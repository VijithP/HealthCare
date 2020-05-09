using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HealthCare.Filters;
using HealthCare.Models;
using HealthCare.Repository;

namespace HealthCare.Controllers
{

    [UserAuthenticationFilter]
    public class AppointmentController : Controller
    {

        DoctorRepository dr = new DoctorRepository();
        PatientRepository pr = new PatientRepository();
               
        public ActionResult ListAppointment()
        {
             List<Appointment> patientsList=  pr.ListPatientDetails();
            return View(patientsList);
        }

        // GET: Appointment
        [HttpGet]
        public ActionResult AddAppointment()
        {
            List<Doctor> doctorList = dr.ListDoctorDetails();
            List<SelectListItem> listDoctor = GetDoctorList(doctorList);
            
            ViewData["DoctorList"] = listDoctor;

            Appointment appointment = new Appointment();
            appointment.AppointmentDate = DateTime.Today;
            return View(appointment);
        }

        [HttpPost]
        [ActionName("AddAppointment")]
        public ActionResult AddAppointment_Post(Appointment appointment)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    appointment.CreatedBy = Convert.ToInt16(Session["UserID"]);
                    appointment.CreatedBy = Convert.ToInt16(Session["UserID"]);
                    pr.AddPatientDetails(appointment);
                    return  RedirectToAction("ListAppointment");

                }else
                {
                    return View();
                }

            }
            catch (Exception exe)
            {

                throw;
            }
        }



        // GET: Appointment
        [HttpGet]
        public ActionResult EditAppointment(int id)
        {
            List<Appointment> patientsList = pr.ListPatientDetails();
            Appointment editAppointment = patientsList.Find(e => e.PatientID == id);

            List<Doctor> doctorList = dr.ListDoctorDetails();
            List<SelectListItem> listDoctor = GetDoctorList(doctorList);

            ViewData["DoctorList"] = listDoctor;

            return View(editAppointment);
        }

        [HttpPost]
        [ActionName("EditAppointment")]
        public ActionResult EditAppointment_Post(Appointment appointment)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    pr.UpdatePatientDetails(appointment);
                    return RedirectToAction("ListAppointment");

                }
                else
                {
                    return View();
                }

            }
            catch (Exception exe)
            {

                throw;
            }
            //return View();
        }

        public List<SelectListItem> GetDoctorList(List<Doctor> doctors)
        {
            try
            {
                List<SelectListItem> doctorsList = new List<SelectListItem>();
                foreach(var item in doctors)
                {
                    doctorsList.Add(new SelectListItem { Text = item.Name, Value = item.DoctorID.ToString() });
                }
                return doctorsList;

            }
            catch (Exception)
            {
                throw;
                throw;
            }
        }






    }
}