app.controller("DiagnosisExpertSystemProcessController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval) {

        $scope.GetGlobalResponse = function () {
            DiagnosisExpertSystemService.getGlobalResponse().then
            (function (result) {
                $scope.DiagnosisResponse = result.data;
            });
        };

        $scope.GetGlobalResponse();



    }]);