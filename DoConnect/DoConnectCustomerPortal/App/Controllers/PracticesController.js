app.controller("PracticesController", ["$scope", "PracticesService", "$interval",
    function ($scope, PracticesService, $interval) {
        $scope.Practices = [];

        //View Filter's
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
        $scope.setAdminID = function (val) {
            $scope.empID = val;
        }
        $scope.getAdminID = function () {
            return $scope.empID;
        }
        //END View Filter's

        $scope.PageTitle_Practices = 'Practices';
        $scope.PageTitle_NewPractice = 'New Practices Details';

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        };

        //Select All Practices
        $scope.GetAllPractices = function () {
            PracticesService.GetAllPractices().then
            (function (result) {
                $scope.Practices = result.data;
            });
        };
        $scope.GetAllPractices();

        //Select PracticeByID Function
        $scope.ViewPractice = function (ID) {
            PracticesService.GetPracticeByID(ID).success(function (result) {
                //$(".readonly_ViewPractice").val("");
                $scope.ID = result["ID"];
                $scope.Name = result["Name"];
                $scope.Phone_Number = result["Phone_Number"];
                $scope.Fax_Number = result["Fax_Number"];
                $scope.Street_Address = result["Street_Address"];
                $scope.Suburb = result["Suburb"];
                $scope.City = result["City"];
                $scope.Country = result["Country"];
                $scope.Trading_Times = result["Trading_Times"];
            });
        };
    }]);