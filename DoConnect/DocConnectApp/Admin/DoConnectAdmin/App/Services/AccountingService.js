app.factory('AccountingService',
    ['$http',
        function ($http) {
            return GetExpenses = function () {
                return $http.get("/api/GetExpenses");
            }
        }
    ]);