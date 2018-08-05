using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.Dao;

namespace Model.Dao
{
    public class ProjectMemberDao
    {
        InternDB db;
        public ProjectMemberDao()
        {
            db = new InternDB();
        }

        public bool DeleteByProjectID(int projectID)
        {
            try
            {
                db.ProjectMembers.RemoveRange(GetAllByProjectID(projectID));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public List<ProjectMember> GetAllByProjectID(int projectID)
        {
            var result = from pl in db.ProjectMembers
                         where pl.ProjectID == projectID
                         select pl;
            return result.ToList();
        }
        public int UpdateManager(int oldManagerID,int newManagerID,int projectID)
        {
            try
            {
                var result = db.ProjectMembers.SingleOrDefault(x => x.ProjectID == projectID && x.UserID == oldManagerID && x.RoleID==2) ;
                if(result==null)//neu chua co thi them 
                {
                    db.ProjectMembers.Add(new ProjectMember() { ProjectID = projectID, UserID = newManagerID, RoleID = 2 });
                    db.SaveChanges();
                }
                else //co roi thi cap nhat lai
                {
                     result.UserID = newManagerID;
                      db.SaveChanges();
                }
              
                return 1;
            }
            catch
            {
                return 0;
            }
          
        }
        public int AssignScrumMaster(int? projectID, int? scrumMasterID)
        {
            // buoc 1: dua scrum master cu tro lai thanh member 
            //tim project bang id project va co role =3 update lai  thanh role 4
            var result = from c in db.ProjectMembers
                         where c.ProjectID == projectID && c.RoleID == 3
                         select c;
            if (result.ToList<ProjectMember>().Count == 0)
            {
                ProjectMember uppr = db.ProjectMembers.SingleOrDefault(x => x.ProjectID == projectID && x.UserID == scrumMasterID);
                if (uppr == null) return 0;
                else
                {
                    uppr.RoleID = 3;
                    db.SaveChanges();
                    return 1;

                }
            }
            else
            {
                foreach (ProjectMember item in result.ToList<ProjectMember>())
                {
                    item.RoleID = 4;
                    db.SaveChanges();
                }

                ProjectMember uppr = db.ProjectMembers.SingleOrDefault(x => x.ProjectID == projectID && x.UserID == scrumMasterID);
                if (uppr == null) return 0;
                else
                {
                    uppr.RoleID = 3;
                    db.SaveChanges();
                    return 1;

                }

            }


        }
        private List<int> GetAllManager()
        {
            List<int> ds = (from c in db.ProjectMembers
                            where c.RoleID == 2
                            select c.UserID ).Distinct().ToList();
            return ds;
        }
        public List<User> Top4IDUserJoinedProject()
        {
            List<int> dsManagerProject = GetAllManager();
            List<User> dl = new List<User>();
            var query = from user in db.ProjectMembers   // cau truy van nay chua toi uu co thoi gian code lai
                        group user by user.UserID into userprojectGroup

                        orderby userprojectGroup.Count() descending
                        select new {  userId = userprojectGroup.Key, soprojectthamgia = userprojectGroup.Count() };
            var temp = query.ToList();

           
            foreach(var c in temp)
            {
                int co = 0;
                foreach(int d in dsManagerProject)
                {
                    if(c.userId==d)
                    {
                        co = 1;
                        break;
                     
                    }
                }
                if (co == 0) { dl.Add((new UserDao()).GetByUserId(c.userId)); }
            }
            
            return dl;
        }
        public ProjectMember Add(int projectID, int userID, int roleID)
        {
          
            try
            {
               ProjectMember ketqua= db.ProjectMembers.Add(new ProjectMember() { ProjectID = projectID, UserID = userID, RoleID = roleID });
                db.SaveChanges();
                
                return ketqua;
            }
            catch
            {
                return null;
            }
             

        }

        public int KiemTraUserCoThamGiaProject(int userID,int projecID)
        {
            try
            {
                 var result = db.ProjectMembers.SingleOrDefault(x => x.UserID == userID && x.ProjectID == projecID);
                if (result != null)
                    return 1;
                else
                    return 0;
            }
            catch { return 0; }
          
            
        }
    }
}
