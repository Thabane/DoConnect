app.factory('MedicineInventoryService',
    function ($http) {
        var GetAllMedicines = function () {
            return $http.get("api/MedicineInventory/GetAllMedicines");
        };

        var GetMedicineByID = function (ID) {
            return $http.get("api/MedicineInventory/GetMedicine/" + ID);
        };

        var InsertMedicine = function (DrugName, Description, QuantityPurchased, PurchaseDate, ExpiryDate, DrugConcentration, Practice_ID) {
            return $http.post("api/MedicineInventory/InsertMedicine",
            {
                'DrugName': DrugName,
                'Description': Description,
                'QuantityPurchased': QuantityPurchased,
                'PurchaseDate': PurchaseDate,
                'ExpiryDate': ExpiryDate,
                'DrugConcentration': DrugConcentration,
                'Practice_ID': Practice_ID
            });
        };

        var UpdateMedicine = function (ID, DrugName, Description, QuantityInStock, DrugConcentration) {
            return $http.post("api/MedicineInventory/UpdateMedicine",
            {
                'ID': ID,
                'DrugName': DrugName,
                'Description': Description,
                'QuantityInStock': QuantityInStock,
                'DrugConcentration': DrugConcentration
            });
        };

        var DeleteMedicine = function (ID) {
            return $http.post("api/MedicineInventory/DeleteMedicine/" + ID);
        };

        return {
            GetAllMedicines: GetAllMedicines,
            GetMedicineByID: GetMedicineByID,
            InsertMedicine: InsertMedicine,
            UpdateMedicine: UpdateMedicine,
            DeleteMedicine: DeleteMedicine
        };
    }
);