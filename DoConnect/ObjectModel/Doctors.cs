using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public string Job_Title { get; set; }
        public int UserId { get; set; }
        public int PracticeId { get; set; }
    }
}
