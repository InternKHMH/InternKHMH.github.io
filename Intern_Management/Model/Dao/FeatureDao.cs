using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model.Dao
{
   public class FeatureDao
   {
        InternDB db;
        public FeatureDao()
        {
            db = new InternDB();
        }
        public List<Feature> GetByProjectID(int ProjectID)
        {
            var result = from kq in db.Features
                         where kq.ProjectID == ProjectID
                         select kq;
            return result.ToList();
        }

        //lấy danh sách thông tin các feature với  par UserID,và ProjectID

        public List<Feature> GetByUserID(int UserID, int ProjectID)
        {
            var result = from feature in db.Features
                         where feature.UserID == UserID && feature.ProjectID==ProjectID
                         select feature;
            return result.ToList();
        }
        

   }
}
