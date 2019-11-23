using House2Invest;
using House2Invest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Imaging;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace House2Invest
{
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using HtmlAgilityPack;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Net.Mail;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    public static class VerificadoresRetornos
    {
        public static bool Emailinvalido = false;
        private static readonly int DEFAULT_MIN_PASSWORD_LENGTH = 8;
        private static readonly int DEFAULT_MAX_PASSWORD_LENGTH = 10;
        private static string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        private static string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        private static string PASSWORD_CHARS_NUMERIC = "23456789";
        private static string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";
        private static readonly string reservedCharacters = "!*'();:@&=+$,/?%#[]";
        private static readonly string[] SizeSuffixes;

        static VerificadoresRetornos()
        {
            string[] textArray1 = new string[9];
            textArray1[0] = "bytes";
            textArray1[1] = "KB";
            textArray1[2] = "MB";
            textArray1[3] = "GB";
            textArray1[4] = "TB";
            textArray1[5] = "PB";
            textArray1[6] = "EB";
            textArray1[7] = "ZB";
            textArray1[8] = "YB";
            SizeSuffixes = textArray1;
        }

        [AsyncStateMachine((Type)typeof((ApagarBlob))]
        public static Task ApagarBlob(string nomedoblob, string AccountName, string AccountKey, string ContainerName, bool SimuladorLocal, string EnderecoLocalArmaz)
        {
            nomedoblob = nomedoblob;
            AccountName = AccountName;
            AccountKey = AccountKey;
            ContainerName = ContainerName;
            SimuladorLocal = SimuladorLocal;
            EnderecoLocalArmaz = EnderecoLocalArmaz;
            t__builder = AsyncTaskMethodBuilder.Create();
            __state = -1;
            t__builder.Start((ApagarBlob)));
            return t__builder.get_Task();
        }

        public static DateTime ConverteStringParaDateTime(string data, string regiao)
        {
            try
            {
                return DateTime.Parse(data, new CultureInfo(regiao));
            }
            catch (Exception)
            {
                return new DateTime(DateTime.get_Now().Year, DateTime.get_Now().Month, DateTime.get_Now().Day, DateTime.get_Now().Hour, DateTime.get_Now().Minute, DateTime.get_Now().Second);
            }
        }

        public static string CriaUrlAmigavel(string TITULO)
        {
            string str3;
            string str = "";
            try
            {
                str3 = Regex.Replace(Regex.Replace(Regex.Replace(RemoveAccent(string.Format("{0}", TITULO)).ToLower(), @"[^a-z0-9\s-]", ""), @"\s+", " ").Trim(), @"\s", "-");
            }
            catch (Exception)
            {
                return str;
            }
            return str3;
        }

        public static string Decrypt(string cipherText, string keyString)
        {
            string str2;
            keyString = Startup._CHAVECRYP;
            byte[] buffer = Convert.FromBase64String(cipherText);
            byte[] rgbIV = new byte[0x10];
            byte[] buffer3 = new byte[buffer.Length - rgbIV.Length];
            Buffer.BlockCopy(buffer, 0, rgbIV, 0, rgbIV.Length);
            Buffer.BlockCopy(buffer, rgbIV.Length, buffer3, 0, buffer.Length - rgbIV.Length);
            byte[] bytes = Encoding.get_UTF8().GetBytes(keyString);
            using (Aes aes = Aes.Create())
            {
                using (ICryptoTransform transform = aes.CreateDecryptor(bytes, rgbIV))
                {
                    string str;
                    using (MemoryStream stream = new MemoryStream(buffer3))
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
            return str2;
        }

        [Extension]
        public static IEnumerable(TSource) Distinct(TSource)(IEnumerable(TSource) source, Func(TSource, object) predicate)
        {
            return Enumerable.Select(IGrouping(object, TSource), TSource)(Enumerable.GroupBy(TSource, object) (source, predicate), delegate (IGrouping(object, TSource) item) {
                return Enumerable.First(TSource) ((IEnumerable(TSource)) item);
            });
        }

[Extension]
public static IQueryable(TSource) Distinct(TSource)(IQueryable(TSource) source, Expression(Func(TSource, object)) predicate)
        {
            ParameterExpression expression = Expression.Parameter((Type)typeof(IGrouping(object, TSource)), "item");
            Expression[] expressionArray1 = new Expression[] { (Expression)expression };
ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
            return Queryable.Select(IGrouping(object, TSource), TSource)(Queryable.GroupBy(TSource, object) (source, predicate), Expression.Lambda(Func(IGrouping(object, TSource), TSource))((Expression) Expression.Call(null, (MethodInfo) methodof(Enumerable.First), expressionArray1), expressionArray2));
        }

        private static string DomainMapper(Match match)
{
    IdnMapping mapping = new IdnMapping();
    string ascii = match.Groups[2].Value;
    try
    {
        ascii = mapping.GetAscii(ascii);
    }
    catch (ArgumentException)
    {
        Emailinvalido = true;
    }
    return (match.Groups[1].Value + ascii);
}

public static string Encrypt(string text, string keyString)
{
    string str;
    keyString = Startup._CHAVECRYP;
    byte[] bytes = Encoding.get_UTF8().GetBytes(keyString);
    using (Aes aes = Aes.Create())
    {
        using (ICryptoTransform transform = aes.CreateEncryptor(bytes, aes.IV))
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream stream2 = new CryptoStream((Stream)stream, transform, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream2))
                    {
                        writer.Write(text);
                    }
                }
                byte[] iV = aes.IV;
                byte[] buffer3 = stream.ToArray();
                byte[] inArray = new byte[iV.Length + buffer3.Length];
                Buffer.BlockCopy(iV, 0, inArray, 0, iV.Length);
                Buffer.BlockCopy(buffer3, 0, inArray, iV.Length, buffer3.Length);
                str = Convert.ToBase64String(inArray);
            }
        }
    }
    return str;
}

