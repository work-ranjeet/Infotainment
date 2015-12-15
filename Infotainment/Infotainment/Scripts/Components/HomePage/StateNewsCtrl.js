(function () {
    angular
		.module('infotainment')
		.controller('stateNewsHomeCtrl', stateNewsHomeCtrl);

    function stateNewsHomeCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $modal, $compile, Helper) {
        $scope.StateTitle = "खबर राज्यों से";
        $scope.StateTabList = [
            { TabId: "99", IsActive: true,  StateName: "बिहार", StateCode: "BH" },
            { TabId: "95", IsActive: false, StateName: "उत्तर प्रदेश", StateCode: "UP" },
            { TabId: "90", IsActive: false, StateName: "छत्तीसगढ़", StateCode: "CH" },
            { TabId: "85", IsActive: false, StateName: "मध्य प्रदेश", StateCode: "MP" },
            { TabId: "80", IsActive: false, StateName: "राजस्थान", StateCode: "RJ" },
            { TabId: "75", IsActive: false, StateName: "हिमाचल प्रदेश", StateCode: "HM" },
            { TabId: "70", IsActive: false, StateName: "पंजाब", StateCode: "PN" }
        ];

        $scope.stateNewsData = {
            "99": { StateCode: "BH", NewsData: [], StateName: "बिहार" } ,
            "95": { StateCode: "UP", NewsData: [], StateName: "उत्तर प्रदेश" } ,
            "90": { StateCode: "CH", NewsData: [], StateName: "छत्तीसगढ़" } ,
            "85": { StateCode: "MP", NewsData: [], StateName: "मध्य प्रदेश" } ,
            "80": { StateCode: "RJ", NewsData: [], StateName: "राजस्थान" } ,
            "75": { StateCode: "MH", NewsData: [], StateName: "हिमाचल प्रदेश" } ,
            "70": { StateCode: "PN", NewsData: [], StateName: "पंजाब" } 

        };

        $scope.activeTab = {
            tabId: "99", StateName: "बिहार", StateCode: "BH", NewsList: []
        };



        $scope.changetab = function (tabId) {
            var currentState = $scope.stateNewsData[tabId];
            if (!Helper.IsNullOrEmptyOrUndefined(currentState.StateCode)) {
                $scope.activeTab.tabId = tabId;
                $scope.activeTab.StateCode = currentState.StateCode;
                $scope.activeTab.StateName = currentState.StateName;
                $scope.activeTab.NewsList = currentState.NewsData;
            };

        };

        $scope.$watch('activeTab.tabId', function (tabId) {
            if (tabId == null)
                return;

            $scope.changetab(tabId);
        });

       

        $scope.stateNewsData[99].NewsData = [
            {
                StateCode: "BH",
                PageUrl: "#",
                TabContainerId: "bihar-container",
                IsActiveContainer: true,
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
                StateCode: "UP",
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
                StateCode: "CH",
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
                StateCode: "MP",
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
                StateCode: "RJ",
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
                StateCode: "MH",
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
                StateCode: "PN",
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