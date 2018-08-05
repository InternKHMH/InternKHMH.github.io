using Intern_Management.Areas.Admin.Controllers;
using Intern_Management.Common;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intern_Management.Areas.Admin.Controllers;
using Model.Dao;
using System.Collections;

namespace Intern_Management.Areas.Member.Controllers
{
    public class ProjectController : BaseController
    {
        // GET: Member/Project
        public ActionResult Index()
        {
            //lay tat ca cac task phai hoan thanh hom nay
            ViewBag.FullNameLogin = ((User)Session[CommonConstants.USE_SESSISON]).FullName;
            ViewBag.userIDLogin = ((User)Session[CommonConstants.USE_SESSISON]).UserID;

            List<Model.EF.Feature> dsTaskDueDate = new Model.Dao.FeatureDao().GetAllDueDateTask(ViewBag.userIDLogin);

            //lay danh sach project da duoc active cua userid nay va la intern

            List<Model.EF.Project> dsProjectActive = new Model.Dao.ProjectDao().GetProjectsByUserID(ViewBag.userIDLogin, CommonConstants.MANAGER,CommonConstants.ACTIVE,CommonConstants.PROCESSING);

            //lay danh sach project comepleted
            List<Model.EF.Project> dsProjectCompleted = new Model.Dao.ProjectDao().GetProjectsByUserID(ViewBag.userIDLogin, CommonConstants.MANAGER, CommonConstants.COMPLETED, CommonConstants.COMPLETED);
            ViewBag.dsTaskDueDate = dsTaskDueDate;
            ViewBag.dsProjectActive = dsProjectActive;
            ViewBag.dsProjectCompleted = dsProjectCompleted;
            //xong phan load du lieu ban dau

            //Load du lieu detail project
            return View();
        }
        public ActionResult GetInforProject(int ProjectID)
        {
            var currentUser = (User)Session[CommonConstants.USE_SESSISON];
            //get information witd ProjectID
            var ttproject = new ProjectDao().GetByID(ProjectID);
            //lay thong tin member
            var dsUser = new UserDao().GetAllUserByProjectID(ProjectID);
            //lay thong tin leader
            var ttleader = (new ProjectDao().GetLeaderProject(ProjectID));

            if (ttleader == null)
            {
                ttproject.Leadername = "No Assign";
            }
            else
            {
                ttproject.Leadername = ttleader.FullName;
            }
            Dictionary<int, string> dsmember = new Dictionary<int, string>();

            List<FeatureMember> dsFeatureMb = new List<FeatureMember>();


            foreach (var item in dsUser)
            {
                if(item.RoleID!=CommonConstants.MANAGER)
                dsmember.Add(item.UserID, item.FullName);
                List<Feature> ft = new FeatureDao().GetByUserID(item.UserID, ProjectID);
                foreach (var fc in ft)
                {
                    FeatureMember fm = new FeatureMember();
                    fm.FeatureOwer = item.FullName;
                    fm.FeatureName = fc.FeatureName;
                    fm.FeatureStatus = fc.StatusCheck.StatusName;
                    fm.FeatureID = fc.FeatureID;
                    dsFeatureMb.Add(fm);
                }
            }
            //dsmember.Remove(currentUser.UserID);
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
        /// <summary>
        /// kiem tra xem user dang login co phai la leader cua project khong
        /// </summary>
        /// <param name="projectId">idproject can kiem tra</param>
        /// <returns></returns>
       public JsonResult IsLeader(int projectId)
        {
            var currentUser = (User)Session[CommonConstants.USE_SESSISON];
            if(currentUser==null)
            {
                return Json(0);

            }
            else
            {
                int? kq = new UserDao().IsLeader(currentUser.UserID, projectId);
                if (kq == CommonConstants.LEADER)
                    return Json(1);
                else return Json(0);

            }
        }
        public JsonResult AddTask(string taskName,string endDate,string description,int taskOwer,int projectId)
        {

            //kiem tra lại userlogin có quyền thêm task không cho chắc ăn

            var currentUser = (User)Session[CommonConstants.USE_SESSISON];
            if (currentUser == null)
            {
                return Json(0);

            }
            else
            {
                int? kq = new UserDao().IsLeader(currentUser.UserID, projectId);
                if (kq == CommonConstants.LEADER)
                {
                    Feature entity = new Feature();
                    entity.FeatureName = taskName;
                    entity.endDate = DateTime.Parse(endDate);
                    entity.Descrip = description;
                    entity.UserID = taskOwer;
                    entity.StatusID = CommonConstants.INACTIVE;
                    entity.ProjectID = projectId;
                    int result = (new FeatureDao().AddTask(entity));
                    return Json(1);
                }
                    
                else return Json(0);

            }

          
           
        }
        public JsonResult ChangeStatusTask(int idStatus,int idFeature)
        {
            int kq = (new FeatureDao().ChangeStatusTask(idStatus, idFeature));
            return Json(kq);
        }
    }



}