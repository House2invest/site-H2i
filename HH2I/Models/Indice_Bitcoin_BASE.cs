namespace House2Invest.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class Indice_Bitcoin_BASE
    {
        public string name { get; set; }
        public string[] format { get; set; }
        public float? last { get; set; }
        public float? buy { get; set; }
        public float? sell { get; set; }
        public float? variation { get; set; }
    }
}

