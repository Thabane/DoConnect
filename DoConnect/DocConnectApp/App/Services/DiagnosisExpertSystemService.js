app.factory('DiagnosisExpertSystemService',
    ['$http',
        function ($http) {
            var GetDiagnosisExpertSystem = function () {
                return  $http.get("api/DiagnosisExpertSystem/GetSymptoms");
            }
            return{
                getDiagnosisExpertSystem : GetDiagnosisExpertSystem
            }
        }
    ]);