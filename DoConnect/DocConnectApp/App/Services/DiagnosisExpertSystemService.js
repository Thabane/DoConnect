app.factory('DiagnosisExpertSystemService',
    ['$http',
        function ($http) {
            var GetDiagnosisExpertSystem = function() {
                return $http.get("api/DiagnosisExpertSystem/GetSymptoms");
            };
            var PatientDiagnosis = function (Symtoms) {
                var s = {
                    sex: "male",
                    age: "16",
                    evidence: Symtoms
                }
                return $http.post("api/DiagnosisExpertSystem/DiagnosePatient", s);
            }
            return {
                getDiagnosisExpertSystem: GetDiagnosisExpertSystem,
                patientDiagnosis: PatientDiagnosis
            }
        }
    ]);