namespace House2Invest.Models
{
    using House2Invest;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class tblHubConversa
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string De { get; set; }
        public string DeCnxId { get; set; }
        public string Para { get; set; }
        public string ParaCnxId { get; set; }

        string _Mensagem;
        [Encrypted(nameof(_Mensagem))]
        public string Mensagem
        {
            get => CriptografiaHelper.Decriptar(_Mensagem);
            set => _Mensagem = CriptografiaHelper.Encriptar(value);
        }

        public bool Lida { get; set; }
    }
}

