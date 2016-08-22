app.controller("EventsController", ["$scope", "EventsService", "$interval",
    function ($scope, EventsService, $interval) {
                
        $scope.DT = function () {
            $("#datetimepicker1").datetimepicker();
            $("#datetimepicker2").datetimepicker({
                useCurrent: false
            });
            $("#datetimepicker1").on("dp.change", function (e) {
                $("#datetimepicker2").data("DateTimePicker").minDate(e.date);
            });
            $("#datetimepicker2").on("dp.change", function (e) {
                $("#datetimepicker1").data("DateTimePicker").maxDate(e.date);
            });
        };

        $scope.DT_View_Events = function () {
            $("#datetimepicker3").datetimepicker();
            $("#datetimepicker4").datetimepicker({
                useCurrent: false
            });
            $("#datetimepicker3").on("dp.change", function (e) {
                $("#datetimepicker4").data("DateTimePicker").minDate(e.date);
            });
            $("#datetimepicker4").on("dp.change", function (e) {
                $("#datetimepicker3").data("DateTimePicker").maxDate(e.date);
            });
        };

        $scope.DT_New_Event = function () {
            $("#datetimepicker5").datetimepicker();
            $("#datetimepicker6").datetimepicker({
                useCurrent: false
            });
            $("#datetimepicker5").on("dp.change", function (e) {
                $("#datetimepicker6").data("DateTimePicker").minDate(e.date);
            });
            $("#datetimepicker6").on("dp.change", function (e) {
                $("#datetimepicker5").data("DateTimePicker").maxDate(e.date);
            });
        };

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        //Select All Events
        $scope.GetAllEvents = function () {
            EventsService.GetAllEvents().then
            (function (result) {
                $scope.Events = result.data;
            });
        };
        $scope.GetAllEvents();

        //Select EventByID Function
        $scope.ViewEvent = function (ID) {
            EventsService.GetEventByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.Title = result["Title"];
                $scope.Details = result["Details"];
                $scope.StartDateTime = result["StartDateTime"];
                $scope.EndDateTime = result["EndDateTime"];
                $scope.AppointmentStatus = result["AppointmentStatus"];
            });
        };

        //Insert Event Funtion
        $scope.NewEvent = function (Title, Details, StartDateTime, EndDateTime, AppointmentStatus) {
            EventsService.InsertEvent(Title, Details, StartDateTime, EndDateTime, AppointmentStatus).success(function () {
                $scope.GetAllEvents();
                angular.element(".insert").val('');
                btnSuccess("Event successfully inserted.");
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };

        //Update Event Funtion
        $scope.function_btnUpdateEvent = function () {
            var btnText = angular.element("#function_btnUpdateEvent").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewEvent").attr("readonly", false);
                angular.element("#function_btnUpdateEvent").html("Save");
            }
            else {
                EventsService.UpdateEvent($scope.ID, $scope.Title, $scope.Details, $scope.StartDateTime, $scope.EndDateTime, $scope.AppointmentStatus).success(function () {
                    $scope.GetAllEvents();
                    btnSuccess("Event details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });

                angular.element(".readonly_ViewEvent").attr("readonly", true);
                angular.element("#function_btnUpdateEvent").html("Update");
            }
        };

        //Delete Event Funtion
        $scope.DeleteEvent = function () {
            EventsService.DeleteEvent($scope.ID).then(function () {
                $scope.GetAllEvents();
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });           
        };
    }]);