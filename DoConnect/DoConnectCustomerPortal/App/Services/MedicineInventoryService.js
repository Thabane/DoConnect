app.factory('MedicineInventoryService',
    function ($http) {
        //Select all Medicine data
        var GetAllMedicines = function () {
            return $http.get("api/Medicines/GetAllMedicines");
        };

        //Select Medicine by ID
        var GetMedicineByID = function (ID) {
            return $http.get("api/Medicines/GetMedicine/" + ID);
        };

        //Insert new record
        var InsertMedicine = function (DrugName, Description, DrugConcentration, QuantityPurchased, ExpiryDate) {
            return $http.post("api/Medicines/InsertMedicine",
            {
                'DrugName': DrugName,
                'Description': Description,
                'DrugConcentration': DrugConcentration,
                'QuantityPurchased': QuantityPurchased,
                'ExpiryDate': ExpiryDate
            });
        };

        //Update Medicine
        var UpdateMedicine = function (ID, DrugName, Description, DrugConcentration, QuantityInStock, PurchaseDate, ExpiryDate, Practice_ID) {
            return $http.post("api/Medicines/UpdateMedicine",
            {
                'ID': ID,
                'DrugName': DrugName,
                'Description': Description,
                'DrugConcentration': DrugConcentration,
                'QuantityPurchased': QuantityInStock,
                'PurchaseDate': PurchaseDate,
                'ExpiryDate': ExpiryDate,
                'ExpiryDate': ExpiryDate
            });
        };

        //Delete the Record
        var DeleteMedicine = function (ID) {
            return $http.post("api/Medicines/DeleteMedicine/" + ID);
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