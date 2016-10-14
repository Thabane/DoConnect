app.factory('DiagnosisExpertSystemService',
    ['$http',
        function ($http) {
            var globalResponse;
            var chosenEvidence;

            var GetCondition = function (conId) {
                condition = $http.get("api/DiagnosisExpertSystem/GetCondition?conId="+ conId);
                return condition;
            }

            var GetFiveRandomSymptoms = function () {
                return $http.get("api/DiagnosisExpertSystem/GetFiveRandomSymptoms");
            }
            var PatientDiagnosis = function(evidence) {
                globalResponse = $http.post("api/DiagnosisExpertSystem/DiagnosePatient", evidence);
                chosenEvidence = evidence;
                return globalResponse;
            }
            var PatientDiagnosisReturn = function (Symtoms) {
                globalResponse = $http.post("api/DiagnosisExpertSystem/DiagnosePatient", Symtoms);
                return globalResponse;
            }
            var GetAllRiskFactors = function () {
                return $http.get("api/DiagnosisExpertSystem/GetAllRiskFactors");
            }
            var GetAllSymptoms = function() {
                return $http.get("api/DiagnosisExpertSystem/GetAllSymptoms");
            }
            var GetGlobalResponse = function () {
                return globalResponse;
            }
            var GetChosenEvidence = function () {
                return chosenEvidence;
            }
            var AddToChosenEvidence = function (evid) {
                chosenEvidence.evidence.push(evid);
            }
            return {
                getFiveRandomSymptoms: GetFiveRandomSymptoms,
                patientDiagnosis: PatientDiagnosis,
                getAllSymptoms: GetAllSymptoms,
                getAllRiskFactors: GetAllRiskFactors,
                getGlobalResponse: GetGlobalResponse,
                getCondition: GetCondition,
                patientDiagnosisReturn: PatientDiagnosisReturn,
                getChosenEvidence: GetChosenEvidence,
                setChosenEvidence: AddToChosenEvidence
            }
        }
    ]);