app.controller("MedicineInventoryController", ["$scope", "MedicineInventoryService", "$interval",
    function ($scope, MedicineInventoryService, $interval) {

        var init_ControlSettings = function () {
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
            angular.element(".readonly").css("font-size", "13px");
            angular.element(".readonly").css("padding-right", "0px");
            angular.element(".readonly_ViewMedicine").attr("readonly", true);
            angular.element("#myFunctionMedicineInventory_Edit").show(); angular.element("#myFunctionMedicineInventory_Save").hide();
        }
        init_ControlSettings();

        $scope.myFunctionMedicineInventory_Edit = function () {
            angular.element("#myFunctionMedicineInventory_Edit").hide(); angular.element("#myFunctionMedicineInventory_Save").show();
            angular.element(".readonly").attr("readonly", false);
            angular.element(".readonly").css("border", "1px solid #ccc");
        };

        $scope.myFunctionMedicineInventory_Save = function () {
            angular.element("#myFunctionMedicineInventory_Edit").show(); angular.element("#myFunctionMedicineInventory_Save").hide();
            angular.element(".readonly").attr("readonly", true);
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
        };

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