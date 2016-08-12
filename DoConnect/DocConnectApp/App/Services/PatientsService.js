app.factory('PatientsService',
    ['$http',
        function ($http) {
            var GetAllPatients = function () {
                return  $http.get("api/Patients/GetAllPatients");
            }
            return { GetAllPatients: GetAllPatients }

            var GetPatient = function (ID) {
                return $http.get("api/Patients/GetPatient?ID"+ID);
            }
            return { GetPatient: GetPatient }
        }
    ]);


