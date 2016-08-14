app.factory('PracticesService',
    ['$http',
        function ($http) {

            //Select all Practice data
            var GetAllPractices = function () {
                return $http.get("api/Practices/GetAllPractices");
            }
            return { GetAllPractices: GetAllPractices }
                                    
            //Select Practice by ID
            var GetPracticeByID = function (ID) { /*I don't think this link is working*/
                return $http.get("api/Practices/GetPractice/" + ID);
            }
            return { GetPracticeByID: GetPracticeByID }

            //Update Practice
            var UpdatePractice = function (ID, Name, Phone_Number, Fax_Number, Street_Address, Suburb, City, Country, Trading_Times) {
                return $http.post("api/Practices/UpdatePractice",
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
            }
            return { UpdatePractice: UpdatePractice }

            //Insert new record
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
            }
            return { InsertPractice: InsertPractice }            

            //Delete the Record
            var DeletePractice = function (ID) {
                return $http.post("api/Practices/DeletePractice/" + ID);
            }
            return { DeletePractice: DeletePractice }

        }
    ]);