app.controller("MedicineInventoryController", ["$scope", "MedicineInventoryService", "$interval", "$filter", "$ngBootbox",
function ($scope, MedicineInventoryService, $interval, $filter, $ngBootbox) {

    //Sort Function
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    $scope.GetAllMedicine = function () {
        MedicineInventoryService.GetAllMedicines().then(function (result) {
            $scope.Medicines = result.data;
        });
    };
    $scope.GetAllMedicine();

    $scope.ViewMedicine = function (ID) {
        MedicineInventoryService.GetMedicineByID(ID).success(function (result) {
            $scope.ID = result["ID"];
            $scope.DrugName = result["DrugName"];
            $scope.Description = result["Description"];
            $scope.QuantityPurchased = result["QuantityPurchased"];
            $scope.PurchaseDate = result["PurchaseDate"];
            $scope.QuantityInStock = result["QuantityInStock"];
            $scope.ExpiryDate = result["ExpiryDate"];
            $scope.DrugConcentration = result["DrugConcentration"];
            $scope.Practice_ID = result["Practice_ID"];
            $scope.PracticeName = result["PracticeName"];
        });
    };

    $scope.today = $filter('date')(new Date(), 'yyyy-MM-dd');

    $scope.NewMedicine = function (_DrugName, _Description, _DrugConcentration, _QuantityPurchased) {
        MedicineInventoryService.InsertMedicine(_DrugName, _Description, _QuantityPurchased, $scope.today, angular.element("#ExpiryDate").val(), _DrugConcentration, 2).success(function () {
            $scope.GetAllMedicine();
            angular.element(".insert").val('');
            btnSuccess("Medicine successfully inserted.");
        },
            function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });
    };

    $scope.function_btnUpdateMedicine = function () {
        var btnText = angular.element("#function_btnUpdateMedicine").html();
        if (btnText == "Update") {
            angular.element(".readonly_ViewMedicine").attr("readonly", false);
            angular.element("#function_btnUpdateMedicine").html("Save");
        }
        else {
            MedicineInventoryService.UpdateMedicine($scope.ID, $scope.DrugName, $scope.Description, $scope.QuantityInStock, $scope.DrugConcentration).success(function () {
                $scope.GetAllMedicine();
                btnSuccess("Medicine details successfully updated.");
            }, function (error) {
                btnAlert("System Error Message", "Update unsuccessful.");
            });
            angular.element(".readonly_ViewMedicine").attr("readonly", true);
            angular.element("#function_btnUpdateMedicine").html("Update");
        }
    };

    $scope.DeleteMedicine1 = function (ID) {
        $ngBootbox.confirm("Are you sure you want to delete this Medicine?").then(function () {
            MedicineInventoryService.DeleteMedicine(ID).then(function () {
                $scope.GetAllMedicine();
                btnSuccess("Medicine record successfully deleted.");
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });
        }, function () {
            //Confirm was cancelled, don't delete customer
            console.log('Confirm was cancelled');
        });
    };
    $scope.DeleteMedicine2 = function () {
        $ngBootbox.confirm("Are you sure you want to delete this Medicine?").then(function () {
            MedicineInventoryService.DeleteMedicine($scope.ID).then(function () {
                $scope.GetAllMedicine();
                angular.element("#CloseModel").trigger("click");
                btnSuccess("Medicine record successfully deleted.");
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });
        }, function () {
            //Confirm was cancelled, don't delete customer
            console.log('Confirm was cancelled');
        });
    };
}]);

