app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval, $location) {

        $scope.Symptoms = [];

        $scope.GetAllSymptoms = function () {
            DiagnosisExpertSystemService.getAllSymptoms().then
            (function (result) {
                $scope.SymptomBank = result.data;
                $scope.GetRiskFactors();
            });
        };

        $scope.DianosePatient = function (symptoms, age, gender) {
            var evidence = {
                sex: gender,
                age: age,
                evidence: symptoms
            }

            DiagnosisExpertSystemService.patientDiagnosis(evidence).then
            (function () {
            });
        };

        $scope.GetAllSymptoms();


        $scope.AddEvidence = function (data) {

            if (data != undefined) {
                var sympt =
                    {
                        id: data[0].id,
                        choice_id: "present",
                        name: data[0].name
                    }
                $scope.Symptoms.push(sympt);
            }
        }

        $scope.GetRiskFactors = function () {
            DiagnosisExpertSystemService.getAllRiskFactors().then
            (function (result) {
                $scope.RiskBank = result.data;
            });
        };

    }]);