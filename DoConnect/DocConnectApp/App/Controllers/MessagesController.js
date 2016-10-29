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
            angular.element(".SearchDiv").show();            
        };

        $scope.FunctionComposeMessage = function () {
            
            angular.element("#div_Compose_Message").show();
            angular.element("#h2_ContentHeading").html("Compose Message");
            angular.element("#div_Message_list").hide();
            angular.element("#div_Sent_list").hide();
            angular.element(".SearchDiv").hide();
        };

        $scope.FunctionSent = function () {
            MessagesService.GetAllSentMessages($scope.SessionData_User_ID).then(function (result) {
                $scope.SentMessages = result.data;
            });
            angular.element("#div_Sent_list").show();
            angular.element("#div_Message_list").hide();
            angular.element("#h2_ContentHeading").html("Sent Messages");
            angular.element("#div_Compose_Message").hide();
            angular.element(".SearchDiv").show();
        };

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        };

        //Select All Messages
        $scope.GetAllMessages = function () {
            MessagesService.SessionData().success(function (result) {
                $scope.SessionData_User_ID      = result["User_ID"];
                $scope.SessionData_FirstName    = result["FirstName"];
                $scope.SessionData_LastName     = result["LastName"];
                $scope.SessionData_Email        = result["Email"];
                MessagesService.GetAllMessages($scope.SessionData_User_ID).then(function (result) {
                    $scope.Messages = result.data;
                });

                MessagesService.NumOfUnReadMessages($scope.SessionData_User_ID).then(function (result) {
                    $scope.NumOfUnReadMessages = result.data["NumOfUnReadMessages"];
                });

                $scope.GetAllRecepients = function () {
                    MessagesService.GetAllRecepients().success(function (result) {
                        $scope.AllRecepients = result;
                    });
                };
                $scope.GetAllRecepients();
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

                $scope.GetAllMessages();
            });
        };

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

        

        $scope.Receiver_UserID = 0;
        $scope.changedValueGetReceiver_UserID = function (item) {
            console.log(item);
            $scope.Receiver_UserID = item.User_ID;
        };

        $scope.SendMessage = function (_Subject, _Description) {
            MessagesService.InsertMessage($scope.Receiver_UserID, $scope.SessionData_User_ID, _Subject, _Description, $scope.today).success(function () {
                $scope.GetAllMessages();
                $scope.FunctionInbox();
                angular.element(".insert").val('');
                btnSuccess("Message successfully sent.");
            },
            function (error) {
                btnAlert("System Error Message", "Message not successfully sent.");
            });
        };

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