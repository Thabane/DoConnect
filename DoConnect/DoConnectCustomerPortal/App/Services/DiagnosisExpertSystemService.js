app.factory('DiagnosisExpertSystemService',
    ['$http',
        function ($http) {
            return GetDiagnosisExpertSystem = function () {
                return $http.get("/api/GetAllDiagnosisExpertSystem");
            }
        }
    ]);