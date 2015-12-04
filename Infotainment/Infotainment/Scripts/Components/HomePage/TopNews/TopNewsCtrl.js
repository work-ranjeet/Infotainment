(function () {
    angular.module('infotainment').controller('TopNewsCtrl', TopNewsCtrl);

    function TopNewsCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $interval, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);

        $scope.NewsType = NewsType.TopNews;
        $scope.MainNewsTitle = "बड़ी ख़बर";

        $scope.videoHeading = "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई";
        $scope.videoUrl = $sce.trustAsResourceUrl("http://www.youtube.com/embed/OulN7vTDq1I");

      
        $scope.imageNewsList = [];
        $scope.simpleNewsHeading = "बरी खबरें";
        $scope.simpleNewsList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNewsWithRss, null).then(function (result) {
            if(result != null)
            {
                $scope.imageNewsList = result;
            }
        });

        //ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNews, null).then(function (result) {
        //    if(result != null)
        //    {
        //        $scope.imageNewsList = result;
        //    }
        //});
        
        //ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNewsDesc, null).then(function (result) {
        //    if (result != null) {
        //        $scope.simpleNewsList = result;
        //    }
        //});

        $scope.advertiseList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNewsAdvertise, null).then(function (result) {
            if (result != null) {
                $scope.advertiseList = result;
            }
        });


    };
})();