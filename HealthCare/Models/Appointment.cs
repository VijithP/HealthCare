using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class Appointment : Patient
    {
        [Display(Name = "Appointment ID")]
        public int AppointmentID { set; get; }

        [Required]
        [Display(Name = "Doctor Name")]
        public int DoctorID { set; get; }

        [Display(Name = "Doctor Name")]
        public string DoctorName{ set; get; }

        [Display(Name = "Appointment Date")]

        public DateTime AppointmentDate { set; get; }
        
    }
}