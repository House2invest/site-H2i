namespace House2Invest.Models.ViewModels
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class TransferenciaViewModel
    {
        [Display(Name = "Comprovante de transferência")]
        public IFormFile ArquivoComprovTransf { get; set; }
        public double Montante { get; set; }
        public string IDUSU { get; set; }
        public int Id { get; set; }
    }
}

