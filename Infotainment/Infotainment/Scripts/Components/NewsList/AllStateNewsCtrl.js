(function () {
    angular
		.module('infotainment')
		.controller('allStateNewsCtrl', allStateNewsCtrl);

    function allStateNewsCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $cookieStore, Helper, ServiceProvider, Session) {
        $scope.StateNewsType = NewsType.StateNews;
        $scope.StateNewsDictionary = []
        $scope.stateNewsData = [];


        $scope.loadNews = function (states) {
            angular.forEach(states, function (stateCode) {
                var stateNews = $scope.StateNewsDictionary[stateCode.Code];
                var newsCounter = 0;
                var newsList = [];
                angular.forEach(stateNews, function (stateNewsItem) {
                    if (!Helper.IsNullOrEmptyOrUndefined(stateNewsItem.ImageUrl) && newsCounter++ <= 2) {
                        newsList.push(stateNewsItem);
                    }
                });

                if (newsList.length > 0)
                {
                    $scope.stateNewsData.push({ StateCode: stateCode.Code, StateName: stateCode.NameHindi, NewsList: newsList });
                }
            });

        };

        $scope.loadState = function () {
            $q.all([
                ServiceProvider.Services.getData(ServiceProvider.Url.StateNews, null),
                ServiceProvider.Services.getData(ServiceProvider.Url.StateCode, null)])
                .then(function (result) {
                    if (result && result[0] && result[1] && result != null && result[0] != null && result[1] != null) {
                        $scope.StateNewsDictionary = result[0];

                        $scope.loadNews(result[1]);
                    };
                });
        };

        $scope.loadState();
    }
})();