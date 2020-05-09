using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthCare.Models;
using HealthCare.Repository;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace HealthCare.Repository
{
    public class PatientRepository:BaseRepository
    {

        public string AddPatientDetails(Appointment Appointment)
        {
            string result = "";
            try
            {

                using (SqlConnection con = GetAppConnectionObject())
                {
                   
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DoctorID", Convert.ToInt16(Appointment.DoctorID));
                    dynamicParameters.Add("@AppointmentDate", Convert.ToDateTime(Appointment.AppointmentDate));
                    dynamicParameters.Add("@Name", Convert.ToString(Appointment.Name));
                    dynamicParameters.Add("@ContactNumber", Convert.ToString(Appointment.ContactNumber));
                    dynamicParameters.Add("@Address", Convert.ToString(Appointment.Address));
                    dynamicParameters.Add("@Age", Convert.ToString(Appointment.Age));
                    dynamicParameters.Add("@IsActive", Convert.ToString(Appointment.IsActive));
                    dynamicParameters.Add("@Gender", Convert.ToString(Appointment.Gender));
                    dynamicParameters.Add("@CreatedBy", Convert.ToString(Appointment.CreatedBy));
                    dynamicParameters.Add("@ModifiedBy", Convert.ToString(Appointment.ModifiedBy));

                    var data = con.Query<string>("USP_HC_Patient_PatientDetailInsert", dynamicParameters, commandType: CommandType.StoredProcedure);
                    return result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdatePatientDetails(Appointment appointment)
        {
            string result = "";
            try
            {


                using (SqlConnection con = GetAppConnectionObject())
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientID", Convert.ToString(appointment.PatientID));
                    dynamicParameters.Add("@DoctorID", Convert.ToInt16(appointment.DoctorID));
                    dynamicParameters.Add("@AppointmentDate", Convert.ToDateTime(appointment.AppointmentDate));
                    dynamicParameters.Add("@Name", Convert.ToString(appointment.Name));
                    dynamicParameters.Add("@ContactNumber", Convert.ToString(appointment.ContactNumber));
                    dynamicParameters.Add("@Address", Convert.ToString(appointment.Address));
                    dynamicParameters.Add("@Gender", Convert.ToString(appointment.Gender));
                    dynamicParameters.Add("@ModifiedBy", Convert.ToString(appointment.ModifiedBy));
                    dynamicParameters.Add("@Age", Convert.ToInt32(appointment.Age));

                    var data = con.Query<string>("USP_HC_Patient_PatientDetailUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }



            }
            catch (Exception exe)
            {

                throw;
            }

        }

        public List<Appointment> ListPatientDetails()
        {
            try
            {

                List<Appointment> doctorList = new List<Appointment>();
                using (SqlConnection con = GetAppConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    doctorList = con.Query<Appointment>("USP_HC_Patient_PatientDetailGet", dynamicParameters, commandType: CommandType.StoredProcedure).ToList<Appointment>();
                    return doctorList;

                }

            }
            catch (Exception exe)
            {

                throw exe;
            }
        }


        public string DeletePatientDetails(Patient patient)
        {
            string result = "";
            try
            {


                using (SqlConnection con = GetAppConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientID", Convert.ToString(patient.PatientID));
                    dynamicParameters.Add("@ModifiedBy", Convert.ToString(patient.ModifiedBy));
                    var data = con.Query<string>("USP_HC_Patient_PatientDetailDelete", dynamicParameters, commandType: CommandType.StoredProcedure);
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