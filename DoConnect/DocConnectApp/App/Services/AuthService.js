app.factory('AuthService',
['$http',
    function ($http) {

           var isLoggedIn = function () {
               var _user = $http.get("api/Dashboard/SessionData");

               console.log("AuthService User Array: " + _user);
               if (_user[0].User_ID != 0) {
                   console.log("return true;");
                   return true;                   
               }
               else {
                   console.log("return false;");
                   return false;
               }
           }

           return {
                    isLoggedIn: isLoggedIn,
              
                  logout: function () {
                     window.localStorage.removeItem("session");
                     window.localStorage.removeItem("list_dependents");
                     _user = null;
                  }
           }
    }
]);