app.controller("LoginController", ["$scope", "LoginService", "$interval", "$rootScope",
    function ($scope, LoginService, $interval, $rootScope) {

        $scope.IsLogedIn = false;
        angular.element("#wrapper").hide();
        $scope.InvalidCredential = "null";
        $scope.HereIAm = "HereIAm";
        $scope.LoginData = {
            Username: '',
            Password: ''
        };

        $scope.Login = function () {
            LoginService.VerifyPatient($scope.LoginData.Username, $scope.LoginData.Password).then(function (result) {
                if (result.data > 0) {
                    console.log(result.data);
                    $scope.changeRs = function () {
                        $rootScope.loggedOnUser = result.data;
                        console.log(result.data);
                        console.log($rootScope.loggedOnUser);
                    };
                    $scope.changeRs();
                    $scope.IsLogedIn = true;
                    angular.element("#wrapper").show();
                    window.location.href = "Home/Index";
                }
                else {
                    $scope.InvalidCredential = "Invalid Username or Password\nPlease enter a valid Username and Password";
                }
            });
        };
    }]);