namespace House2Invest
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class DepoisdaLinhaEncrypDecryp
    {
        private static readonly byte[] IV;
        private static readonly int BlockSize;
        internal const string Inputkey = "CB57FF93-3007-4E98-A304-CF7B6A60495C";

        static DepoisdaLinhaEncrypDecryp()
        {
            byte[] buffer1 = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0x10 };
            IV = buffer1;
            BlockSize = 0x80;
        }

        public static string Decrypt(string texto)
        {
            string str = "";
            byte[] buffer = Convert.FromBase64String(texto);
            SymmetricAlgorithm algorithm = Aes.Create();
            algorithm.Key = MD5.Create().ComputeHash(Encoding.get_Unicode().GetBytes(Startup._CHAVECRYP));
            algorithm.IV = IV;
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                using (CryptoStream stream2 = new CryptoStream((Stream) stream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] buffer2 = new byte[buffer.Length];
                    stream2.Read(buffer2, 0, buffer2.Length);
                    str = Encoding.get_Unicode().GetString(buffer2);
                }
            }
            return str;
        }

        public static string DecryptData(string EncryptedText, string Encryptionkey)
        {
            Encryptionkey = Startup._CHAVECRYP;
            try
            {
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                managed.Padding = PaddingMode.PKCS7;
                managed.KeySize = 0x80;
                managed.BlockSize = 0x80;
                byte[] inputBuffer = Convert.FromBase64String(EncryptedText);
                byte[] bytes = Encoding.get_UTF8().GetBytes(Encryptionkey);
                byte[] buffer3 = new byte[0x10];
                int length = bytes.Length;
                if (length > buffer3.Length)
                {
                    length = buffer3.Length;
                }
                Array.Copy(bytes, buffer3, length);
                managed.Key = buffer3;
                managed.IV = buffer3;
                byte[] buffer4 = managed.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.get_UTF8().GetString(buffer4);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string DecryptRijndael(string cipherText, string salt)
        {
            string str;
            salt = Startup._CHAVECRYP;
            if (string.IsNullOrEmpty(cipherText))
            {
                throw new ArgumentNullException("cipherText");
            }
            if (!IsBase64String(cipherText))
            {
                throw new Exception("The cipherText input parameter is not base64 encoded");
            }
            RijndaelManaged managed = NewRijndaelManaged(salt);
            ICryptoTransform transform = managed.CreateDecryptor(managed.Key, managed.IV);
            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream stream2 = new CryptoStream((Stream) stream, transform, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(stream2))
                    {
                        str = reader.ReadToEnd();
                    }
                }
            }
            return str;
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if ((cipherText == null) || (cipherText.Length == 0))
            {
                throw new ArgumentNullException("cipherText");
            }
            if ((Key == null) || (Key.Length == 0))
            {
                throw new ArgumentNullException("Key");
            }
            if ((IV == null) || (IV.Length == 0))
            {
                throw new ArgumentNullException("IV");
            }
            string str = null;
            using (RijndaelManaged managed = new RijndaelManaged())
            {
                managed.Key = Key;
                managed.IV = IV;
                ICryptoTransform transform = managed.CreateDecryptor(managed.Key, managed.IV);
                using (MemoryStream stream = new MemoryStream(cipherText))
                {
                    using (CryptoStream stream2 = new CryptoStream((Stream) stream, transform, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream2))
                        {
                            str = reader.ReadToEnd();
                        }
                    }
                }
            }
            return str;
        }

        public static string Encrypt(string texto)
        {
            byte[] bytes = Encoding.get_Unicode().GetBytes(texto);
            SymmetricAlgorithm algorithm = Aes.Create();
            algorithm.BlockSize = BlockSize;
            algorithm.Key = MD5.Create().ComputeHash(Encoding.get_Unicode().GetBytes(Startup._CHAVECRYP));
            algorithm.IV = IV;
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream stream2 = new CryptoStream((Stream) stream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    stream2.Write(bytes, 0, bytes.Length);
                }
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static string EncryptData(string textData, string Encryptionkey)
        {
            Encryptionkey = Startup._CHAVECRYP;
            try
            {
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                managed.Padding = PaddingMode.PKCS7;
                managed.KeySize = 0x80;
                managed.BlockSize = 0x80;
                byte[] bytes = Encoding.get_UTF8().GetBytes(Encryptionkey);
                byte[] buffer2 = new byte[0x10];
                int length = bytes.Length;
                if (length > buffer2.Length)
                {
                    length = buffer2.Length;
                }
                Array.Copy(bytes, buffer2, length);
                managed.Key = buffer2;
                managed.IV = buffer2;
                byte[] inputBuffer = Encoding.get_UTF8().GetBytes(textData);
                return Convert.ToBase64String(managed.CreateEncryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string EncryptRijndael(string text, string salt)
        {
            salt = Startup._CHAVECRYP;
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }
            RijndaelManaged managed = NewRijndaelManaged(salt);
            MemoryStream stream = new MemoryStream();
            using (CryptoStream stream2 = new CryptoStream((Stream) stream, managed.CreateEncryptor(managed.Key, managed.IV), CryptoStreamMode.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream2))
                {
                    writer.Write(text);
                }
            }
            return Convert.ToBase64String(stream.ToArray());
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            byte[] buffer;
            if ((plainText == null) || (plainText.Length <= 0))
            {
                throw new ArgumentNullException("plainText");
            }
            if ((Key == null) || (Key.Length == 0))
            {
                throw new ArgumentNullException("Key");
            }
            if ((IV == null) || (IV.Length == 0))
            {
                throw new ArgumentNullException("IV");
            }
            using (RijndaelManaged managed = new RijndaelManaged())
            {
                managed.Key = Key;
                managed.IV = IV;
                ICryptoTransform transform = managed.CreateEncryptor(managed.Key, managed.IV);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream stream2 = new CryptoStream((Stream) stream, transform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(stream2))
                        {
                            writer.Write(plainText);
                        }
                        buffer = stream.ToArray();
                    }
                }
            }
            return buffer;
        }

        public static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (((base64String.Length % 4) == 0) && Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None));
        }

        private static RijndaelManaged NewRijndaelManaged(string salt)
        {
            if (salt == null)
            {
                throw new ArgumentNullException("salt");
            }
            byte[] buffer = Encoding.get_ASCII().GetBytes(salt);
            Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes("CB57FF93-3007-4E98-A304-CF7B6A60495C", buffer);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Key = bytes.GetBytes(managed.KeySize / 8);
            managed.IV = bytes.GetBytes(managed.BlockSize / 8);
            return managed;
        }
    }
}

