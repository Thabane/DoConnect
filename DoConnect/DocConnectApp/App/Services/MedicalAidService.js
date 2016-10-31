app.factory('MedicalAidService',
['$http',
    function ($http) {

        var GetAllMedicalAids = function () {
            return $http.get("api/MedicalAid/GetAllMedicalAids");
        };

        var GetMedicalAidByID = function (ID) {
            return $http.get("api/MedicalAid/GetMedicalAid/" + ID);
        };

        var InsertMedicalAid = function (Name, Cell_Number, Fax_Number, Email_Address, Address) {
            return $http.post("api/MedicalAid/InsertMedicalAid",
            {
                'Name': Name,
                'Cell_Number': Cell_Number,
                'Fax_Number': Fax_Number,
                'Fax_Number': Fax_Number,
                'Email_Address': Email_Address,
                'Address': Address
            });
        };

        var UpdateMedicalAid = function (ID, Name, Cell_Number, Fax_Number, Email_Address, Address) {
            return $http.post("api/MedicalAid/UpdateMedicalAid",
            {
                'ID': ID,
                'Name': Name,
                'Cell_Number': Cell_Number,
                'Fax_Number': Fax_Number,
                'Fax_Number': Fax_Number,
                'Email_Address': Email_Address,
                'Address': Address
            });
        };

        var DeleteMedicalAid = function (ID) {
            return $http.post("api/MedicalAid/DeleteMedicalAid/" + ID);
        };

        return {
            GetAllMedicalAids: GetAllMedicalAids,
            GetMedicalAidByID: GetMedicalAidByID,
            InsertMedicalAid: InsertMedicalAid,
            UpdateMedicalAid: UpdateMedicalAid,
            DeleteMedicalAid: DeleteMedicalAid
        };
    }
]);