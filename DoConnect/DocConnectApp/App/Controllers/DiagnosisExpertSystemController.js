app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval, $localStorage) {

        $scope.Symptoms = [];

        $scope.GetSymptoms = function () {
            DiagnosisExpertSystemService.getDiagnosisExpertSystem().then
            (function (result) {
                $scope.Symp = result.data;
            });
        };


        $scope.DianosePatient = function () {
            DiagnosisExpertSystemService.patientDiagnosis($scope.Symptoms).then
            (function (result) {
                $scope.response = result.data;
                //Console.log($scope.response);
            });
        };

        
        $scope.GetSymptoms();
        localStorage.clear();

        $scope.AddEvidence = function (data) {

            if (localStorage.getItem('myStorage') === null) {
                var arr = [];
            } else {
                var arr = JSON.parse(localStorage.getItem('myStorage'));
            }
            

            for (var i in data) {
                if (data[i].SELECTED == "1") {
                    var sympt = {
                        id: data[i].id,
                        choice_id: "present",
                        name: data[i].name
                    }
                    $scope.Symptoms.push(sympt);
                    arr.push(sympt);
                }
            }
            localStorage.setItem('myStorage', JSON.stringify(arr));
            $scope.getStoredData();

            if ($scope.Symptoms != undefined) {
                //$scope.DianosePatient();
            }
        }
        
        $scope.getStoredData = function () {
            var obj = JSON.parse(localStorage.getItem('myStorage'));
            //console.log(obj);
            $scope.GetSymptoms();;
        }

    }]);