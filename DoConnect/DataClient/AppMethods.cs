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
        public bool UpdatePatient(int userId, string firstName, string lastName, string idNumber, char gender, string dob,string cellNumber,int medicalAidId, int doctorId, string streetaddress,string suburb, string city, string country)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter userIdParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            userIdParameter.Value = userId;
            _parameters.Add(userIdParameter);
            //***************************
            SqlParameter FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            FirstNameParameter.Value = firstName;
            _parameters.Add(FirstNameParameter);
            //***************************
            SqlParameter LastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            LastNameParameter.Value = lastName;
            _parameters.Add(LastNameParameter);
            //***************************
            SqlParameter ID_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            ID_NumberParameter.Value = idNumber;
            _parameters.Add(ID_NumberParameter);
            //***************************
            SqlParameter GenderParameter = new SqlParameter("@Gender", SqlDbType.Char);
            GenderParameter.Value = gender;
            _parameters.Add(GenderParameter);
            //***************************
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.NVarChar);
            dobParameter.Value = dob;
            _parameters.Add(dobParameter);
            //***************************
            SqlParameter Cell_NumberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            Cell_NumberParameter.Value = cellNumber;
            _parameters.Add(Cell_NumberParameter);
            //***************************
            SqlParameter Medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            Medical_Aid_IDParameter.Value = medicalAidId;
            _parameters.Add(Medical_Aid_IDParameter);
            //***************************
            SqlParameter Doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            Doctor_IDParameter.Value = doctorId;
            _parameters.Add(Doctor_IDParameter);
            //***************************
            SqlParameter Street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            Street_AddressParameter.Value = streetaddress;
            _parameters.Add(Street_AddressParameter);
            //***************************
            SqlParameter SuburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SuburbParameter.Value = suburb;
            _parameters.Add(SuburbParameter);
            //***************************
            SqlParameter CityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            CityParameter.Value = city;
            _parameters.Add(CityParameter);
            //***************************
            SqlParameter CountryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            CountryParameter.Value = country;
            _parameters.Add(CountryParameter);
            //***************************

            try
            {
                access.ExecuteNonQuery(Conn, _parameters, "[NewUpdatePatient]");
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
