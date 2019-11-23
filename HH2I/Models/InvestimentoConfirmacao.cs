namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class InvestimentoConfirmacao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public int BlocoProjInvestimentoId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApps { get; set; }
        public double Valor { get; set; }
        public string Token { get; set; }
        public bool Confirmado { get; set; }
        public int INVEST_LancamentoId { get; set; }
        public INVEST_Lancamento INVEST_Lancamento { get; set; }
    }
}

