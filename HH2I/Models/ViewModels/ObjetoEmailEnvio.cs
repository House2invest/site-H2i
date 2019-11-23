namespace House2Invest.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class ObjetoEmailEnvio
    {

        [Display(Name = "mail.From")]
        public string mailFrom { get; set; }
        //[Display(Name = "mail.To.Add")]
        //public string mailToAdd { get; set; }
        [Display(Name = "smtp.UseDefaultCredentials")]
        public bool smtpUseDefaultCredentials { get; set; }
        [Display(Name = "smtp.EnableSsl")]
        public bool smtpEnableSsl { get; set; }
        [Display(Name = "smtp.Host")]
        public string smtpHost { get; set; }
        [Display(Name = "smtp.Port")]
        public int smtpPort { get; set; }
        [Display(Name = "smtp.Credentials.Email")]
        public string smtpCredentialsEmail { get; set; }
        [Display(Name = "smtp.Credentials.Senha")]
        public string smtpCredentialsSenha { get; set; }

        [Display(Name = "PARA")]
        public string PARA { get; set; }
        [Display(Name = "CÓPIA")]
        public string COPIA { get; set; }
        [Display(Name = "ASSUNTO")]
        public string ASSUNTO { get; set; }
        [Display(Name = "MENSAGEM")]
        public string MENSAGEM { get; set; }
    }
}

