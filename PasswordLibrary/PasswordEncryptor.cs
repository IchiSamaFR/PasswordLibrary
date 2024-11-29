using System.Security.Cryptography;
using System.Text;

namespace PasswordLibrary
{
    public class PasswordEncryptor
    {
        private readonly string _password;

        public PasswordEncryptor(string password)
        {
            _password = password;
        }

        private byte[] GenerateKey()
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(_password));
            }
        }
        public string EncryptString(string input)
        {
            byte[] key = GenerateKey();
            byte[] iv = new byte[16];
            RandomNumberGenerator.Fill(iv);

            using (MemoryStream msOutput = new MemoryStream())
            {
                msOutput.Write(iv, 0, iv.Length);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (CryptoStream cs = new CryptoStream(msOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                        cs.Write(inputBytes, 0, inputBytes.Length);
                    }

                    return Convert.ToBase64String(msOutput.ToArray());
                }
            }
        }
        public string DecryptString(string input)
        {
            byte[] key = GenerateKey();

            byte[] encryptedData = Convert.FromBase64String(input);

            using (MemoryStream msInput = new MemoryStream(encryptedData))
            {
                byte[] iv = new byte[16];
                msInput.Read(iv, 0, iv.Length);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (CryptoStream cs = new CryptoStream(msInput, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (MemoryStream msOutput = new MemoryStream())
                    {
                        cs.CopyTo(msOutput);
                        return Encoding.UTF8.GetString(msOutput.ToArray());
                    }
                }
            }
        }
    }
}
