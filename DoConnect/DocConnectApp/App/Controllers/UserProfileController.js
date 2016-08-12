app.controller("UserProfileController", ["$scope", "UserProfileService", "$interval",
    function ($scope, UserProfileService, $interval) {

        UserProfileService.GetAllUserProfile().then
        (function (results) {
            $scope.userProfile = result.data;
        });
    }]);