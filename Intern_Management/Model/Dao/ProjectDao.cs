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
        InternShipDb db;
        public ProjectDao ()
        {
            db = new InternShipDb();
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

    }
}
