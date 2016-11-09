app.factory('AppointmentsService',   
    function ($http) {
        
        //Select all Appointments data
        var GetAllAppointments = function (patientID) {
            return $http.get("api/Appointments/GetAllAppointments/" + patientID);
        };

        var GetAllDoctors = function () {
            return $http.get("api/Appointments/GetAllDoctors");
        }
                                    
        //Select Appointment by ID
        var GetAppointmentByID = function (ID) {
            return $http.get("api/Appointments/GetAppointment/" + ID);
        };

            
        //Insert new record
        var InsertAppointment = function (Date_Time, Patient_ID, Details, DoctorID) {
            return $http.post("api/Appointments/InsertAppointment",
            {
                'Appointments_Date_Time': Date_Time,
                'Patient_ID': Patient_ID,
                'Appointments_Details': Details,
                'Appointments_App_Status': 2,
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

        //Select Practice by ID
        var GetDoctorByID = function (Doctors_ID) {
            return $http.get("api/Doctors/GetDoctor/" + Doctors_ID);
        };

        //Select Practice by ID
        var GetPracticeByID = function (ID) {
            return $http.get("api/Practices/GetPractice/" + ID);
        };

        return {
            GetAllAppointments: GetAllAppointments,
            GetAllDoctors: GetAllDoctors,
            GetAppointmentByID: GetAppointmentByID,            
            InsertAppointment: InsertAppointment,
            UpdateAppointment: UpdateAppointment,
            DeleteAppointment: DeleteAppointment,
            GetDoctorByID: GetDoctorByID,
            GetPracticeByID: GetPracticeByID
        };
    }
);