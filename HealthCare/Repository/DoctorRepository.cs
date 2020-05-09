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
    public class DoctorRepository:BaseRepository
    {

        public string AddDoctorDetails(Doctor doctor)
        {
            string result = "";
            try
            {

                using (SqlConnection con = GetAppConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();                
                    dynamicParameters.Add("@Name", Convert.ToString(doctor.Name));
                    dynamicParameters.Add("@Specification", Convert.ToString(doctor.Specification));
                    dynamicParameters.Add("@IsAvailable", Convert.ToString(doctor.IsAvailable));
                    dynamicParameters.Add("@Address", Convert.ToString(doctor.Address));
                    dynamicParameters.Add("@ContactNumber", Convert.ToString(doctor.ContactNumber));
                    dynamicParameters.Add("@CreatedBy", Convert.ToString(doctor.CreatedBy));
                    dynamicParameters.Add("@ModifiedBy", Convert.ToString(doctor.ModifiedBy));

                    var data = con.Query<string>("USP_HC_Doctor_DoctorDetailInsert", dynamicParameters, commandType: CommandType.StoredProcedure);
                    return result;

                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateDoctorDetails(Doctor doctor)
        {
            string result = "";
            try
            {


                using (SqlConnection con = GetAppConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DoctorID", Convert.ToString(doctor.DoctorID));
                    dynamicParameters.Add("@Name", Convert.ToString(doctor.Name));
                    dynamicParameters.Add("@Specification", Convert.ToString(doctor.Specification));
                    dynamicParameters.Add("@IsAvailable", Convert.ToString(doctor.IsAvailable));
                    dynamicParameters.Add("@Address", Convert.ToString(doctor.Address));
                    dynamicParameters.Add("@ContactNumber", Convert.ToString(doctor.ContactNumber));                   
                    dynamicParameters.Add("@ModifiedBy", Convert.ToString(doctor.ModifiedBy));
                    var data = con.Query<string>("USP_HC_Doctor_DoctorDetailUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }

              

            }
            catch (Exception exe)
            {

                throw;
            }

        }

        public List<Doctor> ListDoctorDetails()
        {
            try
            {

                List<Doctor> doctorList = new List<Doctor>();
                using (SqlConnection con = GetAppConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    doctorList = con.Query<Doctor>("USP_HC_Doctor_DoctorDetailGet", dynamicParameters, commandType: CommandType.StoredProcedure).ToList<Doctor>();
                    return doctorList;

                }
                
            }
            catch (Exception exe)
            {

                throw exe;
            }
        }


        public string DeleteDoctorDetails(Doctor doctor)
        {
            string result = "";
            try
            {


                using (SqlConnection con = GetAppConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DoctorID", Convert.ToString(doctor.DoctorID));       
                    dynamicParameters.Add("@ModifiedBy", Convert.ToString(doctor.ModifiedBy));
                    var data = con.Query<string>("USP_HC_Doctor_DoctorDetailDelete", dynamicParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }



            }
            catch (Exception exe)
            {

                throw;
            }

        }



    }
}