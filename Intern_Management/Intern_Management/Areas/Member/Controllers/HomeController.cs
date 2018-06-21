using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Intern_Management.Areas.Member.Controllers
{
    public class HomeController : Intern_Management.Areas.Admin.Controllers.BaseController
    {
        // GET: Member/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}