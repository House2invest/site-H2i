namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class ResultsGeoIp
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string address { get; set; }
        public string type { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country_name { get; set; }
        public string continent { get; set; }
        public string continent_code { get; set; }
        public string region_code { get; set; }
        public int HgGeoIp_PaisId { get; set; }
        public HgGeoIp_Pais country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string woeid { get; set; }
    }
}

