(function () {
    angular
		.module('infotainment')
		.controller('topNewsCtrl', topNewsCtrl);

    function topNewsCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, Helper, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);


        // Top -News
        $scope.imageNewsList = [];
        $scope.simpleNewsList = [];
        $scope.TopNewsType = NewsType.TopNews;
        $scope.MainNewsTitle = "बड़ी ख़बर";

        //ServiceProvider.Services.getData(ServiceProvider.Url.RssTopTenNews, null).then(function (result) {
        //    if (result != null) {
        //        var counter = 0;
        //        angular.forEach(result, function (news) {
        //            if (counter++ < 10 && !Helper.IsNullOrEmptyOrUndefined(news.ImageUrl)) {
        //                $scope.imageNewsList.push(news);
        //            }
        //            else {
        //                $scope.simpleNewsList.push(news);
        //            }
        //        });

        //         if (!$scope.$$phase) { $scope.$apply(); }
        //    }
        //});

        $scope.LoadTopNews = function () {
            ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNews, null).then(function (result) {
                if (result != null) {
                    $scope.imageNewsList = $filter('topRows')(result, 9);
                    angular.forEach($filter('restRows')(result, 9), function (news) {
                        $scope.simpleNewsList.push(news);
                    });

                    //if (!$scope.$$phase) {
                    //    $scope.$apply();
                    //}
                }
            });
        };

        $scope.LoadTopNewsHeading = function () {
            ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNewsHeading, null).then(function (result) {
                if (result != null) {
                    angular.forEach(result, function (news) {
                        $scope.simpleNewsList.push(news);
                    });

                }
            });
        };

        $scope.LoadAllNews = function () {
            $scope.LoadTopNews();
            $scope.LoadTopNewsHeading();
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        }

        $scope.LoadAllNews();

    };
})();





