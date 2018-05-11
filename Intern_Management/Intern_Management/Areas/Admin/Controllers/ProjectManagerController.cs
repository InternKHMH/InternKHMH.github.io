using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace Intern_Management.Areas.Admin.Controllers
{
    public class ProjectManagerController : Controller
    {
        // GET: Admin/ProjectManager
        public ActionResult Index()
        {
            int ProjectCompleted = 0,ProjectProcessing=0;

            Dictionary<int, string> StatusName = new Dictionary<int, string>();
            List<StatusCheck> listStatus = new StatusDao().GetAll() ;

            foreach(var item in listStatus)
            {
                int key = item.StatusID;
                string value = item.StatusName;
                if (key == 1)
                {
                    ProjectCompleted++;
                }
                else
                    ProjectProcessing++;

                StatusName.Add(key, value);
            }


            ViewBag.StatusName = StatusName;
            ViewBag.Completed = ProjectCompleted;
            ViewBag.Processing = ProjectProcessing;


            ViewBag.DanhSachProject = new ProjectDao().ListAll();
            return View();
        }

        [HttpPost]
        public JsonResult GetInforProject(int ProjectID)
        {
            //get information witd ProjectID
            ProjectDao projec = new ProjectDao();
            var ttproject = projec.GetByID(ProjectID);

            //lay thong tin member



            return Json(new {
                hoten = ProjectID,
                tendk="kdjakf",

            });
        }
    }
}