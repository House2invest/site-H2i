namespace House2Invest
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public class ChamaREST
    {
        private readonly string BASEURL = "https://api.hgbrasil.com/";
        private static Lazy<ChamaREST> _Lazy = new Lazy<ChamaREST>(delegate
        {
            return new ChamaREST();
        });
        private readonly HttpClient _HttpClient = new HttpClient();

    }
}

