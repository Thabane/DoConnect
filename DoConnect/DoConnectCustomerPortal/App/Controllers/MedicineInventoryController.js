app.controller("MedicineInventoryController", ["$scope", "MedicineInventoryService", "$interval",
    function ($scope, MedicineInventoryService, $interval) {
        
        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        //Select All Medicine
        $scope.GetAllMedicines = function () {
            MedicineInventoryService.GetAllMedicines().then
            (function (result) {
                $scope.Medicines = result.data;
            });
        };
        $scope.GetAllMedicines();

        //Select MedicineByID Function
        $scope.ViewMedicine = function (ID) {
            MedicineInventoryService.GetMedicineByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.DrugName = result["DrugName"];
                $scope.Description = result["Description"];
                $scope.DrugConcentration = result["DrugConcentration"];
                $scope.QuantityInStock = result["QuantityInStock"];
                $scope.PurchaseDate = result["PurchaseDate"];
                $scope.ExpiryDate = result["ExpiryDate"];
                $scope.Practice_ID = result["Practice_ID"];
            });
        };

        //Insert Medicine Funtion
        $scope.NewMedicine = function (DrugName, Description, DrugConcentration, QuantityPurchased, ExpiryDate) {
            MedicineInventoryService.InsertMedicine(DrugName, Description, DrugConcentration, QuantityPurchased, ExpiryDate).success(function () {
                $scope.GetAllMedicines();
                angular.element(".insert").val('');
                btnSuccess("Medicine successfully inserted.");
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };

        //Update Medicine Funtion
        $scope.function_btnUpdateMedicine = function () {
            var btnText = angular.element("#function_btnUpdateMedicine").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewMedicine").attr("readonly", false);
                angular.element("#function_btnUpdateMedicine").html("Save");
            }
            else {
                MedicineInventoryService.UpdateMedicine($scope.ID, $scope.DrugName, $scope.Description, $scope.DrugConcentration, $scope.QuantityInStock, $scope.PurchaseDate, $scope.ExpiryDate, $scope.Practice_ID).success(function () {
                    $scope.GetAllMedicines();
                    btnSuccess("Medicine details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".readonly_ViewMedicine").attr("readonly", true);
                angular.element("#function_btnUpdateMedicine").html("Update");
            }
        };

        //Delete Medicine Funtion
        $scope.DeleteMedicine = function () {
            MedicineInventoryService.DeleteMedicine($scope.ID).then(function () {
                $scope.GetAllMedicines();
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });           
        };
    }]);

