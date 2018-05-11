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
        InternDB db;
        public UserDao()
        {
            db = new InternDB();
        }

        //lay danh sach intern dang tham gia project voi mot ProjectID
        public List<User> GetAllUserByProjectID(int ProjectID)
        {

            var query = from user in db.Users
                        where user.Projects.Any(c => c.ProjectID == ProjectID)
                        select user;
            return query.ToList();
        }


    }
}
