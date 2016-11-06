app.controller("PracticesController", ["$scope", "PracticesService", "$interval", "$ngBootbox", "$location",
    function ($scope, PracticesService, $interval, $ngBootbox, $location) {

        $scope.PageTitle_Practices = 'Practices';
        $scope.PageTitle_NewPractice = 'New Practices Details';

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        };

        $scope.GetAllPractices = function () {
            PracticesService.GetAllPractices().then(function (result) {
                $scope.Practices = result.data;
            });

            PracticesService.SessionData().success(function (result) {
                sessionStorage.SessionData_User_ID = result["User_ID"];
                sessionStorage.SessionData_FirstName = result["FirstName"];
                sessionStorage.SessionData_LastName = result["LastName"];
                sessionStorage.SessionData_Email = result["Email"];
                sessionStorage.SessionData_Practice_ID = result["Practice_ID"];
                sessionStorage.SessionData_AccessLevel = result["AccessLevel"];                
            });
        };
        $scope.GetAllPractices();

        if (sessionStorage.SessionData_AccessLevel == '1') {
            angular.element(".doctorControls").show();
        }
        else {
            angular.element(".doctorControls").hide();
        }

        $scope.ViewPractice = function (ID) {
            PracticesService.GetPracticeByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.Name = result["Name"];
                $scope.Phone_Number = result["Phone_Number"];
                $scope.Fax_Number = result["Fax_Number"];
                $scope.Street_Address = result["Street_Address"];
                $scope.Suburb = result["Suburb"];
                $scope.City = result["City"];
                $scope.Country = result["Country"];
                $scope.Trading_Times = result["Trading_Times"];
            });
        };

        $scope.NewPractice = function (Name, Phone_Number, Fax_Number, Street_Address, Suburb, City, Country, Trading_Times) {
            PracticesService.InsertPractice(Name, Phone_Number, Fax_Number, Street_Address, Suburb, City, Country, Trading_Times).success(function () {
                $scope.GetAllPractices();
                angular.element(".insert").val('');
                btnSuccess("Practice successfully inserted.");
                $location.path('/Practices');
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };

        $scope.function_btnUpdatePractice = function (ID) {
            var btnText = angular.element("#function_btnUpdatePractice").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewPractice").attr("readonly", false);
                angular.element("#function_btnUpdatePractice").html("Save");
            }
            else {
                PracticesService.UpdatePractice($scope.ID, $scope.Name, $scope.Phone_Number, $scope.Fax_Number, $scope.Street_Address, $scope.Suburb, $scope.City, $scope.Country, $scope.Trading_Times).success(function () {
                    $scope.GetAllPractices();
                    angular.element(".close").trigger("click");
                    btnSuccess("Practice details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });

                angular.element(".readonly_ViewPractice").attr("readonly", true);
                angular.element(".readonly_ViewPractice").css("background-color", "transparent");
                angular.element("#function_btnUpdatePractice").html("Update");
            }
        };

        $scope.DeletePractice1 = function (ID, Name) {
            $ngBootbox.confirm("Are you sure you want to delete this Practice: " + Name + " ?").then(function () {
                PracticesService.DeletePractice(ID).then(function () {
                    $scope.GetAllPractices();
                    btnSuccess("Practice record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };
        $scope.DeletePractice2 = function () {
            $ngBootbox.confirm("Are you sure you want to delete this Practice: " + $scope.Name + " ?").then(function () {
                PracticesService.DeletePractice($scope.ID).then(function () {
                    $scope.GetAllPractices();
                    angular.element("#CloseModel").trigger("click");
                    btnSuccess("Practice record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };
    }]);