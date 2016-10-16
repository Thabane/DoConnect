app.factory('EventsService',
    function ($http) {

        var GetAllEvents = function () {
            return $http.get("api/Events/GetAllEvents");
        };

        var GetEventByID = function (ID) {
            return $http.get("api/Events/GetEvent/" + ID);
        };

        var InsertEvent = function (Title, Details, StartDateTime, EndDateTime, AppointmentStatus) {
            return $http.post("api/Events/InsertEvent",
            {
                'Title': Title,
                'Details': Details,
                'StartDateTime': StartDateTime,
                'EndDateTime': EndDateTime,
                'AppointmentStatus': AppointmentStatus
            });
        };

        var UpdateEvent = function (ID, Title, Details, StartDateTime, EndDateTime, AppointmentStatus) {
            return $http.post("api/Events/UpdateEvent",
            {
                'ID': ID,
                'Title': Title,
                'Details': Details,
                'StartDateTime': StartDateTime,
                'EndDateTime': EndDateTime,
                'AppointmentStatus': AppointmentStatus
            });
        };

        var DeleteEvent = function (ID) {
            return $http.post("api/Events/DeleteEvent/" + ID);
        };

        return {
            GetAllEvents: GetAllEvents,
            GetEventByID: GetEventByID,
            InsertEvent: InsertEvent,
            UpdateEvent: UpdateEvent,
            DeleteEvent: DeleteEvent
        };
    }
);