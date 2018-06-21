using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intern_Management.Areas.Admin.Models;
using Model.Dao;
using Model.EF;
using System.Web.Routing;

namespace Intern_Management.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                var result = dao.CheckLogin(model.UserName, model.Password);
                if(result==1)
                {
                    
                    Session.Add(Common.CommonConstants.USE_SESSISON, dao.GetByUserName(model.UserName));

                    //new { controller = "Login", action = "Index", Area = "Admin" }));
                    int? rolID = ((User)Session[Common.CommonConstants.USE_SESSISON]).RoleID;
                    if (rolID==2)//manager
                    {
                        return RedirectToAction("Index", "ProjectManager");
                    }

                    if(rolID==4)//intern
                    {
                        return RedirectToAction("Index", "Home", new RouteValueDictionary(new { controller = "Home", action = "Index", Area = "Member" }));
                    }
                    
                }
                else
                {
                    if(result==-1)
                    ModelState.AddModelError("","Username faile");
                    else
                    {
                        if (result == -2) ModelState.AddModelError("", "Password faile");
                        else
                            ModelState.AddModelError("", "Account be not Active");
                    }

                }
            }

            else
            {
                ModelState.AddModelError("", "please check your fields data");
            }
            return View("Index");
            

        }
    }
}