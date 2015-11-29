angular.module('infotainment').factory('ServiceProvider', function ($http, $q, $injector, $location) {


    return {
        Url: $injector.get("urlProvider"),
        Services: $injector.get("InfotainmentService")
    }
});