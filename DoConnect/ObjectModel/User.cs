using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{    
    public class User
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public DateTime Last_Login { get; set; }
        public int AccessLevel { get; set; }
    }
}
