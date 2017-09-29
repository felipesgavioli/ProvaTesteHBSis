'use strict';
app.controller('clientesController', ['$scope', '$location', '$timeout', 'clientesService', function ($scope, $location, $timeout, clientesService) {

    $scope.cliente = {
        Nome: "",
        CpfCnpf: "",
        Telefone: ""
    };

    $scope.loading = true;
    $scope.addMode = false;


    $scope.toggleEdit = function () {
        this.cliente.editMode = !this.cliente.editMode;
    };

    $scope.toggleAdd = function () {
        $scope.cliente = {};
        $scope.addMode = !$scope.addMode;
    };
    
    var _showCliente = function () {
        clientesService.getClientes().then(function (result) {
            $scope.Clientes = result.data
            $scope.loading = false;
        }, function (error) {
            bootbox.alert("Erro para consultar os clientes: " + error.data.ExceptionMessage);
            $scope.Clientes = [];
            $scope.loading = false
        });
    };
    _showCliente();

    //Inser cliente
    $scope.insert = function () {
        if ($scope.cliente.Nome === undefined || $scope.cliente.CpfCnpj === undefined || $scope.cliente.Telefone === undefined) {
            return;
        }

        $scope.loading = true;

        clientesService.insertCliente($scope.cliente).then(function (result) {
            $scope.addMode = false;
            $scope.loading = false;
            _showCliente();

        }, function (error) {
            bootbox.alert("Erro para salvar o cliente: " + error.statusText);
            $scope.loading = false;
            _showCliente();
        });

    };

    //Edit cliente
    $scope.update = function () {

        var cliente = this.cliente;
        if (cliente.Nome === undefined || cliente.CpfCnpj === undefined || cliente.Telefone === undefined) {
            bootbox.alert("Preencha todos os campos.");
            return;
        }
        $scope.loading = true;       

        clientesService.updateCliente(cliente).then(function (result) {
            cliente.editMode = false;
            $scope.loading = false;
            _showCliente();
        }, function (error) {
            bootbox.alert("Erro para atualizar o cliente: " + error.statusText);
            cliente.editMode = false;
            $scope.loading = false;
            _showCliente();
        });

    };

    //Delete cliente
    $scope.delete = function () {

        $scope.addMode = false;
        $scope.loading = true;
        var cliente = this.cliente;

        clientesService.deleteCliente(cliente.ClienteId).then(function (result) {
            $scope.loading = false;
            _showCliente();
        }, function (error) {
            bootbox.alert("Erro para excluír o cliente: " + error.statusText);
            cliente.editMode = false;
            $scope.loading = false;;
            _showCliente();
        });

    };
}]);