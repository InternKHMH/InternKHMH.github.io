using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using System.Collections;

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

            //LOAD 7 INTERN NsoPageGAU NHIEN
            List<Model.EF.User> ds7intern = (new UserDao().Load7Intern(0));
            ViewBag.ds7Intern = ds7intern;
            ViewBag.soPage = (new UserDao().SoPageTrangInternManager());


            return View();
        }

        
        public ActionResult Get_7_StudentRegister(int numberSkip)
        {
            ArrayList dl = new ArrayList();

            List<Model.EF.User> dsuser = (new Model.Dao.UserDao().ListNonActiveStatus(numberSkip));
            foreach(var item in dsuser)
            {
                Model.EF.User motuser = new Model.EF.User();
                motuser.FullName = item.FullName;
                motuser.UserName = item.UserName;
                motuser.RoleID = item.RoleID;
                motuser.userAddress = item.userAddress;
                motuser.UserID = item.UserID;
                motuser.University = item.University;
                motuser.Stat = item.Stat;
                motuser.specialized = item.specialized;
                motuser.Passwords = item.Passwords;
                motuser.imagecover = item.imagecover;
                motuser.imagelogin = item.imagelogin;
           
                dl.Add(motuser);
            }

            return Json(dl, JsonRequestBehavior.AllowGet);
        }
        

          
    }
}