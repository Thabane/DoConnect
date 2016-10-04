app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval, $localStorage) {

        $scope.Symptoms = [];

        $scope.GetAllSymptoms = function () {
            DiagnosisExpertSystemService.getAllSymptoms().then
            (function (result) {
                $scope.SymptomBank = result.data;
                $scope.GetRiskFactors();
            });
        };

        $scope.GetFiveRandomSymptoms = function () {
            DiagnosisExpertSystemService.getFiveRandomSymptoms().then
            (function (result) {
                $scope.RandomSymp = result.data;
            });
        };


        $scope.DianosePatient = function () {
            DiagnosisExpertSystemService.patientDiagnosis($scope.Symptoms).then
            (function (result) {
                $scope.response = result.data;
            });
        };


        //$scope.GetFiveRandomSymptoms();
        $scope.GetAllSymptoms();
        //$scope.GetRiskFactors();


        $scope.AddEvidence = function (data) {

            if (data != undefined) {
                var sympt =
                    {
                        id: data[0],
                        choice_id: "present"
                    }
                $scope.Symptoms.push(sympt);
            }
        }

        $scope.populateData = function () {
            //$scope.GetSymptoms();;
        }

        $scope.GetRiskFactors = function () {
            DiagnosisExpertSystemService.getAllRiskFactors().then
            (function (result) {
                $scope.RiskBank = result.data;
            });
        };

    }]);