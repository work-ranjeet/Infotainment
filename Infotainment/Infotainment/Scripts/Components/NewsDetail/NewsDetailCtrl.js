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
        ServiceProvider.Services.getData(url, null).then(function (result) {
            if (result != null) {
                $scope.PartialNewsList = result;
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