app.controller('DashboardController', ['$scope', '$interval', 'DashboardService',
    function ($scope, $interval, DashboardService) {
        angular.element("#wrapper").show();
        
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

        $scope.GetAllPractices = function () {
            DashboardService.GetAllPractices().then(function (result) {
                $scope.Practices = result.data;
             });
        };
        $scope.GetAllPractices();

        //Load data by practice id
        $scope.GetNumPatientsByPractice = function (GetPractice_ID) {            
            DashboardService.GetNumPatientsByPractice(GetPractice_ID).then(function (result) {
                $scope.TotalNumOfVisits = result.data["TotalNumOfVisits"];
                $scope.Total = result.data["Total"];
                $scope.TotalAmountPaid = result.data["AmountPaid"];
                $scope.TotalBalanceOwing = result.data["BalanceOwing"];
                $scope.Amount = result.data["Amount"];

                google.charts.load('current', { 'packages': ['corechart'] });
                google.charts.setOnLoadCallback(drawChart);
                function drawChart() {

                    var data = google.visualization.arrayToDataTable([
                      ['Task', 'Hours per Day'],
                      ['Total Visits', $scope.TotalNumOfVisits],
                      ['Expected Income', $scope.Total],
                      ['Actual Income', $scope.TotalAmountPaid],
                      ['Balance Due', $scope.TotalBalanceOwing]
                    ]);

                    var options = {
                        title: 'My Daily Activities',
                        legend: 'none',
                        is3D: true
                    };

                    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

                    chart.draw(data, options);
                }

                function drawChart() {
                    var data_TotalNumOfVisits = google.visualization.arrayToDataTable([
                      ['Task', 'Hours per Day'],
                      ['Total Visits', $scope.TotalNumOfVisits]
                    ]);

                    var options = {
                        pieHole: 0.4,
                        left:0,top:0,
                        legend: 'none',
                        is3D: true
                    };

                    var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
                    chart.draw(data_TotalNumOfVisits, options);
                }
            });
        };

        $scope.GetRevenueSummary_Today = function (Practice_ID) {
            DashboardService.GetRevenueSummary_Today(Practice_ID).then(function (result) {
                $scope.TotalNumOfVisits_Summary = result.data["TotalNumOfVisits"];
                $scope.Total_Summary = result.data["Total"];
                $scope.TotalAmountPaid_Summary = result.data["AmountPaid"];
                $scope.TotalBalanceOwing_Summary = result.data["BalanceOwing"];
                $scope.Amount_Summary = result.data["Amount"];
            });
        };
        
        $scope.GetRevenueSummary_Week = function (Practice_ID) {
            DashboardService.GetRevenueSummary_Week(Practice_ID).then(function (result) {
                $scope.TotalNumOfVisits_Summary = result.data["TotalNumOfVisits"];
                $scope.Total_Summary = result.data["Total"];
                $scope.TotalAmountPaid_Summary = result.data["AmountPaid"];
                $scope.TotalBalanceOwing_Summary = result.data["BalanceOwing"];
                $scope.Amount_Summary = result.data["Amount"];
            });
        };

        $scope.GetRevenueSummary_Month = function (Practice_ID) {
            DashboardService.GetNumPatientsByPractice(Practice_ID).then(function (result) {
                $scope.TotalNumOfVisits_Summary = result.data["TotalNumOfVisits"];
                $scope.Total_Summary = result.data["Total"];
                $scope.TotalAmountPaid_Summary = result.data["AmountPaid"];
                $scope.TotalBalanceOwing_Summary = result.data["BalanceOwing"];
                $scope.Amount_Summary = result.data["Amount"];
            });
        };

    }]);