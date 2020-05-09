using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthCare.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace HealthCare.Repository
{
    public class MenuRepository:BaseRepository
    {

        public List<Menu> MenuDetailsGet()
        {
            try
            {

                List<Menu> doctorList = new List<Menu>();
                using (SqlConnection con = GetAppConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    doctorList = con.Query<Menu>("USP_HC_MenuList_MenuListGet", dynamicParameters, commandType: CommandType.StoredProcedure).ToList<Menu>();
                    return doctorList;

                }

            }
            catch (Exception exe)
            {

                throw exe;
            }
        }
    }
}