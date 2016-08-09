app.controller("MedicalAidController", ["$scope", "MedicalAidService", "$interval",
    function ($scope, MedicalAidService, $interval) {

        var init_ControlSettings = function () {
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
            angular.element(".readonly").css("font-size", "13px");
            angular.element(".readonly").css("padding-right", "0px");
            angular.element(".readonly_View").css("background-color", "transparent");
            angular.element(".readonly_View").attr("readonly", true);
            angular.element("#myFunctionMedicalAid_Edit").show(); angular.element("#myFunctionMedicalAid_Save").hide();
        };
        init_ControlSettings();

        $scope.myFunctionMedicalAid_Edit = function () {
            angular.element("#myFunctionMedicalAid_Edit").hide(); angular.element("#myFunctionMedicalAid_Save").show();
            angular.element(".readonly").attr("readonly", false);
            angular.element(".readonly").css("border", "1px solid #ccc");
        };

        $scope.myFunctionMedicalAid_Save = function () {
            angular.element("#myFunctionMedicalAid_Edit").show(); angular.element("#myFunctionMedicalAid_Save").hide();
            angular.element(".readonly").attr("readonly", true);
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
        };

        $scope.function_btnUpdateMedicalAid = function () {
            var btnText = angular.element("#function_btnUpdateMedicalAid").html();
            if (btnText == "Update") {
                angular.element(".readonly_View").attr("readonly", false);
                angular.element("#function_btnUpdateMedicalAid").html("Save");
            }
            else {
                angular.element(".readonly_View").attr("readonly", true);
                angular.element("#function_btnUpdateMedicalAid").html("Update");
            }
        };
    }]);