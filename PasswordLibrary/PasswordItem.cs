using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PasswordLibrary
{
    public class PasswordItem
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
