app.factory('LoginService',
['$http',
    function ($http) {
        var GetUser = function (d) {
            return $http({
                url: '/Data/UserLogin',
                method: 'POST',
                data: JSON.stringify(d),
                headers: { 'content-type': 'application/json' }
            });
        }

        var VerifyPatient = function (Email, Password) {
            return $http.post("api/Login/VerifyPatient",
            {
                'Email': Email,
                'Password': Password
            });
        };

        return {
            GetUser: GetUser,
            VerifyPatient: VerifyPatient
        }
    }
]);