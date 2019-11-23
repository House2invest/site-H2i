namespace House2Invest.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class Indice_CotacaoMoedas_BASE
    {
        public string name { get; set; }
        public float buy { get; set; }
        public float? sell { get; set; }
        public float variation { get; set; }
    }
}

