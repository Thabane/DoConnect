app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval","$location",
    function ($scope, DiagnosisExpertSystemService, $interval, $location) {

        $scope.Symptoms = [];
        $scope.Gender = "";
        $scope.GenderSelector = "Select a Gender";

        $scope.GetAllSymptoms = function () {
            DiagnosisExpertSystemService.getAllSymptoms().then
            (function (result) {
                $scope.SymptomBank = result.data;
                $scope.GetRiskFactors();
            });
        };

        $scope.DianosePatient = function (symptoms, age, gender, adv) {

            var evidence;

            if (adv) {
                 evidence = {
                    sex: gender,
                    age: age,
                    evidence: symptoms
                }
            } else {
                evidence = {
                    sex: gender,
                    age: age,
                    evidence: symptoms,
                    extras: {
                        "ignore_groups": true
                    }
                }
            }
            console.log(evidence);
            
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
            if (num === 1) {
                $scope.Gender = "male";
                $scope.GenderSelector = $scope.Gender;
            }
            if (num === 2) {
                $scope.Gender = "female";
                $scope.GenderSelector = $scope.Gender;
            }
            if (num !== 1 && num !== 2) {
                $scope.Gender = "both";
                $scope.GenderSelector = "Select a Gender";
            }
        };
        $scope.GetGender = function () {
            return $scope.Gender;
        };

    }]);