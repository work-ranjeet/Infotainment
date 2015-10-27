(function () {
    angular
		.module('infotainment')
		.controller('allStateNewsCtrl', allStateNewsCtrl);

    function allStateNewsCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile) {
        $scope.stateList = [
            {
                Order: 1,
                StateID: 1,
                StateName: "बिहार",
                FirstNewsId: 1,
                FirstNewsImageUrl: "Images/Gallery/img03.jpg",
                FirstNewsShortDesc: "विकलांगों को सम्मानित करने के लिए मांग आवेदन विकलांगों को सम्मानित करने के लिए मांग आवेदन",
                SimpleNewsList: [
                    {
                        NewsId: 1,
                        Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                    },
                    {
                        NewsId: 1,
                        Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                    },
                    {
                        NewsId: 1,
                        Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                    },
                    {
                        NewsId: 1,
                        Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                    },
                    {
                        NewsId: 1,
                        Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                    }]
            },
        {
            Order: 1,
            StateID: 1,
            StateName: "बिहार",
            FirstNewsId: 1,
            FirstNewsImageUrl: "Images/Gallery/img03.jpg",
            FirstNewsShortDesc: "विकलांगों को सम्मानित करने के लिए मांग आवेदन विकलांगों को सम्मानित करने के लिए मांग आवेदन",
            SimpleNewsList: [
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                }]
        },
        {
            Order: 1,
            StateID: 1,
            StateName: "बिहार",
            FirstNewsId: 1,
            FirstNewsImageUrl: "Images/Gallery/img03.jpg",
            FirstNewsShortDesc: "विकलांगों को सम्मानित करने के लिए मांग आवेदन विकलांगों को सम्मानित करने के लिए मांग आवेदन",
            SimpleNewsList: [
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                }]
        },
        {
            Order: 1,
            StateID: 1,
            StateName: "बिहार",
            FirstNewsId: 1,
            FirstNewsImageUrl: "Images/Gallery/img03.jpg",
            FirstNewsShortDesc: "विकलांगों को सम्मानित करने के लिए मांग आवेदन विकलांगों को सम्मानित करने के लिए मांग आवेदन",
            SimpleNewsList: [
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                },
                {
                    NewsId: 1,
                    Header: "डेंगू की रोकथाम के लिए लिखा लेटर"
                }]
        }];
    };
})();