namespace House2Invest.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class Indice_Taxas
    {
        public string date { get; set; }
        public float? cdi { get; set; }
        public float? selic { get; set; }
        public float? daily_factor { get; set; }
    }
}

