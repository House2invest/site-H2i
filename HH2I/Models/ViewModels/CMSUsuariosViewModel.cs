namespace House2Invest.Models.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CMSUsuariosViewModel
    {

        public string Id
        { get; set; }

        public DateTime Criado
        { get; set; }

        public string Nome
        { get; set; }

        public string Email
        { get; set; }

        public bool EmailConfirmado
        { get; set; }

        public bool AcessoBloqueado
        { get; set; }

        public bool Lockout
        { get; set; }

        public string Sistema_URLSelfieDocFRENTE
        { get; set; }

        public string Sistema_URLSelfieDocVERSO
        { get; set; }

        public string Financeiro_Investidor_Perfil
        { get; set; }
    }
}

