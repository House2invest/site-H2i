namespace House2Invest.Models.ViewModels
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class ConstrutoraViewModel : Construtora
    {

        [Display(Name="Logotipo")]
        public IFormFile Imagem
        { get; set; }
    }
}

