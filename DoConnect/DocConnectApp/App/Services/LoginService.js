app.factory('LoginService',
    function ($http) {

        var GetUser = function (d) {
            return $http({
                url: '/Data/UserLogin',
                method: 'POST',
                data: JSON.stringify(d),
                headers: { 'content-type': 'application/json' }
            });
        }

        
        var GetUserDetailsByUser_ID = function (ID) {
            return $http.get("api/Login/GetUserDetailsByUser_ID/" + ID);
        }

        return {
            GetUser: GetUser,
            GetUserDetailsByUser_ID: GetUserDetailsByUser_ID
        }
    }
);