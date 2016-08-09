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

//kpi.factory('JobsService',
//    ['$http',
//        function ($http) {
//            var GetJobs = function () {
//                $http.get("/api/Job/GetJobs");
//            }
//            return { GetJobs: GetJobs }
//        }
//    ]);

/*app.factory('PatientsService',
    ['$http',
        function ($http) {
            var GetAllPatients = function () {
                $http.get('api/Patients/GetAllPatients');
            }
            return { GetAllPatients: GetAllPatients }
        }
    ]);*/
