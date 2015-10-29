app.controller('headerController', ['$scope', '$rootScope', 'authenticationService', 'getAllProjects', 'currentEmployee', function ($scope, $rootScope, authenticationService, getAllProjects, currentEmployee) {
    //clearLoginForm()

    $rootScope.$on('showAdm', function (event, data) {
        $scope.showAdmin = data; // 'Some data'
    });
    
        $scope.user = authenticationService.getUserData();
        var role = $scope.user.roles;
        console.log(role);
        
        if (role === "Admin") {
            $scope.showAdmin = true;
        }


    $scope.myProjects_click = function () {
        document.getElementById("btnMyProjects").style.color = "white";
        document.getElementById("btnAllProjects").style.color = "grey";
        
        

    }

    $scope.allProjects_click = function () {
        document.getElementById("btnMyProjects").style.color = "grey";
        document.getElementById("btnAllProjects").style.color = "white";
        


    }

    

    }
]);