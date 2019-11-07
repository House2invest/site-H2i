using House2Invest.Data;
using House2Invest.Hubs;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Ionic.Zip;
using Ionic.Zlib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using static House2Invest.VerificadoresRetornos;
namespace House2Invest.Pages.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        //private readonly IHubContext<ChatHub> _hubContext;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHubContext<NotificacoesHub> _hubNotificacoes;
        private readonly IHubContext<MensagensHub> _hubMensagens;
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _context1;
        private readonly SignInManager<UsuarioApp> _signInManager;
        public SistemaController(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment, SignInManager<UsuarioApp> signInManager, ApplicationDbContext context, ApplicationDbContext context1, IHubContext<NotificacoesHub> hubNotificacoes, IHubContext<MensagensHub> hubMensagens) { _signInManager = signInManager; _context = context; _context1 = context1; _hubNotificacoes = hubNotificacoes; _hubMensagens = hubMensagens; _hostingEnvironment = hostingEnvironment; _accessor = accessor; }
        UsuarioApp RetornaUsuLogado(string uid = "")
        {
            return _context.Users
                .FirstOrDefault(x => string.IsNullOrEmpty(uid) ? x.UserName == User.Identity.Name : x.Id == uid);
        }
        tblUsuSalaVIP RetornaUsuSalaVIP(string uid)
        {
            return _context.tblUsuSalaVIPs
                .Include(x => x.UsuarioApp)
                .FirstOrDefault(x => x.UsuarioAppId == uid);
        }


        [HttpGet]
        public async Task<object> CheckRotina()
        {
            try
            {
                //var _novoFoo = new FooBar()
                //{
                //    Secret = "Olá, eu sou uma frase encryptada."
                //};
                //_context.FooBar.Add(_novoFoo);
                //await _context.SaveChangesAsync();

                //var _registrosFoo = _context.FooBar.ToList();

                //foreach (var item in _registrosFoo)
                //{
                //    var _foo = item;
                //    var oq = _foo.Secret;

                //}
            }
            catch (Exception err)
            {
                var erro = err;
            }

            try
            {
                var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var _ips = new string[] { ip, "value2" };

                var hoje = DateTime.Now;
                //--------------------------
                // PEGO AS OFERTAS SUSPENSAS
                //--------------------------
                var _ofertaSuspensas =
                    _context.BlocoProjInvestimentos
                    .Where(x => x.Status == "S" &&
                    hoje > x.DataLimiteSuspensao)
                    .ToList();

                if (_ofertaSuspensas.Any())
                {
                    //--------------------------------
                    // APLICACAO PADRAO
                    //--------------------------------
                    var _appPadrao =
                        _context.AppConfiguracoes_Aplicativo
                        .FirstOrDefault();

                    foreach (var oferta in _ofertaSuspensas)
                    {
                        var _lancamentosExistentes =
                            _context.INVEST_Lancamentos
                            .Include(x => x.BlocoProjInvestimentos)
                            .Include(x => x.BlocoProjInvestimentos.Construtora)
                            .Include(x => x.UsuarioApp)
                            .Where(x => x.BlocoProjInvestimentosId == oferta.Id && x.Status == "A")
                            .ToList();

                        // DATA LIMITE
                        var _datalimite = DateTime.Now.AddDays(7);

                        // AGRUPO POR USUARIO
                        foreach (var usuario in _lancamentosExistentes.GroupBy(x => x.UsuarioApp))
                        {
                            var _valorSomado = usuario.Sum(x => x.Valor);
                            var _novatransf = new Transferencia()
                            {
                                IdIncorporadora = oferta.ConstrutoraId,
                                BlocoProjInvestimentoId = oferta.Id,
                                IdUsu = usuario.Key.Id,
                                URLComprovante = "",
                                Valor = _valorSomado,
                                DataLimite = _datalimite
                            };
                            _context.Tranferencias.Add(_novatransf);
                            await _context.SaveChangesAsync();

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-info-circle text-primary'></i>",
                                MENSAGEM = $"TRANSFERÊNCIA DE <b>{_novatransf.Valor.ToString("C2")}</b> CRIADA PARA <b>{usuario.Key.Email}</b>. ATENÇÃO!!!!! A DATA LIMITE PARA TRANSFERÊNCIA DESSE VALOR É DE <b>{_datalimite.ToShortDateString()}</b><br> <div>    <a href='https://calendar.google.com/calendar/r/eventedit?dates={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}/{_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&text=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&details=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{oferta.Titulo}&sf=true' class='btn btn-sm bg-red' target='_blank' title='Criar lembrete no Google Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-google'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://calendar.yahoo.com/?v=60&st={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&et={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&title=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&in_loc=House2Invest&desc=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{oferta.Titulo}' class='btn btn-sm bg-violet' target='_blank' title='Criar lembrete no Yahoo Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-yahoo'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://outlook.live.com/owa/?path=/calendar/action/compose&rru=addevent&startdt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&enddt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&subject=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&body=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{oferta.Titulo}' class='btn btn-sm bg-blue' target='_blank' title='Criar lembrete no Microsoft Outlook' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-windows'></i> <i class='far fa-calendar-plus'></i></a>    </div>",
                                ACAO = $"CRIOU",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = "PENDENTE",
                                TIPO = "TRANSFERÊNCIAS",
                                UsuarioAppId = _novatransf.IdUsu,
                                VALOR = _novatransf.Valor,
                                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                            }, _context);

                            string _textoEmail = $"Prezado {usuario.Key.Nome} <br>";
                            _textoEmail += $"Em atenção à determinação da Superintendência de Registro de Valores Mobiliários – SER, comunicamos que a oferta pública <b>{oferta.Titulo}</b> foi <b style='color:red;'>CANCELADA</b>. <br>";
                            _textoEmail += $"Você receberá a devolução integral do valor investido <b>até o quinto dia útil posterior ao recebimento da presente comunicação</b>. <br>";
                            _textoEmail += $"Para obter informações adicionais, entre em contato no e-mail: <i>contato@house2invest.com.br</i> <br>";
                            _textoEmail += $"Atenciosamente, <br>";
                            _textoEmail += $"<b>Equipe House2invest</b> <br>";
                            // instanciar objeto email
                            var _objemail = new ObjetoEmailEnvio()
                            {
                                ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                                COPIA = _appPadrao.mailToAdd,
                                mailFrom = _appPadrao.mailFrom,
                                MENSAGEM = _textoEmail,
                                PARA = usuario.Key.Email,
                                smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                                smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                                smtpEnableSsl = _appPadrao.smtpEnableSsl,
                                smtpHost = _appPadrao.smtpHost,
                                smtpPort = _appPadrao.smtpPort,
                                smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                            };
                            var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                                MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_novatransf.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                                ACAO = $"ENVIOU EMAIL",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = PROC__RetornaStatusLiteralOferta("C"),
                                TIPO = "NOTIFICAÇÃO",
                                UsuarioAppId = usuario.Key.Id,
                                VALOR = _novatransf.Valor,
                                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                            }, _context);

                            // ALTERO O STATUS DO LANÇAMENTO PARA CANCELADO
                            foreach (var lancamento in _lancamentosExistentes)
                            {
                                lancamento.Status = "C";
                                _context.Attach(lancamento).State = EntityState.Modified;
                                await _context.SaveChangesAsync();
                            }
                        }

                        //-----------------------------
                        // TROCO O STATUS DA OFERTA
                        //-----------------------------
                        await _context.BlocoProjInvestimentos
                        .Where(x => x.Id == oferta.Id)
                        .UpdateAsync(x => new BlocoProjInvestimento() { Status = "C" });

                        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                        {
                            ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                            MENSAGEM = $"O STATUS DA OFERTA <b style='color:darkgreen;'>{oferta.Titulo}</b> FOI ALTERADO PARA <b style='color:purple;'>{PROC__RetornaStatusLiteralOferta("C")}</b>",
                            ACAO = $"ALTEROU",
                            DTHR = DateTime.Now,
                            IP = _ips.FirstOrDefault(),
                            STATUS = PROC__RetornaStatusLiteralOferta("C"),
                            TIPO = "STATUS DA OFERTA",
                            UsuarioAppId = "b1aadecb-4357-457d-bfea-27e153505497",
                            VALOR = Convert.ToDouble(oferta.Valor),
                            UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                        }, _context);
                    }

                    //foreach (var oferta in _ofertaSuspensas)
                    //{
                    //    //-----------------------------
                    //    // TROCO O STATUS DA OFERTA
                    //    //-----------------------------
                    //    await _context.BlocoProjInvestimentos
                    //    .Where(x => x.Id == oferta.Id)
                    //    .UpdateAsync(x => new BlocoProjInvestimento() { Status = "C" });

                    //    //----------------------------------------------------------
                    //    // PEGO OS LANCAMENTOS DA OFERTA QUE ACABOU DE SER CANCELADA
                    //    // AGRUPADOS POR USUÁRIO
                    //    //----------------------------------------------------------
                    //    var lancamentosOfertaCancelada =
                    //        await _context.INVEST_Lancamentos
                    //        .Include(x => x.BlocoProjInvestimentos)
                    //        .Include(x => x.BlocoProjInvestimentos.Construtora)
                    //        .Include(x => x.UsuarioApp)
                    //        .Where(x => x.Status == "A" && x.BlocoProjInvestimentos.Id == oferta.Id)
                    //        .GroupBy(x => x.UsuarioApp)
                    //        .ToListAsync();

                    //    //----------------------------------------------------------
                    //    // NOVA LISTA DE TRANSFERENCIAS
                    //    //----------------------------------------------------------
                    //    var _rangeLancamentosUsuarioTotalizado =
                    //        new List<Transferencia>();

                    //    //----------------------------------------------------------
                    //    // RODO CADA LANCAMENTO E CRIO UMA TRANSFERENCIA
                    //    //----------------------------------------------------------
                    //    foreach (var lancamento in lancamentosOfertaCancelada)
                    //    {
                    //        //-------------------------------------------------------
                    //        // NOVA TRANSFERENCIA
                    //        //--------------------------------------------------------
                    //        var _novaTransf = new Transferencia()
                    //        {
                    //            BlocoProjInvestimentoId = lancamento.FirstOrDefault().BlocoProjInvestimentosId,
                    //            DataLimite = DateTime.Now.AddDays(7),
                    //            IdIncorporadora = lancamento.FirstOrDefault().BlocoProjInvestimentos.ConstrutoraId,
                    //            IdUsu = lancamento.Key.Id,
                    //            URLComprovante = "",
                    //            Valor = lancamento.Sum(x => x.Valor)
                    //        };
                    //        _rangeLancamentosUsuarioTotalizado.Add(_novaTransf);

                    //        //----------------------------------------------------------
                    //        // ALTERO O STATUS DO LANCAMENTO PARA CANCELADO
                    //        //----------------------------------------------------------
                    //        var _lancaStatusAntigo =
                    //            _context.INVEST_Lancamentos
                    //            .Where(x => x.Id == lancamento.FirstOrDefault().Id && x.Status == "A")
                    //            .FirstOrDefault();

                    //        if (_lancaStatusAntigo != null)
                    //        {
                    //            _lancaStatusAntigo.Status = "C";
                    //            _context.Update(_lancaStatusAntigo);
                    //            await _context.SaveChangesAsync();
                    //        }
                    //    }

                    //    //----------------------------------------------------------
                    //    // SE HOUVER OBJETO NA LISTA, CRIO E GRAVO
                    //    //----------------------------------------------------------
                    //    if (_rangeLancamentosUsuarioTotalizado.Count > 0)
                    //    {
                    //        await _context.AddRangeAsync(_rangeLancamentosUsuarioTotalizado);
                    //        await _context.SaveChangesAsync();
                    //    }
                    //}


                    ////-----------------------------
                    //// TROCO O STATUS
                    ////-----------------------------
                    //var resultado =
                    //    await _context.BlocoProjInvestimentos
                    //    .Where(x => x.Status == "S" && hoje > x.DataLimiteSuspensao)
                    //    .UpdateAsync(x => new BlocoProjInvestimento() { Status = "C" });

                    ////------------------------------------------------------------
                    //// PEGO LANCAMENTOS APROVADOS QUE EXISTEM EM OFERTAS SUSPENSAS
                    ////------------------------------------------------------------
                    //var lancamentosAprovadosOfertaCancelada =
                    //    await _context.INVEST_Lancamentos
                    //    .Include(x => x.BlocoProjInvestimentos)
                    //    .Include(x => x.BlocoProjInvestimentos.Construtora)
                    //    .Include(x => x.UsuarioApp)
                    //    .Where(x => x.Status == "A" && x.BlocoProjInvestimentos.Status == "C")
                    //    .GroupBy(x => x.UsuarioApp)
                    //    .ToListAsync();

                    ////-------------------------------------------------------
                    //// CRIO AS TRANSFERENCIAS
                    ////--------------------------------------------------------
                    //var _rangeLancamentosUsuarioTotalizado = new List<Transferencia>();
                    //foreach (var lancamento in lancamentosAprovadosOfertaCancelada)
                    //{
                    //    var _novaTransf = new Transferencia()
                    //    {
                    //        BlocoProjInvestimentoId = lancamento.FirstOrDefault().BlocoProjInvestimentosId,
                    //        DataLimite = DateTime.Now.AddDays(5),
                    //        IdIncorporadora = lancamento.FirstOrDefault().BlocoProjInvestimentos.ConstrutoraId,
                    //        IdUsu = lancamento.Key.Id,
                    //        URLComprovante = "",
                    //        Valor = lancamento.Sum(x => x.Valor)
                    //    };
                    //    _rangeLancamentosUsuarioTotalizado.Add(_novaTransf);
                    //}

                    //if (_rangeLancamentosUsuarioTotalizado.Count > 0)
                    //{
                    //    await _context.AddRangeAsync(_rangeLancamentosUsuarioTotalizado);
                    //    await _context.SaveChangesAsync();
                    //}

                    //----------------------------------------
                    // ALTERO O STATUS DE TODOS OS LANCAMENTOS
                    //----------------------------------------
                    //await _context.INVEST_Lancamentos
                    //    .Include(x => x.BlocoProjInvestimentos)
                    //    .Where(x => x.Status == "A" && x.BlocoProjInvestimentos.Status == "C")
                    //    .UpdateAsync(x => new INVEST_Lancamento() { Status = "R", Id = x.Id });

                    return new
                    {
                        s = "troca_status",
                        m = $" ~> [{DateTime.Now}]: Ao menos (UMA) oferta(s) foi(ram) CANCELADA(s)"
                    };
                }
                else
                {
                    return new
                    {
                        s = "",
                        m = $"[{DateTime.Now}]: ({HttpContext.TraceIdentifier})"
                    };
                }
            }
            catch (Exception erro)
            {
                var _erro = erro;
                return new
                {
                    s = "",
                    m = $"    !!! [{DateTime.Now}]: ### ({_erro.Message}) ###"
                };
            }



            //var _existeOfertaSuspensa =
            //    _context.BlocoProjInvestimentos
            //    .Where(x => x.Status == "S").ToList();
            //foreach (var oferta in _existeOfertaSuspensa)
            //{
            //    if (oferta.DataLimiteSuspensao < DateTime.Now)
            //    {
            //        //-------------------
            //        // PEGO A OFERTA
            //        //-------------------
            //        var _oferta =
            //            _context.BlocoProjInvestimentos
            //            .Include(x => x.Construtora)
            //            .Where(x => x.Id == oferta.Id)
            //            .FirstOrDefault();
            //        _oferta.Status = "C";
            //        _context.Attach(_oferta).State = EntityState.Modified;
            //        await _context.SaveChangesAsync();
            //        //--------------------------------
            //        // APLICACAO PADRAO
            //        //--------------------------------
            //        var _configAplicacoes =
            //            _context.AppConfiguracoes_Aplicativo
            //            .FirstOrDefault();
            //        // INVESTIDORES
            //        var _investidores = _context.INVEST_Lancamentos
            //                .Include(x => x.UsuarioApp)
            //                .Where(x => x.BlocoProjInvestimentosId == _oferta.Id &&
            //                x.Status == "A")
            //                .ToList();
            //        var _datalimite = DateTime.Now.AddDays(5);
            //        foreach (var lancamento in _investidores.GroupBy(x => x.UsuarioApp))
            //        {
            //            var _novatransf = new Transferencia()
            //            {
            //                IdIncorporadora = _oferta.ConstrutoraId,
            //                BlocoProjInvestimentoId = _oferta.Id,
            //                IdUsu = lancamento.FirstOrDefault().UsuarioAppId,
            //                URLComprovante = "",
            //                Valor = lancamento.Sum(x => x.Valor),
            //                DataLimite = _datalimite
            //            };
            //            _context.Tranferencias.Add(_novatransf);
            //            await _context.SaveChangesAsync();
            //            //string _textoEmail = $"Prezado {lancamento.FirstOrDefault().UsuarioApp.Nome} <br>";
            //            //_textoEmail += $"Em atenção à determinação da Superintendência de Registro de Valores Mobiliários – SER, comunicamos que a oferta pública {_oferta.Titulo} foi cancelada. <br>";
            //            //_textoEmail += $"O Investidor receberá a devolução integral do valor investido iaté o quinto dia útil posterior ao recebimento da presente comunicação.. <br>";
            //            //_textoEmail += $"Para obter informações adicionais, entre em contato no e-mail: contato@house2invest.com.br <br>";
            //            //_textoEmail += $"Atenciosamente, <br>";
            //            //_textoEmail += $"Equipe House2invest <br>";
            //            //// instanciar objeto email
            //            //var _objemail = new ObjetoEmailEnvio()
            //            //{
            //            //    ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
            //            //    COPIA = _configAplicacoes.mailToAdd,
            //            //    mailFrom = _configAplicacoes.mailFrom,
            //            //    MENSAGEM = _textoEmail,
            //            //    PARA = lancamento.FirstOrDefault().UsuarioApp.Email,
            //            //    smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
            //            //    smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
            //            //    smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
            //            //    smtpHost = _configAplicacoes.smtpHost,
            //            //    smtpPort = _configAplicacoes.smtpPort,
            //            //    smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
            //            //};
            //            //var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);
            //        }
            //    }
            //}
        }


        [HttpGet]
        public object Processo()
        {
            Process currentProcess = Process.GetCurrentProcess();
            long totalBytesOfMemoryUsed = currentProcess.WorkingSet64;
            return new
            {
                processo_nome = currentProcess.ProcessName,
                processo_memoria = VerificadoresRetornos.RetornaTamanhoArquivoParaHumanos(totalBytesOfMemoryUsed),
                processo_id = $"{currentProcess.StartTime.ToShortDateString()} - {currentProcess.StartTime.ToShortTimeString()}"
            };
        }
        [HttpGet]
        public object ImagensAlbum(int id)
        {
            var _lista =
                _context.GaleriaPerfilImagem
                .Where(x => x.GaleriaPerfilAlbumId == id)
                .OrderBy(x => x.Descricao);

            return new
            {
                lista = _lista
            };
        }
        [HttpGet]
        [Authorize]
        public async Task<object> DelReg(string objeto, string codigo)
        {
            if (string.IsNullOrEmpty(objeto))
                return new { mens = "Erro ao excluir o registro. Registro protegido." };

            var _usu = _context.Users
                .Where(x => x.UserName == User.Identity.Name)
                .FirstOrDefault();

            try
            {
                switch (objeto.ToLower().Trim())
                {
                    case "appperfil":
                        if (_context.AppPerfil.Count() == 1)
                            return new { mens = "Erro ao excluir o registro. Registro protegido." };

                        var _exc_appperfil =
                            _context.AppPerfil
                            .Where(x => x.Id == Convert.ToInt32(codigo)).FirstOrDefault();

                        _context.AppPerfil.Remove(_exc_appperfil);
                        await _context.SaveChangesAsync();
                        break;

                    case "config":
                        var _exc_appconfiguracoes =
                            _context.AppConfiguracoes
                            .Where(x => x.Id == Convert.ToInt32(codigo)).FirstOrDefault();

                        _context.AppConfiguracoes.Remove(_exc_appconfiguracoes);
                        await _context.SaveChangesAsync();
                        break;

                    case "configapp":
                        var _exc_configapp =
                            _context.AppConfiguracoes_Aplicativo
                            .Where(x => x.Id == Convert.ToInt32(codigo)).FirstOrDefault();

                        _context.AppConfiguracoes_Aplicativo.Remove(_exc_configapp);
                        await _context.SaveChangesAsync();
                        break;

                    case "appgaleria":
                        var _config = _context.AppPerfil
                            .Include(x => x.AppConfiguracoes)
                            .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                            .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                            .FirstOrDefault();

                        var _imagensgaleria =
                            _context.GaleriaPerfilImagem
                            .Where(x => x.GaleriaPerfilAlbumId == Convert.ToInt32(codigo))
                            .ToList();

                        foreach (var imagem in _imagensgaleria)
                        {
                            var _exc_appgaleria_imagem =
                                _context.GaleriaPerfilImagem
                                .Where(x => x.Id == imagem.Id).FirstOrDefault();

                            _context.GaleriaPerfilImagem.Remove(_exc_appgaleria_imagem);
                            await _context.SaveChangesAsync();

                            // PEGA NOME DO ARQUIVO
                            string _nomedoarq = "";
                            Uri uri = new Uri(imagem.Url);
                            _nomedoarq = System.IO.Path.GetFileName(uri.LocalPath);

                            await VerificadoresRetornos
                                .ApagarBlob(
                                _nomedoarq,
                                _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName,
                                _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey,
                                _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz,
                                _config.AppConfiguracoes.AppConfiguracoes_Azure.UsarSimuladorLocal,
                                _config.AppConfiguracoes.AppConfiguracoes_Azure.EnderecoArmazLocal);
                        }

                        var _exc_appgaleria =
                            _context.GaleriaPerfilAlbum
                            .Where(x => x.Id == Convert.ToInt32(codigo)).FirstOrDefault();

                        _context.GaleriaPerfilAlbum.Remove(_exc_appgaleria);
                        await _context.SaveChangesAsync();
                        break;

                    case "blocosprojinvest":
                        if (User.IsInRole("SIS"))
                        {
                            try
                            {
                                var LISTA = new List<INVEST_Lancamento>();
                                LISTA = _context.INVEST_Lancamentos
                                    .Where(x => x.BlocoProjInvestimentosId == Convert.ToInt32(codigo))
                                    .ToList();

                                if (LISTA.Count() > 0)
                                {
                                    foreach (var cancela in LISTA)
                                    {
                                        // DOCS
                                        var _exc_blocosprojinvestvalorDOCS =
                                            _context.INVEST_LancamentoDocs
                                            .Include(x => x.INVEST_Lancamento)
                                            .Where(x => x.INVEST_LancamentoId == cancela.Id);
                                        if (_exc_blocosprojinvestvalorDOCS.Count() > 0)
                                        {
                                            _context.INVEST_LancamentoDocs.RemoveRange(_exc_blocosprojinvestvalorDOCS);
                                            await _context.SaveChangesAsync();
                                        }

                                        //foreach (var item in _exc_blocosprojinvestvalorDOCS)
                                        //{
                                        //    _context.INVEST_LancamentoDocs.Remove(item);
                                        //    await _context.SaveChangesAsync();
                                        //}

                                        // IMAGENS
                                        var _exc_blocosprojinvestvalor =
                                            _context.INVEST_LancamentoImagens
                                            .Where(x => x.INVEST_LancamentoId == cancela.Id);

                                        if (_exc_blocosprojinvestvalor.Count() > 0)
                                        {
                                            _context.INVEST_LancamentoImagens.RemoveRange(_exc_blocosprojinvestvalor);
                                            await _context.SaveChangesAsync();
                                        }

                                        //foreach (var item in _exc_blocosprojinvestvalor)
                                        //{
                                        //    _context.INVEST_LancamentoImagens.Remove(item);
                                        //    await _context.SaveChangesAsync();
                                        //}
                                    }

                                    // LANCAMENTOS
                                    //foreach (var cancela in _lancaID)
                                    //{
                                    //    var _exc_cancela =
                                    //        _context.INVEST_Lancamentos
                                    //        .Where(x => x.Id == cancela.Id)
                                    //        .FirstOrDefault();

                                    //    if (_exc_cancela != null)
                                    //    {
                                    //        _context.INVEST_Lancamentos.Remove(_exc_cancela);
                                    //        await _context.SaveChangesAsync();
                                    //    }
                                    //}

                                    var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                                    var _ips = new string[] { ip, "value2" };

                                    foreach (var item in LISTA)
                                    {
                                        //// LOGCENTRAL
                                        //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                                        //{
                                        //    ACAO = "INVESTIMENTO - CANCELAMENTO",
                                        //    INVEST_LancamentoId = item.Id,
                                        //    INVEST_ModeloDocId = item.Id,
                                        //    TP = item.TP,
                                        //    URLDOC = "",
                                        //    VALOR = item.Valor,
                                        //    STATUS = item.Status,
                                        //    UsuarioAppId = item.UsuarioAppId,
                                        //    IP = _ips.FirstOrDefault()
                                        //});
                                        //await _context.SaveChangesAsync();
                                    }

                                    _context.INVEST_Lancamentos.RemoveRange(LISTA);
                                    await _context.SaveChangesAsync();
                                }
                            }
                            catch (Exception erro) { var _err = erro; }

                            try
                            {
                                //_usu = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                                var _exc_blocosprojinvestvalorlanca =
                                    _context.INVEST_Lancamentos
                                    .Where(x => x.UsuarioAppId == _usu.Id)
                                    .FirstOrDefault();
                                _context.INVEST_Lancamentos.Remove(_exc_blocosprojinvestvalorlanca);
                                await _context.SaveChangesAsync();
                            }
                            catch (Exception) { }

                            try
                            {
                                var _exc_blocosprojinvestvalorlanca =
                                    _context.INVEST_Lancamentos
                                    .Where(x => x.Id == Convert.ToInt32(codigo))
                                    .FirstOrDefault();

                                if (_exc_blocosprojinvestvalorlanca != null)
                                {
                                    _context.INVEST_Lancamentos.Remove(_exc_blocosprojinvestvalorlanca);
                                    await _context.SaveChangesAsync();
                                }
                            }
                            catch (Exception) { }
                        }


                        var _exc_blocosprojinvest =
                            _context.BlocoProjInvestimentos
                            .Where(x => x.Id == Convert.ToInt32(codigo)).FirstOrDefault();

                        _context.BlocoProjInvestimentos.Remove(_exc_blocosprojinvest);
                        await _context.SaveChangesAsync();
                        break;

                    case "blocosprojinvestvalor":
                        ////try
                        ////{
                        ////    //var _lancaID = _context.INVEST_Lancamentos
                        ////    //    .Where(x => x.BlocoProjInvestimentosId == codigo && x.UsuarioAppId == _usu.Id)
                        ////    //    .FirstOrDefault();

                        ////    //if (_lancaID != null)
                        ////    //{
                        ////    //    var _exc_blocosprojinvestvalor =
                        ////    //        _context.INVEST_LancamentoImagens
                        ////    //        .Where(x => x.INVEST_LancamentoId == _lancaID.Id);
                        ////    //    foreach (var item in _exc_blocosprojinvestvalor)
                        ////    //    {
                        ////    //        _context.INVEST_LancamentoImagens.Remove(item);
                        ////    //        await _context.SaveChangesAsync();
                        ////    //    }
                        ////    //}
                        ////}
                        ////catch (Exception) { }

                        //var _teste =
                        //    _context.INVEST_Lancamentos
                        //    .Where(x => x.UsuarioAppId == _usu.Id && x.BlocoProjInvestimentosId == Convert.ToInt32(codigo))
                        //    .FirstOrDefault();

                        //var _log = _context.LOGCENTRALs
                        //    .Where(x => x.INVEST_LancamentoId == _teste.Id &&
                        //        x.UsuarioAppId == _teste.UsuarioAppId &&
                        //        x.STATUS == "A")
                        //        .FirstOrDefault();

                        //if (DateTime.Now > _log.DTHR.AddDays(7))
                        //{
                        //    return new { mens = "SUPERIOR A 7 DIAS. NÃO PODE SER CANCELADO" };
                        //}

                        //try
                        //{
                        //    //var _exc_blocoDOCS = new List<INVEST_LancamentoDoc>();
                        //    //_exc_blocoDOCS =
                        //    //    _context.INVEST_LancamentoDocs
                        //    //    .Include(x => x.INVEST_Lancamento)
                        //    //    .Include(x => x.INVEST_Lancamento.BlocoProjInvestimentos)
                        //    //    .Include(x => x.INVEST_Lancamento.UsuarioApp)
                        //    //    .Where(x => x.INVEST_Lancamento.BlocoProjInvestimentosId == codigo && x.INVEST_Lancamento.UsuarioAppId == _usu.Id)
                        //    //    .ToList();

                        //    //foreach (var item in _exc_blocoDOCS)
                        //    //{
                        //    //    _context.INVEST_LancamentoDocs.Remove(item);
                        //    //    await _context.SaveChangesAsync();
                        //    //}
                        //}
                        //catch (Exception) { }

                        //try
                        //{
                        //    //var _usu = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                        //    var _exc_blocoslanca = new INVEST_Lancamento();
                        //    _exc_blocoslanca =
                        //        _context.INVEST_Lancamentos
                        //        .Where(x => x.UsuarioAppId == _usu.Id && x.BlocoProjInvestimentosId == Convert.ToInt32(codigo))
                        //        .FirstOrDefault();

                        //    var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                        //    var _ips = new string[] { ip, "value2" };

                        //    foreach (var item in _context.INVEST_Lancamentos.Where(x => x.UsuarioAppId == _usu.Id && x.BlocoProjInvestimentosId == Convert.ToInt32(codigo)))
                        //    {
                        //        item.Status = "C";
                        //        _context.Attach(item).State = EntityState.Modified;
                        //        await _context.SaveChangesAsync();


                        //        //// LOGCENTRAL
                        //        //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                        //        //{
                        //        //    ACAO = "INVESTIMENTO - CANCELAMENTO",
                        //        //    INVEST_LancamentoId = item.Id,
                        //        //    INVEST_ModeloDocId = item.Id,
                        //        //    TP = item.TP,
                        //        //    URLDOC = "",
                        //        //    VALOR = item.Valor,
                        //        //    STATUS = item.Status,
                        //        //    UsuarioAppId = _usu.Id,
                        //        //    IP = _ips.FirstOrDefault()
                        //        //});
                        //        //await _context.SaveChangesAsync();
                        //    }

                        //    //_context.INVEST_Lancamentos.Remove(_exc_blocoslanca);
                        //    //await _context.SaveChangesAsync();

                        //    //// LOGCENTRAL
                        //    //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                        //    //{
                        //    //    ACAO = "INVESTIMENTO - CANCELAMENTO",
                        //    //    INVEST_LancamentoId = _exc_blocoslanca.Id,
                        //    //    INVEST_ModeloDocId = _exc_blocoslanca.Id,
                        //    //    TP = _exc_blocoslanca.TP,
                        //    //    URLDOC = "",
                        //    //    VALOR = _exc_blocoslanca.Valor,
                        //    //    STATUS = _exc_blocoslanca.Status,
                        //    //    UsuarioAppId = _usu.Id
                        //    //});
                        //    //await _context.SaveChangesAsync();

                        //}
                        //catch (Exception) { }

                        //try
                        //{
                        //    var _exc_blocoCONTRANSF = new List<INVEST_ControleTransf>();
                        //    _exc_blocoCONTRANSF =
                        //        _context.INVEST_ControleTransfs
                        //        .Where(x => x.BlocoProjInvestimentosId == Convert.ToInt32(codigo) && x.UsuarioAppId == _usu.Id)
                        //        .ToList();

                        //    foreach (var item in _exc_blocoCONTRANSF)
                        //    {
                        //        item.Status = "C";
                        //        _context.Attach(item).State = EntityState.Modified;
                        //        await _context.SaveChangesAsync();

                        //        //_context.INVEST_ControleTransfs.Remove(item);
                        //        //await _context.SaveChangesAsync();
                        //    }
                        //}
                        //catch (Exception) { }

                        break;

                    //var _exc_blocosprojinvestvalor =
                    //    _context.BlocoProjInvestimentoValores
                    //    .Where(x => x.Id == codigo).FirstOrDefault();

                    //_context.BlocoProjInvestimentoValores.Remove(_exc_blocosprojinvestvalor);
                    //await _context.SaveChangesAsync();
                    //break;

                    case "blococruditemdoc":
                        var _exc_blocoItemDoc =
                            _context.BlocoProjInvestimento_ItemDocs
                            .Where(x => x.Id == Convert.ToInt32(codigo)).FirstOrDefault();

                        _context.BlocoProjInvestimento_ItemDocs.Remove(_exc_blocoItemDoc);
                        await _context.SaveChangesAsync();
                        break;

                    case "modelodoc":
                        var _exc_doc =
                            _context.INVEST_ModeloDocs
                            .Where(x => x.Id == Convert.ToInt32(codigo)).FirstOrDefault();

                        _context.INVEST_ModeloDocs.Remove(_exc_doc);
                        await _context.SaveChangesAsync();
                        break;

                    case "usuarios":
                        //var _exc_logs =
                        //    _context.LOGCENTRALs
                        //    .Where(x => x.UsuarioAppId == codigo);
                        //_context.LOGCENTRALs.RemoveRange(_exc_logs);
                        //await _context.SaveChangesAsync();

                        var _exc_usu =
                            _context.Users
                            .Where(x => x.Id == codigo).FirstOrDefault();

                        _context.Users.Remove(_exc_usu);
                        await _context.SaveChangesAsync();
                        break;

                    case "taxasglobais":
                        var _exc_taxas_globais =
                            _context.TaxasGLOBAIS
                            .Where(x => x.Id == Convert.ToInt32(codigo)).FirstOrDefault();

                        _context.TaxasGLOBAIS.Remove(_exc_taxas_globais);
                        await _context.SaveChangesAsync();
                        break;

                    default:
                        return new { mens = "Procedimento de exclusão não mapeado. Informe ao setor de desenvolvimento sobre esse erro." };
                }
            }
            catch (System.Exception) { return new { mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." }; }

            return new { mens = "ok" };
        }
        [HttpGet]
        [Authorize]
        public async Task<object> TransfFundos(string objeto, int codigo, string tp = "")
        {
            if (string.IsNullOrEmpty(objeto))
                return new { mens = "Erro ao transferir fundos. Registro protegido." };

            try
            {
                switch (objeto.ToLower().Trim())
                {
                    case "blocosprojinvest":
                        if (User.IsInRole("SIS"))
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(tp))
                                {
                                    var _bloco =
                                        _context.BlocoProjInvestimentos
                                        .Where(x => x.Id == codigo)
                                        .FirstOrDefault();

                                    if (_bloco != null)
                                    {
                                        // CONTROLE TRANSF - ADMIN
                                        _context.INVEST_ControleTransfs.Add(new INVEST_ControleTransf()
                                        {
                                            BlocoProjInvestimentosId = _bloco.Id,
                                            Status = "T",
                                            UsuarioAppId = "b1aadecb-4357-457d-bfea-27e153505497",
                                            Valor = Convert.ToDouble(_bloco.Valor.Replace("R$", ""))
                                        });
                                        await _context.SaveChangesAsync();
                                    }
                                }

                                if (!string.IsNullOrEmpty(tp))
                                {
                                    var _controle = new INVEST_ControleTransf();
                                    _controle = _context.INVEST_ControleTransfs
                                        .Include(x => x.BlocoProjInvestimentos)
                                        .Where(x => x.Id == codigo)
                                        .FirstOrDefault();

                                    // STATUS DO LANCAMENTO
                                    var _lancaAPROVADO =
                                        _context.INVEST_Lancamentos
                                        .Where(x =>
                                            x.BlocoProjInvestimentosId == _controle.BlocoProjInvestimentosId &&
                                            x.Valor == _controle.Valor &&
                                            x.UsuarioAppId == _controle.UsuarioAppId)
                                            .FirstOrDefault();

                                    if (_lancaAPROVADO == null)
                                    {
                                        return new { mens = "Não localizei o Lançamento" };
                                    }

                                    if (_lancaAPROVADO.Status != "A")
                                    {
                                        return new { mens = "O Lançamento correspondente a Transferência não foi APROVADO ainda." };
                                    }

                                    var _valor = _controle.Valor;
                                    var _valorperc = (_controle.Valor / 100) * 22;
                                    var _valortot = _valor + _valorperc;

                                    // ALTERO O STATUS: "PENDENTE DO USUARIO" para "PENDENTE-T"
                                    //_context.Attach(_controle).State = EntityState.Modified;
                                    //await _context.SaveChangesAsync();

                                    //_controle = _context.INVEST_ControleTransfs
                                    //    .Include(x => x.BlocoProjInvestimentos)
                                    //    .Where(x => x.Id == codigo)
                                    //    .FirstOrDefault();

                                    // CONTROLE TRANSF - USU
                                    _context.INVEST_ControleTransfs.Add(new INVEST_ControleTransf()
                                    {
                                        BlocoProjInvestimentosId = _controle.BlocoProjInvestimentosId,
                                        Status = "T",
                                        UsuarioAppId = _controle.UsuarioAppId,
                                        Valor = _valortot,
                                        IdCompensacao = _controle.Id
                                    });
                                    await _context.SaveChangesAsync();

                                    //var _lancas =
                                    //    _context.INVEST_ControleTransfs
                                    //    .Include(x => x.BlocoProjInvestimentos)
                                    //    .Where(x => x.BlocoProjInvestimentosId == codigo && x.Status == "T");

                                    //foreach (var item in collection)
                                    //{

                                    //}
                                }


                            }
                            catch (Exception) { }
                        }

                        break;

                    default:
                        return new { mens = "Procedimento de transferência não mapeado. Informe ao setor de desenvolvimento sobre esse erro." };
                }
            }
            catch (System.Exception) { return new { mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." }; }

            return new { mens = "ok" };
        }
        [HttpGet]
        [Authorize(Roles = "SIS")]
        public async Task<object> NovaConsultaTaxa()
        {
            try
            {
                var _taxa = _context.TaxaMercados
                    .Where(x => x.DTHR.ToShortDateString() == DateTime.Now.ToShortDateString()).FirstOrDefault();

                if (_taxa == null)
                {
                    var _novaconsulta = new TaxaMercado();
                    var _resultado_GEO = await ChamaREST.Current
                        .GetAsync<HgFinance>("finance?format=json&key=0574aee9");

                    //HttpClient client = new HttpClient();
                    //HttpResponseMessage response = await client.GetAsync("https://api.hgbrasil.com/finance?format=json&key=0574aee9");
                    //response.EnsureSuccessStatusCode();
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    //var _resultado_GEO = JsonConvert.DeserializeObject<HgFinance>(responseBody);

                    _novaconsulta.data = _resultado_GEO.results.taxes.FirstOrDefault().date;
                    _novaconsulta.cdi = float.Parse(_resultado_GEO.results.taxes.FirstOrDefault().cdi.ToString(), System.Globalization.CultureInfo.CurrentCulture);
                    _novaconsulta.selic = float.Parse(_resultado_GEO.results.taxes.FirstOrDefault().selic.ToString(), System.Globalization.CultureInfo.CurrentCulture);
                    _novaconsulta.fator_diario = float.Parse(_resultado_GEO.results.taxes.FirstOrDefault().daily_factor.ToString(), System.Globalization.CultureInfo.CurrentCulture);

                    _context.Add(_novaconsulta);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception err) { return new { mens = err.Message }; }

            return new { mens = "ok" };
        }
        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        public async Task<object> RetornaListaFilhosLp(string tp = "", int idbloco = 0)
        {
            try
            {
                switch (tp.ToLower().Trim())
                {
                    case "docsinvest":
                        var _dados = await
                        _context
                        .BlocoProjInvestimento_ItemDocs
                        .Include(x => x.BlocoProjInvestimento)
                        .Include(x => x.INVEST_ModeloDoc)
                        .Where(x => x.BlocoProjInvestimentoId == idbloco)
                        .OrderByDescending(x => x.DTHR).ToListAsync();

                        var _lista = new List<object>();
                        foreach (var item in _dados)
                        {
                            _lista.Add(new
                            {
                                id = item.Id,
                                dthr = item.DTHR,
                                idbloco = item.BlocoProjInvestimentoId,
                                blocotit = item.BlocoProjInvestimento.Titulo,
                                doctit = item.INVEST_ModeloDoc.Titulo
                            });
                        }

                        return new
                        {
                            dados = _lista
                        };

                    //case "caract":
                    //    return new { dados = await _context.lp_caracteristicas.Where(x => x.Idlp == idlp).OrderBy(x => x.Ordem).ToListAsync() };

                    //case "faq":
                    //    return new { dados = await _context.lp_FAQ.Where(x => x.Idlp == idlp).OrderBy(x => x.Ordem).ToListAsync() };

                    //case "contatos":
                    //    var _tblcontatos =
                    //        await _context.lp_contatos
                    //        .Where(x => x.Idlp == idlp)
                    //        .OrderByDescending(x => x.DTHRCRIACAO)
                    //        .ToListAsync();

                    //    var _listaSaidaProcessada = new List<DeserializaListaContato>();

                    //    var _elemStringCampos = "";
                    //    foreach (var contato in _tblcontatos)
                    //    {
                    //        var _listformdeseria =
                    //            JsonConvert
                    //            .DeserializeObject<List<NameValueJson>>(contato.CorpoContato);

                    //        var _CampoEmail = false;
                    //        var _CampoFone = false;
                    //        var _CampoCelu = false;
                    //        var _CampoText = false;
                    //        foreach (var elemento in _listformdeseria)
                    //        {
                    //            if (elemento.name.ToLower().Trim() != "idlp")
                    //            {
                    //                if (EhEmail(elemento.value))
                    //                    _CampoEmail = true;

                    //                if (EhNumeroTelefone(elemento.value.Replace("(", "").Replace(")", "").Replace("-", "")))
                    //                    _CampoFone = true;

                    //                if (EhNumeroCelular(elemento.value.Replace("(", "").Replace(")", "").Replace("-", "")))
                    //                    _CampoCelu = true;

                    //                if (!_CampoEmail && !_CampoFone && !_CampoCelu)
                    //                    _CampoText = true;

                    //                if (_CampoEmail)
                    //                {
                    //                    _elemStringCampos += "<i class='fa fa-envelope'></i> <b id=\"" + elemento.name + "\" name=\"" + elemento.name + "\">" + elemento.value + "</b><div class=\"col-12 line\" style='margin:.5rem 0;'></div>" + Environment.NewLine;
                    //                }
                    //                if (_CampoFone)
                    //                {
                    //                    _elemStringCampos += "<i class='fa fa-phone'></i> <b id=\"" + elemento.name + "\" name=\"" + elemento.name + "\">" + elemento.value + "</b><div class=\"col-12 line\" style='margin:.5rem 0;'></div>" + Environment.NewLine;
                    //                }
                    //                if (_CampoCelu)
                    //                {
                    //                    _elemStringCampos += "<i class='fa fa-mobile'></i> <b id=\"" + elemento.name + "\" name=\"" + elemento.name + "\">" + elemento.value + "</b><div class=\"col-12 line\" style='margin:.5rem 0;'></div>" + Environment.NewLine;
                    //                }
                    //                if (_CampoText)
                    //                {
                    //                    _elemStringCampos += "<i id=\"" + elemento.name + "\" name=\"" + elemento.name + "\">" + elemento.value + "</i><div class=\"col-12 line\" style='margin:.5rem 0;'></div>" + Environment.NewLine;
                    //                }

                    //                _CampoEmail = false;
                    //                _CampoFone = false;
                    //                _CampoCelu = false;
                    //                _CampoText = false;
                    //            }
                    //        }

                    //        _listaSaidaProcessada.Add(new DeserializaListaContato()
                    //        {
                    //            id = contato.Id,
                    //            data = contato.DTHRCRIACAO.ToShortDateString() + " - " + contato.DTHRCRIACAO.ToShortTimeString(),
                    //            corpo_bruto = contato.CorpoContato,
                    //            corpo_seria = _elemStringCampos,
                    //            idlp = idlp
                    //        });

                    //        _elemStringCampos = "";
                    //    }

                    //    //var _listformdeseria = JsonConvert.DeserializeObject<List<NameValueJson>>()
                    //    return new
                    //    {
                    //        dados = _listaSaidaProcessada
                    //    };

                    default:
                        break;
                }
            }
            catch (Exception) { }

            return new { dados = "" };
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ListaInvestFront(int id = 0)
        {
            var _lista = new List<object>();
            try
            {
                var _ofertas =
                    await _context.BlocoProjInvestimentos
                    .Where(x => (id > 0 ? x.Id == id : 1 == 1))
                    .OrderByDescending(x => x.DTHR)
                    .ToListAsync();

                foreach (var _oferta in _ofertas)
                {
                    var _novoobjRaiz = new
                    {
                        _oferta.Id,
                        _oferta.DTHR,
                        contador_ano = _oferta.DTHR.Year,
                        contador_mes = _oferta.DTHR.Month.ToString("D2"),
                        contador_dia = _oferta.DTHR.Day.ToString("D2"),
                        contador_hor = _oferta.DTHR.Hour.ToString("D2"),
                        contador_min = _oferta.DTHR.Minute.ToString("D2"),
                        contador_seg = _oferta.DTHR.Second.ToString("D2"),
                        _oferta.Titulo,
                        imagem = _oferta.UrlImgPrinc,
                        valor = Convert.ToDouble(_oferta.Valor),
                        lancemin = Convert.ToDouble(_oferta.LanceMinimo),
                        _oferta.Contador_Exib,
                        _oferta.Contador_DataFinal,
                        _oferta.BlocoProjInvest_ExibTitulo,
                        valormindoc = Convert.ToDouble(_oferta.ValorMinimoDocs),
                        status = "EM ANDAMENTO"
                    };

                    var _novoobjmecanica = new
                    {
                        _valTot = 0.0,
                        _valReserva = 0.0,
                        _valAdquirido = 0.0,
                        _valFracao = 0.0,
                        _valFracaoRes = 0.0,
                        _valFracaoAdq = 0.0,
                        _valLanceMin = 0.0,
                        _valMinimoDoc = 0.0
                    };

                    _lista.Add(new
                    {
                        raiz = _novoobjRaiz,
                        mecanica = _novoobjmecanica
                    });
                }
            }
            catch (Exception erro) { return new OkObjectResult(erro.Message); }

            return new OkObjectResult(_lista);
        }
        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        public async Task<object> ListaDocsBloco(int idbloco = 0)
        {
            try
            {
                var _dados = await
                _context
                .BlocoProjInvestimento_ItemDocs
                .Include(x => x.BlocoProjInvestimento)
                .Include(x => x.INVEST_ModeloDoc)
                .Where(x => x.BlocoProjInvestimentoId == idbloco)
                .OrderByDescending(x => x.DTHR).ToListAsync();

                var _lista = "";
                foreach (var item in _dados)
                {
                    /*
                    if (string.IsNullOrEmpty(doc.INVEST_ModeloDoc.Hyperlink)) 
                    */
                    if (string.IsNullOrEmpty(item.INVEST_ModeloDoc.Hyperlink))
                    {
                        _lista += "<li class=\"lidivdoc\">";
                        _lista += "    <a href=\"DocInvestVisu?id=" + item.INVEST_ModeloDoc.Id + "\" class=\"btn btn-sm btn-primary\" target=\"_blank\" style=\"font-size:11px;padding-bottom:0px;\"><i class=\"fa fa-share\"></i> " + item.INVEST_ModeloDoc.Titulo + "</a>";
                        _lista += "</li>";
                    }
                    else
                    {
                        _lista += "<li class=\"lidivdoc\">";
                        _lista += "    <a href=\"" + item.INVEST_ModeloDoc.Hyperlink + "\" class=\"btn btn-sm btn-primary\" target=\"_blank\" style=\"font-size:11px;padding-bottom:0px;\"><i class=\"fa fa-share\"></i> " + item.INVEST_ModeloDoc.Titulo + "</a>";
                        _lista += "</li>";
                    }

                }

                return new
                {
                    status = "ok",
                    dados = _lista
                };
            }
            catch (Exception) { }

            return new { status = "erro", dados = "" };
        }
        [HttpPost]
        [Authorize]
        public async Task<object> DataTableAjax_AppPerfil()
        {
            try
            {
                return new JsonResult(new
                {
                    meta = new
                    {
                        page = 1,
                        pages = 1,
                        perpage = -1,
                        total = 1,
                        sort = "asc",
                        field = "id"
                    },
                    data = await _context.AppPerfil
                    .Include(x => x.AppConfiguracoes)
                    .ToListAsync()
                });
            }
            catch (Exception) { return new { mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." }; }
        }
        [HttpPost]
        [Authorize]
        public async Task<object> DataTableAjax_AppPerfil_FilhoConfiguracoes(int id)
        {
            try
            {
                return new JsonResult(new
                {
                    meta = new
                    {
                        page = 1,
                        pages = 1,
                        perpage = -1,
                        total = 1,
                        sort = "asc",
                        field = "id"
                    },
                    data = await _context.AppConfiguracoes
                    .Where(x => x.Id == id)
                    .ToListAsync()
                });
            }
            catch (Exception) { return new { mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." }; }
        }
        [HttpPost]
        [Authorize]
        public async Task<object> DataTableAjax_AppPerfil_FilhoAplicativo(int id)
        {
            try
            {
                return new JsonResult(new
                {
                    meta = new
                    {
                        page = 1,
                        pages = 1,
                        perpage = -1,
                        total = 1,
                        sort = "asc",
                        field = "id"
                    },
                    data = await _context.AppConfiguracoes_Aplicativo
                    .Where(x => x.Id == id)
                    .ToListAsync()
                });
            }
            catch (Exception) { return new { mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." }; }
        }
        [HttpPost]
        public async Task<object> Listar(string OrdenarPor, string FiltroAtual, string StringBusca, int? Pagina)
        {
            return await ListaPaginada<GaleriaPerfilAlbum>
                .CriarAsync(_context.GaleriaPerfilAlbum
                .Include(x => x.AppPerfil)
                .Include(x => x.AppPerfil.AppConfiguracoes)
                .AsQueryable().AsNoTracking(), Pagina ?? 1, Startup._LISTAPAGINADATOT);
        }










        [HttpGet]
        [Authorize(Roles = "SIS")]
        public async Task<object> AprovaLanc(int codigo, string tp)
        {
            var _usu = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            if (codigo <= 0)
                return new { mens = "Erro ao aprovar lançamento." };

            if (string.IsNullOrEmpty(tp))
                return new { mens = "Erro ao aprovar lançamento." };

            try
            {
                //-------------------
                // PEGO O LANCAMENTO
                //-------------------
                var _lancamentoSelecionado =
                    _context.INVEST_Lancamentos
                    .Include(x => x.UsuarioApp)
                    .Where(x => x.Id == codigo)
                    .FirstOrDefault();

                //--------------------------------
                // EH UMA RESERVA SEM CONFIRMAÇÃO?
                //--------------------------------
                var _temreserva =
                    _context.InvestimentoConfirmacoes
                    .Include(x => x.UsuarioApps)
                    .Include(x => x.BlocoProjInvestimentos)
                    .Where(
                        x => x.BlocoProjInvestimentoId == _lancamentoSelecionado.BlocoProjInvestimentosId &&
                        x.UsuarioAppId == _lancamentoSelecionado.UsuarioApp.Id
                    ).FirstOrDefault();

                //--------------------------------
                // TEM RESERVA
                //--------------------------------
                if (_temreserva != null)
                {
                    //--------------------------------
                    // RESERVA NÃO CONFIRMADA?
                    //--------------------------------
                    if (!_temreserva.Confirmado)
                    {
                        return new { mens = "CARO ADM. ESTE LANÇAMENTO NÃO PODE SER APROVADO NO MOMENTO!!! O USUÁRIO AINDA NÃO CONFIRMOU A RESERVA REFERENTE AO LANÇAMENTO. =[" };
                    }
                }

                //--------------------------------
                // ALTERO O TIPO DO LANCAMENTO
                //--------------------------------
                if (_lancamentoSelecionado != null)
                {
                    _lancamentoSelecionado.Status = tp.ToUpper().Trim();
                }

                //-------------------------------------
                // SALVO O LANCAMENTO COM O NOVO STATUS
                //-------------------------------------
                _context.Attach(_lancamentoSelecionado).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                //--------------------------------
                // LOGCENTRAL
                //--------------------------------
                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                {
                    ICOMENS = "<i class='fas fa-check-circle text-success'></i>",
                    MENSAGEM = $"O STATUS DO LANÇAMENTO DE NÚMERO <b>{_lancamentoSelecionado.Id}</b> NO VALOR DE <b>{_lancamentoSelecionado.Valor.ToString("C2")}</b>, PERTENCENTE A OFERTA <b>{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}</b> FOI ALTERADO PARA <b style='color:green;'>{VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamentoSelecionado.Status)}</b><br>Para maiores detalhes <a href='/BlocosProjInvestValor'>clique aqui</a>",
                    ACAO = $"ALTEROU",
                    DTHR = DateTime.Now,
                    IP = _ips.FirstOrDefault(),
                    STATUS = VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamentoSelecionado.Status),
                    TIPO = "STATUS DE LANÇAMENTO",
                    UsuarioAppId = _lancamentoSelecionado.UsuarioAppId,
                    VALOR = _lancamentoSelecionado.Valor,
                    UsuarioAppCriadorId = _usu.Id
                }, _context);

                //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                //{
                //    ACAO = "STATUS INVESTIMENTO",
                //    INVEST_LancamentoId = _lancamentoSelecionado.Id,
                //    INVEST_ModeloDocId = _lancamentoSelecionado.Id,
                //    TP = _lancamentoSelecionado.TP,
                //    URLDOC = "",
                //    VALOR = _lancamentoSelecionado.Valor,
                //    STATUS = _lancamentoSelecionado.Status,
                //    UsuarioAppId = _lancamentoSelecionado.UsuarioAppId,
                //    IP = _ips.FirstOrDefault()
                //});
                //await _context.SaveChangesAsync();

                //--------------------------------
                // APLICACAO PADRAO
                //--------------------------------
                var _configAplicacoes =
                    _context.AppConfiguracoes_Aplicativo
                    .FirstOrDefault();

                if (tp.ToUpper().Trim() == "A")
                {
                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-exchange-alt text-success'></i>",
                        MENSAGEM = $"O LANÇAMENTO DE NÚMERO <b>{_lancamentoSelecionado.Id}</b> TEVE O SEU VALOR DE <b>{_lancamentoSelecionado.Valor.ToString("C2")}</b> TRANSFERIDO DO SALDO <b style='color:darkorange;'>RESERVADO</b> PARA O SALDO <b style='color:#5867dd;'>ADQUIRIDO</b><br>Para maiores detalhes <a href='/BlocosProjInvestValor'>clique aqui</a>",
                        ACAO = $"TROCOU",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamentoSelecionado.Status),
                        TIPO = "TRANSFERÊNCIA DE SALDOS",
                        UsuarioAppId = _lancamentoSelecionado.UsuarioAppId,
                        VALOR = _lancamentoSelecionado.Valor,
                        UsuarioAppCriadorId = _usu.Id
                    }, _context);

                    // ALERTO SOBRE O LIMITE DE "DIAS" PARA O CANCELAMENTO
                    // instanciar objeto email
                    string _textoEmail = $"Prezado {_lancamentoSelecionado.UsuarioApp.Nome} <br>";
                    _textoEmail += $"O seu investimento de <b>{_lancamentoSelecionado.Valor.ToString("C2")}</b> na oferta <b>{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}</b> foi <b style='color:green;'>APROVADO</b>. <br>";
                    _textoEmail += $"Vale lembrar que você tem até o dia <b style='color:red;'>{_lancamentoSelecionado.DataLimiteCancelamento.ToShortDateString()}</b> para <b>CANCELAR</b> este investimento.<br><br>";
                    _textoEmail += $"Atenciosamente, <br>";
                    _textoEmail += $"<b>Equipe House2invest</b> <br>";
                    var _objemail = new ObjetoEmailEnvio()
                    {
                        ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                        COPIA = _configAplicacoes.mailToAdd,
                        mailFrom = _configAplicacoes.mailFrom,
                        MENSAGEM = _textoEmail,
                        PARA = _lancamentoSelecionado.UsuarioApp.Email,
                        smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                        smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                        smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                        smtpHost = _configAplicacoes.smtpHost,
                        smtpPort = _configAplicacoes.smtpPort,
                        smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                    };
                    var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                    // LOG DE ENVIO DE EMAIL COM ALERTA DOS "DIAS" A CANCELAR
                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                        MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_lancamentoSelecionado.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                        ACAO = $"ENVIOU EMAIL",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = PROC__RetornaStatusLiteralLancamento(tp.ToUpper().Trim()),
                        TIPO = "NOTIFICAÇÃO",
                        UsuarioAppId = _lancamentoSelecionado.UsuarioAppId,
                        VALOR = _lancamentoSelecionado.Valor,
                        UsuarioAppCriadorId = _usu.Id
                    }, _context);

                    // LOG DE ALERTA PARA A DATA LIMITE DE CANCELAMENTO DO LANCAMENTO 
                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-bell' style='color:purple;'></i>",
                        MENSAGEM = $"O lançamento de número <b>{_lancamentoSelecionado.Id}</b> com o valor <b>{_lancamentoSelecionado.Valor.ToString("C2")}</b> do investidor <img src='{_lancamentoSelecionado.UsuarioApp.AvatarUsuario}' style='max-width:100%;height:20px;border-radius:100%;margin-left:6px;margin-right:3px;'/> <b>{_lancamentoSelecionado.UsuarioApp.Nome} {_lancamentoSelecionado.UsuarioApp.Sobrenome}</b>, referente a oferta <b>{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}</b> foi <b style='color:green;'>APROVADO</b> e tem como <b style='color:red;'>DATA LIMITE DE CANCELAMENTO</b> o dia <b style='color:purple;'>{_lancamentoSelecionado.DataLimiteCancelamento.ToShortDateString()}</b>.",
                        ACAO = $"DATA LIMITE CANCELAMENTO",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = PROC__RetornaStatusLiteralLancamento(tp.ToUpper().Trim()),
                        TIPO = "NOTIFICAÇÃO",
                        UsuarioAppId = _lancamentoSelecionado.UsuarioAppId,
                        VALOR = _lancamentoSelecionado.Valor,
                        UsuarioAppCriadorId = _usu.Id
                    }, _context);



                    //-----------------------------------------------------
                    // SOMAR LANCAMENTOS PARA VER SE CHEGOU AO FIM A OFERTA
                    //-----------------------------------------------------
                    var _somaLancas = _context.INVEST_Lancamentos
                        .Where(x => x.BlocoProjInvestimentosId == _lancamentoSelecionado.BlocoProjInvestimentosId
                        && x.Status == "A")
                        .Sum(x => x.Valor);

                    if (_somaLancas == Convert.ToDouble(_lancamentoSelecionado.BlocoProjInvestimentos.Valor))
                    {
                        //--------------------------------
                        // APLICACAO PADRAO
                        //--------------------------------
                        var _appPadrao =
                            _context.AppConfiguracoes_Aplicativo
                            .FirstOrDefault();

                        //foreach (var oferta in _ofertaSuspensas)
                        //{
                        var _lancamentosExistentes =
                            _context.INVEST_Lancamentos
                            .Include(x => x.BlocoProjInvestimentos)
                            .Include(x => x.BlocoProjInvestimentos.Construtora)
                            .Include(x => x.UsuarioApp)
                            .Where(x => x.BlocoProjInvestimentosId == _lancamentoSelecionado.BlocoProjInvestimentosId && x.Status == "A")
                            .ToList();

                        // DATA LIMITE
                        var _datalimite = DateTime.Now.AddDays(7);
                        var _datalimiteInvest = VerificadoresRetornos.ConverteStringParaDateTime(_lancamentoSelecionado.BlocoProjInvestimentos.Contador_DataFinal).AddDays(5);

                        // AGRUPO POR USUARIO
                        foreach (var usuario in _lancamentosExistentes.GroupBy(x => x.UsuarioApp))
                        {
                            var _valorSomado = usuario.Sum(x => x.Valor);
                            var _novatransf = new Transferencia()
                            {
                                IdIncorporadora = _lancamentoSelecionado.BlocoProjInvestimentos.ConstrutoraId,
                                BlocoProjInvestimentoId = _lancamentoSelecionado.BlocoProjInvestimentosId,
                                IdUsu = usuario.Key.Id,
                                URLComprovante = "",
                                Valor = _valorSomado,
                                DataLimite = _datalimiteInvest
                            };
                            _context.Tranferencias.Add(_novatransf);
                            await _context.SaveChangesAsync();

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-info-circle text-primary'></i>",
                                MENSAGEM = $"TRANSFERÊNCIA DE <b>{_novatransf.Valor.ToString("C2")}</b> CRIADA PARA <b>{usuario.Key.Email}</b>. ATENÇÃO!!!!! A DATA LIMITE PARA TRANSFERÊNCIA DESSE VALOR É DE <b>{_datalimite.ToShortDateString()}</b><br> <div>    <a href='https://calendar.google.com/calendar/r/eventedit?dates={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}/{_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&text=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&details=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}&sf=true' class='btn btn-sm bg-red' target='_blank' title='Criar lembrete no Google Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-google'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://calendar.yahoo.com/?v=60&st={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&et={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&title=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&in_loc=House2Invest&desc=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}' class='btn btn-sm bg-violet' target='_blank' title='Criar lembrete no Yahoo Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-yahoo'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://outlook.live.com/owa/?path=/calendar/action/compose&rru=addevent&startdt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&enddt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&subject=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&body=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}' class='btn btn-sm bg-blue' target='_blank' title='Criar lembrete no Microsoft Outlook' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-windows'></i> <i class='far fa-calendar-plus'></i></a>    </div>",
                                ACAO = $"CRIOU",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = "PENDENTE",
                                TIPO = "TRANSFERÊNCIAS",
                                UsuarioAppId = _novatransf.IdUsu,
                                VALOR = _novatransf.Valor,
                                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                            }, _context);

                            _textoEmail = $"Prezado {usuario.Key.Nome} <br>";
                            _textoEmail += $"A oferta <b>{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}</b> foi <b>{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}</b> foi <b style='color:red;'>ENCERRADA</b>. <br>";
                            _textoEmail += $"Atenciosamente, <br>";
                            _textoEmail += $"<b>Equipe House2invest</b> <br>";
                            // instanciar objeto email
                            _objemail = new ObjetoEmailEnvio()
                            {
                                ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                                COPIA = _appPadrao.mailToAdd,
                                mailFrom = _appPadrao.mailFrom,
                                MENSAGEM = _textoEmail,
                                PARA = usuario.Key.Email,
                                smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                                smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                                smtpEnableSsl = _appPadrao.smtpEnableSsl,
                                smtpHost = _appPadrao.smtpHost,
                                smtpPort = _appPadrao.smtpPort,
                                smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                            };
                            _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                                MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_novatransf.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                                ACAO = $"ENVIOU EMAIL",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = PROC__RetornaStatusLiteralOferta("E"),
                                TIPO = "NOTIFICAÇÃO",
                                UsuarioAppId = usuario.Key.Id,
                                VALOR = _novatransf.Valor,
                                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                            }, _context);

                            // ALTERO O STATUS DO LANÇAMENTO PARA CANCELADO
                            foreach (var lancamento in _lancamentosExistentes)
                            {
                                lancamento.Status = "E";
                                _context.Attach(lancamento).State = EntityState.Modified;
                                await _context.SaveChangesAsync();
                            }
                        }

                        //--------------------------------------------
                        // TRANSF DA INCOROPORADORA
                        //--------------------------------------------
                        var _novatransfIncorp = new Transferencia()
                        {
                            IdIncorporadora = _lancamentoSelecionado.BlocoProjInvestimentos.ConstrutoraId,
                            BlocoProjInvestimentoId = _lancamentoSelecionado.BlocoProjInvestimentosId,
                            IdUsu = "I",
                            URLComprovante = "",
                            Valor = Convert.ToDouble(_lancamentoSelecionado.BlocoProjInvestimentos.Valor),
                            DataLimite = _datalimite
                        };
                        _context.Tranferencias.Add(_novatransfIncorp);
                        await _context.SaveChangesAsync();

                        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                        {
                            ICOMENS = "<i class='fas fa-info-circle text-primary'></i>",
                            MENSAGEM = $"TRANSFERÊNCIA DE <b>{Convert.ToDouble(_lancamentoSelecionado.BlocoProjInvestimentos.Valor).ToString("C2")}</b> CRIADA PARA a INCORPORADORA <b>{_novatransfIncorp.BlocoProjInvestimentos.Construtora.RazaoSocial}</b>. ATENÇÃO!!!!! A DATA LIMITE PARA TRANSFERÊNCIA DESSE VALOR É DE <b>{_datalimite.ToShortDateString()}</b>",
                            ACAO = $"CRIOU",
                            DTHR = DateTime.Now,
                            IP = _ips.FirstOrDefault(),
                            STATUS = "PENDENTE",
                            TIPO = "TRANSFERÊNCIAS",
                            UsuarioAppId = "b1aadecb-4357-457d-bfea-27e153505497",
                            VALOR = Convert.ToDouble(_lancamentoSelecionado.BlocoProjInvestimentos.Valor),
                            UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                        }, _context);


                        //-----------------------------
                        // TROCO O STATUS DA OFERTA
                        //-----------------------------
                        await _context.BlocoProjInvestimentos
                            .Where(x => x.Id == _lancamentoSelecionado.BlocoProjInvestimentos.Id)
                            .UpdateAsync(x => new BlocoProjInvestimento() { Status = "E" });

                        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                        {
                            ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                            MENSAGEM = $"O STATUS DA OFERTA <b style='color:darkgreen;'>{_lancamentoSelecionado.BlocoProjInvestimentos.Titulo}</b> FOI ALTERADO PARA <b style='color:purple;'>{PROC__RetornaStatusLiteralOferta("E")}</b>",
                            ACAO = $"ALTEROU",
                            DTHR = DateTime.Now,
                            IP = _ips.FirstOrDefault(),
                            STATUS = PROC__RetornaStatusLiteralOferta("C"),
                            TIPO = "STATUS DA OFERTA",
                            UsuarioAppId = "b1aadecb-4357-457d-bfea-27e153505497",
                            VALOR = Convert.ToDouble(_lancamentoSelecionado.Valor),
                            UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                        }, _context);

                        //}


                    }
                }






                //if (tp.ToUpper().Trim() == "A")
                //{
                //    // instanciar objeto email
                //    var _objemail = new ObjetoEmailEnvio()
                //    {
                //        ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                //        COPIA = _configAplicacoes.mailToAdd,
                //        mailFrom = _configAplicacoes.mailFrom,
                //        MENSAGEM = string.Format($"Olá!!!{Environment.NewLine}<br/>O seu investimento de {_lancamentoSelecionado.Valor.ToString("C2")} foi APROVADO."),
                //        PARA = _lancamentoSelecionado.UsuarioApp.Email,
                //        smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                //        smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                //        smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                //        smtpHost = _configAplicacoes.smtpHost,
                //        smtpPort = _configAplicacoes.smtpPort,
                //        smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                //    };
                //    var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);
                //    //var _enviou =
                //    //    await VerificadoresRetornos
                //    //    .EnviarEmail(_registro.UsuarioApp.Email, "", "[STATUS INVESTIMENTO] House2Invest", string.Format($"Olá!!!{Environment.NewLine}<br/>O seu investimento de {_registro.Valor.ToString("C2")} foi APROVADO."));
                //}
                //else if (tp.ToUpper().Trim() == "P")
                //{
                //    // instanciar objeto email
                //    var _objemail = new ObjetoEmailEnvio()
                //    {
                //        ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                //        COPIA = _configAplicacoes.mailToAdd,
                //        mailFrom = _configAplicacoes.mailFrom,
                //        MENSAGEM = string.Format($"Olá!!!{Environment.NewLine}<br/>O seu investimento de {_lancamentoSelecionado.Valor.ToString("C2")} está EM ANÁLISE."),
                //        PARA = _lancamentoSelecionado.UsuarioApp.Email,
                //        smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                //        smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                //        smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                //        smtpHost = _configAplicacoes.smtpHost,
                //        smtpPort = _configAplicacoes.smtpPort,
                //        smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                //    };
                //    var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);
                //    //var _enviou =
                //    //    await VerificadoresRetornos
                //    //    .EnviarEmail(_registro.UsuarioApp.Email, "", "[STATUS INVESTIMENTO] House2Invest", string.Format($"Olá!!!{Environment.NewLine}<br/>O seu investimento de {_registro.Valor.ToString("C2")} está EM ANÁLISE."));
                //}
                //else
                //{
                //    // instanciar objeto email
                //    var _objemail = new ObjetoEmailEnvio()
                //    {
                //        ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                //        COPIA = _configAplicacoes.mailToAdd,
                //        mailFrom = _configAplicacoes.mailFrom,
                //        MENSAGEM = string.Format($"Olá!!!{Environment.NewLine}<br/>O seu investimento de {_lancamentoSelecionado.Valor.ToString("C2")} foi CANCELADO."),
                //        PARA = _lancamentoSelecionado.UsuarioApp.Email,
                //        smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                //        smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                //        smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                //        smtpHost = _configAplicacoes.smtpHost,
                //        smtpPort = _configAplicacoes.smtpPort,
                //        smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                //    };
                //    var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);
                //    //var _enviou =
                //    //    await VerificadoresRetornos
                //    //    .EnviarEmail(_registro.UsuarioApp.Email, "", "[STATUS INVESTIMENTO] House2Invest", string.Format($"Olá!!!{Environment.NewLine}<br/>O seu investimento de {_registro.Valor.ToString("C2")} foi CANCELADO."));
                //}


                //// LOGCENTRAL
                //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                //{
                //    ACAO = "ENVIO EMAIL - STATUS INVESTIMENTO",
                //    INVEST_LancamentoId = _lancamentoSelecionado.Id,
                //    INVEST_ModeloDocId = _lancamentoSelecionado.Id,
                //    TP = _lancamentoSelecionado.TP,
                //    URLDOC = "",
                //    VALOR = _lancamentoSelecionado.Valor,
                //    STATUS = _lancamentoSelecionado.Status,
                //    UsuarioAppId = _lancamentoSelecionado.UsuarioAppId,
                //    IP = _ips.FirstOrDefault()
                //});
                //await _context.SaveChangesAsync();











                ////------------------------------------------------
                //// VERIFICO NOVAMENTE SE CHEGOU AO TOTAL DA OFERTA
                ////------------------------------------------------
                //_lancamentoSelecionado =
                //    _context.INVEST_Lancamentos
                //    .Include(x => x.BlocoProjInvestimentos)
                //    .Include(x => x.UsuarioApp)
                //    .Where(x => x.Id == codigo)
                //    .FirstOrDefault();

                //var _lancamentosOferta =
                //    _context.INVEST_Lancamentos
                //    .Include(x => x.BlocoProjInvestimentos)
                //    .Include(x => x.UsuarioApp)
                //    .Where(x => x.BlocoProjInvestimentosId == _lancamentoSelecionado.BlocoProjInvestimentosId && x.Status == "A")
                //    .ToList();

                //var _valorSoma = _lancamentosOferta.Sum(x => x.Valor);
                //var _valorOferta = Convert.ToDouble(_lancamentosOferta.FirstOrDefault().BlocoProjInvestimentos.Valor);
                //if (_valorSoma >= _valorOferta)
                //{
                //    var _bloco =
                //    _context1.BlocoProjInvestimentos
                //    .Where(x => x.Id == _lancamentoSelecionado.BlocoProjInvestimentosId)
                //    .FirstOrDefault();

                //    _bloco.Status = "E";
                //    _context1.Attach(_bloco).State = EntityState.Modified;
                //    await _context1.SaveChangesAsync();

                //    foreach (var lancamento in _lancamentosOferta)
                //    {
                //        // instanciar objeto email
                //        var _objemail = new ObjetoEmailEnvio()
                //        {
                //            ASSUNTO = "[OFERTA ENCERRADA] House2Invest",
                //            COPIA = _configAplicacoes.mailToAdd,
                //            mailFrom = _configAplicacoes.mailFrom,
                //            MENSAGEM = string.Format($"Olá!!!{lancamento.UsuarioApp.Nome}<br>A oferta referente ao investimento {lancamento.BlocoProjInvestimentos.Titulo} foi ENCERRADA com sucesso!!!"),
                //            PARA = _lancamentoSelecionado.UsuarioApp.Email,
                //            smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                //            smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                //            smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                //            smtpHost = _configAplicacoes.smtpHost,
                //            smtpPort = _configAplicacoes.smtpPort,
                //            smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                //        };
                //        var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);
                //    }

                //    var _datalimite = DateTime.Now.AddDays(5);

                //    // INCORPORADORA
                //    var _incorporadora =
                //        _context.Construtoras
                //        .Where(x => x.Id == _bloco.ConstrutoraId)
                //        .FirstOrDefault();

                //    // OFERTA
                //    var _oferta = _bloco;

                //    // LISTA DE INVESTIMENTOS
                //    var _listainvestimentos =
                //        _context.INVEST_Lancamentos
                //        .Include(x => x.UsuarioApp)
                //        .Where(x => x.BlocoProjInvestimentosId == _oferta.Id &&
                //        x.Status == "A");

                //    foreach (var lancamento in
                //        _listainvestimentos.GroupBy(x => x.UsuarioApp))
                //    {
                //        var _novatransf = new Transferencia()
                //        {
                //            IdIncorporadora = _incorporadora.Id,
                //            BlocoProjInvestimentoId = _oferta.Id,
                //            IdUsu = lancamento.FirstOrDefault().UsuarioAppId,
                //            URLComprovante = "",
                //            Valor = lancamento.Sum(x => x.Valor) / 100 * 7 + lancamento.Sum(x => x.Valor),
                //            DataLimite = _datalimite
                //        };

                //        //-----------
                //        // USUARIOS
                //        //-----------
                //        _context1.Tranferencias.Add(_novatransf);
                //        await _context1.SaveChangesAsync();
                //    }

                //    foreach (var lancamento in
                //        _listainvestimentos.GroupBy(x => x.BlocoProjInvestimentos.Construtora))
                //    {
                //        var _novatransf = new Transferencia()
                //        {
                //            IdIncorporadora = _incorporadora.Id,
                //            BlocoProjInvestimentoId = _oferta.Id,
                //            IdUsu = "I",
                //            URLComprovante = "",
                //            Valor = lancamento.Sum(x => x.Valor),
                //            DataLimite = _datalimite
                //        };

                //        //---------------
                //        // INCORPORADORAS
                //        //---------------
                //        _context1.Tranferencias.Add(_novatransf);
                //        await _context1.SaveChangesAsync();
                //    }
                //}



            }
            catch (System.Exception) { return new { mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." }; }

            //await _hubContext.Clients.All.SendAsync("Notify", $"Página carregada");

            return new { mens = "ok" };
        }






        //class Retorno_ProcAlteraStatusOferta
        //{
        //    public string Status { get; set; }
        //    public string Mensagem { get; set; }
        //}
        //private async Task PROC__GravaLOG(LOGCENTRAL log)
        //{
        //    try
        //    {
        //        _context.LOGCENTRALs.Add(log);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception) { }
        //}
        private async Task<object> PROC__AlteraStatusOferta(string ENDERECO_IP, int ID_OFERTA, string STATUS_OFERTA)
        {
            var retorno = new Retorno_ProcAlteraStatusOferta() { Status = "", Mensagem = "" };

            try
            {
                //--------------------------------
                // APLICACAO PADRAO
                //--------------------------------
                var _appPadrao =
                    _context.AppConfiguracoes_Aplicativo
                    .FirstOrDefault();

                //-------------------
                // PEGO A OFERTA
                //-------------------
                var _oferta = _context.BlocoProjInvestimentos
                    .Include(x => x.Construtora)
                    .Where(x => x.Id == ID_OFERTA)
                    .FirstOrDefault();

                //---------------------
                // USUARIO LOGADO
                //---------------------
                var _usu = _context.Users
                    .Where(x => x.UserName == User.Identity.Name)
                    .FirstOrDefault();

                //---------------------------------
                // TEM LANCAMENTOS PRESOS A OFERTA?
                //---------------------------------
                var _lancamentos =
                    _context.INVEST_Lancamentos
                    .Include(x => x.BlocoProjInvestimentos)
                    .Include(x => x.BlocoProjInvestimentos.Construtora)
                    .Include(x => x.UsuarioApp)
                    .Where(x => x.BlocoProjInvestimentosId == ID_OFERTA)
                    .ToList();

                if (_oferta != null)
                {
                    //------------------------------
                    // VALIDAÇÕES SIMPLES
                    //------------------------------
                    // oferta encerrada
                    if (_oferta.Status == "E")
                    {
                        retorno.Status = "erro";
                        retorno.Mensagem = "Esta oferta já foi ENCERRADA.";
                        return retorno;
                    }

                    // se o flag é o mesmo solicitado
                    if (STATUS_OFERTA.ToLower().Trim() == _oferta.Status.ToLower().Trim())
                    {
                        retorno.Status = "erro";
                        retorno.Mensagem = "A oferta já está operando nesse STATUS.";
                        return retorno;
                    }

                    /*
   _____          _   _  _____ ______ _               _____           _____ 
  / ____|   /\   | \ | |/ ____|  ____| |        /\   |  __ \   /\    / ____|
 | |       /  \  |  \| | |    | |__  | |       /  \  | |  | | /  \  | (___  
 | |      / /\ \ | . ` | |    |  __| | |      / /\ \ | |  | |/ /\ \  \___ \ 
 | |____ / ____ \| |\  | |____| |____| |____ / ____ \| |__| / ____ \ ____) |
  \_____/_/    \_|_| \_|\_____|______|______/_/    \_|_____/_/    \_|_____/ 

                    */
                    if (STATUS_OFERTA == "C")
                    {
                        var _lancamentosExistentes =
                            _context.INVEST_Lancamentos
                            .Include(x => x.BlocoProjInvestimentos)
                            .Include(x => x.BlocoProjInvestimentos.Construtora)
                            .Include(x => x.UsuarioApp)
                            .Where(x => x.BlocoProjInvestimentosId == ID_OFERTA && x.Status == "A")
                            .ToList();

                        // DATA LIMITE
                        var _datalimite = DateTime.Now.AddDays(5);

                        // AGRUPO POR USUARIO
                        foreach (var usuario in _lancamentosExistentes.GroupBy(x => x.UsuarioApp))
                        {
                            var _valorSomado = usuario.Sum(x => x.Valor);
                            var _novatransf = new Transferencia()
                            {
                                IdIncorporadora = _oferta.ConstrutoraId,
                                BlocoProjInvestimentoId = _oferta.Id,
                                IdUsu = usuario.Key.Id,
                                URLComprovante = "",
                                Valor = _valorSomado,
                                DataLimite = _datalimite
                            };
                            _context.Tranferencias.Add(_novatransf);
                            await _context.SaveChangesAsync();

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-info-circle text-primary'></i>",
                                MENSAGEM = $"TRANSFERÊNCIA DE <b>{_novatransf.Valor.ToString("C2")}</b> CRIADA PARA <b>{usuario.Key.Email}</b>. ATENÇÃO!!!!! A DATA LIMITE PARA TRANSFERÊNCIA DESSE VALOR É DE <b>{_datalimite.ToShortDateString()}</b><br> <div>    <a href='https://calendar.google.com/calendar/r/eventedit?dates={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}/{_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&text=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&details=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{_oferta.Titulo}&sf=true' class='btn btn-sm bg-red' target='_blank' title='Criar lembrete no Google Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-google'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://calendar.yahoo.com/?v=60&st={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&et={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&title=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&in_loc=House2Invest&desc=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{_oferta.Titulo}' class='btn btn-sm bg-violet' target='_blank' title='Criar lembrete no Yahoo Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-yahoo'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://outlook.live.com/owa/?path=/calendar/action/compose&rru=addevent&startdt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&enddt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&subject=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&body=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{usuario.Key.Financeiro_Banco_Ag}+CC:+{usuario.Key.Financeiro_Banco_CC}+Banco:+{usuario.Key.Financeiro_Banco_Nome}+do+investidor:+{usuario.Key.Nome}+{usuario.Key.Sobrenome}+com+email+{usuario.Key.Email}+devido+ao+cancelamento+da+oferta:+{_oferta.Titulo}' class='btn btn-sm bg-blue' target='_blank' title='Criar lembrete no Microsoft Outlook' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-windows'></i> <i class='far fa-calendar-plus'></i></a>    </div>",
                                ACAO = $"CRIOU",
                                DTHR = DateTime.Now,
                                IP = ENDERECO_IP,
                                STATUS = "PENDENTE",
                                TIPO = "TRANSFERÊNCIAS",
                                UsuarioAppId = _novatransf.IdUsu,
                                VALOR = _novatransf.Valor,
                                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                            }, _context);

                            string _textoEmail = $"Prezado {usuario.Key.Nome} <br>";
                            _textoEmail += $"Em atenção à determinação da Superintendência de Registro de Valores Mobiliários – SER, comunicamos que a oferta pública <b>{_oferta.Titulo}</b> foi <b style='color:red;'>CANCELADA</b>. <br>";
                            _textoEmail += $"Você receberá a devolução integral do valor investido <b>até o quinto dia útil posterior ao recebimento da presente comunicação</b>. <br>";
                            _textoEmail += $"Para obter informações adicionais, entre em contato no e-mail: <i>contato@house2invest.com.br</i> <br>";
                            _textoEmail += $"Atenciosamente, <br>";
                            _textoEmail += $"<b>Equipe House2invest</b> <br>";
                            // instanciar objeto email
                            var _objemail = new ObjetoEmailEnvio()
                            {
                                ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                                COPIA = _appPadrao.mailToAdd,
                                mailFrom = _appPadrao.mailFrom,
                                MENSAGEM = _textoEmail,
                                PARA = usuario.Key.Email,
                                smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                                smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                                smtpEnableSsl = _appPadrao.smtpEnableSsl,
                                smtpHost = _appPadrao.smtpHost,
                                smtpPort = _appPadrao.smtpPort,
                                smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                            };
                            var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                                MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_novatransf.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                                ACAO = $"ENVIOU EMAIL",
                                DTHR = DateTime.Now,
                                IP = ENDERECO_IP,
                                STATUS = PROC__RetornaStatusLiteralOferta(STATUS_OFERTA),
                                TIPO = "NOTIFICAÇÃO",
                                UsuarioAppId = usuario.Key.Id,
                                VALOR = _novatransf.Valor,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);

                            // ALTERO O STATUS DO LANÇAMENTO PARA CANCELADO
                            foreach (var lancamento in _lancamentosExistentes)
                            {
                                lancamento.Status = "C";
                                _context.Attach(lancamento).State = EntityState.Modified;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                    /*
   _____ _    _  _____ _____  ______ _   _  _____          _____ 
  / ____| |  | |/ ____|  __ \|  ____| \ | |/ ____|  /\    / ____|
 | (___ | |  | | (___ | |__) | |__  |  \| | (___   /  \  | (___  
  \___ \| |  | |\___ \|  ___/|  __| | . ` |\___ \ / /\ \  \___ \ 
  ____) | |__| |____) | |    | |____| |\  |____) / ____ \ ____) |
 |_____/ \____/|_____/|_|    |______|_| \_|_____/_/    \_|_____/ 
                    */
                    if (STATUS_OFERTA == "S")
                    {
                        var _investidores =
                            _context.INVEST_Lancamentos
                            .Include(x => x.UsuarioApp)
                            .Where(x => x.BlocoProjInvestimentosId == _oferta.Id)
                            .ToList();

                        // ENVIO EMAILS PRA TODOS
                        foreach (var pessoa in _investidores)
                        {
                            string _textoEmail = $"Prezado {pessoa.UsuarioApp.Nome} <br>";
                            _textoEmail += $"Em atenção à determinação da Superintendência de Registro de Valores Mobiliários – SER, comunicamos que a oferta pública {_oferta.Titulo} foi suspensa. <br>";
                            _textoEmail += $"O prazo de suspensão da oferta é de até 30 (trinta) dias, prazo em que a House2Invest providenciará as adequações necessárias para atendimento das exigências e obter a regularidade do processo de captação da plataforma para a oferta em referência. <br>";
                            _textoEmail += $"O Investidor tem a opção de revogar o investimento até o quinto dia útil posterior ao recebimento da presente comunicação com a garantia de restituição integral dos valores investidos, no prazo máximo de 5 (cinco) dias contados do envio do e-mail solicitando o cancelamento / revogação de seu investimento . <br>";
                            _textoEmail += $"Para realizar a revogação do investimento ofertado em nossa plataforma  ou obter informações adicionais, entre em contato no e-mail: contato@house2invest.com.br <br><br><br>";
                            _textoEmail += $"Atenciosamente, <br>";
                            _textoEmail += $"Equipe House2invest <br>";

                            // instanciar objeto email
                            var _objemail = new ObjetoEmailEnvio()
                            {
                                ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                                COPIA = _appPadrao.mailToAdd,
                                mailFrom = _appPadrao.mailFrom,
                                MENSAGEM = _textoEmail,
                                PARA = pessoa.UsuarioApp.Email,
                                smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                                smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                                smtpEnableSsl = _appPadrao.smtpEnableSsl,
                                smtpHost = _appPadrao.smtpHost,
                                smtpPort = _appPadrao.smtpPort,
                                smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                            };
                            var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
                            // LOG
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
                            //await PROC__GravaLOG(new LOGCENTRAL() { ACAO = "NOTIFICAÇÃO AO USUÁRIO", DTHR = DateTime.Now, INVEST_LancamentoId = 0, INVEST_ModeloDocId = 0, IP = ENDERECO_IP, STATUS = STATUS_OFERTA, TP = $"TROCA DE STATUS DA OFERTA <b style='color:red;'>{pessoa.BlocoProjInvestimentos.Titulo}</b>", URLDOC = "", UsuarioAppId = pessoa.UsuarioAppId, VALOR = pessoa.Valor });
                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-check-circle text-success'></i>",
                                MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog(0);' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                                ACAO = "ENVIOU",
                                DTHR = DateTime.Now,
                                IP = ENDERECO_IP,
                                STATUS = PROC__RetornaStatusLiteralOferta(STATUS_OFERTA),
                                TIPO = $"TROCA DE STATUS DA OFERTA <b style='color:red;'>{pessoa.BlocoProjInvestimentos.Titulo}</b>",
                                UsuarioAppId = pessoa.UsuarioAppId,
                                VALOR = pessoa.Valor,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
                        }
                    }

                    /*
 .----------------. .----------------. .----------------. .----------------. .----------------. 
| .--------------. | .--------------. | .--------------. | .--------------. | .--------------. |
| |    ______    | | |  _______     | | |      __      | | | ____   ____  | | |      __      | |
| |  .' ___  |   | | | |_   __ \    | | |     /  \     | | ||_  _| |_  _| | | |     /  \     | |
| | / .'   \_|   | | |   | |__) |   | | |    / /\ \    | | |  \ \   / /   | | |    / /\ \    | |
| | | |    ____  | | |   |  __ /    | | |   / ____ \   | | |   \ \ / /    | | |   / ____ \   | |
| | \ `.___]  _| | | |  _| |  \ \_  | | | _/ /    \ \_ | | |    \ ' /     | | | _/ /    \ \_ | |
| |  `._____.'   | | | |____| |___| | | ||____|  |____|| | |     \_/      | | ||____|  |____|| |
| |              | | |              | | |              | | |              | | |              | |
| '--------------' | '--------------' | '--------------' | '--------------' | '--------------' |
 '----------------' '----------------' '----------------' '----------------' '----------------' 
                     */
                    //------------------------------
                    // seto o STATUS da oferta pra GRAVAR
                    //------------------------------
                    _oferta.Status = STATUS_OFERTA;

                    if (STATUS_OFERTA.ToLower().Trim() == "s")
                    {
                        var _dataLimite = DateTime.Now;
                        if (!string.IsNullOrEmpty(_appPadrao.temporizaLmiteMaximoOfertaSuspensa))
                        {
                            var _tipo = _appPadrao.temporizaLmiteMaximoOfertaSuspensa.ToLower().Trim();
                            if (_tipo.Contains("min"))
                            {
                                _dataLimite = _dataLimite.AddMinutes(Convert.ToInt32(_tipo.Replace("min", "")));
                            }
                            else if (_tipo.Contains("hor"))
                            {
                                _dataLimite = _dataLimite.AddHours(Convert.ToInt32(_tipo.Replace("hor", "")));
                            }
                            else if (_tipo.Contains("dia"))
                            {
                                _dataLimite = _dataLimite.AddDays(Convert.ToInt32(_tipo.Replace("dia", "")));
                            }
                            else if (_tipo.Contains("sem"))
                            {
                                _dataLimite = _dataLimite.AddDays(Convert.ToInt32(_tipo.Replace("sem", "")) * 7);
                            }
                            else if (_tipo.Contains("mes"))
                            {
                                _dataLimite = _dataLimite.AddMonths(Convert.ToInt32(_tipo.Replace("mes", "")));
                            }
                            else if (_tipo.Contains("ano"))
                            {
                                _dataLimite = _dataLimite.AddYears(Convert.ToInt32(_tipo.Replace("ano", "")));
                            }
                        }

                        _oferta.DataLimiteSuspensao = _dataLimite;
                    }
                    else
                    {
                        _oferta.DataLimiteSuspensao = new DateTime(1901, 1, 1, 0, 0, 0);
                    }
                    _context.Attach(_oferta).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                        MENSAGEM = $"O STATUS DA OFERTA <b style='color:darkgreen;'>{_oferta.Titulo}</b> FOI ALTERADO PARA <b style='color:purple;'>{PROC__RetornaStatusLiteralOferta(STATUS_OFERTA)}</b>",
                        ACAO = $"ALTEROU",
                        DTHR = DateTime.Now,
                        IP = ENDERECO_IP,
                        STATUS = PROC__RetornaStatusLiteralOferta(STATUS_OFERTA),
                        TIPO = "STATUS DA OFERTA",
                        UsuarioAppId = _usu.Id,
                        VALOR = Convert.ToDouble(_oferta.Valor),
                        UsuarioAppCriadorId = _usu.Id
                    }, _context);

                    retorno.Status = "ok";
                    retorno.Mensagem = "Processos efetuados com sucesso";
                }
            }
            catch (Exception err)
            {
                retorno.Status = "erro";
                retorno.Mensagem = $"###\n\r ERRO: \n\r{(User.IsInRole("SIS") ? err.StackTrace : err.Message)}\n\r ###";
            }

            return retorno;
        }
        [HttpGet]
        [Authorize(Roles = "SIS")]
        public async Task<object> AlterStatusOferta(int codigo, string tp)
        {
            if (codigo <= 0 || string.IsNullOrEmpty(tp))
                return new { mens = "Erro ao alterar o status da Oferta." };

            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            return await PROC__AlteraStatusOferta(_ips.FirstOrDefault(), codigo, tp);
        }







        [HttpGet]
        [Authorize]
        public async Task<object> Revogar(int codigo)
        {
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            if (codigo <= 0)
                return new { mens = "Erro ao revogar o Lançamento." };

            // USUÁRIO LOGADO
            var _usu = _context.Users
                .Where(x => x.UserName == User.Identity.Name)
                .FirstOrDefault();

            try
            {
                //-------------------
                // PEGO O LANCAMENTO
                //-------------------
                var _lancamento =
                    _context.INVEST_Lancamentos
                    .Include(x => x.BlocoProjInvestimentos)
                    .Include(x => x.BlocoProjInvestimentos.Construtora)
                    .Include(x => x.UsuarioApp)
                    .Where(x => x.Id == codigo)
                    .FirstOrDefault();

                if (_lancamento != null)
                {
                    //------------------------------
                    // VALIDAÇÕES SIMPLES
                    //------------------------------
                    if (_lancamento.Status != "A")
                        return new { status = "erro", mens = "Este lançamento não pode ser REVOGADO. Status '" + VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamento.Status) + "'." };

                    //------------------------------

                    if (_lancamento.BlocoProjInvestimentos.Status == "S")
                    {
                        if (User.IsInRole("SIS") || _usu.Id == _lancamento.UsuarioAppId)
                        {
                            _lancamento.Status = "R";
                            _context.Attach(_lancamento).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                                MENSAGEM = $"O STATUS DO LANÇAMENTO DE NÚMERO <b>{_lancamento.Id}</b> NO VALOR DE <b>{_lancamento.Valor.ToString("C2")}</b>, PERTENCENTE A OFERTA <b>{_lancamento.BlocoProjInvestimentos.Titulo}</b> FOI ALTERADO PARA <b style='color:red;'>{VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamento.Status)}</b><br>Para maiores detalhes <a href='/BlocosProjInvestValor'>clique aqui</a>",
                                ACAO = $"REVOGOU",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamento.Status),
                                TIPO = "STATUS DE LANÇAMENTO",
                                UsuarioAppId = _lancamento.UsuarioAppId,
                                VALOR = _lancamento.Valor,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);

                            //--------------------------------
                            // APLICACAO PADRAO
                            //--------------------------------
                            var _appPadrao =
                                _context.AppConfiguracoes_Aplicativo
                                .FirstOrDefault();

                            string _textoEmail = $"Prezado {_lancamento.UsuarioApp.Nome} <br>";
                            _textoEmail += $"Você solicitou uma <b>REVOGAÇÃO</b> de um investimento na oferta <b>{_lancamento.BlocoProjInvestimentos.Titulo}</b> no valor de <b>{_lancamento.Valor.ToString("C2")}</b> no dia <b>{DateTime.Now}</b>. <br>";
                            _textoEmail += $"Informamos que estamos trabalhando em sua solicitação. <br><br>";
                            _textoEmail += $"Atenciosamente, <br>";
                            _textoEmail += $"<b>Equipe House2invest</b> <br>";
                            // instanciar objeto email
                            var _objemail = new ObjetoEmailEnvio()
                            {
                                ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                                COPIA = _appPadrao.mailToAdd,
                                mailFrom = _appPadrao.mailFrom,
                                MENSAGEM = _textoEmail,
                                PARA = _lancamento.UsuarioApp.Email,
                                smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                                smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                                smtpEnableSsl = _appPadrao.smtpEnableSsl,
                                smtpHost = _appPadrao.smtpHost,
                                smtpPort = _appPadrao.smtpPort,
                                smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                            };
                            var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                                MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_lancamento.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                                ACAO = $"ENVIOU EMAIL",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = PROC__RetornaStatusLiteralLancamento(_lancamento.Status),
                                TIPO = "NOTIFICAÇÃO",
                                UsuarioAppId = _lancamento.UsuarioAppId,
                                VALOR = _lancamento.Valor,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);

                            //------------------------------------------------
                            // CRIO A TRANSFERENCIA
                            //------------------------------------------------
                            var _datalimite = DateTime.Now.AddDays(5);
                            var _novatransf = new Transferencia()
                            {
                                IdIncorporadora = _lancamento.BlocoProjInvestimentos.ConstrutoraId,
                                BlocoProjInvestimentoId = _lancamento.BlocoProjInvestimentosId,
                                IdUsu = _lancamento.UsuarioAppId,
                                URLComprovante = "",
                                Valor = _lancamento.Valor,
                                DataLimite = _datalimite
                            };

                            //----------------------------
                            // GRAVO A NOVA TRANSFERENCIA
                            //----------------------------
                            _context1.Tranferencias.Add(_novatransf);
                            await _context1.SaveChangesAsync();

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-info-circle text-primary'></i>",
                                MENSAGEM = $"TRANSFERÊNCIA DE <b>{_novatransf.Valor.ToString("C2")}</b> CRIADA PARA <b>{_lancamento.UsuarioApp.Email}</b>. ATENÇÃO!!!!! A DATA LIMITE PARA TRANSFERÊNCIA DESSE VALOR É DE <b>{_datalimite.ToShortDateString()}</b><br> <div>    <a href='https://calendar.google.com/calendar/r/eventedit?dates={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}/{_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&text=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&details=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{_lancamento.UsuarioApp.Financeiro_Banco_Ag}+CC:+{_lancamento.UsuarioApp.Financeiro_Banco_CC}+Banco:+{_lancamento.UsuarioApp.Financeiro_Banco_Nome}+do+investidor:+{_lancamento.UsuarioApp.Nome}+{_lancamento.UsuarioApp.Sobrenome}+com+email+{_lancamento.UsuarioApp.Email}+devido+ao+cancelamento+da+oferta:+{_lancamento.BlocoProjInvestimentos.Titulo}&sf=true' class='btn btn-sm bg-red' target='_blank' title='Criar lembrete no Google Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-google'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://calendar.yahoo.com/?v=60&st={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&et={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&title=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&in_loc=House2Invest&desc=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{_lancamento.UsuarioApp.Financeiro_Banco_Ag}+CC:+{_lancamento.UsuarioApp.Financeiro_Banco_CC}+Banco:+{_lancamento.UsuarioApp.Financeiro_Banco_Nome}+do+investidor:+{_lancamento.UsuarioApp.Nome}+{_lancamento.UsuarioApp.Sobrenome}+com+email+{_lancamento.UsuarioApp.Email}+devido+ao+cancelamento+da+oferta:+{_lancamento.BlocoProjInvestimentos.Titulo}' class='btn btn-sm bg-violet' target='_blank' title='Criar lembrete no Yahoo Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-yahoo'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://outlook.live.com/owa/?path=/calendar/action/compose&rru=addevent&startdt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&enddt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&subject=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&body=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{_lancamento.UsuarioApp.Financeiro_Banco_Ag}+CC:+{_lancamento.UsuarioApp.Financeiro_Banco_CC}+Banco:+{_lancamento.UsuarioApp.Financeiro_Banco_Nome}+do+investidor:+{_lancamento.UsuarioApp.Nome}+{_lancamento.UsuarioApp.Sobrenome}+com+email+{_lancamento.UsuarioApp.Email}+devido+ao+cancelamento+da+oferta:+{_lancamento.BlocoProjInvestimentos.Titulo}' class='btn btn-sm bg-blue' target='_blank' title='Criar lembrete no Microsoft Outlook' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-windows'></i> <i class='far fa-calendar-plus'></i></a>    </div>",
                                ACAO = $"CRIOU",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = "PENDENTE",
                                TIPO = "TRANSFERÊNCIAS",
                                UsuarioAppId = _novatransf.IdUsu,
                                VALOR = _lancamento.Valor,
                                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                            }, _context);

                            _textoEmail = $"Prezado {_lancamento.UsuarioApp.Nome} <br>";
                            _textoEmail += $"Criamos um lançamento de transferência (Um crédito) no valor de <b>{_lancamento.Valor.ToString("C2")}</b> referente a <b>REVOGAÇÃO</b> de um investimento na oferta <b>{_lancamento.BlocoProjInvestimentos.Titulo}</b> solicitado dia <b>{DateTime.Now}</b>. <br><br>";
                            //_textoEmail += $"Informamos que estamos trabalhando em sua solicitação. <br><br>";
                            _textoEmail += $"Atenciosamente, <br>";
                            _textoEmail += $"<b>Equipe House2invest</b> <br>";
                            // instanciar objeto email
                            _objemail = new ObjetoEmailEnvio()
                            {
                                ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                                COPIA = _appPadrao.mailToAdd,
                                mailFrom = _appPadrao.mailFrom,
                                MENSAGEM = _textoEmail,
                                PARA = _lancamento.UsuarioApp.Email,
                                smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                                smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                                smtpEnableSsl = _appPadrao.smtpEnableSsl,
                                smtpHost = _appPadrao.smtpHost,
                                smtpPort = _appPadrao.smtpPort,
                                smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                            };
                            _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                                MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_lancamento.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                                ACAO = $"ENVIOU EMAIL",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = PROC__RetornaStatusLiteralLancamento(_lancamento.Status),
                                TIPO = "NOTIFICAÇÃO",
                                UsuarioAppId = _lancamento.UsuarioAppId,
                                VALOR = _lancamento.Valor,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);
                        }
                        else
                        {
                            return new { status = "erro", mens = "Este lançamento não pode ser REVOGADO. ACESSO NEGADO!!!!" };
                        }
                    }
                    else
                    {
                        return new { status = "erro", mens = "Este lançamento não pode ser REVOGADO. A oferta não está SUSPENSA." };
                    }
                }


                return new { status = "ok", mens = "Lançamento REVOGADO com sucesso." };

            }
            catch (System.Exception err)
            {
                var _erro = err;
                return new { status = "erro", mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." };
            }


            //if (codigo <= 0)
            //    return new { mens = "Erro ao revogar o Lançamento." };

            //try
            //{
            //    //-------------------
            //    // PEGO A OFERTA
            //    //-------------------
            //    var _lancamento =
            //        _context.INVEST_Lancamentos
            //        .Include(x => x.BlocoProjInvestimentos)
            //        .Include(x => x.BlocoProjInvestimentos.Construtora)
            //        .Include(x => x.UsuarioApp)
            //        .Where(x => x.Id == codigo)
            //        .FirstOrDefault();

            //    if (_lancamento != null)
            //    {
            //        //------------------------------
            //        // VALIDAÇÕES SIMPLES
            //        //------------------------------
            //        if (_lancamento.Status != "A")
            //            return new { status = "erro", mens = "Este lançamento não pode ser REVOGADO. Status '" + _lancamento.Status + "'." };

            //        //------------------------------

            //        _lancamento.Status = "R";
            //        _context.Attach(_lancamento).State = EntityState.Modified;
            //        await _context.SaveChangesAsync();
            //    }

            //    //--------------------------------
            //    // APLICACAO PADRAO
            //    //--------------------------------
            //    var _configAplicacoes =
            //        _context.AppConfiguracoes_Aplicativo
            //        .FirstOrDefault();

            //    //------------------------------------------------
            //    // VERIFICO NOVAMENTE SE CHEGOU AO TOTAL DA OFERTA
            //    //------------------------------------------------
            //    var _datalimite = DateTime.Now.AddDays(5);


            //    var _novatransf = new Transferencia()
            //    {
            //        IdIncorporadora = _lancamento.BlocoProjInvestimentos.ConstrutoraId,
            //        BlocoProjInvestimentoId = _lancamento.BlocoProjInvestimentosId,
            //        IdUsu = _lancamento.UsuarioAppId,
            //        URLComprovante = "",
            //        Valor = _lancamento.Valor,
            //        DataLimite = _datalimite
            //    };

            //    //-----------
            //    // USUARIOS
            //    //-----------
            //    _context1.Tranferencias.Add(_novatransf);
            //    await _context1.SaveChangesAsync();

            //    return new { status = "ok", mens = "Lançamento REVOGADO com sucesso." };

            //}
            //catch (System.Exception err)
            //{
            //    var _erro = err;
            //    return new { status = "erro", mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." };
            //}
        }
        [HttpGet]
        [Authorize]
        public async Task<object> CancelarLancamento(int codigo)
        {
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            if (codigo <= 0)
                return new { mens = "Erro ao cancelar o Lançamento." };

            // USUÁRIO LOGADO
            var _usu = _context.Users
                .Where(x => x.UserName == User.Identity.Name)
                .FirstOrDefault();

            try
            {
                //-------------------
                // PEGO O LANCAMENTO
                //-------------------
                var _lancamento =
                    _context.INVEST_Lancamentos
                    .Include(x => x.BlocoProjInvestimentos)
                    .Include(x => x.BlocoProjInvestimentos.Construtora)
                    .Include(x => x.UsuarioApp)
                    .Where(x => x.Id == codigo)
                    .FirstOrDefault();

                if (_lancamento != null)
                {
                    //------------------------------
                    // VALIDAÇÕES SIMPLES
                    //------------------------------
                    if (_lancamento.Status != "A")
                        return new { status = "erro", mens = "Este lançamento não pode ser CANCELADO. Status '" + VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamento.Status) + "'." };

                    //------------------------------

                    if (_lancamento.DataLimiteCancelamento > DateTime.Now)
                    {
                        if (User.IsInRole("SIS") || _usu.Id == _lancamento.UsuarioAppId)
                        {
                            _lancamento.Status = "C";
                            _context.Attach(_lancamento).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                                MENSAGEM = $"O STATUS DO LANÇAMENTO DE NÚMERO <b>{_lancamento.Id}</b> NO VALOR DE <b>{_lancamento.Valor.ToString("C2")}</b>, PERTENCENTE A OFERTA <b>{_lancamento.BlocoProjInvestimentos.Titulo}</b> FOI ALTERADO PARA <b style='color:red;'>{VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamento.Status)}</b><br>Para maiores detalhes <a href='/BlocosProjInvestValor'>clique aqui</a>",
                                ACAO = $"CANCELOU",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_lancamento.Status),
                                TIPO = "STATUS DE LANÇAMENTO",
                                UsuarioAppId = _lancamento.UsuarioAppId,
                                VALOR = _lancamento.Valor,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);

                            //--------------------------------
                            // APLICACAO PADRAO
                            //--------------------------------
                            var _appPadrao =
                                _context.AppConfiguracoes_Aplicativo
                                .FirstOrDefault();

                            string _textoEmail = $"Prezado {_lancamento.UsuarioApp.Nome} <br>";
                            _textoEmail += $"Você solicitou o <b>CANCELAMENTO</b> de um investimento na oferta <b>{_lancamento.BlocoProjInvestimentos.Titulo}</b> no valor de <b>{_lancamento.Valor.ToString("C2")}</b> no dia <b>{DateTime.Now}</b>. <br>";
                            _textoEmail += $"Informamos que estamos trabalhando em sua solicitação. <br><br>";
                            _textoEmail += $"Atenciosamente, <br>";
                            _textoEmail += $"<b>Equipe House2invest</b> <br>";
                            // instanciar objeto email
                            var _objemail = new ObjetoEmailEnvio()
                            {
                                ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                                COPIA = _appPadrao.mailToAdd,
                                mailFrom = _appPadrao.mailFrom,
                                MENSAGEM = _textoEmail,
                                PARA = _lancamento.UsuarioApp.Email,
                                smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                                smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                                smtpEnableSsl = _appPadrao.smtpEnableSsl,
                                smtpHost = _appPadrao.smtpHost,
                                smtpPort = _appPadrao.smtpPort,
                                smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                            };
                            var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                                MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_lancamento.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                                ACAO = $"ENVIOU EMAIL",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = PROC__RetornaStatusLiteralLancamento(_lancamento.Status),
                                TIPO = "NOTIFICAÇÃO",
                                UsuarioAppId = _lancamento.UsuarioAppId,
                                VALOR = _lancamento.Valor,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);

                            //------------------------------------------------
                            // CRIO A TRANSFERENCIA
                            //------------------------------------------------
                            var _datalimite = DateTime.Now.AddDays(5);
                            var _novatransf = new Transferencia()
                            {
                                IdIncorporadora = _lancamento.BlocoProjInvestimentos.ConstrutoraId,
                                BlocoProjInvestimentoId = _lancamento.BlocoProjInvestimentosId,
                                IdUsu = _lancamento.UsuarioAppId,
                                URLComprovante = "",
                                Valor = _lancamento.Valor,
                                DataLimite = _datalimite
                            };

                            //----------------------------
                            // GRAVO A NOVA TRANSFERENCIA
                            //----------------------------
                            _context1.Tranferencias.Add(_novatransf);
                            await _context1.SaveChangesAsync();

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-info-circle text-primary'></i>",
                                MENSAGEM = $"TRANSFERÊNCIA DE <b>{_novatransf.Valor.ToString("C2")}</b> CRIADA PARA <b>{_lancamento.UsuarioApp.Email}</b>. ATENÇÃO!!!!! A DATA LIMITE PARA TRANSFERÊNCIA DESSE VALOR É DE <b>{_datalimite.ToShortDateString()}</b><br> <div>    <a href='https://calendar.google.com/calendar/r/eventedit?dates={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}/{_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&text=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&details=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{_lancamento.UsuarioApp.Financeiro_Banco_Ag}+CC:+{_lancamento.UsuarioApp.Financeiro_Banco_CC}+Banco:+{_lancamento.UsuarioApp.Financeiro_Banco_Nome}+do+investidor:+{_lancamento.UsuarioApp.Nome}+{_lancamento.UsuarioApp.Sobrenome}+com+email+{_lancamento.UsuarioApp.Email}+devido+ao+cancelamento+da+oferta:+{_lancamento.BlocoProjInvestimentos.Titulo}&sf=true' class='btn btn-sm bg-red' target='_blank' title='Criar lembrete no Google Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-google'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://calendar.yahoo.com/?v=60&st={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&et={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&title=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&in_loc=House2Invest&desc=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{_lancamento.UsuarioApp.Financeiro_Banco_Ag}+CC:+{_lancamento.UsuarioApp.Financeiro_Banco_CC}+Banco:+{_lancamento.UsuarioApp.Financeiro_Banco_Nome}+do+investidor:+{_lancamento.UsuarioApp.Nome}+{_lancamento.UsuarioApp.Sobrenome}+com+email+{_lancamento.UsuarioApp.Email}+devido+ao+cancelamento+da+oferta:+{_lancamento.BlocoProjInvestimentos.Titulo}' class='btn btn-sm bg-violet' target='_blank' title='Criar lembrete no Yahoo Calendar' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-yahoo'></i> <i class='far fa-calendar-plus'></i></a>    <a href='https://outlook.live.com/owa/?path=/calendar/action/compose&rru=addevent&startdt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.Day.ToString("D2")}&enddt={_datalimite.Year}{_datalimite.Month.ToString("D2")}{_datalimite.AddDays(1).Day.ToString("D2")}&subject=[HOUSE2INVEST]+TRANSFERÊNCIA+OFERTA+CANCELADA&location=House2Invest&body=Devem+ser+transferidos+até+o+fim+do+dia+de+hoje+,+{_novatransf.Valor.ToString("C2")}+para+a+conta:+Ag.:+{_lancamento.UsuarioApp.Financeiro_Banco_Ag}+CC:+{_lancamento.UsuarioApp.Financeiro_Banco_CC}+Banco:+{_lancamento.UsuarioApp.Financeiro_Banco_Nome}+do+investidor:+{_lancamento.UsuarioApp.Nome}+{_lancamento.UsuarioApp.Sobrenome}+com+email+{_lancamento.UsuarioApp.Email}+devido+ao+cancelamento+da+oferta:+{_lancamento.BlocoProjInvestimentos.Titulo}' class='btn btn-sm bg-blue' target='_blank' title='Criar lembrete no Microsoft Outlook' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fab fa-windows'></i> <i class='far fa-calendar-plus'></i></a>    </div>",
                                ACAO = $"CRIOU",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = "PENDENTE",
                                TIPO = "TRANSFERÊNCIAS",
                                UsuarioAppId = _novatransf.IdUsu,
                                VALOR = _lancamento.Valor,
                                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                            }, _context);

                            _textoEmail = $"Prezado {_lancamento.UsuarioApp.Nome} <br>";
                            _textoEmail += $"Criamos um lançamento de transferência (Um crédito) no valor de <b>{_lancamento.Valor.ToString("C2")}</b> referente ao <b>CANCELAMENTO</b> de um investimento na oferta <b>{_lancamento.BlocoProjInvestimentos.Titulo}</b> solicitado dia <b>{DateTime.Now}</b>. <br>";
                            _textoEmail += $"Informamos que estamos trabalhando em sua solicitação. <br><br>";
                            _textoEmail += $"Atenciosamente, <br>";
                            _textoEmail += $"<b>Equipe House2invest</b> <br>";
                            // instanciar objeto email
                            _objemail = new ObjetoEmailEnvio()
                            {
                                ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                                COPIA = _appPadrao.mailToAdd,
                                mailFrom = _appPadrao.mailFrom,
                                MENSAGEM = _textoEmail,
                                PARA = _lancamento.UsuarioApp.Email,
                                smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                                smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                                smtpEnableSsl = _appPadrao.smtpEnableSsl,
                                smtpHost = _appPadrao.smtpHost,
                                smtpPort = _appPadrao.smtpPort,
                                smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                            };
                            _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                                MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_lancamento.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                                ACAO = $"ENVIOU EMAIL",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = PROC__RetornaStatusLiteralLancamento(_lancamento.Status),
                                TIPO = "NOTIFICAÇÃO",
                                UsuarioAppId = _lancamento.UsuarioAppId,
                                VALOR = _lancamento.Valor,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);
                        }
                        else
                        {
                            return new { status = "erro", mens = "Este lançamento não pode ser CANCELADO. ACESSO NEGADO!!!!" };
                        }
                    }
                    else
                    {
                        return new { status = "erro", mens = "Este lançamento não pode ser CANCELADO. A DATA LIMITE PARA O CANCELAMENTO é menor que a data de hoje." };
                    }
                }


                return new { status = "ok", mens = "Lançamento REVOGADO com sucesso." };

            }
            catch (System.Exception err)
            {
                var _erro = err;
                return new { status = "erro", mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." };
            }
        }
        [HttpGet]
        [Authorize]
        public async Task<object> ValidarReserva(int idoferta, string idusuario, string token)
        {
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            if (string.IsNullOrEmpty(idusuario) || string.IsNullOrEmpty(token) || idoferta <= 0)
                return new { status = "erro", mens = "Erro ao confirmar reserva. <br>Verifique se o token digitado corresponde ao do email enviado pela House2Invest no momento da reserva." };

            // USU DO LANCAMENTO
            var _usu = _context.Users.Where(x => x.Id == idusuario).FirstOrDefault();

            try
            {
                var _editarconfirmacao =
                    _context.InvestimentoConfirmacoes
                    .Include(x => x.UsuarioApps)
                    .Include(x => x.BlocoProjInvestimentos)
                    .Where(x => x.BlocoProjInvestimentoId == idoferta &&
                    x.UsuarioAppId == idusuario &&
                    x.Token == token && x.Confirmado == false)
                    .FirstOrDefault();

                if (_editarconfirmacao != null)
                {
                    _editarconfirmacao.Confirmado = true;
                    _context.Attach(_editarconfirmacao).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-wallet text-success'></i>",
                        MENSAGEM = $"O usuário <b>{_editarconfirmacao.UsuarioApps.Nome} {_editarconfirmacao.UsuarioApps.Sobrenome}</b> <b style='color:green;'>CONFIRMOU</b> a reserva de <b>{_editarconfirmacao.Valor.ToString("C2")}</b> na oferta <b>{_editarconfirmacao.BlocoProjInvestimentos.Titulo}</b>.",
                        ACAO = $"RESERVA",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = "CONFIRMADO",
                        TIPO = "INVESTIMENTOS",
                        UsuarioAppId = _editarconfirmacao.UsuarioAppId,
                        VALOR = _editarconfirmacao.Valor,
                        UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                    }, _context);

                    //--------------------------------
                    // APLICACAO PADRAO
                    //--------------------------------
                    var _configAplicacoes =
                        _context.AppConfiguracoes_Aplicativo
                        .FirstOrDefault();

                    //string _textoEmail = $"Olá {_usu.Nome}, <br>";
                    //_textoEmail += $"Recebemos a sua reserva no valor de {_novoLancamento.Valor.ToString("C2")}. <br>";
                    //_textoEmail += $"Para confirmá-la, insira o código de validação a seguir:<br>";
                    //_textoEmail += $"Atenciosamente, <br>";
                    //_textoEmail += $"<b>Equipe House2invest</b> <br>";

                    string _textoEmail = $"Olá!!!{Environment.NewLine}<br/>A sua reserva de {_editarconfirmacao.Valor.ToString("C2")} foi CONFIRMADA.";

                    // instanciar objeto email
                    var _objemail = new ObjetoEmailEnvio()
                    {
                        ASSUNTO = "[VALIDAÇÃO DO INVESTIMENTO] House2Invest",
                        COPIA = _configAplicacoes.mailToAdd,
                        mailFrom = _configAplicacoes.mailFrom,
                        MENSAGEM = _textoEmail,
                        //MENSAGEM = string.Format($"Olá!!!{Environment.NewLine}<br/>A sua reserva de {_editarconfirmacao.Valor.ToString("C2")} foi CONFIRMADA."),
                        PARA = _usu.Email,
                        smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                        smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                        smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                        smtpHost = _configAplicacoes.smtpHost,
                        smtpPort = _configAplicacoes.smtpPort,
                        smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                    };
                    var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                        MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_editarconfirmacao.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                        ACAO = $"ENVIOU EMAIL",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = "CONFIRMADO",
                        TIPO = "NOTIFICAÇÃO",
                        UsuarioAppId = _usu.Id,
                        VALOR = _editarconfirmacao.Valor,
                        UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                    }, _context);

                }
                else
                {
                    return new { status = "erro", mens = "Verifique com atenção o campo TOKEN. Ele está correto?" };
                }
            }
            catch (Exception err)
            {
                var erro = err;
                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                {
                    ICOMENS = "<i class='fas fa-bug text-danger'></i>",
                    MENSAGEM = $"{err.Message}<br><code>{err.StackTrace}</code>",
                    ACAO = $"ERRO",
                    DTHR = DateTime.Now,
                    IP = _ips.FirstOrDefault(),
                    STATUS = "ERRO INTERNO",
                    TIPO = "ACESSO A PLATAFORMA",
                    UsuarioAppId = _usu.Id,
                    VALOR = 0,
                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                }, _context);

                return new
                {
                    status = "erro",
                    mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação."
                };
            }

            return new { status = "ok", mens = "A reserva foi confirmada com sucesso" };
        }










        [HttpGet]
        [Authorize(Roles = "SIS")]
        public async Task<object> AcaoContaUsuario(string id, string tp, string acao = "UsuarioEmailConfirmado")
        {
            var _usu = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            if (string.IsNullOrEmpty(id))
                return new { mens = "ID igual a ZERO" };

            if (string.IsNullOrEmpty(tp))
                return new { mens = "Não identifiquei o VALOR do 'input check'" };

            try
            {
                var _registro =
                    _context.Users
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (_registro != null)
                {
                    if (acao == "UsuarioEmailConfirmado")
                    {
                        _registro.EmailConfirmed = tp.ToLower().Trim() == "on" ? true : false;

                        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                        {
                            ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                            MENSAGEM = $"O <b>VALOR</b> do campo <b>EMAIL CONFIRMADO</b> foi alterado para <b style='color:purple;'>{tp.ToUpper().Trim()}</b>",
                            ACAO = $"ALTEROU",
                            DTHR = DateTime.Now,
                            IP = _ips.FirstOrDefault(),
                            STATUS = tp.ToUpper().Trim(),
                            TIPO = "CONTA DE USUÁRIO",
                            UsuarioAppId = _registro.Id,
                            VALOR = 0,
                            UsuarioAppCriadorId = _usu.Id
                        }, _context);
                    }

                    if (acao == "UsuarioAcessoBloqueado")
                    {
                        if (tp.ToLower().Trim() == "on")
                            await _hubNotificacoes.Clients.All.SendAsync("ForceLogoff", $"{_registro.Id}", "");

                        _registro.Sistema_AcessoBloqueado = tp.ToLower().Trim() == "on" ? true : false;

                        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                        {
                            ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                            MENSAGEM = $"O <b>VALOR</b> do campo <b>BLOQUEADO</b> foi alterado para <b style='color:purple;'>{tp.ToUpper().Trim()}</b>",
                            ACAO = $"ALTEROU",
                            DTHR = DateTime.Now,
                            IP = _ips.FirstOrDefault(),
                            STATUS = tp.ToUpper().Trim(),
                            TIPO = "CONTA DE USUÁRIO",
                            UsuarioAppId = _registro.Id,
                            VALOR = 0,
                            UsuarioAppCriadorId = _usu.Id
                        }, _context);
                    }

                    if (acao == "UsuarioLockout")
                    {
                        _registro.LockoutEnabled = tp.ToLower().Trim() == "on" ? true : false;
                        _registro.AccessFailedCount = tp.ToLower().Trim() != "on" ? _registro.AccessFailedCount = 0 : _registro.AccessFailedCount;

                        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                        {
                            ICOMENS = "<i class='fas fa-exclamation-circle text-warning'></i>",
                            MENSAGEM = $"O <b>VALOR</b> do campo <b>LOCKOUT</b> foi alterado para <b style='color:purple;'>{tp.ToUpper().Trim()}</b>",
                            ACAO = $"ALTEROU",
                            DTHR = DateTime.Now,
                            IP = _ips.FirstOrDefault(),
                            STATUS = tp.ToUpper().Trim(),
                            TIPO = "CONTA DE USUÁRIO",
                            UsuarioAppId = _registro.Id,
                            VALOR = 0,
                            UsuarioAppCriadorId = _usu.Id
                        }, _context);
                    }

                    if (acao == "DocNecConfirmReserva")
                    {
                        // instanciar objeto email
                        var _configAplicacoes =
                            _context.AppConfiguracoes_Aplicativo
                            .FirstOrDefault();

                        string _corpomensTED = "";
                        var _linkperfil = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host.ToString();

                        _corpomensTED += "Olá, " + _registro.Nome + " " + _registro.Sobrenome + ",<br>";
                        _corpomensTED += "Informamos que sua reserva foi registrada. Para confirmar seu investimento, é necessário realizar uma TED (Transferência Eletrônica Disponível) para a seguinte conta bancária:<br>";
                        _corpomensTED += "237-Banco Bradesco S.A.<br>";
                        _corpomensTED += "AG: 1797-3CC:17800-4<br>";
                        _corpomensTED += "FAVORECIDO:[          ] LTDA<br>";
                        _corpomensTED += "CNPJ: [      ]<br>";
                        _corpomensTED += "VALOR: R$ [       ]<br><br>";

                        _corpomensTED += "OBSERVAÇÃO: Por determinação da CVM, NÃO É PERMITIDO o depósitos em 'caixa' ou caixa eletrônico, nem na modalidade saque/depósito.<br>";
                        _corpomensTED += "A CVM exige o depósito em nome de um serviço terceirizado de arranjo de pagamentos. Por isso, a transferência é realizada para a [RAZÃO SOCIAL FAVORECIDO], que liberará o montante para a incorporadora após a finalização da captação.<br>";
                        _corpomensTED += "Alertamos que, por exigência da CVM, sua reserva só poderá ser aprovada após envio e aprovação de uma foto frente e verso de um documento válido (RG/CNH), acompanhada da selfie do investidor responsável pela reserva nas seguintes condições:<br>";
                        _corpomensTED += "O investidor deverá segurar o documento ao lado do rosto e registrar a  imagem.<br>";
                        _corpomensTED += "Esclarecemos que o procedimento de envio de foto com documento deverá ser realizado na adesão da primeira oferta, sendo dispensado o envio na adesão do investidor em ofertas futuras. Caso contrário, basta clicar <a href='" + _linkperfil + "/Identity/Account/Manage'>aqui</a>.<br>";
                        _corpomensTED += "Após a realização da TED , envio da Declaração de Elegibilidade de Investidor assinada e aprovação da selfie com documento, você receberá em até 1 dia útil a confirmação do investimento no seu e-mail e poderá acompanhar o status do investimento pelo seu painel na plataforma da HOUSE2INVEST.<br>";

                        _corpomensTED += "<a href='" + _linkperfil + "/BlocosProjInvestValor'>ENVIO TED E DECLARAÇÃO</a><br><br>";

                        _corpomensTED += "Assim que a captação for encerrada, seu título será disponibilizado no seu painel em até 5 (cinco) dias úteis.<br>";
                        _corpomensTED += "Ficamos à disposição para esclarecer as dúvidas nos canais de atendimento.<br><br><br>";
                        _corpomensTED += "Equipe House2Invvest<br><br>";
                        _corpomensTED += "<i>Entenda o prazo: As cotas de investimento do projeto são limitadas. Por isso, para garantir sua participação, você precisa realizar a TED o mais breve possível, antes que as cotas sejam esgotadas. Geralmente, realizando a TED dentro de um dia útil, sua participação é garantida. Após esse prazo, sua reserva perderá a preferência e dependerá da disponibilidade das cotas para ser efetivada.</i>";
                        var _objemail = new ObjetoEmailEnvio()
                        {
                            ASSUNTO = "[DOCUMENTAÇÃO NECESSÁRIA] House2Invest",
                            COPIA = _configAplicacoes.mailToAdd,
                            mailFrom = _configAplicacoes.mailFrom,
                            MENSAGEM = _corpomensTED,
                            PARA = _registro.Email,
                            smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                            smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                            smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                            smtpHost = _configAplicacoes.smtpHost,
                            smtpPort = _configAplicacoes.smtpPort,
                            smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                        };
                        var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                        {
                            ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                            MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _corpomensTED + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog(0);' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                            ACAO = $"ENVIOU EMAIL",
                            DTHR = DateTime.Now,
                            IP = _ips.FirstOrDefault(),
                            STATUS = "AGUARDANDO",
                            TIPO = "INSTRUÇÕES PARA O TED",
                            UsuarioAppId = _registro.Id,
                            VALOR = 0,
                            UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                        }, _context);

                        return new { mens = "ok" };
                    }
                }

                _context.Attach(_registro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (System.Exception) { return new { mens = "Talvez o registro não exista mais, ou, está associado a outro(s) registro(s). Não foi possível concluir sua solicitação." }; }

            //await _hubContext.Clients.All.SendAsync("Notify", $"Página carregada");

            return new { mens = "ok" };
        }
        [HttpGet]
        [Authorize]
        public async Task<object> ForcaLogoff(string id, string sl, string st, string rota)
        {
            try
            {
                var _usu = await _context.Users
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (_usu.UserName == User.Identity.Name)
                {
                    //if (!User.IsInRole("SIS"))
                    //{
                    await _signInManager.SignOutAsync();
                    var _novologacaousu = new LOGACOESUSU()
                    {
                        scrollLeft = sl,
                        scrollTop = st,
                        UsuarioAppId = _usu.Id,
                        Url = rota
                    };
                    _context.LOGACOESUSUs.Add(_novologacaousu);
                    await _context.SaveChangesAsync();
                    //await _hubNotificacoes.Clients.All.SendAsync("forcelogoff", _usu.Id, "Logoff");
                    //}
                    //else
                    //{
                    //    return new
                    //    {
                    //        status = "BLOQUEADO",
                    //        mens = "CONTA ADM"
                    //    };
                    //}

                    return new
                    {
                        status = "ok",
                        mens = "LogOff forçado efetuado com sucesso"
                    };
                }
            }
            catch (Exception) { }

            return new
            {
                status = "erro",
                mens = "Não foi possível forçar LogOff. ERRO DESCONHECIDO"
            };
        }
        [HttpPost]
        [Authorize]
        //[Authorize(Roles = "SIS")]
        public async Task EnviarMensagem()
        {
            try
            {
                var _dadosform = Request.Form;

                var _de = _dadosform["de"];
                var _para = _dadosform["para"];
                var _paracnxid = _dadosform["cnxpara"];
                var _decnxid = _dadosform["cnxde"];
                var _mens = _dadosform["mens"];

                //var _de = _dadosform["de"];
                //COM VISITANTE
                //var _de = User.Identity.IsAuthenticated ? User.Identity.Name.Replace("@", "").Replace(".", "") : "visitante";
                //var _de = User.Identity.Name.Replace("@", "").Replace(".", "");
                //var _email_de = _dadosform["emailde"];
                //var _avatar_de = _dadosform["avatarde"];
                //var _decnxid = _dadosform["cnxde"];
                //var _canal = _dadosform["canal"];

                //------------
                // SIGNALR
                //------------
                //await _hubNotificacoes.Clients.Client(_canal).SendAsync("enviarmens", _de, _para, _mens);
                //await _hubNotificacoes
                //    .Clients
                //    .Client(_paracnxid)
                //    .SendAsync("enviarmens", _de, _para, _mens);

                //------------
                // SALVA TUDO
                //------------
                var _pegaCNXID =
                    _context.tblHubClientes
                    .Where(x => x.Email == User.Identity.Name)
                    .OrderByDescending(x => x.DTHR)
                    .FirstOrDefault();

                if (_pegaCNXID != null)
                {
                    if (_pegaCNXID.Status == "ENTROU")
                        _paracnxid = _pegaCNXID.CnxId;
                }

                // LOG NO BANCO
                var _novamens = new tblHubConversa()
                {
                    De = _de,
                    //DeCnxId = _decnxid,
                    DeCnxId = "",
                    Para = _para,
                    ParaCnxId = _paracnxid,
                    Mensagem = _mens,
                    Lida = false
                };
                _context.tblHubConversas.Add(_novamens);
                await _context.SaveChangesAsync();

                await _hubNotificacoes
                    .Clients.All
                    .SendAsync("enviarmens", _de, _para, _mens);
            }
            catch (System.Exception)
            {
                //return new { mens = "Não foi possível concluir sua solicitação." };
            }

            //await _hubContext.Clients.All.SendAsync("Notify", $"Página carregada");
            //return new { mens = "ok" };
        }
        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        //public async Task<object> RetornaListaUsuChatSalaVIP(string chave)
        public async Task<object> RetornaListaUsuChatSalaVIP(string b = "", int hist = 0)
        {
            // RETORNO
            var _lista = new List<object>();

            // USUARIO LOGADO
            var _usu = _context.Users
                .Where(x => x.Email.ToLower().Trim() == User.Identity.Name.ToLower().Trim())
                .FirstOrDefault();

            // LISTA DE INVESTIDORES
            var _listaInvestidores = await _context
                .Users
                //.Where(x => x.Sistema_FuncaoUsuario == "USUARIO")
                .Where(x => x.EmailConfirmed)
                .Where(x => !x.Sistema_AcessoBloqueado)
                .Where(x => x.Id != _usu.Id)
                .ToListAsync();

            //var _dados = await
            //    _context
            //    .tblUsuSalaVIPs
            //    .Include(x => x.UsuarioApp)
            //    .Where(x => x.UsuarioAppId != _usu.Id)
            //    .OrderByDescending(x => x.DTHR)
            //    .ToListAsync();

            // EXISTE BUSCA?
            if (!string.IsNullOrEmpty(b))
            {
                _listaInvestidores =
                    _listaInvestidores
                    .Where(x => x.Email.ToLower().Trim().Contains(b.ToLower().Trim()))
                    .ToList();
            }

            //// EH HISTORICO?
            //if (hist == 1)
            //{
            //    var _dadoshist = await
            //        _context
            //        .tblHubConversas
            //        .Where(x => x.Para == _usu.Id)
            //        .OrderByDescending(x => x.DTHR)
            //        .ToListAsync();

            //    foreach (var item in _dadoshist)
            //    {
            //        var _usuario =
            //            _context
            //            .Users
            //            .Where(x => x.Id == item.De)
            //            .FirstOrDefault();

            //        _lista.Add(new
            //        {
            //            id = item.Id,
            //            cnxid = item.DeCnxId,
            //            dthr = item.DTHR,
            //            idusu = _usuario.Id,
            //            avatar = _usuario.AvatarUsuario,
            //            nome = _usuario.Nome,
            //            email = _usuario.Email,
            //            sobrenome = _usuario.Sobrenome,
            //            trabalho = _usuario.Trabalho_Empresa,
            //            cargo = _usuario.Trabalho_Cargo
            //        });
            //    }
            //}
            //else
            //{

            foreach (var item in _listaInvestidores)
            {
                _lista.Add(new
                {
                    id = item.Id,
                    cnxid = "",
                    dthr = "",
                    idusu = item.Id,
                    avatar = item.AvatarUsuario,
                    nome = item.Nome,
                    email = item.Email,
                    sobrenome = item.Sobrenome,
                    trabalho = item.Trabalho_Empresa,
                    cargo = item.Trabalho_Cargo
                });
            }
            //}

            try
            {
                //await Clients
                //    .All
                //    .SendAsync("quemsoueu", Context.ConnectionId, idusu, _usu.Id, _usu.Nome + " " + _usu.Sobrenome, status);

                //await _hubNotificacoes
                //    .Clients
                //    .All
                //    .SendAsync("enviarmens", _de, _para, _mens);

                //var _idcnx = _context
                //    .tblUsuSalaVIPs
                //    .Include(x => x.UsuarioApp)
                //    .Where(x => x.UsuarioApp.Email == User.Identity.Name)
                //    .OrderByDescending(x => x.DTHR)
                //    .FirstOrDefault();

                //if (_idcnx != null)
                //{
                //    await _hubNotificacoes
                //        .Clients
                //        .All
                //        .SendAsync("quemsoueu", _idcnx.CnxId, _idcnx.UsuarioAppId, "", _usu.Nome + " " + _usu.Sobrenome, "");
                //}
            }
            catch (Exception) { }

            return new
            {
                dados = _lista
            };
        }
        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        public object RetornaListaUsuChatHist()
        {
            // RETORNO
            var _lista = new List<ConversaViewModel>();

            // USUARIO LOGADO
            var _usu = _context.Users
                .Where(x => x.UserName.ToLower().Trim() == User.Identity.Name.ToLower().Trim())
                .FirstOrDefault();

            // EH HISTORICO?
            //var _dadoshist = await
            //    _context
            //    .tblHubConversas
            //    .Where(x => x.De == _usu.Id)
            //    .OrderByDescending(x => x.DTHR)
            //    .ToListAsync();

            var _agrupadoENVIADO = _context
                .tblHubConversas
                .Where(x => x.De == _usu.Id)
                .GroupBy(e => new
                {
                    e.De,
                    e.DeCnxId,
                    e.Para,
                    e.DTHR,
                    e.Id,
                    e.Lida,
                    e.Mensagem,
                    e.ParaCnxId
                })
            .Select(g => g.First())
            //.OrderByDescending(x => x.DTHR)
            .Distinct(d => d.Para);

            var _agrupadoNAOLIDA = _context
                .tblHubConversas
                .Where(x => x.Para == _usu.Id)
                .GroupBy(e => new
                {
                    e.Para,
                    e.De,
                    e.DeCnxId,
                    e.DTHR,
                    e.Id,
                    e.Lida,
                    e.Mensagem,
                    e.ParaCnxId
                })
            .Select(g => g.First())
            //.OrderByDescending(x => x.DTHR)
            .Distinct(d => d.De);

            var _agrupado = new List<tblHubConversa>();
            _agrupado.AddRange(_agrupadoENVIADO);
            _agrupado.AddRange(_agrupadoNAOLIDA);

            _agrupado = _agrupado.OrderByDescending(x => x.DTHR).ToList();

            foreach (var item in _agrupado)
            {
                var _usuario = new UsuarioApp();

                if (item.De == _usu.Id)
                {
                    _usuario = _context.Users
                        .Where(x => x.Id == item.Para)
                        .FirstOrDefault();
                }
                else
                {
                    _usuario = _context.Users
                        .Where(x => x.Id == item.De)
                        .FirstOrDefault();
                }

                //_lista.Add(new
                //{
                //    id = item.Id,
                //    cnxid = item.DeCnxId,
                //    dthr = item.DTHR,
                //    idusu = _usuario.Id,
                //    avatar = _usuario.AvatarUsuario,
                //    nome = _usuario.Nome,
                //    email = _usuario.Email,
                //    sobrenome = _usuario.Sobrenome,
                //    trabalho = _usuario.Trabalho_Empresa,
                //    cargo = _usuario.Trabalho_Cargo
                //});

                _lista.Add(new ConversaViewModel()
                {
                    conv_id = item.Id,
                    conv_cnxid = item.ParaCnxId,
                    conv_dthr = item.DTHR,
                    Id = _usuario.Id,
                    AvatarUsuario = _usuario.AvatarUsuario,
                    Nome = _usuario.Nome,
                    Email = _usuario.Email,
                    Sobrenome = _usuario.Sobrenome,
                    Trabalho_Empresa = _usuario.Trabalho_Empresa,
                    Trabalho_Cargo = _usuario.Trabalho_Cargo
                });
            }

            _lista = _lista
                .GroupBy(e => new
                {
                    e.Id,
                    e.conv_id,
                    e.conv_cnxid,
                    e.conv_dthr,
                    e.AvatarUsuario,
                    e.Nome,
                    e.Email,
                    e.Sobrenome,
                    e.Trabalho_Empresa,
                    e.Trabalho_Cargo
                })
            .Select(g => g.First())
            .OrderByDescending(x => x.conv_dthr)
            .Distinct(d => d.Id)
            .ToList();

            return new
            {
                dados = _lista
            };
        }
        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        public async Task<object> RetornaListaUsuChatConversa(string de, string para)
        {
            // RETORNO
            var _lista = new List<object>();

            // LISTA DE CONVERSAS
            var _conversas_DE = await _context
                .tblHubConversas
                .Where(x => x.De == de && x.Para == para)
                .ToListAsync();

            var _conversas_PARA = await _context
                .tblHubConversas
                .Where(x => x.De == para && x.Para == de)
                .ToListAsync();

            var _conversas_MIX = new List<tblHubConversa>();
            _conversas_MIX.AddRange(_conversas_DE);
            _conversas_MIX.AddRange(_conversas_PARA);

            _conversas_MIX = _conversas_MIX.OrderBy(x => x.DTHR).ToList();

            //// USUARIO LOGADO
            //var _usu = _context.Users
            //    .Where(x => x.UserName.ToLower().Trim() == User.Identity.Name.ToLower().Trim())
            //    .FirstOrDefault();

            // EH HISTORICO?
            //var _dadoshist = await
            //    _context
            //    .tblHubConversas
            //    .Where(x => x.De == _usu.Id)
            //    .OrderByDescending(x => x.DTHR)
            //    .ToListAsync();

            //var _agrupado = _context
            //    .tblHubConversas
            //    .Where(x => x.De == _usu.Id)
            //    .GroupBy(e => new
            //    {
            //        e.De,
            //        e.DeCnxId,
            //        e.Para,
            //        e.DTHR,
            //        e.Id,
            //        e.Lida,
            //        e.Mensagem,
            //        e.ParaCnxId
            //    })
            //.Select(g => g.First())
            //.OrderByDescending(x => x.DTHR)
            //.Distinct(d => d.Para);

            foreach (var item in _conversas_MIX)
            {
                var _usuario_DE = _context.Users
                    .Where(x => x.Id == item.De)
                    .FirstOrDefault();

                var _usuario_PARA = _context.Users
                    .Where(x => x.Id == item.Para)
                    .FirstOrDefault();

                _lista.Add(new
                {
                    item.Id,
                    item.De,
                    nome_de = _usuario_DE.Nome + " " + _usuario_DE.Sobrenome,
                    dthr = item.DTHR.ToShortDateString() + " " + item.DTHR.ToShortTimeString(),
                    item.Para,
                    nome_para = _usuario_PARA.Nome + " " + _usuario_PARA.Sobrenome,
                    avatar_para = _usuario_PARA.AvatarUsuario,
                    item.Lida,
                    item.Mensagem
                });
            }

            if (_lista.Count > 0)
            {
                await _hubNotificacoes.Clients.All.SendAsync("exibehist");
            }

            return new
            {
                dados = _lista
            };
        }
        [HttpPost]
        [Authorize]
        public object EnviarMensagemForum()
        {
            try
            {
                var _dadosform = Request.Form;
                var _idbloc = _dadosform["idbloc"];
                var _comment = _dadosform["comment"];
                if (!string.IsNullOrEmpty(_comment))
                {
                    try
                    {
                        var _usu = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                        var _novocoment = _context.BlocoProjInvestimentoComentarios.Add(new BlocoProjInvestimentoComentario()
                        {
                            BlocoProjInvestimentoId = Convert.ToInt32(_idbloc),
                            Comentario = _comment,
                            UsuarioAppId = _usu.Id
                        });
                        _context.SaveChanges();

                        return new { mens = "ok" };
                    }
                    catch (System.Exception) { }
                }
            }
            catch (System.Exception) { }

            return new { mens = "Não foi possível concluir sua solicitação." };
            //await _hubContext.Clients.All.SendAsync("Notify", $"Página carregada");
            //return new { mens = "ok" };
        }
        [HttpGet]
        public JsonResult ExportarPDF(string url)
        {
            //url = $"{Request.Path.Value}{Request.QueryString.Value}";
            url = $"{Request.QueryString.Value}";
            url = url.Substring(5, url.Length - 5);
            var fileName = "DOC_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".html";
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string fullPath = Path.Combine(sWebRootFolder + "//Upload", fileName);
            //var memory = new MemoryStream();

            //var web = new HtmlAgilityPack.HtmlWeb();
            //var doc = web.Load(url);
            //var web = new HtmlAgilityPack.HtmlWeb();
            //web.PreRequest = delegate (HttpWebRequest webRequest)
            //{
            //    webRequest.Timeout = 60000;
            //    return true;
            //};
            //var doc = await web.LoadFromWebAsync(url);

            //-----------------------------------------------------------------------------
            //var _url = url;
            //70
            //var _indSHARPSurl = url.IndexOf("___");
            ////var _removeSHARPSurl = url.Substring(0, _indSHARPSurl);
            //var _novaurl = url.Substring(0, _indSHARPSurl);
            //var _removeSHARPSurl = url.Substring(_indSHARPSurl + 1, (url.Length - _indSHARPSurl) - 1).Replace("___", "");
            //_removeSHARPSurl = _removeSHARPSurl.Replace("_", "");
            //_novaurl = _novaurl + "&idconstru=" + _removeSHARPSurl;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 60000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream, Encoding.Default);
                }
                else
                {
                    //readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    readStream = new StreamReader(receiveStream, Encoding.UTF8);
                }
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            //-----------------------------------------------------------------------------

            //var _ObjConstrutora = _context.Construtoras
            //    .Where(x => x.Id == Convert.ToInt32(_removeSHARPSurl))
            //    .FirstOrDefault();
            //var data = "";
            FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();

            //if (url.ToLower().Trim().Contains("setoratuacaohist"))
            //{
            //    data = _ObjConstrutora.SetorAtuacaoHist;
            //}
            //if (url.ToLower().Trim().Contains("sociedadeadms"))
            //{
            //    data = _ObjConstrutora.SociedadeAdms;
            //}
            //if (url.ToLower().Trim().Contains("infoplanonegocios"))
            //{
            //    data = _ObjConstrutora.InfoPlanoNegocios;
            //}
            //if (url.ToLower().Trim().Contains("infovalormobofertado"))
            //{
            //    data = _ObjConstrutora.InfoValorMobOfertado;
            //}
            //if (url.ToLower().Trim().Contains("comunprestinfocontaposoferta"))
            //{
            //    data = _ObjConstrutora.ComunPrestInfoContAposOferta;
            //}
            //if (url.ToLower().Trim().Contains("alertasobreriscos"))
            //{
            //    data = _ObjConstrutora.AlertaSobreRiscos;
            //}
            //if (url.ToLower().Trim().Contains("inforemunplataforma"))
            //{
            //    data = _ObjConstrutora.InfoRemunPlataforma;
            //}
            //if (url.ToLower().Trim().Contains("caracofertatribuaplicavel"))
            //{
            //    data = _ObjConstrutora.CaracOfertaTribuAplicavel;
            //}
            //if (url.ToLower().Trim().Contains("incorpconstrut"))
            //{
            //    data = _ObjConstrutora.IncorpConstrut;
            //}
            //if (url.ToLower().Trim().Contains("estudoviabecofinanc"))
            //{
            //    data = _ObjConstrutora.EstudoViabEcoFinanc;
            //}
            //if (url.ToLower().Trim().Contains("outrasinfos"))
            //{
            //    data = _ObjConstrutora.OutrasInfos;
            //}
            //if (url.ToLower().Trim().Contains("outrasinfos"))
            //{
            //    data = _ObjConstrutora.OutrasInfos;
            //}

            htmlDoc.LoadHtml(data);
            htmlDoc.Save(file);
            file.Close();

            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
            converter.Options.PdfPageSize = SelectPdf.PdfPageSize.A4;
            converter.Options.PdfPageOrientation = SelectPdf.PdfPageOrientation.Landscape;
            //converter.Options.WebPageWidth = webPageWidth;
            //converter.Options.WebPageHeight = webPageHeight;
            //PdfDocument doc_ = converter.ConvertHtmlString(innerHtml);
            SelectPdf.PdfDocument doc_ = converter.ConvertUrl(fullPath);
            doc_.Save(fullPath.Replace("html", "pdf"));
            doc_.Close();

            return new JsonResult(new { fileName = fileName.Replace("html", "pdf"), errorMessage = "" });
        }
        [HttpGet]
        [DeleteFile]
        public ActionResult BaixarPDF(string file)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string fullPath = Path.Combine(sWebRootFolder + @"\Upload", file);

            var net = new System.Net.WebClient();
            var data = net.DownloadData(fullPath);
            var content = new MemoryStream(data);

            return File(content, "application/pdf", file);
        }
        [HttpPost]
        [Authorize]
        public IActionResult InfoTaxasGlobais([FromBody] ObjVlrAportComSimula model)
        {
            //return new JsonResult(new { someValue = "It's ok" });

            try
            {
                var _listDescricoes = new List<string>();
                //var _retorno = new List<TaxaGLOBAL>();
                foreach (var item in model.TaxasGlobais)
                {
                    _listDescricoes.Add(item.Descricao);
                }

                var _valortoFloat = Convert.ToDouble(model.Valor);
                var _perc_valortoFloat = _valortoFloat / 100;

                //--------------------------------------------
                // PEGO CARONA NESSE PROCEDIMENTO
                // E RETORNO OS SALDOS DO USUÁRIO LOGADO
                //---------------------------------------------

                // PEGO O USUARIO LOGADO
                var _usu = _context.Users
                    .Where(x => x.UserName == User.Identity.Name)
                    .FirstOrDefault();

                // SALDOS
                var _saldoReservado = 0.0;
                var _saldoAdquirido = 0.0;
                var _saldoReservTot = 0.0;
                var _saldoAdquirTot = 0.0;

                // PEGO O SALDO RESERVADO
                _saldoReservado = _context.INVEST_Lancamentos
                    .Where(x => x.UsuarioAppId == _usu.Id && x.Status == "P" &&
                    x.DTHR.Year == DateTime.Now.Year)
                    .Sum(x => x.Valor);

                // PEGO O SALDO RESERVADO
                _saldoAdquirido = _context.INVEST_Lancamentos
                    .Where(x => x.UsuarioAppId == _usu.Id && x.Status == "A" &&
                    x.DTHR.Year == DateTime.Now.Year)
                    .Sum(x => x.Valor);

                // FAÇO A SOMA DO TOTAL RESERVADO + O VALOR DIGITADO
                _saldoReservTot = _saldoReservado + _valortoFloat;

                // FAÇO A SOMA DO TOTAL ADQUIRIDO + O VALOR DIGITADO
                _saldoAdquirTot = _saldoAdquirido + _valortoFloat;

                var retorno = _context
                    .TaxasGLOBAIS
                    .Where(a => _listDescricoes.Contains(a.descricao))
                    .Select(x => new
                    {
                        x.Id,
                        x.descricao,
                        x.valor,
                        x.pre_selec,
                        x.informacoes,
                        valorcalcu = (Convert.ToDouble(x.valor) * _perc_valortoFloat + _valortoFloat).ToString("C2"),
                        saldo_reservado = _saldoReservado,
                        saldo_adquirido = _saldoAdquirido,
                        saldo_reservtot = _saldoReservTot,
                        saldo_adquirtot = _saldoAdquirTot,
                        saldo_reservado_str = _saldoReservado.ToString("C2").Replace("R$", "R$ "),
                        saldo_adquirido_str = _saldoAdquirido.ToString("C2").Replace("R$", "R$ "),
                        saldo_reservtot_str = _saldoReservTot.ToString("C2").Replace("R$", "R$ "),
                        saldo_adquirtot_str = _saldoAdquirTot.ToString("C2").Replace("R$", "R$ "),
                    });

                return new JsonResult(retorno);
            }
            catch (Exception) { }

            return new JsonResult("ACESSO NEGADO");
        }

        public static void BackupDirectory(string directory)
        {
            using (ZipFile zip = new ZipFile
            {
                CompressionLevel = CompressionLevel.BestCompression
            })
            {
                var files = Directory.GetFiles(directory, "*",
                    SearchOption.AllDirectories).
                    Where(f => Path.GetExtension(f).
                        ToLowerInvariant() != ".zip").ToArray();

                foreach (var f in files)
                {
                    zip.AddFile(f,
                        Path.GetDirectoryName(f).
                        Replace(directory, string.Empty));
                }

                zip.Save(Path.ChangeExtension(directory, ".zip"));
            }
        }
        [HttpGet]
        [Authorize(Roles = "SIS")]
        public async Task<object> CriarDump(string titulo = "")
        {
            var _usu = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            try
            {
                string connectionString = @"Server=.\SQLEXPRESS;user id=grupoalfa;password=SenhaBoodah@010203;";
                string[] saDatabases = new string[] { "house2invest" };
                string backupDir = _hostingEnvironment.WebRootPath + @"\DB_Backups";
                DateTime dtNow = DateTime.Now;
                try
                {
                    if (!Directory.Exists(backupDir))
                        Directory.CreateDirectory(backupDir);

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();

                        foreach (string dbName in saDatabases)
                        {
                            string backupFileNameWithoutExt = String.Format("{0}\\{1}_{2:yyyy-MM-dd_hh-mm-ss-tt}", backupDir, dbName, dtNow);

                            if (!string.IsNullOrEmpty(titulo))
                                backupFileNameWithoutExt = String.Format("{0}\\{1}", backupDir, titulo);

                            string backupFileNameWithExt = String.Format("{0}.bak", backupFileNameWithoutExt);
                            string zipFileName = String.Format("{0}.zip", backupFileNameWithoutExt);
                            string cmdText = string.Format("BACKUP DATABASE {0}\r\nTO DISK = '{1}'", dbName, backupFileNameWithExt);
                            using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                            {
                                sqlCommand.CommandTimeout = 0;
                                sqlCommand.ExecuteNonQuery();
                            }

                            //var _nomearq = backupFileNameWithExt.Replace(backupDir, "").Replace(@"\", "").Trim();
                            using (ZipFile zip = new ZipFile())
                            {
                                zip.CompressionLevel = CompressionLevel.BestCompression;
                                //zip.FlattenFoldersOnExtract = false;
                                zip.AddFile(backupFileNameWithExt, "");
                                zip.Save(zipFileName);
                                //zip.Save();
                            }

                            var _config = _context.AppPerfil
                            .Include(x => x.AppConfiguracoes)
                            .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                            .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                            .FirstOrDefault();

                            String strorageconn = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey);
                            CloudStorageAccount storageacc = CloudStorageAccount.Parse(strorageconn);
                            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();
                            CloudBlobContainer container = blobClient.GetContainerReference(_config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);
                            await container.CreateIfNotExistsAsync();

                            var _nomeblob = zipFileName.Replace(backupDir, "").Replace(@"\", "").Trim();
                            CloudBlockBlob blockBlob = container.GetBlockBlobReference(_nomeblob);
                            using (var filestream = System.IO.File.OpenRead(zipFileName))
                            {
                                await blockBlob.UploadFromStreamAsync(filestream);
                                var _pegaurl = blockBlob.Uri.AbsoluteUri;

                                var _novo = _context.DUMPSQL.Add(new DUMPSQL() { URLBAK = _pegaurl });
                                await _context.SaveChangesAsync();
                            }

                            System.IO.File.Delete(backupFileNameWithExt);
                            System.IO.File.Delete(zipFileName);
                        }

                        sqlConnection.Close();
                    }

                    //--------------------------------
                    // LOGCENTRAL
                    //--------------------------------
                    var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                    var _ips = new string[] { ip, "value2" };
                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-save text-primary'></i>",
                        MENSAGEM = $"CÓPIA DE SEGURANÇA DO BANCO DE DADOS <b>EFETUADA COM SUCESSO</b>",
                        ACAO = $"BACKUP",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = "--",
                        TIPO = "CÓPIA DE SEGURANÇA",
                        UsuarioAppId = _usu.Id,
                        VALOR = 0,
                        UsuarioAppCriadorId = _usu.Id
                    }, _context);

                    //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                    //{
                    //    ACAO = "BACKUP",
                    //    INVEST_LancamentoId = 0,
                    //    INVEST_ModeloDocId = 0,
                    //    TP = "CÓPIA DE SEGURANÇA",
                    //    URLDOC = "",
                    //    VALOR = 0,
                    //    STATUS = "SUCESSO",
                    //    UsuarioAppId = _usu.Id,
                    //    IP = _ips.FirstOrDefault()
                    //});
                    //await _context.SaveChangesAsync();

                    return new { status = "ok", mens = "BACKUP EFETUADO COM SUCESSO!!!" };
                }
                catch (Exception ex)
                {
                    //--------------------------------
                    // LOGCENTRAL
                    //--------------------------------
                    var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                    var _ips = new string[] { ip, "value2" };
                    //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                    //{
                    //    ACAO = "BACKUP",
                    //    INVEST_LancamentoId = 0,
                    //    INVEST_ModeloDocId = 0,
                    //    TP = "CÓPIA DE SEGURANÇA",
                    //    URLDOC = "",
                    //    VALOR = 0,
                    //    STATUS = "ERRO",
                    //    UsuarioAppId = _usu.Id,
                    //    IP = _ips.FirstOrDefault()
                    //});
                    //await _context.SaveChangesAsync();

                    return new { status = "erro", mens = ex.Message };
                }
            }
            catch (Exception erro)
            {
                //--------------------------------
                // LOGCENTRAL
                //--------------------------------
                var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var _ips = new string[] { ip, "value2" };
                //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                //{
                //    ACAO = "BACKUP",
                //    INVEST_LancamentoId = 0,
                //    INVEST_ModeloDocId = 0,
                //    TP = "CÓPIA DE SEGURANÇA",
                //    URLDOC = "",
                //    VALOR = 0,
                //    STATUS = "ERRO",
                //    UsuarioAppId = _usu.Id,
                //    IP = _ips.FirstOrDefault()
                //});
                //await _context.SaveChangesAsync();
                return new { status = "erro", mens = erro.Message };
            }
        }
        [HttpGet]
        [Authorize(Roles = "SIS")]
        public object RestaurarDump(int id)
        {
            try
            {
                var _appConfigApp =
                    _context.AppConfiguracoes_Aplicativo.FirstOrDefault();

                var _arquivoDUMP =
                    _context.DUMPSQL
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                var path =
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Upload", _arquivoDUMP.URLBAK.Replace("https://dimweb.blob.core.windows.net/armazseguro/", ""));

                if (!System.IO.File.Exists(path))
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri(_arquivoDUMP.URLBAK), path);
                }

                try
                {
                    if (System.IO.File.Exists(path))
                    {
                        //recebe a localização do arquivo zip
                        using (ZipFile zip = new ZipFile(path))
                        {
                            //verifica se o destino existe
                            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Upload")))
                            {
                                try
                                {
                                    //extrai o arquivo zip para o destino
                                    zip.ExtractAll(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Upload"), ExtractExistingFileAction.OverwriteSilently);

                                    zip.Dispose();

                                    System.IO.File.Delete(path);

                                    string connectionString = @"Server=.\SQLEXPRESS;user id=grupoalfa;password=SenhaBoodah@010203;";
                                    string[] saDatabases = new string[] { "house2invest" };

                                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                                    {
                                        sqlConnection.Open();

                                        foreach (string dbName in saDatabases)
                                        {
                                            string cmdText = string.Format("Alter database {0} set OFFLINE with rollback immediate", dbName);
                                            using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                                            {
                                                sqlCommand.CommandTimeout = 0;
                                                sqlCommand.ExecuteNonQuery();
                                            }

                                            cmdText = string.Format("RESTORE DATABASE {0} FROM DISK = '{1}'", dbName, path.Replace(".zip", ".bak"));
                                            using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                                            {
                                                sqlCommand.CommandTimeout = 120;
                                                sqlCommand.ExecuteNonQuery();
                                            }
                                        }
                                        sqlConnection.Close();
                                    }
                                }
                                catch
                                {
                                    throw;
                                }
                            }
                            else
                            {
                                throw new DirectoryNotFoundException("O arquivo destino não foi localizado");
                            }
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("O Arquivo Zip não foi localizado");
                    }

                    return new { status = "ok", mens = "RESTAURAÇÃO DO BANCO EFETUADO COM SUCESSO!!!" };
                }
                catch (Exception err)
                {
                    return new { status = "erro", mens = err.Message };
                }
            }
            catch (Exception erro)
            {
                return new { status = "erro", mens = erro.Message };
            }
        }
        [HttpPost]
        [Authorize(Roles = "SIS")]
        public async Task<IActionResult> Restaurar_Bak(List<IFormFile> arquivo_bak)
        {
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            try
            {
                var _usu = _context.Users
                    .Where(x => x.UserName == User.Identity.Name)
                    .FirstOrDefault();

                long size = arquivo_bak.Sum(f => f.Length);
                //var filePath = Path.GetTempFileName().Replace(".tmp", ".bak");
                var filePath = "";
                foreach (var formFile in arquivo_bak)
                {
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Upload", formFile.FileName);
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }

                //var path =
                //    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Upload", _arquivoDUMP.URLBAK.Replace("https://dimweb.blob.core.windows.net/armazseguro/", ""));
                //if (!System.IO.File.Exists(path))
                //{
                //    WebClient webClient = new WebClient();
                //    webClient.DownloadFile(new Uri(_arquivoDUMP.URLBAK), path);
                //}

                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        string connectionString = @"Server=.\SQLEXPRESS;user id=grupoalfa;password=SenhaBoodah@010203;";
                        string[] saDatabases = new string[] { "house2invest" };
                        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                        {
                            sqlConnection.Open();

                            foreach (string dbName in saDatabases)
                            {
                                string cmdText = string.Format("ALTER DATABASE {0} SET OFFLINE WITH ROLLBACK IMMEDIATE", dbName);
                                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                                {
                                    sqlCommand.CommandTimeout = 0;
                                    sqlCommand.ExecuteNonQuery();
                                }

                                cmdText = string.Format("RESTORE DATABASE {0} FROM DISK = '{1}'", dbName, filePath);
                                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                                {
                                    sqlCommand.CommandTimeout = 120;
                                    sqlCommand.ExecuteNonQuery();
                                }

                                cmdText = string.Format("ALTER DATABASE {0} SET ONLINE", dbName);
                                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                                {
                                    sqlCommand.CommandTimeout = 0;
                                    sqlCommand.ExecuteNonQuery();
                                }
                            }

                            sqlConnection.Close();

                            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                            {
                                ICOMENS = "<i class='fas fa-save text-primary'></i>",
                                MENSAGEM = $"RESTAURAÇÃO DE CÓPIA DE SEGURANÇA DO BANCO DE DADOS <b>EFETUADA COM SUCESSO</b>",
                                ACAO = $"RESTORE",
                                DTHR = DateTime.Now,
                                IP = _ips.FirstOrDefault(),
                                STATUS = "--",
                                TIPO = "CÓPIA DE SEGURANÇA",
                                UsuarioAppId = _usu.Id,
                                VALOR = 0,
                                UsuarioAppCriadorId = _usu.Id
                            }, _context);
                        }
                    }
                    catch (Exception erro)
                    {
                        var _erro = erro;
                        string connectionString = @"Server=.\SQLEXPRESS;user id=grupoalfa;password=SenhaBoodah@010203;";
                        string[] saDatabases = new string[] { "house2invest" };
                        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                        {
                            sqlConnection.Open();

                            foreach (string dbName in saDatabases)
                            {
                                string cmdText = string.Format("Alter database {0} set ONLINE", dbName);
                                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                                {
                                    sqlCommand.CommandTimeout = 120;
                                    sqlCommand.ExecuteNonQuery();
                                }
                            }

                            sqlConnection.Close();
                        }


                        await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                        {
                            ICOMENS = "<i class='fas fa-times text-danger'></i>",
                            MENSAGEM = $"UMA RESTAURAÇÃO DE BANCO DE DADOS FOI INTERROMPIDA DEVIDO A UM <b style='color:red;'>ERRO GRAVE</b>. MAS FIQUE TRANQUILO ADM, <b>REVERTI O BANCO</b> E TUDO ESTÁ FUNCIONANDO NORMALMENTE. <br><i style='color:red;'>IMPORTANTE: INFORME ESSE PROBLEMA AO FABRICANTE DO APLICATIVO.</i>",
                            ACAO = $"BACKUP",
                            DTHR = DateTime.Now,
                            IP = _ips.FirstOrDefault(),
                            STATUS = "ERRO GRAVE",
                            TIPO = "CÓPIA DE SEGURANÇA",
                            UsuarioAppId = _usu.Id,
                            VALOR = 0,
                            UsuarioAppCriadorId = _usu.Id
                        }, _context);

                        //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                        //{
                        //    ACAO = "CÓPIA DE SEGURANÇA",
                        //    INVEST_LancamentoId = 0,
                        //    INVEST_ModeloDocId = 0,
                        //    TP = "RESTORE",
                        //    URLDOC = "",
                        //    VALOR = 0,
                        //    STATUS = "PROBLEMAS. O BANCO FOI REVERTIDO AUTOMATICAMENTE",
                        //    UsuarioAppId = _usu.Id,
                        //    IP = _ips.FirstOrDefault()
                        //});
                        //await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    throw new FileNotFoundException("O Arquivo Zip não foi localizado");
                }

                //return Ok(new { count = arquivo_bak.Count, size, filePath });
                return Ok(new { status = "ok", mens = "RESTAURAÇÃO DO BANCO EFETUADO COM SUCESSO!!!" });
                //return new { status = "ok", mens = "RESTAURAÇÃO DO BANCO EFETUADO COM SUCESSO!!!" };
            }
            catch (Exception err)
            {
                return Ok(new { status = "erro", mens = err.Message });
                //return new { status = "erro", mens = err.Message };
            }
        }
    }

    public class DeleteFileAttribute : TypeFilterAttribute
    {
        public DeleteFileAttribute() : base(typeof(DeleteFileAttributeImpl)) { }
        private class DeleteFileAttributeImpl : IActionFilter
        {
            private readonly IHostingEnvironment _hostingEnvironment;
            public DeleteFileAttributeImpl(IHostingEnvironment hostingEnvironment) { _hostingEnvironment = hostingEnvironment; }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                try
                {
                    string sWebRootFolder = _hostingEnvironment.WebRootPath;
                    string fullPath = Path.Combine(sWebRootFolder + @"\Upload", context.HttpContext.Request.QueryString.Value);
                    fullPath = fullPath.Replace("?file=", "");
                    File.Delete(fullPath);
                    File.Delete(fullPath.Replace(".pdf", ".html"));
                }
                catch (Exception) { }
            }
            public void OnActionExecuting(ActionExecutingContext context) { }
        }
    }
}