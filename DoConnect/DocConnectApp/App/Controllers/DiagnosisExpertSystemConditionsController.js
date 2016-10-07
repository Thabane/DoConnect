app.controller("DiagnosisExpertSystemConditionsController", ["$scope", "DiagnosisExpertSystemService", "$interval", '$routeParams', '$route',
    function ($scope, DiagnosisExpertSystemService, $interval, $routeParams, $route) {

        $scope.GetCondition = function () {
            DiagnosisExpertSystemService.getCondition($routeParams.conId).then
            (function (result) {
                $scope.Condition = result.data;
            });
        };

        $scope.GetCondition();



    }]);