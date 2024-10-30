using HW10.Contracts;
using HW10.Entities;
using HW10.Reposetories;
using HW10.Servises;

bool isfinished = false;
IReposetory repo = new Reposetory();
authenthication auth = new authenthication();
UserService service = new UserService();
User currentUser = null;
while (isfinished == false)
{
    Console.Clear();
    Dictionary<string, string> dic = new Dictionary<string, string>();
    try
    {
        Console.Write("Enter Command : ");
        string[] input = Console.ReadLine().Split(" ");
        if (input[0].ToLower() == "register")
        {
            if (currentUser != null) { throw new Exception("your already loged in !"); }
            if (input.Length != 5) { throw new Exception("incorrect command (make sure to not put extra spaces)"); }
            if (input[1].ToLower() != "--username") { throw new Exception("the second input must be (--username)"); }
            if (input[3].ToLower() != "--password") { throw new Exception("the forth input must be (--password)"); }
            dic.Add(input[1].ToLower(), input[2]);
            dic.Add(input[3].ToLower(), input[4]);

            Console.WriteLine(auth.Register(dic["--username"], dic["--password"]));
            Console.ReadKey();
        }
        else if (input[0].ToLower() == "login")
        {
            if (currentUser != null) { throw new Exception("your already loged in !"); }
            if (input.Length != 5) { throw new Exception("incorrect command (make sure to not put extra spaces)"); }
            if (input[1].ToLower() != "--username") { throw new Exception("the second input must be (--username)"); }
            if (input[3].ToLower() != "--password") { throw new Exception("the forth input must be (--password)"); }
            dic.Add(input[1].ToLower(), input[2]);
            dic.Add(input[3].ToLower(), input[4]);

            currentUser = auth.login(dic["--username"], dic["--password"]);
            if (currentUser != null) { Console.WriteLine("Loged In!"); }
            else { Console.WriteLine("password or username is incorrect!"); }
            Console.ReadKey();
        }
        else if (input[0].ToLower() == "change")
        {
            if (currentUser == null) { throw new Exception("your not loged in !"); }
            if (input.Length != 3) { throw new Exception("incorrect command (make sure to not put extra spaces)"); }
            if (input[1].ToLower() != "--status") { throw new Exception("the second input must be (--status)"); }
            dic.Add(input[1].ToLower(), input[2]);
            Console.WriteLine(service.ChangeStatus(currentUser.Id, dic["--status"]));
            Console.ReadKey();
        }
        else if (input[0].ToLower() == "search")
        {
            if (currentUser == null) { throw new Exception("your not loged in !"); }
            if (input.Length != 3) { throw new Exception("incorrect command (make sure to not put extra spaces)"); }
            if (input[1].ToLower() != "--username") { throw new Exception("the second input must be (--username)"); }
            dic.Add(input[1].ToLower(), input[2].ToLower());
            Console.WriteLine(service.search(dic["--username"]));
            Console.ReadKey();
        }
        else if (input[0] == "changepassword")
        {
            if (currentUser == null) { throw new Exception("your not loged in !"); }
            if (input.Length != 5) { throw new Exception("incorrect command (make sure to not put extra spaces)"); }
            if (input[1].ToLower() != "--old") { throw new Exception("the second input must be (--old)"); }
            if (input[3].ToLower() != "--new") { throw new Exception("the forth input must be (--new)"); }
            dic.Add(input[1].ToLower(), input[2]);
            dic.Add(input[3].ToLower(), input[4]);
            Console.WriteLine(service.ChangePassword(currentUser.Id, dic["--old"], dic["--new"]));
            Console.ReadKey();
        }
        else if (input[0].ToLower() == "logout")
        {
            if (currentUser == null) { throw new Exception("your bot loged in"); }
            else { currentUser=null; }
            Console.WriteLine("Loged out");
            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }
}