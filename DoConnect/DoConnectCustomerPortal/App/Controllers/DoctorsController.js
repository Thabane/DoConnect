app.controller("DoctorsController", ["$scope", "DoctorsService", "$interval",
			function ($scope, DoctorsService, $interval) {
				$scope.PageTitle_Doctors = 'Doctor\'s';
				$scope.PageTitle_NewPractice = 'New Practices Details';

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
						console.log(result.data);
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

				//Validation
				$scope.pattern_Email = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
				$scope.pattern_Number = /^[0-9]{1,6}$/;
				$scope.pattern_String = /^[a-zA-Z ]{1,25}$/;

			}]);