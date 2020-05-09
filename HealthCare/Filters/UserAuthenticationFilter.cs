using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
namespace HealthCare.Filters
{
    public class UserAuthenticationFilter:ActionFilterAttribute,IAuthenticationFilter,IExceptionFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {            
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["userSession"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
            }
        }

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception != null )
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
            }

        }

    }
}