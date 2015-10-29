angular.module('projectApp')
    .controller('employeeController',
       ['$scope',
        '$location',
        '$routeParams',
        'Employees',
        
        function ($scope, $location, $routeParams, Employees) {

            $scope.employees = Employees.query();

        }]);

angular.module('projectApp')
    .controller('employeeDetailsController',
       ['$scope',
        '$location',
        '$routeParams',
        'Employees',

        function ($scope, $location, $routeParams, Employees) {

            var employee = Employees.get({ id: $routeParams.id }, function () {

                var e = employee;

                $scope.employee = e;

            });

        }]);

angular.module('projectApp').controller('employeeUpdateController', ['$scope', '$routeParams', 'EmployeesEdit', '$location', function ($scope, $routeParams, EmployeesEdit, $location) {

    var aemployee = EmployeesEdit.get({ id: $routeParams.id }, function () {
        $scope.employee= aemployee;
        var e = $scope.employee;

        $eid = e.eid;

        $scope.edit = function () {

            aemployee.$update({ id: $routeParams.id }, $scope.employee);

            $location.path('/employeesEdited/' + $scope.employee.eid);
        }

        $scope.continue = function () {
            $location.path('employees/' + $scope.employee.eid);
           
        }

    });

}]);

