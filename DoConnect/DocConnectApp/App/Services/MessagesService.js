app.factory('MessagesService',
    function ($http) {

        var GetAllMessages = function (Receiver) {
            return $http.get("api/Messages/GetAllMessages/" + Receiver);
        };

        var GetMessageByID = function (ID) {
            return $http.get("api/Messages/GetMessage/" + ID);
        };

        var GetAllSentMessages = function (Sender) {
            return $http.get("api/Messages/GetAllSentMessages/" + Sender);
        };

        var GetSentMessageById = function (ID) {
            return $http.get("api/Messages/GetSentMessageById/" + ID);
        };

        var InsertMessage = function (Receiver, Sender, Subject, Description, Date) {
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
            GetAllSentMessages: GetAllSentMessages,
            GetSentMessageById: GetSentMessageById,
            InsertMessage: InsertMessage,
            DeleteMessage: DeleteMessage,
            SessionData: SessionData
        };
    }
);