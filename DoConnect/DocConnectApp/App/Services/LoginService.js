app.factory('LoginService',
    function ($http) {
        var VerifyUser = function (Email) {
            return $http.get("api/Login/VerifyUser/" + Email);
        }

        return {
            VerifyUser: VerifyUser
        };
    }
);