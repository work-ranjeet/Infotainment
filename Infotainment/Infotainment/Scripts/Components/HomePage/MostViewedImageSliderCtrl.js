
(function () {
    angular.module('infotainment').controller('MostViewedImageSliderCtrl', ImageGalarySliderCtrl);

    function ImageGalarySliderCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, $interval) {

        $scope.slides = [
            { image: 'Images/Gallery/img00.jpg', description: 'Image 01  दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है।' },
            { image: 'Images/Gallery/img01.jpg', description: 'Image 01  दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है।' },
            { image: 'Images/Gallery/img02.jpg', description: 'Image 02 दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है।' },
            { image: 'Images/Gallery/img03.jpg', description: 'Image 03 दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है।' },
            { image: 'Images/Gallery/img04.jpg', description: 'Image 04 दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है।' }
        ];

        $scope.direction = 'left';
        $scope.currentIndex = 0;

        $scope.setCurrentSlideIndex = function (index) {
            $scope.direction = (index > $scope.currentIndex) ? 'left' : 'right';
            $scope.currentIndex = index;
        };

        $scope.isCurrentSlideIndex = function (index) {
            return $scope.currentIndex === index;
        };

        $scope.prevSlide = function () {
            $scope.direction = 'left';
            $scope.currentIndex = ($scope.currentIndex < $scope.slides.length - 1) ? ++$scope.currentIndex : 0;
        };

        $scope.nextSlide = function () {
            $scope.direction = 'right';
            $scope.currentIndex = ($scope.currentIndex > 0) ? --$scope.currentIndex : $scope.slides.length - 1;
        };

        var next = $interval(function () {
            $scope.nextSlide();
        }, 5000);

        $scope.setImageDescription = function () {
            return $scope.slides[$scope.currentIndex].description;
        }
    };
})();
//.animation('.slide-animation', function () {
//    return {
//        beforeAddClass: function (element, className, done) {
//            var scope = element.scope();

//            if (className == 'ng-hide') {
//                var finishPoint = element.parent().width();
//                if (scope.direction !== 'right') {
//                    finishPoint = -finishPoint;
//                }
//                TweenMax.to(element, 0.5, { left: finishPoint, onComplete: done });
//            }
//            else {
//                done();
//            }
//        },
//        removeClass: function (element, className, done) {
//            var scope = element.scope();

//            if (className == 'ng-hide') {
//                element.removeClass('ng-hide');

//                var startPoint = element.parent().width();
//                if (scope.direction === 'right') {
//                    startPoint = -startPoint;
//                }

//                TweenMax.fromTo(element, 0.5, { left: startPoint }, { left: 0, onComplete: done });
//            }
//            else {
//                done();
//            }
//        }
//    };
//});

