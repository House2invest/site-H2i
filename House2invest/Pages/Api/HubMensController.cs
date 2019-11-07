using House2Invest.Data;
using House2Invest.Hubs;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HubMensController : ControllerBase
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IHubContext<MensagensHub> _hubMensagens;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<UsuarioApp> _signInManager;
        public HubMensController(IHttpContextAccessor accessor, SignInManager<UsuarioApp> signInManager, ApplicationDbContext context, IHubContext<NotificacoesHub> hubNotificacoes, IHubContext<MensagensHub> hubMensagens) { _accessor = accessor; _signInManager = signInManager; _context = context; _hubMensagens = hubMensagens; }
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

        [Authorize]
        public async Task Teclando(string para)
        {
            var _de = RetornaUsuLogado();
            var _usupara = RetornaUsuSalaVIP(para);

            if (_de != null && _usupara != null)
            {
                //await _hubMensagens.Clients.All.SendAsync("teclando", $"{_de.Nome} {_de.Sobrenome}", $"{_usupara.UsuarioApp.Nome} {_usupara.UsuarioApp.Sobrenome}");
                await _hubMensagens.Clients
                    .Client(_usupara.CnxId).SendAsync("teclando", $"{_de.Nome} {_de.Sobrenome}", $"{_usupara.UsuarioApp.Nome} {_usupara.UsuarioApp.Sobrenome}", _de.Id, _usupara.Id);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task Correio()
        {
            try
            {
                var _dadosform = Request.Form;

                var _de = _dadosform["de"];
                var _para = _dadosform["para"];
                //var _paracnxid = _dadosform["cnxpara"];
                //var _decnxid = _dadosform["cnxde"];
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


                var _usulogado =
                    await _context.Users
                    .FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

                //------------
                // SALVA TUDO
                //------------
                var _pegaCNXID =
                    _context.tblUsuSalaVIPs
                    .Where(x => x.UsuarioAppId == _usulogado.Id)
                    .OrderByDescending(x => x.DTHR)
                    .FirstOrDefault();

                var _pegaCNXID_PARA =
                    _context.tblUsuSalaVIPs
                    .Where(x => x.UsuarioAppId == _para)
                    .OrderByDescending(x => x.DTHR)
                    .FirstOrDefault();

                //if (_pegaCNXID != null)
                //{
                //    if (_pegaCNXID.Status == "ENTROU")
                //        _paracnxid = _pegaCNXID.CnxId;
                //}
                //if (_pegaCNXID_PARA != null)
                //{
                //    if (_pegaCNXID_PARA.Status == "ENTROU")
                //        _paracnxid = _pegaCNXID.CnxId;
                //}

                // LOG NO BANCO
                var _novamens = new tblHubConversa()
                {
                    De = _de,
                    DeCnxId = _pegaCNXID != null ? (_pegaCNXID.Status == "ENTROU" ? _pegaCNXID.CnxId : "") : "",
                    Para = _para,
                    ParaCnxId = _pegaCNXID_PARA != null ? (_pegaCNXID_PARA.Status == "ENTROU" ? _pegaCNXID_PARA.CnxId : "") : "",
                    Mensagem = _mens,
                    Lida = false
                };
                _context.tblHubConversas.Add(_novamens);
                await _context.SaveChangesAsync();

                //await _hubNotificacoes
                //    .Clients.All
                //    .SendAsync("enviarmens", _novamens.DeCnxId, _de, _para, _mens);

                var conteudotraduzido = await VerificadoresRetornos.TranslateText(_mens, "en|pt-br");

                await _hubMensagens
                    .Clients
                    .Client(_novamens.ParaCnxId)
                    .SendAsync("correio", _de, _para, conteudotraduzido, _novamens.DeCnxId, _novamens.ParaCnxId);
            }
            catch (System.Exception)
            {
                //return new { mens = "Não foi possível concluir sua solicitação." };
            }

            //await _hubContext.Clients.All.SendAsync("Notify", $"Página carregada");
            //return new { mens = "ok" };
        }
        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public async Task<object> MensagensNaoLidas()
        {
            try
            {
                var _u = await _context.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
                var _retorno = new List<object>();

                var _mensNaoLidas = _context
                    .tblHubConversas
                    .Where(x => x.Para == _u.Id && !x.Lida)
                    .ToList();

                var _agrupadoRecebido = _context
                    .tblHubConversas
                    .Where(x => x.Para == _u.Id && !x.Lida)
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
                    .OrderByDescending(x => x.DTHR)
                    .Distinct(d => d.De);

                foreach (var item in _agrupadoRecebido)
                {
                    var _ude = _context.Users.FirstOrDefault(x => x.Id == item.De);
                    _retorno.Add(new
                    {
                        item.Id,
                        dthr = VerificadoresRetornos.TemposAtras(item.DTHR),
                        item.De,
                        de_nome = _ude.Nome + " " + _ude.Sobrenome,
                        de_avatar = _ude.AvatarUsuario,
                        menscortada = item.Mensagem.Length > 80 ? item.Mensagem.Substring(0, 80) + " ..." : item.Mensagem,
                        mens = item.Mensagem,
                        lida = !item.Lida ? 0 : 1
                    });
                }

                return new
                {
                    status = "ok",
                    dados = _retorno
                };
            }
            catch (Exception) { }

            return new { status = "erro", dados = "" };
        }
        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public async Task<object> Historico(string de)
        {
            try
            {
                var _para = await _context.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
                var _retorno = new List<object>();

                var _historico = _context.tblHubConversas
                    .Where(x => x.De == de && x.Para == _para.Id || x.Para == de && x.De == _para.Id)
                    .OrderBy(x => x.DTHR);

                var _lista = _historico.ToList();
                foreach (var item in _lista)
                {
                    var _item = await _context.tblHubConversas
                        .FirstOrDefaultAsync(x => x.Id == item.Id);

                    if (_item != null)
                    {
                        _item.Lida = true;
                        //_context.Attach(_item).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }

                foreach (var item in _historico)
                {
                    _retorno.Add(new
                    {
                        dthr = VerificadoresRetornos.TemposAtras(item.DTHR),
                        mens = item.Mensagem,
                        flag = item.De == de ? "R" : "E"
                    });
                }

                return new
                {
                    status = "ok",
                    dados = _retorno
                };
            }
            catch (Exception) { }

            return new { status = "erro", dados = "" };
        }

        [HttpGet]
        [Authorize(Roles = "SIS")]
        public async Task<object> AcaoContaUsuario(string id, string tp, string acao = "UsuarioEmailConfirmado")
        {
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
                        _registro.EmailConfirmed = tp.ToLower().Trim() == "on" ? true : false;

                    if (acao == "UsuarioAcessoBloqueado")
                    {
                        if (tp.ToLower().Trim() == "on")
                            await _hubMensagens.Clients.All.SendAsync("ForceLogoff", $"{_registro.Id}", "");

                        _registro.Sistema_AcessoBloqueado = tp.ToLower().Trim() == "on" ? true : false;
                    }
                }

                _context.Attach(_registro).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var _ips = new string[] { ip, "value2" };

                //// LOGCENTRAL
                //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                //{
                //    ACAO = acao,
                //    INVEST_LancamentoId = 0,
                //    INVEST_ModeloDocId = 0,
                //    TP = tp.ToLower().Trim(),
                //    URLDOC = "",
                //    VALOR = 0,
                //    STATUS = "acao_sis",
                //    UsuarioAppId = _registro.Id,
                //    IP = _ips.FirstOrDefault()
                //});
                //await _context.SaveChangesAsync();
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
    }
}
