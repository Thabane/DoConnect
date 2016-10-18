app.factory('DashboardService',
    ['$http',
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

        var Consulations_Visits = function (Practice_ID) {
            return $http.get("api/Dashboard/Consulations_Visits/" + Practice_ID);
        };

        var Appointment_Stats = function (Practice_ID) {
            return $http.get("api/Dashboard/Appointment_Stats/" + Practice_ID);
        };

        var GetPendingAppointmentsByPracticeID = function (Practice_ID) {
            return $http.get("api/Dashboard/GetPendingAppointmentsByPracticeID/" + Practice_ID);
        };
        
        var GetAppovedAppointmentsByPracticeID = function (Practice_ID) {
            return $http.get("api/Dashboard/GetAppovedAppointmentsByPracticeID/" + Practice_ID);
        };

        var GetRejectedAppointmentsByPracticeID = function (Practice_ID) {
            return $http.get("api/Dashboard/GetRejectedAppointmentsByPracticeID/" + Practice_ID);
        };
                
        var AppoveAppointment = function (ID) {
            return $http.post("api/Dashboard/AppoveAppointment",
            {
                'Appointments_ID': ID,
                'Appointments_App_Status': 1
            });
        };

        var RejectAppointment = function (ID) {
            return $http.post("api/Dashboard/RejectAppointment",
            {
                'Appointments_ID': ID,
                'Appointments_App_Status': 0
            });
        };

        var GetAllMessages = function (Receiver) {
            return $http.get("api/Dashboard/GetAllMessages/" + Receiver);
        };

        var NumOfUnReadMessages = function (Receiver) {
            return $http.get("api/Dashboard/NumOfUnReadMessages/" + Receiver);
        };

        var MedicineInventoryStockCount = function (Practice_ID) {
            return $http.get("api/Dashboard/MedicineInventoryStockCount/" + Practice_ID);
        };

        return {
            SessionData: SessionData,
            GetAllPractices: GetAllPractices,
            GetRevenueSummary_Today: GetRevenueSummary_Today,
            GetRevenueSummary_Week: GetRevenueSummary_Week,
            GetNumPatientsByPractice: GetNumPatientsByPractice,
            Consulations_Visits: Consulations_Visits,
            Appointment_Stats: Appointment_Stats,
            GetPendingAppointmentsByPracticeID: GetPendingAppointmentsByPracticeID,
            GetAppovedAppointmentsByPracticeID: GetAppovedAppointmentsByPracticeID,
            GetRejectedAppointmentsByPracticeID: GetRejectedAppointmentsByPracticeID,
            AppoveAppointment: AppoveAppointment,
            RejectAppointment: RejectAppointment,
            NumOfUnReadMessages: NumOfUnReadMessages,
            GetAllMessages: GetAllMessages,
            MedicineInventoryStockCount: MedicineInventoryStockCount


        }
    }
]);