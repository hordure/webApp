angular.module('projectApp').factory('Employees', function ($resource) {
    return $resource(
        '/api/employees/:id', null,
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

angular.module('projectApp').factory('EmployeesEdit', function ($resource) {
    return $resource(
        '/api/employeesEdit/:id', 
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});

angular.module('projectApp').factory('currentEmployee', function ($resource) {
    return $resource(
        '/api/currentemployee/:id',
        { Id: "@Id" },
       { 'update': { method: 'PUT' } }
    );


});