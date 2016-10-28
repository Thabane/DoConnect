app.controller("FeedCtrl", ["$scope", "FeedService", "$interval", function ($scope, FeedService, $interval, Feed) {
    $scope.loadButonText = "Load";
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

