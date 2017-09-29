'use strict';
app.factory('storageService', ['$localStorage', '$sessionStorage', function ($localStorage, $sessionStorage) {

    var storageService = {};
    var mode = 'local';

    var _setMode = function (_mode) {
        mode = _mode;
    }

    var _get = function (k) {
        if (mode === 'session')
            return eval("$sessionStorage." + k);
        else if (mode === 'local')
            return eval("$localStorage." + k);;
    }

    var _set = function (k, v) {
        if (mode === 'session')
            $sessionStorage[k] = v;
        else if (mode === 'local')
            $localStorage[k] = v;
    }

    var _delete = function (k, v) {
        if (mode === 'session')
            eval("delete $sessionStorage." + k + ";");
        else if (mode === 'local')
            eval("delete $localStorage." + k + ";");
    }
   
    storageService.setMode = _setMode;
    storageService.get = _get;
    storageService.set = _set;
    storageService.delete = _delete;

    return storageService;

}]);