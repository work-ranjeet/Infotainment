(function () {
    angular
		.module('infotainment')
		.controller('stateNewsListCtrl', stateNewsListCtrl);

    function stateNewsListCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile) {

        $scope.stateNewsList = [
        {
            NewsID: 1,
            EditorID: 1,
            OrderID: 1,
            ImageUrl: "Images/MainNews/pm-narendra-modi_240x180_81439867577.jpg",
            Heading: "बाजार में काला सोमवार: पीएम मोदी ने की स्थिति की समीक्षा, सुधारों पर जोर",
            EditorName: "Press Trust of India",
            Date: "Monday August 24, 2015, New Delhi",
            ShortDesc: "नई दिल्ली: शेयर बाजार में सोमवार को आई भारी गिरावट से परेशान निवेशकों को शांत करने का प्रयास करते हुए प्रधानमंत्री नरेन्द्र मोदी ने अर्थव्यवस्था की मजबूती के लिए सुधारों को आगे बढ़ाने और सार्वजनिक खर्च में तेजी लाने पर जोर दिया।"
        },
        {
            NewsID: 1,
            EditorID: 1,
            OrderID: 1,
            ImageUrl: "Images/MainNews/pm-narendra-modi_240x180_81439867577.jpg",
            Heading: "बाजार में काला सोमवार: पीएम मोदी ने की स्थिति की समीक्षा, सुधारों पर जोर",
            EditorName: "Press Trust of India",
            Date: "Monday August 24, 2015, New Delhi",
            ShortDesc: "नई दिल्ली: शेयर बाजार में सोमवार को आई भारी गिरावट से परेशान निवेशकों को शांत करने का प्रयास करते हुए प्रधानमंत्री नरेन्द्र मोदी ने अर्थव्यवस्था की मजबूती के लिए सुधारों को आगे बढ़ाने और सार्वजनिक खर्च में तेजी लाने पर जोर दिया।"
        },
        {
            NewsID: 1,
            EditorID: 1,
            OrderID: 1,
            ImageUrl: "Images/MainNews/pm-narendra-modi_240x180_81439867577.jpg",
            Heading: "बाजार में काला सोमवार: पीएम मोदी ने की स्थिति की समीक्षा, सुधारों पर जोर",
            EditorName: "Press Trust of India",
            Date: "Monday August 24, 2015, New Delhi",
            ShortDesc: "नई दिल्ली: शेयर बाजार में सोमवार को आई भारी गिरावट से परेशान निवेशकों को शांत करने का प्रयास करते हुए प्रधानमंत्री नरेन्द्र मोदी ने अर्थव्यवस्था की मजबूती के लिए सुधारों को आगे बढ़ाने और सार्वजनिक खर्च में तेजी लाने पर जोर दिया।"
        }];
    };
})();