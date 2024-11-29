using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PasswordLibrary
{
    public class PasswordContainer
    {
        private readonly string _password;
        private readonly PasswordEncryptor _encryptor;

        public List<PasswordFolder> Folders { get; set; } = new List<PasswordFolder>();

        public PasswordContainer(string password)
        {
            _password = password;
            _encryptor = new PasswordEncryptor(password);
        }
        public void Load(string file)
        {
            var st = File.ReadAllText(file);
            var str = _encryptor.DecryptString(st);
            Folders = JsonSerializer.Deserialize<List<PasswordFolder>>(str) ?? new List<PasswordFolder>();
        }
        public void Save(string file)
        {
            File.WriteAllText(file, _encryptor.EncryptString(JsonSerializer.Serialize(Folders)));
        }
        public void SaveRaw(string file)
        {
            File.WriteAllText(file, JsonSerializer.Serialize(Folders, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }
    }
}
