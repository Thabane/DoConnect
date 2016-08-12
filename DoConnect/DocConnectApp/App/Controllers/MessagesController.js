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
    }]);