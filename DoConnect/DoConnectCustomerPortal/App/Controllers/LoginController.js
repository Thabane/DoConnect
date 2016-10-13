app.controller("LoginController", ["$scope", "LoginService", "$interval", "$location",
    function ($scope, LoginService, $interval, $location) {

        $scope.Email;
        $scope.Login = function (Username, Password) {
            LoginService.VerifyUser(Username).success(function (result) {
                $scope.Email = result["Email"];
                $scope.UserPassword = result["Password"];

                if ((Username == result["Email"]) && (Password == result["Password"])) {
                    $location.path('/Patients');
                }
                
            });
        };
    }]);