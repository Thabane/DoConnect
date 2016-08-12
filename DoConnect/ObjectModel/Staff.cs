using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{  
    public class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID_Number { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Street_Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Employee_Type { get; set; }
        public int Practice_ID { get; set; }
        public int User_ID { get; set; }

    }
}
