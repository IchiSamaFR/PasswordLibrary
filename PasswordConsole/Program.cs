using PasswordConsole;
using PasswordConsole.Helpers;
using PasswordLibrary;
using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static PasswordContainer _passwordContainer;

    static void Main(string[] args)
    {
        Console.Write("Password : ");
        var pass = ConsoleHelper.GetPassword();
        _passwordContainer = new PasswordContainer(pass);

        Action();
    }

    private static void Action()
    {
        ContainerController.Start(_passwordContainer);
    }
}