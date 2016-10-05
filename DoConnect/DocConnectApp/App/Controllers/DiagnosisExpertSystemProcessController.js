app.controller("DiagnosisExpertSystemProcessController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval) {

        $scope.GetGlobalResponse = function () {
            DiagnosisExpertSystemService.getGlobalResponse().then
            (function (result) {
                $scope.DiagnosisResponse  = result.data;
            });
        };

        if ($scope.response === undefined) {
            $scope.GetGlobalResponse();
        }

        $scope.CheckScope = function () {
            var hold = 2;
        };                


    }]);