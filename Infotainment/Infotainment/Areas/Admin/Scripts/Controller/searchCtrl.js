(function () {
    'use strict';
    angular.module('infotainment').controller('searchCtrl', searchCtrl);

    function searchCtrl($scope, $state, $cookieStore, Helper) {

        $scope.activeValue =0;
        $scope.activeChange = function () {
            var checkbox = angular.element($('#IsActive'));
            if ($(checkbox).is(':checked')) {
                $('#IsActiveHidden').val(1);
            }
            else {
                $('#IsActiveHidden').val(0);
            }
        };

        $scope.approvedValue = 0;
        $scope.approvedChange = function () {
            var checkbox = angular.element($('#IsActive'));
            if ($(checkbox).is(':checked')) {
                $('#IsApprovedHidden').val(1);
            }
            else {
                $('#IsApprovedHidden').val(0);
            }
        };
    }
})();