(function () {
    angular
		.module('infotainment')
		.controller('mainCtrl', mainCtrl);

    function mainCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);

        $scope.OpenWindow = function (url) {
            var win = window.open(url, "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=50, left=400, width=1100, height=900");
            win.focus();
        };

    };

})();




