(function () {
    angular
		.module('infotainment')
		.controller('internationalNewsCtrl', internationalNewsCtrl);

    function internationalNewsCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);
        $scope.NewsType = NewsType.InternationalNews;


        $scope.InterTitle = "अंतरराष्ट्रीय खबर";
        $scope.Others = "अन्य खबर";

        $scope.newsList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.InternationalNews, null).then(function (result) {
            if (result != null) {
                $scope.newsList = result;
            }
        });

      

    };
})();
    