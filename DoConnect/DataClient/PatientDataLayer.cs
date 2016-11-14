using ObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClient
{
    public class PatientDataLayer
    {
        private DataAccess access;
        private List<SqlParameter> _parameters = new List<SqlParameter>();
        private string Conn;
        //private string Conn = @"Server=tcp:doconnect.database.windows.net,1433;Initial Catalog=DoConnect;Persist Security Info=False;User ID=teamCogent;Password=DoConnect1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public PatientDataLayer()
        {
            access = new DataAccess();
            Conn = "Server=tcp:doconnect.database.windows.net,1433;Initial Catalog=DoConnect;Persist Security Info=False;User ID=teamCogent;Password=DoConnect1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";//ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        #region Appointments

        public List<Appointments> Portal_GetAppointmentsByPatientID(int PatientID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter PatientIDParameter = new SqlParameter("@PatientID", SqlDbType.Int);
            PatientIDParameter.Value = PatientID;
            _parameters.Add(PatientIDParameter);

            DateTime Today = DateTime.Now;
            DateTime Tomorrow = DateTime.Today.AddDays(+1);
            DateTime Tomorrow2 = DateTime.Today.AddDays(+2);
            Appointments AppointmentInfo = new Appointments(); int numTodayApps = 0; int numTomorrowApps = 0;
            List<Appointments> AppointmentsInfo = new List<Appointments>();

            try
            {
                using (var reader = access.ExecuteReader(Conn, "[Portal_GetAppointmentsByPatientID]", _parameters))
                {
                    while (reader.Read())
                    {
                        AppointmentInfo.Appointments_ID = reader.GetInt32(reader.GetOrdinal("Appointments_ID"));
                        AppointmentInfo.Appointments_App_Status = reader.GetInt32(reader.GetOrdinal("Appointments_App_Status"));
                        AppointmentInfo.Appointments_Date_Time = reader.GetString(reader.GetOrdinal("Appointments_Date_Time"));
                        AppointmentInfo.Appointments_Details = reader.GetString(reader.GetOrdinal("Appointments_Details"));
                        AppointmentInfo.Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID"));
                        AppointmentInfo.Patient_FirstName = reader.GetString(reader.GetOrdinal("Patient_FirstName"));
                        AppointmentInfo.Patient_LastName = reader.GetString(reader.GetOrdinal("Patient_LastName"));
                        AppointmentInfo.Patient_Cell_Number = reader.GetString(reader.GetOrdinal("Patient_Cell_Number"));
                        AppointmentInfo.Patient_Email = reader.GetString(reader.GetOrdinal("Patient_Email"));
                        AppointmentInfo.Doctors_Email = reader.GetString(reader.GetOrdinal("Doctors_Email"));
                        AppointmentInfo.Doctors_FirstName = reader.GetString(reader.GetOrdinal("Doctors_FirstName"));
                        AppointmentInfo.Doctors_LastName = reader.GetString(reader.GetOrdinal("Doctors_LastName"));
                        AppointmentInfo.Doctors_ID = reader.GetInt32(reader.GetOrdinal("Doctors_ID"));
                        AppointmentInfo.Doctors_Job_Title = reader.GetString(reader.GetOrdinal("Doctors_Job_Title"));
                        AppointmentInfo.Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID"));
                        AppointmentInfo.Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name"));
                        AppointmentInfo.Practice_Phone_Number = reader.GetString(reader.GetOrdinal("Practice_Phone_Number"));
                        AppointmentInfo.Practice_Fax_Number = reader.GetString(reader.GetOrdinal("Practice_Fax_Number"));
                        AppointmentInfo.Practice_Address = reader.GetString(reader.GetOrdinal("Practice_Address"));

                        DateTime Appointments_Date_Time = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Appointments_Date_Time")));
                        if ((Today < Appointments_Date_Time) && (Appointments_Date_Time < Tomorrow))
                        {
                            AppointmentInfo.highlightTodayApps = 1;
                            numTodayApps++;
                        }
                        AppointmentInfo.numTodayApps = numTodayApps;
                        if ((Tomorrow < Appointments_Date_Time) && (Appointments_Date_Time < Tomorrow2))
                        {
                            AppointmentInfo.highlightTomorrowApps = 1;
                            numTomorrowApps++;
                        }
                        AppointmentInfo.numTomorrowApps = numTomorrowApps;
                        AppointmentsInfo.Add(AppointmentInfo); AppointmentInfo = new Appointments();
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed appointments page");
            }
            catch (Exception e)
            {
                string error = e.Message;
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view selected appointment " + ex.ToString());
            }
            return AppointmentsInfo;
        }

        public Appointments Portal_GetAppointmentById(int AppId)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter appIdParameter = new SqlParameter("@AppId", SqlDbType.Int);
            appIdParameter.Value = AppId;
            _parameters.Add(appIdParameter);
            Appointments AppointmentsInfo = new Appointments();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[Portal_GetAppointmentById]", _parameters))
                {
                    if (reader.Read())
                    {
                        AppointmentsInfo = (new Appointments().GetAppByID(reader));
                        //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed appointment record");
                    }
                }
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view appointments: " + AppId + "\n" + ex.ToString());
            }
            return AppointmentsInfo;
        }

        public bool Portal_NewAppointment(string Date_Time, int Patient_ID, string Details, int App_Status, int DoctorID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter App_StatusParameter = new SqlParameter("@App_Status", SqlDbType.Bit);
            SqlParameter DetailsParameter = new SqlParameter("@Details", SqlDbType.NVarChar);
            SqlParameter Date_TimeParameter = new SqlParameter("@Date_Time", SqlDbType.NVarChar);
            SqlParameter Patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter DoctorIDParameter = new SqlParameter("@Doctor_ID", SqlDbType.NVarChar);

            App_StatusParameter.Value = 2;//App_Status;
            DetailsParameter.Value = Details;
            Date_TimeParameter.Value = Date_Time;
            Patient_IDParameter.Value = Patient_ID;
            DoctorIDParameter.Value = DoctorID;
            parameters.Add(App_StatusParameter);
            parameters.Add(DetailsParameter);
            parameters.Add(Date_TimeParameter);
            parameters.Add(Patient_IDParameter);
            parameters.Add(DoctorIDParameter);

            try
            {
                int ID = 0;
                using (var reader = access.ExecuteReader(Conn, "[Portal_NewAppointment]", parameters))
                {
                    if (reader.Read())
                        ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Recorded new appointment");
                }
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to record new appointment: " + ex.ToString());
                return false;
            }
        }

        public bool Portal_UpdateAppointment(int ID, string Date_Time, int Patient_ID, string Details, int App_Status, int DoctorID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter App_StatusParameter = new SqlParameter("@App_Status", SqlDbType.Bit);
            SqlParameter DetailsParameter = new SqlParameter("@Details", SqlDbType.NVarChar);
            SqlParameter Date_TimeParameter = new SqlParameter("@Date_Time", SqlDbType.NVarChar);
            SqlParameter Patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter DoctorIDParameter = new SqlParameter("@Doctor_ID", SqlDbType.NVarChar);

            IDParameter.Value = ID;
            App_StatusParameter.Value = App_Status;
            DetailsParameter.Value = Details;
            Date_TimeParameter.Value = Date_Time;
            Patient_IDParameter.Value = Patient_ID;
            DoctorIDParameter.Value = DoctorID;
            parameters.Add(IDParameter);
            parameters.Add(App_StatusParameter);
            parameters.Add(DetailsParameter);
            parameters.Add(Date_TimeParameter);
            parameters.Add(Patient_IDParameter);
            parameters.Add(DoctorIDParameter);
            try
            {
                access.ExecuteNonQuery(Conn, parameters, "[Portal_UpdateAppointment]");
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Updated appointment record");
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to update appointment record: " + ex.ToString());
                return false;
            }
        }

        public bool Portal_DeleteAppointment(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[Portal_DeleteAppointment]", _parameters))
                {
                    if (reader.Read())
                    {
                        //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Deleted appointment record: "+ id);
                        return true;
                    }
                    else
                    {
                        //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to delete appointment record: " + id);
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to delete appointment record: "+ id +" : "+ ex.ToString());
                return false;
            }
        }

        #endregion

        #region Patient

        //
        public int Portal_Login(string email, string password)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);
            SqlParameter passwordParameter = new SqlParameter("@Password", SqlDbType.NVarChar);

            emailParameter.Value = email;
            passwordParameter.Value = password;

            _parameters.Add(emailParameter);
            _parameters.Add(passwordParameter);

            using (var reader = access.ExecuteReader(Conn, "[Portal_PatientLogin]", _parameters))
            {
                if(reader.Read())
                {
                    return reader.GetInt32(reader.GetOrdinal("ID")) != 0 ? reader.GetInt32(reader.GetOrdinal("ID")) : 0;
                }
            }
            return 0;
        }

        public MedicalRecord Portal_GetPatientByID(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            MedicalRecord MedicalRecordInfo = new MedicalRecord();
            using (var reader = access.ExecuteReader(Conn, "[GetMedicalRecord]", _parameters))
            {
                if (reader.Read())
                {
                    MedicalRecordInfo = new MedicalRecord().Create(reader);
                }
            }
            return MedicalRecordInfo;
        }

        //
        public void Portal_UpdatePreferedDoctor(int patientID, int doctorID)
        {

        }

        //
        public List<string> Portal_PatientMedicalHistory(int patientID)
        {
            return new List<string>();
        }

        #endregion

        #region Practices

        public List<Practice> Portal_GetAllPractices()
        {
            List<Practice> PracticeInfo = new List<Practice>();
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetAllPractices]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    PracticeInfo.Add(new Practice().Create(reader));
                }
            }
            return PracticeInfo;
        }

        public Practice Portal_GetPracticeById(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Practice PracticeInfo = new Practice();
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetPracticeById]", _parameters))
            {
                if (reader.Read())
                {
                    PracticeInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    PracticeInfo.Name = reader.GetString(reader.GetOrdinal("Name"));
                    PracticeInfo.Phone_Number = reader.GetString(reader.GetOrdinal("Phone_Number"));
                    PracticeInfo.Fax_Number = reader.GetString(reader.GetOrdinal("Fax_Number"));
                    PracticeInfo.Street_Address = reader.GetString(reader.GetOrdinal("Street_Address"));
                    PracticeInfo.Suburb = reader.GetString(reader.GetOrdinal("Suburb"));
                    PracticeInfo.City = reader.GetString(reader.GetOrdinal("City"));
                    PracticeInfo.Country = reader.GetString(reader.GetOrdinal("Country"));
                    PracticeInfo.Latitude = reader.GetString(reader.GetOrdinal("Latitude"));
                    PracticeInfo.Longitude = reader.GetString(reader.GetOrdinal("Longitude"));
                    PracticeInfo.Trading_Times = reader.GetString(reader.GetOrdinal("Trading_Times"));
                }
            }
            return PracticeInfo;
        }

        #endregion

        #region Doctors

        public List<Doctor> Portal_GetAllDoctors()
        {
            List<Doctor> DoctorsInfo = new List<Doctor>();
            using (var reader = access.ExecuteReader(Conn, "[GetAllDoctors]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    DoctorsInfo.Add(new Doctor().Create(reader));
                }
            }
            return DoctorsInfo;
        }

        //
        public Doctor Portal_GetDoctorById(int Id)
        {
            List<SqlParameter> _parameter = new List<SqlParameter>();
            SqlParameter IdParameter = new SqlParameter("@Id", SqlDbType.Int);
            IdParameter.Value = Id;
            _parameter.Add(IdParameter);

            Doctor DoctorsInfo = new Doctor();
            //try
            //{
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetDoctorById]", _parameter))
            {
                if (reader.Read())
                {
                    DoctorsInfo = new Doctor().Create(reader);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    access.LogEntry(UserId, ex.ToString());
            //}
            return DoctorsInfo;
        }

        #endregion

        #region MedicalHistory
        public List<MedicalHistory> Portal_GetMedicalHistoryByPatientID(int patient_ID)
        {
            List<SqlParameter> _parameter = new List<SqlParameter>();
            SqlParameter IdParameter = new SqlParameter("@ID", SqlDbType.Int);
            IdParameter.Value = patient_ID;
            _parameter.Add(IdParameter);
            List<MedicalHistory> PatientMedicalHistory = new List<MedicalHistory>();
            using (var reader = access.ExecuteReader(Conn, "[GetConsultationNotesWithId]", _parameter))
            {
                while (reader.Read())
                {
                    PatientMedicalHistory.Add(new MedicalHistory().Create(reader));
                }
            }
            return PatientMedicalHistory;
        }
        
        public MedicalHistory Portal_GetMedicalHistoryID(int id)
        {
            List<SqlParameter> _parameter = new List<SqlParameter>();
            SqlParameter IdParameter = new SqlParameter("@ID", SqlDbType.Int);
            IdParameter.Value = id;
            _parameter.Add(IdParameter);
            MedicalHistory PatientMedicalHistory = new MedicalHistory();
            using (var reader = access.ExecuteReader(Conn, "[GetConsultationNotesWithId]", _parameter))
            {
                if(reader.Read())
                { 
                    PatientMedicalHistory.SetMedRecord(reader);
                    return PatientMedicalHistory;
                }
            }
            return null;
        }
        #endregion

        #region Messages
        public List<Messages> Portal_GetAllMessages(int Receiver)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter ReceiverParameter = new SqlParameter("@Receiver", SqlDbType.Int);
            ReceiverParameter.Value = Receiver;
            _parameters.Add(ReceiverParameter);

            Messages MessageInfo = new Messages();
            List<Messages> MessagesInfo = new List<Messages>();
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetAllMessages]", _parameters))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.Sender = reader.GetInt32(reader.GetOrdinal("Sender"));
                    MessageInfo.Receiver = reader.GetInt32(reader.GetOrdinal("Receiver"));
                    MessageInfo.Subject = reader.GetString(reader.GetOrdinal("Subject"));
                    MessageInfo.Description = reader.GetString(reader.GetOrdinal("Description"));
                    MessageInfo.Date = reader.GetString(reader.GetOrdinal("Date"));
                    MessageInfo.ReceiverEmail = reader.GetString(reader.GetOrdinal("ReceiverEmail"));
                    MessageInfo.ReadStatus = reader.GetInt32(reader.GetOrdinal("ReadStatus"));

                    List<SqlParameter> parametersSender = new List<SqlParameter>();
                    SqlParameter SenderParameterSender = new SqlParameter("@Sender", SqlDbType.Int);
                    SenderParameterSender.Value = reader.GetInt32(reader.GetOrdinal("Sender"));
                    parametersSender.Add(SenderParameterSender);

                    using (var readerMessageSender = access.ExecuteReader(Conn, "[Portal_GetMessageSender]", parametersSender))
                    {
                        if (readerMessageSender.Read())
                        {
                            MessageInfo.SenderEmail = readerMessageSender.GetString(readerMessageSender.GetOrdinal("SenderEmail"));
                        }
                    }
                    MessagesInfo.Add(MessageInfo);
                    MessageInfo = new Messages();
                }

            }
            return MessagesInfo;
        }
        public Messages Portal_NumOfUnReadMessages(int Receiver)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter ReceiverParameter = new SqlParameter("@Receiver", SqlDbType.Int);
            ReceiverParameter.Value = Receiver;
            _parameters.Add(ReceiverParameter);

            Messages NumOfUnReadMessages = new Messages();
            using (var reader = access.ExecuteReader(Conn, "[Portal_NumOfUnReadMessages]", _parameters))
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(reader.GetOrdinal("ReadStatus")) == 1)
                    {
                        NumOfUnReadMessages.NumOfUnReadMessages++;
                    }
                }
            }
            return NumOfUnReadMessages;
        }
        public Messages Portal_GetMessageById(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);

            Messages MessageInfo = new Messages();
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetMessageById]", _parameters))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.Sender = reader.GetInt32(reader.GetOrdinal("Sender"));
                    MessageInfo.Receiver = reader.GetInt32(reader.GetOrdinal("Receiver"));
                    MessageInfo.Subject = reader.GetString(reader.GetOrdinal("Subject"));
                    MessageInfo.Description = reader.GetString(reader.GetOrdinal("Description"));
                    MessageInfo.Date = reader.GetString(reader.GetOrdinal("Date"));
                    MessageInfo.ReceiverEmail = reader.GetString(reader.GetOrdinal("ReceiverEmail"));

                    List<SqlParameter> parametersSender = new List<SqlParameter>();
                    SqlParameter SenderParameterSender = new SqlParameter("@Sender", SqlDbType.Int);
                    SenderParameterSender.Value = reader.GetInt32(reader.GetOrdinal("Sender"));
                    parametersSender.Add(SenderParameterSender);

                    List<SqlParameter> parametersMessageRead = new List<SqlParameter>();
                    SqlParameter IDParameterMessageRead = new SqlParameter("@ID", SqlDbType.Int);
                    IDParameterMessageRead.Value = ID;
                    parametersMessageRead.Add(IDParameterMessageRead);

                    using (var readerMessageSender = access.ExecuteReader(Conn, "[Portal_GetMessageSender]", parametersSender))
                    {
                        if (readerMessageSender.Read())
                        {
                            MessageInfo.SenderEmail = readerMessageSender.GetString(readerMessageSender.GetOrdinal("SenderEmail"));
                            access.ExecuteReader(Conn, "[Update_MessageRead]", parametersMessageRead);
                        }
                    }
                }
            }
            return MessageInfo;
        }
        public List<Messages> Portal_GetAllSentMessages(int Sender)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter SenderParameter = new SqlParameter("@Sender", SqlDbType.Int);
            SenderParameter.Value = Sender;
            _parameters.Add(SenderParameter);

            Messages MessageInfo = new Messages();
            List<Messages> MessagesInfo = new List<Messages>();
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetAllSentMessages]", _parameters))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.Sender = reader.GetInt32(reader.GetOrdinal("Sender"));
                    MessageInfo.Receiver = reader.GetInt32(reader.GetOrdinal("Receiver"));
                    MessageInfo.Subject = reader.GetString(reader.GetOrdinal("Subject"));
                    MessageInfo.Description = reader.GetString(reader.GetOrdinal("Description"));
                    MessageInfo.Date = reader.GetString(reader.GetOrdinal("Date"));
                    MessageInfo.SenderEmail = reader.GetString(reader.GetOrdinal("SenderEmail"));

                    List<SqlParameter> parametersReceiver = new List<SqlParameter>();
                    SqlParameter ReceiverParameter = new SqlParameter("@Receiver", SqlDbType.Int);
                    ReceiverParameter.Value = reader.GetInt32(reader.GetOrdinal("Receiver"));
                    parametersReceiver.Add(ReceiverParameter);

                    using (var readerMessageSender = access.ExecuteReader(Conn, "[GetMessageReceiver]", parametersReceiver))
                    {
                        if (readerMessageSender.Read())
                        {
                            MessageInfo.ReceiverEmail = readerMessageSender.GetString(readerMessageSender.GetOrdinal("ReceiverEmail"));
                        }
                    }
                    MessagesInfo.Add(MessageInfo);
                    MessageInfo = new Messages();
                }
            }
            return MessagesInfo;
        }
        public Messages Portal_GetSentMessageById(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);

            Messages MessageInfo = new Messages();
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetMessageById]", _parameters))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.Sender = reader.GetInt32(reader.GetOrdinal("Sender"));
                    MessageInfo.Receiver = reader.GetInt32(reader.GetOrdinal("Receiver"));
                    MessageInfo.Subject = reader.GetString(reader.GetOrdinal("Subject"));
                    MessageInfo.Description = reader.GetString(reader.GetOrdinal("Description"));
                    MessageInfo.Date = reader.GetString(reader.GetOrdinal("Date"));
                    MessageInfo.ReceiverEmail = reader.GetString(reader.GetOrdinal("ReceiverEmail"));

                    List<SqlParameter> parametersSender = new List<SqlParameter>();
                    SqlParameter SenderParameterSender = new SqlParameter("@Sender", SqlDbType.Int);
                    SenderParameterSender.Value = reader.GetInt32(reader.GetOrdinal("Sender"));
                    parametersSender.Add(SenderParameterSender);

                    using (var readerMessageSender = access.ExecuteReader(Conn, "[Portal_GetMessageSender]", parametersSender))
                    {
                        if (readerMessageSender.Read())
                        {
                            MessageInfo.SenderEmail = readerMessageSender.GetString(readerMessageSender.GetOrdinal("SenderEmail"));
                        }
                    }
                }
            }
            return MessageInfo;
        }
        public List<Staff> Portal_GetAllRecepients()
        {

            Staff MessageInfo = new Staff();
            List<Staff> MessagesInfo = new List<Staff>();
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetRecepientDoctors]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.FirstName = reader.GetString(reader.GetOrdinal("FirstName")) + " " + reader.GetString(reader.GetOrdinal("LastName")) + " : " + reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    MessageInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                    MessageInfo.Email = reader.GetString(reader.GetOrdinal("Email"));
                    MessagesInfo.Add(MessageInfo);
                    MessageInfo = new Staff();
                }
            }
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetRecepientStaff]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.FirstName = reader.GetString(reader.GetOrdinal("FirstName")) + " " + reader.GetString(reader.GetOrdinal("LastName")) + " : " + reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    MessageInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                    MessageInfo.Email = reader.GetString(reader.GetOrdinal("Email"));
                    MessagesInfo.Add(MessageInfo);
                    MessageInfo = new Staff();
                }
            }
            using (var reader = access.ExecuteReader(Conn, "[Portal_GetRecepientPatients]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.FirstName = reader.GetString(reader.GetOrdinal("FirstName")) + " " + reader.GetString(reader.GetOrdinal("LastName")) + " : " + reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    MessageInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                    MessageInfo.Email = reader.GetString(reader.GetOrdinal("Email"));
                    MessagesInfo.Add(MessageInfo);
                    MessageInfo = new Staff();
                }
            }
            return MessagesInfo;
        }
        public bool Portal_NewMessages(int Receiver, int Sender, string Subject, string Description, string Date)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter SenderParameter = new SqlParameter("@Sender", SqlDbType.Int);
            SqlParameter ReceiverParameter = new SqlParameter("@Receiver", SqlDbType.Int);
            SqlParameter SubjectParameter = new SqlParameter("@Subject", SqlDbType.NVarChar);
            SqlParameter DescriptionParameter = new SqlParameter("@Description", SqlDbType.NVarChar);
            SqlParameter DateParameter = new SqlParameter("@Date", SqlDbType.NVarChar);

            SenderParameter.Value = Sender;
            ReceiverParameter.Value = Receiver;
            SubjectParameter.Value = Subject;
            DescriptionParameter.Value = Description;
            DateParameter.Value = Date;

            _parameters.Add(SenderParameter);
            _parameters.Add(ReceiverParameter);
            _parameters.Add(SubjectParameter);
            _parameters.Add(DescriptionParameter);
            _parameters.Add(DateParameter);

            int insertedID = 0;
            using (var reader = access.ExecuteReader(Conn, "[Portal_InsertMessage]", _parameters))
            {
                if (reader.Read())
                {
                    insertedID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        public bool Portal_DeleteMessages(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            int User_ID = 0;
            using (var reader = access.ExecuteReader(Conn, "[Portal_DeleteMessage]", _parameters))
            {
                if (reader.Read())
                {
                    User_ID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region User Profile
        public UserProfile Portal_GetLoggedinUserProfile(int User_ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter _User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            User_IDParameter.Value = User_ID;
            _User_IDParameter.Value = User_ID;
            parameters.Add(User_IDParameter);
            _parameters.Add(_User_IDParameter);

            UserProfile UserProfile = new UserProfile();
            using (var reader = access.ExecuteReader(Conn, "[GetLoggedinUserProfile]", _parameters))
            {
                if (reader.Read())
                {
                    UserProfile.AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel"));
                    if (UserProfile.AccessLevel == 1 || UserProfile.AccessLevel == 2)
                    {
                        return new UserProfile().CreateDoctor(reader);
                    }
                    else if (UserProfile.AccessLevel == 4 || UserProfile.AccessLevel == 5 || UserProfile.AccessLevel == 6)
                    {
                        return new UserProfile().CreateStaff(reader);
                    }

                }
            }
            return UserProfile;
        }
        public bool Portal_UpdateProfileStaff(int User_ID, string FirstName, string LastName, string ID_Number, string Gender, string DOB, string Phone, string Street_Address, string Suburb, string City, string Country)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter LastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter ID_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter GenderParameter = new SqlParameter("@Gender", SqlDbType.Char);
            SqlParameter DOBParameter = new SqlParameter("@DOB", SqlDbType.NVarChar);
            SqlParameter PhoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar);
            SqlParameter Street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter SuburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter CityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter CountryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);

            User_IDParameter.Value = User_ID;
            FirstNameParameter.Value = FirstName;
            LastNameParameter.Value = LastName;
            ID_NumberParameter.Value = ID_Number;
            GenderParameter.Value = Gender;
            DOBParameter.Value = DOB;
            PhoneParameter.Value = Phone;
            Street_AddressParameter.Value = Street_Address;
            SuburbParameter.Value = Suburb;
            CityParameter.Value = City;
            CountryParameter.Value = Country;

            _parameters.Add(User_IDParameter);
            _parameters.Add(FirstNameParameter);
            _parameters.Add(LastNameParameter);
            _parameters.Add(ID_NumberParameter);
            _parameters.Add(GenderParameter);
            _parameters.Add(DOBParameter);
            _parameters.Add(PhoneParameter);
            _parameters.Add(Street_AddressParameter);
            _parameters.Add(SuburbParameter);
            _parameters.Add(CityParameter);
            _parameters.Add(CountryParameter);

            //try
            //{
            access.ExecuteNonQuery(Conn, _parameters, "[UpdateProfileStaff]");
            return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
        public bool Portal_UpdateProfileDoctor(int User_ID, string FirstName, string LastName, string Gender, string Address)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter LastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter GenderParameter = new SqlParameter("@Gender", SqlDbType.Char);
            SqlParameter AddressParameter = new SqlParameter("@Address", SqlDbType.NVarChar);

            User_IDParameter.Value = User_ID;
            FirstNameParameter.Value = FirstName;
            LastNameParameter.Value = LastName;
            GenderParameter.Value = Gender;
            AddressParameter.Value = Address;

            _parameters.Add(User_IDParameter);
            _parameters.Add(FirstNameParameter);
            _parameters.Add(LastNameParameter);
            _parameters.Add(GenderParameter);
            _parameters.Add(AddressParameter);

            //try
            //{
            access.ExecuteNonQuery(Conn, _parameters, "[UpdateProfileDoctor]");
            return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public UserProfile Portal_GetPassword(int User_ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            User_IDParameter.Value = User_ID;
            parameters.Add(User_IDParameter);

            UserProfile UserProfile = new UserProfile();
            using (var reader = access.ExecuteReader(Conn, "[GetPassword]", parameters))
            {
                if (reader.Read())
                {
                    return new UserProfile().GetPassword(reader);
                }
            }
            return UserProfile;
        }

        public bool Portal_UpdatePassword(int User_ID, string Password)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter PasswordParameter = new SqlParameter("@Password", SqlDbType.NVarChar);

            User_IDParameter.Value = User_ID;
            PasswordParameter.Value = Password;

            _parameters.Add(User_IDParameter);
            _parameters.Add(PasswordParameter);

            //try
            //{
            access.ExecuteNonQuery(Conn, _parameters, "[UpdatePassword]");
            return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
        #endregion
    }
}
