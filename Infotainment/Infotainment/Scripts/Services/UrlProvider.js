angular.module('infotainment').factory('urlProvider', function ($http, $q, $injector) {

    return {
        TopTenNews: "api/homeapi/GetToptenNewsList"
    }
});