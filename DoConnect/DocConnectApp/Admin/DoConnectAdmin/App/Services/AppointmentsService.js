app.factory('AppointmentsService',
    ['$http',
        function ($http) {
            return GetAppointments = function () {
                return $http.get("/api/GetAllAppointments");
            }
        }
    ]);