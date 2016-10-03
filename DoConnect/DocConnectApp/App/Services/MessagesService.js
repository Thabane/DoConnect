﻿app.factory('MessagesService',
    function ($http) {

        var GetAllMessages = function (Receiver) {
            return $http.get("api/Messages/GetAllMessages/" + Receiver);
        };

        var GetMessageByID = function (ID) {
            return $http.get("api/Messages/GetMessage/" + ID);
        };

        var InsertMessage = function (Sender, Receiver, Subject, Description, Date) {
            return $http.post("api/Messages/InsertMessage",
            {
                'Sender': Sender,
                'Receiver': Receiver,
                'Subject': Subject,
                'Description': Description,
                'Date': Date
            });
        };

        var DeleteMessage = function (ID) {
            return $http.post("api/Messages/DeleteMessage/" + ID);
        };

        var SessionData = function () {
            return $http.get("/Data/SessionData");
        };

        return {
            GetAllMessages: GetAllMessages,
            GetMessageByID: GetMessageByID,
            InsertMessage: InsertMessage,
            DeleteMessage: DeleteMessage,
            SessionData: SessionData
        };
    }
);