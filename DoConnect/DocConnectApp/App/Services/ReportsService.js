app.factory('ReportsService',
    ['$http',
        function ($http) {
            var GetAllPractices = function () {
                return $http.get("api/Employees/GetAllPractices");
            };

            var GetAllPatients = function () {
                return $http.get("api/Patients/GetAllPatients");
            };
            
            var GetAllPatientsByPracticeID = function (ID) {
                return $http.get("api/Reports/GetAllPatientsByPracticeID/" + ID);
            };

            return {
                GetAllPractices: GetAllPractices,
                GetAllPatients, GetAllPatients,
                GetAllPatientsByPracticeID, GetAllPatientsByPracticeID
            };
    }
]);