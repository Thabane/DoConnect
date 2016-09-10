app.factory('AppointmentsService',   
    function ($http) {
        
        //Select all Appointments data
        var GetAllAppointments = function () {
            return $http.get("api/Appointments/GetAllAppointments");
        };

        var GetAllPatients = function () {
            return $http.get("api/Appointments/GetAllPatients");
        }

        var GetAllDoctors = function () {
            return $http.get("api/Appointments/GetAllDoctors");
        }
                                    
        //Select Appointment by ID
        var GetAppointmentByID = function (ID) {
            return $http.get("api/Appointments/GetAppointment/" + ID);
        };

            
        //Insert new record
        var InsertAppointment = function (Date_Time, Patient_ID, Details, App_Status, DoctorID) {
            return $http.post("api/Appointments/InsertAppointment",
            {
                'Appointments_Date_Time': Date_Time,
                'Patient_ID': Patient_ID,
                'Appointments_Details': Details,
                'Appointments_App_Status': App_Status,
                'Doctors_ID': DoctorID
            });
        };

        //Update Practice
        var UpdateAppointment = function (ID, Date_Time, Patient_ID, Details, App_Status, DoctorID) {
            console.log(ID, Date_Time, Patient_ID, Details, App_Status, DoctorID);
            return $http.post("api/Appointments/UpdateAppointment",
            {
                'Appointments_ID': ID,
                'Appointments_Date_Time': Date_Time,
                'Patient_ID': Patient_ID,
                'Appointments_Details': Details,
                'Appointments_App_Status': App_Status,
                'Doctors_ID': DoctorID
            });
        };
            
        //Delete the Record
        var DeleteAppointment = function (ID) {
            return $http.post("api/Appointments/DeleteAppointment/" + ID);
        };

        return {
            GetAllAppointments: GetAllAppointments,
            GetAllPatients: GetAllPatients,
            GetAllDoctors: GetAllDoctors,
            GetAppointmentByID: GetAppointmentByID,            
            InsertAppointment: InsertAppointment,
            UpdateAppointment: UpdateAppointment,
            DeleteAppointment: DeleteAppointment
        };
    }
);