[AsyncStateMachine((Type)typeof((EnviarEmail))]
public static Task(string) EnviarEmail(ObjetoEmailEnvio modelo)
{
    d__.modelo = modelo;
    d__.()t__builder = AsyncTaskMethodBuilder(string).Create();
    d__.()1__state = -1;
    d__.()t__builder.Start((EnviarEmail)d__38)(ref d__);
    return d__.()t__builder.get_Task();
}

[AsyncStateMachine((Type)typeof((EnviarImagemAzure))]
public static Task(string) EnviarImagemAzure(IFormFile Request, string AccountName, string AccountKey, string ContainerName, bool SimuladorLocal, string EnderecoLocalArmaz)
{
    (EnviarImagemAzure)d__34 d__;
    d__.Request = Request;
    d__.AccountName = AccountName;
    d__.AccountKey = AccountKey;
    d__.ContainerName = ContainerName;
    d__.SimuladorLocal = SimuladorLocal;
    d__.EnderecoLocalArmaz = EnderecoLocalArmaz;
    d__.()t__builder = AsyncTaskMethodBuilder(string).Create();
    d__.()1__state = -1;
    d__.()t__builder.Start((EnviarImagemAzure)d__34)(ref d__);
    return d__.()t__builder.get_Task();
}

[AsyncStateMachine((Type)typeof((EnviarImagemAzure))]
public static Task(string) EnviarImagemAzure(Image Request, int tamanhomaximobytes, string extensao, int LarguraMaxima, int AlturaMaxima, string AccountName, string AccountKey, string ContainerName)
{
    (EnviarImagemAzure)d__36 d__;
    d__.Request = Request;
    d__.extensao = extensao;
    d__.AccountName = AccountName;
    d__.AccountKey = AccountKey;
    d__.ContainerName = ContainerName;
    d__.()t__builder = AsyncTaskMethodBuilder(string).Create();
    d__.()1__state = -1;
    d__.()t__builder.Start((EnviarImagemAzure)d__36)(ref d__);
    return d__.()t__builder.get_Task();
}

[AsyncStateMachine((Type)typeof((EnviarImagemAzure))]
public static Task(string) EnviarImagemAzure(IFormFile Request, int tamanhomaximobytes, int LarguraMaxima, int AlturaMaxima, string AccountName, string AccountKey, string ContainerName, bool SimuladorLocal, string EnderecoLocalArmaz)
{
    (EnviarImagemAzure)d__35 d__;
    d__.Request = Request;
    d__.tamanhomaximobytes = tamanhomaximobytes;
    d__.AccountName = AccountName;
    d__.AccountKey = AccountKey;
    d__.ContainerName = ContainerName;
    d__.SimuladorLocal = SimuladorLocal;
    d__.EnderecoLocalArmaz = EnderecoLocalArmaz;
    d__.()t__builder = AsyncTaskMethodBuilder(string).Create();
    d__.()1__state = -1;
    d__.()t__builder.Start((EnviarImagemAzure)d__35)(ref d__);
    return d__.()t__builder.get_Task();
}

public static string GerarCodigoAleatorio(int Tamanho, bool uppercase)
{
    string str = string.Empty;
    for (int i = 0; i(Tamanho; i++)
    {
        int num3 = new Random().Next(0x30, 0x7a);
        int num2 = Convert.ToInt32(((int)num3).ToString());

        if (((num2 > 0x30) || (num2 > 0x39)) && ((num2 < 0x61) || (num2 > 0x7a)))
        {
            i--;
        }
        else
        {
            string str2 = ((char)num2).ToString();
            if (!str.Contains(str2))
            {
                str = str + str2;
            }
            else
            {
                i--;
            }
        }
    }
    return (uppercase ? str.ToUpper().Trim() : str.Trim());
}

public static string GerarSenha()
{
    return GerarSenha(DEFAULT_MIN_PASSWORD_LENGTH, DEFAULT_MAX_PASSWORD_LENGTH);
}

public static string GerarSenha(int length)
{
    return GerarSenha(length, length);
}

public static unsafe string GerarSenha(int minLength, int maxLength)
{
    if ((minLength <= 0) || ((maxLength <= 0) || (minLength > maxLength)))
    {
        return null;
    }
    char[][] chArray = new char[][] { PASSWORD_CHARS_LCASE.ToCharArray(), PASSWORD_CHARS_UCASE.ToCharArray(), PASSWORD_CHARS_NUMERIC.ToCharArray(), PASSWORD_CHARS_SPECIAL.ToCharArray() };
    int[] numArray = new int[chArray.Length];
    for (int i = 0; i < numArray.Length; i++)
    {
        numArray[i] = chArray[i].Length;
    }
    int[] numArray2 = new int[chArray.Length];
    for (int j = 0; j(numArray2.Length; j++)
    {
        numArray2[j] = j;
    }
    byte[] data = new byte[4];
    RandomNumberGenerator.Create().GetBytes(data);
    Random random = new Random(BitConverter.ToInt32(data, 0));
    char[] chArray2 = null;
    chArray2 = (minLength >= maxLength) ? ((char[])new char[minLength]) : ((char[])new char[random.Next(minLength, maxLength + 1)]);
    int maxValue = numArray2.Length - 1;
    for (int k = 0; k < chArray2.Length; k++)
    {
        int index = (maxValue != 0) ? random.Next(0, maxValue) : 0;
        int num3 = numArray2[index];
        int num5 = numArray[num3] - 1;
        int num2 = (num5 != 0) ? random.Next(0, num5 + 1) : 0;
        chArray2[k] = chArray[num3][num2];
        if (num5 == 0)
        {
            numArray[num3] = chArray[num3].Length;
        }
        else
        {
            if (num5 != num2)
            {
                chArray[num3][num5] = chArray[num3][num2];
                chArray[num3][num2] = chArray[num3][num5];
            }
            int numPtr1 = (numArray[num3]);

            numPtr1[0]--;
        }
        if (maxValue == 0)
        {
            maxValue = numArray2.Length - 1;
        }
        else
        {
            if (maxValue != index)
            {
                numArray2[maxValue] = numArray2[index];
                numArray2[index] = numArray2[maxValue];
            }
            maxValue--;
        }
    }
    return (string)new string(chArray2);
}

public static ImageFormat GetImageFormat(byte[] bytes)
{
    byte[] buffer = Encoding.get_ASCII().GetBytes("BM");
    byte[] buffer2 = Encoding.get_ASCII().GetBytes("GIF");
    byte[] buffer1 = new byte[] { 0x89, 80, 0x4e, 0x47 };
    byte[] buffer3 = buffer1;
    byte[] buffer8 = new byte[] { 0x49, 0x49, 0x2a };
    byte[] buffer4 = buffer8;
    byte[] buffer9 = new byte[] { 0x4d, 0x4d, 0x2a };
    byte[] buffer5 = buffer9;
    byte[] buffer10 = new byte[] { 0xff, 0xd8, 0xff, 0xe0 };
    byte[] buffer6 = buffer10;
    byte[] buffer11 = new byte[] { 0xff, 0xd8, 0xff, 0xe1 };
    byte[] buffer7 = buffer11;
    return !Enumerable.SequenceEqual(byte)(buffer, Enumerable.Take(byte)(bytes, buffer.Length)) ? (!Enumerable.SequenceEqual(byte)(buffer2, Enumerable.Take(byte)(bytes, buffer2.Length)) ? (!Enumerable.SequenceEqual(byte)(buffer3, Enumerable.Take(byte)(bytes, buffer3.Length)) ? (!Enumerable.SequenceEqual(byte)(buffer4, Enumerable.Take(byte)(bytes, buffer4.Length)) ? (!Enumerable.SequenceEqual(byte)(buffer5, Enumerable.Take(byte)(bytes, buffer5.Length)) ? (!Enumerable.SequenceEqual(byte)(buffer6, Enumerable.Take(byte)(bytes, buffer6.Length)) ? (!Enumerable.SequenceEqual(byte)(buffer7, Enumerable.Take(byte)(bytes, buffer7.Length)) ? ImageFormat.unknown : ImageFormat.jpeg) : ImageFormat.jpeg) : ImageFormat.tiff) : ImageFormat.tiff) : ImageFormat.png) : ImageFormat.gif) : ImageFormat.bmp;
}

public static string GetPublicIP()
{
    return new StreamReader(WebRequest.Create("http://checkip.dyndns.org").GetResponse().GetResponseStream()).ReadToEnd().Trim().Split(':', (StringSplitOptions)StringSplitOptions.None)[1].Substring(1).Split('(', (StringSplitOptions)StringSplitOptions.None)[0];
}

[AsyncStateMachine((Type)typeof((PROC__GravaLOG)))]
public static Task PROC__GravaLOG(LOGCENTRAL log, ApplicationDbContext _context)
{
    (PROC__GravaLOG)d__;
    d__.log = log;
    d__._context = _context;
    d__.()t__builder = AsyncTaskMethodBuilder.Create();
    d__.()1__state = -1;
    d__.()t__builder.Start((PROC__GravaLOG)d__45)(ref d__);
    return d__.()t__builder.get_Task();
}

public static string PROC__RetornaStatusLiteralLancamento(string tp)
{
    string str = "PENDENTE";
    string str2 = tp.ToLower().Trim();
    if (str2 != null)
    {
        if (str2 == "a")
        {
            str = "APROVADO";
        }
        else if (str2 == "c")
        {
            str = "CANCELADO";
        }
        else if (str2 == "r")
        {
            str = "REVOGADO";
        }
    }
    return str;
}

public static string PROC__RetornaStatusLiteralOferta(string tp)
{
    string str = "EM ANDAMENTO";
    string str2 = tp.ToLower().Trim();
    if (str2 != null)
    {
        if (str2 == "i")
        {
            str = "INDEFINIDA";
        }
        else if (str2 == "c")
        {
            str = "CANCELADA";
        }
        else if (str2 == "e")
        {
            str = "ENCERRADA";
        }
        else if (str2 == "s")
        {
            str = "SUSPENSA";
        }
    }
    return str;
}

private static string RemoveAccent(string text)
{
    byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(text);
    return Encoding.get_ASCII().GetString(bytes);
}

[Extension]
public static string RemoveDiacritics(string s)
{
    string str = s.Normalize(2);
    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < str.Length; i++)
    {
        char ch = str[i];
        if (CharUnicodeInfo.GetUnicodeCategory(ch) != 5)
        {
            builder.Append(ch);
        }
    }
    return builder.ToString();
}

public static string RemoveEspacos(string texto, bool linhasembranco)
{
    string str = "";
    try
    {
        str = !linhasembranco ? Regex.Replace(texto, @"\s+", string.Empty) : texto.Replace(Environment.NewLine, string.Empty);
    }
    catch (Exception)
    {
    }
    return str;
}

public static FileStreamResult ResampleImagem(IFormFile files, bool resizenaimagem)
{
    using (Image image = Image.FromStream(files.OpenReadStream()))
    {
        return new FileStreamResult((Stream)new MemoryStream(resizenaimagem ? Extends.ToByteArray(Extends.Resize(image, 0x365, 0x365)) : Extends.ToByteArray(image)), "image/jpg");
    }
}

public static int RetornaIdade(DateTime datanascimento)
{
    int num = 0;
    try
    {
        num = DateTime.get_Now().Year - datanascimento.Year;
    }
    catch (Exception)
    {
    }
    return num;
}

public static string RetornaMesExtenso(DateTime dt, bool abreviado)
{
    string str = "";
    try
    {
        switch (dt.Month)
        {
            case 1:
                str = !abreviado ? "JANEIRO" : "JAN";
                break;

            case 2:
                str = !abreviado ? "FEVEREIRO" : "FEV";
                break;

            case 3:
                str = !abreviado ? "MAR\x00c7O" : "MAR";
                break;

            case 4:
                str = !abreviado ? "ABRIL" : "ABR";
                break;

            case 5:
                str = !abreviado ? "MAIO" : "MAI";
                break;

            case 6:
                str = !abreviado ? "JUNHO" : "JUN";
                break;

            case 7:
                str = !abreviado ? "JULHO" : "JUL";
                break;

            case 8:
                str = !abreviado ? "AGOSTO" : "AGO";
                break;

            case 9:
                str = !abreviado ? "SETEMBRO" : "SET";
                break;

            case 10:
                str = !abreviado ? "OUTUBRO" : "OUT";
                break;

            case 11:
                str = !abreviado ? "NOVEMBRO" : "NOV";
                break;

            case 12:
                str = !abreviado ? "DEZEMBRO" : "DEZ";
                break;

            default:
                break;
        }
    }
    catch (Exception)
    {
    }
    return str;
}

public static DateTime RetornaStringParaData(string dateString)
{
    DateTime time;
    if (!DateTime.TryParse(dateString, time))
    {
        time = new DateTime(0x76d, 1, 1, 0, 0, 0);
    }
    return time;
}

public static string RetornaTamanhoArquivoParaHumanos(long value, int decimalPlaces)
{
    if (value < 0L)
    {
        return ("-" + RetornaTamanhoArquivoParaHumanos(-value, 1));
    }
    if (value == 0)
    {
        return "0.0 bytes";
    }
    int index = (int)Math.Log((double)value, 1024.0);
    decimal num2 = value / (1L((((index * 10) & 0x3f))));
    if (Math.Round(num2, decimalPlaces) >= 1000M)
    {
        index++;
        num2 = (decimal)(num2 / 1024M);
    }
    return string.Format("{0:n" + ((int)decimalPlaces).ToString() + "} {1}", num2, SizeSuffixes[index]);
}

[AsyncStateMachine((Type)typeof((RetornaTamanhoImagemBytes)d__29))]
public static Task(long) RetornaTamanhoImagemBytes(string url)
{
    (RetornaTamanhoImagemBytes)d__29 d__;
    d__.url = url;
    d__.()t__builder = AsyncTaskMethodBuilder(long).Create();
    d__.()1__state = -1;
    d__.()t__builder.Start((RetornaTamanhoImagemBytes)d__29)(ref d__);
    return d__.()t__builder.get_Task();
}

public static string RetornaURLAmigavel(string titulo)
{
    string str = "";
    try
    {
        str = Regex.Replace(Regex.Replace(Regex.Replace(RemoveAccent(string.Format("{0}", titulo)).ToLower(), @"[^a-z0-9\s-]", ""), @"\s+", " ").Trim(), @"\s", "-");
    }
    catch (Exception)
    {
    }
    return str;
}

public static string TemposAtras(DateTime dt, bool praBots)
{
    TimeSpan span = (TimeSpan)(DateTime.get_Now() - dt);
    if (span.Days > 0x16d)
    {
        int num = span.Days / 0x16d;
        if ((span.Days % 0x16d) != 0)
        {
            num++;
        }
        return string.Format("H\x00e1 {0} {1}", (int)num, (num == 1) ? "ano" : "anos");
    }
    if (span.Days <= 30)
    {
        return ((span.Days <= 0) ? ((span.Hours <= 0) ? ((span.Minutes <= 0) ? ((span.Seconds <= 5) ? ((span.Seconds > 5) ? string.Empty : (praBots ? string.Format("{0} ms", (int)span.Milliseconds) : "agora")) : string.Format("H\x00e1 {0} seg", (int)span.Seconds)) : string.Format("H\x00e1 {0} {1}", (int)span.Minutes, (span.Minutes == 1) ? "min" : "mins")) : string.Format("H\x00e1 {0} {1}", (int)span.Hours, (span.Hours == 1) ? "hora" : "horas")) : string.Format("H\x00e1 {0} {1}", (int)span.Days, (span.Days == 1) ? "dia" : "dias"));
    }
    int num2 = span.Days / 30;
    if ((span.Days % 0x1f) != 0)
    {
        num2++;
    }
    return string.Format("H\x00e1 {0} {1}", (int)num2, (num2 == 1) ? "m\x00eas" : "meses");
}

public static int TotalDeMesesEntreDatas(DateTime from, DateTime to)
{
    if (from > to)
    {
        return TotalDeMesesEntreDatas(to, from);
    }
    int num = Math.Abs((int)(((to.Year * 12) + (to.Month - 1)) - ((from.Year * 12) + (from.Month - 1))));
    return (((from.AddMonths(num) > to) || (to.Day < from.Day)) ? (num - 1) : num);
}

[AsyncStateMachine((Type)typeof((TradutorBing)d__11))]
public static Task(string) TradutorBing(string texto, string idioma_de, string idioma_para)
{
    (TradutorBing)d__11 d__;
    d__.texto = texto;
    d__.idioma_de = idioma_de;
    d__.idioma_para = idioma_para;
    d__.()t__builder = AsyncTaskMethodBuilder(string).Create();
    d__.()1__state = -1;
    d__.()t__builder.Start((TradutorBing)d__11)(ref d__);
    return d__.()t__builder.get_Task();
}

[AsyncStateMachine((Type)typeof((TranslateText)d__10))]
public static Task(string) TranslateText(string input, string languagePair)
{
    (TranslateText)d__10 d__;
    d__.input = input;
    d__.()t__builder = AsyncTaskMethodBuilder(string).Create();
    d__.()1__state = -1;
    d__.()t__builder.Start((TranslateText)d__10)(ref d__);
    return d__.()t__builder.get_Task();
}

public static string UrlEncode(string value)
{
    string str = "";
    try
    {
        if (!string.IsNullOrEmpty(value))
        {
            StringBuilder builder = new StringBuilder();
            string str3 = value;
            int num = 0;
            while (true)
            {
                if (num >= str3.Length)
                {
                    str = builder.ToString();
                    break;
                }
                char ch = str3[num];
                if (reservedCharacters.IndexOf(ch) == -1)
                {
                    builder.Append(ch);
                }
                else
                {
                    builder.AppendFormat("%{0:X2}", (int)ch);
                }
                num++;
            }
        }
        else
        {
            return string.Empty;
        }
    }
    catch (Exception)
    {
    }
    return str;
}

public static bool ValidaCelular(string celular)
{
    return (new Regex(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", RegexOptions.IgnoreCase).Matches(celular).Count > 0);
}

public static bool ValidaCPF(string cpf)
{
    char ch;
    int[] numArray1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    int[] numArray = numArray1;
    int[] numArray3 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    int[] numArray2 = numArray3;
    cpf = cpf.Trim();
    cpf = cpf.Replace(".", "").Replace("-", "");
    if (cpf.Length != 11)
    {
        return false;
    }
    if (cpf != null)
    {
        uint num3 = (PrivateImplementationDetails).ComputeStringHash(cpf);
        if (num3 <= 0x33851313)
        {
            if (num3 <= 0x8cca6a1)
            {
                if (num3 != 0xb97baa)
                {
                    if ((num3 == 0x8cca6a1) && (cpf == "66666666666"))
                    {
                        return false;
                    }
                }
                else if (cpf == "11111111111")
                {
                    return false;
                }
            }
            else if (num3 == 0x1eb8b808)
            {
                if (cpf == "33333333333")
                {
                    return false;
                }
            }
            else if (num3 != 0x2264e184)
            {
                if ((num3 == 0x33851313) && (cpf == "44444444444"))
                {
                    return false;
                }
            }
            else if (cpf == "77777777777")
            {
                return false;
            }
        }
        else if (num3 <= 0x8e70376f)
        {
            if (num3 != 0x6e6c5825)
            {
                if ((num3 == 0x8e70376f) && (cpf == "88888888888"))
                {
                    return false;
                }
            }
            else if (cpf == "2222222222")
            {
                return false;
            }
        }
        else if (num3 == 0xa126a6e7)
        {
            if (cpf == "00000000000")
            {
                return false;
            }
        }
        else if (num3 != 0xf695eb82)
        {
            if ((num3 == 0xf6960196) && (cpf == "55555555555"))
            {
                return false;
            }
        }
        else if (cpf == "99999999999")
        {
            return false;
        }
    }
    string str = cpf.Substring(0, 9);
    int num = 0;
    for (int i = 0; i < 9; i++)
    {
        ch = str[i];
        num += int.Parse(((char)ch).ToString()) * numArray[i];
    }
    int num2 = num % 11;
    num2 = (num2 >= 2) ? (11 - num2) : 0;
    string str2 = ((int)num2).ToString();
    str = str + str2;
    num = 0;
    for (int j = 0; j < 10; j++)
    {
        ch = str[j];
        num += int.Parse(((char)ch).ToString()) * numArray2[j];
    }
    num2 = num % 11;
    num2 = (num2 >= 2) ? (11 - num2) : 0;
    str2 = str2 + ((int)num2).ToString();
    return cpf.EndsWith(str2);
}

public static bool ValidaEmail(string strIn)
{
    Emailinvalido = false;
    if (string.IsNullOrEmpty(strIn))
    {
        return false;
    }
    try
    {
        strIn = Regex.Replace(strIn, "(@)(.+)$", new MatchEvaluator(VerificadoresRetornos.DomainMapper), RegexOptions.None, TimeSpan.FromMilliseconds(200.0));
    }
    catch (RegexMatchTimeoutException)
    {
        return false;
    }
    if (Emailinvalido)
    {
        return false;
    }
    try
    {
        return Regex.IsMatch(strIn, "^(?(\")(\".+?(?(!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?(=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250.0));
    }
    catch (RegexMatchTimeoutException)
    {
        return false;
    }
}




