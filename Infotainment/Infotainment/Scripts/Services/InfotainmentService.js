angular.module('infotainment').factory('InfotainmentService', function ($http, $q) {
    
    var webHost = "";

    return {
        Host: function setHost(host) {
            webHost = host +"/";
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