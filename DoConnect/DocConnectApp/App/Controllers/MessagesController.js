app.controller("MessagesController", ["$scope", "MessagesService", "$interval", "$filter", "$ngBootbox",
    function ($scope, MessagesService, $interval, $filter, $ngBootbox) {

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
            MessagesService.SessionData().success(function (result) {
                sessionStorage.SessionData_User_ID      = result["User_ID"];
                sessionStorage.SessionData_FirstName    = result["FirstName"];
                sessionStorage.SessionData_LastName     = result["LastName"];
                sessionStorage.SessionData_Email        = result["Email"];
                MessagesService.GetAllMessages(sessionStorage.SessionData_User_ID).then(function (result) {
                    $scope.Messages = result.data;
                });

                MessagesService.GetAllSentMessages(sessionStorage.SessionData_User_ID).then(function (result) {
                    $scope.SentMessages = result.data;
                });
            });            
        };
        $scope.GetAllMessages();

        //Select MessageByID Function
        $scope.ViewInboxMessage = function (ID) {
            MessagesService.GetMessageByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.Sender = result["Sender"];
                $scope.Receiver = result["Receiver"];
                $scope.SenderEmail = result["SenderEmail"];
                $scope.ReceiverEmail = result["ReceiverEmail"];
                $scope.Subject = result["Subject"];
                $scope.Description = result["Description"];
                $scope.Date = result["Date"];
            });
        };

        $scope.GetAllSentMessages = function () {
            
        };
        $scope.GetAllSentMessages();

        $scope.ViewSentMessage = function (ID) {
            MessagesService.GetSentMessageById(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.Sender = result["Sender"];
                $scope.Receiver = result["Receiver"];
                $scope.SenderEmail = result["SenderEmail"];
                $scope.ReceiverEmail = result["ReceiverEmail"];
                $scope.Subject = result["Subject"];
                $scope.Description = result["Description"];
                $scope.Date = result["Date"];
            });
        };

        $scope.CloseViewMessageModel = function (ID) {
            angular.element("#CloseViewMessageModel").trigger("click");
        };

        $scope.today = $filter('date')(new Date(), 'yyyy-MM-dd');
        //alert($filter('time')(new Date(), 'HH:mm:ss'));

        $scope.ReplyMessage = function (_Subject, _Description) {
            MessagesService.InsertMessage($scope.Sender, $scope.Receiver, _Subject, _Description, $scope.today).success(function () {
                $scope.GetAllMessages();
                angular.element("#CloseViewMessageModel2").trigger("click");
                btnSuccess("Message successfully sent.");
            },
            function (error) {
                btnAlert("System Error Message", "Message not successfully sent.");
            });
        };

        //Delete Message Funtion
        $scope.DeleteMessage = function () {
            $ngBootbox.confirm("Are you sure you want to delete this Message?").then(function () {
                MessagesService.DeleteMessage($scope.ID).then(function () {
                    $scope.GetAllMessages();
                    btnSuccess("Message record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };


        $scope.DeleteMessage1 = function (ID) {
            $ngBootbox.confirm("Are you sure you want to delete this message ?").then(function () {
                MessagesService.DeleteMessage(ID).then(function () {
                    $scope.GetAllMessages();
                    btnSuccess("Message successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };
        $scope.DeleteMessage2 = function (ID) {
            $ngBootbox.confirm("Are you sure you want to delete this message ?").then(function () {
                MessagesService.DeleteMessage(ID).then(function () {
                    $scope.GetAllMessages();
                    angular.element(".CloseModel").trigger("click");
                    btnSuccess("Message successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };
    }]);