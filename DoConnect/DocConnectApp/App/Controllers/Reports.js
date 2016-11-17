app.controller("ReportsController", ["$scope", "ReportsService", "$interval", "$filter",
    function ($scope, ReportsService, $interval, $filter) {

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        $scope.GetAllPractices = function () {
            ReportsService.GetAllPractices().then(function (result) { 
                $scope.Practices = [];                
                for (var i = 0; i < (result.data.length + 1); i++) {                    
                    if (i == result.data.length) {                        
                        $scope.Practices.push({ "Name": "All Practices", "ID": "0" });
                    }
                    else {
                        $scope.Practices.push({ "Name": result.data[i]["Name"], "ID": result.data[i]["ID"] });
                    }
                }
                ReportsService.GetAllPatients().then(function (result) {
                    $scope.DisplayPatientsData(result);
                    $scope.DonutChart_PatientsGender(result);
                });
                ReportsService.FinancialReport_All("2000-01-01", "2050-01-01").then(function (result) {
                    $scope.DisplayFinancialReportData(result);
                    $scope.FinancialReportGraphs(result);
                    $scope.Finance_Practice_Name = "All Practices";
                });
            });
        };
        $scope.GetAllPractices();

        $scope.Practice_ID = 0;
        $scope.changedValueGetPractice_ID = function (item) {
            $scope.Practice_ID = item.ID;
            $scope.Practice_Name = item.Name;

            if ($scope.Practice_ID == "0") {
                ReportsService.GetAllPatients().then(function (result) {
                    $scope.DisplayPatientsData(result);
                    $scope.DonutChart_PatientsGender(result);
                });
            }
            else{ 
                ReportsService.GetAllPatientsByPracticeID($scope.Practice_ID).then(function (result) {
                    $scope.DisplayPatientsData(result);
                    $scope.DonutChart_PatientsGender(result);                    
                });
            }
        };
        
        $scope.DisplayPatientsData = function (result) {
            var rowCount = 0;
            var num_TotalPatients = 0;
            var num_TotalPatientsPerGroup = 0;

            var Date = result.data[0]["RegistrationDate"].split('-');
            var Year_Month = Date[0] + "-" + Date[1];
            var strControl = Year_Month;

            $scope.Patients = [];
            $scope.Summary = [];
            var PrintSummary = 'false';

            for (var i = 0; i < result.data.length; i++) {
                Date = result.data[i]["RegistrationDate"].split('-');
                Year_Month = Date[0] + "-" + Date[1];

                if (strControl == Year_Month) {
                    $scope.Patients.push({ "FirstName": result.data[i]["FirstName"], "LastName": result.data[i]["LastName"], "Email": result.data[i]["Email"], "Cell_Number": result.data[i]["Cell_Number"], "RegistrationDate": result.data[i]["RegistrationDate"], "PrintSummary": "false" });
                    num_TotalPatients++; num_TotalPatientsPerGroup++;

                }
                else {
                    Date = result.data[i]["RegistrationDate"].split('-');
                    Year_Month = Date[0] + "-" + Date[1];
                    strControl = Year_Month;
                    $scope.Summary = [];
                    $scope.Patients.push({ "num_TotalPatientsPerGroup": num_TotalPatientsPerGroup, "Year_Month": Year_Month, "PrintSummary": "true" });

                    num_TotalPatientsPerGroup = 0;
                    i--;
                }

            }
            $scope.Patients.push({ "num_TotalPatientsPerGroup": num_TotalPatientsPerGroup, "Year_Month": Year_Month, "PrintSummary": "Groupfooter" });
            $scope.Patients.push({ "num_TotalPatients": num_TotalPatients, "Year_Month": Year_Month, "PrintSummary": "footer" });
        };

        //Donut Chart - Patients Gender
        $scope.DonutChart_PatientsGender = function (result) {
            $scope.num_Male = 0; $scope.num_Female = 0; $scope.Suggestion = "";
            
            for (var i = 0; i < result.data.length; i++) {
                if (result.data[i]["Gender"] === 'M')
                { $scope.num_Male++; }
                else { $scope.num_Female++; }
            }
            
            if ($scope.num_Male > $scope.num_Female)
                { $scope.Suggestion = "Female"; }
            else { $scope.Suggestion = "Male"; }
            
            $scope.DOB_Array = []; $scope.Age_Array = [];
            for (var i = 0; i < result.data.length; i++) {
                $scope.DOB_Array.push(result.data[i]["DOB"]);
            }

            $scope.$watch('DOB_Array', function () {
                $scope.DOB_Array.sort();
            }, true);

            $scope.AgeCount_0_9 = 0;
            $scope.AgeCount_10_19 = 0;
            $scope.AgeCount_20_29 = 0;
            $scope.AgeCount_30_39 = 0;
            $scope.AgeCount_40_49 = 0;
            $scope.AgeCount_50_59 = 0;
            $scope.AgeCount_60_69 = 0;
            $scope.AgeCount_Above = 0;
            var Date = 0; var Year = 0; var Age;
           
            for (var i = 0; i < $scope.DOB_Array.length; i++) {
                Date = $scope.DOB_Array[i].split('-');
                Year = Date[0];
                Age = (2016 - Year);
                $scope.Age_Array.push(Age); 
            }

            $scope.$watch('Age_Array', function () {
                $scope.Age_Array.sort();
            }, true);

            for (var i = 0; i < $scope.Age_Array.length; i++) {
                if (($scope.Age_Array[i] >= 0) && ($scope.Age_Array[i] <= 9)) {
                    $scope.AgeCount_0_9++;
                }
                else if (($scope.Age_Array[i] >= 10) && ($scope.Age_Array[i] <= 19)) {
                    $scope.AgeCount_10_19++;
                }
                else if (($scope.Age_Array[i] >= 20) && ($scope.Age_Array[i] <= 29)) {
                    $scope.AgeCount_20_29++;
                }
                else if (($scope.Age_Array[i] >= 30) && ($scope.Age_Array[i] <= 39)) {
                    $scope.AgeCount_30_39++;
                }
                else if (($scope.Age_Array[i] >= 40) && ($scope.Age_Array[i] <= 49)) {
                    $scope.AgeCount_40_49++;
                }
                else if (($scope.Age_Array[i] >= 50) && ($scope.Age_Array[i] <= 59)) {
                    $scope.AgeCount_50_59++;
                }
                else if (($scope.Age_Array[i] >= 60) && ($scope.Age_Array[i] <= 69)) {
                    $scope.AgeCount_60_69++;
                }
                else if ($scope.Age_Array[i] >= 70) {
                    $scope.AgeCount_Above++;
                }
            }

            google.charts.load("current", { packages: ["corechart"] });
            google.charts.setOnLoadCallback(drawChart);
            function drawChart() {
                
                var data_Age = google.visualization.arrayToDataTable([
                  ['Age group', 'Number'],
                  ['Male', $scope.num_Male],
                  ['Female', $scope.num_Female]
                ]);

                var options_Age = {
                    is3D: true, width: 500, height: 300
                };

                var chart_Age = new google.visualization.PieChart(document.getElementById('donutchart_Gender'));
                chart_Age.draw(data_Age, options_Age);

                var data = google.visualization.arrayToDataTable([
                  ['Year Range', 'Number'],
                  ['0 - 9 years',   $scope.AgeCount_0_9],
                  ['10 - 19 years', $scope.AgeCount_10_19],
                  ['20 - 29 years', $scope.AgeCount_20_29],
                  ['30 - 39 years', $scope.AgeCount_30_39],
                  ['40 - 49 years', $scope.AgeCount_40_49],
                  ['50 - 59 years', $scope.AgeCount_50_59],
                  ['60 - 69 years', $scope.AgeCount_60_69],
                  ['70 years and older', $scope.AgeCount_Above],
                ]);

                var options = {
                    pieHole: 0.5, width: 500, height: 300
                };

                var chart = new google.visualization.PieChart(document.getElementById('donutchart_Age'));
                chart.draw(data, options);
            }
        };        
        
        $scope.Finance_Practice_ID = 0;
        $scope.Finance_changedValueGetPractice_ID = function (item) {
            $scope.Finance_Practice_ID = item.ID;
            $scope.Finance_Practice_Name = item.Name;

            if ((angular.element("#DateStart").val() != "undefined") && (angular.element("#DateEnd").val() != "undefined")) {
                if ($scope.Finance_Practice_ID == "0") {
                    ReportsService.FinancialReport_All(angular.element("#DateStart").val(), angular.element("#DateEnd").val()).then(function (result) {
                        $scope.DisplayFinancialReportData(result);
                        $scope.FinancialReportGraphs(result);
                    });
                }
                else {
                    ReportsService.FinancialReportByPracticeID($scope.Finance_Practice_ID, angular.element("#DateStart").val(), angular.element("#DateEnd").val()).then(function (result) {
                        $scope.DisplayFinancialReportData(result);
                        $scope.FinancialReportGraphs(result);
                    });
                }
            }           
        };

        var myDate = new Date();

        $scope.year_0 = $filter('date')(myDate, 'yyyy');
        $scope.month_0 = $scope.year_0 + "-" + $filter('date')(myDate, 'MM'); $scope.Total_month_0 = 0; $scope.AmountPaid_month_0 = 0; $scope.BalanceOwing_month_0 = 0;

        var month_1 = new Date(myDate);
        month_1.setMonth(myDate.getMonth() - 1);
        $scope.month_1 = $scope.year_0 + "-" + $filter('date')(month_1, 'MM'); $scope.Total_month_1 = 0; $scope.AmountPaid_month_1 = 0; $scope.BalanceOwing_month_1 = 0;

        var month_2 = new Date(myDate);
        month_2.setMonth(myDate.getMonth() - 2);
        $scope.month_2 = $scope.year_0 + "-" + $filter('date')(month_2, 'MM'); $scope.Total_month_2 = 0; $scope.AmountPaid_month_2 = 0; $scope.BalanceOwing_month_2 = 0;

        var month_3 = new Date(myDate);
        month_3.setMonth(myDate.getMonth() - 3);
        $scope.month_3 = $scope.year_0 + "-" + $filter('date')(month_3, 'MM'); $scope.Total_month_3 = 0; $scope.AmountPaid_month_3 = 0; $scope.BalanceOwing_month_3 = 0;

        var month_4 = new Date(myDate);
        month_4.setMonth(myDate.getMonth() - 4);
        $scope.month_4 = $scope.year_0 + "-" + $filter('date')(month_4, 'MM'); $scope.Total_month_4 = 0; $scope.AmountPaid_month_4 = 0; $scope.BalanceOwing_month_4 = 0;

        var month_5 = new Date(myDate);
        month_5.setMonth(myDate.getMonth() - 5);
        $scope.month_5 = $scope.year_0 + "-" + $filter('date')(month_5, 'MM'); $scope.Total_month_5 = 0; $scope.AmountPaid_month_5 = 0; $scope.BalanceOwing_month_5 = 0;
        
        $scope.DisplayFinancialReportData = function (result) {
            var num_Consultations = 0; var num_ConsultationsPerGroup = 0;
            $scope.Total = 0; $scope.AmountPaid = 0; $scope.BalanceOwing = 0;
            $scope.Total_Footer = 0; $scope.AmountPaid_Footer = 0; $scope.BalanceOwing_Footer = 0;

            var Date = result.data[0]["Date"].split('-');
            var Year_Month = Date[0] + "-" + Date[1];
            var strControl = Year_Month;

            $scope.FinancialReportData = [];
            $scope.Summary = [];
            var PrintSummary = 'false';            

            for (var i = 0; i < result.data.length; i++) {
                Date = result.data[i]["Date"].split('-');
                Year_Month = Date[0] + "-" + Date[1];

                if (strControl == Year_Month) {
                    $scope.FinancialReportData.push({ "PatientFullName": result.data[i]["PatientFullName"], "Email": result.data[i]["Email"], "Date": result.data[i]["Date"], "Diagnosis": result.data[i]["Diagnosis"], "Total": result.data[i]["Total"], "AmountPaid": result.data[i]["AmountPaid"], "BalanceOwing": result.data[i]["BalanceOwing"], "PrintSummary": "false" });
                    num_Consultations++; num_ConsultationsPerGroup++;
                    $scope.Total = +result.data[i]["Total"]; $scope.AmountPaid = +result.data[i]["AmountPaid"]; $scope.BalanceOwing = +result.data[i]["BalanceOwing"];
                    $scope.Total_Footer = ($scope.Total_Footer + result.data[i]["Total"]); $scope.AmountPaid_Footer = ($scope.AmountPaid_Footer + result.data[i]["AmountPaid"]); $scope.BalanceOwing_Footer = ($scope.BalanceOwing_Footer + result.data[i]["BalanceOwing"]);

                    if (Year_Month == $scope.month_0) {
                        $scope.Total_month_0 = $scope.Total_month_0 + result.data[i]["Total"]; $scope.AmountPaid_month_0 = $scope.AmountPaid_month_0 + result.data[i]["AmountPaid"]; $scope.BalanceOwing_month_0 = $scope.BalanceOwing_month_0 + result.data[i]["BalanceOwing"];
                    }
                    else if (Year_Month == $scope.month_1) {
                        $scope.Total_month_1 = $scope.Total_month_1 + result.data[i]["Total"]; $scope.AmountPaid_month_1 = $scope.AmountPaid_month_1 + result.data[i]["AmountPaid"]; $scope.BalanceOwing_month_1 = $scope.BalanceOwing_month_1 + result.data[i]["BalanceOwing"];
                    }
                    else if (Year_Month == $scope.month_2) {
                        $scope.Total_month_2 = $scope.Total_month_2 + result.data[i]["Total"]; $scope.AmountPaid_month_2 = $scope.AmountPaid_month_2 + result.data[i]["AmountPaid"]; $scope.BalanceOwing_month_2 = $scope.BalanceOwing_month_2 + result.data[i]["BalanceOwing"];
                    }
                    else if (Year_Month == $scope.month_3) {
                        $scope.Total_month_3 = $scope.Total_month_3 + result.data[i]["Total"]; $scope.AmountPaid_month_3 = $scope.AmountPaid_month_3 + result.data[i]["AmountPaid"]; $scope.BalanceOwing_month_3 = $scope.BalanceOwing_month_3 + result.data[i]["BalanceOwing"];
                    }
                    else if (Year_Month == $scope.month_4) {
                        $scope.Total_month_4 = $scope.Total_month_4 + result.data[i]["Total"]; $scope.AmountPaid_month_4 = $scope.AmountPaid_month_4 + result.data[i]["AmountPaid"]; $scope.BalanceOwing_month_4 = $scope.BalanceOwing_month_4 + result.data[i]["BalanceOwing"];
                    }
                    else if (Year_Month == $scope.month_5) {
                        $scope.Total_month_5 = $scope.Total_month_5 + result.data[i]["Total"]; $scope.AmountPaid_month_5 = $scope.AmountPaid_month_5 + result.data[i]["AmountPaid"]; $scope.BalanceOwing_month_5 = $scope.BalanceOwing_month_5 + result.data[i]["BalanceOwing"];
                    }

                }
                else {
                    Date = result.data[i]["Date"].split('-');
                    Year_Month = Date[0] + "-" + Date[1];
                    strControl = Year_Month;
                    i--;
                    $scope.Summary.push({ "num_ConsultationsPerGroup": num_ConsultationsPerGroup, "Total": $scope.Total, "AmountPaid": $scope.AmountPaid, "BalanceOwing": $scope.BalanceOwing, "PrintSummary": "true" });
                    num_ConsultationsPerGroup = 0; $scope.Total = 0; $scope.AmountPaid = 0; $scope.BalanceOwing = 0;
                    
                }
            }
            //$scope.FinancialReportData.push({ "num_ConsultationsPerGroup": num_ConsultationsPerGroup, "Total": $scope.Total, "AmountPaid": $scope.AmountPaid, "BalanceOwing": $scope.BalanceOwing, "PrintSummary": "Groupfooter" });
            //$scope.FinancialReportData.push({ "num_ConsultationsPerGroup": num_ConsultationsPerGroup, "Total": $scope.Total, "AmountPaid": $scope.AmountPaid, "BalanceOwing": $scope.BalanceOwing, "PrintSummary": "footer" });
        };

        //FinancialReport Graphs
        $scope.FinancialReportGraphs = function (result) {
            $scope.num_Male = 0; $scope.num_Female = 0; $scope.Suggestion = "";

            for (var i = 0; i < result.data.length; i++) {
                if (result.data[i]["Gender"] === 'M')
                { $scope.num_Male++; }
                else { $scope.num_Female++; }
            }

            if ($scope.num_Male > $scope.num_Female)
            { $scope.Suggestion = "Female"; }
            else { $scope.Suggestion = "Male"; }

            $scope.DOB_Array = []; $scope.Age_Array = [];
            for (var i = 0; i < result.data.length; i++) {
                $scope.DOB_Array.push(result.data[i]["DOB"]);
            }

            $scope.$watch('DOB_Array', function () {
                $scope.DOB_Array.sort();
            }, true);

            $scope.AgeCount_0_9 = 0;
            $scope.AgeCount_10_19 = 0;
            $scope.AgeCount_20_29 = 0;
            $scope.AgeCount_30_39 = 0;
            $scope.AgeCount_40_49 = 0;
            $scope.AgeCount_50_59 = 0;
            $scope.AgeCount_60_69 = 0;
            $scope.AgeCount_Above = 0;
            var Date = 0; var Year = 0; var Age;

            for (var i = 0; i < $scope.DOB_Array.length; i++) {
                Date = $scope.DOB_Array[i].split('-');
                Year = Date[0];
                Age = (2016 - Year);
                $scope.Age_Array.push(Age);
            }

            $scope.$watch('Age_Array', function () {
                $scope.Age_Array.sort();
            }, true);

            for (var i = 0; i < $scope.Age_Array.length; i++) {
                if (($scope.Age_Array[i] >= 0) && ($scope.Age_Array[i] <= 9)) {
                    $scope.AgeCount_0_9++;
                }
                else if (($scope.Age_Array[i] >= 10) && ($scope.Age_Array[i] <= 19)) {
                    $scope.AgeCount_10_19++;
                }
                else if (($scope.Age_Array[i] >= 20) && ($scope.Age_Array[i] <= 29)) {
                    $scope.AgeCount_20_29++;
                }
                else if (($scope.Age_Array[i] >= 30) && ($scope.Age_Array[i] <= 39)) {
                    $scope.AgeCount_30_39++;
                }
                else if (($scope.Age_Array[i] >= 40) && ($scope.Age_Array[i] <= 49)) {
                    $scope.AgeCount_40_49++;
                }
                else if (($scope.Age_Array[i] >= 50) && ($scope.Age_Array[i] <= 59)) {
                    $scope.AgeCount_50_59++;
                }
                else if (($scope.Age_Array[i] >= 60) && ($scope.Age_Array[i] <= 69)) {
                    $scope.AgeCount_60_69++;
                }
                else if ($scope.Age_Array[i] >= 70) {
                    $scope.AgeCount_Above++;
                }
            }

            google.charts.load("current", { packages: ["corechart"] });
            google.charts.load("current", { packages: ["bar"] });
            google.charts.setOnLoadCallback(drawChart);

            function drawChart() {

                var data_Age = google.visualization.arrayToDataTable([
                  ['Age group', 'Number'],
                  ['Male', $scope.num_Male],
                  ['Female', $scope.num_Female]
                ]);

                var options_Age = {
                    pieHole: 0.6, width: 500, height: '220'
                };

                var chart_Age = new google.visualization.PieChart(document.getElementById('donutchart_Gender'));
                chart_Age.draw(data_Age, options_Age);

                var data = google.visualization.arrayToDataTable([
                  ['Year Range', 'Number'],
                  ['0 - 9 years', $scope.AgeCount_0_9],
                  ['10 - 19 years', $scope.AgeCount_10_19],
                  ['20 - 29 years', $scope.AgeCount_20_29],
                  ['30 - 39 years', $scope.AgeCount_30_39],
                  ['40 - 49 years', $scope.AgeCount_40_49],
                  ['50 - 59 years', $scope.AgeCount_50_59],
                  ['60 - 69 years', $scope.AgeCount_60_69],
                  ['70 years and older', $scope.AgeCount_Above],
                ]);

                var options = {
                    pieHole: 0.5, width: 500, height: 300
                };

                var chart = new google.visualization.PieChart(document.getElementById('donutchart_Age'));
                chart.draw(data, options);

                //Financial Bar Graph - Totals (Consulation Fee, Amount Owing, Amount Paid) Over the selected period over a selected period of time.
                var data = google.visualization.arrayToDataTable([
                    ["Income Type", "Amount (R)", { role: "style" }],
                    ["Gross Income", $scope.Total_Footer, "blue"],
                    ["Received", $scope.AmountPaid_Footer, "red"],
                    ["Outstanding", $scope.BalanceOwing_Footer, "gold"]
                ]);

                var options = {
                    title: "Total income in (R)",
                    width: 500,
                    height: 400,
                    bar: { groupWidth: "95%" },
                    legend: { position: "none" },
                };

                var chart = new google.visualization.ColumnChart(document.getElementById('curve_chart_IncomeStats'));
                chart.draw(data, options);

                //Financial Line Graph: Income Stats over last 6 Months
                var data = google.visualization.arrayToDataTable([
                  ['Year-Month', 'Income', 'Received', 'Outstanding'],
                  [$scope.month_5, $scope.Total_month_5, $scope.AmountPaid_month_5, $scope.BalanceOwing_month_5],
                  [$scope.month_4, $scope.Total_month_4, $scope.AmountPaid_month_4, $scope.BalanceOwing_month_4],
                  [$scope.month_3, $scope.Total_month_3, $scope.AmountPaid_month_3, $scope.BalanceOwing_month_3],
                  [$scope.month_2, $scope.Total_month_2, $scope.AmountPaid_month_2, $scope.BalanceOwing_month_2],
                  [$scope.month_1, $scope.Total_month_1, $scope.AmountPaid_month_1, $scope.BalanceOwing_month_1],
                  [$scope.month_0, $scope.Total_month_0, $scope.AmountPaid_month_0, $scope.BalanceOwing_month_0] 
                ]);

                console.log($scope.month_5, +" " + $scope.Total_month_5, +" " + $scope.AmountPaid_month_5, +" " + $scope.BalanceOwing_month_5);
                console.log($scope.month_4, +" " + $scope.Total_month_4, +" " + $scope.AmountPaid_month_4, +" " + $scope.BalanceOwing_month_4);
                console.log($scope.month_3, +" " + $scope.Total_month_3, +" " + $scope.AmountPaid_month_3, +" " + $scope.BalanceOwing_month_3);
                console.log($scope.month_2, +" " + $scope.Total_month_2, +" " + $scope.AmountPaid_month_2, +" " + $scope.BalanceOwing_month_2);
                console.log($scope.month_1, +" " + $scope.Total_month_1, +" " + $scope.AmountPaid_month_1, +" " + $scope.BalanceOwing_month_1);
                console.log($scope.month_0, +" " + $scope.Total_month_0, +" " + $scope.AmountPaid_month_0, +" " + $scope.BalanceOwing_month_0);
                var options = {
                    title: 'Company Performance',
                    curveType: 'function',
                    legend: { position: 'right' },
                    width: 1200,
                    height: 380,
                };

                var chart = new google.visualization.LineChart(document.getElementById('curve_chart_Income_OverLast6Months'));
                chart.draw(data, options);
            } 
        };
    }]);