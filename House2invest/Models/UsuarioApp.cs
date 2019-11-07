using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
namespace House2Invest.Models
{
    public class UsuarioApp : IdentityUser
    {
        string _Nome;
        [Encrypted(nameof(_Nome))]
        public string Nome
        {
            get => CriptografiaHelper.Decriptar(_Nome);
            set => _Nome = CriptografiaHelper.Encriptar(value);
        }

        string _Sobrenome;
        [Encrypted(nameof(_Sobrenome))]
        public string Sobrenome
        {
            get => CriptografiaHelper.Decriptar(_Sobrenome);
            set => _Sobrenome = CriptografiaHelper.Encriptar(value);
        }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Formato inválido em {0}")]
        public DateTime? Nascimento { get; set; }

        string _Genero;
        [Encrypted(nameof(_Genero))]
        [Display(Name = "Gênero")]
        public string Genero
        {
            get => CriptografiaHelper.Decriptar(_Genero);
            set => _Genero = CriptografiaHelper.Encriptar(value);
        }

        string _EstadoCivil;
        [Encrypted(nameof(_EstadoCivil))]
        [Display(Name = "Estado civil")]
        public string EstadoCivil
        {
            get => CriptografiaHelper.Decriptar(_EstadoCivil);
            set => _EstadoCivil = CriptografiaHelper.Encriptar(value);
        }

        string _AvatarUsuario;
        [Encrypted(nameof(_AvatarUsuario))]
        public string AvatarUsuario
        {
            get => CriptografiaHelper.Decriptar(_AvatarUsuario);
            set => _AvatarUsuario = CriptografiaHelper.Encriptar(value);
        }

        public string ImagemFundoPerfil { get; set; }

        string _Bio;
        [Encrypted(nameof(_Bio))]
        public string Bio
        {
            get => CriptografiaHelper.Decriptar(_Bio);
            set => _Bio = CriptografiaHelper.Encriptar(value);
        }

        string _Documentacao_TPPessoa;
        [Encrypted(nameof(_Documentacao_TPPessoa))]
        [Display(Name = "Tipo de pessoa")]
        public string Documentacao_TPPessoa
        {
            get => CriptografiaHelper.Decriptar(_Documentacao_TPPessoa);
            set => _Documentacao_TPPessoa = CriptografiaHelper.Encriptar(value);
        }

        string _Documentacao_CPF;
        [Encrypted(nameof(_Documentacao_CPF))]
        [Display(Name = "CPF")]
        public string Documentacao_CPF
        {
            get => CriptografiaHelper.Decriptar(_Documentacao_CPF);
            set => _Documentacao_CPF = CriptografiaHelper.Encriptar(value);
        }

        string _Documentacao_CNPJ;
        [Encrypted(nameof(_Documentacao_CNPJ))]
        [Display(Name = "CNPJ")]
        public string Documentacao_CNPJ
        {
            get => CriptografiaHelper.Decriptar(_Documentacao_CNPJ);
            set => _Documentacao_CNPJ = CriptografiaHelper.Encriptar(value);
        }

        string _Documentacao_RG;
        [Encrypted(nameof(_Documentacao_RG))]
        [Display(Name = "RG")]
        public string Documentacao_RG
        {
            get => CriptografiaHelper.Decriptar(_Documentacao_RG);
            set => _Documentacao_RG = CriptografiaHelper.Encriptar(value);
        }

        string _Trabalho_Empresa;
        [Encrypted(nameof(_Trabalho_Empresa))]
        [Display(Name = "Empresa")]
        public string Trabalho_Empresa
        {
            get => CriptografiaHelper.Decriptar(_Trabalho_Empresa);
            set => _Trabalho_Empresa = CriptografiaHelper.Encriptar(value);
        }

        string _Trabalho_Cargo;
        [Encrypted(nameof(_Trabalho_Cargo))]
        [Display(Name = "Cargo")]
        public string Trabalho_Cargo
        {
            get => CriptografiaHelper.Decriptar(_Trabalho_Cargo);
            set => _Trabalho_Cargo = CriptografiaHelper.Encriptar(value);
        }

