using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Intern_Management.Common;
using System.Collections;
using Intern_Management.Models;
using Intern_Management.Common;
using Model.Dao;


namespace Intern_Management.Areas.Admin.Controllers
{
    public class ProjectManagerController : BaseController
    {
        // GET: Admin/ProjectManager
        public ActionResult Index()
        {

            
            Dictionary<int, string> StatusName = new Dictionary<int, string>();
            List<StatusCheck> listStatus = new StatusDao().GetAll();

            foreach (var item in listStatus)
            {
                int key = item.StatusID;
                string value = item.StatusName;
                StatusName.Add(key, value);
            }


            ViewBag.StatusName = StatusName;
           
            ViewBag.ManagerName = ((User)Session[CommonConstants.USE_SESSISON]).FullName;
            ViewBag.ManagerID = ((User)Session[CommonConstants.USE_SESSISON]).UserID;
            List<Project> dsProject= new ProjectDao().GetListProjectByManager(ViewBag.ManagerID);
            ViewBag.DanhSachProject = dsProject;



            //dem so project hoan thanh va chua hoan thanh
            int projectHoanThanh = 0, projectProcessing = 0, projectInActive = 0;
            foreach(var item in dsProject)
            {
                if(item.StatusID==1)
                {
                    projectHoanThanh++;
                    
                }
                if (item.StatusID == 2)
                    projectProcessing++;
                if (item.StatusID == 4)
                    projectInActive++;

            }

            ViewBag.Completed = projectHoanThanh; ////(new ProjectDao().CountProjectByStatusID(1));
            ViewBag.Processing = projectProcessing;
            ViewBag.InActive = projectInActive;
            return View();
        }

        [HttpGet]
        public ActionResult GetInforProject(int ProjectID)
        {
            var manager = (User)Session[CommonConstants.USE_SESSISON];
            //get information witd ProjectID
            var ttproject = new ProjectDao().GetByID(ProjectID);
            //lay thong tin member
            var dsUser = new UserDao().GetAllUserByProjectID(ProjectID);
            //lay thong tin leader
            var ttleader = (new ProjectDao().GetLeaderProject(ProjectID));
            
            if(ttleader==null)
            {
                ttproject.Leadername = "Project " + ttproject.ProjectName + " not exists leader please select below";
            }
            else
            {
                ttproject.Leadername = ttleader.FullName;
            }
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
                    fm.FeatureID = fc.FeatureID;
                    dsFeatureMb.Add(fm);
                }
            }
            dsmember.Remove(manager.UserID);
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

            //neu them khong duoc tra ve -1 
            //neu them duoc tra ve id project vua them

            //truyền thêm một User Id là UserID của manager đăng nhập hệ thống
            var manager = (User)Session[CommonConstants.USE_SESSISON];
            ArrayList dl = new ArrayList();
            dl.Add(new ProjectDao().Add(ProjectName, StartDate, EndDate, manager.UserID));
            dl.Add(manager.UserName);
            return Json(dl);
        }
        
        [HttpPost]
        public JsonResult Delete(int projectID)
        {
            //lay danh sach user trong bang user voi projectID tren
            List<User> listUser=(new UserDao()).GetAllUserByProjectID(projectID);

            //delete data in table projectmember with projectID
            ProjectMemberDao pm = new ProjectMemberDao();
            bool result = pm.DeleteByProjectID(projectID);
            //xoa cac user trong bang user
            bool kq = (new UserDao()).Delete(listUser);

            if (result == true && kq == true)
            {
                return Json((new ProjectDao()).Delete(projectID));
            }
            else
                return Json(-1);
            
            
        }


        /// <summary>
        /// lay id va fullname cac manager he thong
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetManager()
        {
            var result = (new ProjectDao()).GetManager();
            ArrayList dl = new ArrayList();
            dl.Add(result.ToList());
            return Json(dl,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(string projectName,int newManagerID,DateTime startDate,DateTime endDate, int projectID)
        {
            var manager = (User)Session[CommonConstants.USE_SESSISON];
            ProjectDao dao = new ProjectDao();
            Project pr = new Project();
            pr.ProjectName = projectName;
            pr.StartDate = startDate;
            pr.EndDate = endDate;
            pr.ProjectID = projectID;
            int result = dao.Update(pr, newManagerID, manager.UserID);
            return Json(result);
        }

        public JsonResult AssignScrumMaster(int? projectID,int userID)
        {
            return Json((new ProjectMemberDao()).AssignScrumMaster(projectID, userID));
        }

    }
    
}