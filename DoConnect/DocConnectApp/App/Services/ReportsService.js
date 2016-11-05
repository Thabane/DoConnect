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

            var FinancialReport_All = function (StartDate, EndDate) {
                return $http.get("api/Reports/FinancialReport_All/" + StartDate + "/" + EndDate);
            };

            var FinancialReportByPracticeID = function (Practice_ID, StartDate, EndDate) {
                return $http.get("api/Reports/FinancialReportByPracticeID/" + Practice_ID + "/" + StartDate + "/" + EndDate);
            };

            return {
                GetAllPractices: GetAllPractices,
                GetAllPatients: GetAllPatients,
                GetAllPatientsByPracticeID: GetAllPatientsByPracticeID,
                FinancialReport_All: FinancialReport_All,
                FinancialReportByPracticeID: FinancialReportByPracticeID
            };
    }
]);