namespace House2Invest
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;

    public static class StringCipher
    {
        private const int Keysize = 0x100;
        private const int DerivationIterations = 0x3e8;

        public static string Decrypt(string cipherText, string passPhrase)
        {
            string str;
            passPhrase = Startup._CHAVECRYP;
            byte[] buffer = Convert.FromBase64String(cipherText);
            byte[] salt = Enumerable.ToArray<byte>(Enumerable.Take<byte>(buffer, 0x20));
            byte[] rgbIV = Enumerable.ToArray<byte>(Enumerable.Take<byte>(Enumerable.Skip<byte>(buffer, 0x20), 0x20));
            byte[] buffer4 = Enumerable.ToArray<byte>(Enumerable.Take<byte>(Enumerable.Skip<byte>(buffer, 0x40), buffer.Length - 0x40));
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(passPhrase, salt, 0x3e8))
            {
                byte[] rgbKey = bytes.GetBytes(0x20);
                using (RijndaelManaged managed = new RijndaelManaged())
                {
                    managed.BlockSize = 0x100;
                    managed.Mode = CipherMode.CBC;
                    managed.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform transform = managed.CreateDecryptor(rgbKey, rgbIV))
                    {
                        using (MemoryStream stream = new MemoryStream(buffer4))
                        {
                            using (CryptoStream stream2 = new CryptoStream((Stream) stream, transform, CryptoStreamMode.Read))
                            {
                                byte[] buffer6 = new byte[buffer4.Length];
                                stream.Close();
                                stream2.Close();
                                str = Encoding.UTF8.GetString(buffer6, 0, stream2.Read(buffer6, 0, buffer6.Length));
                            }
                        }
                    }
                }
            }
            return str;
        }

        public static string Encrypt(string plainText, string passPhrase)
        {
            string str;
            passPhrase = Startup._CHAVECRYP;
            byte[] salt = Generate256BitsOfRandomEntropy();
            byte[] rgbIV = Generate256BitsOfRandomEntropy();
            byte[] buffer = Encoding.UTF8.GetBytes(plainText);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(passPhrase, salt, 0x3e8))
            {
                byte[] rgbKey = bytes.GetBytes(0x20);
                using (RijndaelManaged managed = new RijndaelManaged())
                {
                    managed.BlockSize = 0x100;
                    managed.Mode = CipherMode.CBC;
                    managed.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform transform = managed.CreateEncryptor(rgbKey, rgbIV))
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            using (CryptoStream stream2 = new CryptoStream((Stream) stream, transform, CryptoStreamMode.Write))
                            {
                                stream2.Write(buffer, 0, buffer.Length);
                                stream2.FlushFinalBlock();
                                byte[] inArray = Enumerable.ToArray<byte>(Enumerable.Concat<byte>(Enumerable.ToArray<byte>(Enumerable.Concat<byte>(salt, rgbIV)), stream.ToArray()));
                                stream.Close();
                                stream2.Close();
                                str = Convert.ToBase64String(inArray);
                            }
                        }
                    }
                }
            }
            return str;
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            byte[] data = new byte[0x20];
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(data);
            }
            return data;
        }
    }
}

