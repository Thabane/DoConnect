app.factory('PracticesService',
    function ($http) {

        var GetAllPractices = function () {
            return $http.get("api/Practices/GetAllPractices");
        };

        var GetPracticeByID = function (ID) {
            return $http.get("api/Practices/GetPractice/" + ID);
        };

        var InsertPractice = function (Name, Phone_Number, Fax_Number, Street_Address, Suburb, City, Country, Trading_Times) {
            return $http.post("api/Practices/InsertPractice",
            {
                'Name': Name,
                'Phone_Number': Phone_Number,
                'Fax_Number': Fax_Number,
                'Street_Address': Street_Address,
                'Suburb': Suburb,
                'City': City,
                'Country': Country,
                'Trading_Times': Trading_Times
            });
        };

        var UpdatePractice = function (ID, Name, Phone_Number, Fax_Number, Street_Address, Suburb, City, Country, Trading_Times) {
            return $http.post("api/Practices/UpdatePractice",
            {
                'ID': ID,
                'Name': Name,
                'Phone_Number': Phone_Number,
                'Fax_Number': Fax_Number,
                'Street_Address': Street_Address,
                'Suburb': Suburb,
                'City': City,
                'Country': Country,
                'Trading_Times': Trading_Times
            });
        };

        var DeletePractice = function (ID) {
            return $http.post("api/Practices/DeletePractice/" + ID);
        };

        return {
            GetAllPractices: GetAllPractices,
            GetPracticeByID: GetPracticeByID,
            InsertPractice: InsertPractice,
            UpdatePractice: UpdatePractice,
            DeletePractice: DeletePractice
        };
    }
);