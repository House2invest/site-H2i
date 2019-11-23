namespace House2Invest.Models.ViewModels
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Runtime.CompilerServices;

    public class CorpoPrincipalOferta
    {

        public BlocoProjInvestimento blocoProjInvestimento
        { get; set; }

        public UsuarioApp usuarioObjeto
        { get; set; }

        public IFormFile ArquivoComprovResid
        { get; set; }

        public IFormFile ArquivoTermoDeUso
        { get; set; }

        public IFormFile ArquivoCienciaRisco
        { get; set; }

        public IFormFile ArquivoTermoDeAdesao
        { get; set; }

        public IFormFile ArquivoContratoDeMutuo
        { get; set; }

        public string ValorInvestido
        { get; set; }

        public bool AceitouTermos
        { get; set; }

        public string PerfilInvestidorInformado
        { get; set; }
    }
}

