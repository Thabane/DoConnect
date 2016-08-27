app.controller("MedicalAidController", ["$scope", "MedicalAidService", "$interval",
    function ($scope, MedicalAidService, $interval) {

        MedicalAidService.GetAllMedicalAid().then
        (function (results) {
            $scope.MedicalAid = result.data;
        });
    }]);