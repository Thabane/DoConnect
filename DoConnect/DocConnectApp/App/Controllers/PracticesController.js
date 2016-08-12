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

        $scope.GetAllPractices = function () {
            PracticesService.GetAllPractices().then
            (function (result) {
                $scope.Practices = result.data;
            });
        };
        $scope.GetAllPractices();

        $scope.strSort;
        $scope.limitTo = 5;

        $scope.setlimitTo = function (limit) {
            $scope.limitTo = limit;
        }
        $scope.getlimitTo = function () {
            return $scope.limitTo;
        }
        $scope.setSortKey = function (key) {
            $scope.strSort = key;
        }
        $scope.getSortKey = function () {
            return $scope.strSort;
        }        
    }]);