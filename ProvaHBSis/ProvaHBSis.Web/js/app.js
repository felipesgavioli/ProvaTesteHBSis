var app = angular.module('AngularAuthApp', [
    'ngRoute',
    'ngStorage',
    'angular-loading-bar',
    'gdi2290.md5-service',
    'ui.utils.masks'
]);

app.config(function ($routeProvider) {

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/views/signup.html"
    });

    $routeProvider.when("/clientes", {
        controller: "clientesController",
        templateUrl: "/views/clientes.html"
    });

    $routeProvider.otherwise({ redirectTo: "/login" });
});

//app.config(function ($httpProvider) {
//    $httpProvider.interceptors.push('authInterceptorService');
//});

//app.run(['authService', function (authService) {
//    authService.fillAuthData();
//}]);