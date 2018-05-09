using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace Intern_Management.Areas.Admin.Controllers
{
    public class ProjectManagerController : Controller
    {
        // GET: Admin/ProjectManager
        public ActionResult Index()
        {
            ViewBag.DanhSachProject = new ProjectDao().ListAll();
            return View();
        }
    }
}