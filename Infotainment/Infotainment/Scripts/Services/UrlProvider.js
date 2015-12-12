angular.module('infotainment').factory('urlProvider', function ($http, $q, $injector, $location) {
    
    var url = {
        TopNewsList: "request/MainNewsApi/NewsList?NextPage=",
        TopTenNews: "request/MainNewsApi/TopNews",
        TopTenNewsHeading: "request/MainNewsApi/TopNewsHeader",
        TopTenNewsDetail: "request/MainNewsApi/NewsDetail",
        TopTenNewsAdvertise: "request/AdvertismentApi/TopNewsAdvertisment",

        // International News
        InternationalNews: "request/InternationalNewsApi/FirstNews",
        //InternationalFirstNews: "request/InternationalNewsApi/NewsHeader",




        //RssTopTenNews: "request/MainNewsApi/RssTopNews"
        
    };

    return url;
});