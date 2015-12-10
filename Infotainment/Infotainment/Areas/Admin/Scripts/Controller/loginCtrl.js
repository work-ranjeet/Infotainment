(function () {
    'use strict';
    angular.module('infotainment').controller('loginCtrl', loginCtrl);

    function loginCtrl($scope, $state, $cookieStore, Helper) {

        $scope.User = [];
        $scope.User.UserID = null;
        $scope.User.Password = null;
        $scope.User.IsEnteredUserID = true;
        $scope.User.IsEnteredPassword = true;
        $scope.User.Message = Constants.Empty;


        $scope.checkUserIDEntry = function () {
            if (!Helper.IsNullOrEmptyOrUndefined($scope.User.UserID) && (RegEmail.test($scope.User.UserID) || RegMob.test($scope.User.UserID))) {
                $scope.User.IsEnteredUserID = true;
            }
            else {
                $scope.User.IsEnteredUserID = false;
            }

            $scope.User.Message = Constants.Empty;
        };

        $scope.checkPasswordEntry = function () {
            if (!Helper.IsNullOrEmptyOrUndefined($scope.User.Password)) {
                $scope.User.IsEnteredPassword = true;
            }
            else {
                $scope.User.IsEnteredPassword = false;
            }

            $scope.User.Message = Constants.Empty;
        };
        $scope.login = function () {
            $scope.User.Message = Constants.Empty;
            if ($scope.User.IsEnteredPassword && $scope.User.IsEnteredUserID) {
                return true;
            }

            $scope.User.Message = Message.EnterCrendential;
            
            return false;
        };


        $scope.ForgotPassword = function () {
            alert("NASDAQ");
        };

        //$scope.onLoadAuthentication = function () {
        //    var user = $cookieStore.get('KeepMeSafe_User');
        //    if (user.UserID != undefined && user.UserID != null && user.Password != undefined && user.Password != null) {
        //        // redirect to home page 
        //        $location.path("HomePage");
        //    }
        //};

    }
})();