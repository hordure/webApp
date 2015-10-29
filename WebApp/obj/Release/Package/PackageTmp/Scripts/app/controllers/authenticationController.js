app.controller('authenticationController', ['$scope', '$rootScope', '$resource', 'authenticationService', '$location', 'currentEmployee', function ($scope,$rootScope,  $resource, authenticationService, $location, currentEmployee) {
    clearLoginForm()
    $scope.user = authenticationService.getUserData();
    $scope.persist = true;
    $scope.errors = [];
    $scope.showSignUp = false;

    function disableLoginButton(message) {
        if (typeof message !== 'string') {
            message = 'Attempting login...';
        }
        jQuery('#btn-login').prop('disabled', true).prop('value', message);
    }

    function enableLoginButton(message) {
        if (typeof message !== 'string') {
            message = 'Submit';
        }
        jQuery('#btn-login').prop('disabled', false).prop('value', message);
    }

    function clearLoginForm() {
        $scope.username = '';
        $scope.password = '';
        $scope.confirmPassword = '';
    }

    function onSuccessfulLogin(data) {
        var currentEmp = currentEmployee.get({}, function (data) {

            var role = data.userrole;

            if (role === "admin") {
                
                $rootScope.$emit('showAdm', true);
            }
            else {
      
                $rootScope.$emit('showAdm', false);

            }
        });
        //$state.go('main');
        $scope.errors = [];
        
        
    }

    function onFailedLogin(error) {
        if (typeof error === 'string' && $scope.errors.indexOf(error) === -1) {
            $scope.errors.push(error);
        }
        enableLoginButton();
    }

    clearLoginForm();
    
    $scope.login = function () {
        disableLoginButton();
        
        authenticationService.authenticate($scope.username, $scope.password, onSuccessfulLogin, onFailedLogin, $scope.persist );
        disableLoginButton();
        //setTimeout(function () {
        //    location.reload();
        //}, 5000);
    };

    $scope.logout = function () {
        clearLoginForm();
        authenticationService.removeAuthentication();
        //$state.go('main');
        enableLoginButton();
        //location.reload();
        $location.path('/');

       
    }

    $scope.signUp = function () {
        disableLoginButton();
        authenticationService.signUp($scope.username, $scope.password, $scope.confirmPassword, onSuccessfulLogin, onFailedLogin, $scope.persist);
        $scope.login();
        clearLoginForm();
        //var un = $scope.username;
        //clearLoginForm()
        //$scope.username = un;
        //$scope.showSignUp = false;
    }
}]);