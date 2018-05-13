using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Intern_Management.Common;
using System.Collections;

namespace Intern_Management.Areas.Admin.Controllers
{
    public class ProjectManagerController : Controller
    {
        // GET: Admin/ProjectManager
        public ActionResult Index()
        {
            int ProjectCompleted = 0, ProjectProcessing = 0;

            Dictionary<int, string> StatusName = new Dictionary<int, string>();
            List<StatusCheck> listStatus = new StatusDao().GetAll();

            foreach (var item in listStatus)
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

        [HttpGet]
        public ActionResult GetInforProject(int ProjectID)
        {
            //get information witd ProjectID
            var ttproject = new ProjectDao().GetByID(ProjectID);
            //lay thong tin member
            var dsUser = new UserDao().GetAllUserByProjectID(ProjectID);

            Dictionary<int, string> dsmember = new Dictionary<int, string>();
            List<FeatureMember> dsFeatureMb = new List<FeatureMember>();
           

            foreach (var item in dsUser)
            {
                dsmember.Add(item.UserID, item.FullName);
                List<Feature> ft = new FeatureDao().GetByUserID(item.UserID,ProjectID);
              
               

                
                foreach(var fc in ft)
                {
                    FeatureMember fm = new FeatureMember();
                    fm.FeatureOwer = item.FullName;
                    fm.FeatureName = fc.FeatureName;
                    fm.FeatureStatus = fc.StatusCheck.StatusName;
                    dsFeatureMb.Add(fm);
                }
            }

            //lấy thông tin Feature theo ID member
           

            ArrayList dl = new ArrayList();
            dl.Add(dsmember.ToList()); //dl[0]="danh sách các member"
            dl.Add(ttproject.ProjectName);//dl[1]=tên project
            dl.Add(ttproject.Leadername);//dl[2]==tên leader
            dl.Add(ttproject.StartDate);//dl[3]==ngày bắt đầu project
            dl.Add(ttproject.EndDate);//dl[4]==ngày kết thúc project
            dl.Add(dsFeatureMb);//dl[5] danh sách feature và member đảm nhiệm
            
            return Json(dl, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(string ProjectName,DateTime StartDate,DateTime EndDate)
        {
            ArrayList ds = new ArrayList();
            ds.Add(ProjectName);
               ds.Add(StartDate);
            ds.Add(EndDate);
            return Json(ds);
        }


    }

   

    
}