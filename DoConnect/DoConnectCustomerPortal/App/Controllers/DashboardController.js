app.controller('DashboardController', ['$scope', '$interval', 'DashboardService', "PracticesService", "PatientsService", "MessagesService", "AppointmentsService",
    function ($scope, $interval, DashboardService, PracticesService, PatientsService, MessagesService, AppointmentsService) {
        $scope.LoggedOnUserID = document.cookie;
        

        //Select All Practices 
        $scope.GetAllPractices = function () {
            PracticesService.GetAllPractices().then
            (function (result) {
                $scope.Practices = result.data;
                $scope.TotalPracices = result.data.length;
            });
        };

        //Select PatientByID Function
        $scope.ViewPatient = function () {
            PatientsService.GetPatientByID($scope.LoggedOnUserID).then(function (result) {
                $scope.LoggedUserName = result.data["FirstName"] + ' ' + result.data["LastName"];
                $scope.MedicalAid = result.data["Scheme_Name"];
            });
        };

        $scope.ViewNumOfUnReadMessages = function () {
            MessagesService.NumOfUnReadMessages($scope.LoggedOnUserID).then(function(result) {
                $scope.NumOfUnReadMessages = result.data["NumOfUnReadMessages"];
                console.log(result);
            });
        };

        $interval($scope.ViewNumOfUnReadMessages, 5000);

        //Select All Appointments
        $scope.GetAllAppointments = function () {
            $scope.Date_Time = new Date('2016-11-07 10:27');
            AppointmentsService.GetAllAppointments($scope.LoggedOnUserID).then
            (function (result) {
                $scope.AppointmentsTotal = result.data.length;
            });
        };

        $scope.GetAllAppointments();
        $scope.ViewPatient();
        $scope.GetAllPractices();
    }]);