angular.module('projectApp')
    .controller('allProjectsController',
       ['$scope',
        '$location',
        '$routeParams',
        'getAllProjects',

        function ($scope, $location, $routeParams, getAllProjects) {
            var projects = getAllProjects.query({}, function (data) {

                $scope.projects = projects;

                for (var i = 0; i < projects.length; i++) {

                    if (projects[i].projectisfinished === true) {
                            
                        $scope.projects[i].projectisfinished = "Lokið";
                        
                        
                    } else {
                            
                        $scope.projects[i].projectisfinished = "Í vinnslu";
                       
                    }
                }


            });
            
        }]);