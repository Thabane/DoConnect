app.controller("LoginController", ["$scope", "LoginService", "$interval",
    function ($scope, LoginService, $interval) {
        
        $scope.IsLogedIn = false;
        angular.element("#wrapper").hide();
        $scope.InvalidCredential = "null";
        $scope.HereIAm = "HereIAm";
        $scope.LoginData = {
            Username: '',
            Password: ''
        };
 
    
        $scope.Login = function () { 
                LoginService.GetUser($scope.LoginData).then(function (d) {
                    if (d.data.Email != null) {
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