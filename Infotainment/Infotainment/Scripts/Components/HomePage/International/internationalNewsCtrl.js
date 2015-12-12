(function () {
    angular
		.module('infotainment')
		.controller('internationalNewsCtrl', internationalNewsCtrl);

    function internationalNewsCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);
        $scope.InterNewsType = NewsType.InternationalNews;


        $scope.InterTitle = "अंतरराष्ट्रीय खबर";
        $scope.Others = "अन्य खबर";

        $scope.HasInterNews = false;
        $scope.InternationalNewsList = [];
        $scope.InternationalNewsHeaderList = [];

        ServiceProvider.Services.getData(ServiceProvider.Url.InternationalNews, null).then(function (result) {
            if (result != null) {
                
                $scope.InternationalNewsList = $filter('topRows')(result, 5);
                $scope.InternationalNewsHeaderList =$filter('limitTo')( $filter('restRows')(result, 5), 7);
                $scope.HasInterNews = $scope.InternationalNewsList.length > 0;
            }
        });



    };
})();
