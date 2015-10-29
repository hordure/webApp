var app = angular.module('projectApp', ['ngRoute', 'ngResource','ngCookies']);

app.config([
    '$routeProvider',
    function ($routeProvider, $location) {
        $routeProvider.when(
        '/project',
        {
            templateUrl: 'Home/Project',
            controller: 'projectController'
        });
        $routeProvider.when(
        '/project/create',
        {
            templateUrl: 'Home/CreateProject',
            controller: 'projectManageController'
        });
        
        $routeProvider.when(
        '/project/:id',
        {
            templateUrl: 'Home/ProjectDetails',
            controller: 'projectDetailsController'
        });
        $routeProvider.when(
        '/projectsEdit/:id',
        {
            templateUrl: 'Home/EditProject',
            controller: 'projectUpdateController'
        });
        $routeProvider.when(
        '/projectsEdited/:id',
        {
            templateUrl: 'Home/EditedProject',
            controller: 'projectUpdateController'
        });
        $routeProvider.when(
          '/login',
          {
              templateUrl: 'Home/login',
              controller: 'authenticationController'
          });
        $routeProvider.when(
          '/allprojects',
          {
              templateUrl: 'Home/allprojects',
              controller: 'headerController'
          });
        $routeProvider.when(
           '/employees',
           {
               templateUrl: 'OtherViews/Employees',
               controller: 'employeeController'
           });
        $routeProvider.when(
           '/employees/:id',
           {
               templateUrl: 'OtherViews/EmployeeDetails',
               controller: 'employeeDetailsController'
           });
        $routeProvider.when(
            '/employeesEdit/:id',
           {
               templateUrl: 'OtherViews/EditEmployee',
               controller: 'employeeUpdateController'
           });
        $routeProvider.when(
            '/employeesEdited/:id',
           {
               templateUrl: 'OtherViews/EditedEmployee',
               controller: 'employeeUpdateController'
           });
        $routeProvider.when(
            '/project_messages',
           {
               templateUrl: 'OtherViews/ProjectMessages',
               controller: 'project_MessagesController'
           });
        $routeProvider.when(
            '/project_messagesDetails/:id',
           {
               templateUrl: 'OtherViews/ProjectMessageDetail',
               controller: 'project_MessageDetailsController'
           });
        $routeProvider.when(
            '/editProject_message/:id',
           {
               templateUrl: 'OtherViews/EditProjectMessage',
               controller: 'project_MessageDetailsController'
           });
        $routeProvider.when(
            '/editedProject_message/:id',
           {
               templateUrl: 'OtherViews/EditedProjectMessage',
               controller: 'project_MessageDetailsController'
           });
        $routeProvider.when(
           '/project_costs',
          {
              templateUrl: 'OtherViews/ProjectCosts',
              controller: 'project_CostsController'
          });
        $routeProvider.when(
            '/project_costDetails/:id',
           {
               templateUrl: 'OtherViews/ProjectCostDetail',
               controller: 'project_CostDetailsController'
           });
        $routeProvider.when(
            '/editProject_cost/:id',
           {
               templateUrl: 'OtherViews/EditProjectCost',
               controller: 'project_CostDetailsController'
           });
        $routeProvider.when(
            '/editedProject_cost/:id',
           {
               templateUrl: 'OtherViews/EditedProjectCost',
               controller: 'project_CostDetailsController'
           });
        $routeProvider.when(
           '/project_hours',
          {
              templateUrl: 'OtherViews/ProjectHours',
              controller: 'project_HoursController'
          });
        $routeProvider.when(
            '/project_hourDetails/:id',
           {
               templateUrl: 'OtherViews/ProjectHourDetails',
               controller: 'project_HourDetailsController'
           });
        $routeProvider.when(
            '/editProject_hours/:id',
            {
                templateUrl: 'OtherViews/EditProjectHours',
                controller: 'project_HourDetailsController'
            });
        $routeProvider.when(
            '/editedProject_hour/:id',
            {
                templateUrl: 'OtherViews/EditedProjectHours',
                controller: 'project_HourDetailsController'
            });
        $routeProvider.otherwise({ redirectTo: '/login' });
    }]);

app.config(function ($resourceProvider) {
    $resourceProvider.defaults.stripTrailingSlashes = false;
});

app.run(function (authenticationService, $location) {
    // check to see if there is a cookie with authentication information
    //if so the user is logged in automatically. This would be the case 
    //if the user checked the "Remember me" last time he/she signed in.
    try {
        authenticationService.isAuthenticated();
    } catch (e) {
        //the user is not authenticated, that's ok
        //don't do anything with this
        $location.path('/login');
    }
});