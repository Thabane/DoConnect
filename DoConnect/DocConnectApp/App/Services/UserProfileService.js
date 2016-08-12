app.factory('UserProfileService',
    ['$http',
        function ($http) {
            return GetUserProfile = function () {
                return $http.get("/api/GetAllUserProfile");
            }
        }
    ]);