app.factory('AccountingService',
    ['$http',
        function ($http) {
            return GetAccounting = function () {
                return $http.get("/api/GetAllAccounting");
            }
        }
    ]);