using ObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataClient
{
    public class DataLayer : IDataLayer
    {
        private DataAccess access; 
        private List<SqlParameter> _parameters = new List<SqlParameter>();
        private string Conn = @"Data Source=DESKTOP-6Gu3I3G\SQLEXPRESS;Initial Catalog=DoConnect;Integrated Security=True";
        //private string Conn = @"Server=tcp:doconnect.database.windows.net,1433;Initial Catalog=DoConnect;Persist Security Info=False;User ID=teamCogent;Password=DoConnect1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public DataLayer()
        {
            access = new DataAccess();            
        }

        #region
        public int CreateUser(int AccessLevel)
        {
            int userId = 0;
            SqlParameter levelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            levelParameter.Value = AccessLevel;

            try
            {
                using (var reader = access.ExecuteReader(Conn, "[CreateUser]", new List<SqlParameter>() { levelParameter }))
                {
                    if (reader.Read())
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            catch (Exception)
            {

            }
            return userId;
        }
        
        public static int LoggedIn_User_ID;
        public Login MyLogin(string Email, string Password)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            List<SqlParameter> _parametersLog_LastLoginTime = new List<SqlParameter>();
            SqlParameter EmailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);
            SqlParameter PasswordParameter = new SqlParameter("@Password", SqlDbType.NVarChar);
            EmailParameter.Value = Email;
            PasswordParameter.Value = Password;
            _parameters.Add(EmailParameter);
            _parameters.Add(PasswordParameter);

            Login Login = new Login();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[Login]", _parameters))
                {
                    if (reader.Read())
                    {
                        Login = (new Login().Create(reader));
                        int ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        if (ID != 0)
                        {
                            DateTime DateTime = DateTime.Now;
                            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
                            SqlParameter DateTimeParameter = new SqlParameter("@Last_Login", SqlDbType.DateTime);
                            IDParameter.Value = ID;
                            DateTimeParameter.Value = Convert.ToDateTime(DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            LoggedIn_User_ID = ID;
                            DateTime DT = Convert.ToDateTime(DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            _parametersLog_LastLoginTime.Add(IDParameter);
                            _parametersLog_LastLoginTime.Add(DateTimeParameter);
                            access.ExecuteReader(Conn, "[Log_LastLoginTime]", _parametersLog_LastLoginTime);                            
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return Login;
        }

        public static int LoggedIn_User_PRACTICE_ID, LoggedIn_User_AccessLevel, COUNT = 0; public static string LoggedIn_Name, LoggedIn_User_strAccessLevel;
        public Staff GetUserDetailsByUser_ID()
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            User_IDParameter.Value = LoggedIn_User_ID;
            _parameters.Add(User_IDParameter);

            Staff List = new Staff();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetUserDetailsByUser_ID]", _parameters))
                {
                    if (reader.Read())
                    {
                        LoggedIn_Name = reader.GetString(reader.GetOrdinal("FirstName"))+" "+ reader.GetString(reader.GetOrdinal("LastName"))+" "+ reader.GetString(reader.GetOrdinal("Email"));
                        LoggedIn_User_PRACTICE_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID"));
                        LoggedIn_User_AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel"));

                        if (LoggedIn_User_AccessLevel == 1)
                        {
                            LoggedIn_User_strAccessLevel = "Admin";
                        }
                        else if (LoggedIn_User_AccessLevel == 2)
                        {
                            LoggedIn_User_strAccessLevel = "Doctor";
                        }
                        else if (LoggedIn_User_AccessLevel == 3)
                        {
                            LoggedIn_User_strAccessLevel = "Receptionist";
                        }
                        else if (LoggedIn_User_AccessLevel == 5)
                        {
                            LoggedIn_User_strAccessLevel = "Nurse";
                        }
                        else
                        {
                            LoggedIn_User_strAccessLevel = "Assistant";
                        }

                        List = new Staff().GetLogginUser(reader);
                        if (COUNT == 0)
                        {
                            //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Logged in");
                            COUNT = 1;
                        }                        
                    }
                }
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed: " + ex.ToString());
            }
            return List;
        }

        public List<AccessLevel> GetAllAccessLevel()
        {
            List<AccessLevel> List = new List<AccessLevel>();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAllAccessLevel]", new List<SqlParameter>()))
                {
                    while (reader.Read())
                    {
                        List.Add(new AccessLevel().Create(reader));
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return List;
        }

        public AccessLevel GetAccessLevelById(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            AccessLevel Item = new AccessLevel();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAccessLevelById]", _parameters))
                {
                    if (reader.Read())
                    {
                        Item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        Item.Level = reader.GetString(reader.GetOrdinal("Level"));
                    }
                }
            }
            catch (Exception)
            {

            }
            return Item;
        }
        #endregion

        #region Expense
        public List<Expenses> GetAllExpenses()
        {
            Expenses ExpenseInfo = new Expenses();
            List<Expenses> ExpensesInfo = new List<Expenses>();

            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAllExpenses]", new List<SqlParameter>()))
                {
                    while (reader.Read())
                    {
                        List<SqlParameter> _parameters = new List<SqlParameter>();
                        SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
                        User_IDParameter.Value = reader.GetInt32(reader.GetOrdinal("User_ID"));
                        _parameters.Add(User_IDParameter);
                        ExpenseInfo = new Expenses();

                        try
                        {
                            using (var readerUserDoc = access.ExecuteReader(Conn, "[GetAllExpensesUsersDoc]", _parameters))
                            {
                                if (readerUserDoc.Read())
                                {
                                    ExpenseInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                    ExpenseInfo.Description = reader.GetString(reader.GetOrdinal("Description"));
                                    ExpenseInfo.Date = reader.GetString(reader.GetOrdinal("Date"));
                                    ExpenseInfo.Amount = reader.GetString(reader.GetOrdinal("Amount"));
                                    ExpenseInfo.Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID"));
                                    ExpenseInfo.Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name"));
                                    ExpenseInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                                    ExpenseInfo.DoctorFullName = readerUserDoc.GetString(readerUserDoc.GetOrdinal("DoctorFullName"));                                    
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view expenses: " + ex.ToString());
                        }

                        List<SqlParameter> parametersStaff = new List<SqlParameter>();
                        SqlParameter User_IDParameterStaff = new SqlParameter("@User_ID", SqlDbType.Int);
                        User_IDParameterStaff.Value = reader.GetInt32(reader.GetOrdinal("User_ID"));
                        parametersStaff.Add(User_IDParameterStaff);

                        try
                        {
                            using (var readerUserStaff = access.ExecuteReader(Conn, "[GetAllExpensesUsersStaff]", parametersStaff))
                            {
                                if (readerUserStaff.Read())
                                {
                                    ExpenseInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                    ExpenseInfo.Description = reader.GetString(reader.GetOrdinal("Description"));
                                    ExpenseInfo.Date = reader.GetString(reader.GetOrdinal("Date"));
                                    ExpenseInfo.Amount = reader.GetString(reader.GetOrdinal("Amount"));
                                    ExpenseInfo.Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID"));
                                    ExpenseInfo.Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name"));
                                    ExpenseInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                                    ExpenseInfo.StaffFullName = readerUserStaff.GetString(readerUserStaff.GetOrdinal("StaffFullName"));
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view expenses: " + ex.ToString());
                        }
                        ExpensesInfo.Add(ExpenseInfo);
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed expenses page");
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view expenses: " + ex.ToString());
            }
            return ExpensesInfo;
        }
        public Expenses GetExpenseById(int ID)
        {
            List<SqlParameter> _parametersGetExpense = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parametersGetExpense.Add(IDParameter);

            Expenses ExpenseInfo = new Expenses();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetExpenseByID]", _parametersGetExpense))
                {
                    while (reader.Read())
                    {
                        List<SqlParameter> _parameters = new List<SqlParameter>();
                        SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
                        User_IDParameter.Value = reader.GetInt32(reader.GetOrdinal("User_ID"));
                        _parameters.Add(User_IDParameter);

                        using (var readerUserDoc = access.ExecuteReader(Conn, "[GetAllExpensesUsersDoc]", _parameters))
                        {
                            if (readerUserDoc.Read())
                            {
                                ExpenseInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                ExpenseInfo.Description = reader.GetString(reader.GetOrdinal("Description"));
                                ExpenseInfo.Date = reader.GetString(reader.GetOrdinal("Date"));
                                ExpenseInfo.Amount = reader.GetString(reader.GetOrdinal("Amount"));
                                ExpenseInfo.Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID"));
                                ExpenseInfo.Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name"));
                                ExpenseInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                                ExpenseInfo.DoctorFullName = readerUserDoc.GetString(readerUserDoc.GetOrdinal("DoctorFullName"));
                            }
                        }

                        List<SqlParameter> parametersStaff = new List<SqlParameter>();
                        SqlParameter User_IDParameterStaff = new SqlParameter("@User_ID", SqlDbType.Int);
                        User_IDParameterStaff.Value = reader.GetInt32(reader.GetOrdinal("User_ID"));
                        parametersStaff.Add(User_IDParameterStaff);

                        using (var readerUserStaff = access.ExecuteReader(Conn, "[GetAllExpensesUsersStaff]", parametersStaff))
                        {
                            if (readerUserStaff.Read())
                            {
                                ExpenseInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                ExpenseInfo.Description = reader.GetString(reader.GetOrdinal("Description"));
                                ExpenseInfo.Date = reader.GetString(reader.GetOrdinal("Date"));
                                ExpenseInfo.Amount = reader.GetString(reader.GetOrdinal("Amount"));
                                ExpenseInfo.Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID"));
                                ExpenseInfo.Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name"));
                                ExpenseInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                                ExpenseInfo.StaffFullName = readerUserStaff.GetString(readerUserStaff.GetOrdinal("StaffFullName"));                                
                            }
                        }
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed expense record");
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view selected expense: " + ex.ToString());
            }
            return ExpenseInfo;
        }
        public Expenses GetPracticeIDByUser_ID(int User_ID)
        {
            List<SqlParameter> _parametersPracticeID = new List<SqlParameter>();
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            User_IDParameter.Value = User_ID;
            _parametersPracticeID.Add(User_IDParameter);

            Expenses PracticeID = new Expenses();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetPracticeIDByUser_ID]", _parametersPracticeID))
                {
                    if (reader.Read())
                    {
                        PracticeID.Practice_ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    }
                }
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to select practice details: " + ex.ToString());
            }
            return PracticeID;
        }
        public bool NewExpense(string Description, string Date, string Amount, int Practice_ID, int User_ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter DescriptionParameter = new SqlParameter("@Description", SqlDbType.NVarChar);
            SqlParameter DateParameter = new SqlParameter("@Date", SqlDbType.NVarChar);
            SqlParameter AmountParameter = new SqlParameter("@Amount", SqlDbType.NVarChar);
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            DescriptionParameter.Value = Description;
            parameters.Add(DescriptionParameter);
            DateParameter.Value = Date;
            parameters.Add(DateParameter);
            AmountParameter.Value = Amount;
            parameters.Add(AmountParameter);
            Practice_IDParameter.Value = Practice_ID;
            parameters.Add(Practice_IDParameter);
            User_IDParameter.Value = User_ID;
            parameters.Add(User_IDParameter);

            try
            {
                access.ExecuteNonQuery(Conn, parameters, "[InsertExpense]");
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Created a new expense entry");
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to insert a new expense: " + ex.ToString());
                return false;
            }
        }
        public bool UpdateExpense(int ID, string Description, string Amount)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter DescriptionParameter = new SqlParameter("@Description", SqlDbType.NVarChar);
            SqlParameter AmountParameter = new SqlParameter("@Amount", SqlDbType.NVarChar);
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);

            IDParameter.Value = ID;
            parameters.Add(IDParameter);
            DescriptionParameter.Value = Description;
            parameters.Add(DescriptionParameter);
            AmountParameter.Value = Amount;
            parameters.Add(AmountParameter);

            try
            {
                access.ExecuteNonQuery(Conn, parameters, "[UpdateExpense]");
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Updated expense record: ID: "+ ID);
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to Updated expense record: ID: " + ID+"\n" + ex.ToString());
                return false;
            }
        }
        public bool DeleteExpense(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            int DeletedID = 0;
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[DeleteExpense]", _parameters))
                {
                    if (reader.Read())
                    {
                        DeletedID = reader.GetInt32(reader.GetOrdinal("ID"));
                       //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Deleted expense record: ID: " + ID);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to deleted expense record: ID: " + ID+"\n" + ex.ToString());
                return false;
            }
        }
        #endregion

        #region Appointments
        public List<Appointments> GetAppointments()
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_IDParameter.Value = LoggedIn_User_PRACTICE_ID;
            _parameters.Add(Practice_IDParameter);

            DateTime Today = DateTime.Now;
            DateTime Today0 = DateTime.Today.AddDays(0);
            DateTime Yesterday2 = DateTime.Today.AddDays(-2);
            DateTime Yesterday = DateTime.Today.AddDays(-1);
            DateTime Tomorrow = DateTime.Today.AddDays(+1);
            DateTime Tomorrow2 = DateTime.Today.AddDays(+2);
            Appointments AppointmentInfo = new Appointments(); int numYesterdayApps = 0; int numTodayApps = 0; int numTomorrowApps = 0;
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
                            else if ((Tomorrow < Appointments_Date_Time) && (Appointments_Date_Time < Tomorrow2))
                            {
                                AppointmentInfo.highlightTomorrowApps = 1;
                                numTomorrowApps++;                            
                            }
                            else if ((Appointments_Date_Time > Convert.ToDateTime("2016-11-06")) && (Appointments_Date_Time < Convert.ToDateTime("2016-11-08")))
                            {
                                AppointmentInfo.highlightYesterdayApps = 1;
                                numYesterdayApps++;
                            }

                            AppointmentInfo.numTodayApps = numTodayApps;
                            AppointmentInfo.numYesterdayApps = numYesterdayApps;
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
        #endregion

        #region Consultation
        public List<Consultation> GetAllConsultations()
        {
            List<Consultation> consultationInfo = new List<Consultation>();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAllConsultations]", new List<SqlParameter>()))
                {
                    while (reader.Read())
                    {
                        consultationInfo.Add(new Consultation().Create(reader));
                    }
                }
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed retrive consulation details: " + ex.ToString());
            }
            return consultationInfo;
        }

        public List<Consultation> ViewUnInvoicedConsultations()
        {
            List<Consultation> consultationInfo = new List<Consultation>();
            //try
            //{
                using (var reader = access.ExecuteReader(Conn, "[ViewUnInvoicedConsultations]", new List<SqlParameter>()))
                {
                    while (reader.Read())
                    {
                        consultationInfo.Add(new Consultation().ViewUnInvoicedConsultations(reader));
                    }
                }
            //}
            //catch (Exception)
            //{
            //    //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed retrive consulation details: " + ex.ToString());
            //}
            return consultationInfo;
        }

        public List<Consultation> GetConsultationByPatientId(int id)//Get Consultation Notes by Patient ID
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            List<Consultation> consultationInfo = new List<Consultation>();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetConsultationNotes]", _parameters))
                {
                    while (reader.Read())
                    {
                        consultationInfo.Add(new Consultation().Create(reader));
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed patient's consultation notes");
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view patient's consultation notes: " + ex.ToString());
            }
            return consultationInfo;
        }

        public bool NewConsultationNote(int patient_ID, int doctor_ID, string reasonForConsulta, string symptoms, string clinicalFindings, string diagnosis, string testResultSummary, string treatmentPlan, int presciption_ID, int referral_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            List<SqlParameter> Patient_Consultation_parameters = new List<SqlParameter>();
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter reasonForConsultaParameter = new SqlParameter("@ReasonForConsultation", SqlDbType.NVarChar);
            SqlParameter symptomsParameter = new SqlParameter("@Symptoms", SqlDbType.NVarChar);
            SqlParameter clinicalFindingsParameter = new SqlParameter("@ClinicalFindings", SqlDbType.NVarChar);
            SqlParameter diagnosisParameter = new SqlParameter("@Diagnosis", SqlDbType.NVarChar);
            SqlParameter testResultSummaryParameter = new SqlParameter("@TestResultSummary", SqlDbType.NVarChar);
            SqlParameter treatmentPlanParameter = new SqlParameter("@TreatmentPlan", SqlDbType.NVarChar);
            SqlParameter presciption_IDParameter = new SqlParameter("@Presciption_ID", SqlDbType.Int);
            SqlParameter referral_IDParameter = new SqlParameter("@Referral_ID", SqlDbType.Int);
            SqlParameter insertedConsultationParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter insertedpatient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);

            patient_IDParameter.Value = patient_ID;
            doctor_IDParameter.Value = doctor_ID;
            reasonForConsultaParameter.Value = reasonForConsulta;
            symptomsParameter.Value = symptoms;
            clinicalFindingsParameter.Value = clinicalFindings;
            diagnosisParameter.Value = diagnosis;
            testResultSummaryParameter.Value = testResultSummary;
            treatmentPlanParameter.Value = treatmentPlan;
            presciption_IDParameter.Value = presciption_ID;
            referral_IDParameter.Value = referral_ID;

            _parameters.Add(patient_IDParameter);
            _parameters.Add(doctor_IDParameter);
            _parameters.Add(reasonForConsultaParameter);
            _parameters.Add(symptomsParameter);
            _parameters.Add(clinicalFindingsParameter);
            _parameters.Add(diagnosisParameter);
            _parameters.Add(testResultSummaryParameter);
            _parameters.Add(treatmentPlanParameter);
            _parameters.Add(presciption_IDParameter);
            _parameters.Add(referral_IDParameter);

            insertedpatient_IDParameter.Value = patient_ID;
            Patient_Consultation_parameters.Add(insertedpatient_IDParameter);

            try
            {
                int insertedConsultationID = 0;
                using (var reader = access.ExecuteReader(Conn, "[InsertPatient_Consultation]", Patient_Consultation_parameters))
                {
                    if (reader.Read())
                    {
                        using (var readerInsertConsultationNote = access.ExecuteReader(Conn, "[InsertConsultationNote]", _parameters))
                        {
                            if (reader.Read())
                            {
                                insertedConsultationID = readerInsertConsultationNote.GetInt32(reader.GetOrdinal("ID"));
                            }
                        }
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Recorded new consultation notes");
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to record new consultation notes: " + ex.ToString());
	            return false;
            }
        }

        public bool UpdateConsultationNote(int consultationID, string reasonForConsulta, string symptoms, string clinicalFindings, string diagnosis, string testResultSummary, string treatmentPlan)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter consultationIDParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter reasonForConsultaParameter = new SqlParameter("@ReasonForConsultation", SqlDbType.NVarChar);
            SqlParameter symptomsParameter = new SqlParameter("@Symptoms", SqlDbType.NVarChar);
            SqlParameter clinicalFindingsParameter = new SqlParameter("@ClinicalFindings", SqlDbType.NVarChar);
            SqlParameter diagnosisParameter = new SqlParameter("@Diagnosis", SqlDbType.NVarChar);
            SqlParameter testResultSummaryParameter = new SqlParameter("@TestResultSummary", SqlDbType.NVarChar);
            SqlParameter treatmentPlanParameter = new SqlParameter("@TreatmentPlan", SqlDbType.NVarChar);

            consultationIDParameter.Value = consultationID;
            reasonForConsultaParameter.Value = reasonForConsulta;
            symptomsParameter.Value = symptoms;
            clinicalFindingsParameter.Value = clinicalFindings;
            diagnosisParameter.Value = diagnosis;
            testResultSummaryParameter.Value = testResultSummary;
            treatmentPlanParameter.Value = treatmentPlan;

            _parameters.Add(consultationIDParameter);
            _parameters.Add(reasonForConsultaParameter);
            _parameters.Add(symptomsParameter);
            _parameters.Add(clinicalFindingsParameter);
            _parameters.Add(diagnosisParameter);
            _parameters.Add(testResultSummaryParameter);
            _parameters.Add(treatmentPlanParameter);

            try
            {
                access.ExecuteNonQuery(Conn, _parameters, "[UpdateConsultationNote]");
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Updated consultation note: ID: " + consultationID);
                return true;
            }
            catch (Exception)
            {            
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to updated consultation note: ID: " + consultationID + "\n" + ex.ToString());
            	return false;
            }
        }


        public bool UpdateUnInvoicedConsultations(int consultationID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter consultationIDParameter = new SqlParameter("@ID", SqlDbType.Int);
            consultationIDParameter.Value = consultationID;
            _parameters.Add(consultationIDParameter);

            using (var reader = access.ExecuteReader(Conn, "[UpdateUnInvoicedConsultations]", _parameters))
            {

            }
                return true; 
        }

        public bool UpdateConsultation_AddAdditionalFee(decimal Additionalfee, string InvoiceDocMessage)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter AdditionalfeeParameter = new SqlParameter("@Additionalfee", SqlDbType.Decimal);
            SqlParameter InvoiceDocMessageParameter = new SqlParameter("@InvoiceDocMessage", SqlDbType.NVarChar);
            AdditionalfeeParameter.Value = Additionalfee;
            InvoiceDocMessageParameter.Value = InvoiceDocMessage;
            _parameters.Add(AdditionalfeeParameter);
            _parameters.Add(InvoiceDocMessageParameter);

            int lastConsultationID = 0;
            using (var reader = access.ExecuteReader(Conn, "[lastAddedConsultation]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    lastConsultationID = reader.GetInt32(reader.GetOrdinal("ID"));
                    
                    SqlParameter lastConsultationIDParameter = new SqlParameter("@lastConsultationID", SqlDbType.Int);
                    lastConsultationIDParameter.Value = lastConsultationID;
                    _parameters.Add(lastConsultationIDParameter);

                    using (var readerupdate = access.ExecuteReader(Conn, "[UpdateConsultation_AddAdditionalFee]", _parameters))
                    {

                    }
                }
            }            
            return true;
        }

        public bool DeleteConsultation(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            int userId = 0;
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[DeleteConsultation]", _parameters))
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(reader.GetOrdinal("ID"));
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Deleted consultation note: ID: " + id);
                return true;
            }
            catch (Exception)
            {            
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to delete consultation note: ID: " + id +"\n" + ex.ToString());
            	return false;
            }
        }

        #endregion

        #region Invoice
        public List<Invoice> GetAllInvoices()
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_IDParameter.Value = LoggedIn_User_PRACTICE_ID;
            _parameters.Add(Practice_IDParameter);

            Invoice invoice = new Invoice(); int numOfUnPaid = 0; int numOfPatiallyPaid = 0;
            List<Invoice> invoiceInfo = new List<Invoice>();
            try
            {
                if (LoggedIn_User_AccessLevel == 1)
                {
                    using (var reader = access.ExecuteReader(Conn, "[GetAllInvoices]", new List<SqlParameter>()))
                    {
                        while (reader.Read())
                        {
                            invoice.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                            invoice.InvoiceSummary = reader.GetString(reader.GetOrdinal("InvoiceSummary"));
                            invoice.Date = reader.GetString(reader.GetOrdinal("Date"));
                            invoice.Total = reader.GetDecimal(reader.GetOrdinal("Total"));
                            invoice.BalanceOwing = reader.GetDecimal(reader.GetOrdinal("BalanceOwing"));
                            invoice.PaidStatus = reader.GetInt32(reader.GetOrdinal("PaidStatus"));
                            invoice.Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID"));
                            invoice.Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID"));
                            invoice.Patient_FirstName = reader.GetString(reader.GetOrdinal("Patient_FirstName"));
                            invoice.Patient_LastName = reader.GetString(reader.GetOrdinal("Patient_LastName"));
                            invoice.Patient_Email = reader.GetString(reader.GetOrdinal("Patient_Email"));
                            invoice.Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID"));
                            invoice.Doctor_FirstName = reader.GetString(reader.GetOrdinal("Doctor_FirstName"));
                            invoice.Doctor_LastName = reader.GetString(reader.GetOrdinal("Doctor_LastName"));
                            invoice.Doctor_Email = reader.GetString(reader.GetOrdinal("Doctor_Email"));
                                //0 == Unpaid, 1 == Fully-Paid, 2 == Partially-Paid
                            if (reader.GetInt32(reader.GetOrdinal("PaidStatus")) == 0)
                            {
                                numOfUnPaid++;
                            }
                            invoice.numOfUnPaid = numOfUnPaid;
                            if (reader.GetInt32(reader.GetOrdinal("PaidStatus")) == 2)
                            {
                                numOfPatiallyPaid++;
                            }
                            invoice.numOfPatiallyPaid = numOfPatiallyPaid;
                            invoiceInfo.Add(invoice); invoice = new Invoice();
                        }
                    }
                }
                else
                {
                    using (var reader = access.ExecuteReader(Conn, "[GetAllInvoicesPrac]", _parameters))
                    {
                        while (reader.Read())
                        {
                            invoice.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                            invoice.InvoiceSummary = reader.GetString(reader.GetOrdinal("InvoiceSummary"));
                            invoice.Date = reader.GetString(reader.GetOrdinal("Date"));
                            invoice.Total = reader.GetDecimal(reader.GetOrdinal("Total"));
                            invoice.BalanceOwing = reader.GetDecimal(reader.GetOrdinal("BalanceOwing"));
                            invoice.PaidStatus = reader.GetInt32(reader.GetOrdinal("PaidStatus"));
                            invoice.Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID"));
                            invoice.Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID"));
                            invoice.Patient_FirstName = reader.GetString(reader.GetOrdinal("Patient_FirstName"));
                            invoice.Patient_LastName = reader.GetString(reader.GetOrdinal("Patient_LastName"));
                            invoice.Patient_Email = reader.GetString(reader.GetOrdinal("Patient_Email"));
                            invoice.Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID"));
                            invoice.Doctor_FirstName = reader.GetString(reader.GetOrdinal("Doctor_FirstName"));
                            invoice.Doctor_LastName = reader.GetString(reader.GetOrdinal("Doctor_LastName"));
                            invoice.Doctor_Email = reader.GetString(reader.GetOrdinal("Doctor_Email"));
                        
                            if (reader.GetInt32(reader.GetOrdinal("PaidStatus")) == 0)
                            {
                                numOfUnPaid++;
                            }
                            invoice.numOfUnPaid = numOfUnPaid;
                            if (reader.GetInt32(reader.GetOrdinal("PaidStatus")) == 2)
                            {
                                numOfPatiallyPaid++;
                            }
                            invoice.numOfPatiallyPaid = numOfPatiallyPaid;
                            invoiceInfo.Add(invoice); invoice = new Invoice();
                        }
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed invoice page");
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view invoice page: " + ex.ToString());
            }
            return invoiceInfo;
        }

        public Invoice GetInvoiceById(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            Invoice invoiceInfo = new Invoice();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetInvoiceById]", _parameters))
                {
                    if (reader.Read())
                    {
                        return new Invoice().ViewInvoiceByID(reader);
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed invoice record");
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view selected invoice: " + ex.ToString());
            }
            return invoiceInfo;
        }
        public List<GetAllPatients> GetAllPatientsForInvoice()
        {
            List<GetAllPatients> patientInfo = new List<GetAllPatients>();
            
            using (var reader = access.ExecuteReader(Conn, "[GetAllPatientsForInvoice]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    patientInfo.Add(new GetAllPatients().Create(reader));
                }
            }            
            return patientInfo;
        }

        public List<Invoice> GetAllDiagnosisByPatientID(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            List<Invoice> invoiceInfo = new List<Invoice>();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAllDiagnosisByPatientID]", _parameters))
                {
                    while (reader.Read())
                    {
                        invoiceInfo.Add(new Invoice().GetAllDiagnosisByPatientID(reader));
                    }
                }
            }
            catch (Exception)
            {

            }
            return invoiceInfo;
        }

        public bool NewInvoice(string Date, string InvoiceSummary, decimal Total, decimal AmountPaid, int Medical_Aid_ID, int Patient_ID, int Doctor_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter dateParameter = new SqlParameter("@Date", SqlDbType.NVarChar);
            SqlParameter invoiceSummaryParameter = new SqlParameter("@InvoiceSummary", SqlDbType.NVarChar);
            SqlParameter totalParameter = new SqlParameter("@Total", SqlDbType.Decimal);
            SqlParameter AmountPaidParameter = new SqlParameter("@AmountPaid", SqlDbType.Decimal);
            SqlParameter BalanceOwingParameter = new SqlParameter("@BalanceOwing", SqlDbType.Decimal);
            SqlParameter PaidStatusParameter = new SqlParameter("@PaidStatus", SqlDbType.Int);
            SqlParameter medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);

            dateParameter.Value = Date;
            invoiceSummaryParameter.Value = InvoiceSummary;
            totalParameter.Value = Total;
            AmountPaidParameter.Value = AmountPaid;
            BalanceOwingParameter.Value = Convert.ToDecimal(Total - AmountPaid);

            if (AmountPaid == 0)//0 == Unpaid, 1 == Fully-Paid, 2 == Partially-Paid
            { PaidStatusParameter.Value = 0; }
            else if ((AmountPaid > 0) && (AmountPaid < Total))
            { PaidStatusParameter.Value = 2; }
            else
            { PaidStatusParameter.Value = 1; }

            medical_Aid_IDParameter.Value = Medical_Aid_ID;
            patient_IDParameter.Value = Patient_ID;
            doctor_IDParameter.Value = Doctor_ID;

            _parameters.Add(dateParameter);
            _parameters.Add(invoiceSummaryParameter);
            _parameters.Add(totalParameter);
            _parameters.Add(AmountPaidParameter);
            _parameters.Add(BalanceOwingParameter);
            _parameters.Add(PaidStatusParameter);
            _parameters.Add(medical_Aid_IDParameter);
            _parameters.Add(patient_IDParameter);
            _parameters.Add(doctor_IDParameter);

            int insertedID = 0;
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[InsertInvoice]", _parameters))
                {
                    if (reader.Read())
                    {
                        insertedID = reader.GetInt32(reader.GetOrdinal("ID"));                        
                        Email.SendEmail("josephine.chivinge@gmail.com", "Consultation Invoice", "Your account has been billed with the consultation fee amount of R "+ Total+ ".\nA total amount of R "+Convert.ToDecimal(Total - AmountPaid)+" has been credited to your account.","");
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Recorded new invoice entry");
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to record new invoice entry: " + ex.ToString());
                return false;
            }
        }

        public bool DeleteInvoice(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            int DeletedID = 0;
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[DeleteInvoice]", _parameters))
                {
                    if (reader.Read())
                    {
                        DeletedID = reader.GetInt32(reader.GetOrdinal("ID"));
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Deleted invoice entry: ID: " + id);
                return true;
            }
            catch (Exception)
            {            
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to delete invoice entry: ID: " + id+"\n" + ex.ToString());
            	return false;
            }
        }
        #endregion

        #region patient
        public int NewUpdatePatient(string firstName, string lastName, string id_Number, string gender, string dob, string cell_number, string street_address, string suburb, string city, string country)
        {
            int userId = 0;
            _parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.NVarChar);
            SqlParameter cell_numberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            cell_numberParameter.Value = cell_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;

            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(cell_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);

            try
            {
                using (var reader = access.ExecuteReader(Conn, "[NewUpdatePatient]", new List<SqlParameter>()))
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(reader.GetOrdinal("ID"));
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Created new patient's medical record");
                return userId;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to create new patient's medical record: " + ex.ToString());
                return userId;
            }
        }

        public bool CreatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country,
            string Allergies, string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory, int Medical_Aid_ID, int Doctor_ID, int UserId)
        {

            //state params
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.DateTime);
            SqlParameter cell_numberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);

            SqlParameter AllergiesParameter = new SqlParameter("@Allergies", SqlDbType.NVarChar);
            SqlParameter PreviousIllnessesParameter = new SqlParameter("@PreviousIllnesses", SqlDbType.NVarChar);
            SqlParameter PreviousMedicationParameter = new SqlParameter("@PreviousMedication", SqlDbType.NVarChar);
            SqlParameter RiskFactorsParameter = new SqlParameter("@RiskFactors", SqlDbType.NVarChar);
            SqlParameter SocialHistoryParameter = new SqlParameter("@SocialHistory", SqlDbType.NVarChar);
            SqlParameter FamilyHistoryParameter = new SqlParameter("@FamilyHistory", SqlDbType.NVarChar);
            SqlParameter Medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            SqlParameter Doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter UserIdParameter = new SqlParameter("@UserId", SqlDbType.Int);
            //assign values
            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            cell_numberParameter.Value = cell_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            AllergiesParameter.Value = Allergies;
            PreviousIllnessesParameter.Value = PreviousIllnesses;
            PreviousMedicationParameter.Value = PreviousMedication;
            RiskFactorsParameter.Value = RiskFactors;
            SocialHistoryParameter.Value = SocialHistory;
            FamilyHistoryParameter.Value = FamilyHistory;
            Medical_Aid_IDParameter.Value = Medical_Aid_ID;
            Doctor_IDParameter.Value = Doctor_ID;
            UserIdParameter.Value = UserId;
            //add to list
            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(cell_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(AllergiesParameter);
            _parameters.Add(PreviousIllnessesParameter);
            _parameters.Add(PreviousMedicationParameter);
            _parameters.Add(RiskFactorsParameter);
            _parameters.Add(SocialHistoryParameter);
            _parameters.Add(FamilyHistoryParameter);
            _parameters.Add(Medical_Aid_IDParameter);
            _parameters.Add(Doctor_IDParameter);
            _parameters.Add(UserIdParameter);

            try
            {
                access.ExecuteNonQuery(Conn, _parameters, "[CreatePatient]");
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Created new patient's medical record");
                return true;
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to create new patient's medical record: " + ex.ToString());
                return false;
            }
        }

        public List<GetAllPatients> GetAllPatients()
        {
            List<GetAllPatients> patientInfo = new List<GetAllPatients>();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAllPatients]", new List<SqlParameter>()))
                {
                    while (reader.Read())
                    {
                        patientInfo.Add(new GetAllPatients().Create(reader));
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed patients page");
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view patients list: " + ex.ToString());
            }
            return patientInfo;
        }

        public List<GetAllPatients> GetAllPatientsByPracticeID(int PracticeID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter PracticeIDParameter = new SqlParameter("@PracticeID", SqlDbType.Int);
            PracticeIDParameter.Value = PracticeID;
            _parameters.Add(PracticeIDParameter);
            List<GetAllPatients> patientInfo = new List<GetAllPatients>();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAllPatientsByPracticeID]", _parameters))
                {
                    while (reader.Read())
                    {
                        patientInfo.Add(new GetAllPatients().Create(reader));
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed patients page");
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view patients list: " + ex.ToString());
            }
            return patientInfo;
        }

        public List<Patient> GetPatientByID(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            List<Patient> patientInfo = new List<Patient>();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[GetPatientById]", _parameters))
                {
                    while (reader.Read())
                    {
                        patientInfo.Add(new Patient().Create(reader));
                    }
                }
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Viewed patient's medical record");
            }
            catch (Exception)
            {            
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to view selected patient's medical record: " + ex.ToString());
            }
            return patientInfo;
        }        

        public bool DeletePatient(int ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);

            int userId = 0;
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[DeletePatient]", _parameters))
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(reader.GetOrdinal("ID"));
                        //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "Deleted patient's medical record: ID: " + ID);
                        return true;
                    }
                    else
                    {
                        //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to delete patient's medical record: ID: " + ID);
                        return false;
                    }
                }                
            }
            catch (Exception)
            {            
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to delete patient's medical record: ID: " + ID + "\n" + ex.ToString());
	            return false;
            }
        }
        #endregion

        #region patient medical aid
        public int Create_Patient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter scheme_nameParameter = new SqlParameter("@Scheme_Name", SqlDbType.NVarChar);
            SqlParameter member_numberParameter = new SqlParameter("@Membership_Number", SqlDbType.NVarChar);
            SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit);
            SqlParameter registration_dateParameter = new SqlParameter("@Registration_Date", SqlDbType.DateTime);
            SqlParameter deregistrationParameter = new SqlParameter("@Deregistration_Date", SqlDbType.DateTime);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            scheme_nameParameter.Value = scheme_name;
            member_numberParameter.Value = member_number;
            statusParameter.Value = status;
            registration_dateParameter.Value = registration_date;
            deregistrationParameter.Value = deregistration;
            patient_IDParameter.Value = patient_ID;
            medical_Aid_IDParameter.Value = medical_Aid_ID;
            _parameters.Add(scheme_nameParameter);
            _parameters.Add(member_numberParameter);
            _parameters.Add(statusParameter);
            _parameters.Add(registration_dateParameter);
            _parameters.Add(deregistrationParameter);
            _parameters.Add(patient_IDParameter);
            _parameters.Add(medical_Aid_IDParameter);
            int userId = 0;
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[Create_Patient_Medical_Aid]", new List<SqlParameter>()))
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(reader.GetOrdinal("ID"));                       
                    }
                }
            }
            catch (Exception)
            {
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to create new patient's medical aid record: " + ex.ToString());                
            }
            return userId;
        }

        public List<Patient_Medical_Aid> GetAll_Patient_Medical_Aids()
        {
            List<Patient_Medical_Aid> patientInfo = new List<Patient_Medical_Aid>();

            try
            {            
                using (var reader = access.ExecuteReader(Conn, "[GetAll_Patient_Medical_Aids]", new List<SqlParameter>()))
                {
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            patientInfo.Add(new Patient_Medical_Aid().Create(reader));
                        }
                    }
                }
            }
            catch (Exception)
            {}
            return patientInfo;
        }

        public Patient_Medical_Aid Get_Patient_Medical_AidById(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@Patient_Medical_Aid_ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Patient_Medical_Aid patientMedicalAidInfo = new Patient_Medical_Aid();
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[Get_Patient_Medical_Aid]", new List<SqlParameter>()))
                {
                    if (reader.Read())
                    {
                        patientMedicalAidInfo = new Patient_Medical_Aid().Create(reader);
                    }
                }
            }
            catch (Exception)
            {}
            return patientMedicalAidInfo;
        }

        public int NewUpdatePatient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter scheme_nameParameter = new SqlParameter("@Scheme_Name", SqlDbType.NVarChar);
            SqlParameter member_numberParameter = new SqlParameter("@Membership_Number", SqlDbType.NVarChar);
            SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit);
            SqlParameter registration_dateParameter = new SqlParameter("@Registration_Date", SqlDbType.DateTime);
            SqlParameter deregistrationParameter = new SqlParameter("@Deregistration_Date", SqlDbType.DateTime);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            scheme_nameParameter.Value = scheme_name;
            member_numberParameter.Value = member_number;
            statusParameter.Value = status;
            registration_dateParameter.Value = registration_date;
            deregistrationParameter.Value = deregistration;
            patient_IDParameter.Value = patient_ID;
            medical_Aid_IDParameter.Value = medical_Aid_ID;
            _parameters.Add(scheme_nameParameter);
            _parameters.Add(member_numberParameter);
            _parameters.Add(statusParameter);
            _parameters.Add(registration_dateParameter);
            _parameters.Add(deregistrationParameter);
            _parameters.Add(patient_IDParameter);
            _parameters.Add(medical_Aid_IDParameter);

            int userId = 0;
            try
            {                
                using (var reader = access.ExecuteReader(Conn, "[NewUpdatePatient_Medical_Aid]", new List<SqlParameter>()))
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(reader.GetOrdinal("Patient_Medical_Aid_ID"));
                    }
                }
            }
            catch (Exception)
            {}
            return userId;
        }

        public bool Delete_Patient_Medical_Aid(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            int userId = 0;
            try
            {
                using (var reader = access.ExecuteReader(Conn, "[Delete_Patient_Medical_Aid]", new List<SqlParameter>()))
                {
                    if (reader.Read())
                    {
                        userId = reader.GetInt32(reader.GetOrdinal("ID"));
                        return true;
                    }
                }
                return true;
            }
            catch (Exception)
            {            
                //access.LogEntry(LoggedIn_User_ID, LoggedIn_Name, LoggedIn_User_strAccessLevel, "System failed to delete patient's medical aid: ID: " + id+"\n" + ex.ToString());
            	return false;
            }
        }
        #endregion

        #region practice

        public int NewUpdatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.Int);
            SqlParameter cell_numberParameter = new SqlParameter("@Phone_Number", SqlDbType.NVarChar);
            SqlParameter fax_numberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter latitudeParameter = new SqlParameter("@Latitude", SqlDbType.NVarChar);
            SqlParameter longitudeParameter = new SqlParameter("@Longitude", SqlDbType.NVarChar);
            SqlParameter trading_TimesParameter = new SqlParameter("@Trading_Times", SqlDbType.NVarChar);
            nameParameter.Value = name;
            cell_numberParameter.Value = cell_number;
            fax_numberParameter.Value = fax_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            latitudeParameter.Value = latitude;
            longitudeParameter.Value = longitude;
            trading_TimesParameter.Value = trading_Times;
            _parameters.Add(nameParameter);
            _parameters.Add(cell_numberParameter);
            _parameters.Add(fax_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(latitudeParameter);
            _parameters.Add(longitudeParameter);
            _parameters.Add(trading_TimesParameter);

            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[NewUpdatePractice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("PracticeID"));
                }
            }
            return userId;
        }

        public int CreatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            SqlParameter cell_numberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter fax_numberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter latitudeParameter = new SqlParameter("@Latitude", SqlDbType.NVarChar);
            SqlParameter longitudeParameter = new SqlParameter("@Longitude", SqlDbType.NVarChar);
            SqlParameter trading_TimesParameter = new SqlParameter("@Trading_Times", SqlDbType.NVarChar);
            nameParameter.Value = name;
            cell_numberParameter.Value = cell_number;
            fax_numberParameter.Value = fax_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            latitudeParameter.Value = latitude;
            longitudeParameter.Value = longitude;
            trading_TimesParameter.Value = trading_Times;
            _parameters.Add(nameParameter);
            _parameters.Add(cell_numberParameter);
            _parameters.Add(fax_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(latitudeParameter);
            _parameters.Add(longitudeParameter);
            _parameters.Add(trading_TimesParameter);

            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[CreatePractice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return userId;
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

        public bool InsertPractice(string Name, string Phone_Number, string Fax_Number, string Street_Address, string Suburb, string City, string Country, string Latitude, string Longitude, string Trading_Times)
        {
            int ID = 0;
            SqlParameter NameParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            SqlParameter Phone_NumberParameter = new SqlParameter("@Phone_Number", SqlDbType.NVarChar);
            SqlParameter Fax_NumberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter Street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter SuburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter CityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter CountryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter LatitudeParameter = new SqlParameter("@Latitude", SqlDbType.NVarChar);
            SqlParameter LongitudeParameter = new SqlParameter("@Longitude", SqlDbType.NVarChar);
            SqlParameter Trading_TimesParameter = new SqlParameter("@Trading_Times", SqlDbType.NVarChar);

            NameParameter.Value = Name;
            Phone_NumberParameter.Value = Phone_Number;
            Fax_NumberParameter.Value = Fax_Number;
            Street_AddressParameter.Value = Street_Address;
            SuburbParameter.Value = Suburb;
            CityParameter.Value = City;
            CountryParameter.Value = Country;
            LatitudeParameter.Value = Latitude;
            LongitudeParameter.Value = Longitude;
            Trading_TimesParameter.Value = Trading_Times;

            _parameters.Add(NameParameter);
            _parameters.Add(Phone_NumberParameter);
            _parameters.Add(Fax_NumberParameter);
            _parameters.Add(Street_AddressParameter);
            _parameters.Add(SuburbParameter);
            _parameters.Add(CityParameter);
            _parameters.Add(CountryParameter);
            _parameters.Add(LatitudeParameter);
            _parameters.Add(LongitudeParameter);
            _parameters.Add(Trading_TimesParameter);

            using (var reader = access.ExecuteReader(Conn, "[InsertPractice]", new List<SqlParameter>() { NameParameter, Phone_NumberParameter, Fax_NumberParameter, Street_AddressParameter, SuburbParameter, CityParameter, CountryParameter, LatitudeParameter, LongitudeParameter, Trading_TimesParameter }))
            {
                if (reader.Read())
                    ID = reader.GetInt32(reader.GetOrdinal("ID"));
            }
            return true;
        }

        public bool UpdatePractice(int id, string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            SqlParameter phone_numberParameter = new SqlParameter("@Phone_Number", SqlDbType.NVarChar);
            SqlParameter fax_numberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter latitudeParameter = new SqlParameter("@Latitude", SqlDbType.NVarChar);
            SqlParameter longitudeParameter = new SqlParameter("@Longitude", SqlDbType.NVarChar);
            SqlParameter trading_TimesParameter = new SqlParameter("@Trading_Times", SqlDbType.NVarChar);
            idParameter.Value = id;
            nameParameter.Value = name;
            phone_numberParameter.Value = cell_number;
            fax_numberParameter.Value = fax_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            latitudeParameter.Value = latitude;
            longitudeParameter.Value = longitude;
            trading_TimesParameter.Value = trading_Times;
            _parameters.Add(idParameter);
            _parameters.Add(nameParameter);
            _parameters.Add(phone_numberParameter);
            _parameters.Add(fax_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(latitudeParameter);
            _parameters.Add(longitudeParameter);
            _parameters.Add(trading_TimesParameter);

            access.ExecuteNonQuery(Conn, _parameters, "[UpdatePractice]");
            return true;
        }

        public bool DeletePractice(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            using (var reader = access.ExecuteReader(Conn, "[DeletePractice]", _parameters))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region Medical Record
        public MedicalRecord GetMedicalRecordByPatientID(int id)
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

        public List<Medical_Aid> GetMedical_Aid()
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            List<Medical_Aid> MedicalRecordInfo = new List<Medical_Aid>();
            using (var reader = access.ExecuteReader(Conn, "[GetMedical_Aid]", _parameters))
            {
                while (reader.Read())
                {
                    MedicalRecordInfo.Add(new Medical_Aid().Create(reader));
                }
            }
            return MedicalRecordInfo;
        }

        public bool NewMedicalRecord(int Doctor_ID, string FirstName, string LastName, string Email, string ID_Number, string Cell_Number, string DOB, string Gender, string Street_Address, string Suburb, string City, string Country, int Patient_Medical_Aid_Medical_Aid_ID, string Scheme_Name, string Membership_Number, string Registration_Date, string Deregistration_Date, string Allergies, string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory)
        {
            int accessLevel = 3;
            int Status = 0;

            if (Convert.ToDateTime(Deregistration_Date) >= Convert.ToDateTime(Registration_Date))
            { Status = 1; } //Valid
            else
            { Status = 0; } //Invalid

            List<SqlParameter> _parameters = new List<SqlParameter>();
            List<SqlParameter> _parametersCreateUser = new List<SqlParameter>();
            List<SqlParameter> _parametersPatient_Medical_Aid = new List<SqlParameter>();
            List<SqlParameter> _parametersEmailAddress = new List<SqlParameter>();
            SqlParameter Doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.VarChar);
            SqlParameter LastNameParameter = new SqlParameter("@LastName", SqlDbType.VarChar);
            SqlParameter EmailParameter = new SqlParameter("@Email", SqlDbType.VarChar);
            SqlParameter _EmailParameter = new SqlParameter("@Email", SqlDbType.VarChar);
            SqlParameter ID_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.VarChar);
            SqlParameter Cell_NumberParameter = new SqlParameter("@Cell_Number", SqlDbType.VarChar);
            SqlParameter DOBParameter = new SqlParameter("@DOB", SqlDbType.VarChar);
            SqlParameter GenderParameter = new SqlParameter("@Gender", SqlDbType.VarChar);
            SqlParameter Street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.VarChar);
            SqlParameter SuburbParameter = new SqlParameter("@Suburb", SqlDbType.VarChar);
            SqlParameter CityParameter = new SqlParameter("@City", SqlDbType.VarChar);
            SqlParameter CountryParameter = new SqlParameter("@Country", SqlDbType.VarChar);
            SqlParameter Patient_Medical_Aid_Medical_Aid_IDParameter = new SqlParameter("@Patient_Medical_Aid_Medical_Aid_ID", SqlDbType.Int);
            SqlParameter Medical_Aid_IDParameter = new SqlParameter("@Patient_Medical_Aid_Medical_Aid_ID", SqlDbType.Int);
            SqlParameter Scheme_NameParameter = new SqlParameter("@Scheme_Name", SqlDbType.VarChar);
            SqlParameter Membership_NumberParameter = new SqlParameter("@Membership_Number", SqlDbType.VarChar);
            SqlParameter Registration_DateParameter = new SqlParameter("@Registration_Date", SqlDbType.VarChar);
            SqlParameter Deregistration_DateParameter = new SqlParameter("@Deregistration_Date", SqlDbType.VarChar);
            SqlParameter StatusParameter = new SqlParameter("@Status", SqlDbType.Bit);
            SqlParameter AllergiesParameter = new SqlParameter("@Allergies", SqlDbType.VarChar);
            SqlParameter PreviousIllnessesParameter = new SqlParameter("@PreviousIllnesses", SqlDbType.VarChar);
            SqlParameter PreviousMedicationParameter = new SqlParameter("@PreviousMedication", SqlDbType.VarChar);
            SqlParameter RiskFactorsParameter = new SqlParameter("@RiskFactors", SqlDbType.VarChar);
            SqlParameter SocialHistoryParameter = new SqlParameter("@SocialHistory", SqlDbType.VarChar);
            SqlParameter FamilyHistoryParameter = new SqlParameter("@FamilyHistory", SqlDbType.VarChar);
            SqlParameter accessLevelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            Doctor_IDParameter.Value = Doctor_ID;
            FirstNameParameter.Value = FirstName;
            LastNameParameter.Value = LastName;
            EmailParameter.Value = Email;
            ID_NumberParameter.Value = ID_Number;
            Cell_NumberParameter.Value = Cell_Number;
            DOBParameter.Value = DOB;
            GenderParameter.Value = Gender;
            Street_AddressParameter.Value = Street_Address;
            SuburbParameter.Value = Suburb;
            CityParameter.Value = City;
            CountryParameter.Value = Country;
            Patient_Medical_Aid_Medical_Aid_IDParameter.Value = Patient_Medical_Aid_Medical_Aid_ID;
            Medical_Aid_IDParameter.Value = Patient_Medical_Aid_Medical_Aid_ID;
            Scheme_NameParameter.Value = Scheme_Name;
            Membership_NumberParameter.Value = Membership_Number;
            Registration_DateParameter.Value = Registration_Date;
            Deregistration_DateParameter.Value = Deregistration_Date;
            StatusParameter.Value = Status;
            AllergiesParameter.Value = Allergies;
            PreviousIllnessesParameter.Value = PreviousIllnesses;
            PreviousMedicationParameter.Value = PreviousMedication;
            RiskFactorsParameter.Value = RiskFactors;
            SocialHistoryParameter.Value = SocialHistory;
            FamilyHistoryParameter.Value = FamilyHistory;
            accessLevelParameter.Value = accessLevel;
            _EmailParameter.Value = Email;
            _parameters.Add(Doctor_IDParameter);
            _parameters.Add(FirstNameParameter);
            _parameters.Add(LastNameParameter);
            _parameters.Add(EmailParameter);
            _parameters.Add(ID_NumberParameter);
            _parameters.Add(Cell_NumberParameter);
            _parameters.Add(DOBParameter);
            _parameters.Add(GenderParameter);
            _parameters.Add(Street_AddressParameter);
            _parameters.Add(SuburbParameter);
            _parameters.Add(CityParameter);
            _parameters.Add(CountryParameter);
            _parameters.Add(Patient_Medical_Aid_Medical_Aid_IDParameter);
            _parametersPatient_Medical_Aid.Add(Medical_Aid_IDParameter);
            _parametersPatient_Medical_Aid.Add(Scheme_NameParameter);
            _parametersPatient_Medical_Aid.Add(Membership_NumberParameter);
            _parametersPatient_Medical_Aid.Add(Registration_DateParameter);
            _parametersPatient_Medical_Aid.Add(Deregistration_DateParameter);
            _parametersPatient_Medical_Aid.Add(StatusParameter);
            _parameters.Add(AllergiesParameter);
            _parameters.Add(PreviousIllnessesParameter);
            _parameters.Add(PreviousMedicationParameter);
            _parameters.Add(RiskFactorsParameter);
            _parameters.Add(SocialHistoryParameter);
            _parameters.Add(FamilyHistoryParameter);
            _parametersCreateUser.Add(accessLevelParameter);
            _parametersEmailAddress.Add(_EmailParameter);

            int UserID = 0; int PatientID = 0;            
            try
            {
                using (var readerEmailAddress = access.ExecuteReader(Conn, "[CheckIfUserExists]", _parametersEmailAddress))//Check if user exists
                {
                    if (!readerEmailAddress.Read())
                    {
                        using (var reader = access.ExecuteReader(Conn, "[CreateUser]", _parametersCreateUser))
                        {
                            if (reader.Read())
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("ID"));
                                SqlParameter UserIDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
                                UserIDParameter.Value = UserID;
                                _parameters.Add(UserIDParameter);
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                if (UserID != 0)
                {
                    using (var reader = access.ExecuteReader(Conn, "[InsertMedicalRecord]", _parameters))
                    {
                        if (reader.Read())
                        {
                            PatientID = reader.GetInt32(reader.GetOrdinal("ID"));
                            SqlParameter PatientIDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
                            PatientIDParameter.Value = PatientID;
                            _parametersPatient_Medical_Aid.Add(PatientIDParameter);
                            access.ExecuteNonQuery(Conn, _parametersPatient_Medical_Aid, "[InsertPatient_Medical_Aid]");
                            
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public bool UpdateMedicalRecord(int Patient_ID, string FirstName, string LastName, string Email, string ID_Number, string Cell_Number, string DOB, string Gender, string Street_Address, string Suburb, string City, string Country, int Patient_Medical_Aid_Medical_Aid_ID, string Scheme_Name, string Membership_Number, string Registration_Date, string Deregistration_Date, string Allergies, string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.VarChar);
            SqlParameter LastNameParameter = new SqlParameter("@LastName", SqlDbType.VarChar);
            SqlParameter EmailParameter = new SqlParameter("@Email", SqlDbType.VarChar);
            SqlParameter ID_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.VarChar);
            SqlParameter Cell_NumberParameter = new SqlParameter("@Cell_Number", SqlDbType.VarChar);
            SqlParameter DOBParameter = new SqlParameter("@DOB", SqlDbType.VarChar);
            SqlParameter GenderParameter = new SqlParameter("@Gender", SqlDbType.VarChar);
            SqlParameter Street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.VarChar);
            SqlParameter SuburbParameter = new SqlParameter("@Suburb", SqlDbType.VarChar);
            SqlParameter CityParameter = new SqlParameter("@City", SqlDbType.VarChar);
            SqlParameter CountryParameter = new SqlParameter("@Country", SqlDbType.VarChar);
            SqlParameter Patient_Medical_Aid_Medical_Aid_IDParameter = new SqlParameter("@Patient_Medical_Aid_Medical_Aid_ID", SqlDbType.Int);
            SqlParameter Scheme_NameParameter = new SqlParameter("@Scheme_Name", SqlDbType.VarChar);
            SqlParameter Membership_NumberParameter = new SqlParameter("@Membership_Number", SqlDbType.VarChar);
            SqlParameter Registration_DateParameter = new SqlParameter("@Registration_Date", SqlDbType.VarChar);
            SqlParameter Deregistration_DateParameter = new SqlParameter("@Deregistration_Date", SqlDbType.VarChar);
            SqlParameter AllergiesParameter = new SqlParameter("@Allergies", SqlDbType.VarChar);
            SqlParameter PreviousIllnessesParameter = new SqlParameter("@PreviousIllnesses", SqlDbType.VarChar);
            SqlParameter PreviousMedicationParameter = new SqlParameter("@PreviousMedication", SqlDbType.VarChar);
            SqlParameter RiskFactorsParameter = new SqlParameter("@RiskFactors", SqlDbType.VarChar);
            SqlParameter SocialHistoryParameter = new SqlParameter("@SocialHistory", SqlDbType.VarChar);
            SqlParameter FamilyHistoryParameter = new SqlParameter("@FamilyHistory", SqlDbType.VarChar);
            Patient_IDParameter.Value = Patient_ID;
            FirstNameParameter.Value = FirstName;
            LastNameParameter.Value = LastName;
            EmailParameter.Value = Email;
            ID_NumberParameter.Value = ID_Number;
            Cell_NumberParameter.Value = Cell_Number;
            DOBParameter.Value = DOB;
            GenderParameter.Value = Gender;
            Street_AddressParameter.Value = Street_Address;
            SuburbParameter.Value = Suburb;
            CityParameter.Value = City;
            CountryParameter.Value = Country;
            Patient_Medical_Aid_Medical_Aid_IDParameter.Value = Patient_Medical_Aid_Medical_Aid_ID;
            Scheme_NameParameter.Value = Scheme_Name;
            Membership_NumberParameter.Value = Membership_Number;
            Registration_DateParameter.Value = Registration_Date;
            Deregistration_DateParameter.Value = Deregistration_Date;
            AllergiesParameter.Value = Allergies;
            PreviousIllnessesParameter.Value = PreviousIllnesses;
            PreviousMedicationParameter.Value = PreviousMedication;
            RiskFactorsParameter.Value = RiskFactors;
            SocialHistoryParameter.Value = SocialHistory;
            FamilyHistoryParameter.Value = FamilyHistory;
            _parameters.Add(Patient_IDParameter);
            _parameters.Add(FirstNameParameter);
            _parameters.Add(LastNameParameter);
            _parameters.Add(EmailParameter);
            _parameters.Add(ID_NumberParameter);
            _parameters.Add(Cell_NumberParameter);
            _parameters.Add(DOBParameter);
            _parameters.Add(GenderParameter);
            _parameters.Add(Street_AddressParameter);
            _parameters.Add(SuburbParameter);
            _parameters.Add(CityParameter);
            _parameters.Add(CountryParameter);
            _parameters.Add(Patient_Medical_Aid_Medical_Aid_IDParameter);
            _parameters.Add(Scheme_NameParameter);
            _parameters.Add(Membership_NumberParameter);
            _parameters.Add(Registration_DateParameter);
            _parameters.Add(Deregistration_DateParameter);
            _parameters.Add(AllergiesParameter);
            _parameters.Add(PreviousIllnessesParameter);
            _parameters.Add(PreviousMedicationParameter);
            _parameters.Add(RiskFactorsParameter);
            _parameters.Add(SocialHistoryParameter);
            _parameters.Add(FamilyHistoryParameter);

            access.ExecuteNonQuery(Conn, _parameters, "[UpdateMedicalRecord]");
            return true;
        }
        #endregion

        #region Prescription        

        public List<Prescription> GetPrescriptionByPatientID(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            List<Prescription> PrescriptionInfo = new List<Prescription>();
            using (var reader = access.ExecuteReader(Conn, "[GetPrescription]", _parameters))
            {
                while (reader.Read())
                {
                    PrescriptionInfo.Add(new Prescription().Create(reader));
                }
            }
            return PrescriptionInfo;
        }

        public bool NewPrescription(int Patient_ID, int Doctor_ID, int Consultation_ID, string DrugName, string Strength, string IntakeRoute, string Frequency, int DispenseNumber, int RefillNumber)
        {
            List<SqlParameter> _parametersPrescription = new List<SqlParameter>();
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter Doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter Consultation_IDParameter = new SqlParameter("@Consultation_ID", SqlDbType.Int);
            SqlParameter DrugNameParameter = new SqlParameter("@DrugName", SqlDbType.VarChar);
            SqlParameter StrengthParameter = new SqlParameter("@Strength", SqlDbType.VarChar);
            SqlParameter IntakeRouteParameter = new SqlParameter("@IntakeRoute", SqlDbType.VarChar);
            SqlParameter FrequencyParameter = new SqlParameter("@Frequency", SqlDbType.VarChar);
            SqlParameter DispenseNumberParameter = new SqlParameter("@DispenseNumber", SqlDbType.Int);
            SqlParameter RefillNumberParameter = new SqlParameter("@RefillNumber", SqlDbType.Int);
            Patient_IDParameter.Value = Patient_ID;
            Doctor_IDParameter.Value = Doctor_ID;
            Consultation_IDParameter.Value = Consultation_ID;
            DrugNameParameter.Value = DrugName;
            StrengthParameter.Value = Strength;
            IntakeRouteParameter.Value = IntakeRoute;
            FrequencyParameter.Value = Frequency;
            DispenseNumberParameter.Value = DispenseNumber;
            RefillNumberParameter.Value = RefillNumber;
            _parametersPrescription.Add(Patient_IDParameter);
            _parametersPrescription.Add(Doctor_IDParameter);
            _parameters.Add(Consultation_IDParameter);
            _parameters.Add(DrugNameParameter);
            _parameters.Add(StrengthParameter);
            _parameters.Add(IntakeRouteParameter);
            _parameters.Add(FrequencyParameter);
            _parameters.Add(DispenseNumberParameter);
            _parameters.Add(RefillNumberParameter);

            int InsertedPrescription_ID = 0;
            using (var reader = access.ExecuteReader(Conn, "[InsertPrescription]", _parametersPrescription))
            {
                if (reader.Read())
                {
                    InsertedPrescription_ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    SqlParameter Prescription_IDParameter = new SqlParameter("@Prescription_ID", SqlDbType.Int);
                    Prescription_IDParameter.Value = InsertedPrescription_ID;
                    _parameters.Add(Prescription_IDParameter);
                }
            }
            access.ExecuteNonQuery(Conn, _parameters, "[InsertPrescription_DrugDetails]");
            return true;
        }

        public bool UpdatePrescription(int Prescription_ID, string Diagnosis, string DrugName, string Strength, string IntakeRoute, string Frequency, int DispenseNumber, int RefillNumber)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Prescription_IDParameter = new SqlParameter("@Prescription_ID", SqlDbType.Int);
            SqlParameter DiagnosisParameter = new SqlParameter("@Diagnosis", SqlDbType.VarChar);
            SqlParameter DrugNameParameter = new SqlParameter("@DrugName", SqlDbType.VarChar);
            SqlParameter StrengthParameter = new SqlParameter("@Strength", SqlDbType.VarChar);
            SqlParameter IntakeRouteParameter = new SqlParameter("@IntakeRoute", SqlDbType.VarChar);
            SqlParameter FrequencyParameter = new SqlParameter("@Frequency", SqlDbType.VarChar);
            SqlParameter DispenseNumberParameter = new SqlParameter("@DispenseNumber", SqlDbType.Int);
            SqlParameter RefillNumberParameter = new SqlParameter("@RefillNumber", SqlDbType.Int);
            Prescription_IDParameter.Value = Prescription_ID;
            DiagnosisParameter.Value = Diagnosis;
            DrugNameParameter.Value = DrugName;
            StrengthParameter.Value = Strength;
            IntakeRouteParameter.Value = IntakeRoute;
            FrequencyParameter.Value = Frequency;
            DispenseNumberParameter.Value = DispenseNumber;
            RefillNumberParameter.Value = RefillNumber;
            _parameters.Add(Prescription_IDParameter);
            _parameters.Add(DiagnosisParameter);
            _parameters.Add(DrugNameParameter);
            _parameters.Add(StrengthParameter);
            _parameters.Add(IntakeRouteParameter);
            _parameters.Add(FrequencyParameter);
            _parameters.Add(DispenseNumberParameter);
            _parameters.Add(RefillNumberParameter);

            access.ExecuteNonQuery(Conn, _parameters, "[UpdatePrescription]");
            return true;
        }

        public bool DeletePrescription(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[DeletePrescription]", _parameters))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region Staff       
        public List<Staff> GetAllStaff()
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_IDParameter.Value = LoggedIn_User_PRACTICE_ID;
            _parameters.Add(Practice_IDParameter);
            
            List<Staff> staffInfo = new List<Staff>();
            if (LoggedIn_User_AccessLevel == 1)
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAllPracStaff]", new List<SqlParameter>()))
                {
                    while (reader.Read())
                    {
                        staffInfo.Add(new Staff().Create(reader));
                    }
                }
            }
            else
            {
                using (var reader = access.ExecuteReader(Conn, "[GetAllStaff]", _parameters))
                {
                    while (reader.Read())
                    {
                        staffInfo.Add(new Staff().Create(reader));
                    }
                }
            }            
            return staffInfo;
        }

        public Staff GetStaffById(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Staff staffInfo = new Staff();
            using (var reader = access.ExecuteReader(Conn, "[GetAllStaffById]", _parameters))
            {
                if (reader.Read())
                {
                    staffInfo = (new Staff().Create(reader));
                }
            }
            return staffInfo;
        }

        public int GetNewUserID()
        {
            int UserID = 0;
            using (var reader = access.ExecuteReader(Conn, "[GetNewUserID]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    UserID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return (UserID + 1);
        }

        public bool InsertStaff(string firstName, string lastName, string id_Number, string gender, string dob, string phone,
            string street_Address, string suburb, string city, string country, int ACCESSLEVEL_ID, string employee_Type, int practice_ID, int User_ID, string Email)
        {
            _parameters = new List<SqlParameter>();
            List<SqlParameter> _parametersCreateUser = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.NVarChar);
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.NVarChar);
            SqlParameter phoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar);
            SqlParameter street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter employee_TypeParameter = new SqlParameter("@Employee_Type", SqlDbType.NVarChar);
            SqlParameter accessLevelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            SqlParameter practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter User_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);

            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            phoneParameter.Value = phone;
            street_AddressParameter.Value = street_Address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            employee_TypeParameter.Value = employee_Type;
            accessLevelParameter.Value = ACCESSLEVEL_ID;
            practice_IDParameter.Value = practice_ID;
            User_IDParameter.Value = User_ID;
            emailParameter.Value = Email;

            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(phoneParameter);
            _parameters.Add(street_AddressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(employee_TypeParameter);
            _parametersCreateUser.Add(accessLevelParameter);
            _parameters.Add(practice_IDParameter);
            _parameters.Add(User_IDParameter);
            _parameters.Add(emailParameter);

            //try
            //{

            access.ExecuteNonQuery(Conn, _parametersCreateUser, "[CreateUser]");


            if (User_ID != 0)
            {
                access.ExecuteNonQuery(Conn, _parameters, "[InsertStaff]");
            }

            return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public bool UpdateStaff(int ID, string firstName, string lastName, string id_Number, string gender, string dob, string phone,
            string street_Address, string suburb, string city, string country, string employee_Type, int practice_ID, string Email)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.NVarChar);
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.NVarChar);
            SqlParameter phoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar);
            SqlParameter street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter employee_TypeParameter = new SqlParameter("@Employee_Type", SqlDbType.NVarChar);
            SqlParameter practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);

            IDParameter.Value = ID;
            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            phoneParameter.Value = phone;
            street_AddressParameter.Value = street_Address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            employee_TypeParameter.Value = employee_Type;
            practice_IDParameter.Value = practice_ID;
            emailParameter.Value = Email;

            _parameters.Add(IDParameter);
            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(phoneParameter);
            _parameters.Add(street_AddressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(employee_TypeParameter);
            _parameters.Add(practice_IDParameter);
            _parameters.Add(emailParameter);

            //try
            //{
            access.ExecuteNonQuery(Conn, _parameters, "[UpdateStaff]");
            return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public bool DeleteStaff(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            
            using (var reader = access.ExecuteReader(Conn, "[DeleteEmployee]", _parameters))
            {
                if (reader.Read())
                {
                    
                }
            }
            return true;
        }
        #endregion

        #region Doctor
        public bool NewUpdateDoctor(Doctor doc, int UserId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.Char);
            SqlParameter addressParameter = new SqlParameter("@Address", SqlDbType.NVarChar);
            SqlParameter practiceIdParameter = new SqlParameter("@PracticeID", SqlDbType.Int);
            SqlParameter userIdParameter = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter jobTitleParameter = new SqlParameter("@JobTitle", SqlDbType.NVarChar);

            firstNameParameter.Value = doc.FirstName;
            parameters.Add(firstNameParameter);
            lastNameParameter.Value = doc.LastName;
            parameters.Add(lastNameParameter);
            genderParameter.Value = doc.Gender;
            parameters.Add(genderParameter);
            addressParameter.Value = doc.Address;
            parameters.Add(addressParameter);
            practiceIdParameter.Value = doc.Practice_ID;
            parameters.Add(practiceIdParameter);
            userIdParameter.Value = doc.User_Id;
            parameters.Add(userIdParameter);
            jobTitleParameter.Value = doc.Job_Title;
            parameters.Add(jobTitleParameter);

            try
            {
                access.ExecuteNonQuery(Conn, parameters, "[NewUpdateDoctor]");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        #endregion

        #region Medicine_Inventory
        public List<Medicine_Inventory> GetAllMedicine_Inventory()
        {
            DateTime Today = DateTime.Now;
            DateTime NextMonthDate = DateTime.Today.AddMonths(+1);
            Medicine_Inventory Medicine = new Medicine_Inventory(); int qtyAboutToExpier = 0; int qtyExpiered = 0; int qtyNeedRefill = 0;
            List<Medicine_Inventory> Medicine_InventoryInfo = new List<Medicine_Inventory>();
            using (var reader = access.ExecuteReader(Conn, "[GetAllMedicine_Inventory]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    Medicine.ID = reader.GetInt32(reader.GetOrdinal("ID"))                                  ;
                    Medicine.DrugName = reader.GetString(reader.GetOrdinal("DrugName"))                     ;
                    Medicine.Description = reader.GetString(reader.GetOrdinal("Description"))               ;
                    Medicine.QuantityPurchased = reader.GetInt32(reader.GetOrdinal("QuantityPurchased"))    ;
                    Medicine.PurchaseDate = reader.GetString(reader.GetOrdinal("PurchaseDate"))             ;
                    Medicine.QuantityInStock = reader.GetInt32(reader.GetOrdinal("QuantityInStock"))        ;
                    Medicine.ExpiryDate = reader.GetString(reader.GetOrdinal("ExpiryDate"))                 ;
                    Medicine.DrugConcentration = reader.GetString(reader.GetOrdinal("DrugConcentration"))   ;
                    Medicine.Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID"))                ;
                    Medicine.PracticeName = reader.GetString(reader.GetOrdinal("PracticeName"));

                    DateTime ExpiryDate = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("ExpiryDate")));
                    if ((Today < ExpiryDate) && (ExpiryDate < NextMonthDate))
                    {
                        Medicine.highlightqtyAboutToExpier = 1;
                        qtyAboutToExpier++;
                    }
                    Medicine.qtyAboutToExpier = qtyAboutToExpier;

                    if (ExpiryDate < Today)
                    {
                        Medicine.highlightqtyExpiered = 1;
                        qtyExpiered++;
                    }
                    Medicine.qtyExpiered = qtyExpiered;

                    int QuantityInStock = reader.GetInt32(reader.GetOrdinal("QuantityInStock"));
                    if (QuantityInStock < 50)
                    {
                        Medicine.highlightqtyNeedRefill = 1;
                        qtyNeedRefill++;
                    }
                    Medicine.qtyNeedRefill = qtyNeedRefill;
                    Medicine_InventoryInfo.Add(Medicine); Medicine = new Medicine_Inventory();
                }
            }
            return Medicine_InventoryInfo;
        }

        public Medicine_Inventory GetMedicine_InventoryById(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            Medicine_Inventory Medicine_InventoryInfo = new Medicine_Inventory();
            using (var reader = access.ExecuteReader(Conn, "[GetMedicine_InventoryById]", _parameters))
            {
                if (reader.Read())
                {
                    return new Medicine_Inventory().Create(reader);
                }
            }
            return Medicine_InventoryInfo;
        }

        public bool NewMedicine_Inventory(string DrugName, string Description, int QuantityPurchased, string PurchaseDate, string ExpiryDate, string DrugConcentration, int Practice_ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter DrugNameParameter = new SqlParameter("@DrugName", SqlDbType.NVarChar);
            SqlParameter DescriptionParameter = new SqlParameter("@Description", SqlDbType.NVarChar);
            SqlParameter QuantityPurchasedParameter = new SqlParameter("@QuantityPurchased", SqlDbType.NVarChar);
            SqlParameter PurchaseDateParameter = new SqlParameter("@PurchaseDate", SqlDbType.NVarChar);
            SqlParameter QuantityInStockParameter = new SqlParameter("@QuantityInStock", SqlDbType.Int);
            SqlParameter ExpiryDateParameter = new SqlParameter("@ExpiryDate", SqlDbType.NVarChar);
            SqlParameter DrugConcentrationParameter = new SqlParameter("@DrugConcentration", SqlDbType.NVarChar);
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);

            DrugNameParameter.Value = DrugName;
            DescriptionParameter.Value = Description;
            QuantityPurchasedParameter.Value = QuantityPurchased;
            PurchaseDateParameter.Value = PurchaseDate;
            QuantityInStockParameter.Value = QuantityPurchased;
            ExpiryDateParameter.Value = ExpiryDate;
            DrugConcentrationParameter.Value = DrugConcentration;
            Practice_IDParameter.Value = Practice_ID;

            parameters.Add(DrugNameParameter);
            parameters.Add(DescriptionParameter);
            parameters.Add(QuantityPurchasedParameter);
            parameters.Add(PurchaseDateParameter);
            parameters.Add(QuantityInStockParameter);
            parameters.Add(ExpiryDateParameter);
            parameters.Add(DrugConcentrationParameter);
            parameters.Add(Practice_IDParameter);

            //try
            //{
            int insertedID = 0;
            using (var reader = access.ExecuteReader(Conn, "[InsertMedicine_Inventory]", parameters))
            {
                if (reader.Read())
                {
                    insertedID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            //access.LogEntry(UserId, "User Added new Medicine Inventory");
            return true;
            //}
            //catch (Exception ex)
            //{
            //    access.LogEntry(UserId, ex.ToString());
            //    return false;
            //}
        }
        public bool UpdateMedicine_Inventory(int ID, string DrugName, string Description, int QuantityInStock, string DrugConcentration)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter DrugNameParameter = new SqlParameter("@DrugName", SqlDbType.NVarChar);
            SqlParameter DescriptionParameter = new SqlParameter("@Description", SqlDbType.NVarChar);
            SqlParameter QuantityInStockParameter = new SqlParameter("@QuantityInStock", SqlDbType.Int);
            SqlParameter DrugConcentrationParameter = new SqlParameter("@DrugConcentration", SqlDbType.NVarChar);

            IDParameter.Value = ID;
            DrugNameParameter.Value = DrugName;
            DescriptionParameter.Value = Description;
            QuantityInStockParameter.Value = QuantityInStock;
            DrugConcentrationParameter.Value = DrugConcentration;

            parameters.Add(IDParameter);
            parameters.Add(DrugNameParameter);
            parameters.Add(DescriptionParameter);
            parameters.Add(QuantityInStockParameter);
            parameters.Add(DrugConcentrationParameter);

            //try
            //{

            int updatedID = 0;
            using (var reader = access.ExecuteReader(Conn, "[UpdateMedicine_Inventory]", parameters))
            {
                if (reader.Read())
                {
                    updatedID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            //access.LogEntry(UserId, "User Added new Medicine Inventory");
            return true;
            //}
            //catch (Exception ex)
            //{
            //    access.LogEntry(UserId, ex.ToString());
            //    return false;
            //}
        }
        public bool DeleteMedicine_Inventory(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            int deletedID = 0;
            using (var reader = access.ExecuteReader(Conn, "[DeleteMedicine_Inventory]", _parameters))
            {
                if (reader.Read())
                {
                    deletedID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region Medical Aid
        public List<Medical_Aid> GetAllMedicalAids()
        {
            List<Medical_Aid> MedicalAidInfo = new List<Medical_Aid>();
            using (var reader = access.ExecuteReader(Conn, "[GetAllMedicalAids]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    MedicalAidInfo.Add(new Medical_Aid().Create(reader));
                }
            }
            return MedicalAidInfo;
        }
        public Medical_Aid GetMedicalAidById(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            Medical_Aid MedicalAidInfo = new Medical_Aid();
            using (var reader = access.ExecuteReader(Conn, "[GetMedicalAidById]", _parameters))
            {
                if (reader.Read())
                {
                    return new Medical_Aid().Create(reader);
                }
            }
            return MedicalAidInfo;
        }
        public bool NewMedicalAid(string Name, string Cell_Number, string Fax_Number, string Email_Address, string Address)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter NameParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            SqlParameter Cell_NumberSummaryParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter Fax_NumberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter Email_AddressParameter = new SqlParameter("@Email_Address", SqlDbType.NVarChar);
            SqlParameter AddressParameter = new SqlParameter("@Address", SqlDbType.NVarChar);

            NameParameter.Value = Name;
            Cell_NumberSummaryParameter.Value = Cell_Number;
            Fax_NumberParameter.Value = Fax_Number;
            Email_AddressParameter.Value = Email_Address;
            AddressParameter.Value = Address;

            _parameters.Add(NameParameter);
            _parameters.Add(Cell_NumberSummaryParameter);
            _parameters.Add(Fax_NumberParameter);
            _parameters.Add(Email_AddressParameter);
            _parameters.Add(AddressParameter);

            int insertedID = 0;
            using (var reader = access.ExecuteReader(Conn, "[InsertMedicalAid]", _parameters))
            {
                if (reader.Read())
                {
                    insertedID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        public bool UpdateMedicalAid(int ID, string Name, string Cell_Number, string Fax_Number, string Email_Address, string Address)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter NameParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            SqlParameter Cell_NumberSummaryParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter Fax_NumberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter Email_AddressParameter = new SqlParameter("@Email_Address", SqlDbType.NVarChar);
            SqlParameter AddressParameter = new SqlParameter("@Address", SqlDbType.NVarChar);

            IDParameter.Value = ID;
            NameParameter.Value = Name;
            Cell_NumberSummaryParameter.Value = Cell_Number;
            Fax_NumberParameter.Value = Fax_Number;
            Email_AddressParameter.Value = Email_Address;
            AddressParameter.Value = Address;

            _parameters.Add(IDParameter);
            _parameters.Add(NameParameter);
            _parameters.Add(Cell_NumberSummaryParameter);
            _parameters.Add(Fax_NumberParameter);
            _parameters.Add(Email_AddressParameter);
            _parameters.Add(AddressParameter);


            //try
            //{
            access.ExecuteNonQuery(Conn, _parameters, "[UpdateMedicalAid]");
            return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
        public bool DeleteMedicalAid(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            int User_ID = 0;
            using (var reader = access.ExecuteReader(Conn, "[DeleteMedicalAid]", _parameters))
            {
                if (reader.Read())
                {
                    User_ID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region Messages
        public List<Messages> GetAllMessages(int Receiver)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter ReceiverParameter = new SqlParameter("@Receiver", SqlDbType.Int);
            ReceiverParameter.Value = Receiver;
            _parameters.Add(ReceiverParameter);

            Messages MessageInfo = new Messages();
            List<Messages> MessagesInfo = new List<Messages>();
            using (var reader = access.ExecuteReader(Conn, "[GetAllMessages]", _parameters))
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

                    using (var readerMessageSender = access.ExecuteReader(Conn, "[GetMessageSender]", parametersSender))
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
        public Messages NumOfUnReadMessages(int Receiver)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter ReceiverParameter = new SqlParameter("@Receiver", SqlDbType.Int);
            ReceiverParameter.Value = Receiver;
            _parameters.Add(ReceiverParameter);

            Messages NumOfUnReadMessages = new Messages();
            using (var reader = access.ExecuteReader(Conn, "[NumOfUnReadMessages]", _parameters))
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
        public Messages GetMessageById(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);

            Messages MessageInfo = new Messages();
            using (var reader = access.ExecuteReader(Conn, "[GetMessageById]", _parameters))
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

                    using (var readerMessageSender = access.ExecuteReader(Conn, "[GetMessageSender]", parametersSender))
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

        public List<Messages> GetAllSentMessages(int Sender)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter SenderParameter = new SqlParameter("@Sender", SqlDbType.Int);
            SenderParameter.Value = Sender;
            _parameters.Add(SenderParameter);

            Messages MessageInfo = new Messages();
            List<Messages> MessagesInfo = new List<Messages>();
            using (var reader = access.ExecuteReader(Conn, "[GetAllSentMessages]", _parameters))
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
        public Messages GetSentMessageById(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);

            Messages MessageInfo = new Messages();
            using (var reader = access.ExecuteReader(Conn, "[GetMessageById]", _parameters))
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

                    using (var readerMessageSender = access.ExecuteReader(Conn, "[GetMessageSender]", parametersSender))
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

        public List<Staff> GetAllRecepients()
        {
            Staff MessageInfo = new Staff();
            List<Staff> MessagesInfo = new List<Staff>();
            using (var reader = access.ExecuteReader(Conn, "[GetRecepientDoctors]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.FirstName = reader.GetString(reader.GetOrdinal("FirstName")) + " " + reader.GetString(reader.GetOrdinal("LastName")) + " : " + reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    MessageInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                    MessageInfo.Email = reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel"));
                    MessagesInfo.Add(MessageInfo);
                    MessageInfo = new Staff();
                }
            }
            using (var reader = access.ExecuteReader(Conn, "[GetRecepientStaff]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.FirstName = reader.GetString(reader.GetOrdinal("FirstName")) +" "+ reader.GetString(reader.GetOrdinal("LastName")) + " : " + reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    MessageInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                    MessageInfo.Email = reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel"));
                    MessagesInfo.Add(MessageInfo);
                    MessageInfo = new Staff();
                }
            }
            using (var reader = access.ExecuteReader(Conn, "[GetRecepientPatients]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    MessageInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    MessageInfo.FirstName = reader.GetString(reader.GetOrdinal("FirstName")) + " " + reader.GetString(reader.GetOrdinal("LastName")) + " : " + reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    MessageInfo.User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"));
                    MessageInfo.Email = reader.GetString(reader.GetOrdinal("Email"));
                    MessageInfo.AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel"));
                    MessagesInfo.Add(MessageInfo);
                    MessageInfo = new Staff();
                }
            }
            return MessagesInfo;
        }

        public bool NewMessages(int Receiver, int Sender, string Subject, string Description, string Date)
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
            using (var reader = access.ExecuteReader(Conn, "[InsertMessage]", _parameters))
            {
                if (reader.Read())
                {
                    insertedID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        public bool DeleteMessages(int ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            IDParameter.Value = ID;
            _parameters.Add(IDParameter);
            int User_ID = 0;
            using (var reader = access.ExecuteReader(Conn, "[DeleteMessage]", _parameters))
            {
                if (reader.Read())
                {
                    User_ID = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region Dashboard
        public Invoice GetRevenueSummary_Today(int Practice_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter _Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            _Practice_IDParameter.Value = Practice_ID;
            Practice_IDParameter.Value = Practice_ID;
            _parameters.Add(_Practice_IDParameter);
            parameters.Add(Practice_IDParameter);

            Invoice GetRevenueSummary_Today = new Invoice();
            using (var reader = access.ExecuteReader(Conn, "[GetRevenueSummary_Today]", _parameters))
            {
                while (reader.Read())
                {
                    GetRevenueSummary_Today.TotalNumOfVisits++;
                    GetRevenueSummary_Today.Total += reader.GetDecimal(reader.GetOrdinal("Total"));
                    GetRevenueSummary_Today.AmountPaid += reader.GetDecimal(reader.GetOrdinal("AmountPaid"));
                    GetRevenueSummary_Today.BalanceOwing += reader.GetDecimal(reader.GetOrdinal("BalanceOwing"));
                }                
            }
            using (var GetExpense = access.ExecuteReader(Conn, "[GetExpenses_Today]", parameters))
            {
                while (GetExpense.Read())
                {
                    GetRevenueSummary_Today.Amount += Convert.ToDecimal(GetExpense.GetString(GetExpense.GetOrdinal("Amount")));
                }
            }
            return GetRevenueSummary_Today;
        }
        public Invoice GetRevenueSummary_Week(int Practice_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter _Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            _Practice_IDParameter.Value = Practice_ID;
            Practice_IDParameter.Value = Practice_ID;
            _parameters.Add(_Practice_IDParameter);
            parameters.Add(Practice_IDParameter);

            Invoice GetRevenueSummary_Week = new Invoice();
            using (var reader = access.ExecuteReader(Conn, "[GetRevenueSummary_Week]", _parameters))
            {
                while (reader.Read())
                {
                    GetRevenueSummary_Week.TotalNumOfVisits++;
                    GetRevenueSummary_Week.Total += reader.GetDecimal(reader.GetOrdinal("Total"));
                    GetRevenueSummary_Week.AmountPaid += reader.GetDecimal(reader.GetOrdinal("AmountPaid"));
                    GetRevenueSummary_Week.BalanceOwing += reader.GetDecimal(reader.GetOrdinal("BalanceOwing"));
                }
            }

            using (var GetExpense = access.ExecuteReader(Conn, "[GetExpenses_Week]", parameters))
            {
                while (GetExpense.Read())
                {
                    GetRevenueSummary_Week.Amount += Convert.ToDecimal(GetExpense.GetString(GetExpense.GetOrdinal("Amount")));
                }
            }
            return GetRevenueSummary_Week;
        }

        public Invoice GetRevenueSummary_Month(int Practice_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter _Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            _Practice_IDParameter.Value = Practice_ID;
            Practice_IDParameter.Value = Practice_ID;
            _parameters.Add(_Practice_IDParameter);
            parameters.Add(Practice_IDParameter);

            Invoice GetRevenueSummary_Month = new Invoice();
            using (var reader = access.ExecuteReader(Conn, "[GetRevenueSummary_Month]", _parameters))
            {
                while (reader.Read())
                {
                    GetRevenueSummary_Month.TotalNumOfVisits++;
                    GetRevenueSummary_Month.Total += reader.GetDecimal(reader.GetOrdinal("Total"));
                    GetRevenueSummary_Month.AmountPaid += reader.GetDecimal(reader.GetOrdinal("AmountPaid"));
                    GetRevenueSummary_Month.BalanceOwing += reader.GetDecimal(reader.GetOrdinal("BalanceOwing"));
                }
            }

            using (var GetExpense = access.ExecuteReader(Conn, "[GetExpenses_Month]", parameters))
            {
                while (GetExpense.Read())
                {
                    GetRevenueSummary_Month.Amount += Convert.ToDecimal(GetExpense.GetString(GetExpense.GetOrdinal("Amount")));
                }
            }
            return GetRevenueSummary_Month;
        }

        public Invoice GetNumPatientsByPractice(int Practice_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter _Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            _Practice_IDParameter.Value = Practice_ID;
            Practice_IDParameter.Value = Practice_ID;
            _parameters.Add(_Practice_IDParameter);
            parameters.Add(Practice_IDParameter);

            Invoice GetNumPatientsByPractice = new Invoice();
            using (var reader = access.ExecuteReader(Conn, "[GetRevenueSummary_Month]", _parameters))
            {
                while (reader.Read())
                {
                    GetNumPatientsByPractice.TotalNumOfVisits++;
                    GetNumPatientsByPractice.Total += reader.GetDecimal(reader.GetOrdinal("Total"));
                    GetNumPatientsByPractice.AmountPaid += reader.GetDecimal(reader.GetOrdinal("AmountPaid"));
                    GetNumPatientsByPractice.BalanceOwing += reader.GetDecimal(reader.GetOrdinal("BalanceOwing"));
                }
            }

            using (var GetExpense = access.ExecuteReader(Conn, "[GetExpenses_Month]", parameters))
            {
                while (GetExpense.Read())
                {
                    GetNumPatientsByPractice.Amount += Convert.ToDecimal(GetExpense.GetString(GetExpense.GetOrdinal("Amount")));
                }
            }
            return GetNumPatientsByPractice;
        }
        public List<Consultation> Consulations_Visits(int Practice_ID)
        {
            List<SqlParameter> parameters_4LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_3LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_2LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_1LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_CurrentMonth = new List<SqlParameter>();

            SqlParameter Practice_ID_4LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_3LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_2LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_1LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_CurrentMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_ID_4LastMonth.Value = Practice_ID;
            Practice_ID_3LastMonth.Value = Practice_ID;
            Practice_ID_2LastMonth.Value = Practice_ID;
            Practice_ID_1LastMonth.Value = Practice_ID; 
            Practice_ID_CurrentMonth.Value = Practice_ID;
            parameters_4LastMonth.Add(Practice_ID_4LastMonth);
            parameters_3LastMonth.Add(Practice_ID_3LastMonth);
            parameters_2LastMonth.Add(Practice_ID_2LastMonth);
            parameters_1LastMonth.Add(Practice_ID_1LastMonth);
            parameters_CurrentMonth.Add(Practice_ID_CurrentMonth);


            Consultation Consulations_Visits = new Consultation();
            DateTime date = DateTime.Now;
            List<Consultation> List = new List<Consultation>();
            using (var reader = access.ExecuteReader(Conn, "[Consulations_Visits_4LastMonth]", parameters_4LastMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(-4)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            using (var reader = access.ExecuteReader(Conn, "[Consulations_Visits_3LastMonth]", parameters_3LastMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(-3)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            using (var reader = access.ExecuteReader(Conn, "[Consulations_Visits_2LastMonth]", parameters_2LastMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(-2)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            using (var reader = access.ExecuteReader(Conn, "Consulations_Visits_LastMonth", parameters_1LastMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(-1)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            using (var reader = access.ExecuteReader(Conn, "[Consulations_Visits_CurrentMonth]", parameters_CurrentMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(0)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            return List;
        }
        public List<Consultation> Appointment_Stats(int Practice_ID)
        {
            List<SqlParameter> parameters_4LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_3LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_2LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_1LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_CurrentMonth = new List<SqlParameter>();

            SqlParameter Practice_ID_4LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_3LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_2LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_1LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_CurrentMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_ID_4LastMonth.Value = Practice_ID;
            Practice_ID_3LastMonth.Value = Practice_ID;
            Practice_ID_2LastMonth.Value = Practice_ID;
            Practice_ID_1LastMonth.Value = Practice_ID;
            Practice_ID_CurrentMonth.Value = Practice_ID;
            parameters_4LastMonth.Add(Practice_ID_4LastMonth);
            parameters_3LastMonth.Add(Practice_ID_3LastMonth);
            parameters_2LastMonth.Add(Practice_ID_2LastMonth);
            parameters_1LastMonth.Add(Practice_ID_1LastMonth);
            parameters_CurrentMonth.Add(Practice_ID_CurrentMonth);


            Consultation Consulations_Visits = new Consultation();
            DateTime date = DateTime.Now;
            List<Consultation> List = new List<Consultation>();
            using (var reader = access.ExecuteReader(Conn, "[Appointments_Visits_4LastMonth]", parameters_4LastMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date_Time"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(-4)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            using (var reader = access.ExecuteReader(Conn, "[Appointments_Visits_3LastMonth]", parameters_3LastMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date_Time"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(-3)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            using (var reader = access.ExecuteReader(Conn, "[Appointments_Visits_2LastMonth]", parameters_2LastMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date_Time"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(-2)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            using (var reader = access.ExecuteReader(Conn, "Appointments_Visits_LastMonth", parameters_1LastMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date_Time"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(-1)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            using (var reader = access.ExecuteReader(Conn, "[Appointments_Visits_CurrentMonth]", parameters_CurrentMonth))
            {
                int Count = 0; Consulations_Visits = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("Date_Time"))).ToString("MMM");

                }
                else
                {
                    Consulations_Visits.TotalNumOfVisits = Count;
                    Consulations_Visits.Month = (date.AddMonths(0)).ToString("MMM");
                }
                List.Add(Consulations_Visits);
            }
            return List;
        }
        public List<Appointments> GetPendingAppointmentsByPracticeID (int Practice_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_IDParameter.Value = Practice_ID;
            _parameters.Add(Practice_IDParameter);

            List<Appointments> PendingAppointmentsList = new List<Appointments>();
            using (var reader = access.ExecuteReader(Conn, "[GetPendingAppointmentsByPracticeID]", _parameters))
            {
                while (reader.Read())
                {
                    PendingAppointmentsList.Add(new Appointments().GetPendingAppointmentsByPracticeID(reader));
                }
            }
            return PendingAppointmentsList;
        }
        public List<Appointments> GetAppovedAppointmentsByPracticeID(int Practice_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_IDParameter.Value = Practice_ID;
            _parameters.Add(Practice_IDParameter);

            List<Appointments> AppovedAppointmentsList = new List<Appointments>();
            using (var reader = access.ExecuteReader(Conn, "[GetAppovedAppointmentsByPracticeID]", _parameters))
            {
                while (reader.Read())
                {
                    AppovedAppointmentsList.Add(new Appointments().GetPendingAppointmentsByPracticeID(reader));
                }
            }
            return AppovedAppointmentsList;
        }
        public List<Appointments> GetRejectedAppointmentsByPracticeID(int Practice_ID)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_IDParameter.Value = Practice_ID;
            _parameters.Add(Practice_IDParameter);

            List<Appointments> RejectedAppointmentsList = new List<Appointments>();
            using (var reader = access.ExecuteReader(Conn, "[GetRejectedAppointmentsByPracticeID]", _parameters))
            {
                while (reader.Read())
                {
                    RejectedAppointmentsList.Add(new Appointments().GetPendingAppointmentsByPracticeID(reader));
                }
            }
            return RejectedAppointmentsList;
        }
        public bool AppoveAppointment(int ID, int App_Status)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter App_StatusParameter = new SqlParameter("@App_Status", SqlDbType.Bit);

            IDParameter.Value = ID;
            App_StatusParameter.Value = App_Status;
            parameters.Add(IDParameter);
            parameters.Add(App_StatusParameter);

            access.ExecuteNonQuery(Conn, parameters, "[AppoveOrRejectAppointment]");
            return true;
        }
        public bool RejectAppointment(int ID, int App_Status)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter App_StatusParameter = new SqlParameter("@App_Status", SqlDbType.Bit);

            IDParameter.Value = ID;
            App_StatusParameter.Value = App_Status;
            parameters.Add(IDParameter);
            parameters.Add(App_StatusParameter);

            access.ExecuteNonQuery(Conn, parameters, "[AppoveOrRejectAppointment]");
            return true;
        }
        public List<Medicine_Inventory> MedicineInventoryStockCount(int Practice_ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter Practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_IDParameter.Value = Practice_ID;
            parameters.Add(Practice_IDParameter);

            List<Medicine_Inventory> MedicineInventoryStockCount  = new List<Medicine_Inventory>();
            using (var reader = access.ExecuteReader(Conn, "[MedicineInventoryStockCount]", parameters))
            {
                while (reader.Read())
                {
                    MedicineInventoryStockCount.Add(new Medicine_Inventory().MedicineInventoryStockCount(reader));
                }
            }
            return MedicineInventoryStockCount;
        }

        public List<Consultation> NumOFPatientsPerMonthPerPractice(int Practice_ID)
        {
            List<SqlParameter> parameters_4LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_3LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_2LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_1LastMonth = new List<SqlParameter>();
            List<SqlParameter> parameters_CurrentMonth = new List<SqlParameter>();

            SqlParameter Practice_ID_4LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_3LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_2LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_1LastMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter Practice_ID_CurrentMonth = new SqlParameter("@Practice_ID", SqlDbType.Int);
            Practice_ID_4LastMonth.Value = Practice_ID;
            Practice_ID_3LastMonth.Value = Practice_ID;
            Practice_ID_2LastMonth.Value = Practice_ID;
            Practice_ID_1LastMonth.Value = Practice_ID;
            Practice_ID_CurrentMonth.Value = Practice_ID;
            parameters_4LastMonth.Add(Practice_ID_4LastMonth);
            parameters_3LastMonth.Add(Practice_ID_3LastMonth);
            parameters_2LastMonth.Add(Practice_ID_2LastMonth);
            parameters_1LastMonth.Add(Practice_ID_1LastMonth);
            parameters_CurrentMonth.Add(Practice_ID_CurrentMonth);


            Consultation PatientsCount = new Consultation();
            DateTime date = DateTime.Now;
            List<Consultation> List = new List<Consultation>();
            using (var reader = access.ExecuteReader(Conn, "[PatientsCount_4LastMonth]", parameters_4LastMonth))
            {
                int Count = 0; PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = (date.AddMonths(-4)).ToString("MMM");
                }
                //List.Add(PatientsCount);
            }
            //PatientsCount/Month
            using (var reader = access.ExecuteReader(Conn, "[TotalPatientsCount_4LastMonth]", new List<SqlParameter>()))
            {
                int Count = 0; //PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = (date.AddMonths(-4)).ToString("MMM");
                }
                List.Add(PatientsCount);
            }

            using (var reader = access.ExecuteReader(Conn, "[PatientsCount_3LastMonth]", parameters_3LastMonth))
            {
                int Count = 0; PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = (date.AddMonths(-3)).ToString("MMM");
                }
                //List.Add(PatientsCount);
            }
            //PatientsCount/Month
            using (var reader = access.ExecuteReader(Conn, "[TotalPatientsCount_3LastMonth]", new List<SqlParameter>()))
            {
                int Count = 0; //PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = (date.AddMonths(-3)).ToString("MMM");
                }
                List.Add(PatientsCount);
            }

            using (var reader = access.ExecuteReader(Conn, "[PatientsCount_2LastMonth]", parameters_2LastMonth))
            {
                int Count = 0; PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = (date.AddMonths(-2)).ToString("MMM");
                }
                //List.Add(PatientsCount);
            }

            //PatientsCount/Month
            using (var reader = access.ExecuteReader(Conn, "[TotalPatientsCount_2LastMonth]", new List<SqlParameter>()))
            {
                int Count = 0; //PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = (date.AddMonths(-2)).ToString("MMM");
                }
                List.Add(PatientsCount);
            }

            using (var reader = access.ExecuteReader(Conn, "[PatientsCount_LastMonth]", parameters_1LastMonth))
            {
                int Count = 0; PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = (date.AddMonths(-1)).ToString("MMM");
                }
                //List.Add(PatientsCount);
            }
            //PatientsCount/Month
            using (var reader = access.ExecuteReader(Conn, "[TotalPatientsCount_LastMonth]", new List<SqlParameter>()))
            {
                int Count = 0; //PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = (date.AddMonths(-1)).ToString("MMM");
                }
                List.Add(PatientsCount);
            }
            //PatientsCount/Practice/Month
            using (var reader = access.ExecuteReader(Conn, "[PatientsCount_CurrentMonth]", parameters_CurrentMonth))
            {
                int Count = 0; PatientsCount = new Consultation();
                while (reader.Read())
                {
                    Count++;
                }
                if (reader.Read())
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = Convert.ToDateTime(reader.GetString(reader.GetOrdinal("RegistrationDate"))).ToString("MMM");

                }
                else
                {
                    PatientsCount.TotalNumOfVisits = Count;
                    PatientsCount.Month = (date.AddMonths(0)).ToString("MMM");
                }
                //List.Add(PatientsCount);
            }

            //PatientsCount/Month
            using (var TotalPatientsCount = access.ExecuteReader(Conn, "[TotalPatientsCount_CurrentMonth]", new List<SqlParameter>()))
            {
                int Count = 0; //PatientsCount = new Consultation();
                while (TotalPatientsCount.Read())
                {
                    Count++;
                }
                if (TotalPatientsCount.Read())
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = Convert.ToDateTime(TotalPatientsCount.GetString(TotalPatientsCount.GetOrdinal("RegistrationDate"))).ToString("MMM");
                }
                else
                {
                    PatientsCount.TotalPatientsCount = Count;
                    PatientsCount.Month = (date.AddMonths(0)).ToString("MMM");
                }
                List.Add(PatientsCount);
            }
            return List;
        }

        #endregion

        #region User Profile
        public UserProfile GetLoggedinUserProfile(int User_ID)
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
                    if (UserProfile.AccessLevel == 1 || UserProfile.AccessLevel == 2) {
                        return new UserProfile().CreateDoctor(reader);
                    }
                    else if (UserProfile.AccessLevel == 4 || UserProfile.AccessLevel == 5 || UserProfile.AccessLevel == 6) {
                        return new UserProfile().CreateStaff(reader);
                    }
                    
                }
            }
            return UserProfile;
        }
        public bool UpdateProfileStaff(int User_ID, string FirstName, string LastName, string ID_Number, string Gender, string DOB, string Phone, string Street_Address, string Suburb, string City, string Country)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter User_IDParameter       = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter FirstNameParameter     = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter LastNameParameter      = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter ID_NumberParameter     = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter GenderParameter        = new SqlParameter("@Gender", SqlDbType.Char);
            SqlParameter DOBParameter           = new SqlParameter("@DOB", SqlDbType.NVarChar);
            SqlParameter PhoneParameter         = new SqlParameter("@Phone", SqlDbType.NVarChar);
            SqlParameter Street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter SuburbParameter        = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter CityParameter          = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter CountryParameter       = new SqlParameter("@Country", SqlDbType.NVarChar);

            User_IDParameter.Value = User_ID              ;
            FirstNameParameter.Value = FirstName          ;
            LastNameParameter.Value = LastName            ;
            ID_NumberParameter.Value = ID_Number          ;
            GenderParameter.Value = Gender                ;
            DOBParameter.Value = DOB                      ;
            PhoneParameter.Value = Phone                  ;
            Street_AddressParameter.Value = Street_Address;
            SuburbParameter.Value = Suburb                ;
            CityParameter.Value = City                    ;
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
        public bool UpdateProfileDoctor(int User_ID, string FirstName, string LastName, string Gender, string Address)
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

        public UserProfile GetPassword(int User_ID)
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

        public bool UpdatePassword(int User_ID, string Password)
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

        #region LogFile
        public List<Log> ReadLogFile()
        {
            Log Data = new Log();
            List<Log> LogData = new List<Log>();
            List<Log> LoadList = new List<Log>();            
            LogData = access.ReadEntry();
            for (int i = 0; i < LogData.Count; i++)
            {
               Data.Key = LogData[i].Key;
               Data.User_ID = LogData[i].User_ID;
               Data.Name = LogData[i].Name;
               Data.AccessLevel = LogData[i].AccessLevel;
               Data.Activity = LogData[i].Activity;
               Data.LogTime = LogData[i].LogTime;
               LoadList.Add(Data); Data = new Log();
            }
            return LogData;
        }
        #endregion

        #region
        public List<Consultation> FinancialReport_All(string StartDate, string EndDate)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter StartDateParameter = new SqlParameter("@DateStart", SqlDbType.NVarChar);
            SqlParameter EndDateParameter = new SqlParameter("@DateEnd", SqlDbType.NVarChar);
            
            StartDateParameter.Value = StartDate;
            EndDateParameter.Value = EndDate;
            
            _parameters.Add(StartDateParameter);
            _parameters.Add(EndDateParameter);

            List<Consultation> FinancialInfo = new List<Consultation>();
            using (var reader = access.ExecuteReader(Conn, "[FinancialReport_All]", _parameters))
            {
                while (reader.Read())
                {
                    FinancialInfo.Add(new Consultation().FinancialReportByPracticeID(reader));
                }
            }
            return FinancialInfo;
        }

        public List<Consultation> FinancialReportByPracticeID(int Practice_ID, string StartDate, string EndDate)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>(); 
            SqlParameter Practice_IDParameter = new SqlParameter("@PracticeID", SqlDbType.Int);
            SqlParameter StartDateParameter = new SqlParameter("@DateStart", SqlDbType.NVarChar);
            SqlParameter EndDateParameter = new SqlParameter("@DateEnd", SqlDbType.NVarChar);

            Practice_IDParameter.Value = Practice_ID;
            StartDateParameter.Value = StartDate;
            EndDateParameter.Value = EndDate;

            _parameters.Add(Practice_IDParameter);
            _parameters.Add(StartDateParameter);
            _parameters.Add(EndDateParameter);

            List<Consultation> FinancialInfo = new List<Consultation>();
            using (var reader = access.ExecuteReader(Conn, "[FinancialReportByPracticeID]", _parameters))
            {
                while (reader.Read())
                {
                    FinancialInfo.Add(new Consultation().FinancialReportByPracticeID(reader));
                }
            }
            return FinancialInfo;
        }
        #endregion
    }
}