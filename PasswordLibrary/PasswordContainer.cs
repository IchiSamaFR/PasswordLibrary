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
        public bool Load(string file)
        {
            try
            {
                if (!File.Exists(file))
                {
                    return false;
                }
                var text = File.ReadAllText(file);
                var decryptedTxt = _encryptor.DecryptString(text);
                Folders = JsonSerializer.Deserialize<List<PasswordFolder>>(decryptedTxt) ?? new List<PasswordFolder>();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
