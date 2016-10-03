app.controller('DashboardController', ['$scope', '$interval', 'DashboardService', "$cookies", "$cookieStore",
    function ($scope, $interval, DashboardService, $cookies, $cookieStore) {
        angular.element("#wrapper").show();
        //google.charts.load("current", { packages: ["corechart"] });
        //google.charts.setOnLoadCallback(drawChart); 
        //function drawChart() {
        //    var data = google.visualization.arrayToDataTable([
        //      ['Appointment Stats', 'Number Of Patients'],
        //      ['Arrived', 11],
        //      ['Cancelled', 2],
        //      ['No Show', 2],
        //      ['Pre-Scheduled', 2]
        //    ]);

        //    var options = {
        //        title: 'Appointment Stats',
        //        is3D: true,
        //    };

        //    var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
        //    chart.draw(data, options);
        //} 

        $scope.SessionData = function () {
            DashboardService.SessionData().success(function (result) {
                $scope.SessionData_User_ID = result["User_ID"];
                $scope.SessionData_FirstName = result["FirstName"];
                $scope.SessionData_LastName = result["LastName"];
                $scope.SessionData_Email = result["Email"];
                $scope.SessionData_Practice_ID = result["Practice_ID"];
                $scope.SessionData_AccessLevel = result["AccessLevel"];


            });
        };
        $scope.SessionData();
    }]);