angular.module('projectApp').factory('Projects', function ($resource, $routeParams) {
    return $resource(
        '/api/projects/:id', null,
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );
    

});


angular.module('projectApp').factory('getAllProjects', function ($resource, $routeParams) {
    return $resource(
        '/api/all/projects/:id', null,
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

angular.module('projectApp').factory('affiliateProjects', function ($resource, $routeParams) {
    return $resource(
        '/api/affiliate/projects/:id', null,
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

angular.module('projectApp').factory('projectMessages', function ($resource, $routeParams) {
    return $resource(
        '/api/project_messages/:id', 
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );

});

angular.module('projectApp').factory('addprojectMessage', function ($resource, $routeParams) {
    return $resource(
        '/api/addproject_message/:id',
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );

});

angular.module('projectApp').factory('allProjectMessages', function ($resource, $routeParams) {
    return $resource(
        '/api/all/project_messages/:id', null,
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

angular.module('projectApp').factory('projectHours', function ($resource, $routeParams) {
    return $resource(
        '/api/project_hours/:id', 
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

angular.module('projectApp').factory('allProjectHours', function ($resource, $routeParams) {
    return $resource(
        '/api/all/project_hours/:id', null,
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

angular.module('projectApp').factory('projectCosts', function ($resource, $routeParams) {
    return $resource(
        '/api/project_costs/:id', 
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

angular.module('projectApp').factory('allProjectCosts', function ($resource, $routeParams) {
    return $resource(
        '/api/all/project_costs/:id', null,
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

app.factory('editProject', ['$resource', '$routeParams', function ($resource, $routeParams) {
    return $resource(
        '/api/projectsEdit/:id',
        { pid: '@pid' }, 
       { update : { method: 'PUT' } }
    );

}]);

app.factory('sumOfHours', ['$resource', '$routeParams', function ($resource, $routeParams) {
    return $resource(
        '/api/sum/project_hours/:id',
        { pid: '@pid' },
       { update: { method: 'PUT' } }
    );

}]);

app.factory('sumOfCosts', ['$resource', '$routeParams', function ($resource, $routeParams) {
    return $resource(
        '/api/sum/project_costs/:id',
        { pid: '@pid' },
       { update: { method: 'PUT' } }
    );

}]);

app.factory('projectEmployees', ['$resource', '$routeParams', function ($resource, $routeParams) {
    return $resource(
        '/api/project_employees/:id',
        { pid: '@pid' },
       { update: { method: 'PUT' } }
    );

}]);

app.factory('empsNotInProject', ['$resource', '$routeParams', function ($resource, $routeParams) {
    return $resource(
        '/api/empsnotinproject/:id',
        { pid: '@pid' },
       { update: { method: 'PUT' } }
    );

}]);

