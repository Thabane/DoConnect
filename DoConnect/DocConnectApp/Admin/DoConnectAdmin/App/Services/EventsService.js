app.factory('EventsService',
    ['$http',
        function ($http) {
            return GetEvents = function () {
                return $http.get("/api/GetAllEvents");
            }
        }
    ]);