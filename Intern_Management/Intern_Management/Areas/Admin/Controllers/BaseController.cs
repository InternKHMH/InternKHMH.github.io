using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intern_Management.Common;
using Model.EF;

namespace Intern_Management.Areas.Admin.Controllers
{
    /// <summary>
    ///  controller check login 
    /// </summary>
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                    var sess = (User)Session[CommonConstants.USE_SESSISON];
                if(sess==null)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                        new { controller = "Login", action = "Index", Area = "Admin" }));
                }
                base.OnActionExecuting(filterContext);
            }
            catch
            {
                base.OnActionExecuting(filterContext);
            }
            
        }
    }
}