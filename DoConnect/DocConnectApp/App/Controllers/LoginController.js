app.controller("LoginController", ["$scope", "LoginService", "$interval",
    function ($scope, LoginService, $interval) {
        $scope.IsLogedIn = false;
        $scope.Message = '';
        $scope.Submitted = false;
        $scope.IsFormValid = false;
        angular.element("#wrapper").hide();
        $scope.InvalidCredential = "null";

        $scope.LoginData = {
            Username: '',
            Password: ''
        };
 
        //Check is Form Valid or Not // Here f1 is our form Name
        $scope.$watch('f1.$valid', function (newVal) {
            $scope.IsFormValid = newVal;
        });
    
        $scope.Login = function () {        
            $scope.Submitted = true;
            if ($scope.IsFormValid) {
                LoginService.GetUser($scope.LoginData).then(function (d) {
                    if (d.data.Email != null) {
                        $scope.IsLogedIn = true;
                        angular.element("#wrapper").show();

                        $scope.GetUserDetails(d.data.ID);

                        window.location.href = "/#/Dashboard";
                    }
                    else {
                        $scope.InvalidCredential = "Username or Password is invalid";
                    }
                });
            }
        };

        $scope.GetUserDetails = function (User_ID) {
            LoginService.GetUserDetailsByUser_ID(User_ID).success(function (result) {
                alert(User_ID);
                sessionStorage.Staff_ID = result["ID"];
                sessionStorage.User_ID = result["User_ID"];                
                sessionStorage.FirstName = result["FirstName"];
                sessionStorage.LastName = result["LastName"];
                sessionStorage.Email = result["Email"]; 
                sessionStorage.Practice_ID = result["PRACTICE_ID"];
            });
        };
}]);