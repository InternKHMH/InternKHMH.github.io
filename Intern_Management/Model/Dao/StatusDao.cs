using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class StatusDao
    {
        InternDB db;
       public StatusDao()
        {
            db = new InternDB();
        }
        public List<StatusCheck> GetAll()
        {
            return db.StatusChecks.ToList();
        }

        public string GetStatusNameByID(int StatusID)
        {
            return db.StatusChecks.Find(StatusID).StatusName;
        }
    }
}
