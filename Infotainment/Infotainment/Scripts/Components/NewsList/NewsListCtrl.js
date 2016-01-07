(function () {
    angular
		.module('infotainment')
		.controller('newsListCtrl', newsListCtrl);

    function newsListCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $cookieStore, ServiceProvider, Session) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);

        $scope.NewsListController ="";

        var parameters = $location.$$absUrl.split('?');
        if (parameters.length > 1) {
            parameters = parameters[1];
        }

        var parameters = parameters.split('&');

        var code = "";
        var newsTypeparam = "";
        if (parameters.length > 0 && parameters[0] != undefined)
        {
            newsTypeparam = parameters[0].split('=');
        }

        if (parameters.length > 1 && parameters[1] != undefined) {
            code = parameters[1].split('=');
        }

        //parameters = parameters.split('=');

        var newsType = newsTypeparam.length > 1 ? newsTypeparam[1] : Constants.Empty;
        var codeValue = code.length > 1 ? code[1] : Constants.Empty;

        var url = Constants.Empty;
        var addUrl = Constants.Empty;

        switch (newsType) {
            case NewsType.TopNews.toString():
                url = ServiceProvider.Url.TopNewsList;
                addUrl = ServiceProvider.Url.TopTenNewsAdvertise;
                $scope.NewsListController = "MainNews";
                break;

            case NewsType.InternationalNews.toString():
                url = ServiceProvider.Url.InternationalNewsList;
                addUrl = ServiceProvider.Url.TopTenNewsAdvertise;
                $scope.NewsListController = "InternationalNews";
                break;

            case NewsType.StateNews.toString():
                //?StateCode=@NextPage=
                url = ServiceProvider.Url.StateNewsList + "?StateCode=" + codeValue + "&NextPage=";
                addUrl = ServiceProvider.Url.TopTenNewsAdvertise;
                $scope.NewsListController = "StateNews";
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
        ServiceProvider.Services.getData(addUrl, null).then(function (result) {
            if (result != null) {
                $scope.advertiseList = result;
            }
        });


    };
})();