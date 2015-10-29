app.controller('project_HoursController', ['$scope', '$http', 'allProjectHours', 'sumOfHours', '$location', function ($scope, $http, allProjectHours, sumOfHours, $location) {

    $scope.project_hours = allProjectHours.query();
    $scope.sumOfHours = sumOfHours.query();

}]);

app.controller('project_HourDetailsController', ['$scope', '$routeParams', '$http', 'projectHours', '$location', function ($scope, $routeParams, $http, projectHours, $location) {

    var project_hour = projectHours.get({ id: $routeParams.id }, function () {
        var ph = project_hour;
        $scope.phour = ph;

        $scope.edit = function () {
            project_hour.$update({ id: $routeParams.id }, $scope.phour);

            $location.path('/editedProject_hour/' + $scope.phour.phid);
        }

        $scope.continue = function () {
            $location.path('/project_hourDetails/' + $scope.phour.phid);

        }

        $scope.delclick = function (phid) {
            var r = confirm("Viltu eyða þessum tímum?");
            if (r == true) {
                projectHours.delete({ id: pmid },
                    function () {
                        $location.path('/project_hours');
                    });
            }
        }

    });

}]);