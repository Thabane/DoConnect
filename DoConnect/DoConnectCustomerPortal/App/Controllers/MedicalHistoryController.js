app.controller("MedicalHistoryController", ["$scope", "MedicalHistoryService", "$interval",
    function ($scope, MedicalHistoryService, $interval) {
        $scope.MedicalHistory;

        //View Filter's
        $scope.strSort;
        $scope.limitTo = 5;

        $scope.setlimitTo = function (limit) {
            $scope.limitTo = limit;
        }
        $scope.getlimitTo = function () {
            return $scope.limitTo;
        }
        $scope.setSortKey = function (key) {
            $scope.strSort = key;
        }
        $scope.getSortKey = function () {
            return $scope.strSort;
        }
        $scope.setAdminID = function (val) {
            $scope.empID = val;
        }
        $scope.getAdminID = function () {
            return $scope.empID;
        }

        //Select GetMedicalHistoryByPatientID Function
        $scope.GetMedicalHistoryByPatientID = function () {
            MedicalHistoryService.GetMedicalHistoryByPatientID(1).success(function (result) {
                console.log(result);
                $scope.MedicalHistory = result.data;
                console.log($scope.MedicalHistory);
            });
        };
        $scope.GetMedicalHistoryByPatientID();

        $scope.ViewDiagnosis = function (ID) {
            MedicalHistoryService.Portal_GetMedicalHistoryID(1).success(function (result) {
                $scope.Diagnosis = result["Diagnosis"];
                $scope.TestResultSummary = result["TestResultSummary"];
                $scope.TreatmentPlan = result["TreatmentPlan"];
                $scope.Presciption_ID = result["Presciption_ID"];
            });
        };
        
}]);