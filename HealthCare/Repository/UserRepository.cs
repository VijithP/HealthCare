using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using HealthCare.Models;

namespace HealthCare.Repository
{
    public class UserRepository:BaseRepository
    {

        public List<User> ValidateLoginUser(string userName, string password)
        {

            try
            {
                using (SqlConnection con = GetAppConnectionObject())
                {
                    
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserName", Convert.ToString(userName));
                    dynamicParameters.Add("@Password", Convert.ToString(password));
                    List<User> data = con.Query<User>("usp_HC_ValidateUser", dynamicParameters, commandType: CommandType.StoredProcedure).ToList<User>();
                    return data;

                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}