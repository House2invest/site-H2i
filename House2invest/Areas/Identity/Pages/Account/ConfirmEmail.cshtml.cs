using House2Invest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace House2Invest.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly Data.ApplicationDbContext _context;
        public ConfirmEmailModel(IHttpContextAccessor accessor, Data.ApplicationDbContext context, UserManager<UsuarioApp> userManager)
        {
            _accessor = accessor;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            if (userId == null || code == null)
            {
                return Redirect("/");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                {
                    ICOMENS = "<i class='fas fa-times text-danger'></i>",
                    MENSAGEM = $"<img src='/images/sem-imagem.png' style='border-radius:100%;max-width:100%;height:24px;margin-right:5px;'/> <b>{userId}</b> usando o código <b>{code}</b> <b style='color:red;'>FALHOU</b> ao <b style='color:red;'>CONFIRMAR O EMAIL</b> na plataforma.",
                    ACAO = $"CONFIRMAÇÃO DO EMAIL",
                    DTHR = DateTime.Now,
                    IP = _ips.FirstOrDefault(),
                    STATUS = "FALHA",
                    TIPO = "ACESSO A PLATAFORMA",
                    UsuarioAppId = userId,
                    VALOR = 0,
                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                }, _context);

                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                {
                    ICOMENS = "<i class='fas fa-times text-danger'></i>",
                    MENSAGEM = $"<img src='{user.AvatarUsuario}' style='border-radius:100%;max-width:100%;height:24px;margin-right:5px;'/> <b>{user.Nome} {user.Sobrenome}</b> usando o email <b>{user.Email}</b> <b style='color:red;'>FALHOU</b> ao <b style='color:red;'>CONFIRMAR O EMAIL</b> na plataforma.",
                    ACAO = $"CONFIRMAÇÃO DO EMAIL",
                    DTHR = DateTime.Now,
                    IP = _ips.FirstOrDefault(),
                    STATUS = "FALHA",
                    TIPO = "ACESSO A PLATAFORMA",
                    UsuarioAppId = userId,
                    VALOR = 0,
                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                }, _context);

                return NotFound();
                //throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
            }

            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            {
                ICOMENS = "<i class='fas fa-check-circle text-success'></i>",
                MENSAGEM = $"<img src='{user.AvatarUsuario}' style='border-radius:100%;max-width:100%;height:24px;margin-right:5px;'/> <b>{user.Nome} {user.Sobrenome}</b> usando o email <b>{user.Email}</b> <b style='color:green;'>OBTEVE ÊXITO</b> em <b style='color:green;'>CONFIRMAR O EMAIL</b> na plataforma.",
                ACAO = $"REGISTRO",
                DTHR = DateTime.Now,
                IP = _ips.FirstOrDefault(),
                STATUS = "SUCESSO",
                TIPO = "ACESSO A PLATAFORMA",
                UsuarioAppId = user.Id,
                VALOR = 0,
                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            }, _context);

            //// LOGCENTRAL
            //_context.LOGCENTRALs.Add(new LOGCENTRAL()
            //{
            //    ACAO = "ENVIO EMAIL - EMAIL CONFIRMADO",
            //    INVEST_LancamentoId = 0,
            //    INVEST_ModeloDocId = 0,
            //    TP = "",
            //    URLDOC = "",
            //    VALOR = 0,
            //    STATUS = "",
            //    UsuarioAppId = user.Id,
            //    IP = _ips.FirstOrDefault()
            //});
            //await _context.SaveChangesAsync();

            return Page();
        }
    }
}
