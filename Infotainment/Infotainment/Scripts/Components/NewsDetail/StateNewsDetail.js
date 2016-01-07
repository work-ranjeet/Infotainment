(function () {
    angular
		.module('infotainment')
		.controller('stateNewsDetailCtrl', stateNewsDetailCtrl);

    function stateNewsDetailCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $cookieStore, ServiceProvider, Session) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);


        $scope.imageNewsList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.StateNews, null).then(function (result) {
            if (result != null) {
                $scope.imageNewsList = result[$cookieStore.get(CookieKey.StateCodeKey)];
            }
        });

        $scope.advertiseList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNewsAdvertise, null).then(function (result) {
            if (result != null) {
                $scope.advertiseList = result;
            }
        });
    };
})();