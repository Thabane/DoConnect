app.controller("EmployeesController", ["$scope", "EmployeesService", "$interval",
    function ($scope, EmployeesService, $interval) {
    
        var init_ControlSettings = function () {
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
            angular.element(".readonly").css("font-size", "13px");
            angular.element(".readonly").css("padding-right", "0px");
            angular.element("#myFunctionEmployees_Edit").show(); angular.element("#myFunctionEmployees_Save").hide();
        };
        init_ControlSettings();

        $scope.myFunctionEmployees_Edit = function () {
            angular.element("#myFunctionEmployees_Edit").hide(); angular.element("#myFunctionEmployees_Save").show();
            angular.element(".readonly").attr("readonly", false);
            angular.element(".readonly").css("border", "1px solid #ccc");
        };

        $scope.myFunctionEmployees_Save = function () {
            angular.element("#myFunctionEmployees_Edit").show(); angular.element("#myFunctionEmployees_Save").hide();
            angular.element(".readonly").attr("readonly", true);
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
        };

        $scope.function_btnUpdateEmployee = function () {
            var btnText = angular.element("#function_btnUpdateEmployee").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewEmployee").attr("readonly", false);
                angular.element("#function_btnUpdateEmployee").html("Save");
            }
            else {
                angular.element(".readonly_ViewEmployee").attr("readonly", true);
                angular.element(".readonly_ViewEmployee").css("background-color", "transparent");
                angular.element("#function_btnUpdateEmployee").html("Update");
            }
        };
    }]);