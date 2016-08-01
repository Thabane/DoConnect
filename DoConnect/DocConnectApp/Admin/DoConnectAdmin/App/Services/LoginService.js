app.factory('LoginService',
    ['$http',
        function ($http) {
            return GetLogin = function () {
                return $http.get("/api/GetAllLogin");
            }
        }
    ]);