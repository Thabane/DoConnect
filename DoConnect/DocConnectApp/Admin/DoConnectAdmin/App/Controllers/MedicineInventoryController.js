app.controller("MedicineInventoryController", ["$scope", "MedicineInventoryService", "$interval",
    function ($scope, MedicineInventoryService, $interval) {

        $scope.function_btnUpdateMedicine = function () {
            var btnText = angular.element("#function_btnUpdateMedicine").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewMedicine").attr("readonly", false);
                angular.element("#function_btnUpdateMedicine").html("Save");
            }
            else {
                angular.element(".readonly_ViewMedicine").attr("readonly", true);
                angular.element("#function_btnUpdateMedicine").html("Update");
            }
        };
    }]);