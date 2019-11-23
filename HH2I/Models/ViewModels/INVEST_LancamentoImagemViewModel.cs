namespace House2Invest.Models.ViewModels
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class INVEST_LancamentoImagemViewModel : INVEST_LancamentoImagem
    {

        [Display(Name="Comprovante de transfer\x00eancia")]
        public IFormFile ArquivoComprovTransf
        { get; set; }
    }
}

