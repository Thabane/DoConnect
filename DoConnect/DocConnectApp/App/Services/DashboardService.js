app.factory('DashboardService',
    function($http) {
        var SessionData = function () {
            return $http.get("/Data/SessionData");
        };

        var GetAllPractices = function () {
            return $http.get("api/Practices/GetAllPractices");
        };

        var GetRevenueSummary_Today = function (Practice_ID) {
            return $http.get("api/Dashboard/GetRevenueSummary_Today/" + Practice_ID);
        };

        var GetRevenueSummary_Week = function (Practice_ID) {
            return $http.get("api/Dashboard/GetRevenueSummary_Week/" + Practice_ID);
        };

        var GetNumPatientsByPractice = function (Practice_ID) {
            return $http.get("api/Dashboard/GetNumPatientsByPractice/" + Practice_ID);
        };

        return {
            SessionData: SessionData,
            GetAllPractices: GetAllPractices,
            GetRevenueSummary_Today: GetRevenueSummary_Today,
            GetRevenueSummary_Week: GetRevenueSummary_Week,
            GetNumPatientsByPractice: GetNumPatientsByPractice
        }
    }
);