using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HealthCare.Models
{
    public class Patient
    {
        public int PatientID { set; get; }    
        
        [Required]
        [Display(Name="Patient Name")]
        public string Name { set; get; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { set; get; }
        public string Address { set; get; }
        public string Gender { set; get; }
        public int Age { set; get; }
        public bool IsActive { set; get; }

        public int CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedDate  { set; get;   }
    }
}