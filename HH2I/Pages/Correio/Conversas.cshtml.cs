using House2Invest.Data;
using House2Invest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages
{
    [Authorize]
    public class ConversasModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ConversasModel(ApplicationDbContext context) { _context = context; }

        public string DE_UID { get; set; }
        public string DE_EMAIL { get; set; }
        public string DE_CNXID { get; set; }
        public string DE_AVATAR { get; set; }
        public string DE_NOME { get; set; }
        public string DE_SOBRENOME { get; set; }
        public string PARA_UID { get; set; }
        public string PARA_EMAIL { get; set; }
        public string PARA_CNXID { get; set; }
        public int IDINVEST { get; set; }

        public async Task<IActionResult> OnGetAsync(string uid = "", int idinv = 0)
        {
            var _usu_DE = new UsuarioApp();
            var _usu_PARA = new UsuarioApp();

            // INICIANDO PROPRIEDADES
            DE_UID = "00000000-00000000-00000000-00000000";
            DE_EMAIL = "[desconhecido]";
            DE_CNXID = "[offline]";
            DE_AVATAR = "/images/usuario-padrao-avatar.png";
            DE_NOME = "desconhecido";
            DE_SOBRENOME = "";
            PARA_UID = "00000000-00000000-00000000-00000000";
            PARA_EMAIL = "[desconhecido]";
            PARA_CNXID = "[offline]";

            // PEGA INFO USU DE
            _usu_DE = await _context.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
            if (_usu_DE == null)
                return Redirect("/IndexCMS");

            if (!string.IsNullOrEmpty(uid))
            {
                // PEGA INFO USU PARA
                _usu_PARA = await _context.Users.FirstOrDefaultAsync(x => x.Id == uid);
                if (_usu_PARA == null)
                    return Redirect("/IndexCMS");
            }

            IDINVEST = idinv;

            //----------------------------------
            // DE
            //----------------------------------
            DE_UID = _usu_DE.Id;
            DE_EMAIL = _usu_DE.Email;
            DE_AVATAR = _usu_DE.AvatarUsuario;
            DE_NOME = _usu_DE.Nome;
            DE_SOBRENOME = _usu_DE.Sobrenome;

            //// PEGANDO CNX_DE
            //var _salavipDE =
            //    _context.tblHubClientes
            //    .Where(x => x.Email == User.Identity.Name)
            //    .OrderByDescending(x => x.DTHR)
            //    .FirstOrDefault();

            //DE_CNXID = _salavipDE.CnxId;

            //----------------------------------
            // PARA
            //----------------------------------
            if (_usu_PARA.Email != null)
            {
                PARA_UID = _usu_PARA.Id;
                PARA_EMAIL = _usu_PARA.Email;
                //// PEGANDO CNX_PARA
                //var _salavipPARA = 
                //    _context
                //    .tblHubClientes
                //    .Where(x => x.UsuarioAppId == _usu_PARA.Id)
                //    .OrderByDescending(x => x.DTHR)
                //    .FirstOrDefault();

                //PARA_CNXID = _salavipPARA.CnxId;
            }

            return Page();
        }
    }
}