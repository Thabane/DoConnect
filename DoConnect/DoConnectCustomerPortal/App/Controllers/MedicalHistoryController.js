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
            MedicalHistoryService.getMedicalHistoryByPatientID(document.cookie).success(function (result) {
                //console.log(result);
                $scope.MedicalRecord = result;
                //console.log($scope.MedicalHistory);
            });
        };
        $scope.GetMedicalHistoryByPatientID();

        $scope.ViewDiagnosis = function (ID) {
            MedicalHistoryService.portal_GetMedicalHistoryID(ID).success(function (result) {
                $scope.Diagnosis = result["Consultation_Diagnosis"];
                $scope.TestResultSummary = result["Consultation_TestResultSummary"];
                $scope.TreatmentPlan = result["Consultation_TreatmentPlan"];
                $scope.Presciption_ID = result["Consultation_Presciption_ID"];
            });

            $('#View_Diagnosis_Modal').modal('show');
        };
        
}]);