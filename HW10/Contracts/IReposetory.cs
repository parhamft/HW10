using HW10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Contracts
{
    public interface IReposetory
    {
        List<User> GetAllUsers();
        void AddUser(User U);
        bool ChangePassword(int id, string curPassword, string newPassword);
        void ChangeStatus(int id, int STATUS);
    }

}
