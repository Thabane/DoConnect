app.controller("PatientsController", ["$scope", "PatientService", "$interval",
    function ($scope, PatientService, $interval) {
        $scope.firstName;
        $scope.lastName;
        $scope.id_Number;
        $scope.gender;
        $scope.dob;
        $scope.cell_number;
        $scope.street_address;
        $scope.suburb;
        $scope.city;
        $scope.country;

        $scope.InsertPatient = function (firstName, lastName, id_Number, gender, dob, cell_number, street_address, suburb, city, country) {
            var dobControl = document.getElementById("dob");
            dobValue = dobControl.value;
            
            PatientService.InsertPatient(firstName, lastName, id_Number, gender, dob, cell_number, street_address, suburb, city, country).then
            (function (result) {
                console.log(result);
            });
        };        

        $scope.status;//"Active";
        //Function Calls
        //$interval($scope.GetStuff, 300000);
    }]);