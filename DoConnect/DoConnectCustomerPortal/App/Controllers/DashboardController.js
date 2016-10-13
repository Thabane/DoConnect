app.controller('DashboardController',['$scope', '$interval', 'DashboardService',
    function ($scope, $interval, DashboardService) {

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
        //
        //    var options = {
        //        title: 'Appointment Stats',
        //        is3D: true,
        //    };
        //
        //    var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
        //    chart.draw(data, options);
        //}
    }]);