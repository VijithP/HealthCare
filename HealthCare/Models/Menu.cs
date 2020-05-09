using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public class Menu
    {
     
        public int MenuID { get; set; }  
        public int? MenuParentID { get; set; }  
        public string MenuName { get; set; }  
        public string ControllerName { get; set; }  
        public string ActionName { get; set; }    


}

}