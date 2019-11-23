namespace House2Invest.Models.ViewModels
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class AppConfig_AppViewModel : AppConfiguracoes_Aplicativo
    {

        [Display(Name="Imagem Logotipo")]
        public IFormFile App_ImagemLogo
        { get; set; }
    }
}

