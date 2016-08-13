app.controller("MedicalAidController", ["$scope", "MedicalAidService", "$interval",
    function ($scope, MedicalAidService, $interval) {
                
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

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }
    }]);