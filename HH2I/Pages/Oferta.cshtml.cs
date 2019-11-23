using House2Invest.Data;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace House2Invest.Pages
{
    [Authorize]
    public class OfertaModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        public OfertaModel(ApplicationDbContext context, IHostingEnvironment hostingEnvironment, IHttpContextAccessor accessor, IConfiguration configuration) { _context = context; _accessor = accessor; _configuration = configuration; _hostingEnvironment = hostingEnvironment; }
        [BindProperty]
        public CorpoPrincipalOferta modelo { get; set; }
        public string __IPPUBLICO { get; set; }
        [BindProperty]
        public ObjetoIP2Loc ObjetoIP2LocModelo { get; set; }
        public string Mensagem { get; set; }

        public double _valTot { get; set; }
        public double _valReserva { get; set; }
        public double _valAdquirido { get; set; }
        public double _valTotalInvestido { get; set; }
        public double _valfracao { get; set; }
        public double _valfracaoRes { get; set; }
        public double _valfracaoAdq { get; set; }
        public double _valLanceMin { get; set; }
        public double _valMinimoDocs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var registro = await _context
                .BlocoProjInvestimentos
                .Include(x => x.GaleriaPerfilAlbum)
                .Include(x => x.Construtora)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (registro == null)
            {
                return NotFound();
            }

            modelo = new CorpoPrincipalOferta();
            modelo.blocoProjInvestimento = new BlocoProjInvestimento()
            {
                Id = registro.Id,
                Titulo = registro.Titulo,
                DescricaoDetalhadaProjeto = registro.DescricaoDetalhadaProjeto,
                Valor = registro.Valor,
                UrlImgPrinc = registro.UrlImgPrinc,
                Contador_DataFinal = registro.Contador_DataFinal,
                LanceMinimo = registro.LanceMinimo,
                ValorMinimoDocs = registro.ValorMinimoDocs,
                Status = registro.Status,
                Contato_CEP = registro.Contato_CEP,
                Contato_Logradouro = registro.Contato_Logradouro,
                Contato_LogradouroNum = registro.Contato_LogradouroNum,
                Contato_Bairro = registro.Contato_Bairro,
                Contato_Cidade = registro.Contato_Cidade,
                Contato_Complemento = registro.Contato_Complemento,
                Contato_Estado = registro.Contato_Estado,
                Ativo = registro.Ativo,
                BlocoProjInvest_ExibTitulo = registro.BlocoProjInvest_ExibTitulo,
                Contador_Exib = registro.Contador_Exib,
                DTHR = registro.DTHR,
                GaleriaPerfilAlbumId = registro.GaleriaPerfilAlbumId,
                GaleriaPerfilAlbum = registro.GaleriaPerfilAlbum,
                ConstrutoraId = registro.ConstrutoraId,
                Construtora = registro.Construtora,
                LinkVideoProjeto = registro.LinkVideoProjeto,
                SaldoReservado = registro.SaldoReservado,
                Rentabilidade_PRE_FIM = registro.Rentabilidade_PRE_FIM,
                Rentabilidade_PRE_INI = registro.Rentabilidade_PRE_INI,
                Rentabilidade_PRE_TIT = registro.Rentabilidade_PRE_TIT,
                Rentabilidade_ROI_FIM = registro.Rentabilidade_ROI_FIM,
                Rentabilidade_ROI_INI = registro.Rentabilidade_ROI_INI,
                Rentabilidade_ROI_TIT = registro.Rentabilidade_ROI_TIT,
                Rentabilidade_TIR_FIM = registro.Rentabilidade_TIR_FIM,
                Rentabilidade_TIR_INI = registro.Rentabilidade_TIR_INI,
                Rentabilidade_TIR_TIT = registro.Rentabilidade_TIR_TIT,
                AndamentoObra = registro.AndamentoObra,
                AndamentoObraAcabamento = registro.AndamentoObraAcabamento
            };
            modelo.usuarioObjeto = new UsuarioApp();
            modelo.usuarioObjeto = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

            //modelo.ValorInvestido = registro.LanceMinimo;
            modelo.ValorInvestido = "0,00";

            //var _meuip = VerificadoresRetornos.GetPublicIP();
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            __IPPUBLICO = _ips.FirstOrDefault();

            var _novoobjip2loc = new ObjetoIP2Loc();
            var _resultado_GEO =
                await ChamaREST
                .Current
                .GetAsync<ObjetoIP2Loc>($"http://xnspirit.api.depoisdalinha.com.br/api/buscar/{__IPPUBLICO}", false);

            if (_resultado_GEO != null)
            {
                _novoobjip2loc.cep = _resultado_GEO.cep;
                _novoobjip2loc.cidade = _resultado_GEO.cidade;
                _novoobjip2loc.codpais = _resultado_GEO.codpais;
                _novoobjip2loc.estado = _resultado_GEO.estado;
                _novoobjip2loc.lat = _resultado_GEO.lat;
                _novoobjip2loc.lon = _resultado_GEO.lon;
                _novoobjip2loc.nomepais = _resultado_GEO.nomepais;
                _novoobjip2loc.timezone = _resultado_GEO.timezone;

                ObjetoIP2LocModelo = _novoobjip2loc;
            }

            try
            {
                _valTot = Convert.ToDouble(modelo.blocoProjInvestimento.Valor);

                _valReserva =
                    _context.INVEST_Lancamentos
                    .Where(x => x.BlocoProjInvestimentosId == modelo.blocoProjInvestimento.Id && x.Status == "P")
                    .Sum(x => x.Valor);

                _valAdquirido =
                    _context.INVEST_Lancamentos
                    .Where(x => x.BlocoProjInvestimentosId == modelo.blocoProjInvestimento.Id && x.Status == "A")
                    .Sum(x => x.Valor);

                _valTotalInvestido =
                    _context.INVEST_Lancamentos
                    .Where(x => x.BlocoProjInvestimentosId == modelo.blocoProjInvestimento.Id)
                    .Sum(x => x.Valor);

                _valfracao = Convert.ToDouble(modelo.blocoProjInvestimento.Valor) / 100;
                _valfracaoRes = Math.Round(_valReserva / _valfracao);
                _valfracaoAdq = Math.Round(_valAdquirido / _valfracao);
                _valLanceMin = Convert.ToDouble(modelo.blocoProjInvestimento.LanceMinimo);
                _valMinimoDocs = Convert.ToDouble(modelo.blocoProjInvestimento.ValorMinimoDocs);
            }
            catch (Exception) { }

            return Page();
        }


        /*
        RE 2e. Evidência de que a plataforma restitui os montantes investidos 
                para os investidores, num prazo de até 5 dias úteis, nos casos de 
                revogação (após suspensão) ou cancelamento da oferta.

        CONTROLE DE TRANSFERÊNCIAS EM CASO DE:
        SITUAÇÃO: 
        (I)	SUSPENSÃO DA OFERTA:
            a.	H2i deve Informar por e-mail que a CVM suspendeu oferta e a h2i 
                tem 30 dias para atender a exigência.
            b.	O investidor pode enviar e-mail solicitando a revogação da oferta. 
                Se mandar, a H2i deverá restituir o valor integral em até 
                5 dias contados do recebimento do e-mail

        (II)	SUSPENSÃO CONVALIDAR EM CANCELAMENTO
            a.	Se a CVM cancelar a oferta, os investidores devem ser 
                restituídos em 5 dias úteis contados do cancelamento.

        (III)   Encerramento da Oferta – Concluído o processo de captação com êxito
            a.	Transferência para SPE o montante final captado no prazo 
                de até 5 dias úteis após a data do encerramento.

            b.	Devolução do valor investido acrescido da remuneração do capital 
                ao final do período contratado ao final do prazo de validade do título

        (IV)	Restituição do montante final investido quando o valor 
                alvo mínimo não atingir 2/3 (dois terços) do valor alvo máximo; 
             
        */
        public async Task<JsonResult> OnPostAsync()
        {
            /*
                Evidenciar a tipificação do investidor de acordo com o montante: 
                a) novo investidor investindo menos de 10mil 
                b) novo investidor investindo mais de 10 mil 
                c) investidor fazendo novo aporte em oferta, com total menor de 10mil (acumulado) 
                d) investidor fazendo novo aporte em oferta, com total maior de 10mil (acumulado) 
                e) investidor fazendo novo aporte em oferta, com total menor de 100mil (acumulado) 
                f) autodeclaração de valores acumulados multiplataforma             
            */

            double _valormoeda = 0;

            try
            {
                if (modelo.ArquivoComprovResid == null)
                {
                    return new JsonResult(new
                    {
                        status = "arq_comprov_resid",
                        mens = "Você precisa enviar um comprovante de residência"
                    });
                }

                if (modelo.AceitouTermos == false)
                {
                    return new JsonResult(new
                    {
                        status = "termos",
                        mens = "Você precisa ler e aceitar os Termos desta oferta"
                    });
                }

                if (string.IsNullOrEmpty(modelo.usuarioObjeto.Financeiro_Banco_Nome) ||
                    string.IsNullOrEmpty(modelo.usuarioObjeto.Financeiro_Banco_Ag) ||
                    string.IsNullOrEmpty(modelo.usuarioObjeto.Financeiro_Banco_CC))
                {
                    return new JsonResult(new
                    {
                        status = "info_usu_banco",
                        mens = "Você precisa corrigir suas informações bancárias."
                    });
                }

                if (string.IsNullOrEmpty(modelo.usuarioObjeto.Sistema_URLSelfieDocFRENTE) ||
                    string.IsNullOrEmpty(modelo.usuarioObjeto.Sistema_URLSelfieDocVERSO))
                {
                    return new JsonResult(new
                    {
                        status = "info_usu_selfies",
                        mens = "Envie um documento com foto (Frente/Verso) antes de solicitar uma reserva.<br> <a href='/Identity/Account/Manage'>Clique aqui para resolver isso</a>"
                    });
                }

                if (string.IsNullOrEmpty(modelo.PerfilInvestidorInformado))
                {
                    return new JsonResult(new
                    {
                        status = "perfil_investidor",
                        mens = "Você precisa selecionar um PERFIL DE INVESTIDOR"
                    });
                }

                var _usuario = _context.Users
                    .Where(x => x.UserName == User.Identity.Name)
                    .FirstOrDefault();

                _valormoeda = Convert.ToDouble(modelo.ValorInvestido);

                var _bloco = _context.BlocoProjInvestimentos
                    .Where(x => x.Id == Convert.ToInt32(modelo.blocoProjInvestimento.Id))
                    .FirstOrDefault();

                //if (_valormoeda > 10000 && _usuario.Financeiro_Investidor_Perfil == "C")
                //{
                //    return Page();
                //    //return new
                //    //{
                //    //    Status = "erro",
                //    //    Mens = $"VALOR SUPERIOR A <b>R$ 10.000,00</b>.<br> Deseja alterar o seu perfil de investidor? Clique <a href='/Correio/Conversas?uid=2751483e-2c65-4629-84b5-abc20c940c1c&idinv=" + modelo.blocoProjInvestimento.Id + "' target='_blank'><b>AQUI</b></a>.",
                //    //    Dados = "",
                //    //    Total = 0
                //    //};
                //}

                //if (_valormoeda > 1000000 && _usuario.Financeiro_Investidor_Perfil == "B")
                //{
                //    return Page();
                //    //return new
                //    //{
                //    //    Status = "erro",
                //    //    Mens = $"VALOR SUPERIOR A <b>R$ 1.000.000,00</b>.<br> Deseja alterar o seu perfil de investidor? Clique <a href='/Correio/Conversas?uid=2751483e-2c65-4629-84b5-abc20c940c1c&idinv=" + modelo.blocoProjInvestimento.Id + "' target='_blank'><b>AQUI</b></a>.",
                //    //    Dados = "",
                //    //    Total = 0
                //    //};
                //}

                var _valortotalgeral = 0.0;
                try
                {
                    _valortotalgeral = _context.INVEST_Lancamentos
                        //.Where(x => x.BlocoProjInvestimentosId == _bloco.Id && x.Status == "A")
                        .Where(x => x.BlocoProjInvestimentosId == _bloco.Id)
                        .Sum(x => x.Valor);
                }
                catch (Exception) { }
                var _valorbloco = Convert.ToDouble(_bloco.Valor);
                if (_valormoeda + _valortotalgeral > _valorbloco)
                {
                    return new JsonResult(new
                    {
                        status = "valor",
                        mens = $"Infelizmente não podemos aportar o valor total da sua reserva, pois o valor informado ultrapassa o limite esperado desta oferta.<br>O valor excedido foi de: <b>{(_valormoeda + _valortotalgeral - _valorbloco).ToString("C2")}</b>"
                    });

                    //return Page();
                    //return new
                    //{
                    //    Status = "erro",
                    //    Mens = $"O VALOR QUE VOCÊ DESEJA INVESTIR, ULTRAPASSA O VALOR TOTAL DA OFERTA. INVISTA UM VALOR MENOR.",
                    //    Dados = "",
                    //    Total = 0
                    //};
                }

                //var _totalinvestido = 0.0;
                //try
                //{
                //    _totalinvestido = _context.INVEST_Lancamentos
                //        .Where(x => x.UsuarioAppId == _usuario.Id)
                //        .Sum(x => x.Valor);
                //}
                //catch (Exception) { }

                //if (_valormoeda + _totalinvestido > _valorbloco)
                ////if (_valormoeda + _totalinvestido > (_usuario.Financeiro_Investidor_Perfil == "C" ? 10000 : _usuario.Financeiro_Investidor_Perfil == "B" ? 1000000 : 10000))
                //{
                //    //var _valorfinal = ((_usuario.Financeiro_Investidor_Perfil == "C" ? 10000 : _usuario.Financeiro_Investidor_Perfil == "B" ? 1000000 : 10000) - _totalinvestido);
                //    var _valorfinal = _valormoeda + _totalinvestido;
                //    //return Page();
                //    return new JsonResult(new
                //    {
                //        status = "valor",
                //        mens = $"VOCÊ ULTRAPASSOU O LIMITE DE INVESTIMENTO PARA O SEU PERFIL.<br> ULTRAPASSADO: <b>R$ " + (_valorfinal - _valorbloco).ToString("C2") + "</b>.<br> Deseja alterar seu perfil? Clique <a href='/Correio/Conversas?uid=2751483e-2c65-4629-84b5-abc20c940c1c&idinv=" + modelo.blocoProjInvestimento.Id + "' target='_blank'>AQUI</a>."
                //    });

                //    //return new
                //    //{
                //    //    Status = "erro",
                //    //    Mens = $"VOCÊ ULTRAPASSOU O LIMITE DE INVESTIMENTO PARA O SEU PERFIL.<br> SEU SALDO É DE: <b>R$ " + _valorfinal.ToString("C2") + "</b>.<br> Deseja alterar seu perfil? Clique <a href='/Correio/Conversas?uid=2751483e-2c65-4629-84b5-abc20c940c1c&idinv=" + modelo.blocoProjInvestimento.Id + "' target='_blank'>AQUI</a>.",
                //    //    Dados = "",
                //    //    Total = 0
                //    //};
                //}

                //_context.BlocoProjInvestimentoValores.Add(new BlocoProjInvestimentoValor()
                //{
                //    BlocoProjInvestimentoId = Convert.ToInt32(_id),
                //    UsuarioAppId = _usuario.Id,
                //    Valor = _valormoeda
                //});
                //await _context.SaveChangesAsync();

                //-------------------
                // OBJETO USUARIO
                //-------------------
                //var _pegaUsu =
                //    _context.Users
                //    .Where(x => x.UserName == User.Identity.Name)
                //    .FirstOrDefault();

                //-------------------
                // LOGS FINANCEIROS
                //-------------------
                // LANCAMENTO
                var _novoLancamento = new INVEST_Lancamento()
                {
                    BlocoProjInvestimentosId = Convert.ToInt32(modelo.blocoProjInvestimento.Id),
                    UsuarioAppId = _usuario.Id,
                    TP = "E",
                    Valor = _valormoeda,
                    Status = "P",
                    PerfilInvestidorInformado = modelo.PerfilInvestidorInformado
                };
                _context.INVEST_Lancamentos.Add(_novoLancamento);
                await _context.SaveChangesAsync();

                var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var _ips = new string[] { ip, "value2" };

                //var _valormindoc = Convert.ToDouble(_context.BlocoProjInvestimentos.Where(x => x.Id == Convert.ToInt32(modelo.blocoProjInvestimento.Id)).FirstOrDefault().ValorMinimoDocs);
                //if (_valormoeda > _valormindoc)
                //{

                // LANCAMENTOS DOC
                var _listaItensDoc =
                await _context.BlocoProjInvestimento_ItemDocs
                    .Include(x => x.INVEST_ModeloDoc)
                    .Where(x => x.BlocoProjInvestimentoId == _novoLancamento.BlocoProjInvestimentosId)
                    .ToListAsync();

                var _indiceCuringaModeloDocProblemaReferencia = 0;
                foreach (var item in _listaItensDoc)
                {
                    var _novoLancamentoDoc = new INVEST_LancamentoDoc()
                    {
                        INVEST_LancamentoId = _novoLancamento.Id,
                        INVEST_ModeloDocId = item.INVEST_ModeloDocId,
                        URLDoc = "",
                        TP = "A"
                    };
                    _context.INVEST_LancamentoDocs.Add(_novoLancamentoDoc);
                    await _context.SaveChangesAsync();
                    _indiceCuringaModeloDocProblemaReferencia = item.INVEST_ModeloDocId;
                }

                foreach (var item in _listaItensDoc)
                {
                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-file-signature text-primary'></i>",
                        MENSAGEM = $"ASSINOU DIGITALMENTE {item.INVEST_ModeloDoc.Titulo}",
                        ACAO = $"ASSINATURA DIGITAL",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = "",
                        TIPO = "NOTIFICAÇÃO",
                        UsuarioAppId = _usuario.Id,
                        VALOR = _novoLancamento.Valor,
                        UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                    }, _context);
                }

                var _textoAnexos = "";
                var fileName = "";
                var _config = _context.AppPerfil
                    .Include(x => x.AppConfiguracoes)
                    .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                    .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                    .FirstOrDefault();

                //----------
                // ANEXO4-C
                //----------
                if (modelo.PerfilInvestidorInformado == "C")
                {
                    _textoAnexos += $"<div style='text-align:center;'><b>ANEXO 4-C</b></div>";
                    _textoAnexos += $"<div style='text-align:center;margin-top:0px;margin-bottom:25px;'><b>{HttpUtility.HtmlEncode("DECLARAÇÃO")}</b></div>";
                    _textoAnexos += $"<div style='text-align:justify !important;'>";
                    _textoAnexos += $"Declaro, sob as penas da lei, que:<br>";
                    _textoAnexos += $"1. o valor de meu investimento na oferta de <b style='font-size:14px;color:grey !important;margin-left:15px;margin-right:15px;font-weight:normal !important;'>[emissor]</b>, quando somado ao valor de <b style='font-size:14px;color:grey !important;margin-left:15px;margin-right:15px;font-weight:normal !important;'>[montante]</b> que {HttpUtility.HtmlEncode("já")} investi no {HttpUtility.HtmlEncode("ano-calendário")} em ofertas dispensadas de registro na {HttpUtility.HtmlEncode("Comissão de Valores Mobiliários (CVM)")} por meio de plataformas {HttpUtility.HtmlEncode("eletrônicas")} investimento participativo (crowdfunding de investimento), {HttpUtility.HtmlEncode("não")} ultrapassa R$ 10.000,00 (dez mil reais).<br><br>";
                    _textoAnexos += $"2. entendo que o limite de R$ 10.000,00 (dez mil reais) tem por objetivo proteger os investidores em {HttpUtility.HtmlEncode("razão do nível")} de risco e da falta de liquidez associados aos investimentos por meio de crowdfunding.<br><br>";
                    _textoAnexos += $"3. entendo ser minha responsabilidade observar que o valor total de meus investimentos realizados no {HttpUtility.HtmlEncode("ano-calendário")} em todas as plataformas de crowdfunding de investimento combinadas {HttpUtility.HtmlEncode("não")} ultrapassa o limite.<br>";
                    _textoAnexos += $"</div><br><br><br>";
                    _textoAnexos += $"<b>{HttpUtility.HtmlEncode("SÃO PAULO")}, {DateTime.Now.ToLongDateString().ToUpper()}</b><br><br><br><br><br><br><br>";
                    _textoAnexos += $"<hr style='display:block;width:60%;margin-top:0px;margin-bottom:0px;float:left;'><br>";
                    _textoAnexos += $"<b style='margin-top:-25px;'>{HttpUtility.HtmlEncode(_usuario.Nome)} {_usuario.Sobrenome} /// {_usuario.Documentacao_CPF}</b><br>";
                    _textoAnexos += $"<br><br><br><br>";
                    _textoAnexos += $"<div style='margin-top:25px;'>";
                    _textoAnexos += $"<b style='color:grey!important;font-size:8px!important;font-weight:normal!important;'>Registro H2I: Esse ANEXO4-C foi assinado digitalmente por {HttpUtility.HtmlEncode("você")} no dia {DateTime.Now.ToShortDateString()} {HttpUtility.HtmlEncode("às")} {DateTime.Now.ToShortTimeString()} a partir do IP: {_ips.FirstOrDefault()} referente a reserva de {_valormoeda.ToString("C2")} na oferta {HttpUtility.HtmlEncode(_bloco.Titulo)} </i>";
                    _textoAnexos += $"</div>";

                    fileName = $"{Guid.NewGuid().ToString()}-anexo4c.html";
                }
                else if (modelo.PerfilInvestidorInformado == "B")
                {
                    _textoAnexos += $"<div style='text-align:center;'><b>ANEXO 4-B</b></div>";
                    _textoAnexos += $"<div style='text-align:center;margin-top:0px;margin-bottom:25px;'><b>{HttpUtility.HtmlEncode("DECLARAÇÃO")}</b></div>";

                    _textoAnexos += $"<div style='text-align:justify !important;'>";
                    _textoAnexos += $"Declaro, sob as penas da lei, que:<br>";
                    _textoAnexos += $"1. possuo renda bruta anual ou investimentos financeiros em valor superior a R$ 100.000,00 (cem mil reais).<br><br>";
                    _textoAnexos += $"2. o valor de meu investimento na oferta de <b style='font-size:14px;color:grey !important;margin-left:15px;margin-right:15px;font-weight:normal !important;'>[ emissor ]</b>, quando somado ao valor de R$ <b style='font-size:14px;color:grey !important;margin-left:15px;margin-right:15px;font-weight:normal !important;'>[ montante ]</b> que {HttpUtility.HtmlEncode("já")} investi no {HttpUtility.HtmlEncode("ano-calendário")} em ofertas dispensadas de registro na {HttpUtility.HtmlEncode("Comissão de Valores Mobiliários (CVM)")} por meio de plataformas {HttpUtility.HtmlEncode("eletrônicas")} investimento participativo (crowdfunding de investimento), {HttpUtility.HtmlEncode("não")} ultrapassa 10% (dez por cento) do maior entre: (a) minha renda bruta anual; ou (b) o montante total de meus investimentos financeiros.<br><br>";
                    _textoAnexos += $"3. entendo que o limite de 10% (dez por cento) tem por objetivo proteger os investidores em {HttpUtility.HtmlEncode("razão do nível")} de risco e da falta de liquidez associados aos investimentos por meio de crowdfunding.<br><br>";
                    _textoAnexos += $"4. entendo ser minha responsabilidade observar que o valor total de meus investimentos realizados no {HttpUtility.HtmlEncode("ano-calendário")} em todas as plataformas de crowdfunding de investimento combinadas {HttpUtility.HtmlEncode("não")} ultrapassa o limite.";
                    _textoAnexos += $"</div><br><br><br>";
                    _textoAnexos += $"<b>{HttpUtility.HtmlEncode("SÃO PAULO")}, {DateTime.Now.ToLongDateString().ToUpper()}</b><br><br><br><br><br><br><br>";
                    _textoAnexos += $"<hr style='display:block;width:60%;margin-top:0px;margin-bottom:0px;float:left;'><br>";
                    _textoAnexos += $"<b style='margin-top:-25px;'>{HttpUtility.HtmlEncode(_usuario.Nome)} {_usuario.Sobrenome} /// {_usuario.Documentacao_CPF}</b><br>";
                    _textoAnexos += $"<br><br><br><br>";
                    _textoAnexos += $"<div style='margin-top:25px;'>";
                    _textoAnexos += $"<b style='color:grey!important;font-size:8px!important;font-weight:normal!important;'>Registro H2I: Esse ANEXO4-B foi assinado digitalmente por {HttpUtility.HtmlEncode("você")} no dia {DateTime.Now.ToShortDateString()} {HttpUtility.HtmlEncode("às")} {DateTime.Now.ToShortTimeString()} a partir do IP: {_ips.FirstOrDefault()} referente a reserva de {_valormoeda.ToString("C2")} na oferta {HttpUtility.HtmlEncode(_bloco.Titulo)} </i>";
                    _textoAnexos += $"</div>";

                    fileName = $"{Guid.NewGuid().ToString()}-anexo4b.html";
                }
                else if (modelo.PerfilInvestidorInformado == "A")
                {
                    _textoAnexos += $"<div style='text-align:center;'><b>ANEXO 4-A</b></div>";
                    _textoAnexos += $"<div style='text-align:center;margin-top:0px;margin-bottom:25px;'><b>{HttpUtility.HtmlEncode("DECLARAÇÃO")}</b></div>";
                    _textoAnexos += $"<div style='text-align:justify !important;'>";
                    _textoAnexos += $"Ao assinar este termo, afirmo minha {HttpUtility.HtmlEncode("condição")} de investidor qualificado e declaro possuir conhecimento sobre o mercado financeiro suficiente para que {HttpUtility.HtmlEncode("não")} me sejam {HttpUtility.HtmlEncode("aplicáveis")} um conjunto de {HttpUtility.HtmlEncode("proteções")} legais e regulamentares conferidas aos investidores que {HttpUtility.HtmlEncode("não")} sejam qualificados.<br><br>";
                    _textoAnexos += $"Como investidor qualificado, atesto ser capaz de entender e ponderar os riscos financeiros relacionados {HttpUtility.HtmlEncode("à aplicação")} de meus recursos em oferta {HttpUtility.HtmlEncode("pública de distribuição de valores mobiliários de emissão de sociedades empresárias")} de pequeno porte, realizada com dispensa de registro na {HttpUtility.HtmlEncode("Comissão de Valores Mobiliários (CVM)")}, por meio de plataforma {HttpUtility.HtmlEncode("eletrônica")} de investimento participativo.<br><br>";
                    _textoAnexos += $"Declaro, sob as penas da lei, que possuo investimentos financeiros em valor superior a R$ 1.000.000,00 {HttpUtility.HtmlEncode("(um milhão de reais)")}.<br><br>";
                    _textoAnexos += $"</div><br><br><br>";
                    _textoAnexos += $"<b>{HttpUtility.HtmlEncode("SÃO PAULO")}, {DateTime.Now.ToLongDateString().ToUpper()}</b><br><br><br><br><br><br><br>";
                    _textoAnexos += $"<hr style='display:block;width:60%;margin-top:0px;margin-bottom:0px;float:left;'><br>";
                    _textoAnexos += $"<b style='margin-top:-25px;'>{HttpUtility.HtmlEncode(_usuario.Nome)} {_usuario.Sobrenome} /// {_usuario.Documentacao_CPF}</b><br>";
                    _textoAnexos += $"<br><br><br><br>";
                    _textoAnexos += $"<div style='margin-top:25px;'>";
                    _textoAnexos += $"<b style='color:grey!important;font-size:8px!important;font-weight:normal!important;'>Registro H2I: Esse ANEXO4-A foi assinado digitalmente por {HttpUtility.HtmlEncode("você")} no dia {DateTime.Now.ToShortDateString()} {HttpUtility.HtmlEncode("às")} {DateTime.Now.ToShortTimeString()} a partir do IP: {_ips.FirstOrDefault()} referente a reserva de {_valormoeda.ToString("C2")} na oferta {HttpUtility.HtmlEncode(_bloco.Titulo)} </i>";
                    _textoAnexos += $"</div>";

                    fileName = $"{Guid.NewGuid().ToString()}-anexo4a.html";
                }

                string sWebRootFolder = _hostingEnvironment.WebRootPath;
                string fullPath = Path.Combine(sWebRootFolder + "//Upload", fileName);
                FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(_textoAnexos);
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
                System.IO.File.Delete(fullPath);

                // ENVIAR PRA CLOUD AZURE
                FileStream _arquivoPDFCriado = new FileStream(fullPath.Replace("html", "pdf"), FileMode.Open, FileAccess.Read);
                string pegaurl = "";
                try
                {
                    var _strcnx = "";
                    _strcnx = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey);
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_strcnx);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(_config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                    blockBlob.Properties.ContentType = "application/pdf";
                    await blockBlob.UploadFromStreamAsync(_arquivoPDFCriado);
                    pegaurl = blockBlob.Uri.AbsoluteUri;

                    var _novoLancamentoDoc = new INVEST_LancamentoDoc()
                    {
                        INVEST_LancamentoId = _novoLancamento.Id,
                        // USO UM INDICE VALIDO COLHIDO LÁ EM CIMA
                        // PARA SANAR UM PROBLEMA DE REFERENCIA DE CHAVE
                        // ESTRANGEIRA COM MODELOS DOC. AFINAL DE CONTAS
                        // GERO O PDF DO ZERO, NÃO EXISTE ASSOCIACAO
                        // AINDA, ATEH O ATO DE CRIAR E PUBLICAR O PDF.
                        INVEST_ModeloDocId = _indiceCuringaModeloDocProblemaReferencia,
                        URLDoc = pegaurl,
                        TP = "A"
                    };
                    _context.INVEST_LancamentoDocs.Add(_novoLancamentoDoc);
                    await _context.SaveChangesAsync();

                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-file-signature text-primary'></i>",
                        MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoAnexos + "</i>" + $"<br> <div><a href='{pegaurl}' target='_blank'>Ver doc.</a></div>",
                        ACAO = $"INFORMOU PERFIL ANEXO4-{modelo.PerfilInvestidorInformado}",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = "",
                        TIPO = "NOTIFICAÇÃO",
                        UsuarioAppId = _usuario.Id,
                        VALOR = _novoLancamento.Valor,
                        UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                    }, _context);
                }
                catch (Exception err) { var erro = err; }

                //// LOGCENTRAL
                //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                //{
                //    ACAO = "INVESTIU",
                //    INVEST_LancamentoId = _novoLancamento.Id,
                //    INVEST_ModeloDocId = _novoLancamento.Id,
                //    TP = _novoLancamento.TP,
                //    URLDOC = "",
                //    VALOR = _valormoeda,
                //    STATUS = _novoLancamento.Status,
                //    UsuarioAppId = _novoLancamento.UsuarioAppId,
                //    IP = _ips.FirstOrDefault()
                //});
                //await _context.SaveChangesAsync();
                //// CONTROLE TRANSF - USU
                //_context.INVEST_ControleTransfs.Add(new INVEST_ControleTransf()
                //{
                //    BlocoProjInvestimentosId = _novoLancamento.BlocoProjInvestimentosId,
                //    Status = "P",
                //    UsuarioAppId = _novoLancamento.UsuarioAppId,
                //    Valor = _novoLancamento.Valor
                //});
                //await _context.SaveChangesAsync();
                //// CONTROLE TRANSF - ADM
                //_context.INVEST_ControleTransfs.Add(new INVEST_ControleTransf()
                //{
                //    BlocoProjInvestimentosId = _novoLancamento.BlocoProjInvestimentosId,
                //    Status = "P",
                //    UsuarioAppId = "bbf7b44d-faa0-4276-b163-295b780a062c",
                //    Valor = _novoLancamento.Valor
                //});
                //await _context.SaveChangesAsync();
                //return Page();
                //if (modelo.ArquivoComprovResid != null)
                //{
                //    var _imagemLogotipo =
                //        await VerificadoresRetornos
                //        .EnviarImagemAzure(modelo.ArquivoComprovResid, 550000, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);
                //    if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                //        BlocoProjInvestimento.UrlImgPrinc = _imagemLogotipo;
                //    else
                //    {
                //        ModelState.AddModelError(string.Empty, "A imagem é muito grande");
                //        _errosValidacoes = true;
                //    }
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Selecione uma imagem do seu computador");
                //    _errosValidacoes = true;
                //}


                //}

                //// LOGCENTRAL
                //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                //{
                //    ACAO = "ENVIO DE EMAIL - INVESTIU",
                //    INVEST_LancamentoId = _novoLancamento.Id,
                //    INVEST_ModeloDocId = _novoLancamento.Id,
                //    TP = _novoLancamento.TP,
                //    URLDOC = "",
                //    VALOR = _valormoeda,
                //    STATUS = _novoLancamento.Status,
                //    UsuarioAppId = _novoLancamento.UsuarioAppId,
                //    IP = _ips.FirstOrDefault()
                //});
                //await _context.SaveChangesAsync();

                var _token = Guid.NewGuid().ToString();
                var _novaconfirm = new InvestimentoConfirmacao()
                {
                    BlocoProjInvestimentoId = modelo.blocoProjInvestimento.Id,
                    Confirmado = false,
                    Token = _token,
                    UsuarioAppId = _usuario.Id,
                    Valor = _valormoeda,
                    INVEST_LancamentoId = _novoLancamento.Id
                };
                _context.InvestimentoConfirmacoes.Add(_novaconfirm);
                await _context.SaveChangesAsync();

                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                {
                    ICOMENS = "<i class='fas fa-wallet text-warning'></i>",
                    MENSAGEM = $"O usuário <b>{_novoLancamento.UsuarioApp.Nome} {_novoLancamento.UsuarioApp.Sobrenome}</b> fez uma reserva de <b>{_novoLancamento.Valor.ToString("C2")}</b> na oferta <b>{_novoLancamento.BlocoProjInvestimentos.Titulo}</b>.<br> Geramos o seguinte token ao investidor: <i>{_token}</i>",
                    ACAO = $"RESERVA",
                    DTHR = DateTime.Now,
                    IP = _ips.FirstOrDefault(),
                    STATUS = VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_novoLancamento.Status),
                    TIPO = "INVESTIMENTOS",
                    UsuarioAppId = _novoLancamento.UsuarioAppId,
                    VALOR = _valormoeda,
                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                }, _context);


                /*
                E-mail confirmação de reserva de investimento e envio do Código de Validação 
                
                
                Olá [Nome Investidor],

                Recebemos a sua reserva no valor de R$ [    ] (      mil reais).
                Para confirmá-la, insira o código de validação a seguir :
                [código]


                Atenciosamente,
                Equipe House2Invest
                */

                // instanciar objeto email
                var _configAplicacoes =
                    _context.AppConfiguracoes_Aplicativo
                    .FirstOrDefault();

                string _textoEmail = $"Olá {_novoLancamento.UsuarioApp.Nome}, <br>";
                _textoEmail += $"Recebemos o seu pedido de reserva no valor de {_novoLancamento.Valor.ToString("C2")}. <br>";
                _textoEmail += $"Para confirmá-la, insira o código de validação a seguir:<br>";
                _textoEmail += $"<code>{_token}</code> <br><br>";
                _textoEmail += $"Atenciosamente, <br>";
                _textoEmail += $"<b>Equipe House2invest</b> <br>";

                var _objemail = new ObjetoEmailEnvio()
                {
                    ASSUNTO = "[INVESTIMENTO] House2Invest",
                    COPIA = _configAplicacoes.mailToAdd,
                    mailFrom = _configAplicacoes.mailFrom,
                    MENSAGEM = _textoEmail,
                    //MENSAGEM = string.Format($"Olá {_usuario.Nome},<br/><br/><br/>Recebemos a sua reserva no valor de <b>{_valormoeda.ToString("C2")}</b>.<br/> Para confirmá-la, insira o código de validação a seguir:<br> <b>{_token}</b>.<br/><br/><br/>Atenciosamente,<br>Equipe House2Invest"),
                    //MENSAGEM = string.Format($"Olá!!!{Environment.NewLine}<br/>Você fez um investimento de <b>{_valormoeda.ToString("C2")}</b> em <b>{_context.BlocoProjInvestimentos.Where(x => x.Id == Convert.ToInt32(modelo.blocoProjInvestimento.Id)).FirstOrDefault().Titulo}</b>. Para validá-lo, digite esse código <b>{_token}</b> no campo correspondente."),
                    PARA = _usuario.Email,
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
                    MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_novoLancamento.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                    ACAO = $"ENVIOU EMAIL",
                    DTHR = DateTime.Now,
                    IP = _ips.FirstOrDefault(),
                    STATUS = VerificadoresRetornos.PROC__RetornaStatusLiteralLancamento(_novoLancamento.Status),
                    TIPO = "NOTIFICAÇÃO",
                    UsuarioAppId = _novoLancamento.UsuarioAppId,
                    VALOR = _novoLancamento.Valor,
                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                }, _context);

                //var _enviou =
                //    await VerificadoresRetornos
                //    .EnviarEmail(_usuario.Email, "", "[INVESTIMENTO] House2Invest", string.Format($"Olá!!!{Environment.NewLine}<br/>Você fez um investimento de <b>{_valormoeda.ToString("C2")}</b> em <b>{_context.BlocoProjInvestimentos.Where(x => x.Id == Convert.ToInt32(modelo.blocoProjInvestimento.Id)).FirstOrDefault().Titulo}</b>. Para validá-lo, digite esse código <b>{_token}</b> no campo correspondente."));

                //return new
                //{
                //    Status = "ok",
                //    Mens = $"Seu investimento foi registrado em nosso sistema. Acompanhe o andamento em sua área protegida.",
                //    Dados = "",
                //    Total = 0
                //};
                //return Page();

                //return Redirect("/");

                return new JsonResult(new
                {
                    status = "ok",
                    mens = $"PARABÉNS"
                });
            }
            catch (Exception err)
            {
                //return Page();
                return new JsonResult(new
                {
                    status = "erro",
                    mens = $"Nada foi feito. Verifique o log de saída.",
                    errobruto = err.InnerException.Message
                    //    Dados = "",
                    //    Total = 0
                });
            }
        }
    }
}