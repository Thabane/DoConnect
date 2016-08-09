app.factory('EmployeesService',
    ['$http',
        function ($http) {
            return GetEmployees = function () {
                return $http.get("/api/GetAllEmployees");
            }
        }
    ]);