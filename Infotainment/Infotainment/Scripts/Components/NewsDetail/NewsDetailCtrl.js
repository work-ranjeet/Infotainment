(function () {
    angular
		.module('infotainment')
		.controller('newsDetailCtrl', newsDetailCtrl);

    function newsDetailCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, ServiceProvider) {
        ServiceProvider.Services.Host($location.$$protocol + "://" + $location.$$host + ":" + $location.$$port);

        $scope.imageNewsList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNews, null).then(function (result) {
            if (result != null) {
                $scope.imageNewsList = result;
            }
        });

         $scope.simpleNewsHeading = "बरी खबरें";
        $scope.simpleNewsList = [];
        ServiceProvider.Services.getData(ServiceProvider.Url.TopTenNewsDesc, null).then(function (result) {
            if (result != null) {
                $scope.simpleNewsList = result;
            }
        });
       
       
       // $scope.NewsList = [];


       // $scope.NewsDetail = "";
       // ServiceProvider.Services.getData(ServiceProvider.Url.NewsDetail, null).then(function (result) {
       //     if (result != null) {
       //         $scope.imageNewsList = result;
       //     }
       // });



       // $scope.NewsDetail =
       //{
       //    NewsID: 1,
       //    EditorID: 1,
       //    ImageUrl: "Images/MainNews/pm-narendra-modi_240x180_81439867577.jpg",
       //    Heading: "बाजार में काला सोमवार: पीएम मोदी ने की स्थिति की समीक्षा, सुधारों पर जोर",
       //    EditorName: "Press Trust of India",
       //    Date: "Monday August 24, 2015, New Delhi",
       //    ShortDesc: "नई दिल्ली: शेयर बाजार में सोमवार को आई भारी गिरावट से परेशान निवेशकों को शांत करने का प्रयास करते हुए प्रधानमंत्री नरेन्द्र मोदी ने अर्थव्यवस्था की मजबूती के लिए सुधारों को आगे बढ़ाने और सार्वजनिक खर्च में तेजी लाने पर जोर दिया।",
       //    Desc: "प्रधानमंत्री ने वित्त मंत्री अरुण जेटली एवं अन्य शीर्ष अधिकारियों के साथ शेयर बाजार और रुपये में आई भारी गिरावट की समीक्षा की। उन्होंने जोर देते हुए कहा कि घरेलू अर्थव्यवस्था स्थिर है और  जो भी समस्या है, वह बाहरी कारणों से है। प्रधानमंत्री की समीक्षा बैठक के बाद जेटली ने संवाददाताओं को बताया कि सरकार के साथ-साथ रिजर्व बैंक और सेबी आदि नियामकों की वैश्विक घटनाक्रमों के साथ-साथ बाजार पर पैनी नजर है। फिलहाल किसी तरह के राहत पैकेज की जरूरत नहीं है। जेटली ने कहा,‘प्रधानमंत्री की राय थी कि अपनी अर्थव्यवस्था को और मजबूत करने के लिए हमें और कदम उठाने चाहिए।’ इसके साथ ही वित्त मंत्री ने जोड़ा कि रणनीति में कोई बदलाव नहीं होगा और निवेशकों को आकर्षित करने की पहल जारी रहेगी। उन्होंने कहा कि निजी और सार्वजनिक क्षेत्र के भागीदारों के साथ और बातचीत की जाएगी, ताकि निवेशकों को आकर्षित करने के लिए और उपाय किए जा सकें।"
       //};


       // $scope.NewsList = [
       //  {
       //      NewsID: 1,
       //      EditorID: 1,
       //      OrderID: 1,
       //      ImageUrl: "Images/MainNews/pm-narendra-modi_240x180_81439867577.jpg",
       //      Heading: "बाजार में काला सोमवार: पीएम मोदी ने की स्थिति की समीक्षा, सुधारों पर जोर",
       //      EditorName: "Press Trust of India",
       //      Date: "Monday August 24, 2015, New Delhi",
       //      ShortDesc: "नई दिल्ली: शेयर बाजार में सोमवार को आई भारी गिरावट से परेशान निवेशकों को शांत करने का प्रयास करते हुए प्रधानमंत्री नरेन्द्र मोदी ने अर्थव्यवस्था की मजबूती के लिए सुधारों को आगे बढ़ाने और सार्वजनिक खर्च में तेजी लाने पर जोर दिया।"
       //  },
       //  {
       //      NewsID: 1,
       //      EditorID: 1,
       //      OrderID: 1,
       //      ImageUrl: "Images/MainNews/pm-narendra-modi_240x180_81439867577.jpg",
       //      Heading: "बाजार में काला सोमवार: पीएम मोदी ने की स्थिति की समीक्षा, सुधारों पर जोर",
       //      EditorName: "Press Trust of India",
       //      Date: "Monday August 24, 2015, New Delhi",
       //      ShortDesc: "नई दिल्ली: शेयर बाजार में सोमवार को आई भारी गिरावट से परेशान निवेशकों को शांत करने का प्रयास करते हुए प्रधानमंत्री नरेन्द्र मोदी ने अर्थव्यवस्था की मजबूती के लिए सुधारों को आगे बढ़ाने और सार्वजनिक खर्च में तेजी लाने पर जोर दिया।"
       //  },
       //  {
       //      NewsID: 1,
       //      EditorID: 1,
       //      OrderID: 1,
       //      ImageUrl: "Images/MainNews/pm-narendra-modi_240x180_81439867577.jpg",
       //      Heading: "बाजार में काला सोमवार: पीएम मोदी ने की स्थिति की समीक्षा, सुधारों पर जोर",
       //      EditorName: "Press Trust of India",
       //      Date: "Monday August 24, 2015, New Delhi",
       //      ShortDesc: "नई दिल्ली: शेयर बाजार में सोमवार को आई भारी गिरावट से परेशान निवेशकों को शांत करने का प्रयास करते हुए प्रधानमंत्री नरेन्द्र मोदी ने अर्थव्यवस्था की मजबूती के लिए सुधारों को आगे बढ़ाने और सार्वजनिक खर्च में तेजी लाने पर जोर दिया।"
       //  }
       // ];
    };
})();