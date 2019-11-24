using House2Invest.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModelPage : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly Data.ApplicationDbContext _context;
        public LoginModelPage(IHttpContextAccessor accessor, SignInManager<UsuarioApp> signInManager, ILogger<LoginModel> logger, Data.ApplicationDbContext context)
        {
            _accessor = accessor;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public class InputModel
        {
            [Required(ErrorMessage = "O campo {0} é requerido")]
            [EmailAddress(ErrorMessage = "O valor digitado não corresponde a um email válido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é requerido")]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [Display(Name = "Lembrar de mim")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            returnUrl = returnUrl ?? Url.Content("~/");
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var resultadoLogin = await _signInManager
                    .PasswordSignInAsync(Input.Email, Input.Password, false, true);

                // FLAG ERROS DE LOGIN EM VALIDACOES
                var _permitoLogin = true;

                if (resultadoLogin.Succeeded)
                {
                    try
                    {
                        var _usu =
                        _context.Users
                        .Where(x => x.UserName.ToLower().Trim() == Input.Email.ToLower().Trim())
                        .FirstOrDefault();

                        if (_usu != null)
                        {
                            //*****************************************************
                            // EMAIL CONFIRMADO?
                            //*****************************************************
                            if (!_usu.EmailConfirmed)
                            {
                                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                                {
                                    ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                                    MENSAGEM = $"O usuário com o email <b>{_usu.Email}</b> teve o <b>ACESSO NEGADO</b> a plataforma.<br> Motivo: <b style='color:red;'>EMAIL NÃO CONFIRMADO</b>. <br><i style='color:red;'>Clique <a href='/CMSUsuarios/Edit?id={_usu.Id}'>AQUI</a> para acessar a conta deste usuário.</i>",
                                    ACAO = $"BLOQUEIO",
                                    DTHR = DateTime.Now,
                                    IP = _ips.FirstOrDefault(),
                                    STATUS = "EMAIL NÃO CONFIRMADO",
                                    TIPO = "ACESSO A PLATAFORMA",
                                    UsuarioAppId = _usu.Id,
                                    VALOR = 0,
                                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                                }, _context);

                                ModelState.AddModelError(string.Empty, "Email ainda não foi confirmado.");
                                _permitoLogin = false;
                            }

                            //*****************************************************
                            // ACESSO BLOQUEADO?
                            //*****************************************************
                            if (_usu.Sistema_AcessoBloqueado)
                            {
                                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                                {
                                    ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                                    MENSAGEM = $"O usuário <b>{_usu.Email}</b> teve o <b>ACESSO NEGADO</b> a plataforma.<br> Motivo: <b style='color:red;'>ACESSO BLOQUEADO</b>. <br><i style='color:red;'>Clique <a href='/CMSUsuarios/Edit?id={_usu.Id}'>AQUI</a> para acessar a conta deste usuário.</i>",
                                    ACAO = $"BLOQUEIO",
                                    DTHR = DateTime.Now,
                                    IP = _ips.FirstOrDefault(),
                                    STATUS = "AVALIAÇÃO DE FICHA PENDENTE",
                                    TIPO = "ACESSO A PLATAFORMA",
                                    UsuarioAppId = _usu.Id,
                                    VALOR = 0,
                                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                                }, _context);

                                ModelState.AddModelError(string.Empty, "Estamos analisando as informações da sua conta. Logo menos, entramos em contato. Obrigado pela paciência.");
                                _permitoLogin = false;
                            }
                        }
                        //**********************************************************
                        // ERRO DESCONHECIDO. NÃO CONSEGUI INSTANCIAR O OBJETO _usu
                        //**********************************************************
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Não podemos verificar o seu login neste momento. Por favor, tente novamente mais tarde. Sentimos pelo ocorrido.");
                        }

                        if (!_permitoLogin)
                        {
                            await _signInManager.SignOutAsync();
                        }
                        else
                        {
                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-sign-in-alt text-success'></i>",
                                MENSAGEM = $"<img src='{_usu.AvatarUsuario}' style='border-radius:100%;max-width:100%;height:24px;margin-right:5px;'/> <b>{_usu.Nome} {_usu.Sobrenome}</b> usando o email <b>{_usu.Email}</b> fez <b style='color:darkgreen;'>LOGIN</b> na plataforma.",
                                ACAO = $"LOGIN",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = "SUCESSO",
                                TIPO = "ACESSO A PLATAFORMA",
                                UsuarioAppId = _usu.Id,
                                VALOR = 0,
                                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                            }, _context);

                            return LocalRedirect(returnUrl);
                        }
                    }
                    catch (Exception _err)
                    {
                        var erro = _err;
                    }
                }
                //*****************************************************
                // DADOS INVÁLIDOS DE LOGIN. EMAIL E/OU SENHA INVÁLIDOS
                //*****************************************************
                else
                {
                    var _usu = new UsuarioApp();
                    try { _usu = _context.Users.Where(x => x.UserName == Input.Email).FirstOrDefault(); } catch (Exception) { }
                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-user-shield text-danger'></i>",
                        MENSAGEM = $"Tentativa de login com o email <b>{Input.Email}</b>, recebeu como resposta <b>ACESSO NEGADO</b>.<br> <b style='color:red;'>Motivo: DADOS DE LOGIN INVÁLIDOS.</b><br>TOT. LOCKOUT: <b style='color:purple;'>{(_usu != null ? _usu.AccessFailedCount.ToString() : "?")}</b>",
                        ACAO = $"LOGIN",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = "ACESSO NEGADO",
                        TIPO = "ACESSO A PLATAFORMA",
                        UsuarioAppId = _usu != null ? _usu.Id : "b1aadecb-4357-457d-bfea-27e153505497",
                        VALOR = 0,
                        UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                    }, _context);

                    ModelState.AddModelError(string.Empty, "Dados inválidos de login. Verifique com atenção o campo USUÁRIO OU EMAIL e o campo SENHA.");

                    if (_usu != null)
                    {
                        if (_usu.AccessFailedCount > 3)
                        {
                            ModelState.AddModelError(string.Empty, "Não conseguimos validar suas credenciais em nosso servidor. Entre em contato com a House2Invest e informe este problema.");

                            try { await _signInManager.UserManager.SetLockoutEnabledAsync(_usu, true); } catch (Exception) { }
                            try { await _signInManager.SignOutAsync(); } catch (Exception) { }

                            try
                            {
                                _usu.LockoutEnabled = true;
                                _usu.Sistema_AcessoBloqueado = true;
                                _usu.AccessFailedCount = 0;
                                _usu.LockoutEnd = null;
                                _context.Attach(_usu).State = EntityState.Modified;
                                await _context.SaveChangesAsync();

                                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                                {
                                    ICOMENS = "<i class='fas fa-user-lock text-warning'></i>",
                                    MENSAGEM = $"O usuário <img src='{_usu.AvatarUsuario}' style='border-radius:100%;max-width:100%;height:24px;margin-right:5px;' /> <b>{_usu.Nome} {_usu.Sobrenome}</b> email <b>{_usu.Email}</b>, recebeu <b style='color:red;'>LOCKOUT</b> em sua conta.<br> <b style='color:red;'>Motivo: SUCESSIVAS TENTATIVAS DE LOGIN INVÁLIDAS.</b><br>TOT. LOCKOUT: <b style='color:purple;'>{(_usu != null ? _usu.AccessFailedCount.ToString() : "?")}</b>",
                                    ACAO = $"ATIVADO",
                                    DTHR = DateTime.Now,
                                    IP = _ips.FirstOrDefault(),
                                    STATUS = "LOCKOUT NA CONTA",
                                    TIPO = "ACESSO A PLATAFORMA",
                                    UsuarioAppId = _usu != null ? _usu.Id : "b1aadecb-4357-457d-bfea-27e153505497",
                                    VALOR = 0,
                                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                                }, _context);
                            }
                            catch (Exception) { }

                            return Page();
                        }
                    }
                }
            }
            //*****************************************
            // DADOS INVÁLIDOS DE LOGIN. FALTAM CAMPOS
            //*****************************************
            else
            {
                ModelState.AddModelError(string.Empty, "Por favor, informe o email e a senha da sua conta antes de prosseguir.");
            }

            return Page();




            //if (ModelState.IsValid)
            //{
            //    var _usu =
            //        _context.Users
            //        .Where(x => x.UserName.ToLower().Trim() == Input.Email.ToLower().Trim())
            //        .FirstOrDefault();

            //    try
            //    {
            //        if (_usu.AccessFailedCount > 3)
            //        {
            //            //await _signInManager.UserManager.SetLockoutEnabledAsync(_usu, true);
            //            _usu.LockoutEnabled = true;
            //            _usu.Sistema_AcessoBloqueado = true;
            //            _context.Attach(_usu).State = EntityState.Modified;
            //            await _context.SaveChangesAsync();

            //            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            //            {
            //                ICOMENS = "<i class='fas fa-user-lock text-danger'></i>",
            //                MENSAGEM = $"O USUÁRIO <i>{_usu.Email}</i> TEVE O ACESSO BLOQUEADO A PLATAFORMA. MOTIVO: <b style='color:red;'>5 TENTATIVAS INVÁLIDAS DE ACESSO EM UM CURTO ESPAÇO DE TEMPO</b>. <br><i style='color:red;'>Clique <a href='/CMSUsuarios/Edit?id={_usu.Id}'>AQUI</a> para acessar a conta deste usuário.</i>",
            //                ACAO = $"LOCKOUT",
            //                DTHR = DateTime.Now,
            //                IP = _ips.FirstOrDefault(),
            //                STATUS = "BLOQUEADO",
            //                TIPO = "ACESSO A PLATAFORMA",
            //                UsuarioAppId = _usu.Id,
            //                VALOR = 0,
            //                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            //            }, _context);

            //            //_context.LOGCENTRALs.Add(new LOGCENTRAL()
            //            //{
            //            //    ACAO = "ENTRADA NO SISTEMA",
            //            //    INVEST_LancamentoId = 0,
            //            //    INVEST_ModeloDocId = 0,
            //            //    TP = "LOCKOUT",
            //            //    URLDOC = "",
            //            //    VALOR = 0,
            //            //    STATUS = "ATIVADO",
            //            //    UsuarioAppId = _usu.Id,
            //            //    IP = _ips.FirstOrDefault()
            //            //});
            //            //await _context.SaveChangesAsync();

            //            ModelState.AddModelError(string.Empty, "Não conseguimos validar suas credenciais em nosso servidor. Entre em contato com a House2Invest e informe este problema.");
            //            try { await _signInManager.SignOutAsync(); } catch (System.Exception) { }
            //            return Page();
            //        }
            //    }
            //    catch (Exception err)
            //    {
            //        var erro = err;
            //        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            //        {
            //            ICOMENS = "<i class='fas fa-bug text-danger'></i>",
            //            MENSAGEM = $"{erro.Message}<br><code>{erro.StackTrace}</code>",
            //            ACAO = $"ERRO",
            //            DTHR = DateTime.Now,
            //            IP = _ips.FirstOrDefault(),
            //            STATUS = "ERRO INTERNO",
            //            TIPO = "ACESSO A PLATAFORMA",
            //            UsuarioAppId = _usu.Id,
            //            VALOR = 0,
            //            UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            //        }, _context);

            //        return Page();
            //    }

            //    //--------------------------------
            //    // LOGCENTRAL
            //    //--------------------------------
            //    var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, true);
            //    if (result.Succeeded)
            //    {
            //        //var _usu = _context.Users.Where(x => x.UserName.ToLower().Trim() == Input.Email.ToLower().Trim()).FirstOrDefault();
            //        if (_usu != null)
            //        {
            //            //if (_usu.AccessFailedCount > 3)
            //            //{
            //            //    await _signInManager.UserManager.SetLockoutEnabledAsync(_usu, true);
            //            //    ModelState.AddModelError(string.Empty, "Não conseguimos validar suas credenciais em nosso servidor. Entre em contato com a House2Invest e informe este problema.");
            //            //    try { await _signInManager.SignOutAsync(); } catch (System.Exception) { }
            //            //    return Page();
            //            //}



            //            if (!_usu.EmailConfirmed)
            //            {
            //                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            //                {
            //                    ICOMENS = "<i class='fas fa-sign-in-alt text-danger'></i>",
            //                    MENSAGEM = $"O USUÁRIO <i>{_usu.Email}</i> TEVE O ACESSO NEGADO A PLATAFORMA. MOTIVO: <b style='color:red;'>EMAIL AINDA NÃO CONFIRMADO</b>. <br><i style='color:red;'>Clique <a href='/CMSUsuarios/Edit?id={_usu.Id}'>AQUI</a> para acessar a conta deste usuário.</i>",
            //                    ACAO = $"BLOQUEIO",
            //                    DTHR = DateTime.Now,
            //                    IP = _ips.FirstOrDefault(),
            //                    STATUS = "EMAIL NÃO CONFIRMADO",
            //                    TIPO = "ACESSO A PLATAFORMA",
            //                    UsuarioAppId = _usu.Id,
            //                    VALOR = 0,
            //                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            //                }, _context);

            //                ModelState.AddModelError(string.Empty, "Email ainda não foi confirmado.");
            //                //_context.LOGCENTRALs.Add(new LOGCENTRAL()
            //                //{
            //                //    ACAO = "ENTRADA NO SISTEMA",
            //                //    INVEST_LancamentoId = 0,
            //                //    INVEST_ModeloDocId = 0,
            //                //    TP = "LOGIN",
            //                //    URLDOC = "",
            //                //    VALOR = 0,
            //                //    STATUS = "EMAIL NÃO CONFIRMADO",
            //                //    UsuarioAppId = _usu.Id,
            //                //    IP = _ips.FirstOrDefault()
            //                //});
            //                //await _context.SaveChangesAsync();
            //                try { await _signInManager.SignOutAsync(); } catch (System.Exception) { }
            //                return Page();
            //            }

            //            if (_usu.Sistema_AcessoBloqueado)
            //            {
            //                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            //                {
            //                    ICOMENS = "<i class='fas fa-sign-in-alt text-danger'></i>",
            //                    MENSAGEM = $"O USUÁRIO <i>{_usu.Email}</i> TEVE O ACESSO NEGADO A PLATAFORMA. MOTIVO: <b style='color:red;'>ACESSO BLOQUEADO</b>. <br><i style='color:red;'>Clique <a href='/CMSUsuarios/Edit?id={_usu.Id}'>AQUI</a> para acessar a conta deste usuário.</i>",
            //                    ACAO = $"BLOQUEIO",
            //                    DTHR = DateTime.Now,
            //                    IP = _ips.FirstOrDefault(),
            //                    STATUS = "AVALIAÇÃO DE FICHA PENDENTE",
            //                    TIPO = "ACESSO A PLATAFORMA",
            //                    UsuarioAppId = _usu.Id,
            //                    VALOR = 0,
            //                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            //                }, _context);

            //                ModelState.AddModelError(string.Empty, "Estamos analisando as informações da sua conta. Logo menos, entramos em contato. Obrigado pela paciência.");

            //                //_context.LOGCENTRALs.Add(new LOGCENTRAL()
            //                //{
            //                //    ACAO = "ENTRADA NO SISTEMA",
            //                //    INVEST_LancamentoId = 0,
            //                //    INVEST_ModeloDocId = 0,
            //                //    TP = "LOGIN",
            //                //    URLDOC = "",
            //                //    VALOR = 0,
            //                //    STATUS = "ACESSO BLOQUEADO",
            //                //    UsuarioAppId = _usu.Id,
            //                //    IP = _ips.FirstOrDefault()
            //                //});
            //                //await _context.SaveChangesAsync();

            //                try { await _signInManager.SignOutAsync(); } catch (System.Exception) { }
            //                return Page();
            //            }
            //        }

            //        _logger.LogInformation("User logged in.");


            //        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            //        {
            //            ICOMENS = "<i class='fas fa-sign-in-alt text-success'></i>",
            //            MENSAGEM = $"<b>{_usu.Email}</b> <i>FEZ LOGIN</i> NA PLATAFORMA.",
            //            ACAO = $"LOGIN",
            //            DTHR = DateTime.Now,
            //            IP = _ips.FirstOrDefault(),
            //            STATUS = "SUCESSO",
            //            TIPO = "ACESSO A PLATAFORMA",
            //            UsuarioAppId = _usu.Id,
            //            VALOR = 0,
            //            UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            //        }, _context);

            //        try
            //        {


            //            ////--------------------------------
            //            //// LOGCENTRAL
            //            ////--------------------------------
            //            //_context.LOGCENTRALs.Add(new LOGCENTRAL()
            //            //{
            //            //    ACAO = "ACESSO A PLATAFORMA",
            //            //    INVEST_LancamentoId = 0,
            //            //    INVEST_ModeloDocId = 0,
            //            //    TP = "LOGIN",
            //            //    URLDOC = "",
            //            //    VALOR = 0,
            //            //    STATUS = "SUCESSO",
            //            //    UsuarioAppId = _usu.Id,
            //            //    IP = _ips.FirstOrDefault()
            //            //});
            //            //await _context.SaveChangesAsync();
            //        }
            //        catch (System.Exception) { }

            //        return LocalRedirect(returnUrl);
            //    }

            //    if (result.RequiresTwoFactor)
            //    {
            //        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, Input.RememberMe });
            //    }

            //    //if (result.IsLockedOut)
            //    //{
            //    //    ModelState.AddModelError(string.Empty, "Não conseguimos validar suas credenciais em nosso servidor. Entre em contato com a House2Invest e informe este problema.");

            //    //    _context.LOGCENTRALs.Add(new LOGCENTRAL()
            //    //    {
            //    //        ACAO = "ENTRADA NO SISTEMA",
            //    //        INVEST_LancamentoId = 0,
            //    //        INVEST_ModeloDocId = 0,
            //    //        TP = "LOGIN",
            //    //        URLDOC = "",
            //    //        VALOR = 0,
            //    //        STATUS = "LOCKOUT",
            //    //        UsuarioAppId = _usu.Id,
            //    //        IP = _ips.FirstOrDefault()
            //    //    });
            //    //    await _context.SaveChangesAsync();

            //    //    try { await _signInManager.SignOutAsync(); } catch (System.Exception) { }
            //    //    return RedirectToPage("./Lockout");

            //    //    //_logger.LogWarning("User account locked out.");
            //    //    //return RedirectToPage("./Lockout");
            //    //}
            //    //else
            //    //{

            //    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            //    {
            //        ICOMENS = "<i class='fas fa-sign-in-alt text-danger'></i>",
            //        MENSAGEM = $"O USUÁRIO <i>{_usu.Email}</i> TEVE ACESSO NEGADO A PLATAFORMA. MOTIVO: Dados de login inválidos.",
            //        ACAO = $"LOGIN",
            //        DTHR = DateTime.Now,
            //        IP = _ips.FirstOrDefault(),
            //        STATUS = "ACESSO NEGADO",
            //        TIPO = "ACESSO A PLATAFORMA",
            //        UsuarioAppId = _usu.Id,
            //        VALOR = 0,
            //        UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            //    }, _context);

            //    ModelState.AddModelError(string.Empty, "Dados de login inválidos.");
            //    return Page();
            //    //}
            //}

            //return Page();
        }
    }
}