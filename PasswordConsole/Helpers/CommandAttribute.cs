﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordConsole.Helpers
{
    internal class CommandAttribute : Attribute
    {
        public string Name { get; set; }
        public CommandAttribute(string name)
        {
            Name = name;
        }
    }
}
