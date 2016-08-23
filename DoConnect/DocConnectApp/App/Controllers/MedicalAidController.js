app.controller("MedicalAidController", ["$scope", "MedicalAidService", "$interval",
    function ($scope, MedicalAidService, $interval) {

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        //Select All Practices
        $scope.GetAllMedicalAids = function () {
            MedicalAidService.GetAllMedicalAids().then
            (function (result) {
                $scope.MedicalAids = result.data;
            });
        };
        $scope.GetAllMedicalAids();

        //Select MedicalAidByID Function
        $scope.ViewMedicalAid = function (ID) {
            MedicalAidService.GetMedicalAidByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.Name = result["Name"];
                $scope.Cell_Number = result["Cell_Number"];
                $scope.Fax_Number = result["Fax_Number"];
                $scope.Email_Address = result["Email_Address"];
                $scope.Address = result["Address"];
            });
        };

        //Insert MedicalAid Funtion
        $scope.NewMedicalAid = function (Name, Cell_Number, Fax_Number, Email_Address, Address) {
            MedicalAidService.InsertMedicalAid(Name, Cell_Number, Fax_Number, Email_Address, Address).success(function () {
                $scope.GetAllMedicalAids();
                angular.element(".insert").val('');
                btnSuccess("MedicalAid successfully inserted.");
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };

        //Update MedicalAid Funtion
        $scope.function_btnUpdateMedicalAid = function () {
            var btnText = angular.element("#function_btnUpdateMedicalAid").html();
            if (btnText == "Update") {
                angular.element(".readonly_View").attr("readonly", false);
                angular.element("#function_btnUpdateMedicalAid").html("Save");
            }
            else {
                MedicalAidService.UpdateMedicalAid($scope.ID, $scope.Name, $scope.Cell_Number, $scope.Fax_Number, $scope.Email_Address, $scope.Address).success(function () {
                    $scope.GetAllMedicalAids();
                    btnSuccess("MedicalAid details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".readonly_View").attr("readonly", true);
                angular.element("#function_btnUpdateMedicalAid").html("Update");
            }
        };

        //Delete MedicalAid Funtion
        $scope.DeleteMedicalAid = function () {
            MedicalAidService.DeleteMedicalAid($scope.ID).then(function () {
                $scope.GetAllMedicalAids();
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });          
        };
    }]);