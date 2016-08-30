app.factory('AppointmentsService',   
    function ($http) {
        
        //Select all Appointments data
        var GetAllAppointments = function () {
            return $http.get("api/Appointments/GetAllAppointments");
        };            
                                    
        //Select Appointment by ID
        var GetAppointmentByID = function (ID) {
            return $http.get("api/Appointments/GetAppointment/" + ID);
        };
            
        //Insert new record
        var InsertAppointment = function (Date_Time, Patient_ID, Details, App_Status) {
            return $http.post("api/Appointments/InsertAppointment",
            {
                'Name': Name,
                'Date_Time': Date_Time,
                'Patient_ID': Patient_ID,
                'Details': Details,
                'App_Status': App_Status
            });
        };

        //Update Practice
        var UpdateAppointment = function (ID, Date_Time, Patient_ID, Details, App_Status) {
            return $http.post("api/Appointments/UpdateAppointment",
            {
                'ID': ID,
                'Name': Name,
                'Date_Time': Date_Time,
                'Patient_ID': Patient_ID,
                'Details': Details,
                'App_Status': App_Status
            });
        };
            
        //Delete the Record
        var DeleteAppointment = function (ID) {
            return $http.post("api/Appointments/DeleteAppointment/" + ID);
        };

        return {
            GetAllAppointments: GetAllAppointments,
            GetAppointmentByID: GetAppointmentByID,
            InsertAppointment: InsertAppointment,
            UpdateAppointment: UpdateAppointment,
            DeleteAppointment: DeleteAppointment
        };
    }
);