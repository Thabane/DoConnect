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
            LoginService.VerifyPatient($scope.LoginData.Username, $scope.LoginData.Password).success(function (result) {
                console.log(result);
                if (result > 0 || result.data > 0) {
                    document.cookie = result;   
                    window.location.href = "Home/Index";
                    $scope.LogStuff(result.data);
                    $scope.changeRs = function () {
                        $rootScope.loggedOnUser = result.data;
                        console.log(result.data);
                        console.log($rootScope.loggedOnUser);
                    };
                    $scope.changeRs();
                    $scope.IsLogedIn = true;
                    angular.element("#wrapper").show();
                    
                }
                else {
                    $scope.InvalidCredential = "Invalid Username or Password\nPlease enter a valid Username and Password";
                }
            });
        };
        $scope.LogStuff = function (log) {
            console.log(log);
        }
    }]);