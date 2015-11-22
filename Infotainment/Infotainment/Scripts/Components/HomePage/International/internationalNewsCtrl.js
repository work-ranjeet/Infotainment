(function () {
    angular
		.module('infotainment')
		.controller('internationalNewsCtrl', internationalNewsCtrl);

    function internationalNewsCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile) {
        $scope.Title = "अंतरराष्ट्रीय खबर";
        $scope.PageUrl = "#";
        $scope.Others = "अन्य खबर";

        $scope.imageNewsList = [
            {
                ID: "#",
                Order:1,
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg",
                Heading: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",

            },
            {
                ID: "#",
                Order: 2,
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg",
                Heading: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",

            },
            {
                ID: "#",
                Order: 3,
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg",
                Heading: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",

            }
        ];

        $scope.simpleNewsList = [
            { ID: "#", Heading: "चोटिल शिखर धवन श्रीलंका दौरे से बाहर", Order: 1 },
            { ID: "#", Heading: "30 साल बाद अपने पिता का इतिहास दोहरायेंगे स्टुअर्ट बिन्नी", Order: 2 },
            { ID: "#", Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले", Order: 3 },
            { ID: "#", Heading: "शीर्ष क्रम की कमजोर कड़ी साबित हो रहे हैं रोहित शर्मा", Order: 4 },
            { ID: "#", Heading: "जीत के बाद खिलाड़ियों ने संगकारा को कंधों पर उठाया", Order: 5 }
        ];
    };
})();
    