app.factory('AuthHttpResponseInterceptor',
    ['$q', '$location', '$injector',
    function ($q, $location, $injector) {
        return {
            response: function (response) {
                if (response.status === 401) {
                    console.log("Response 401");
                }
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    console.log("Response Error 401", rejection);
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        }
    }
]);

