using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ObjectModel;

namespace DataClient
{
    public class AppMethods
    {
        private DataAccess access;

        private string Conn;

        public AppMethods()
        {
            access = new DataAccess();
            Conn = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public string GetPatientByID(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@PatId", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            Patient patientInfo = new Patient();
            using (var reader = access.ExecuteReader(Conn, "[GetPatById]", _parameters))
            {
                if (reader.Read())
                {
                    patientInfo = new Patient(reader);
                    return JsonConvert.SerializeObject(patientInfo);
                }
            }
            return null;
        }
    }
}
