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

        public User GetIsManager(int projectID)
        {
            int UserID = (db.ProjectMembers.SingleOrDefault(x => x.ProjectID == projectID && x.RoleID == 2)).UserID;
            return db.Users.Find(UserID);
        }
        public User GetByUserName(string usename )
        {
            return db.Users.SingleOrDefault(x => x.UserName == usename);
        }
        public List<User> GetManager()
        {
            List<User> dsManager =new  List<User>();
            var result = (from dl in db.Users
                          where dl.RoleID == 2// roleid=2 la id cua manager

                          select dl).Distinct();


            foreach (var item in result)
            {
                dsManager.Add(item);
            }

            return dsManager;

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
        public bool Delete(User entity)
        {
            try
            {
                db.Users.Remove(entity);
                 db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        public bool Delete(List<User> ds)
        {
            try
            {
                db.Users.RemoveRange(ds);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }
        public User GetByUserId(int userId)
        {
            return db.Users.Find(userId);

        }
        public bool ActiveUser(User entity)
        {
           if( db.Users.Find(entity.UserID)==null)
           {
                return false;
           }
           else
           {
                entity.Stat = true;
                db.SaveChanges();
                return true;
           }

        }//chua dung
        public List<User> ListNonActiveStatus()
        {
            var query = from c in db.Users
                        where c.Stat == false
                        select c;
            return query.ToList();
        }//chua dung
        public int RegisterByStudent(User entity)
        {
            try
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }


        }//chua dung



    }
}
