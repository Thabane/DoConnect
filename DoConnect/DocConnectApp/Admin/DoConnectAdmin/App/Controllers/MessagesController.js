app.controller("MessagesController", ["$scope", "MessagesService", "$interval",
    function ($scope, MessagesService, $interval) {

        MessagesService.GetAllMessages().then
        (function (results) {
            $scope.messages = result.data;
        });
    }]);