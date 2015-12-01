(function () {
    angular.module('infotainment').controller('contactusCtrl', contactusCtrl);

    function contactusCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $interval, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);

        $scope.ContactUS =
            {
                Name: "Ravi Anand",
                HouseName: "Surya niketan",
                HouseNo: "Plot no. 13",
                Address1: "Opposite anand vihar Gurudwara",
                Address2: "Near by Kadkaduma metro station",
                City: "New Delhi",
                State: "New Delhi",
                Country: "India",
                PinNo:"-",
                Email: "ravianand_pat@yahoo.com"
            };

    };
})();