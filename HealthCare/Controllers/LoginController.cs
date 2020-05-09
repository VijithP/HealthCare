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
    public class LoginController : Controller
    {
        UserRepository userRepository = new UserRepository();
        MenuRepository menuRepository = new MenuRepository();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginSumit(User user)
        {

            List<User> userDetails = userRepository.ValidateLoginUser(user.UserName, user.Password);
            if(userDetails.Count>0)
            {
                Session["UserID"] = userDetails[0].UserID;
                Session["UserName"]= userDetails[0].UserName;
                Session["userSession"] = new Guid();
                LoadSessionValues();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(user);

            }

        }

        public void LoadSessionValues()
        {
            try
            {

                Session["MenuList"]= menuRepository.MenuDetailsGet();


                //List<Menu> listMenu = new List<Menu>()
                //{
                //    new Menu{MenuID=1,MenuName="Home",URL="/Home/Index" },
                //    new Menu{MenuID=2,MenuName="Appointment",URL="/Appoinment/Index" }


                //};

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }





    }
}