using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace InfoServ
{
    public class GlabalVar
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=TestAndroid;Integrated Security=True");
        public string connect = @"Data Source=localhost;Initial Catalog=TestAndroid;Integrated Security=True";

        
    }
}