using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF
{
    public class AccountModel
    {
        //public NguyenThiThanhNgaDBContext context = null;
        //public AccountModel()
        //{

        //}
        //public bool Login(string username, string password)
        //{
        //    object[] SqlPara =
        //     { 
        //        new SqlParameter("@UserName",username),
        //        new SqlParameter("@Password",password),

        //     };
        //    var res = context.Database.SqlQuery<bool>("pr_Account @UserName,@Password",SqlPara).SingleOrDefault();
        //    return res;
        //
        //}

        private NguyenThiThanhNgaDBContext db;
        public AccountModel()
        {
            db = new NguyenThiThanhNgaDBContext();
        }
        public int login (string username, string password)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(username) && x.Password.Contains(password));
            if(result== null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }
        public IEnumerable<UserAccount> ListWhereUser(string keysearch,int page,int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model= model.Where(x => x.UserName.Contains(keysearch));
            }
            return model.OrderBy(x=>x.UserName).ToPagedList(page,pagesize);
        }

        public bool Delete(string UserName)
        {
            try
            {
                var user = db.UserAccounts.Find(UserName);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }
        //public UserAccount Find(string username)
        //{
        //    return db.UserAccounts.Find(username);
        //}
    }
}
