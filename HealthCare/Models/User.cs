using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public class User
    {
        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

    }
}