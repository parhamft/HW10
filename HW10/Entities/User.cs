using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW10.DB;
using HW10.Enums;

namespace HW10.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string userName { get; set; }
        public string password { get; set; }
        public StatusEnum status { get; set; } 

        public User(int Id, string username, string password)
        {
            this.Id = Id;
            userName = username;
            this.password = password;
             this.status = StatusEnum.available;

        }
        public User()
        {
            
        }
        public string ChangeStatus(int status)
        {
            if ((StatusEnum)status == this.status) { return $"your account is already {this.status}"; }
            this.status = (StatusEnum)status;

            return $"your account is now {this.status}";
        }
        public void changePassword(string Currpassword, string password)
        {
            this.password=password;
        }
    }
}