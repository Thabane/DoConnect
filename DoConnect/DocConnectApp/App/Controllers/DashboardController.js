app.controller('DashboardController', ['$scope', '$interval', 'DashboardService', "AppointmentsService", "AccountingService", "PatientsService",
    function ($scope, $interval, DashboardService, AppointmentsService, AccountingService, PatientsService) {
        angular.element("#wrapper").show();
        
        $scope.SessionData = function () {
            DashboardService.SessionData().success(function (result) {
                $scope.SessionData_ID = result["ID"];
                $scope.SessionData_User_ID = result["User_ID"];
                $scope.SessionData_FirstName = result["FirstName"];
                $scope.SessionData_LastName = result["LastName"];
                $scope.SessionData_Email = result["Email"];
                $scope.SessionData_Practice_ID = result["Practice_ID"];
                $scope.SessionData_AccessLevel = result["AccessLevel"];
                
                DashboardService.GetAllMessages($scope.SessionData_User_ID).then(function (result) {
                    $scope.Messages = result.data;
                });

                DashboardService.NumOfUnReadMessages($scope.SessionData_User_ID).then(function (result) {
                    $scope.NumOfUnReadMessages = result.data["NumOfUnReadMessages"];
                });

                AppointmentsService.GetAllAppointments().then(function (result) {
                    $scope.Appointments = result.data;
                    $scope.numTodayApps = $scope.Appointments[$scope.Appointments.length - 1].numTodayApps;
                    $scope.numTomorrowApps = $scope.Appointments[$scope.Appointments.length - 1].numTomorrowApps;
                    $scope.numYesterdayApps = $scope.Appointments[$scope.Appointments.length - 1].numYesterdayApps;
                });

                AccountingService.GetAllInvoices().then(function (result) {
                    $scope.Invoices = result.data;
                    $scope.numOfUnPaid = $scope.Invoices[$scope.Invoices.length - 1].numOfUnPaid;
                    $scope.numOfPatiallyPaid = $scope.Invoices[$scope.Invoices.length - 1].numOfPatiallyPaid;
                });

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
            });
        };
        $scope.SessionData();

        
    }]);