app.controller("UserProfileController", ["$scope", "UserProfileService", "$interval", "PatientsService",
    function ($scope, UserProfileService, $interval, PatientsService) {
        
        $scope.SessionData = function () {
            UserProfileService.SessionData().success(function (result) {
                $scope.SessionData_ID = result["ID"];
                $scope.SessionData_User_ID = result["User_ID"];
                $scope.SessionData_FirstName = result["FirstName"];
                $scope.SessionData_LastName = result["LastName"];
                $scope.SessionData_Email = result["Email"];
                $scope.SessionData_Practice_ID = result["Practice_ID"];
                $scope.SessionData_AccessLevel = result["AccessLevel"];

                $scope.GetLoggedinUserProfile();
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

        $scope.GetLoggedinUserProfile = function () {
            PatientsService.GetProfileByPatientID($scope.SessionData_ID).then(function (result) {
                $scope.ID = result.data["ID"];
                $scope.FirstName = result.data["FirstName"];
                $scope.LastName = result.data["LastName"];
                $scope.ID_Number = result.data["ID_Number"];
                if (result.data["Gender"] == 'M') { $scope.Gender = 'Male'; } else { $scope.Gender = 'Female'; }
                $scope.DOB = result.data["DOB"];
                $scope.Cell_Number = result.data["Cell_Number"];
                $scope.Street_Address = result.data["Street_Address"];
                $scope.Suburb = result.data["Suburb"];
                $scope.City = result.data["City"];
                $scope.Country = result.data["Country"];
                $scope.Medical_Aid_ID = result.data["Medical_Aid_ID"];
                $scope.Medical_Aid_Name = result.data["Name"];
                $scope.Doctor_ID = result.data["Doctor_ID"];
                $scope.Scheme_Name = result.data["Scheme_Name"];
                $scope.Membership_Number = result.data["Membership_Number"];
                if (result.data["Status"])
                { $scope.Status = "Valid"; }
                else { $scope.Status = "Invalid"; }
                $scope.Registration_Date = result.data["Registration_Date"];
                $scope.Deregistration_Date = result.data["Deregistration_Date"];
                $scope.Patient_ID = result.data["Patient_ID"];
                $scope.Medical_Aid_Name =   result.data["Medical_Aid_Name"];
                $scope.Doctors_FirstName =  result.data["Doctors_FirstName"];
                $scope.Doctors_LastName =   result.data["Doctors_LastName"];
                $scope.Practice_Aid_Name =  result.data["Practice_Aid_Name"];
            });             
        };
    }]);