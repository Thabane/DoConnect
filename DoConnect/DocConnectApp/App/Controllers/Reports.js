app.controller("ReportsController", ["$scope", "ReportsService", "$interval",
    function ($scope, ReportsService, $interval) {

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        $scope.GetAllPractices = function () {
            ReportsService.GetAllPractices().then(function (result) { 
                $scope.Practices = [];                
                for (var i = 0; i < (result.data.length + 1); i++) {                    
                    if (i == result.data.length) {                        
                        $scope.Practices.push({ "Name": "All Practices", "ID": "0" });
                    }
                    else {
                        $scope.Practices.push({ "Name": result.data[i]["Name"], "ID": result.data[i]["ID"] });
                    }
                }                
            });
        };
        $scope.GetAllPractices();

        $scope.Practice_ID = 0;
        $scope.changedValueGetPractice_ID = function (item) {
            $scope.Practice_ID = item.ID;
            $scope.Practice_Name = item.Name;

            if ($scope.Practice_ID == "0") {
                ReportsService.GetAllPatients().then(function (result) {
                        $scope.Patients = result.data;
                    });
            }
            else{ 
                ReportsService.GetAllPatientsByPracticeID($scope.Practice_ID).then(function (result) {
                    $scope.Patients = result.data;
                });
            }
        };
    }]);