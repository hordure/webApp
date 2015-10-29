angular.module('projectApp')
    .controller('projectController',
       ['$scope',
        '$location',
        '$routeParams',
        'Projects',
        'affiliateProjects',
        
        
        function ($scope, $location, $routeParams, Project, affiliateProjects) {

            $scope.projects = Project.query();

            document.getElementById("btnMyProjects2").style.backgroundColor = "lightgrey";
            
   
            $scope.otherProjects = function () {  
                document.getElementById("btnOtherProjects").style.backgroundColor = "lightgrey";
                document.getElementById("btnMyProjects2").style.backgroundColor = "transparent";
                $scope.projects = affiliateProjects.query();
            }

            $scope.myProjects = function () {      
                document.getElementById("btnOtherProjects").style.backgroundColor = "transparent";
                document.getElementById("btnMyProjects2").style.backgroundColor = "lightgrey";
                $scope.projects = Project.query();
            }
  
    
        }]);

angular.module('projectApp')
    .controller('projectDetailsController',
        ['$scope',
            '$http',
            '$location',
            '$rootScope',
            'Projects',
            'addprojectMessage',
            'projectCosts',
            'projectHours',
            'projectEmployees',
            'empsNotInProject',
            'currentEmployee',
            '$routeParams',

            function ($scope, $http, $location, $rootScope, Projects, addprojectMessage, projectCosts, projectHours, projectEmployees, empsNotInProject, currentEmployee, $routeParams) {
                var project = Projects.get({ id: $routeParams.id }, function (projDat) {
                    
                    var user = currentEmployee.get({}, function (userDat) {
                        if (userDat.eid === projDat.employee_eid) {
                            $scope.isOwner = true;
                        }

                    });
                    
                    


                var p = project;
                $scope.project = p;

                if (project.projectisfinished === true) {
                    $scope.project.isfinished = "Lokið";
                    $("#status").css("color", "green");
                    $("#status").css("font-weight", "bolder");
                } else {
                    $scope.project.isfinished = "Í vinnslu";
                    $("#status").css("color", "red");
                    $("#status").css("font-weight", "bolder");
                }
                
                $scope.projectEmps = projectEmployees.query();

                $scope.hideMinusPE = true;


                //make project messages option visible if there are any
                if (p.project_messages[0]) {
                    $scope.messages = true;
                }
                else {
                    $scope.messages = false;
                }

                //make project hours option visible if there are any
                
                if (p.project_hours[0]){
                    $scope.hours = true;
                }
                else
                {
                    $scope.hours = false;
                }

                //make project costs option visible if there are any
                
                if (p.project_costs[0]) {
                    $scope.costs = true;
                }
                else {
                    $scope.costs = false;
                }
                

                $scope.projectdetails = true;
                
               

                $scope.showPMessages = false;

                $scope.btnShowMessages = function () {
                    $scope.showPMessages = true; 
                }


                $scope.btnHideMessages = function () {
                    $scope.showPMessages = false;
                }

                $scope.showPHours = false;


                $scope.btnShowHours = function () {
                    $scope.showPHours = true;

                }

                $scope.btnHideHours = function () {
                    $scope.showPHours = false;
                }

                $scope.showPCosts = false;
            
                $scope.btnShowCosts = function () {
                    $scope.showPCosts = true;
                }

                $scope.btnHideCosts = function () {
                    $scope.showPCosts = false;
                }

                $scope.delclick = function (pid) {
                    var r = confirm("Viltu eyða þessu verkefni?");
                    if (r == true) {
                        Projects.delete({ id: pid },
                            function () {
                                $location.path('/project');           
                        });
                    }
                }

                $scope.updclick = function () {
                    $scope.projectdetails = false;
                }
                
                $scope.sendPid = function (pid) {
                    //console.log('hæ');
                    $rootScope.$emit('sendPid', pid);

                }
               
                $scope.createMessage = function () {

                    var newprojectMessage = new addprojectMessage();
                    angular.extend(newprojectMessage, $scope.newprojectMessage);

                    newprojectMessage.$save(function (projM) {
                        
                        location.reload();
                        // do something when save is successful
                    });

                }

                $scope.createCost = function () {

                    var newprojectCost = new projectCosts();
                    angular.extend(newprojectCost, $scope.newprojectCost);

                    newprojectCost.$save(function (projC) {
                        
                        location.reload();
                        // do something when save is successful
                    });

                }

                $scope.createHours = function () {

                    var newprojectHours = new projectHours();
                    angular.extend(newprojectHours, $scope.newprojectHours);

                    newprojectHours.$save(function (projH) {

                        location.reload();
                        // do something when save is successful
                    });

                }



                $scope.cancel = function () {
                    location.reload();
                }

                $scope.addHoursClick = function () {
                    $scope.addHours = true;
                    $scope.addMessage = false;
                    $scope.addCost = false;
                    $scope.projectdetails = false;
                }

                $scope.addMessageClick = function () {
                    $scope.addHours = false;
                    $scope.addMessage = true;
                    $scope.addCost = false;
                    $scope.projectdetails = false;
                }

                $scope.addCostClick = function () {
                    $scope.addHours = false;
                    $scope.addMessage = false;
                    $scope.addCost = true;
                    $scope.projectdetails = false;
                }

                $scope.addProjectEmp = function () {
                    $scope.addEmployee = empsNotInProject.query();
                    $scope.showAddProjectEmp = true;
                    $scope.remEmp = false;
                    $scope.hidePlusPE = true;
                    $scope.hideMinusPE = true;

                }
                $scope.remProjectEmp = function () {
                    $scope.remEmp = true;
                    $scope.showMinusPE = true;
                    $scope.hideMinusPE = false;
                    $scope.showAddProjectEmp = false;
                    $scope.hidePlusPE = false;


                }

                $scope.removeProjectEmp = function (idx, peid) {
                    
                    projectEmployees.delete({ id: peid });
                    $scope.projectEmps.splice(idx, 1);
                    $scope.remEmp = false;
                    $scope.hideMinusPE = false;

                }

                $scope.btnAddProjectEmps = function (eid, pid, idx) {
                    var addE = new projectEmployees();
                    addE.employee_eid = eid;
                    addE.project_pid = pid;
                    addE.$save(function (dat) {
                        var te = projectEmployees.get({ id: dat.employee_eid }); 
                        $scope.projectEmps = projectEmployees.query();
                    });

                    $scope.hidePlusPE = false;

                    $scope.showAddProjectEmp = false;
                    $scope.addEmployee = empsNotInProject.query();

                    
                }

            });
     }]);



app.controller('projectManageController', ['$scope', '$http', 'Projects', '$location',  function ($scope, $http, Projects, $location) {
    
    $scope.create = function () {

        var newproject = new Projects();
        angular.extend(newproject, $scope.newproject);
        newproject.pdate = Date.now();
        console.log(newproject);


        newproject.$save(function (proj) {
            $location.path('/project/' + proj.pid);
            // do something when save is successful
        });
        
    }


}]);


angular.module('projectApp').controller('projectUpdateController', ['$scope', '$routeParams', 'editProject', '$location', function ($scope, $routeParams, editProject, $location) {

    var aproject = editProject.get({ id: $routeParams.id }, function () {
        $scope.eproject = aproject;
        var e = $scope.eproject;
        


        $pid = e.pid;

        $scope.edit = function () {

            aproject.$update({ id: $routeParams.id }, $scope.eproject);

            $location.path('/projectsEdited/' + $scope.eproject.pid);
        }

        $scope.continue = function () {
            $location.path('project/' + $scope.eproject.pid);
        }

    });

}]);
