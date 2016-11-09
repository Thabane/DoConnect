app.factory('AccountService',
    function ($http) {

        //Select all MedicalAid data
        var GetAllMedicalAid = function () {
            return $http.get("api/MedicalAids/GetAllMedicalAids");
        };

        //Select MedicalAid by ID
        var GetMedicalAidByID = function (ID) {
            return $http.get("api/MedicalAids/GetMedicalAid/" + ID);
        };

        //Insert new record
        var InsertMedicalAid = function (Name, Cell_Number, Fax_Number, Email_Address, Address) {
            return $http.post("api/MedicalAids/InsertMedicalAid",
            {
                'Name': Name,
                'Cell_Number': Cell_Number,
                'Fax_Number': Fax_Number,
                'Fax_Number': Fax_Number,
                'Email_Address': Email_Address,
                'Address': Address
            });
        };

        //Update MedicalAid
        var UpdateMedicalAid = function (ID, Name, Cell_Number, Fax_Number, Email_Address, Address) {
            return $http.post("api/MedicalAids/UpdateMedicalAid",
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

        //Delete the Record
        var DeleteMedicalAid = function (ID) {
            return $http.post("api/MedicalAids/DeleteMedicalAid/" + ID);
        };

        return {
            GetAllMedicalAids: GetAllMedicalAids,
            GetMedicalAidByID: GetMedicalAidByID,
            InsertMedicalAid: InsertMedicalAid,
            UpdateMedicalAid: UpdateMedicalAid,
            DeleteMedicalAid: DeleteMedicalAid
        };
    }
);