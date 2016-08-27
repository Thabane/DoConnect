app.controller("LoginController", ["$scope", "LoginService", "$interval",
    function ($scope, LoginService, $interval) {

        LoginService.GetAllLogin().then
        (function (results) {
            $scope.Login = result.data;
        });
    }]);