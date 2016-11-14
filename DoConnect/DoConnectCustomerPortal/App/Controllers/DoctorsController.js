app.controller("DoctorsController", ["$scope", "DoctorsService", "$interval", "PatientsService",
			function ($scope, DoctorsService, $interval, PatientsService) {
			    $scope.PageTitle_Doctors = 'Doctors';
			    $scope.PageTitle_NewPractice = 'New Practices Details';
			    $scope.PrefferedDoctor;
			    $scope.LoggedOnUserID = document.cookie;

			    //View Filter's
			    $scope.strSort;
			    $scope.limitTo = 5;

			    $scope.setlimitTo = function (limit) {
			        $scope.limitTo = limit;
			    }
			    $scope.getlimitTo = function () {
			        return $scope.limitTo;
			    }
			    $scope.setSortKey = function (key) {
			        $scope.strSort = key;
			    }
			    $scope.getSortKey = function () {
			        return $scope.strSort;
			    }
			    $scope.setAdminID = function (val) {
			        $scope.empID = val;
			    }
			    $scope.getAdminID = function () {
			        return $scope.empID;
			    }
			    //END View Filter's

			    //Select All Doctors
			    $scope.GetAllDoctors = function () {
			        DoctorsService.GetAllDoctors().then
					(function (result) {
					    //console.log(result.data);
					    $scope.Doctors = result.data;
					});
			    };
			    $scope.GetAllDoctors();

			    //Select GetDoctorByID Function
			    $scope.GetDoctorByID = function (ID) {
			        DoctorsService.GetDoctorByID(ID).success(function (result) {
			            //$scope.ID = result["ID"];
			            $scope.FirstName = result["FirstName"];
			            $scope.LastName = result["LastName"];
			            $scope.Email = result["Email"];
			            $scope.Gender = result["Gender"];
			            $scope.Address = result["Address"];
			            $scope.Job_Title = result["Job_Title"];
			            $scope.User_Id = result["User_Id"];
			            $scope.Practice_ID = result["Practice_ID"];
			        });
			    };

			    $scope.ConfirmPreffered = function (DoctorID) {
			        $scope.PrefferedDoctor = DoctorID;
			        $('#Preffered_Modal').modal('show');
			    };

			    $scope.SetPreffered = function () {
			        DoctorsService.SetAsPreffered($scope.PrefferedDoctor).success(function (result) {
			            $scope.GetAllDoctors();
			        });
			    };

			    //Select Medical Record by PatientID Funtion
			    var GetMedicalRecord = function () {
			        PatientsService.GetMedicalRecord($scope.LoggedOnUserID).then(function (result) {
			            $scope.ID = result.data["ID"];
			            $scope.FirstName = result.data["FirstName"];
			            $scope.LastName = result.data["LastName"];
			            $scope.ID_Number = result.data["ID_Number"];
			            if (result.data["Gender"] == 'M') {
			                $scope.Gender = 'Male';
			            }
			            else {
			                $scope.Gender = 'Female';
			            }
			            $scope.DOB = { value: new Date(result.data["DOB"]) };
			            $scope.Cell_Number = result.data["Cell_Number"];
			            $scope.Street_Address = result.data["Street_Address"];
			            $scope.Suburb = result.data["Suburb"];
			            $scope.City = result.data["City"];
			            $scope.Country = result.data["Country"];
			            $scope.Medical_Aid_ID = result.data["Medical_Aid_ID"];
			            $scope.Medical_Aid_Name = result.data["Name"];
			            $scope.Doctor_ID = result.data["Doctor_ID"];
			            $scope.User_ID = result.data["User_ID"];
			            $scope.Allergies = result.data["Allergies"];
			            $scope.PreviousIllnesses = result.data["PreviousIllnesses"];
			            $scope.PreviousMedication = result.data["PreviousMedication"];
			            $scope.RiskFactors = result.data["RiskFactors"];
			            $scope.SocialHistory = result.data["SocialHistory"];
			            $scope.FamilyHistory = result.data["FamilyHistory"];
			            $scope.Email = result.data["Email"];
			            $scope.Patient_Medical_Aid_Medical_Aid_ID = result.data["Patient_Medical_Aid_Medical_Aid_ID"];
			            $scope.Scheme_Name = result.data["Scheme_Name"];
			            $scope.Membership_Number = result.data["Membership_Number"];
			            if (result.data["Status"] == 'true') {
			                $scope.Status = 'Valid';
			            }
			            else {
			                $scope.Status = 'Invalid';
			            }
			            $scope.Registration_Date = { value: new Date(result.data["Registration_Date"]) };
			            $scope.Deregistration_Date = { value: new Date(result.data["Deregistration_Date"]) };
			            $scope.Patient_ID = result.data["Patient_ID"];
			        });
			    };
			    GetMedicalRecord();

			    //Validation
			    $scope.pattern_Email = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
			    $scope.pattern_Number = /^[0-9]{1,6}$/;
			    $scope.pattern_String = /^[a-zA-Z ]{1,25}$/;

			}]);