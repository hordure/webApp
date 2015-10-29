angular.module('projectApp')
    .controller('allProjectsController',
       ['$scope',
        '$location',
        '$routeParams',
        'getAllProjects',

        function ($scope, $location, $routeParams, getAllProjects) {
            $scope.projects = getAllProjects.query();
            
        }]);