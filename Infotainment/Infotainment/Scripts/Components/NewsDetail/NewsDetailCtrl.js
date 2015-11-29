(function () {
    angular
		.module('infotainment')
		.controller('newsDetailCtrl', newsDetailCtrl);

    function newsDetailCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);

        $scope.imageNewsList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNews, null).then(function (result) {
            if (result != null) {
                $scope.imageNewsList = result;
            }
        });

        $scope.simpleNewsHeading = "बरी खबरें";
        $scope.simpleNewsList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNewsDesc, null).then(function (result) {
            if (result != null) {
                $scope.simpleNewsList = result;
            }
        });


        var parameter = $location.$$absUrl.split('?');
        if (parameter.length > 1) {
            parameter = parameter[1];
        }
        parameter = parameter.split('=');

        var newsType = parameter.length > 1 ? parameter[1] : Constants.Empty;
        var url = Constants.Empty;

        switch (newsType) {
            case NewsType.TopNews.toString():
                url = ServiceProvider.Url.TopNewsList;
                break;
        }


        $scope.PartialNewsList = [];
        $scope.nextPage = 0;
        $scope.loadingMore = false;
        $scope.PartialNewsBusy = false;
        $scope.pagingFunction = function () {
            if (!$scope.PartialNewsBusy) {
                $scope.loadingMore = true;
                ServiceProvider.Services.getData(url + $scope.nextPage, null).then(function (result) {
                    if (result != null) {
                        $scope.loadingMore = false;
                        if (result.length > 0) {
                            $scope.nextPage = $scope.nextPage + result.length;
                            // $scope.PartialNewsBusy = false;
                            angular.forEach(result, function (listItem) {
                                $scope.PartialNewsList.push(listItem);
                            });
                        }
                        else {
                            $scope.PartialNewsBusy = true;
                        }
                    }
                });
            };
        };
        $scope.pagingFunction();




        $scope.advertiseList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNewsAdvertise, null).then(function (result) {
            if (result != null) {
                $scope.advertiseList = result;
            }
        });

    };
})();