angular.module('infotainment').factory('InfotainmentService', function ($http, $q) {
    var localHost = 'http://localhost:55592/';
    var webUrl = localHost;

    return {

        getPostData: function (url, postdata) {
            var deferred = $q.defer();
            var completeUrl = webUrl + url;

            $http.post(completeUrl, postdata)
              .then(function (result) {
                  deferred.resolve(result.data);
              });
            return deferred.promise;
        },

        getData: function (url, locale) {
            var deferred = $q.defer();
            var completeUrl = webUrl + url;

            $http.get(completeUrl)
              .then(function (result) {
                  deferred.resolve(result.data);
              });
            return deferred.promise;
        }
    }
});