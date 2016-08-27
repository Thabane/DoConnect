app.controller("MedicineInventoryController", ["$scope", "MedicineInventoryService", "$interval",
    function ($scope, MedicineInventoryService, $interval) {

        MedicineInventoryService.GetAllMedicineInventory().then
        (function (results) {
            $scope.MedicineInventory = result.data;
        });
    }]);