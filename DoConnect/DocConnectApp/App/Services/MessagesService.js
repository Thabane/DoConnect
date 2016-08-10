app.factory('MessagesService',
    ['$http',
        function ($http) {
            return GetMessages = function () {
                return $http.get("/api/GetAllMessages");
            }
        }
    ]);