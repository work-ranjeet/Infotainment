
// String Functionality
angular.module('infotainment').factory('Session', function () {

    var _stateCode;
    return {        
       StateCode : _stateCode

    }

    function SetStateCode(code)
    {
        _stateCode = code;
    }
    function GetStateCode() {
        return _stateCode;
    }
});