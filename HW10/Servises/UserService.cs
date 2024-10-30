using HW10.Contracts;
using HW10.Entities;
using HW10.Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Servises
{
    public class UserService
    {
        IReposetory repo = new Reposetory();
        
        public string search(string srch)
        {
            string str = "";
            foreach (User u in repo.GetAllUsers())
            {
                if (u.userName.ToLower().IndexOf(srch)!= -1)
                {
                    str += $"{u.Id}) {u.userName} | {u.status}\n";
                }
            }
            if (str == "") { return "no user found"; }
            return str;
        }
        public string ChangePassword(int id, string curpass,string newpass)
        {
            repo.ChangePassword(id, curpass, newpass);
            return "password changed";
        }
        public string ChangeStatus(int id, string status)
        {
            if (status.ToLower() == "available") { repo.ChangeStatus(id, 1); return "your now available"; }
            else if (status.ToLower() == "not_available") { repo.ChangeStatus(id,2); return "your now not available"; }
            else { return("you can only put (available or not_available) as your status!"); }
        }
    }
}
