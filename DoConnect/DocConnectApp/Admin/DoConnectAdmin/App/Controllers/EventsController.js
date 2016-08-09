app.controller("EventsController", ["$scope", "EventsService", "$interval",
    function ($scope, EventsService, $interval) {

        EventsService.GetAllEvents().then
        (function (results) {
            $scope.Events = result.data;
        });
    }]);