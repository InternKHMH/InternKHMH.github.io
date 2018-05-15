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

            //var query = from user in db.Users
            //            where user.Projects.Any(c => c.ProjectID == ProjectID)
            //            select user;

            var query = from user in db.Users
                        where user.ProjectMembers.Any(c => c.ProjectID == ProjectID)
                        select user;
            return query.ToList();
        }


        public User GetByUserName(string usename )
        {
            return db.Users.SingleOrDefault(x => x.UserName == usename);
        }

        public int CheckLogin(string UserName, string Password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == UserName);
            if (result ==null)
            {
                return -1;
            }
            else
            {
                result = db.Users.SingleOrDefault(x =>x.UserName==UserName &&  x.Passwords == Password);
                if(result==null)
                {
                    return -2;

                }
                else
                {
                    if (result.Stat == false) return 0;
                    return 1;
                }
            }
        }


    }
}
