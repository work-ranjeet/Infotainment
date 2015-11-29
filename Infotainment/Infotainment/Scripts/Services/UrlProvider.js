angular.module('infotainment').factory('urlProvider', function ($http, $q, $injector) {

    var url = {
        TopNewsList: "request/MainNewsApi/NewsList",
        TopTenNews: "request/MainNewsApi/TopNews",
        TopTenNewsDesc: "request/MainNewsApi/TopNewsHeader",
        TopTenNewsDetail: "request/MainNewsApi/NewsDetail",
        TopTenNewsAdvertise: "request/AdvertismentApi/TopNewsAdvertisment",
        InternationalNews: "request/InternationalNewsApi/FirstNews"
        
    };

    return url;
});
NewsDetail