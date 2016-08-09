app.factory('DashboardService',
    ['$http',
        function($http) {
            var getStuff = function ()
            {
                return "";//$http.get('/api/BuildState');
            }
            return {
                getStuff: getStuff
        }
        }
    ]);