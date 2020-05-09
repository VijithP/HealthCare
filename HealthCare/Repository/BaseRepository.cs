using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HealthCare.Repository
{
    public class BaseRepository
    {
        public static string GetConnectionString()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            return connectionString;
        }




        public static SqlConnection GetAppConnectionObject()
        {
            SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
            return sqlConnection;
        }
    }
}