        string _Trabalho_Profissao;
        [Encrypted(nameof(_Trabalho_Profissao))]
        [Display(Name = "Profissão")]
        public string Trabalho_Profissao
        {
            get => CriptografiaHelper.Decriptar(_Trabalho_Profissao);
            set => _Trabalho_Profissao = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_Logradouro;
        [Encrypted(nameof(_Contato_Logradouro))]
        [Display(Name = "Logradouro")]
        public string Contato_Logradouro
        {
            get => CriptografiaHelper.Decriptar(_Contato_Logradouro);
            set => _Contato_Logradouro = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_LogradouroNum;
        [Encrypted(nameof(_Contato_LogradouroNum))]
        [Display(Name = "Número")]
        public string Contato_LogradouroNum
        {
            get => CriptografiaHelper.Decriptar(_Contato_LogradouroNum);
            set => _Contato_LogradouroNum = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_Complemento;
        [Encrypted(nameof(_Contato_Complemento))]
        [Display(Name = "Complemento")]
        public string Contato_Complemento
        {
            get => CriptografiaHelper.Decriptar(_Contato_Complemento);
            set => _Contato_Complemento = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_Bairro;
        [Encrypted(nameof(_Contato_Bairro))]
        [Display(Name = "Bairro")]
        public string Contato_Bairro
        {
            get => CriptografiaHelper.Decriptar(_Contato_Bairro);
            set => _Contato_Bairro = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_Cidade;
        [Encrypted(nameof(_Contato_Cidade))]
        [Display(Name = "Cidade")]
        public string Contato_Cidade
        {
            get => CriptografiaHelper.Decriptar(_Contato_Cidade);
            set => _Contato_Cidade = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_CEP;
        [Encrypted(nameof(_Contato_CEP))]
        [Display(Name = "CEP")]
        public string Contato_CEP
        {
            get => CriptografiaHelper.Decriptar(_Contato_CEP);
            set => _Contato_CEP = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_Estado;
        [Encrypted(nameof(_Contato_Estado))]
        [Display(Name = "UF")]
        public string Contato_Estado
        {
            get => CriptografiaHelper.Decriptar(_Contato_Estado);
            set => _Contato_Estado = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_Pais;
        [Encrypted(nameof(_Contato_Pais))]
        [Display(Name = "País")]
        public string Contato_Pais
        {
            get => CriptografiaHelper.Decriptar(_Contato_Pais);
            set => _Contato_Pais = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_Escritorio;
        [Encrypted(nameof(_Contato_Escritorio))]
        [Display(Name = "Endereço escritório")]
        public string Contato_Escritorio
        {
            get => CriptografiaHelper.Decriptar(_Contato_Escritorio);
            set => _Contato_Escritorio = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_Website;
        [Encrypted(nameof(_Contato_Website))]
        [Display(Name = "Website")]
        public string Contato_Website
        {
            get => CriptografiaHelper.Decriptar(_Contato_Website);
            set => _Contato_Website = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_FoneComercial;
        [Encrypted(nameof(_Contato_FoneComercial))]
        [Display(Name = "Fone comercial")]
        public string Contato_FoneComercial
        {
            get => CriptografiaHelper.Decriptar(_Contato_FoneComercial);
            set => _Contato_FoneComercial = CriptografiaHelper.Encriptar(value);
        }

        string _Contato_FoneCelular;
        [Encrypted(nameof(_Contato_FoneCelular))]
        [Display(Name = "Celular")]
        public string Contato_FoneCelular
        {
            get => CriptografiaHelper.Decriptar(_Contato_FoneCelular);
            set => _Contato_FoneCelular = CriptografiaHelper.Encriptar(value);
        }

        string _Financeiro_Banco_Nome;
        [Encrypted(nameof(_Financeiro_Banco_Nome))]
        [Display(Name = "Banco")]
        public string Financeiro_Banco_Nome
        {
            get => CriptografiaHelper.Decriptar(_Financeiro_Banco_Nome);
            set => _Financeiro_Banco_Nome = CriptografiaHelper.Encriptar(value);
        }

        string _Financeiro_Banco_Ag;
        [Encrypted(nameof(_Financeiro_Banco_Ag))]
        [Display(Name = "Agência")]
        public string Financeiro_Banco_Ag
        {
            get => CriptografiaHelper.Decriptar(_Financeiro_Banco_Ag);
            set => _Financeiro_Banco_Ag = CriptografiaHelper.Encriptar(value);
        }

        string _Financeiro_Banco_CC;
        [Encrypted(nameof(_Financeiro_Banco_CC))]
        [Display(Name = "Conta corrente")]
        public string Financeiro_Banco_CC
        {
            get => CriptografiaHelper.Decriptar(_Financeiro_Banco_CC);
            set => _Financeiro_Banco_CC = CriptografiaHelper.Encriptar(value);
        }

        string _Financeiro_Investidor_Perfil;
        [Encrypted(nameof(_Financeiro_Investidor_Perfil))]
        [Display(Name = "Perfil de investidor")]
        public string Financeiro_Investidor_Perfil
        {
            get => CriptografiaHelper.Decriptar(_Financeiro_Investidor_Perfil);
            set => _Financeiro_Investidor_Perfil = CriptografiaHelper.Encriptar(value);
        }

        string _ContatoAutenticacao_Fone;
        [Encrypted(nameof(_ContatoAutenticacao_Fone))]
        [Display(Name = "Fone contato")]
        public string ContatoAutenticacao_Fone
        {
            get => CriptografiaHelper.Decriptar(_ContatoAutenticacao_Fone);
            set => _ContatoAutenticacao_Fone = CriptografiaHelper.Encriptar(value);
        }

        string _ContatoAutenticacao_Email;
        [Encrypted(nameof(_ContatoAutenticacao_Email))]
        public string ContatoAutenticacao_Email
        {
            get => CriptografiaHelper.Decriptar(_ContatoAutenticacao_Email);
            set => _ContatoAutenticacao_Email = CriptografiaHelper.Encriptar(value);
        }

        string _ContatoAutenticacao_FoneAlternativo;
        [Encrypted(nameof(_ContatoAutenticacao_FoneAlternativo))]
        [Display(Name = "Fone principal")]
        public string ContatoAutenticacao_FoneAlternativo
        {
            get => CriptografiaHelper.Decriptar(_ContatoAutenticacao_FoneAlternativo);
            set => _ContatoAutenticacao_FoneAlternativo = CriptografiaHelper.Encriptar(value);
        }

        string _ContatoAutenticacao_EmailAlternativo;
        [Encrypted(nameof(_ContatoAutenticacao_EmailAlternativo))]
        [Display(Name = "Email alternativo")]
        public string ContatoAutenticacao_EmailAlternativo
        {
            get => CriptografiaHelper.Decriptar(_ContatoAutenticacao_EmailAlternativo);
            set => _ContatoAutenticacao_EmailAlternativo = CriptografiaHelper.Encriptar(value);
        }

        string _MidiasSociais_Facebook;
        [Encrypted(nameof(_MidiasSociais_Facebook))]
        public string MidiasSociais_Facebook
        {
            get => CriptografiaHelper.Decriptar(_MidiasSociais_Facebook);
            set => _MidiasSociais_Facebook = CriptografiaHelper.Encriptar(value);
        }

        string _MidiasSociais_Twitter;
        [Encrypted(nameof(_MidiasSociais_Twitter))]
        public string MidiasSociais_Twitter
        {
            get => CriptografiaHelper.Decriptar(_MidiasSociais_Twitter);
            set => _MidiasSociais_Twitter = CriptografiaHelper.Encriptar(value);
        }

        string _MidiasSociais_Instagram;
        [Encrypted(nameof(_MidiasSociais_Instagram))]
        public string MidiasSociais_Instagram
        {
            get => CriptografiaHelper.Decriptar(_MidiasSociais_Instagram);
            set => _MidiasSociais_Instagram = CriptografiaHelper.Encriptar(value);
        }

        string _MidiasSociais_GooglePlus;
        [Encrypted(nameof(_MidiasSociais_GooglePlus))]
        public string MidiasSociais_GooglePlus
        {
            get => CriptografiaHelper.Decriptar(_MidiasSociais_GooglePlus);
            set => _MidiasSociais_GooglePlus = CriptografiaHelper.Encriptar(value);
        }

        string _MidiasSociais_Linkedin;
        [Encrypted(nameof(_MidiasSociais_Linkedin))]
        public string MidiasSociais_Linkedin
        {
            get => CriptografiaHelper.Decriptar(_MidiasSociais_Linkedin);
            set => _MidiasSociais_Linkedin = CriptografiaHelper.Encriptar(value);
        }

        string _MidiasSociais_Youtube;
        [Encrypted(nameof(_MidiasSociais_Youtube))]
        public string MidiasSociais_Youtube
        {
            get => CriptografiaHelper.Decriptar(_MidiasSociais_Youtube);
            set => _MidiasSociais_Youtube = CriptografiaHelper.Encriptar(value);
        }

        string _MidiasSociais_Pinterest;
        [Encrypted(nameof(_MidiasSociais_Pinterest))]
        public string MidiasSociais_Pinterest
        {
            get => CriptografiaHelper.Decriptar(_MidiasSociais_Pinterest);
            set => _MidiasSociais_Pinterest = CriptografiaHelper.Encriptar(value);
        }

        string _Sistema_FuncaoUsuario;
        [Encrypted(nameof(_Sistema_FuncaoUsuario))]
        public string Sistema_FuncaoUsuario
        {
            get => CriptografiaHelper.Decriptar(_Sistema_FuncaoUsuario);
            set => _Sistema_FuncaoUsuario = CriptografiaHelper.Encriptar(value);
        }

        string _Sistema_URLComprovanteResidencia;
        [Encrypted(nameof(_Sistema_URLComprovanteResidencia))]
        public string Sistema_URLComprovanteResidencia
        {
            get => CriptografiaHelper.Decriptar(_Sistema_URLComprovanteResidencia);
            set => _Sistema_URLComprovanteResidencia = CriptografiaHelper.Encriptar(value);
        }

        string _Sistema_URLSelfieDocFRENTE;
        [Encrypted(nameof(_Sistema_URLSelfieDocFRENTE))]
        [Display(Name = "Selfie com RG [Frente]")]
        public string Sistema_URLSelfieDocFRENTE
        {
            get => CriptografiaHelper.Decriptar(_Sistema_URLSelfieDocFRENTE);
            set => _Sistema_URLSelfieDocFRENTE = CriptografiaHelper.Encriptar(value);
        }

        string _Sistema_URLSelfieDocVERSO;
        [Encrypted(nameof(_Sistema_URLSelfieDocVERSO))]
        [Display(Name = "Selfie com RG [Verso]")]
        public string Sistema_URLSelfieDocVERSO
        {
            get => CriptografiaHelper.Decriptar(_Sistema_URLSelfieDocVERSO);
            set => _Sistema_URLSelfieDocVERSO = CriptografiaHelper.Encriptar(value);
        }

        string _Sistema_URLFotoDoc;
        [Encrypted(nameof(_Sistema_URLFotoDoc))]
        public string Sistema_URLFotoDoc
        {
            get => CriptografiaHelper.Decriptar(_Sistema_URLFotoDoc);
            set => _Sistema_URLFotoDoc = CriptografiaHelper.Encriptar(value);
        }

        public bool Sistema_AcessoBloqueado { get; set; }
        public bool Sistema_DeclaracaoCienciaTermos { get; set; }
        public bool Sistema_DeclaracaoPessoaExposta { get; set; }
        public bool Sistema_NaoAparecerListaProjetos { get; set; }
        public DateTime Sistema_DataDeclaracaoCienciaTermos { get; set; }

        public int AppConfiguracoesId { get; set; }
        public AppConfiguracoes AppConfiguracoes { get; set; }
    }
}