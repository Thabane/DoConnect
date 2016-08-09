app.factory('MedicalAidService',
    ['$http',
        function ($http) {
            return GetMedicalAid = function () {
                return $http.get("/api/GetAllMedicalAid");
            }
        }
    ]);