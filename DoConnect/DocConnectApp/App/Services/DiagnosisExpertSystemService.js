app.factory('DiagnosisExpertSystemService',
    ['$http',
        function ($http) {
            var globalResponse;

            var GetFiveRandomSymptoms = function () {
                return $http.get("api/DiagnosisExpertSystem/GetFiveRandomSymptoms");
            }
            var PatientDiagnosis = function(Symtoms) {
                var s = {
                    sex: "male",
                    age: "16",
                    evidence: Symtoms
                }
                globalResponse = $http.post("api/DiagnosisExpertSystem/DiagnosePatient", s);
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
            return {
                getFiveRandomSymptoms: GetFiveRandomSymptoms,
                patientDiagnosis: PatientDiagnosis,
                getAllSymptoms: GetAllSymptoms,
                getAllRiskFactors: GetAllRiskFactors,
                getGlobalResponse: GetGlobalResponse
            }
        }
    ]);