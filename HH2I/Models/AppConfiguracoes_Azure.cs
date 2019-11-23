namespace House2Invest.Models
{
    using House2Invest;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class AppConfiguracoes_Azure
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        [Display(Name = "Usar simulador de armazenamento local?")]
        public bool UsarSimuladorLocal { get; set; }

        string __azureblob_AccountName;
        [Encrypted(nameof(__azureblob_AccountName))]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Nome da conta")]
        public string _azureblob_AccountName
        {
            get => CriptografiaHelper.Decriptar(__azureblob_AccountName);
            set => __azureblob_AccountName = CriptografiaHelper.Encriptar(value);
        }

        string __azureblob_AccountKey;
        [Encrypted(nameof(__azureblob_AccountKey))]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Chave da conta")]
        public string _azureblob_AccountKey
        {
            get => CriptografiaHelper.Decriptar(__azureblob_AccountKey);
            set => __azureblob_AccountKey = CriptografiaHelper.Encriptar(value);
        }

        string __azureblob_ContainerRaiz;
        [Encrypted(nameof(__azureblob_ContainerRaiz))]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Nome do container")]
        public string _azureblob_ContainerRaiz
        {
            get => CriptografiaHelper.Decriptar(__azureblob_ContainerRaiz);
            set => __azureblob_ContainerRaiz = CriptografiaHelper.Encriptar(value);
        }

        string _EnderecoArmazLocal;
        [Encrypted(nameof(_EnderecoArmazLocal))]
        [Display(Name = "Endereço armazenamento local Blob")]
        public string EnderecoArmazLocal
        {
            get => CriptografiaHelper.Decriptar(_EnderecoArmazLocal);
            set => _EnderecoArmazLocal = CriptografiaHelper.Encriptar(value);
        }
    }
}

