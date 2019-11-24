namespace House2Invest.Models
{
    using House2Invest;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class UsuarioApp : IdentityUser
    {
        private string _Nome;
        private string _Sobrenome;
        private string _Genero;
        private string _EstadoCivil;
        private string _AvatarUsuario;
        private string _Bio;
        private string _Documentacao_TPPessoa;
        private string _Documentacao_CPF;
        private string _Documentacao_CNPJ;
        private string _Documentacao_RG;
        private string _Trabalho_Empresa;
        private string _Trabalho_Cargo;
        private string _Trabalho_Profissao;
        private string _Contato_Logradouro;
        private string _Contato_LogradouroNum;
        private string _Contato_Complemento;
        private string _Contato_Bairro;
        private string _Contato_Cidade;
        private string _Contato_CEP;
        private string _Contato_Estado;
        private string _Contato_Pais;
        private string _Contato_Escritorio;
        private string _Contato_Website;
        private string _Contato_FoneComercial;
        private string _Contato_FoneCelular;
        private string _Financeiro_Banco_Nome;
        private string _Financeiro_Banco_Ag;
        private string _Financeiro_Banco_CC;
        private string _Financeiro_Investidor_Perfil;
        private string _ContatoAutenticacao_Fone;
        private string _ContatoAutenticacao_Email;
        private string _ContatoAutenticacao_FoneAlternativo;
        private string _ContatoAutenticacao_EmailAlternativo;
        private string _MidiasSociais_Facebook;
        private string _MidiasSociais_Twitter;
        private string _MidiasSociais_Instagram;
        private string _MidiasSociais_GooglePlus;
        private string _MidiasSociais_Linkedin;
        private string _MidiasSociais_Youtube;
        private string _MidiasSociais_Pinterest;
        private string _Sistema_FuncaoUsuario;
        private string _Sistema_URLComprovanteResidencia;
        private string _Sistema_URLSelfieDocFRENTE;
        private string _Sistema_URLSelfieDocVERSO;
        private string _Sistema_URLFotoDoc;

        [Encrypted("_Nome")]
        public string Nome
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Nome, "", "");
            }
            set
            {
                this._Nome = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Sobrenome")]
        public string Sobrenome
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Sobrenome, "", "");
            }
            set
            {
                this._Sobrenome = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Display(Name="Data de nascimento"), DataType(DataType.Date, ErrorMessage="Formato inv\x00e1lido em {0}")]
        public DateTime? Nascimento
        {
            get
            {
                return this.Nascimento;
            }
            set
            {
                this.Nascimento = value;
            }
        }

        [Encrypted("_Genero"), Display(Name="G\x00eanero")]
        public string Genero
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Genero, "", "");
            }
            set
            {
                this._Genero = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_EstadoCivil"), Display(Name="Estado civil")]
        public string EstadoCivil
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._EstadoCivil, "", "");
            }
            set
            {
                this._EstadoCivil = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_AvatarUsuario")]
        public string AvatarUsuario
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._AvatarUsuario, "", "");
            }
            set
            {
                this._AvatarUsuario = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        public string ImagemFundoPerfil
        {
            get
            {
                return this.ImagemFundoPerfil;
            }
            set
            {
                this.ImagemFundoPerfil = value;
            }
        }

        [Encrypted("_Bio")]
        public string Bio
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Bio, "", "");
            }
            set
            {
                this._Bio = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Documentacao_TPPessoa"), Display(Name="Tipo de pessoa")]
        public string Documentacao_TPPessoa
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Documentacao_TPPessoa, "", "");
            }
            set
            {
                this._Documentacao_TPPessoa = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Documentacao_CPF"), Display(Name="CPF")]
        public string Documentacao_CPF
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Documentacao_CPF, "", "");
            }
            set
            {
                this._Documentacao_CPF = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Documentacao_CNPJ"), Display(Name="CNPJ")]
        public string Documentacao_CNPJ
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Documentacao_CNPJ, "", "");
            }
            set
            {
                this._Documentacao_CNPJ = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Documentacao_RG"), Display(Name="RG")]
        public string Documentacao_RG
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Documentacao_RG, "", "");
            }
            set
            {
                this._Documentacao_RG = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Trabalho_Empresa"), Display(Name="Empresa")]
        public string Trabalho_Empresa
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Trabalho_Empresa, "", "");
            }
            set
            {
                this._Trabalho_Empresa = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Trabalho_Cargo"), Display(Name="Cargo")]
        public string Trabalho_Cargo
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Trabalho_Cargo, "", "");
            }
            set
            {
                this._Trabalho_Cargo = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Trabalho_Profissao"), Display(Name="Profiss\x00e3o")]
        public string Trabalho_Profissao
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Trabalho_Profissao, "", "");
            }
            set
            {
                this._Trabalho_Profissao = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_Logradouro"), Display(Name="Logradouro")]
        public string Contato_Logradouro
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_Logradouro, "", "");
            }
            set
            {
                this._Contato_Logradouro = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_LogradouroNum"), Display(Name="N\x00famero")]
        public string Contato_LogradouroNum
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_LogradouroNum, "", "");
            }
            set
            {
                this._Contato_LogradouroNum = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_Complemento"), Display(Name="Complemento")]
        public string Contato_Complemento
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_Complemento, "", "");
            }
            set
            {
                this._Contato_Complemento = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_Bairro"), Display(Name="Bairro")]
        public string Contato_Bairro
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_Bairro, "", "");
            }
            set
            {
                this._Contato_Bairro = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_Cidade"), Display(Name="Cidade")]
        public string Contato_Cidade
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_Cidade, "", "");
            }
            set
            {
                this._Contato_Cidade = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_CEP"), Display(Name="CEP")]
        public string Contato_CEP
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_CEP, "", "");
            }
            set
            {
                this._Contato_CEP = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_Estado"), Display(Name="UF")]
        public string Contato_Estado
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_Estado, "", "");
            }
            set
            {
                this._Contato_Estado = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_Pais"), Display(Name="Pa\x00eds")]
        public string Contato_Pais
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_Pais, "", "");
            }
            set
            {
                this._Contato_Pais = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_Escritorio"), Display(Name="Endere\x00e7o escrit\x00f3rio")]
        public string Contato_Escritorio
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_Escritorio, "", "");
            }
            set
            {
                this._Contato_Escritorio = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_Website"), Display(Name="Website")]
        public string Contato_Website
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_Website, "", "");
            }
            set
            {
                this._Contato_Website = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_FoneComercial"), Display(Name="Fone comercial")]
        public string Contato_FoneComercial
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_FoneComercial, "", "");
            }
            set
            {
                this._Contato_FoneComercial = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Contato_FoneCelular"), Display(Name="Celular")]
        public string Contato_FoneCelular
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Contato_FoneCelular, "", "");
            }
            set
            {
                this._Contato_FoneCelular = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Financeiro_Banco_Nome"), Display(Name="Banco")]
        public string Financeiro_Banco_Nome
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Financeiro_Banco_Nome, "", "");
            }
            set
            {
                this._Financeiro_Banco_Nome = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Financeiro_Banco_Ag"), Display(Name="Ag\x00eancia")]
        public string Financeiro_Banco_Ag
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Financeiro_Banco_Ag, "", "");
            }
            set
            {
                this._Financeiro_Banco_Ag = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Financeiro_Banco_CC"), Display(Name="Conta corrente")]
        public string Financeiro_Banco_CC
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Financeiro_Banco_CC, "", "");
            }
            set
            {
                this._Financeiro_Banco_CC = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Financeiro_Investidor_Perfil"), Display(Name="Perfil de investidor")]
        public string Financeiro_Investidor_Perfil
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Financeiro_Investidor_Perfil, "", "");
            }
            set
            {
                this._Financeiro_Investidor_Perfil = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_ContatoAutenticacao_Fone"), Display(Name="Fone contato")]
        public string ContatoAutenticacao_Fone
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._ContatoAutenticacao_Fone, "", "");
            }
            set
            {
                this._ContatoAutenticacao_Fone = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_ContatoAutenticacao_Email")]
        public string ContatoAutenticacao_Email
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._ContatoAutenticacao_Email, "", "");
            }
            set
            {
                this._ContatoAutenticacao_Email = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_ContatoAutenticacao_FoneAlternativo"), Display(Name="Fone principal")]
        public string ContatoAutenticacao_FoneAlternativo
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._ContatoAutenticacao_FoneAlternativo, "", "");
            }
            set
            {
                this._ContatoAutenticacao_FoneAlternativo = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_ContatoAutenticacao_EmailAlternativo"), Display(Name="Email alternativo")]
        public string ContatoAutenticacao_EmailAlternativo
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._ContatoAutenticacao_EmailAlternativo, "", "");
            }
            set
            {
                this._ContatoAutenticacao_EmailAlternativo = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_MidiasSociais_Facebook")]
        public string MidiasSociais_Facebook
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._MidiasSociais_Facebook, "", "");
            }
            set
            {
                this._MidiasSociais_Facebook = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_MidiasSociais_Twitter")]
        public string MidiasSociais_Twitter
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._MidiasSociais_Twitter, "", "");
            }
            set
            {
                this._MidiasSociais_Twitter = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_MidiasSociais_Instagram")]
        public string MidiasSociais_Instagram
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._MidiasSociais_Instagram, "", "");
            }
            set
            {
                this._MidiasSociais_Instagram = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_MidiasSociais_GooglePlus")]
        public string MidiasSociais_GooglePlus
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._MidiasSociais_GooglePlus, "", "");
            }
            set
            {
                this._MidiasSociais_GooglePlus = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_MidiasSociais_Linkedin")]
        public string MidiasSociais_Linkedin
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._MidiasSociais_Linkedin, "", "");
            }
            set
            {
                this._MidiasSociais_Linkedin = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_MidiasSociais_Youtube")]
        public string MidiasSociais_Youtube
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._MidiasSociais_Youtube, "", "");
            }
            set
            {
                this._MidiasSociais_Youtube = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_MidiasSociais_Pinterest")]
        public string MidiasSociais_Pinterest
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._MidiasSociais_Pinterest, "", "");
            }
            set
            {
                this._MidiasSociais_Pinterest = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Sistema_FuncaoUsuario")]
        public string Sistema_FuncaoUsuario
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Sistema_FuncaoUsuario, "", "");
            }
            set
            {
                this._Sistema_FuncaoUsuario = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Sistema_URLComprovanteResidencia")]
        public string Sistema_URLComprovanteResidencia
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Sistema_URLComprovanteResidencia, "", "");
            }
            set
            {
                this._Sistema_URLComprovanteResidencia = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Sistema_URLSelfieDocFRENTE"), Display(Name="Selfie com RG [Frente]")]
        public string Sistema_URLSelfieDocFRENTE
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Sistema_URLSelfieDocFRENTE, "", "");
            }
            set
            {
                this._Sistema_URLSelfieDocFRENTE = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Sistema_URLSelfieDocVERSO"), Display(Name="Selfie com RG [Verso]")]
        public string Sistema_URLSelfieDocVERSO
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Sistema_URLSelfieDocVERSO, "", "");
            }
            set
            {
                this._Sistema_URLSelfieDocVERSO = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        [Encrypted("_Sistema_URLFotoDoc")]
        public string Sistema_URLFotoDoc
        {
            get
            {
                return CriptografiaHelper.Decriptar(this._Sistema_URLFotoDoc, "", "");
            }
            set
            {
                this._Sistema_URLFotoDoc = CriptografiaHelper.Encriptar(value, "", "");
            }
        }

        public bool Sistema_AcessoBloqueado
        {
            get
            {
                return this.Sistema_AcessoBloqueado;
            }
            set
            {
                this.Sistema_AcessoBloqueado = value;
            }
        }

        public bool Sistema_DeclaracaoCienciaTermos
        {
            get
            {
                return this.Sistema_DeclaracaoCienciaTermos;
            }
            set
            {
                this.Sistema_DeclaracaoCienciaTermos = value;
            }
        }

        public bool Sistema_DeclaracaoPessoaExposta
        {
            get
            {
                return this.Sistema_DeclaracaoPessoaExposta;
            }
            set
            {
                this.Sistema_DeclaracaoPessoaExposta = value;
            }
        }

        public bool Sistema_NaoAparecerListaProjetos
        {
            get
            {
                return this.Sistema_NaoAparecerListaProjetos;
            }
            set
            {
                this.Sistema_NaoAparecerListaProjetos = value;
            }
        }

        public DateTime Sistema_DataDeclaracaoCienciaTermos
        {
            get
            {
                return this.Sistema_DataDeclaracaoCienciaTermos;
            }
            set
            {
                this.Sistema_DataDeclaracaoCienciaTermos = value;
            }
        }

        public int AppConfiguracoesId
        {
            get
            {
                return this.AppConfiguracoesId;
            }
            set
            {
                this.AppConfiguracoesId = value;
            }
        }

        public House2Invest.Models.AppConfiguracoes AppConfiguracoes
        {
            get
            {
                return this.AppConfiguracoes;
            }
            set
            {
                this.AppConfiguracoes = value;
            }
        }
    }
}

