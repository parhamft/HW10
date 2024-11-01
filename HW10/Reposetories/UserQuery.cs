using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.
    setories
{
    public static class UserQuery
    {
        public static string create = "insert into Users (Id,userName,password,status) values (@id,@userName,@password, @status)";
        public static string Get = "select * from Users";
        public static string changePassword = "Update users SET password= @password where Id = @Id";
        public static string changeStatus = "Update users SET status= @status where Id = @Id";
        public static string GetById = "select * from Users where Id = @Id";
    }
}
