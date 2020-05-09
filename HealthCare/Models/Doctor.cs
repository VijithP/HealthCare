using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class Doctor
    {
        public int DoctorID { set; get; }

        [Required]
        [Display(Name="Doctor Name")]
        public string Name { set; get; }
        public bool IsAvailable { set; get; }
        [Required]
        public string Specification { set; get; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { set; get; }

        [Required]
        public string Address { set; get; }

        public int CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }

        public int ModifiedBy { set; get; }
        public DateTime ModifiedDate { set; get;
        }

    }
}