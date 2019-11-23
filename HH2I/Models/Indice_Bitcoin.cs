namespace House2Invest.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class Indice_Bitcoin
    {
        public Indice_Bitcoin_blockchain_info blockchain_info { get; set; }
        public Indice_Bitcoin_coinbase coinbase { get; set; }
        public Indice_Bitcoin_bitstamp bitstamp { get; set; }
        public Indice_Bitcoin_foxbit foxbit { get; set; }
        public Indice_Bitcoin_mercadobitcoin mercadobitcoin { get; set; }
        public Indice_Bitcoin_omnitrade omnitrade { get; set; }
        public Indice_Bitcoin_xdex xdex { get; set; }
    }
}

