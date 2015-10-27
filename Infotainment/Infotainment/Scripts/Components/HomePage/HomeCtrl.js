

(function () {
    angular
		.module('infotainment')
		.controller('homeCtrl', indexCtrl);

    function indexCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile) {
        //var childWindow;
        //$scope.value = "testing";
        //$scope.open = function (v) {
        //    var windowWidth = (90 * screen.width) / 100;
        //    var windowHeight = (75 * screen.height) / 100;
        //    var left = (screen.width - windowWidth) / 2;
        //    var top = (screen.height - windowHeight) / 2;

        //    alert(v);

        //    var urlWithpara = "/home/home";
        //    var feature = "status=yes,toolbar=no,scrollbars=1,menubar=no,title=no,resizable=yes,width=" + windowWidth + ",height=" + windowHeight + ",left=" + left + ",top=" + top;
        //    var name = new Date().toTimeString();

        //    //if (childWindow) {
        //    //    childWindow.close();
        //    //    //childWindow.reload(true)
        //    //}

        //    var win = window.open(urlWithpara, name, feature);
        //    win.focus();

        //    childWindow = win;
        //};

        var payload = {
            method: 'POST',
            url: 'api/homeapi/5',
            headers: {
                'Content-Type': 'application/json, text/plain'
            }
            //},
            //data: { }
        };


        //$scope.GetLocalizedText = function () {
        //    InfotainmentService.getData('api/homeapi/5')
        //            .then(function (translateResult) {
        //                if (translateResult != null) {
        //                    var r = translateResult;
        //                }
        //            });
        //};
        //var result = $scope.GetLocalizedText();

        //Game section Tab control
        //$scope.tabListJSON = {
        //    cricket: "cricket-container",
        //    football: "football-container",
        //    hockey: "hockey-container",
        //    playStory: "story-container"
        //};
        //$scope.deactivateAlltab = function () {
        //    $('#cricket').removeClass("active-tab-header");
        //    $('#football').removeClass("active-tab-header");
        //    $('#hockey').removeClass("active-tab-header");
        //    $('#playStory').removeClass("active-tab-header");


        //    $('#cricket').addClass("de-active-tab-header");
        //    $('#football').addClass("de-active-tab-header");
        //    $('#hockey').addClass("de-active-tab-header");
        //    $('#playStory').addClass("de-active-tab-header");
        //};
        //$scope.hideAllContainer = function () {
        //    $('#cricket-container').css("display", "none");
        //    $('#football-container').css("display", "none");
        //    $('#hockey-container').css("display", "none");
        //    $('#story-container').css("display", "none");
        //};
        //$scope.onClickTab = function (tabNmae) {
        //    $scope.hideAllContainer();
        //    $scope.deactivateAlltab();
        //    $scope.ActiveTab(tabNmae)

        //    var container = $scope.tabListJSON[tabNmae];
        //    $('#' + container).css("display", "block");
        //};

        //$scope.ActiveTab = function (tabNmae) {
        //    $('#' + tabNmae).removeClass("de-active-tab-header");
        //    $('#' + tabNmae).addClass("active-tab-header");
        //}
        ////End of play section




        //End of play section
    };
})();




