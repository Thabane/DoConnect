app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval) {


        $scope.GetSymptoms = function () {
            DiagnosisExpertSystemService.getDiagnosisExpertSystem().then
            (function (result) {
                $scope.Symp = result.data;
            });
        };
        $scope.GetSymptoms();
    }]);