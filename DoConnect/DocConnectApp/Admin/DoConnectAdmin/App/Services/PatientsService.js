app.factory('PatientsService',
    ['$http',
        function ($http) {
            var GetAllPatients = function () {
                return  $http.get("api/Patients/GetAllPatients");
            }
            return { GetAllPatients: GetAllPatients }

            var GetPatient = function (ID) {
                return $http.get("api/Patients/GetPatient?ID"+ID);
            }
            return { GetPatient: GetPatient }

            //Insert New Patient
            var InsertPatient = function (FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID) {
                $http.post("api/Patients/InsertPatient",
                {
                    'FirstName': FirstName, 
                    'LastName': LastName, 
                    'ID_Number': ID_Number, 
                    'Gender': Gender, 
                    'DOB': DOB, 
                    'Cell_Number': Cell_Number, 
                    'Street_Address': Street_Address, 
                    'Suburb': Suburb, 
                    'City': City,
                    'Country': Country,
                    'Allergies': Allergies, 
                    'PreviousIllnesses': PreviousIllnesses,
                    'PreviousMedication': PreviousMedication,
                    'RiskFactors': RiskFactors,
                    'SocialHistory': SocialHistory,
                    'FamilyHistory': FamilyHistory,
                    'Medical_Aid_ID': Medical_Aid_ID,
                    'Doctor_ID': Doctor_ID,
                    'User_ID': User_ID
                });
            }
            return { InsertPatient: InsertPatient}
        }
    ]);


