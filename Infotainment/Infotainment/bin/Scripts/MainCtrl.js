(function () {
    angular
		.module('infotainment')
		.controller('mainCtrl', mainCtrl);

    function mainCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, Helper, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);
        $scope.shortDescLimit = 250;

        $scope.Moreheading = "और भी पढें";

        $scope.todayDate = $filter('hindiDate')(new Date());
        $scope.fbUrl = SocilMediaLink.FaceBook;
        $scope.twiterUrl = SocilMediaLink.Twiter;
        $scope.gPlusUrl = SocilMediaLink.GPlus;

        $scope.OpenWindow = function (url) {
            var win = window.open(url, "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=10, left=400, width=1100, height=950");
            win.focus();
        };

        // Video News
        $scope.videoHeading = "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई";
        $scope.videoUrl = $sce.trustAsResourceUrl("http://www.youtube.com/embed/OulN7vTDq1I");

        // Top -News
        $scope.imageNewsList = [];
        $scope.simpleNewsList = [];
        $scope.TopNewsType = NewsType.TopNews;
        $scope.MainNewsTitle = "बड़ी ख़बर";
       
        ServiceProvider.Services.getData(ServiceProvider.Url.RssTopTenNews, null).then(function (result) {
            if (result != null) {
                var counter = 0;
                angular.forEach(result, function (news) {
                    if (counter++ < 10 && !Helper.IsNullOrEmptyOrUndefined(news.ImageUrl)) {
                        $scope.imageNewsList.push(news);
                    }
                    else {
                        $scope.simpleNewsList.push(news);
                    }
                });
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

    };

})();




