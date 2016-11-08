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
    public class DataLayerAccess
    {
        private DataAccess access;
        private List<SqlParameter> _parameters = new List<SqlParameter>();
        private string Conn;
        private int LoggedIn_User_AccessLevel;
        private int LoggedIn_User_PRACTICE_ID;

        public DataLayerAccess()
        {
            access = new DataAccess();
            LoggedIn_User_AccessLevel = 1;
            LoggedIn_User_PRACTICE_ID = 1;
            Conn = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public List<Appointments> GetAppointments()
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_IDParameter.Value = LoggedIn_User_PRACTICE_ID;
            _parameters.Add(Practice_IDParameter);

            DateTime Today = DateTime.Now;
            DateTime Tomorrow = DateTime.Today.AddDays(+1);
            DateTime Tomorrow2 = DateTime.Today.AddDays(+2);
            Appointments AppointmentInfo = new Appointments(); int numTodayApps = 0; int numTomorrowApps = 0;
            List<Appointments> AppointmentsInfo = new List<Appointments>();

            try
            {
                if (LoggedIn_User_AccessLevel == 1)
                {
                    using (var reader = access.ExecuteReader(Conn, "[GetAllAppointments]", new List<SqlParameter>()))
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
                }
                else
                {
                    using (var reader = access.ExecuteReader(Conn, "[GetAllAppointmentsPrac]", _parameters))
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
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed appointments page");
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view selected appointment " + ex.ToString());
            }
            return AppointmentsInfo;
        }

        public Appointments GetAppointmentById(int AppId)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter appIdParameter = new SqlParameter("@AppId", SqlDbType.Int);
            appIdParameter.Value = AppId;
            _parameters.Add(appIdParameter);
            Appointments AppointmentsInfo = new Appointments();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAppointmentById]", _parameters))
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

        public bool NewAppointment(string Date_Time, int Patient_ID, string Details, int App_Status, int DoctorID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter App_StatusParameter = new SqlParameter("@App_Status", SqlDbType.Bit);
            SqlParameter DetailsParameter = new SqlParameter("@Details", SqlDbType.NVarChar);
            SqlParameter Date_TimeParameter = new SqlParameter("@Date_Time", SqlDbType.NVarChar);
            SqlParameter Patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter DoctorIDParameter = new SqlParameter("@Doctor_ID", SqlDbType.NVarChar);

            App_StatusParameter.Value = App_Status;
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
                using (var reader = access.ExecuteReader(Conn, "[InsertAppointment]", parameters))
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

        public bool UpdateAppointment(int ID, string Date_Time, int Patient_ID, string Details, int App_Status, int DoctorID)
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
                access.ExecuteNonQuery(Conn, parameters, "[UpdateAppointment]");
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Updated appointment record");
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to update appointment record: " + ex.ToString());
                return false;
            }
        }

        public bool DeleteAppointment(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[DeleteAppointment]", _parameters))
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

        public Patient GetPatientInfoByID(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            Patient patientInfo = new Patient();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetPatientInfoByID]", _parameters))
                {
                    patientInfo = (new Patient()).Create(reader);
                }

            }
            catch (Exception e)
            {
                string temp = e.ToString();
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view selected patient's medical record: " + ex.ToString());
            }
            return patientInfo;
        }

        public List<Practice> GetAllPractices()
        {
            List<Practice> PracticeInfo = new List<Practice>();
            using (var reader = access.ExecuteReader(Conn, "[GetAllPractices]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    PracticeInfo.Add(new Practice().Create(reader));
                }
            }
            return PracticeInfo;
        }

        public Practice GetPracticeById(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Practice PracticeInfo = new Practice();
            using (var reader = access.ExecuteReader(Conn, "[GetPracticeById]", _parameters))
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

        public List<Doctor> GetAllDoctors()
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
        public Doctor GetDoctorById(int Id)
        {
            List<SqlParameter> _parameter = new List<SqlParameter>();
            SqlParameter IdParameter = new SqlParameter("@Id", SqlDbType.Int);
            IdParameter.Value = Id;
            _parameter.Add(IdParameter);

            Doctor DoctorsInfo = new Doctor();
            //try
            //{
            using (var reader = access.ExecuteReader(Conn, "[GetDoctorById]", _parameter))
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
    }
}
