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
        public List<User> ListNonActiveStatus(int numberSkip)
        {
            try
            {
                    var query = (from c in db.Users
                        where c.Stat == false
                        select c).Take(6*(numberSkip+1));
                    var dl = query.ToList().Skip(6 * numberSkip);
                    return dl.ToList();
            }
            catch
            {
                var query = (from c in db.Users
                             where c.Stat == false
                             select c);
                return query.ToList();
            }
           
            
        }
        public int RegisterByStudent(User entity)
        {
            //kiem tra xem da co user ten do chua
            var temp = from c in db.Users
                        where c.UserName == entity.UserName
                        select c;
            if (temp.Count() > 0)
                return -1;

            try
            {
               User gitritrave= db.Users.Add(entity);
                db.SaveChanges();
                return gitritrave.UserID;
            }
            catch
            {
                return 0;
            }


        }//chua dung
        public List<User> Load7Intern(int page)
        {
            
            try
            {
                    var query = ((from c in db.Users
                                  orderby c.FullName descending
                                  where c.RoleID == 4
                                  select c).Take(7*(page+1)));
                    var dl = (from b in query
                    select b).Skip(7*page);
                    return dl.ToList();

            }
            catch 
            {
                var query = (from c in db.Users
                             where c.RoleID == 4
                             select c);
                return query.ToList();
            }


        }
        public bool Update(User entity)
        {
            User oldus = db.Users.Find(entity.UserID);

            if (oldus!=null)
            {
                oldus = entity;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public  int SoPageTrangInternManager()
        {
            var query = from c in db.Users
                        select c;

            if(query.Count()%7==0)
            {
                return query.Count() / 7;
            }             
            else
            {
                return query.Count() / 7 + 1;
            }
        }
        public List<User> GetAllUser(int? rolID, int projectID)
        {
            var result=from dl in db.Users
                       where dl.RoleID==rolID && dl.Stat==true
                       select dl;

            
            return result.ToList();
        }
        public int? IsLeader(int userId,int projecID)
        {
            var result = db.ProjectMembers.SingleOrDefault(x => x.UserID == userId && x.ProjectID == projecID);

            if (result == null) return 0;
            else
            {
                return result.RoleID;
            }
        }

    }
}
