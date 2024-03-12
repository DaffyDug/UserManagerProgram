using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        IAction[] actions = new IAction[]
        {
            new adduser(),
            new RemuveUser(),
            new InformationAllUsers()
        };
        while (true)
        {
            Menu();

            if (int.TryParse(Console.ReadLine(), out int intvalue))
            {
                if (intvalue >= 1 && intvalue <= actions.Length)
                {
                    actions[intvalue - 1].Run();
                }
            }


        }
    }
    static public void Menu()
    {
        Console.WriteLine("1. Add Users");
        Console.WriteLine("2. Remuve Users");
        Console.WriteLine("3. Print All Informations Users");
    }
}
public interface IAction
{
    public void Run();
}
class UserManager
{
    public static readonly UserManager userManager;
    private UserManager()
    { }
    static UserManager()
    {
        userManager = new UserManager();
    }

    List<User> users = new List<User>();

    public void AddUser()
    {
        Console.WriteLine("введите имя пользователя: ");
        string FirstName = Console.ReadLine();
        Console.WriteLine("введите фамилию пользователя: ");
        string LastName = Console.ReadLine();
        if (FirstName.Length != 0 && LastName.Length != 0)
        {

            User user = new User(FirstName, LastName, DateTime.Today);
            users.Add(user);
        }
        else
        {
            Console.WriteLine("you can't fit the void");
        }
    }
    public void RemoveUser()
    {
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}--{users[i].FirstName}");
        }
        if (users.Count != 0)
        {
            int.TryParse(Console.ReadLine(), out int intvalue);
            if (intvalue >= 1 && intvalue <= users[intvalue - 1].FirstName.Length)
            {
                users.RemoveAt(intvalue - 1);
            }
            else
            {
                Console.WriteLine("You'r don't have this User");
            }
        }
        else
        {
            Console.WriteLine("You don't have Users");
        }
    }
    public void InformatoinUsers()
    {
        if (users.Count != 0)
        {
            foreach (var item in users)
            {
                item.PrintInfo();
            }
        }
        else
        {
            Console.WriteLine("You don't have Users");
        }
    }
}

class adduser : IAction
{
    public void Run()
    {
        UserManager.userManager.AddUser();
    }

}
class RemuveUser : IAction
{
    public void Run()
    {
        UserManager.userManager.RemoveUser();
    }
}
class InformationAllUsers : IAction
{
    public void Run()
    {
        UserManager.userManager.InformatoinUsers();
    }
}

public class User
{
    public string FirstName { get; private set; }
    private string SecondName;
    private DateTime Datetime;
    public User(string firstName, string secondName, DateTime datetime)
    {
        FirstName = firstName;
        SecondName = secondName;
        Datetime = datetime;
    }
    public void PrintInfo()
    {
        Console.WriteLine(FirstName + '\n');
        Console.WriteLine(SecondName + '\n');
        Console.WriteLine($"{Datetime}\n");
    }
}