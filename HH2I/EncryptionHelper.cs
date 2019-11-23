namespace House2Invest
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public static class EncryptionHelper
    {
        public static string Decrypt(string cipherText)
        {
            string password = "a4c1c8b60b7b4880b58b97bc8a277a22c341f8da59d04691943704d6e4648db0";
            cipherText = cipherText.Replace(" ", "+");
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                byte[] salt = new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 };
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt);
                aes.Key = bytes.GetBytes(0x20);
                aes.IV = bytes.GetBytes(0x10);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream stream2 = new CryptoStream((Stream) stream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        stream2.Write(buffer, 0, buffer.Length);
                        stream2.Close();
                    }
                    cipherText = Encoding.get_Unicode().GetString(stream.ToArray());
                }
            }
            return cipherText;
        }

        public static string Encrypt(string clearText)
        {
            string password = "a4c1c8b60b7b4880b58b97bc8a277a22c341f8da59d04691943704d6e4648db0";
            byte[] buffer = Encoding.get_Unicode().GetBytes(clearText);
            using (Aes aes = Aes.Create())
            {
                byte[] salt = new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 };
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt);
                aes.Key = bytes.GetBytes(0x20);
                aes.IV = bytes.GetBytes(0x10);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream stream2 = new CryptoStream((Stream) stream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        stream2.Write(buffer, 0, buffer.Length);
                        stream2.Close();
                    }
                    clearText = Convert.ToBase64String(stream.ToArray());
                }
            }
            return clearText;
        }
    }
}

