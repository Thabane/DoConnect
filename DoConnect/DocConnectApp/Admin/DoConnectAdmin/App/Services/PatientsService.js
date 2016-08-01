app.factory('PatientService',
    ['$http',
        function ($http) {
            var InsertPatient = function (firstName, lastName, id_Number, gender, dob, cell_number, street_address, suburb, city, country) {//GetPatients must be the same as the method name in the controller
                $http.Post("api/Patients/InsertPatient",
                {
                    "FirstName": firstName,
                    "LastName": lastName,
                    "ID_Number": id_Number,
                    "Gender": gender,
                    "DOB": dob,
                    "Cell_Number": cell_number,
                    "Street_address": street_address,
                    "Suburb": suburb,
                    "City": city,
                    "Country": country
                });
            }
            return {
                InsertPatient : InsertPatient
            }
        }
    ]);