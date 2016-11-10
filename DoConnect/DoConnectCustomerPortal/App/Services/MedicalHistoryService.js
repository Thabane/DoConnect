app.factory('MedicalHistoryService',
    function ($http) {

        var GetMedicalHistoryByPatientID = function (PatientID) {
            return $http.get("api/MedicalHistory/GetMedicalHistoryByPatientID/" + PatientID);
        };

        var Portal_GetMedicalHistoryID = function (PatientID) {
            return $http.get("api/MedicalHistory/Portal_GetMedicalHistoryID/" + PatientID);
        };

        return {
            getMedicalHistoryByPatientID: GetMedicalHistoryByPatientID,
            portal_GetMedicalHistoryID: Portal_GetMedicalHistoryID
        };
    }
);