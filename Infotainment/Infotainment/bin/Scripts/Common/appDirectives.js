angular.module('infotainment').
    directive('capitalizeFirst', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, modelCtrl) {
                var capitalize = function (inputValue) {
                    var capitalized = inputValue.toUpperCase();
                    if (capitalized !== inputValue) {
                        modelCtrl.$setViewValue(capitalized);
                        modelCtrl.$render();
                    }
                    return capitalized;
                }
                modelCtrl.$parsers.push(capitalize);
                capitalize(scope[attrs.ngModel]);  // capitalize initial value
            }
        };
    });

angular.module('infotainment').directive('sliderMenu', ['$swipe',
function ($swipe) {
    return {
        restrict: 'EA',
        link: function (scope, ele, attrs, ctrl) {
            var startX, pointX;
            $swipe.bind(ele, {
                'start': function (coords) {
                    startX = coords.x;
                    pointX = coords.y;
                },
                'move': function (coords) {
                    var delta = coords.x - pointX;
                    // ...
                },
                'end': function (coords) {
                    // ...
                },
                'cancel': function (coords) {
                    // ...
                }
            });
        }
    }
}]);
