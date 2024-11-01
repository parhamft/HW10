using Dapper;
using HW10.Contracts;
using HW10.Entities;
using System.Data;
using System.Data.SqlClient;

namespace HW10.
    
    setories
{
    public class SQLRepo : IReposetory
    {
        readonly string conectionString = "Server = DESKTOP-03R7JG5\\SQLEXPRESS; Database=Users;Trusted_Connection=True;";
        public void AddUser(User U)
        {
            using (IDbConnection db = new SqlConnection(conectionString))
            {
                db.Execute(UserQuery.create, new { U.Id, U.userName, U.password, U.status });
            }
        }

        public bool ChangePassword(int id, string curPassword, string newPassword)
        {
            using (IDbConnection db = new SqlConnection(conectionString))
            {
                var user = db.QueryFirstOrDefault<User>(UserQuery.GetById, new { Id = id });
                if (user.password == curPassword)
                { db.Execute(UserQuery.changePassword, new { Id = id, password = newPassword }); return true; }
                return false;
            }
        }

        public void ChangeStatus(int id, int STATUS)
        {
            using (IDbConnection db = new SqlConnection(conectionString))
            {
                db.Execute(UserQuery.changeStatus, new { Id = id, status = STATUS });
            }
        }

        public List<User> GetAllUsers()
        {
            using (IDbConnection db = new SqlConnection(conectionString))
            {
                return db.Query<User>(UserQuery.Get).ToList();
            }
        }
    }



}
