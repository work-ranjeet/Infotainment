(function () {
    angular
		.module('infotainment')
		.controller('mainCtrl', mainCtrl);

    function mainCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);
        $scope.shortDescLimit = 220;

        $scope.Moreheading = "और भी पढें";

        $scope.todayDate = $filter('hindiDate')(new Date());
        $scope.fbUrl = SocilMediaLink.FaceBook;
        $scope.twiterUrl = SocilMediaLink.Twiter;
        $scope.gPlusUrl = SocilMediaLink.GPlus;

        $scope.AboutUS = AboutUs;

        $scope.OpenWindow = function (url) {
            var win = window.open(url, "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=10, left=400, width=1100, height=950");
            win.focus();
        };

      

        $scope.addHomePage = function () {
            $('#pageContainer').empty();

            $('#pageContainer').append($compile("<homepage></homepage>"));
        };

         $scope.addAboutPage= function () {
            $('#pageContainer').empty();

            $('#pageContainer').append($compile("<aboutus></aboutus>"));
        };

    };

})();




