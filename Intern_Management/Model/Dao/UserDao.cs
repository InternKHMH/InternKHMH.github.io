using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model.Dao
{
   public class UserDao
    {
        InternShipDb db;
        public UserDao()
        {
            db = new InternShipDb();
        }

        //lay danh sach intern dang tham gia project voi mot ProjectID

        //public List<User> GetAllUserByProjectID(int ProjectID)
        //{
            
        //}


    }
}
