using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthCare.Models;
using HealthCare.Repository;
using HealthCare.Filters;

namespace HealthCare.Controllers
{

    [UserAuthenticationFilter]
    public class SettingsController : Controller
    {

        DoctorRepository dr = new DoctorRepository();
        // GET: Settings
        public ActionResult Doctor()
        {
            List<Doctor> doctorsList = new List<Doctor>();
            doctorsList = dr.ListDoctorDetails();

            return View(doctorsList);
        }

        [HttpGet]
        public ActionResult AddDoctor(Doctor doctor)
        {
            try
            {


                return View();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ActionName("AddDoctor")]
        public ActionResult AddDoctor_Post(Doctor doctor)
        {
            try
            {               

                if(ModelState.IsValid)
                {
                    doctor.CreatedBy = 1;
                    doctor.ModifiedBy = 1;
                    dr.AddDoctorDetails(doctor);
                    return RedirectToAction("Doctor");
                }
                else
                {
                    return View();
                }

               
            }
            catch ( Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public ActionResult EditDoctor(int ? id)
        {

            try
            {
                List<Doctor> doctorsList = new List<Doctor>();
                doctorsList = dr.ListDoctorDetails();

                Doctor doc = new Doctor();
                doc = doctorsList.First(e => e.DoctorID == id);

                return View(doc);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPost]
        [ActionName("EditDoctor")]
        public ActionResult EditDoctor_Post(Doctor doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    doctor.ModifiedBy = 1;
                    dr.UpdateDoctorDetails(doctor);
                    return RedirectToAction("Doctor");
                }
                else
                {
                    return View();
                }


                
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        //[HttpPost]
        [ActionName("DeleteDoctor")]
        public ActionResult DeleteDoctor(int id)
        {
            try
            {             
                    Doctor doctor = new Doctor();
                    doctor.DoctorID = id;
                    doctor.ModifiedBy = 1;
                    dr.DeleteDoctorDetails(doctor);
                    return RedirectToAction("Doctor");              

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}