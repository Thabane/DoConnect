app.controller("MasterController", ["$scope", "PatientsService", "$interval", "$rootScope", "MessagesService",
function ($scope, PatientsService, $interval, $rootScope, MessagesService) {
    $rootScope.loggedOnUserID = document.cookie;
    //Select GetPatientByID Function
    $scope.GetPatientByID = function () {
        PatientsService.GetPatientByID($rootScope.loggedOnUserID).success(function (result) {
            //$scope.ID = result["ID"];
            //console.log(result.data['FirstName']);
            console.log(result);
            $scope.FirstName = result["FirstName"];
            $scope.LastName = result["LastName"];
            $scope.Email = result["Email"];
            $scope.Gender = (result["Gender"] == "M" ? "Male" : "Female");
            $scope.DOB = result["DOB"];
            $scope.Cell_Number = result["Cell_Number"];
            $scope.Street_Address = result["Street_Address"];
            $scope.Suburb = result["Suburb"];
            $scope.Suburb = result["City"];
            $scope.Suburb = result["Country"];
            $scope.User_Id = result["User_Id"];
            $scope.Practice_ID = result["Practice_ID"];

        });
    };

    $scope.logout = function () {
        window.location.href = "PatientLogin/Index";
    }

    //Validation
    $scope.pattern_Email = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
    $scope.pattern_Number = /^[0-9]{1,6}$/;
    $scope.pattern_String = /^[a-zA-Z ]{1,25}$/;

    $scope.GetPatientByID();
    $scope.MessageNotification = function () {
        MessagesService.NumOfUnReadMessages($scope.loggedOnUserID).then(function (result) {
            $scope.NumOfUnReadMessages = result.data["NumOfUnReadMessages"];
        });
    };

    $interval($scope.MessageNotification, 3000);
}]);