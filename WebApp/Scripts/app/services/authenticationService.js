app.service('authenticationService', ['$http', '$cookieStore', function authSvc($http, $cookieStore) {
    var userData = {
        isAuthenticated: false,
        username: '',
        roles: '',
        bearerToken: '',
        expirationDate: null
    };

    console.log("authService");

    function NoAuthenticationException(message) {
        this.name = 'AuthenticationRequired';
        this.message = message;
    }

    function NextStateUndefinedException(message) {
        this.name = 'NextStateUndefined';
        this.message = message;
    }

    function AuthenticationExpiredException(message) {
        this.name = 'AuthenticationExpired';
        this.message = message;
    }

    function AuthenticationRetrievalException(message) {
        this.name = 'AuthenticationRetrieval';
        this.message = message;
    }

    function isAuthenticationExpired(expirationDate) {
        var now = new Date();
        expirationDate = new Date(expirationDate);
        if (expirationDate - now > 0) {
            return false;
        } else {
            return true;
        }
    }

    function removeData() {
        $cookieStore.remove('auth_data');
    }

    function saveData() {
        removeData();
        $cookieStore.put('auth_data', userData);
    }


    this.showAdmin = function (trueorfalse) {
        showAdmin = trueorfalse;
        console.log(showAdmin);
        return showAdmin;
    };


    function retrieveSavedData() {
        var savedData = $cookieStore.get('auth_data');
        if (typeof savedData === 'undefined') {
            throw new AuthenticationRetrievalException('No authentication data exists');
        } else if (isAuthenticationExpired(savedData.expirationDate)) {
            throw new AuthenticationExpiredException('Authentication token has already expired');
        } else {
            userData = savedData;
            setHttpAuthHeader();
        }
    }

    function clearUserData() {
        userData.isAuthenticated = false;
        userData.username = '';
        userData.roles = '';
        userData.bearerToken = '';
        userData.expirationDate = null;
    }



    this.isAuthenticated = function () {
        if (userData.isAuthenticated && !isAuthenticationExpired(userData.expirationDate)) {
            return true;
        } else {
            try {
                retrieveSavedData();
            } catch (e) {
                throw new NoAuthenticationException('Authentication not found');
            }
            return true;
        }
    };

    this.getUserData = function () {
        return userData;
    }

    function setHttpAuthHeader() {
        $http.defaults.headers.common.Authorization = 'Bearer ' + userData.bearerToken;
    }

    this.removeAuthentication = function () {
        clearUserData();
        removeData();
        $http.defaults.headers.common.Authorization = null;
    };

    this.authenticate = function (username, password, successCallback, errorCallback, persistData) {
        this.removeAuthentication();
        var config = {
            method: 'POST',
            url: 'token',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
            },
            data: 'grant_type=password&username=' + username + '&password=' + password,
        };

        $http(config)
          .success(function (data) {
              userData.isAuthenticated = true;
              userData.username = data.userName;
              userData.bearerToken = data.access_token;
              userData.roles = data.roles;
              userData.expirationDate = new Date(data['.expires']);
              setHttpAuthHeader();
              
              if (persistData === true) {
                  saveData();
              }
              if (typeof successCallback === 'function') {
                  successCallback();
              }
              
          })
          .error(function (data) {
              if (typeof errorCallback === 'function') {
                  if (data.error_description) {
                      errorCallback(data.error_description);
                  } else {
                      errorCallback('Unable to contact server; please, try again later.');
                  }
              }
          });
        
    };

    this.signUp = function (username, password, confirmPassword, successCallback, errorCallback, persistData) {
        var config = {
            method: 'POST',
            url: '/api/Account/Register',
            headers: {
                'Content-Type': 'application/json',
            },
            data: {
                Email: username,
                Password: password,
                ConfirmPassword: confirmPassword
            }
        };

        var me = this;
        $http(config).
            success(function (data) {
                me.authenticate(username, password, successCallback, errorCallback, persistData);

            }).
            error(function (data) {
                if (typeof errorCallback === 'function') {
                    if (data.error_description) {
                        errorCallback(data.error_description);
                    } else {
                        errorCallback('Unable to contact server; please, try again later');
                    }
                }

            });
    }
}]);