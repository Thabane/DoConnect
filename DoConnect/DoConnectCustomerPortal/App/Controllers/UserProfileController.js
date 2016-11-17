app.controller("UserProfileController", ["$scope", "UserProfileService", "$interval",
    function ($scope, UserProfileService, $interval) {

        $scope.SessionData = function () {
            UserProfileService.SessionData().success(function (result) {
                $scope.SessionData_User_ID = result["User_ID"];
                $scope.SessionData_FirstName = result["FirstName"];
                $scope.SessionData_LastName = result["LastName"];
                $scope.SessionData_Email = result["Email"];
                $scope.SessionData_Practice_ID = result["Practice_ID"];
                $scope.SessionData_AccessLevel = result["AccessLevel"];

                if (result["AccessLevel"] == '1' || result["AccessLevel"] == '2') {
                    angular.element("#ProfileDetails_DoctorAdmin_div").show();
                    angular.element("#ProfileDetails_Staff_div").hide();
                }
                else {
                    angular.element("#ProfileDetails_DoctorAdmin_div").hide();
                    angular.element("#ProfileDetails_Staff_div").show();
                }

                $scope.GetLoggedinUserProfile($scope.SessionData_User_ID, $scope.SessionData_AccessLevel);
            });
        };
        $scope.SessionData();

        $scope.Genders = [{ "Gender": "Male", "Char": "M" }, { "Gender": "Female", "Char": "F" }];

        angular.element(".div_ChangePassword").hide();
        angular.element(".btnCancel_PasswordChange").hide();

        $scope.btnChangePassword = function (CurrentPassword, NewPassword, ConfirmPassword) {
            var btnText = angular.element(".btnChangePassword").html();
            if (btnText == "Change Password") {
                angular.element(".div_ChangePassword").show();
                angular.element(".btnCancel_PasswordChange").show();
                angular.element(".btnChangePassword").html("Save Password");
            }
            else {
                UserProfileService.GetPassword($scope.SessionData_User_ID).success(function (result) {
                    if (result["Password"] == CurrentPassword) {
                        if (NewPassword == ConfirmPassword) {
                            $scope.UpdatePassword(NewPassword);
                        }
                        else {
                            angular.element("input").val("");
                            btnAlert("System Message", "The new password and confirm password do not match.");
                        }
                    }
                    else {
                        angular.element("input").val("");
                        btnAlert("System Message", "The old password is incorrect.\nPlease enter your old password.");
                    }
                });
            }
        };

        $scope.UpdatePassword = function (NewPassword) {
            UserProfileService.UpdatePassword($scope.SessionData_User_ID, NewPassword).success(function (result) {
                btnSuccess("Password successfully changed");
                angular.element(".div_ChangePassword").hide();
                angular.element(".btnCancel_PasswordChange").hide();
                angular.element(".btnChangePassword").html("Change Password");
                angular.element("input").val("");
            });
        };

        $scope.btnCancel_PasswordChange = function () {
            angular.element(".div_ChangePassword").hide();
            angular.element(".btnCancel_PasswordChange").hide();
            angular.element(".btnChangePassword").html("Change Password");
            angular.element("input").val("");
        };

        $scope.GetLoggedinUserProfile = function (SessionData_User_ID, SessionData_AccessLevel) {
            UserProfileService.GetLoggedinUserProfile(SessionData_User_ID).success(function (result) {
                if ((SessionData_AccessLevel == '1') || (SessionData_AccessLevel == '2')) {
                    $scope.FirstName = result["FirstName"];
                    $scope.LastName = result["LastName"];
                    $scope.Email = result["Email"];
                    if (result["Gender"] == 'M') {
                        $scope.Gender = 'Male';
                    }
                    else {
                        $scope.Gender = 'Female';
                    }
                    $scope.Address = result["Street_Address"];
                    $scope.Employee_Type = result["Employee_Type"];
                    $scope.Practice_Name = result["Practice_Name"];
                    $scope.Practice_Phone_Number = result["Practice_Phone_Number"];
                    $scope.Practice_Fax_Number = result["Practice_Fax_Number"];
                    $scope.Practice_Street_Address = result["Practice_Street_Address"];
                    $scope.Practice_Suburb = result["Practice_Suburb"];
                    $scope.Practice_City = result["Practice_City"];
                    $scope.Practice_Country = result["Practice_Country"];
                }
                else {
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
                    $scope.Email = result["Email"];
                    $scope.Practice_Name = result["Practice_Name"];
                    $scope.Practice_Phone_Number = result["Practice_Phone_Number"];
                    $scope.Practice_Fax_Number = result["Practice_Fax_Number"];
                    $scope.Practice_Street_Address = result["Practice_Street_Address"];
                    $scope.Practice_Suburb = result["Practice_Suburb"];
                    $scope.Practice_City = result["Practice_City"];
                    $scope.Practice_Country = result["Practice_Country"];
                }
            });
        };
    }]);