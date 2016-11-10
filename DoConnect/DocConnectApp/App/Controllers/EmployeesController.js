﻿app.controller("EmployeesController", ["$scope", "EmployeesService", "$interval", "$ngBootbox", "$location",
    function ($scope, EmployeesService, $interval, $ngBootbox, $location) {

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        $scope.GetAllEmployees = function () {
            EmployeesService.GetAllEmployees().then
            (function (result) {
                $scope.Employees = result.data;
            });

            EmployeesService.SessionData().success(function (result) {
                sessionStorage.SessionData_User_ID = result["User_ID"];
                sessionStorage.SessionData_FirstName = result["FirstName"];
                sessionStorage.SessionData_LastName = result["LastName"];
                sessionStorage.SessionData_Email = result["Email"];
                sessionStorage.SessionData_Practice_ID = result["Practice_ID"];
                sessionStorage.SessionData_AccessLevel = result["AccessLevel"];                
            });
        };
        $scope.GetAllEmployees();

        if (sessionStorage.SessionData_AccessLevel == '1' || sessionStorage.SessionData_AccessLevel == '2') {
            angular.element(".doctorControls").show();
        }
        else {
            angular.element(".doctorControls").hide();
        }

        $scope.Genders = [{ "Gender": "Male", "Char": "M" }, { "Gender": "Female", "Char": "F" }];

        $scope.ViewEmployee = function (ID) {
            EmployeesService.GetEmployeeByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.FirstName = result["FirstName"];
                $scope.LastName = result["LastName"];
                $scope.ID_Number = result["ID_Number"];

                if (result["Gender"] == 'M') {
                    $scope.Gender = 'Male';
                }
                else {
                    $scope.Gender = 'Female';
                }
                $scope.DOB = result["DOB"];
                $scope.Phone = result["Phone"];
                $scope.Street_Address = result["Street_Address"];
                $scope.Suburb = result["Suburb"];
                $scope.City = result["City"];
                $scope.Country = result["Country"];
                $scope.Employee_Type = result["Employee_Type"];
                $scope.PRACTICE_ID = result["PRACTICE_ID"];
                $scope.Practice_Name = result["PRACTICE_Name"];
                $scope.User_ID = result["User_ID"];
                $scope.Email = result["Email"];
            });
        };

        $scope.GetAllAccessLevel = function () {
            EmployeesService.GetAllAccessLevel().then
            (function (result) {
                $scope.AccessLevel = result.data;
            });
        };
        $scope.GetAllAccessLevel();

        $scope.Seleceted_ACCESSLEVEL_LEVEL = 0;
        $scope.changedValueGetAccessLevel = function (item) {
            EmployeesService.GetAccessLevelByID(item.ID).success(function (result) {
                $scope.Seleceted_ACCESSLEVEL_ID = result["ID"];
                $scope.Seleceted_ACCESSLEVEL_LEVEL = result["Level"];
            });
        };

        $scope.GetAllPractices = function () {
            EmployeesService.GetAllPractices().then
            (function (result) {
                $scope.Practices = result.data;
            });
        };
        $scope.GetAllPractices();

        $scope.Practice_ID = 0;
        $scope.changedValueGetPractice_ID = function (item) {
            $scope.Practice_ID = item.ID;
            $scope.Practice_Name = item.Name;
        };

        $scope.Seleceted_Gender = 0;
        $scope.changedValueGetGender = function (item) {
            $scope.Seleceted_Gender = item.Char;
        };

        $scope.NewEmployee = function (FirstName, LastName, ID_Number, Phone, Street_Address, Suburb, City, Country, Email) {
            if (sessionStorage.SessionData_AccessLevel == '1' || sessionStorage.SessionData_AccessLevel == '2') {
                EmployeesService.InsertEmployee(FirstName, LastName, ID_Number, $scope.Seleceted_Gender, angular.element("#DOB").val(), Phone, Street_Address, Suburb, City, Country, $scope.Seleceted_ACCESSLEVEL_ID, $scope.Seleceted_ACCESSLEVEL_LEVEL, $scope.Practice_ID, Email).success(function () {
                    $scope.GetAllEmployees();
                    angular.element(".insert").val('');
                    btnSuccess("Employee successfully inserted.");
                    $location.path('/Employees');
                }, function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
            }
            else {
                EmployeesService.InsertEmployee(FirstName, LastName, ID_Number, $scope.Seleceted_Gender, angular.element("#DOB").val(), Phone, Street_Address, Suburb, City, Country, $scope.Seleceted_ACCESSLEVEL_ID, $scope.Seleceted_ACCESSLEVEL_LEVEL, sessionStorage.SessionData_Practice_ID, Email).success(function () {
                    $scope.GetAllEmployees();
                    angular.element(".insert").val('');
                    btnSuccess("Employee successfully inserted.");
                    $location.path('/Employees');
                }, function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
            }
        };

        $scope.function_btnUpdateEmployee = function () {
            var btnText = angular.element("#function_btnUpdateEmployee").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewEmployee").attr("readonly", false); angular.element(".disable_ViewEmployee").prop("disabled", false);
                angular.element("#function_btnUpdateEmployee").html("Save");
            }
            else {
                if ($scope.Gender == 'Male') { $scope.G = 'M'; } else { $scope.G = 'F'; }
                if ($scope.Seleceted_Gender == 0) { $scope.Seleceted_Gender = $scope.G }
                if ($scope.Practice_ID == 0) { $scope.Practice_ID = $scope.PRACTICE_ID }
                if ($scope.Seleceted_ACCESSLEVEL_LEVEL == 0) { $scope.Seleceted_ACCESSLEVEL_LEVEL = $scope.Employee_Type }
                console.log($scope.ID, $scope.FirstName, $scope.LastName, $scope.ID_Number, $scope.Seleceted_Gender, angular.element("#DOB").val(), $scope.Phone, $scope.Street_Address, $scope.Suburb, $scope.City, $scope.Country, $scope.Seleceted_ACCESSLEVEL_LEVEL, $scope.Practice_ID, $scope.Email);
                EmployeesService.UpdateEmployee($scope.ID, $scope.FirstName, $scope.LastName, $scope.ID_Number, $scope.Seleceted_Gender, angular.element("#DOB").val(), $scope.Phone, $scope.Street_Address, $scope.Suburb, $scope.City, $scope.Country, $scope.Seleceted_ACCESSLEVEL_LEVEL, $scope.Practice_ID, $scope.Email).success(function () {
                    $scope.GetAllEmployees();
                    btnSuccess("Employee details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });

                angular.element(".readonly_ViewEmployee").attr("readonly", true); angular.element(".disable_ViewEmployee").prop("disabled", true);
                angular.element(".readonly_ViewEmployee").css("background-color", "transparent");
                angular.element("#function_btnUpdateEmployee").html("Update");
            }
        };

        $scope.DeleteEmployee1 = function (User_ID, Name) {
            $ngBootbox.confirm("Are you sure you want to delete this Employee: " + Name + "?").then(function () {
                EmployeesService.DeleteEmployee(User_ID).then(function () {
                    $scope.GetAllEmployees();
                    btnSuccess("Employee record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
        $scope.DeleteEmployee2 = function () {
            $ngBootbox.confirm("Are you sure you want to delete this Employee: " + $scope.FirstName+" "+$scope.LastName + "?").then(function () {
                EmployeesService.DeleteEmployee($scope.User_ID).then(function () {
                    $scope.GetAllEmployees();
                    angular.element("#CloseModel").trigger("click");
                    btnSuccess("Employee record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
    }]); 