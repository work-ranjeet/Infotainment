angular.module('infotainment').factory('urlProvider', function ($http, $q, $injector) {

    var url = {
        TopTenNews: "request/MainNewsApi/TopNews",
        TopTenNewsDesc: "request/MainNewsApi/TopNewsHeader",
        TopTenNewsDetail: "request/MainNewsApi/NewsDetail",
        TopTenNewsAdvertise: "request/AdvertismentApi/TopNewsAdvertisment"
        
    };

    return url;
});
NewsDetail