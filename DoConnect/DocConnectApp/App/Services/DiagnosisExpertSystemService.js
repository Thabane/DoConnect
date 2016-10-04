app.factory('DiagnosisExpertSystemService',
    ['$http',
        function ($http) {
            var GetFiveRandomSymptoms = function () {
                return $http.get("api/DiagnosisExpertSystem/GetFiveRandomSymptoms");
            }
            var PatientDiagnosis = function(Symtoms) {
                var s = {
                    sex: "male",
                    age: "16",
                    evidence: Symtoms
                }
                return $http.post("api/DiagnosisExpertSystem/DiagnosePatient", s);
            }
            var GetAllRiskFactors = function () {
                return $http.get("api/DiagnosisExpertSystem/GetAllRiskFactors");
            }
            var GetAllSymptoms = function() {
                return $http.get("api/DiagnosisExpertSystem/GetAllSymptoms");
            }
            return {
                getFiveRandomSymptoms: GetFiveRandomSymptoms,
                patientDiagnosis: PatientDiagnosis,
                getAllSymptoms: GetAllSymptoms,
                getAllRiskFactors: GetAllRiskFactors
            }
        }
    ]);