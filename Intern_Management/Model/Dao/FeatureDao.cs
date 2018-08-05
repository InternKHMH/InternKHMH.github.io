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
        public List<Model.EF.Feature> GetAllDueDateTask(int userID)
        {
            var date = Convert.ToDateTime(DateTime.Now.Date);

            var result = from feature in db.Features
                         where feature.UserID == userID && feature.endDate.Value.Day == DateTime.Now.Day && feature.endDate.Value.Year==DateTime.Now.Year && feature.endDate.Value.Month==DateTime.Now.Month
                         select feature;
            return result.ToList();
        }
        public int AddTask(Feature entity)
        {
            try
            {
                Feature dl = new Feature();
                dl.FeatureName = entity.FeatureName;
                dl.endDate = entity.endDate;
                dl.ImagesFeatures = entity.ImagesFeatures;
                dl.Descrip = entity.Descrip;
                dl.UserID = entity.UserID;
                dl.StatusID = entity.StatusID;
                dl.startDate = DateTime.Now;

                var result = db.Features.Add(entity);
                db.SaveChanges();
                return result.FeatureID;
            }
            catch
            {
                return 0;
            }
        }
        public int ChangeStatusTask(int idStatus,int idTask)
        {
           try
            {
                var feature = db.Features.Find(idTask);
                if (feature == null) return 0;
                else
                {
                    feature.StatusID = idStatus;
                    db.SaveChanges();
                    return 1;
                }

            }
            catch { return 0; }
        }
       
   }
}
