using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordConsole.Helpers
{
    public static class ConsoleHelper
    {
        public static string GetPassword()
        {
            int baseCursor = Console.CursorLeft;

            StringBuilder passwordBuilder = new StringBuilder();
            bool continueReading = true;
            char newLineChar = '\r';
            while (continueReading)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                char passwordChar = consoleKeyInfo.KeyChar;

                if (passwordChar == newLineChar)
                {
                    continueReading = false;
                }
                else
                {
                    if (passwordChar == '\b')
                    {
                        passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
                    }
                    else
                    {
                        passwordBuilder.Append(passwordChar.ToString());
                    }
                    Console.CursorLeft = baseCursor;
                    Console.Write(new string('*', passwordBuilder.Length));
                    Console.Write(new string(' ', 1));
                    Console.CursorLeft = baseCursor + passwordBuilder.Length;
                }
            }
            Console.WriteLine();
            return passwordBuilder.ToString();
        }
    }
}
