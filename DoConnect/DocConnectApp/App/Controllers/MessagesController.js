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
            });
            
        };
        $scope.GetAllMessages();

        //Select MessageByID Function
        $scope.ViewMessage = function (ID) {
            MessagesService.GetMessageByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.Sender = result["SenderEmail"];
                $scope.Receiver = result["ReceiverEmail"];
                $scope.Subject = result["Subject"];
                $scope.Description = result["Description"];
                $scope.Date = result["Date"];
            });
        };

        $scope.today = $filter('date')(new Date(), 'yyyy-MM-dd');
        //alert($filter('time')(new Date(), 'HH:mm:ss'));
        //Insert Message Funtion
        $scope.NewMessage = function (Receiver, Subject, Description) {
            MessagesService.InsertMessage(sessionStorage.Email, Receiver, Subject, Description, $scope.today).success(function () {
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
            $ngBootbox.confirm("Are you sure you want to delete this Message?").then(function () {
                MessagesService.DeleteMessage($scope.ID).then(function () {
                    $scope.GetAllMessages();
                    btnSuccess("Message record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };
    }]);