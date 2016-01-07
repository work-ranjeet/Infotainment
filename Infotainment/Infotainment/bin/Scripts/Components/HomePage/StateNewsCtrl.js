(function () {
    angular
		.module('infotainment')
		.controller('stateNewsHomeCtrl', stateNewsHomeCtrl);

    function stateNewsHomeCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $cookieStore, Helper, ServiceProvider, Session) {
        $scope.StateNewsType = NewsType.StateNews;
        $scope.StateTitle = "खबर राज्यों से";
        $scope.stateName = "";
        $scope.StateCode = "";
        $scope.StateNewsDictionary = []
        
        $scope.StateTabList = [];

        $scope.stateNewsData = {};

        $scope.activeTab = {
            TabId: 0, StateName: "बिहार", StateCode: "BR", NewsList: []
        };

        $scope.formatTab = function (result) {
            var tabIdDigit = 500;
            angular.forEach(result, function (stateCodes) {
                $scope.StateTabList.push({ TabId: tabIdDigit, IsActive: false, StateName: stateCodes.NameHindi, StateCode: stateCodes.Code });
                $scope.stateNewsData[tabIdDigit] = { StateCode: stateCodes.Code, StateName: stateCodes.NameHindi };

                tabIdDigit = tabIdDigit - 5;
            });

            $scope.activeTab.TabId = $scope.StateTabList[0].TabId;
            $scope.activeTab.NewsList = $scope.FormateStateNews($scope.activeTab.StateCode);
            //$scope.StateTabList[0].IsActive = true;
        };

        $scope.changetab = function (code) {
            var currentState = $scope.stateNewsData[code];
            if (currentState && currentState.StateCode && !Helper.IsNullOrEmptyOrUndefined(currentState.StateCode)) {
                $scope.activeTab.TabId = code;
                $scope.activeTab.StateCode = currentState.StateCode;
                $scope.activeTab.StateName = currentState.StateName;
                $scope.activeTab.NewsList = $scope.FormateStateNews(currentState.StateCode);
                $scope.stateName = currentState.StateName + " की समाचार";
                $scope.StateCode = currentState.StateCode;
                //Session.SetStateCode(currentState.StateCode);
                $cookieStore.put(CookieKey.StateCodeKey, currentState.StateCode);
            };

        };

        $scope.FormateStateNews = function (stateCode) {
            var result = [];
            var currentTabData = $scope.StateNewsDictionary[stateCode];
            if (!Helper.IsNullOrEmptyOrUndefined(currentTabData)) {

                var firstNewsCounter = 0;
                var firstNews = [];
                var restNews = [];
                angular.forEach(currentTabData, function (news) {
                    if (!Helper.IsNullOrEmptyOrUndefined(news.ImageUrl) && firstNewsCounter++ <= 2) {
                        firstNews.push(news);
                    }
                    else {
                        restNews.push(news);
                    }
                });

                result = { FirstNews: firstNews, OthersNews: restNews };
            };
            return result;
        };

        //btn-radio="{{state.TabId}}" 
        $scope.watch = function(tabId) {
            if (tabId && tabId == null)
                return;
            if ($scope.stateNewsData != null && $scope.stateNewsData.length > 0) {
                $scope.changetab(tabId);
            }
        };

        $scope.$watch('activeTab.TabId', function (tabId) {
            if (tabId && tabId == null)
                return;
            if ($scope.stateNewsData  && $scope.stateNewsData != null) {
                $scope.changetab(tabId);
            }
        });

        $scope.loadStateForHomePage = function () {
            $q.all([
                ServiceProvider.Services.getData(ServiceProvider.Url.StateNews, null), 
                ServiceProvider.Services.getData(ServiceProvider.Url.StateCode, null)])
                .then(function (result) {
                    if (result && result[0] && result[1] && result != null && result[0] != null && result[1] != null) {
                        $scope.StateNewsDictionary = result[0];

                        $scope.formatTab(result[1]);

                        //$scope.activeTab = { tabId: "BR", StateName: "बिहार", StateCode: "BR", NewsList: $scope.FormateStateNews("BR") };
                    }
                });
        };

        $scope.loadStateForHomePage();
    }
})();