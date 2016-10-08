app.controller("DiagnosisExpertSystemProcessController", ["$scope", "DiagnosisExpertSystemService", "$interval",
    function ($scope, DiagnosisExpertSystemService, $interval) {

        $scope.GetGlobalResponse = function () {
            DiagnosisExpertSystemService.getGlobalResponse().then
            (function (result) {
                $scope.DiagnosisResponse = result.data;
            });
        };

        $scope.GetGlobalResponse();

        $scope.AnswerQuestionSingle = function (id, choiceid) {

            var quesResponse = {
                "sex": "male",
                "age": "26",
                "evidence": [
                  {
                      "id": id,
                      "choice_id": choiceid
                  }
                ]
            }

            DiagnosisExpertSystemService.patientDiagnosisReturn(quesResponse).then
            (function (result) {
                $scope.DiagnosisResponse = result.data;
            });

        };

        $scope.AnswerQuestionGroupMutiple = function (evidence) {

            $scope.finalEvidence = [];

            for (var e in evidence) {

                    if (evidence[e].SELECTED === 1) {
                        var evid = finalEvidence = 
                            {
                                id: evidence[e].id,
                                choice_id: evidence[e].choices[0].id
                            }
                        $scope.finalEvidence.push(evid);
                    }

                }
            

            var quesResponse = {
                "sex": "male",
                "age": "26",
                "evidence": $scope.finalEvidence
            }


            DiagnosisExpertSystemService.patientDiagnosisReturn(quesResponse).then
            (function (result) {
                $scope.DiagnosisResponse = result.data;
            });

        };

    }]);