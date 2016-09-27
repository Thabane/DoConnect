app.controller("MessagesController", ["$scope", "MessagesService", "$interval",
    function ($scope, MessagesService, $interval) {

        var init_ControlSettings = function () {
            angular.element("#div_Compose_Message").hide();
            angular.element("#div_Sent_list").hide();
        };
        init_ControlSettings();

        $scope.FunctionInbox = function () {
            angular.element("#div_Message_list").show();
            angular.element("#h2_ContentHeading").html("Inbox");
            angular.element("#div_Compose_Message").hide();
            angular.element("#div_Sent_list").hide();
        };

        $scope.FunctionComposeMessage = function () {
            angular.element("#div_Compose_Message").show();
            angular.element("#h2_ContentHeading").html("Compose Message");
            angular.element("#div_Message_list").hide();
            angular.element("#div_Sent_list").hide();
        };

        $scope.FunctionSent = function () {
            angular.element("#div_Sent_list").show();
            angular.element("#div_Message_list").hide();
            angular.element("#h2_ContentHeading").html("Sent Messages");
            angular.element("#div_Compose_Message").hide();
        };

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        };

        //Select All Messages
        $scope.GetAllMessages = function () {
            MessagesService.GetAllMessages().then
            (function (result) {
                $scope.Messages = result.data;
            });
        };
        $scope.GetAllMessages();

        //Select MessageByID Function
        $scope.ViewMessage = function (ID) {
            MessagesService.GetMessageByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.Sender = result["Sender"];
                $scope.Receiver = result["Receiver"];
                $scope.Subject = result["Subject"];
                $scope.Description = result["Description"];
                $scope.Date = result["Date"];
            });
        };

        //Insert Message Funtion
        $scope.NewMessage = function (Sender, Receiver, Subject, Description, Date) {
            MessagesService.InsertMessage(Sender, Receiver, Subject, Description, Date).success(function () {
                $scope.GetAllMessages();
                angular.element(".insert").val('');
                btnSuccess("Message successfully inserted.");
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };

        //Delete Message Funtion
        $scope.DeleteMessage = function () {
            MessagesService.DeleteMessage($scope.ID).then(function () {
                $scope.GetAllMessages();
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });
        };
    }]);