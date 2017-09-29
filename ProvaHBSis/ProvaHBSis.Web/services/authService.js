'use strict';
app.factory('authService', ['$http', '$q', 'storageService', 'md5', function ($http, $q, storageService, $md5) {

    var serviceBase = 'http://localhost:50800/';
    var authService = {};
    
    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _saveRegistration = function (registration) {

        _logOut();
        registration.Senha = $md5.createHash(registration.Senha);
        return $http.put(serviceBase + 'api/account', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {
       

        var deferred = $q.defer();

        loginData.Senha = $md5.createHash(loginData.Senha)
        $http.post(serviceBase + 'api/account', loginData).success(function (response) {
            
            _authentication.isAuth = true;
            _authentication.userName = loginData.Nome;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });
        return deferred.promise;

    };

    var _logOut = function () {

        _authentication.isAuth = false;
        _authentication.userName = "";

    };

    authService.saveRegistration = _saveRegistration;
    authService.login = _login;
    authService.logOut = _logOut;
    authService.authentication = _authentication;

    return authService;
}]);