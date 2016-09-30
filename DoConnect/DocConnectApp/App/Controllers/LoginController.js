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
            alert("$scope.Login has been clicked");
                LoginService.GetUser($scope.LoginData).then(function (d) {
                    alert("d.data.Email = " + d.data.Email);
                    alert("d.[Email]= " + d.data["Email"]);
                    if (d.data.Email != null) {
                        $scope.IsLogedIn = true;
                        angular.element("#wrapper").show();

                        $scope.GetUserDetails(d.data.ID);
                        window.location.href = "Home/Index";
                    }
                    else {
                        $scope.InvalidCredential = "Invalid Username or Password\nPlease enter a valid Username and Password";
                    }
                });
        };

        $scope.GetUserDetails = function (User_ID) {
            LoginService.GetUserDetailsByUser_ID(User_ID).success(function (result) {
                sessionStorage.ID = result["ID"];
                sessionStorage.User_ID = result["User_ID"];
                sessionStorage.FirstName = result["FirstName"];
                sessionStorage.LastName = result["LastName"];
                sessionStorage.Email = result["Email"];
                alert("Logged in user: " + sessionStorage.Email);
            });
        };
}]);