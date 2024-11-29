using PasswordConsole.Helpers;
using PasswordLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordConsole
{
    internal static class ContainerController
    {
        public static void Start(PasswordContainer container)
        {
            string toDo = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[enter] exit | [+] add | [-] remove");
                Console.WriteLine("-- Folders --");
                int count = 0;
                foreach (var item in container.Folders)
                {
                    Console.WriteLine($"[{count.ToString().PadLeft(container.Folders.Count.ToString().Length)}] {item.Name}");
                    count++;
                }

                Console.WriteLine(" ");
                Console.Write("Input : ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "+":
                        AddFolder(container);
                        break;
                    case "-":
                        RemoveFolder(container);
                        break;
                    default:
                        if (int.TryParse(input, out int res) && res >= 0 && res < container.Folders.Count)
                        {
                            FolderController.ShowFolder(container.Folders[res]);
                        }
                        return;
                }
            }
        }

        private static void RemoveFolder(PasswordContainer container)
        {
            Console.Write("Id removed : ");
            var foldIndex = Console.ReadLine();

            if (!int.TryParse(foldIndex, out int res) || res < 0 || container.Folders.Count <= res)
            {
                return;
            }
            container.Folders.RemoveAt(res);
        }
        private static void AddFolder(PasswordContainer container)
        {
            Console.Write("New folder name : ");
            var foldName = Console.ReadLine();

            if (string.IsNullOrEmpty(foldName))
            {
                return;
            }

            container.Folders.Add(new PasswordFolder()
            {
                Name = foldName,
            });
        }
    }
}
