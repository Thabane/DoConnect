app.controller('DashboardController', ['$scope', '$interval', 'DashboardService', "AppointmentsService", "AccountingService",
    function ($scope, $interval, DashboardService, AppointmentsService, AccountingService) {
        angular.element("#wrapper").show();
        
        $scope.SessionData = function () {
            DashboardService.SessionData().success(function (result) {
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
                
            });
        };
        $scope.SessionData();

        
    }]);