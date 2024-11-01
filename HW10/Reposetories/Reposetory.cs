using HW10.Contracts;
using HW10.DB;
using HW10.Entities;

namespace HW10.Reposetories
{
    public class Reposetory : IReposetory
    {
        public void AddUser(User U)
        {
            Storage.AddUserToFile(U);
        }



        public void ChangeStatus(int id, int status)
        {
            List<User>? temp = Storage.GetUserFromFile();
            var result = temp.First(p => p.Id == id);
            result.ChangeStatus(status);
            Storage.SaveList(temp);
        }

        public List<User> GetAllUsers()
        {
            return Storage.GetUserFromFile();
        }

        public bool ChangePassword(int id, string curPassword, string newPassword)
        {
            List<User>? temp = Storage.GetUserFromFile();
            var result = temp.First(p => p.Id == id);
            result.changePassword(curPassword, newPassword);
            Storage.SaveList(temp);
            return true;
        }
    }
}
