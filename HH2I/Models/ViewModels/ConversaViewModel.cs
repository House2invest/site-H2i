namespace House2Invest.Models.ViewModels
{
    using House2Invest.Models;
    using System;
    using System.Runtime.CompilerServices;

    public class ConversaViewModel : UsuarioApp
    {

        public int conv_id
        { get; set; }

        public string conv_cnxid
        { get; set; }

        public DateTime conv_dthr
        { get; set; }
    }
}

