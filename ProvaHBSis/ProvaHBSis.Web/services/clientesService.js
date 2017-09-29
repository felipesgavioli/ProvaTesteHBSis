'use strict';
app.factory('clientesService', ['$http', '$q', 'storageService', 'md5', function ($http, $q, storageService, $md5) {

    var serviceBase = 'http://localhost:50800/';
    var clienteService = {};

    var _getAll = function () {

        return $http.get(serviceBase + 'api/clientes', { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (results) {
            return results;
        });
    };

    var _getById = function (id) {

        return $http.get(serviceBase + 'api/clientes/' + id, { headers: { 'Content-Type': 'application/json' } }).then(function (results) {
            return results;
        });
    };

    var _delete = function (id) {
        return $http.delete(serviceBase + 'api/clientes/'+ id, { headers: { 'Content-Type': 'application/json' } });
    };
   
    var _insert = function (cliente) {
        return $http.post(serviceBase + 'api/clientes', cliente, { headers: { 'Content-Type': 'application/json' } });
    };

    var _update = function (cliente) {
        return $http.put(serviceBase + 'api/clientes', cliente, { headers: { 'Content-Type': 'application/json' } });
    };

    clienteService.getClientes = _getAll;
    clienteService.getClienteById = _getById;
    clienteService.deleteCliente = _delete;
    clienteService.insertCliente = _insert;
    clienteService.updateCliente = _update;

    return clienteService;

}]);