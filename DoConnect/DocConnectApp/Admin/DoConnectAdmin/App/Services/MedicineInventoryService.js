app.factory('MedicineInventoryService',
    ['$http',
        function ($http) {
            return GetMedicineInventory = function () {
                return $http.get("/api/GetAllMedicineInventory");
            }
        }
    ]);