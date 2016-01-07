(function () {
    angular
		.module('infotainment')
		.controller('interNewsDetailCtrl', interNewsDetailCtrl);

    function interNewsDetailCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);


        $scope.imageNewsList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.InternationalNews, null).then(function (result) {
            if (result != null) {
                $scope.imageNewsList = result;
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