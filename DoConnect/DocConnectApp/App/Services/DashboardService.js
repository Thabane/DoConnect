app.factory('DashboardService',
    function($http) {
        var SessionData = function () {
            return $http.get("/Data/SessionData");
        };

        return {
            SessionData: SessionData
        }
    }
);