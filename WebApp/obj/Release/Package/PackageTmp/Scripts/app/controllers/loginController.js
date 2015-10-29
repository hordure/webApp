angular.module('projectApp')
    .controller('loginController',
       ['$scope',
        '$location',
        'Employees',

        function ($scope, $location, Login) {
            $scope.employees = Login.query();


        }]);