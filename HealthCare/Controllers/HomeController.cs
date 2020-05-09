using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthCare.Models;
using HealthCare.Filters;
using HealthCare.Repository;


namespace HealthCare.Controllers
{
    [UserAuthenticationFilter]
    [HandleError]
    public class HomeController : Controller
    {
        DoctorRepository dr = new DoctorRepository();
        PatientRepository pr = new PatientRepository();
        public ActionResult Index()
        {

            try
            {
                //int value = 0;
                //int result = 10 / value;
                List<Doctor> doctorsList = new List<Doctor>();
                doctorsList = dr.ListDoctorDetails();

                List<Appointment> appointmentsList = new List<Appointment>();
                appointmentsList = pr.ListPatientDetails();

                ViewData["TotalDoctor"] = doctorsList.Count();
                ViewData["TotalAppointment"] = appointmentsList.Count();
                ViewData["UserName"] = Session["UserName"].ToString();

                return View(doctorsList);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public ActionResult Logout()
        {
            try
            {
                Session.Abandon();
                return Redirect("~/Login/Login");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}