namespace House2Invest.Models.ViewModels
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class UsuarioAppViewModel : UsuarioApp
    {
        [Display(Name = "Documento digitalizado")]
        public IFormFile ImagemDocDigitalizado { get; set; }

        [Display(Name = "Sua selfie")]
        public IFormFile ImagemSelfie { get; set; }

        [Display(Name = "Comprovante de residência")]
        public IFormFile ImagemComprovanteResidencia { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido")]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua Senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não correspondem.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido")]
        [Display(Name = "Li e Aceito os Termos de Uso")]
        public bool Termos { get; set; }

        [Display(Name = "Não desejo aparecer na lista de participantes do projeto.")]
        public bool NaoAparecerListaProjetos { get; set; }

        [Display(Name = "Sou uma pessoa politicamente exposta.")]
        public bool PessoaPoliticamenteExposta { get; set; }

    }
}

