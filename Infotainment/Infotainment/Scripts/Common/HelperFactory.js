
// String Functionality
angular.module('infotainment').factory('Helper', function () {
    return {        
        Empty: Constants.Empty,

        IsNull: function (value) {
            return value === Constants.NullValue;
        },

        IsNullOrEmpty: function (value) {
            return value === Constants.Empty || value === Constants.NullValue;
        },

        IsNullOrEmptyOrUndefined: function (value) {
            return (typeof value === "undefined") || value === Constants.Empty || value === Constants.NullValue;
        },
        
        IsValidArry: function (value) {
            return angular.isDefined(value) && value != Constants.Empty && value != Constants.NullValue && value.length > 0
                && angular.isDefined(value[0]) && value[0] != Constants.Empty && value[0] != Constants.NullValue;
         },

        IsHTMLBind: confirmIsHtmlBind

    }

    function confirmIsHtmlBind(dataFormat) {
        switch (dataFormat) {
            case DataFormat.Address:
            case DataFormat.MoreText:
            case DataFormat.Url:
                return true;


            default:
                return false;
        }
    };
   
});