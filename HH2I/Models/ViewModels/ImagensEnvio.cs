namespace House2Invest.Models.ViewModels
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Runtime.CompilerServices;

    public class ImagensEnvio : GaleriaPerfilImagem
    {

        public IFormFile Arquivo
        { get; set; }
    }
}

