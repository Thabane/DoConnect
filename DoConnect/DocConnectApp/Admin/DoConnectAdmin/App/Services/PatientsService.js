app.factory('PatientsService',
    ['$http',
        function ($http) {
            return GetPatients = function () {//GetPatients must be the same as the method name in the controller
                return $http.get("/api/GetAllPatients"); ///calls Patient controller
            }
        }
    ]);