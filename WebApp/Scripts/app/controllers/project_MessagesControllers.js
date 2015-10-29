app.controller('project_MessagesController', ['$scope', '$http', 'allProjectMessages', '$location', function ($scope, $http, allProjectMessages, $location) {

    $scope.project_messages = allProjectMessages.query();

}]);

app.controller('project_MessageDetailsController', ['$scope', '$routeParams', '$http', 'projectMessages', '$location', function ($scope, $routeParams, $http, projectMessages, $location) {

    var project_message = projectMessages.get({ id: $routeParams.id }, function () {
        var pm = project_message;
        $scope.pmessage = pm;

        $scope.edit = function () {
            project_message.$update({ id: $routeParams.id }, $scope.pmessage);

            $location.path('/editedProject_message/' + $scope.pmessage.pmid);
        }

        $scope.continue = function () {
            $location.path('/project_messagesDetails/' + $scope.pmessage.pmid);

        }

        $scope.delclick = function (pmid) {
            var r = confirm("Viltu eyða þessum skilaboðum?");
            if (r == true) {
                projectMessages.delete({ id: pmid },
                    function () {
                        $location.path('/project_messages');
                    });
            }
        }

    });

}]);

