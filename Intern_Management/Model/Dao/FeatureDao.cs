﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
   public class FeatureDao
   {
        InternShipDb db;
        public FeatureDao()
        {
            db = new InternShipDb();
        }
        public List<Feature> GetByProjectID(int ProjectID)
        {
            var result = from kq in db.Features
                         where kq.ProjectID == ProjectID
                         select kq;
            return result.ToList();
        }
        

   }
}
