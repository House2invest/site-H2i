using House2Invest.Data;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace House2Invest.Pages
{
    [Authorize(Roles = "SIS,ADM,USU")]
    public class IndexCMSModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        public readonly string jobId = Guid.NewGuid().ToString("N");
        public IndexCMSModel(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment, ApplicationDbContext context) { _hostingEnvironment = hostingEnvironment; _context = context; _accessor = accessor; }
        [BindProperty]
        public ObjetoIP2Loc ObjetoIP2LocModelo { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["TotalRegistros"] =
                _context.AppPerfil.Count() +
                _context.AppConfiguracoes.Count() +
                _context.AppConfiguracoes_Aplicativo.Count() +
                _context.AppConfiguracoes_Azure.Count();

            //var _meuip = VerificadoresRetornos.GetPublicIP();
            var _meuip = Get();

            var _novoobjip2loc = new ObjetoIP2Loc();
            var _resultado_GEO =
                await ChamaREST
                .Current
                .GetAsync<ObjetoIP2Loc>($"http://xnspirit.api.depoisdalinha.com.br/api/buscar/{_meuip.FirstOrDefault()}", false);

            if (_resultado_GEO != null)
            {
                _novoobjip2loc.ip = _meuip.FirstOrDefault();
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

            return Page();
        }
        public IEnumerable<string> Get()
        {
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return new string[] { ip, "value2" };
        }
        #region CHARTS
        public JsonResult OnGetDadosBarrasVisitasDia()
        {
            var resultado = new object();
            IEnumerable<object> filtroRegistros = new List<object>();
            var retornojson = new { dados = new object[] { }, maximo = 0, minimo = 0 };
            try
            {
                var _registros = _context.SEO_Visitas
                    .Where(x => x.DTHR.Day == DateTime.Now.Day)
                    .OrderByDescending(x => x.DTHR.Hour);

                var _manha = _registros.Where(x => x.DTHR.Hour > 0 && x.DTHR.Hour < 12).Count();
                var _tarde = _registros.Where(x => x.DTHR.Hour > 11 && x.DTHR.Hour < 18).Count();
                var _noite = _registros.Where(x => x.DTHR.Hour > 17).Count();

                retornojson = new
                {
                    dados = new object[] { _manha, _tarde, _noite },
                    maximo = _registros.Count() + 50,
                    minimo = 0
                };
            }
            catch (Exception) { }

            return new JsonResult(retornojson);
        }
        //[HttpGet]
        //public IActionResult dadosChartEventosAno()
        //{
        //    var resultado = new object();
        //    IEnumerable<object> filtroRegistros = new List<object>();
        //    var retornojson = Json(new { dados = new object[] { }, maximo = 0, minimo = 0 });
        //    try
        //    {
        //        var _registros =
        //            _context.Eventos
        //            .Where(x => x.DataIni.Year == DateTime.Now.Year)
        //            .OrderByDescending(x => x.DataIni);
        //        //resultado = from item in _registros
        //        //            select new[] { 15, 56, 81, 258, 13, 1, 1150, 854, 623, 2100, 85, 1751 };
        //        var _jan = _registros.Where(x => x.DataIni.Month == 1).Count();
        //        var _fev = _registros.Where(x => x.DataIni.Month == 2).Count();
        //        var _mar = _registros.Where(x => x.DataIni.Month == 3).Count();
        //        var _abr = _registros.Where(x => x.DataIni.Month == 4).Count();
        //        var _mai = _registros.Where(x => x.DataIni.Month == 5).Count();
        //        var _jun = _registros.Where(x => x.DataIni.Month == 6).Count();
        //        var _jul = _registros.Where(x => x.DataIni.Month == 7).Count();
        //        var _ago = _registros.Where(x => x.DataIni.Month == 8).Count();
        //        var _set = _registros.Where(x => x.DataIni.Month == 9).Count();
        //        var _out = _registros.Where(x => x.DataIni.Month == 10).Count();
        //        var _nov = _registros.Where(x => x.DataIni.Month == 11).Count();
        //        var _dez = _registros.Where(x => x.DataIni.Month == 12).Count();
        //        retornojson = Json(new
        //        {
        //            dados = new[] { _jan, _fev, _mar, _abr, _mai, _jun, _jul, _ago, _set, _out, _nov, _dez },
        //            maximo = _registros.Count(),
        //            minimo = 0
        //        });
        //    }
        //    catch (Exception) { }
        //    return retornojson;
        //}
        #endregion
        #region Utilitarios
        //[Produces("application/json")]
        //public async Task<ActionResult> BuscarPessoas(string chavebusca)
        //{
        //    var retorno = new StringBuilder();

        //    try
        //    {
        //        var _buscacongressista =
        //            await _context.Congressistas
        //            .Include(x => x.Evento)
        //            .Where
        //            (
        //                x => x.Nome.ToLower().Trim().Contains(chavebusca.ToLower().Trim()) ||
        //                x.CPFCNPJ.Replace(".", "").Replace("-", "").Contains(chavebusca.ToLower().Trim()) ||
        //                x.Email.ToLower().Trim().Contains(chavebusca.ToLower().Trim())
        //            )
        //            .ToListAsync();

        //        var _buscainscritos =
        //            await _context.Inscritos
        //            .Include(x => x.Curso)
        //            .Where
        //            (
        //                x => x.Nome.ToLower().Trim().Contains(chavebusca.ToLower().Trim()) ||
        //                x.CPF.Replace(".", "").Replace("-", "").Contains(chavebusca.ToLower().Trim()) ||
        //                x.Email.ToLower().Trim().Contains(chavebusca.ToLower().Trim())
        //            )
        //            .ToListAsync();

        //        //bool acheialgo = false;
        //        //if (_buscacongressista != null)
        //        //{
        //        //    acheialgo = true;
        //        //    retorno.Append("<a href='javascript:;' class='btn btn-primary btn-block'><i class='fa fa-chalkboard-teacher'></i> Congreso <br/><b style='margin-bottom:4px;white-space: normal;'>" + _buscacongressista.Evento.Titulo + "</b></a>");
        //        //}
        //        //if (_buscainscritos.Count > 0)
        //        //{
        //        //    acheialgo = true;
        //        //    foreach (var item in _buscainscritos)
        //        //    {
        //        //        retorno.Append("<a href='javascript:;' class='btn btn-success btn-block'><i class='fa fa fa-graduation-cap'></i>  Curso <br/><b style='margin-bottom:4px;white-space: normal;'>" + item.Curso.Descricao + "</b></a>");
        //        //    }
        //        //}

        //        var _retorno = new List<select2BuscaPessoa>();
        //        foreach (var item in _buscacongressista.GroupBy(x => x.Nome).Select(y => y.First()))
        //        {
        //            _retorno.Add(new select2BuscaPessoa()
        //            {
        //                Id = item.Id,
        //                Nome = item.Nome.ToUpper().Trim(),
        //                Tipo = "CONGRESSO"
        //            });
        //        }

        //        foreach (var item in _buscainscritos.GroupBy(x => x.Nome).Select(y => y.First()))
        //        {
        //            if (_retorno.Where(x => x.Nome.ToLower().Trim().Equals(item.Nome.ToLower().Trim())).Count() == 0)
        //            {
        //                _retorno.Add(new select2BuscaPessoa()
        //                {
        //                    Id = item.Id,
        //                    Nome = item.Nome.ToUpper().Trim(),
        //                    Tipo = "CURSO"
        //                });
        //            }
        //        }

        //        return Ok(new
        //        {
        //            Status = "ok",
        //            Mens = $"Sucesso",
        //            //items = _buscacongressista.ToList(),
        //            items = _retorno.OrderBy(x => x.Nome).ToList(),
        //            Total = 0
        //        });
        //    }
        //    catch (Exception) { }

        //    return Ok(new
        //    {
        //        Status = "erro",
        //        Mens = $"Não localizei ninguém com esse filtro de busca. Tente novamente por favor.",
        //        items = "",
        //        Total = 0
        //    });
        //}
        //[HttpPost]
        //[Produces("application/json")]
        //public async Task<ActionResult> BuscarCertificados(string chavebusca, int eventoid, string tipo)
        //{
        //    var retorno = new StringBuilder();
        //    var _buscacongressista = new Congressista();
        //    var _buscainscritos = new List<Inscrito>();
        //    try
        //    {
        //        _buscacongressista = await _context.Congressistas
        //            .Include(x => x.Evento)
        //            .Where(x => x.EventoId == eventoid)
        //            .Where
        //            (
        //                x => x.Nome.ToLower().Trim().Equals(chavebusca.ToLower().Trim())
        //            //    x => x.Nome.ToLower().Trim().Equals(chavebusca.ToLower().Trim()) ||
        //            //    x.CPFCNPJ.Replace(".", "").Replace("-", "").Equals(chavebusca.ToLower().Trim()) ||
        //            //    x.Email.ToLower().Trim().Equals(chavebusca.ToLower().Trim())
        //            )
        //            .FirstOrDefaultAsync();
        //    }
        //    catch (Exception) { }

        //    try
        //    {
        //        _buscainscritos = await _context.Inscritos
        //            //.Include(x => x.Curso)
        //            //.Where(x => x.Curso.EventoId == eventoid)
        //            .Where
        //            (
        //                x => x.Nome.ToLower().Trim().Equals(chavebusca.ToLower().Trim())
        //            //    x => x.Nome.ToLower().Trim().Equals(chavebusca.ToLower().Trim()) ||
        //            //    x.CPF.Replace(".", "").Replace("-", "").Equals(chavebusca.ToLower().Trim()) ||
        //            //    x.Email.ToLower().Trim().Equals(chavebusca.ToLower().Trim())
        //            )
        //            .ToListAsync();
        //    }
        //    catch (Exception) { }

        //    //Certificado(int eventoid = 0, int chavebusca = 0, int cursoid = 0)

        //    try
        //    {
        //        retorno.Append("<table class='table card-text py-5'>");
        //        retorno.Append("    <thead style='font-size:12px;font-weight:bold;'>");
        //        retorno.Append("        <tr>");
        //        retorno.Append("            <th style='width:100px;text-align:right;'>TIPO</th>");
        //        retorno.Append("            <th>");
        //        retorno.Append("                CERTIFICADOS DISPONÍVEIS");
        //        retorno.Append("            </th>");
        //        retorno.Append("            <th style='width:100px;'></th>");
        //        retorno.Append("        </tr>");
        //        retorno.Append("    </thead>");
        //        retorno.Append("    <tbody style='font-size:12px;'>");

        //        bool acheialgo = false;
        //        if (_buscacongressista != null)
        //        {
        //            acheialgo = true;
        //            //retorno.Append("<a href='/Home/Certificado?eventoid=" + eventoid + "&chavebusca=" + _buscacongressista.Id + "&cursoid=0' class='btn btn-primary btn-block' target='_blank'><i class='fa fa-chalkboard-teacher'></i> Congreso <br/><b style='margin-bottom:4px;white-space:normal;'>" + _buscacongressista.Evento.Titulo + "</b></a>");
        //            retorno.Append("        <tr>");
        //            retorno.Append("            <td style='text-align:right;font-weight:bold;color:blue;'>");
        //            retorno.Append("                CONGRESSO");
        //            retorno.Append("            </td>");
        //            retorno.Append("            <td>");
        //            retorno.Append("                " + _buscacongressista.Evento.Titulo.ToUpper().Trim());
        //            retorno.Append("            </td>");
        //            retorno.Append("            <td>");
        //            retorno.Append("                <a href='/Home/Certificado?eventoid=" + eventoid + "&chavebusca=" + _buscacongressista.Id + "&cursoid=0' title='Visualizar Certificado' style='margin-right:5px;' target='_blank'><i class='far fa-eye'></i></a> <a href='javascript:ExportarPDF(\"" + string.Format("{0}://{1}", Request.Scheme, Request.Host) + Url.RouteUrl(new { Controller = "Home", Action = "Certificado" }) + "?eventoid=" + eventoid + "&chavebusca=" + _buscacongressista.Id + "&cursoid=0 " + "\");' title='Baixar Certificado'><i class='fa fa-download'></i></a>");
        //            retorno.Append("            </td>");
        //            retorno.Append("        </tr>");
        //        }
        //        if (_buscainscritos != null)
        //        {
        //            acheialgo = true;
        //            foreach (var item in _buscainscritos)
        //            {
        //                var _buscacurso = _context.Cursos.Where(x => x.EventoId == eventoid && x.Id == item.CursoId).FirstOrDefault();
        //                if (_buscacurso != null)
        //                {
        //                    //retorno.Append("<a href='/Home/Certificado?eventoid=" + eventoid + "&chavebusca=" + item.Id + "&cursoid=" + _buscacurso.Id + "' class='btn btn-success btn-block' target='_blank'><i class='fa fa fa-graduation-cap'></i>  Curso <br/><b style='margin-bottom:4px;white-space: normal;'>" + _buscacurso.Descricao + "</b></a>");
        //                    retorno.Append("        <tr>");
        //                    retorno.Append("            <td style='text-align:right;font-weight:bold;color:red;'>");
        //                    retorno.Append("                CURSO");
        //                    retorno.Append("            </td>");
        //                    retorno.Append("            <td>");
        //                    retorno.Append("                " + _buscacurso.Descricao.ToUpper().Trim());
        //                    retorno.Append("            </td>");
        //                    retorno.Append("            <td>");
        //                    retorno.Append("                <a href='/Home/Certificado?eventoid=" + eventoid + "&chavebusca=" + item.Id + "&cursoid=" + _buscacurso.Id + "' title='Visualizar Certificado' style='margin-right:5px;' target='_blank'><i class='far fa-eye'></i></a> <a href='javascript:ExportarPDF(\"" + string.Format("{0}://{1}", Request.Scheme, Request.Host) + Url.RouteUrl(new { Controller = "Home", Action = "Certificado" }) + "?eventoid=" + eventoid + "&chavebusca=" + item.Id + "&cursoid=" + _buscacurso.Id + "\");' title='Baixar Certificado'><i class='fa fa-download'></i></a>");
        //                    retorno.Append("            </td>");
        //                    retorno.Append("        </tr>");
        //                }
        //            }
        //        }

        //        retorno.Append("    </tbody>");
        //        retorno.Append("</table>");

        //        return Ok(new
        //        {
        //            Status = acheialgo ? "ok" : "erro",
        //            Mens = acheialgo ? $"Sucesso" : "Nenhum certificado encontrado com esse filtro de busca. Tente novamente por favor.",
        //            Dados = acheialgo ? retorno.ToString() : "",
        //            Total = 0
        //        });
        //    }
        //    catch (Exception) { }

        //    return Ok(new
        //    {
        //        Status = "erro",
        //        Mens = $"Não localizei ninguém com esse filtro de busca. Tente novamente por favor.",
        //        Dados = "",
        //        Total = 0
        //    });
        //}
        //public IActionResult Certificado(int eventoid = 0, int chavebusca = 0, int cursoid = 0)
        //{
        //    var model = new emissaoCertificado();
        //    model.certif_Data = "00/00/0000";
        //    model.certif_CargaHor = "00h00min";
        //    model.certif_ImagemFundo = @"/images/preview_certificado_005.jpg";
        //    model.certif_Logotipo = @"/images/logo-tecnomarketing.png";
        //    model.certif_Titulo = "TÍTULO";
        //    model.certif_Texto = "SEM CONTEÚDO";
        //    model.CPF = "000.000.000-00";
        //    model.EventoId = 0;
        //    model.pessoa_Nome = "NOME COMPLETO";

        //    var _congressista = new Congressista();
        //    var _inscrito = new Inscrito();
        //    var _curso = new Curso();

        //    try
        //    {
        //        // OBJETO EVENTO
        //        var _evento =
        //            _context.Eventos
        //            .Where(x => x.Id == eventoid)
        //            .FirstOrDefault();

        //        if (_evento != null)
        //        {
        //            if (cursoid == 0)
        //            {
        //                // BUSCO O CONGRESSISTA
        //                _congressista =
        //                    _context.Congressistas
        //                    .Where(x => x.EventoId == eventoid && x.Id == chavebusca)
        //                    .FirstOrDefault();
        //            }
        //            else
        //            {
        //                // BUSCO O INSCRITO
        //                _inscrito =
        //                    _context.Inscritos
        //                    .Where(x => x.CursoId == cursoid && x.Id == chavebusca)
        //                    .FirstOrDefault();

        //                _curso =
        //                    _context.Cursos
        //                    .Where(x => x.Id == cursoid)
        //                    .FirstOrDefault();
        //            }

        //            model.certif_Data = $"{_evento.Cidade}, {_evento.DataFim.Day} de {VerificadoresRetornos.RetornaMesExtenso(_evento.DataFim)} de {_evento.DataFim.Year}";
        //            model.certif_CargaHor = _evento.CargaHoraria;
        //            model.certif_ImagemFundo = _evento.Certif_ImagemFundo;
        //            model.certif_Logotipo = _evento.Certif_Logotipo;
        //            model.exibir_certif_Logotipo = _evento.ExibirLogoTipoCertificado;
        //            model.exibir_certif_ImagemFundo = _evento.ExibirImagemCertificado;
        //            model.certif_Titulo = _evento.Titulo;
        //            model.htmlcss_certificado = _evento.htmlCss_Estilo;

        //            string textocertif =
        //                _congressista.Id > 0
        //                ?
        //                !string.IsNullOrEmpty(_evento.Certif_Texto) ? _evento.Certif_Texto : "SEM CONTEÚDO"
        //                :
        //                !string.IsNullOrEmpty(_evento.Certif_Texto_Inscrito) ? _evento.Certif_Texto_Inscrito : "SEM CONTEÚDO";

        //            textocertif = textocertif.Replace("{titulo_evento}", _evento.Titulo);
        //            textocertif = textocertif.Replace("{cargahora_evento}", _evento.CargaHoraria);
        //            textocertif = textocertif.Replace("{dia_ini_evento}", _evento.DataIni.Day.ToString());
        //            textocertif = textocertif.Replace("{mes_ini_evento}", VerificadoresRetornos.RetornaMesExtenso(_evento.DataIni));
        //            textocertif = textocertif.Replace("{ano_ini_evento}", _evento.DataIni.Year.ToString());
        //            textocertif = textocertif.Replace("{hor_ini_evento}", _evento.DataIni.Hour.ToString());
        //            textocertif = textocertif.Replace("{min_ini_evento}", _evento.DataIni.Minute.ToString());
        //            textocertif = textocertif.Replace("{dia_fim_evento}", _evento.DataFim.Day.ToString());
        //            textocertif = textocertif.Replace("{mes_fim_evento}", VerificadoresRetornos.RetornaMesExtenso(_evento.DataFim));
        //            textocertif = textocertif.Replace("{ano_fim_evento}", _evento.DataFim.Year.ToString());
        //            textocertif = textocertif.Replace("{hor_fim_evento}", _evento.DataFim.Hour.ToString());
        //            textocertif = textocertif.Replace("{min_fim_evento}", _evento.DataFim.Minute.ToString());
        //            textocertif = textocertif.Replace("{local_evento}", _evento.Local);
        //            textocertif = textocertif.Replace("{local_evento_logradouro}", _evento.Logradouro);
        //            textocertif = textocertif.Replace("{local_evento_bairro}", _evento.Bairro);
        //            textocertif = textocertif.Replace("{local_evento_cidade}", _evento.Cidade);
        //            textocertif = textocertif.Replace("{local_evento_estado}", _evento.UF);
        //            textocertif = textocertif.Replace("{local_evento_cep}", _evento.CEP);

        //            if (_inscrito != null)
        //            {
        //                textocertif = textocertif.Replace("{cursos_evento_lista}", _curso.Descricao);
        //            }

        //            model.certif_Texto = textocertif;

        //            if (_congressista.Id > 0)
        //            {
        //                model.CPF = _congressista.CPFCNPJ;
        //                model.EventoId = _congressista.EventoId;
        //                model.pessoa_Nome = _congressista.Nome;
        //            }
        //            else
        //            {
        //                model.CPF = _inscrito.CPF;
        //                model.EventoId = _inscrito.Curso.EventoId;
        //                model.pessoa_Nome = _inscrito.Nome;
        //            }
        //        }
        //    }
        //    catch (Exception) { }

        //    return View(model);
        //}
        //[HttpPost]
        //public JsonResult ExportarPDF(string url)
        //{
        //    var fileName = "Certificado_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".html";
        //    string sWebRootFolder = _hostingEnvironment.WebRootPath;
        //    string fullPath = Path.Combine(sWebRootFolder + "//Upload", fileName);
        //    //var memory = new MemoryStream();
        //    var web = new HtmlAgilityPack.HtmlWeb();
        //    var doc = web.Load(url);
        //    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
        //    doc.Save(file);
        //    file.Close();

        //    SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
        //    converter.Options.PdfPageSize = SelectPdf.PdfPageSize.A4;
        //    converter.Options.PdfPageOrientation = SelectPdf.PdfPageOrientation.Landscape;
        //    //converter.Options.WebPageWidth = webPageWidth;
        //    //converter.Options.WebPageHeight = webPageHeight;
        //    //PdfDocument doc_ = converter.ConvertHtmlString(innerHtml);
        //    SelectPdf.PdfDocument doc_ = converter.ConvertUrl(fullPath);
        //    doc_.Save(fullPath.Replace("html", "pdf"));
        //    doc_.Close();

        //    return Json(new { fileName = fileName.Replace("html", "pdf"), errorMessage = "" });
        //}
        //[HttpGet]
        //[DeleteFile]
        //public ActionResult BaixarPDF(string file)
        //{
        //    string sWebRootFolder = _hostingEnvironment.WebRootPath;
        //    string fullPath = Path.Combine(sWebRootFolder + @"\Upload", file);

        //    var net = new System.Net.WebClient();
        //    var data = net.DownloadData(fullPath);
        //    var content = new MemoryStream(data);

        //    return File(content, "application/pdf", file);
        //}
        //public static Byte[] PdfSharpConvert(String html)
        //{
        //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        //    Byte[] res = null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
        //        pdf.Save(ms);
        //        res = ms.ToArray();
        //    }

        //    return res;
        //}
        #endregion
    }

    /// <summary>
    /// EXCLUI O ARQUIVO APOS O DOWNLOAD EFETUADO
    /// </summary>
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