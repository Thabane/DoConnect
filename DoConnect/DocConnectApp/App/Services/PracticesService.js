app.factory('PracticesService',
    ['$http',
        function ($http) {

            var GetAllPractices = function () {
                return $http.get("api/Practices/GetAllPractices");
            }
            return { GetAllPractices: GetAllPractices }

            //Select Single Practice
            var GetPractice = function (ID) {
                var response = $http({
                    method: "post",
                    url: "api/Practices/GetPractice",
                    params: { ID: JSON.stringify(ID) }
                });
                return response;
            }
            

            /*var GetPractice = function (ID) {
                return $http.get("api/Practices/GetPractice" + ID);
            }
            return { GetPractice: GetPractice }*/

            //Insert New Practice
            var InsertPractice = function (Name, Phone_Number, Fax_Number, Street_Address, Suburb, City, Country, Trading_Times) {
                $http.Post("api/Practices/InsertPractice",
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
        }
    ]);