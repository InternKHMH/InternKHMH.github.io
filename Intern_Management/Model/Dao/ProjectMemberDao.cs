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
        
    }
}
