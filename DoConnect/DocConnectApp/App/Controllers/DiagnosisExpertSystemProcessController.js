app.controller("DiagnosisExpertSystemProcessController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval) {

        $scope.GetGlobalResponse = function () {
            DiagnosisExpertSystemService.getGlobalResponse().then
            (function (result) {
                $scope.DiagnosisResponse = result.data;                
            });
        };

        $scope.GetChosenEvidence = function () {
            $scope.globalEvidence = DiagnosisExpertSystemService.getChosenEvidence();
        };

        $scope.GetChosenEvidence();
        $scope.GetGlobalResponse();
        

        $scope.AnswerQuestionSingle = function (id, choiceid) {

            var quesResponse = {                    
                        "id": id,
                        "choice_id": choiceid                   
            }
            
            $scope.globalEvidence.evidence.push(quesResponse);

            DiagnosisExpertSystemService.patientDiagnosisReturn($scope.globalEvidence).then
            (function (result) {
                $scope.DiagnosisResponse = result.data;
                $scope.LogStuff($scope.DiagnosisResponse);
            });

        };

        $scope.LogStuff = function (log) {
            console.log(log);
        }

        $scope.AnswerQuestionGroupMutiple = function (evidence) {

            $scope.finalEvidence = [];

            for (var e in evidence) {

                if (evidence[e].SELECTED === 1) {
                    var evid =
                        {
                            id: evidence[e].id,
                            choice_id: evidence[e].choices[1].id
                        }
                    $scope.finalEvidence.push(evid);
                }

            }

            for (var e in $scope.finalEvidence) {
                $scope.globalEvidence.evidence.push($scope.finalEvidence[e]);
            }            
            
            DiagnosisExpertSystemService.patientDiagnosisReturn($scope.globalEvidence).then
            (function (result) {
                $scope.DiagnosisResponse = result.data;
                $scope.LogStuff($scope.DiagnosisResponse);
            });

        };

        $scope.AnswerQuestionGroupSingle = function (evidence) {

            var quesResponse = {               
                        "id": evidence.id,
                        "choice_id": evidence.choices[0].id
            }
                
            $scope.globalEvidence.evidence.push(quesResponse);
            

            DiagnosisExpertSystemService.patientDiagnosisReturn($scope.globalEvidence).then
            (function (result) {
                $scope.DiagnosisResponse = result.data;
                $scope.LogStuff($scope.DiagnosisResponse);
            });

        };

    }]);