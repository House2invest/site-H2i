namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class HgGeoIp_Pais
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string name { get; set; }
        public string code { get; set; }
        public string capital { get; set; }
        public int HgGeoIp_Pais_FlagId { get; set; }
        public HgGeoIp_Pais_Flag flag { get; set; }
        public string calling_code { get; set; }
    }
}

