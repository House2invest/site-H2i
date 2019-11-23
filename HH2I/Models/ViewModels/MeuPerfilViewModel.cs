namespace House2Invest.Models.ViewModels
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class MeuPerfilViewModel : UsuarioApp
    {

        [Display(Name="Documento digitalizado")]
        public IFormFile ImagemDocDigitalizado
        { get; set; }

        [Display(Name="Sua selfie - Frente")]
        public IFormFile ImagemSelfieFRENTE
        { get; set; }

        [Display(Name="Sua selfie - Verso")]
        public IFormFile ImagemSelfieVERSO
        { get; set; }

        [Display(Name="N\x00e3o desejo aparecer na lista de participantes do projeto.")]
        public bool NaoAparecerListaProjetos
        { get; set; }

        [Display(Name="Sou uma pessoa politicamente exposta.")]
        public bool PessoaPoliticamenteExposta
        { get; set; }
    }
}

