app.controller("EmployeesController", ["$scope", "EmployeesService", "$interval",
    function ($scope, EmployeesService, $interval) {
         
        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        //Select All Employees
        $scope.GetAllEmployees = function () {
            EmployeesService.GetAllEmployees().then
            (function (result) {
                $scope.Employees = result.data;
            });
        };
        $scope.GetAllEmployees();

        //Select EmployeeByID Function
        $scope.ViewEmployee = function (ID) {
            EmployeesService.GetEmployeeByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.FirstName = result["FirstName"];
                $scope.LastName = result["LastName"];
                $scope.ID_Number = result["ID_Number"];
                $scope.Gender = result["Gender"];
                $scope.DOB = result["DOB"];
                $scope.Phone = result["Phone"];
                $scope.Employee_Type = result["Employee_Type"];
                $scope.Practice_ID = result["Practice_ID"];
                $scope.Email = result["Email"];
            });
        };

        //Insert Employee Funtion
        $scope.NewEmployee = function (FirstName, LastName, ID_Number, Gender, DOB, Phone, Employee_Type, Practice_ID, Email) {
            EmployeesService.InsertEmployee(FirstName, LastName, ID_Number, Gender, DOB, Phone, Employee_Type, Practice_ID, Email).success(function () {
                $scope.GetAllEmployees();
                angular.element(".insert").val('');
                btnSuccess("Employee successfully inserted.");
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };

        //Update Employee Funtion
        $scope.function_btnUpdateEmployee = function () {
            var btnText = angular.element("#function_btnUpdateEmployee").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewEmployee").attr("readonly", false);
                angular.element("#function_btnUpdateEmployee").html("Save");
            }
            else {
                EmployeesService.UpdateEmployee($scope.ID, $scope.FirstName, $scope.LastName, $scope.ID_Number, $scope.Gender, $scope.DOB, $scope.Phone, $scope.Employee_Type, $scope.Practice_ID, $scope.Email).success(function () {
                    $scope.GetAllEmployees();
                    btnSuccess("Employee details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".readonly_ViewEmployee").attr("readonly", true);
                angular.element(".readonly_ViewEmployee").css("background-color", "transparent");
                angular.element("#function_btnUpdateEmployee").html("Update");
            }
        };

        //Delete Employee Funtion
        $scope.DeleteEmployee = function () {
            EmployeesService.DeleteEmployee($scope.ID).then(function () {
                $scope.GetAllEmployees();
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });           
        };
    }]);