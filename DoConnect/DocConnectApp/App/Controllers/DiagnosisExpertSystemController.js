app.controller("DiagnosisExpertSystemController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval, $localStorage) {


        $scope.GetSymptoms = function () {
            DiagnosisExpertSystemService.getDiagnosisExpertSystem().then
            (function (result) {
                $scope.Symp = result.data;
            });
        };
        $scope.GetSymptoms();
        //$scope.AddEvidence();
        $scope.AddEvidence = function (id) {
            
            //var obj = JSON.parse(localStorage.getItem('myStorage'));

            var evid = [];

            evid.push({"id": id});

            localStorage.setItem('myStorage', JSON.stringify(evid));
        };


    }]);