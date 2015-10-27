(function () {
    angular.module('infotainment').controller('TopTenNewsCtrl', ImageGalarySliderCtrl);

    function ImageGalarySliderCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $interval) {

        $scope.newsListPageUrl = "1";
        $scope.imageNewsList = [
            {
                NewsID: "1",
                Order: 1,
                Heading: "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई, भाषण सुन आंखें हुईं नम",
                ShortDescription: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg"
            },
            {
                NewsID: "1",
                Order: 2,
                Heading: "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई, भाषण सुन आंखें हुईं नम",
                ShortDescription: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg"
            },
            {
                NewsID: "1",
                Order: 3,
                Heading: "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई, भाषण सुन आंखें हुईं नम",
                ShortDescription: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg"
            },
            {
                NewsID: "1",
                Order: 5,
                Heading: "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई, भाषण सुन आंखें हुईं नम",
                ShortDescription: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg"
            },
            {
                NewsID: "1",
                Order: 6,
                Heading: "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई, भाषण सुन आंखें हुईं नम",
                ShortDescription: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg"
            },
            {
                NewsID: "1",
                Order: 7,
                Heading: "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई, भाषण सुन आंखें हुईं नम",
                ShortDescription: "लोकसभा में बुधवार को ललितगेट पर चर्चा के दौरान बीजेपी सांसद की टिप्पणी पर सोनिया गांधी ने कड़ा एतराज जताया।",
                ImageUrl: "Images/Top-ten/advani-sushma_1439374915.jpg"
            }
        ];

        $scope.videoHeading = "लाेकसभा : आडवाणी ने सुषमा की पीठ थपथपाई";
        $scope.videoUrl = $sce.trustAsResourceUrl("http://www.youtube.com/embed/OulN7vTDq1I");

        $scope.simpleNewsHeading = "बरी खबरें";
        $scope.simpleNewsPageUrl = "2";
        $scope.simpleNewsList = [
            {
                NewsID: "1",
                Order: 1,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 2,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 3,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 4,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 5,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 6,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 7,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 8,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 9,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            },
            {
                NewsID: "1",
                Order: 10,
                Heading: "राधे मां के रिश्‍तेदार ने लगाया भाभी के मर्डर में शामिल होने का आरोप"
            }
        ];

    };
})();