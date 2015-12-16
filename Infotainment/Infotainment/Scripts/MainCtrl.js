(function () {
    angular
		.module('infotainment')
		.controller('mainCtrl', mainCtrl);

    function mainCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, Helper, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);
        $scope.shortDescLimit = 230;

        $scope.Moreheading = "और भी पढें";

        $scope.todayDate = $filter('hindiDate')(new Date());
        $scope.fbUrl = SocilMediaLink.FaceBook;
        $scope.twiterUrl = SocilMediaLink.Twiter;
        $scope.gPlusUrl = SocilMediaLink.GPlus;

        $scope.showmenu = false;
        $scope.toggleMenu = function () {
            $scope.showmenu = ($scope.showmenu) ? false : true;
            //window.location.assign("http://www.w3schools.com")
        }

//         $scope.IsSliderMenuVisble = true;
//         $scope.sliderMenuToggle = function () {
//             $("#sliderMenuSection").animate({
//                 width: 'toggle'
//             });
// 
//             $scope.IsSliderMenuVisble = !$scope.IsSliderMenuVisble;
//         };
//         $scope.closeMenu = function () {
//             if ($scope.IsSliderMenuVisble) {
//                 $("#sliderMenuSection").animate({
//                     width: 'toggle'
//                 });
// 
//                 $scope.IsSliderMenuVisble = false;
//             }
//         };

        $scope.OpenWindow = function (url) {
            var win = window.open(url, "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=10, left=400, width=1100, height=950");
            win.focus();
        };

        // Video News
        $scope.videoHeading = "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई";
        $scope.videoUrl = $sce.trustAsResourceUrl("http://www.youtube.com/embed/OulN7vTDq1I");

       

    };

})();




