using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;



namespace Model.Dao
{
    
   public class ProjectDao
    {
        InternDB db;
        public ProjectDao ()
        {
            db = new InternDB();
        }
        public Model.EF.Project GetByID(int ProjectID)
        {
            Model.EF.Project pro = db.Projects.SingleOrDefault(x => x.ProjectID==ProjectID);
            return pro;
        }
        public List<Project> ListAll()
        {
            
            return db.Projects.ToList();
           
        }

        public List<Project> GetListProjectByManager(int managerID)
        {
            List<Project> dsProject = new List<Project>();
           var  result = from dl in db.ProjectMembers
                                    where dl.RoleID == 2 && dl.UserID == managerID
                                    select dl.ProjectID;
            List<int> dsProjectID = result.ToList();

            //lay ds prject 

            foreach(int item in dsProjectID)
            {
                dsProject.Add(GetByID(item));
            }
            return dsProject;

        }

        public int CountProjectByStatusID(int statusID)
        {
            return db.Projects.Count(x => x.StatusID == statusID);
        }
        public int Add(string projectName,DateTime startDate,DateTime endDate,int userID)
        {
            Project oneProject=new Project
            {

                ProjectName = projectName,
                EndDate = endDate,
                StartDate = startDate,
                StatusID = 4
               
            };
            try
            {
                 Project result = db.Projects.Add(oneProject);
                
                db.SaveChanges();
                oneProject.ProjectMembers.Add(new ProjectMember { ProjectID = result.ProjectID, UserID = userID, RoleID = 2 });
                db.SaveChanges();
                return result.ProjectID;
            }
            catch
            {
                return -1;
            }
        }
        public bool Delete(int projectID)
        {
           
           
            Project temp = GetByID(projectID);
            if(temp==null)
            {
                return false;
            }
            else
            {
                db.Projects.Remove(temp);
                db.SaveChanges();
                return true;
            }
            
        }
        /// <summary>
        /// get infomation leader project with projectID
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public User GetLeaderProject(int projectID)
        {
            try
            {
                int userID = (db.ProjectMembers.SingleOrDefault(
                    x =>x.ProjectID == projectID && x.RoleID == 3)).UserID;
                return db.Users.SingleOrDefault(x => x.UserID == userID);
            }
            catch
            {
                return null;
            }
            
        }

        public Dictionary<int,string> GetManager()
        {
            Dictionary<int, string> dsManager = new Dictionary<int, string>();
            var result = (from dl in db.Users
                          where dl.RoleID == 2// roleid=2 la id cua manager

                          select dl.UserID).Distinct();
            
              
            foreach(var item in result)
            {
                int key = item;
                string value = (db.Users.Find(key)).FullName;
                dsManager.Add(key, value);
            }

            return dsManager;
    
        }
        public int Update(Project entity,int newManager,int oldManager)
        {
            try
            {
                var project = db.Projects.Find(entity.ProjectID);
                if (project == null) return -1;
                project.ProjectName = entity.ProjectName;
                project.StartDate = entity.StartDate;
                project.EndDate = entity.EndDate;
                db.SaveChanges();
                //update lai manager ben bang project member
                ProjectMemberDao pr = new ProjectMemberDao();
                if (newManager != oldManager)
                   return pr.UpdateManager(oldManager, newManager, entity.ProjectID);

                return 1;
            }
        
            catch
            {
                return 0;
            }
           

            
            
        }

    }
}
