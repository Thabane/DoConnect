app.controller("MedicalAidController", ["$scope", "MedicalAidService", "$interval", "$ngBootbox",
    function ($scope, MedicalAidService, $interval, $ngBootbox) {

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        $scope.GetAllMedicalAids = function () {
            MedicalAidService.GetAllMedicalAids().then
            (function (result) {
                $scope.MedicalAids = result.data;
            });
        };
        $scope.GetAllMedicalAids();

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

        $scope.NewMedicalAid = function (Name, Cell_Number, Fax_Number, Email_Address, Address) {
            MedicalAidService.InsertMedicalAid(Name, Cell_Number, Fax_Number, Email_Address, Address).success(function () {
                $scope.GetAllMedicalAids();
                angular.element(".insert").val('');
                btnSuccess("Medical Aid details successfully inserted.");
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };

        $scope.function_btnUpdateMedicalAid = function () {
            var btnText = angular.element("#function_btnUpdateMedicalAid").html();
            if (btnText == "Update") {
                angular.element(".readonly_View").attr("readonly", false);
                angular.element("#function_btnUpdateMedicalAid").html("Save");
            }
            else {
                MedicalAidService.UpdateMedicalAid($scope.ID, $scope.Name, $scope.Cell_Number, $scope.Fax_Number, $scope.Email_Address, $scope.Address).success(function () {
                    $scope.GetAllMedicalAids();
                    btnSuccess("Medical Aid details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".readonly_View").attr("readonly", true);
                angular.element(".readonly_View").css("background-color", "transparent");
                angular.element("#function_btnUpdateMedicalAid").html("Update");
            }
        };

        $scope.DeleteMedicalAid1 = function (ID, Name) {
            $ngBootbox.confirm("Are you sure you want to delete this Medical Aid: " + Name + " ?").then(function () {
                MedicalAidService.DeleteMedicalAid(ID).then(function () {
                    $scope.GetAllMedicalAids();
                    btnSuccess("Medical Aid record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
        $scope.DeleteMedicalAid2 = function () {
            $ngBootbox.confirm("Are you sure you want to delete this Medical Aid: " + $scope.Name + " ?").then(function () {
                MedicalAidService.DeleteMedicalAid($scope.ID).then(function () {
                    $scope.GetAllMedicalAids();
                    angular.element("#CloseModel").trigger("click");
                    btnSuccess("Medical Aid record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
    }]);