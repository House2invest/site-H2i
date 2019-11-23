namespace House2Invest
{
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class WebUtils
    {
        public static Encoding GetEncodingFrom(NameValueCollection responseHeaders, Encoding defaultEncoding)
        {
            if (responseHeaders == null)
            {
                return defaultEncoding;
            }
            string str = responseHeaders["Content-Type"];
            if (str == null)
            {
                return defaultEncoding;
            }
            string[] strArray = str.Split(';', (StringSplitOptions) StringSplitOptions.None);
            if (strArray.Length <= 1)
            {
                return defaultEncoding;
            }
            string str2 = Enumerable.FirstOrDefault<string>(Enumerable.Skip<string>(strArray, 1), delegate (string p) {
                return p.TrimStart().StartsWith("charset", (StringComparison) StringComparison.InvariantCultureIgnoreCase);
            });
            if (str2 == null)
            {
                return defaultEncoding;
            }
            string[] strArray2 = str2.Split('=', (StringSplitOptions) StringSplitOptions.None);
            if (strArray2.Length != 2)
            {
                return defaultEncoding;
            }
            string str3 = strArray2[1].Trim();
            if (str3 == "")
            {
                return defaultEncoding;
            }
            try
            {
                return Encoding.GetEncoding(str3);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}

