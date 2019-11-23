namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class HgFinance
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string by { get; set; }
        public bool valid_key { get; set; }
        public int ResultsFinanceId { get; set; }
        public ResultsFinance results { get; set; }
        public float execution_time { get; set; }
        public bool from_cache { get; set; }
    }
}

