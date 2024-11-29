using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PasswordLibrary
{
    public class PasswordFolder
    {
        public string Name { get; set; }
        public List<PasswordItem> Passwords { get; set; } = new List<PasswordItem>();
    }
}
