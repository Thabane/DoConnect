app.factory('PracticesService',
    ['$http',
        function ($http) {
            var GetAllPractices = function () {
                return $http.get("api/Practices/GetAllPractices");
            }
            return { GetAllPractices: GetAllPractices }

        }
    ]);