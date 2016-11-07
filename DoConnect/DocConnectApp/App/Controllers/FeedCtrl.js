app.controller("FeedCtrl", ["$scope", "FeedService", "$interval", function ($scope, FeedService, $interval, Feed) {
    $scope.loadButonText = "Load";
     
    $scope.Load = function () {
        FeedService.parseFeed("https://medlineplus.gov/feeds/news_en.xml").then(function (res) {
            $scope.loadButonText = "MedlinePlus Health News";
            $scope.feeds = res.data.responseData.feed.entries;
        });
    }

    $scope.loadFeed = function (e) {
        FeedService.parseFeed($scope.feedSrc).then(function (res) {
            $scope.loadButonText = angular.element(e.target).text();
            $scope.feeds = res.data.responseData.feed.entries;
        });
    }
}]);



app.factory('FeedService', ['$http', function ($http) {

    var parseFeed = function (url) {
        return $http.jsonp('//ajax.googleapis.com/ajax/services/feed/load?v=1.0&num=50&callback=JSON_CALLBACK&q=' + encodeURIComponent(url));
    };

    return { parseFeed: parseFeed }
}]);

