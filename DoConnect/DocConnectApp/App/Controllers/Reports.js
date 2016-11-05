app.controller("ReportsController", ["$scope", "ReportsService", "$interval",
    function ($scope, ReportsService, $interval) {

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
                console.log($scope.Age_Array[i]);
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
    }]);