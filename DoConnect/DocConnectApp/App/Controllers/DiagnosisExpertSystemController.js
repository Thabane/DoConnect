app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval","$location",
    function ($scope, DiagnosisExpertSystemService, $interval, $location) {

        $scope.Symptoms = [];
        $scope.Gender = "Select a Gender";

        $scope.GetAllSymptoms = function () {
            DiagnosisExpertSystemService.getAllSymptoms().then
            (function (result) {
                $scope.SymptomBank = result.data;
                $scope.GetRiskFactors();
                $scope.SetGender(3);
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

            $location.path('/DiagnosisExpertSystemProcess');
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

        $scope.SetGender = function (num) {
            if (num == 1) {
                $scope.Gender = "male";
            }
            if (num === 2) {
                $scope.Gender = "female";
            }
            if (num !== 1 && num !== 2) {
                $scope.Gender = "both";
            }
        };
        $scope.GetGender = function (num) {
            return $scope.Gender;
        };

    }]);