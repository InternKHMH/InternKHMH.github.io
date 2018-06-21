using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;


namespace Intern_Management.Areas.Admin.Controllers
{
    public class InternManagerController : Controller
    {
        // GET: Admin/InternManager
        public ActionResult Index()
        {
            //lay du lieu hien thi len view 
            //lay top 4 intern tham gia nhieu project nhat
            List<Model.EF.User> ds = (new ProjectMemberDao().Top4IDUserJoinedProject());
            ViewBag.dsSlideTo = ds;
            return View();
        }
        

          
    }
}