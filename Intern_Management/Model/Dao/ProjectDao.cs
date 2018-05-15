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

    }
}
