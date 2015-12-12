(function () {
    angular.module('infotainment').controller('aboutusCtrl', aboutusCtrl);

    function aboutusCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $interval, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);

        $scope.AboutUS = AboutUs;
        $scope.TeamList = [
                         {
                             Gender : 1,
                             PicUrl: "Content/images/femail.png",
                             Name: "Puja Gupta",
                             Desigantion: "Company Secretry",
                             Qulification:"ACS, LLB, MBA",
                             Work: "",
                             Detail: ""
                         },
                         {
                             PicUrl: "Content/images/mail.png",
                             Name: "Ravi Anand",
                             Desigantion: "",
                             Qulification: "",
                             Work: "Content Management",
                             Detail: ""
                         },
                         {
                             PicUrl: "Content/images/mail.png",
                             Name: "Munna Kumar Gupta",
                             Desigantion: "",
                             Qulification: "MCA",
                             Work: "Technical Support",
                             Detail: ""
                         }

        ];
    };
})();