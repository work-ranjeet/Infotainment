(function () {
    angular
		.module('infotainment')
		.controller('stateNewsHomeCtrl', stateNewsHomeCtrl);

    function stateNewsHomeCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile) {
        $scope.Title = "खबर राज्यों से";
        $scope.StateTabList = [
            { TabIdName: "bihar", IsActive: true, StateName: "बिहार", TabContainerName: "bihar-container" },
            { TabIdName: "up", IsActive: false, StateName: "उत्तर प्रदेश", TabContainerName: "up-container" },
            { TabIdName: "chhattisgarh", IsActive: false, StateName: "छत्तीसगढ़", TabContainerName: "chhattisgarh-container" },
            { TabIdName: "mp", IsActive: false, StateName: "मध्य प्रदेश", TabContainerName: "mp-container" },
            { TabIdName: "rajasthan", IsActive: false, StateName: "राजस्थान", TabContainerName: "rajasthan-container" },
            { TabIdName: "himachal", IsActive: false, StateName: "हिमाचल प्रदेश", TabContainerName: "himachal-container" },
            { TabIdName: "panjab", IsActive: false, StateName: "पंजाब", TabContainerName: "panjab-container" }];

        //$scope.StateNames = {
        //    bihar: "बिहार",
        //    up: "उत्तर प्रदेश",
        //    chhattisgarh: "छत्तीसगढ़",
        //    mp: "मध्य प्रदेश",
        //    rajasthan: "राजस्थान",
        //    himachal: "हिमाचल प्रदेश",
        //    panjab: "पंजाब"
        //};


        $scope.changeStateNewsTab = function (tabNmae) {
            angular.forEach($scope.StateTabList, function (name) {
                $('#' + name.TabIdName).removeClass("active-state-news-header");
                $('#' + name.TabIdName).addClass("de-active-state-news-header");
                $('#' + name.TabContainerName).css("display", "none");
            });

            $('#' + tabNmae.state.TabIdName).removeClass("de-active-state-news-header");
            $('#' + tabNmae.state.TabIdName).addClass("active-state-news-header");

           // $scope.ActiveStateNewsTab(tabNmae);
            $('#' + tabNmae.state.TabContainerName).css("display", "block");
        };




        $scope.StateNewsContainerList = [
            {
                PageUrl: "#",
                TabContainerId: "bihar-container",
                IsActiveContainer:true,
                NewsId: "#",
                ImageUrl: "Images/GameSection/cricket/mainmng.jpg",
                ImageCaption: "आईसीसी ट्वेंटी-20 विश्वकप",
                StateName: "बिहार",
                ShortDesc: "दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है लेकिन टीम के खिलाड़ियों को परिस्थतियों के अनुकूल खुद को ढालने की जरूरत है। ",
                simpleNewsList: [
                    { ID: "#", Order: 1, Heading: "चोटिल शिखर धवन श्रीलंका दौरे से बाहर" },
                    { ID: "#", Order: 2, Heading: "30 साल बाद अपने पिता का इतिहास दोहरायेंगे स्टुअर्ट बिन्नी" },
                    { ID: "#", Order: 3, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" },
                    { ID: "#", Order: 4, Heading: "शीर्ष क्रम की कमजोर कड़ी साबित हो रहे हैं रोहित शर्मा" },
                    { ID: "#", Order: 5, Heading: "जीत के बाद खिलाड़ियों ने संगकारा को कंधों पर उठाया" },
                    { ID: "#", Order: 6, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" }
                ]
            },
            {
                PageUrl: "#",
                TabContainerId: "up-container",
                IsActiveContainer: false,
                NewsId: "#",
                ImageUrl: "Images/GameSection/cricket/mainmng.jpg",
                ImageCaption: "आईसीसी ट्वेंटी-20 विश्वकप",
                StateName: "उत्तर प्रदेश",
                ShortDesc: "दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है लेकिन टीम के खिलाड़ियों को परिस्थतियों के अनुकूल खुद को ढालने की जरूरत है। ",
                simpleNewsList: [
                    { ID: "#", Order: 1, Heading: "चोटिल शिखर धवन श्रीलंका दौरे से बाहर" },
                    { ID: "#", Order: 2, Heading: "30 साल बाद अपने पिता का इतिहास दोहरायेंगे स्टुअर्ट बिन्नी" },
                    { ID: "#", Order: 3, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" },
                    { ID: "#", Order: 4, Heading: "शीर्ष क्रम की कमजोर कड़ी साबित हो रहे हैं रोहित शर्मा" },
                    { ID: "#", Order: 5, Heading: "जीत के बाद खिलाड़ियों ने संगकारा को कंधों पर उठाया" },
                    { ID: "#", Order: 6, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" }
                ]
            },
            {
                PageUrl: "#",
                TabContainerId: "chhattisgarh-container",
                IsActiveContainer: false,
                NewsId: "#",
                ImageUrl: "Images/GameSection/cricket/mainmng.jpg",
                ImageCaption: "आईसीसी ट्वेंटी-20 विश्वकप",
                StateName: "छत्तीसगढ़",
                ShortDesc: "दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है लेकिन टीम के खिलाड़ियों को परिस्थतियों के अनुकूल खुद को ढालने की जरूरत है। ",
                simpleNewsList: [
                    { ID: "#", Order: 1, Heading: "चोटिल शिखर धवन श्रीलंका दौरे से बाहर" },
                    { ID: "#", Order: 2, Heading: "30 साल बाद अपने पिता का इतिहास दोहरायेंगे स्टुअर्ट बिन्नी" },
                    { ID: "#", Order: 3, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" },
                    { ID: "#", Order: 4, Heading: "शीर्ष क्रम की कमजोर कड़ी साबित हो रहे हैं रोहित शर्मा" },
                    { ID: "#", Order: 5, Heading: "जीत के बाद खिलाड़ियों ने संगकारा को कंधों पर उठाया" },
                    { ID: "#", Order: 6, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" }
                ]
            },
            {
                PageUrl: "#",
                TabContainerId: "mp-container",
                IsActiveContainer: false,
                NewsId: "#",
                ImageUrl: "Images/GameSection/cricket/mainmng.jpg",
                ImageCaption: "आईसीसी ट्वेंटी-20 विश्वकप",
                StateName: "",
                ShortDesc: "दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है लेकिन टीम के खिलाड़ियों को परिस्थतियों के अनुकूल खुद को ढालने की जरूरत है। ",
                simpleNewsList: [
                    { ID: "#", Order: 1, Heading: "चोटिल शिखर धवन श्रीलंका दौरे से बाहर" },
                    { ID: "#", Order: 2, Heading: "30 साल बाद अपने पिता का इतिहास दोहरायेंगे स्टुअर्ट बिन्नी" },
                    { ID: "#", Order: 3, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" },
                    { ID: "#", Order: 4, Heading: "शीर्ष क्रम की कमजोर कड़ी साबित हो रहे हैं रोहित शर्मा" },
                    { ID: "#", Order: 5, Heading: "जीत के बाद खिलाड़ियों ने संगकारा को कंधों पर उठाया" },
                    { ID: "#", Order: 6, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" }
                ]
            },
            {
                PageUrl: "#",
                TabContainerId: "rajasthan-container",
                IsActiveContainer: false,
                NewsId: "#",
                ImageUrl: "Images/GameSection/cricket/mainmng.jpg",
                ImageCaption: "आईसीसी ट्वेंटी-20 विश्वकप",
                SatateName: "",
                ShortDesc: "दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है लेकिन टीम के खिलाड़ियों को परिस्थतियों के अनुकूल खुद को ढालने की जरूरत है। ",
                simpleNewsList: [
                    { ID: "#", Order: 1, Heading: "चोटिल शिखर धवन श्रीलंका दौरे से बाहर" },
                    { ID: "#", Order: 2, Heading: "30 साल बाद अपने पिता का इतिहास दोहरायेंगे स्टुअर्ट बिन्नी" },
                    { ID: "#", Order: 3, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" },
                    { ID: "#", Order: 4, Heading: "शीर्ष क्रम की कमजोर कड़ी साबित हो रहे हैं रोहित शर्मा" },
                    { ID: "#", Order: 5, Heading: "जीत के बाद खिलाड़ियों ने संगकारा को कंधों पर उठाया" },
                    { ID: "#", Order: 6, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" }
                ]
            },
            {
                PageUrl: "#",
                TabContainerId: "himachal-container",
                IsActiveContainer: false,
                NewsId: "#",
                ImageUrl: "Images/GameSection/cricket/mainmng.jpg",
                ImageCaption: "आईसीसी ट्वेंटी-20 विश्वकप",
                SatateName: "",
                ShortDesc: "दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है लेकिन टीम के खिलाड़ियों को परिस्थतियों के अनुकूल खुद को ढालने की जरूरत है। ",
                simpleNewsList: [
                    { ID: "#", Order: 1, Heading: "चोटिल शिखर धवन श्रीलंका दौरे से बाहर" },
                    { ID: "#", Order: 2, Heading: "30 साल बाद अपने पिता का इतिहास दोहरायेंगे स्टुअर्ट बिन्नी" },
                    { ID: "#", Order: 3, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" },
                    { ID: "#", Order: 4, Heading: "शीर्ष क्रम की कमजोर कड़ी साबित हो रहे हैं रोहित शर्मा" },
                    { ID: "#", Order: 5, Heading: "जीत के बाद खिलाड़ियों ने संगकारा को कंधों पर उठाया" },
                    { ID: "#", Order: 6, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" }
                ]
            },
            {
                PageUrl: "#",
                TabContainerId: "panjab-container",
                IsActiveContainer: false,
                NewsId: "#",
                ImageUrl: "Images/GameSection/cricket/mainmng.jpg",
                ImageCaption: "आईसीसी ट्वेंटी-20 विश्वकप",
                SatateName: "",
                ShortDesc: "दक्षिण अफ्रीका के कप्तान एबी डीविलियर्स का मानना है कि उनकी टीम आईसीसी ट्वेंटी-20 विश्वकप से पहले खुद को तैयार कर रही है लेकिन टीम के खिलाड़ियों को परिस्थतियों के अनुकूल खुद को ढालने की जरूरत है। ",
                simpleNewsList: [
                    { ID: "#", Order: 1, Heading: "चोटिल शिखर धवन श्रीलंका दौरे से बाहर" },
                    { ID: "#", Order: 2, Heading: "30 साल बाद अपने पिता का इतिहास दोहरायेंगे स्टुअर्ट बिन्नी" },
                    { ID: "#", Order: 3, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" },
                    { ID: "#", Order: 4, Heading: "शीर्ष क्रम की कमजोर कड़ी साबित हो रहे हैं रोहित शर्मा" },
                    { ID: "#", Order: 5, Heading: "जीत के बाद खिलाड़ियों ने संगकारा को कंधों पर उठाया" },
                    { ID: "#", Order: 6, Heading: "आईसीसी टेस्ट रैंकिंग: अश्विन टॉप टेन में, शिखर 15 स्थान उछले" }
                ]
            }
        ];
    }
})();