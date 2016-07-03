using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
//using System.Net

namespace DataClient
{
    /// <summary>
    /// Data class
    /// </summary>
    internal class DataAccess
    {
        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns></returns>
        internal SqlDataReader ExecuteReader(string connectionString, string procName, List<SqlParameter> commandParameters)
        {
            string connStr = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            var conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand(procName, conn);

            if (commandParameters != null)
                foreach (SqlParameter param in commandParameters)
                    command.Parameters.Add(param);

            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="storedProc">The stored proc.</param>
        internal void ExecuteNonQuery(string connectionString, List<SqlParameter> parameters, string storedProc)
        {
            string connStr = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            using (var con = new SqlConnection(connStr))
            using (var command = new SqlCommand(storedProc, con))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        internal void LogEntry()
        {
            JObject o1 = JObject.Parse(File.ReadAllText(@"c:\videogames.json"));
            //using (StreamReader r = new StreamReader(@"C:\Users\thabane.n\Source\Repos\DoConnect\DoConnect\DataClient\LogFiles\Log.json"))
            //{
            //    var text = r.Read();
            //    var hold = JSON.Parse(text);
            //}
        }
    }
}
