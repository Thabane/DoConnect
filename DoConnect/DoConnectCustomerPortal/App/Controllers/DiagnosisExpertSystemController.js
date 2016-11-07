app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval) {

        DiagnosisExpertSystemService.GetAllDiagnosisExpertSystem().then
        (function (results) {
            $scope.DiagnosisExpertSystem = result.data;
        });
    }]);