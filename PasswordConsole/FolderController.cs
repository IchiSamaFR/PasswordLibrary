using PasswordConsole.Helpers;
using PasswordLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PasswordConsole
{
    internal static class FolderController
    {
        public static void ShowFolder(PasswordFolder folder)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[enter] exit | [+] add | [-] remove");
                Console.WriteLine($"-- {folder.Name} --");
                int count = 0;
                foreach (var item in folder.Passwords)
                {
                    Console.WriteLine($"[{count.ToString().PadLeft(folder.Passwords.Count.ToString().Length)}] {item.Username}");
                    Console.WriteLine($"- {item.Password}");
                    Console.WriteLine($"- {item.Description}");
                    count++;
                }

                Console.WriteLine(" ");
                Console.Write("Input : ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "+":
                        AddFile(folder);
                        break;
                    case "-":
                        RemoveFile(folder);
                        break;
                    default:
                        return;
                }
            }
        }

        private static void RemoveFile(PasswordFolder folder)
        {
            Console.Write("Id : ");
            var passIndex = Console.ReadLine();

            if (!int.TryParse(passIndex, out int res) || res < 0 || folder.Passwords.Count <= res)
            {
                return;
            }
            folder.Passwords.RemoveAt(res);
        }
        private static void AddFile(PasswordFolder folder)
        {
            Console.Write("Username : ");
            var username = Console.ReadLine();

            if (string.IsNullOrEmpty(username))
            {
                return;
            }

            Console.Write("Password : ");
            var passwod = ConsoleHelper.GetPassword();

            folder.Passwords.Add(new PasswordItem()
            {
                Username = username,
                Password = passwod
            });
        }
    }
}
