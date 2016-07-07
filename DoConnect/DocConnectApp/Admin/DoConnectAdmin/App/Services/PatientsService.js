app.factory('PatientsService',
    ['$http',
        function ($http) {
            return getReport = function () {
                return "";//$http.get("http://sa-tfss:8085/DeploymentInfoService.asmx/GetReport");
            }
        }
    ]);