namespace House2Invest
{
    using HH2I;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;

    public static class CriptografiaHelper
    {
        private static string ArrayBytesToHexString(byte[] conteudo)
        {
            StringBuilder hex = new StringBuilder(conteudo.Length * 2);
            foreach (byte b in conteudo)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private static Rijndael CriarInstanciaRijndael(string chave, string vetorInicializacao)
        {
            if ((chave == null) || ((chave.Length != 0x10) && ((chave.Length != 0x18) && (chave.Length != 0x20))))
            {
                throw new Exception("A chave de criptografia deve possuir 16, 24 ou 32 caracteres.");
            }
            if ((vetorInicializacao == null) || (vetorInicializacao.Length != 0x10))
            {
                throw new Exception("O vetor de inicializa\x00e7\x00e3o deve possuir 16 caracteres.");
            }
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Encoding.ASCII.GetBytes(chave);
            rijndael.IV = Encoding.ASCII.GetBytes(vetorInicializacao);
            return rijndael;
        }

        public static string Decriptar(string textoEncriptado, string chave ="", string vetorInicializacao="")
        {
            string str2;
            if (string.IsNullOrWhiteSpace(textoEncriptado))
            {
                return "";
            }
            try
            {
                chave = Startup._CHAVECRYP;
                vetorInicializacao = Startup._VETORCRYP;
                if ((textoEncriptado.Length % 2) != 0)
                {
                    throw new Exception("O conte\x00fado a ser decriptado \x00e9 inv\x00e1lido.");
                }
                using (Rijndael rijndael = CriarInstanciaRijndael(chave, vetorInicializacao))
                {
                    ICryptoTransform transform = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
                    string str = null;
                    using (MemoryStream stream = new MemoryStream(HexStringToArrayBytes(textoEncriptado)))
                    {
                        using (CryptoStream stream2 = new CryptoStream((Stream)stream, transform, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(stream2))
                            {
                                str = reader.ReadToEnd();
                            }
                        }
                    }
                    str2 = str;
                }
            }
            catch (Exception)
            {
                str2 = "";
            }
            return str2;
        }

        public static string Encriptar(string textoNormal, string chave="", string vetorInicializacao="")
        {
            string str;
            if (string.IsNullOrWhiteSpace(textoNormal))
            {
                return "";
            }
            try
            {
                chave = Startup._CHAVECRYP;
                vetorInicializacao = Startup._VETORCRYP;
                using (Rijndael rijndael = CriarInstanciaRijndael(chave, vetorInicializacao))
                {
                    ICryptoTransform transform = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (CryptoStream stream2 = new CryptoStream((Stream)stream, transform, CryptoStreamMode.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(stream2))
                            {
                                writer.Write(textoNormal);
                            }
                        }
                        str = ArrayBytesToHexString(stream.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                str = "";
            }
            return str;
        }

        private static byte[] HexStringToArrayBytes(string conteudo)
        {
            int num = conteudo.Length / 2;
            byte[] buffer = new byte[num];
            for (int i = 0; i < num; i++)
            {
                buffer[i] = Convert.ToByte(conteudo.Substring(i * 2, 2), 0x10);
            }
            return buffer;
        }
    }
}

