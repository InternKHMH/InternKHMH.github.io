using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace Intern_Management.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult PostImageCover(HttpPostedFileBase file)
        {
            try
            {
                //xóa tất cả dư liệu trong file tạm

                DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Asset/ImagesTemp"));
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
            }
            catch { }

            string path = Server.MapPath(""); 
            if (file != null)
            {
                path = Server.MapPath("~/Asset/ImagesTemp/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                   
                }
                file.SaveAs(path + Path.GetFileName(file.FileName));
            }
           

            return Json(file.FileName);
        }
        private bool renamePicture(string path,string newName)
        {
            bool ret = false;
            
            System.IO.FileInfo fi = new System.IO.FileInfo(path);
            newName += fi.Extension;
            if (!fi.Exists) return ret;
            string duongdanmoi = Server.MapPath("~/Asset/Images/");
            string newFilePathName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(duongdanmoi), newName);
            System.IO.FileInfo f2 = new System.IO.FileInfo(newFilePathName);
            try
            {
                if(f2.Exists)
                {
                    f2.Attributes = System.IO.FileAttributes.Normal;
                    f2.Delete();
                }
                fi.CopyTo(newFilePathName);
                fi.Delete();
                ret = true;

            }
            catch
            {

            }
            return ret;
            
        }
        [HttpPost]
        public JsonResult AddRegiterByStudent(string username,string fullname,string password,string pc,string university,string userdes,string address,string specialized)
        {
          //đổi tên hình trong thư mục ~/Asset/Images/pc

            UserDao dao = new UserDao();
            Model.EF.User entity = new Model.EF.User();
            entity.UserName = username;
            entity.FullName = fullname;
            
            int vt = pc.LastIndexOf('.');
            string duoianh = pc.Substring(vt);

            entity.imagecover = pc;
            entity.imagelogin = pc;
            entity.RoleID = 4;
            entity.Stat = false;
            entity.userAddress = address;
            entity.University = university;
            entity.Passwords = password;
            entity.specialized = specialized;
            entity.userdes = userdes;
            int userID = dao.RegisterByStudent(entity);

           
            if(userID!=-1 && userID!=0)
            {
                string path = Server.MapPath("~/Asset/ImagesTemp/") + pc;

                renamePicture(path, userID.ToString());
            }

            entity.imagecover = userID.ToString() + duoianh;
            entity.imagelogin = userID.ToString() + duoianh;
            dao.Update(entity);
            return Json( dao.RegisterByStudent(entity));

        }
    }
}