angular.module('infotainment').factory('InfotainmentService', function ($http, $q, $location) {
    
    var webHost = "";
    var absUrl = $location.$$absUrl+"/";
    return {
        Host: function setHost(host) {

            webHost = host + "/Infotainment/";
        },

        getPostData: function (url, postdata) {
            var deferred = $q.defer();
            var completeUrl = webHost + url;

            $http.post(completeUrl, postdata)
              .then(function (result) {
                  deferred.resolve(result.data);
              });
            return deferred.promise;
        },

        getData: function (url, locale) {
            var deferred = $q.defer();
            var completeUrl = webHost + url;

            $http.get(completeUrl)
              .then(function (result) {
                  deferred.resolve(result.data);
              });
            return deferred.promise;
        }
    }
});