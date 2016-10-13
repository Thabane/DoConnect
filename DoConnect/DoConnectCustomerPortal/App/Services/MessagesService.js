app.factory('MessagesService',
    function ($http) {
        //Select all Message data
        var GetAllMessages = function () {
            return $http.get("api/Messages/GetAllMessages");
        };            
                                    
        //Select Message by ID
        var GetMessageByID = function (ID) {
            return $http.get("api/Messages/GetMessage/" + ID);
        };
            
        //Insert new record
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

        //Delete the Record
        var DeleteMessage = function (ID) {
            return $http.post("api/Messages/DeleteMessage/" + ID);
        };

        return {
            GetAllMessages: GetAllMessages,
            GetMessageByID: GetMessageByID,
            InsertMessage: InsertMessage,
            UpdateMessage: UpdateMessage,
            DeleteMessage: DeleteMessage
        };
    }
);