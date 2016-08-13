app.controller("PracticesController", ["$scope", "PracticesService", "$interval",
    function ($scope, PracticesService, $interval) {

        $scope.PageTitle_Practices = 'Practices';
        $scope.PageTitle_NewPractice = 'New Practices Details';

        $scope.function_btnUpdatePractice = function (ID) {
            var btnText = angular.element("#function_btnUpdatePractice").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewPractice").attr("readonly", false);
                angular.element("#function_btnUpdatePractice").html("Save");
            }
            else {
                angular.element(".readonly_ViewPractice").attr("readonly", true);
                angular.element(".readonly_ViewPractice").css("background-color", "transparent");
                angular.element("#function_btnUpdatePractice").html("Update");
            }
        };

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        $scope.GetAllPractices = function () {
            PracticesService.GetAllPractices().then
            (function (result) {
                $scope.Practices = result.data;
            });
        };
        $scope.GetAllPractices();

        

        $scope.NewPractice = function (Name, Phone_Number, Fax_Number, Street_Address, Suburb, City, Country, Trading_Times) {
            PracticesService.InsertPractice(Name, Phone_Number, Fax_Number, Street_Address, Suburb, City, Country, Trading_Times).then
            (function (result) {
                console.log(result);
            });
            console.log("data inserted" + Name + Phone_Number + Fax_Number + Street_Address + Suburb + City + Country + Trading_Times);
            //.sucess(function (data, status, headers, config) {
            //    console.log("data inserted" + data);
            //});
        };
        
    }]);