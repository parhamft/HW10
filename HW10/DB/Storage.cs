using HW10.Entities;
using System.Text;
using Newtonsoft.Json;


namespace HW10.DB
{
    public static class Storage
    {


        static string dir = @"D:\C#\HW\HW10\HW10\DB\DataBase.txt";
        public static List<User>? users { get; set; } = new List<User>();



        public static void AddUserToFile(User U)
        {
            users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(dir));

            users.Add(U);
            string text = JsonConvert.SerializeObject(users);
            File.WriteAllText(dir, text, Encoding.UTF8);
            users.Clear();
        }
        public static List<User> GetUserFromFile()
        {
            string readtext = File.ReadAllText(dir);
            List<User> users=JsonConvert.DeserializeObject<List<User>>(readtext);
            return users;
        }
        public static void SaveList(List<User> userlist)
        {
            string text = JsonConvert.SerializeObject(userlist);
            File.WriteAllText(dir, text, Encoding.UTF8);
            users.Clear();
        }
    }
}
