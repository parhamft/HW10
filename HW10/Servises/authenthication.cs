using HW10.Contracts;
using HW10.DB;
using HW10.Entities;
using HW10.Reposetories;

namespace HW10.Servises
{
    public class authenthication
    {
        IReposetory repo = new Reposetory();
        public string Register(string Username, string password)
        {
            List<User>? users = repo.GetAllUsers();

            int count = repo.GetAllUsers().Count;

            User tuser = repo.GetAllUsers()[count-1];



            if (users == null) { repo.AddUser(new User(tuser.Id+1,Username, password)); return "account created"; }
            foreach (User? U in users)
            {
                if (U.userName == Username) { return "User name is already in use"; }
            }
            repo.AddUser(new User(tuser.Id + 1, Username, password));
            return "account created";
        }
        public User login(string Username, string password)
        {
            foreach (User U in repo.GetAllUsers())
            {
                if (U.userName == Username) { if (U.password == password) { return U; } }


            }
            return null;
        }

    }
}
