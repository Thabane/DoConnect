using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Expenses
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public int Practice_ID { get; set; }
        public string Practice_Name { get; set; }
        public int User_ID { get; set; }
        public string StaffFullName { get; set; }
        public string DoctorFullName { get; set; }
        
        public Expenses Create(SqlDataReader reader)
        {            
            return new Expenses
            {

                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Date = reader.GetString(reader.GetOrdinal("Date")),
                Amount = reader.GetString(reader.GetOrdinal("Amount")),
                Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID")),
                Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name")),
                User_ID = reader.GetInt32(reader.GetOrdinal("User_ID"))
            };           
        }

        public Expenses GetAllExpensesUsersDoc(SqlDataReader reader)
        {
            return new Expenses
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                User_ID = reader.GetInt32(reader.GetOrdinal("User_ID")),
                DoctorFullName = reader.GetString(reader.GetOrdinal("DoctorFullName"))
            };
        }

        public Expenses GetAllExpensesUsersStaff(SqlDataReader reader)
        {
            return new Expenses
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                User_ID = reader.GetInt32(reader.GetOrdinal("User_ID")),
                StaffFullName = reader.GetString(reader.GetOrdinal("StaffFullName"))
            };
        }

    }
}
