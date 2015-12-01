(function () {
    angular.module('infotainment').controller('aboutusCtrl', aboutusCtrl);

    function aboutusCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $interval, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);

        $scope.AboutUS = AboutUs;
        $scope.TeamList = [
                         {
                             PicUrl: "Images/User/Default.jpg",
                             Name: "Puja Gupta",
                             Desigantion: "Company Secretry",
                             Qulification:"ACS, LLB, MBA",
                             Work: "",
                             Detail: ""
                         },
                         {
                             PicUrl: "Images/User/Default.jpg",
                             Name: "Ravi Anand",
                             Desigantion: "",
                             Qulification: "",
                             Work: "Content Management",
                             Detail: ""
                         },
                         {
                             PicUrl: "Images/User/Default.jpg",
                             Name: "Munna Kumar Gupta",
                             Desigantion: "",
                             Qulification: "MCA",
                             Work: "Technical Support",
                             Detail: ""
                         }

        ];
    };
})();