app.controller('project_CostsController', ['$scope', '$http', 'allProjectCosts','sumOfCosts', '$location', function ($scope, $http, allProjectCosts,sumOfCosts, $location) {

    $scope.project_costs = allProjectCosts.query();
    $scope.sumOfCosts = sumOfCosts.query();

}]);

app.controller('project_CostDetailsController', ['$scope', '$routeParams', '$http', 'projectCosts', '$location', function ($scope, $routeParams, $http, projectCosts, $location) {

    var project_cost = projectCosts.get({ id: $routeParams.id }, function () {
        var pc = project_cost;
        $scope.pcost = pc;
        
       

        


        $scope.edit = function () {
            var updateCost = [
           pcid = $scope.pcost.pcid,
           cost = $scope.pcost.cost,
           costdescription = $scope.pcost.costdescription,
           project_pid = $scope.pcost.project_pid,
           employee_eid = $scope.pcost.employee_eid,
           employee = null,
           project = null,
           costdate = $scope.pcost.costdate

            ];
            
            project_cost.$update({ id: $routeParams.id }, updateCost);

            $location.path('/editedProject_cost/' + $scope.pcost.pcid);
        }

        $scope.continue = function () {
            $location.path('/project_costsDetails/' + $scope.pcost.pcid);

        }

        $scope.delclick = function (pmid) {
            var r = confirm("Viltu eyða þessum kostnaði?");
            if (r == true) {
                projectCosts.delete({ id: pcid },
                    function () {
                        $location.path('/project_costs');
                    });
            }
        }

    });

}]);