app.controller("PracticesController", ["$scope", "PracticesService", "$interval",
    function ($scope, PracticesService, $interval) {

        $scope.PageTitle_Practices = 'Practices';
        $scope.PageTitle_NewPractice = 'New Practices Details';

        $scope.function_btnUpdatePractice = function (ID) {
            var btnText = angular.element("#function_btnUpdatePractice").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewPractice").attr("readonly", false);
                angular.element("#function_btnUpdatePractice").html("Save");

                PracticesService.UpdatePractice(ID, $scope.Name, $scope.Phone_Number, $scope.Fax_Number, $scope.Street_Address, $scope.Suburb, $scope.City, $scope.Country, $scope.Trading_Times).success(function () {
                        GetAllPractices();
                    },function (error) {
                    console.log("Error message: " + error);
                });

            }
            else {
                angular.element(".readonly_ViewPractice").attr("readonly", true);
                angular.element(".readonly_ViewPractice").css("background-color", "transparent");
                angular.element("#function_btnUpdatePractice").html("Update");
            }
        }

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        //Select All Practices
        $scope.GetAllPractices = function () {
            PracticesService.GetAllPractices().then
            (function (result) {
                $scope.Practices = result.data;
            });            
        }
        $scope.GetAllPractices();

        //Select PracticeByID Function
        $scope.ViewPractice = function (ID) {
            alert(ID + " This is the ID in the Service");
            PracticesService.GetPracticeByID(ID).then
            (function (result) {
                alert(result["ID"] + " This is the ID in the Service");
                //$scope.Name = result[1];
                //$scope.Phone_Number = result[2];
                //$scope.Fax_Number = result[3];
            });
        }
        

        //Insert Practice Funtion
        $scope.NewPractice = function () {
            PracticesService.InsertPractice($scope.Name, $scope.Phone_Number, $scope.Fax_Number, $scope.Street_Address, $scope.Suburb, $scope.City, $scope.Country, $scope.Trading_Times).success(function () {
                    GetAllPractices();
                },
                function (error) {
                    console.log("Error message: " + error);
                });
        }

        //Delete Practice Funtion
        $scope.DeletePractice = function (ID) {
            PracticesService.DeletePractice(ID).then(function () {
                console.log("Delete Successful");
            },function (error) {
                console.log("Delete unsuccessful " + error);
            });
        }

        
    }]);