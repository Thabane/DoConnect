app.factory('ReportsService',
    ['$http',
        function ($http) {
            return GetReports = function () {
                return $http.get("/api/GetAllReports");
            }
        }
    ]);