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

        return {
            GetUser: GetUser
        }
    }
]);