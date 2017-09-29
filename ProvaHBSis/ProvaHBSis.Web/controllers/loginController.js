'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    
    $scope.usuario = {
        UsuarioId: 0,
        Nome: "",
        Senha: ""
    };
  
    $scope.login = function () {
        
        authService.login($scope.usuario).then(function (response) {
            $location.path('/clientes');
        },
         function (err) {
             bootbox.alert("Por favor digite um usuário ou senha validos.");
         });
    };

}]);