app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval, $localStorage) {


        $scope.GetSymptoms = function () {
            DiagnosisExpertSystemService.getDiagnosisExpertSystem().then
            (function (result) {
                $scope.Symp = result.data;
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
                    arr.push(data[i].id);
                }
            }
            localStorage.setItem('myStorage', JSON.stringify(arr));
            $scope.getStoredData();
        }
        
        $scope.getStoredData = function () {
            var obj = JSON.parse(localStorage.getItem('myStorage'));
            console.log(obj);
            $scope.GetSymptoms();;
        }

    }]);