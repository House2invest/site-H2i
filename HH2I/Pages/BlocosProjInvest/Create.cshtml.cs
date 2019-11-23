using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.BlocosProjInvest
{
    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public BlocoProjInvestimentoViewModel BlocoProjInvestimento { get; set; }
        public IActionResult OnGet()
        {
            BlocoProjInvestimento = new BlocoProjInvestimentoViewModel()
            {
                UrlImgPrinc = "/images/fundo-padrao-investimento-001.jpg",
                Ativo = true,
                //Contador_DataFinal = $"{DateTime.Now.Year}/{DateTime.Now.AddMonths(1).Month.ToString("D2")}/{DateTime.Now.Day.ToString("D2")}",
                Contador_DataFinal = $"{DateTime.Now.Day.ToString("D2")}/{DateTime.Now.AddMonths(6).Month.ToString("D2")}/{DateTime.Now.Year} {DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}{DateTime.Now.Second.ToString("D2")}",
                Valor = "100.000,00",
                LanceMinimo = "1.000,00",
                ValorMinimoDocs = "10.000,00",
                SaldoReservado = 0,
                Status = "A",
                Contador_Exib = true,
                BlocoProjInvest_ExibTitulo = true,
                Rentabilidade_TIR_TIT = "Rentabilidade anual projetada<br> (TIR)*",
                Rentabilidade_TIR_INI = "15.3",
                Rentabilidade_TIR_FIM = "19.2",
                Rentabilidade_PRE_TIT = "Rentabilidade mínima<br> pré-fixada",
                Rentabilidade_PRE_INI = "0",
                Rentabilidade_PRE_FIM = "120",
                Rentabilidade_ROI_TIT = "Rentabilidade projetada<br> (ROI)",
                Rentabilidade_ROI_INI = "53.2",
                Rentabilidade_ROI_FIM = "69.4",
                AndamentoObra = "0 %",
                AndamentoObraAcabamento = "0 %"

            };

            //ViewData["INVEST_ModeloDocId"] = new SelectList(_context.INVEST_ModeloDocs, "Id", "Titulo");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var _config = _context.AppPerfil
                .Include(x => x.AppConfiguracoes)
                .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                .FirstOrDefault();

            var _errosValidacoes = false;
            if (BlocoProjInvestimento.ImagemDestaque != null)
            {
                var _imagemLogotipo =
                    await VerificadoresRetornos
                    .EnviarImagemAzure(BlocoProjInvestimento.ImagemDestaque, 550000, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                    BlocoProjInvestimento.UrlImgPrinc = _imagemLogotipo;
                else
                {
                    ModelState.AddModelError(string.Empty, "A imagem é muito grande");
                    _errosValidacoes = true;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Selecione uma imagem do seu computador");
                _errosValidacoes = true;
            }

            if (Convert.ToDouble(BlocoProjInvestimento.LanceMinimo) > Convert.ToDouble(BlocoProjInvestimento.Valor))
            {
                ModelState.AddModelError(string.Empty, "O Lance mínimo deve ser INFERIOR ao VALOR TOTAL DO INVESTIMENTO");
                _errosValidacoes = true;
            }

            if (VerificadoresRetornos.ConverteStringParaDateTime(BlocoProjInvestimento.Contador_DataFinal) < DateTime.Now)
            {
                ModelState.AddModelError(string.Empty, "A data limite do contador deve ser SUPERIOR a data de hoje");
                _errosValidacoes = true;
            }

            if (Convert.ToDouble(BlocoProjInvestimento.Valor) <= 0)
            {
                ModelState.AddModelError(string.Empty, "Necessário: VALOR TOTAL DO INVESTIMENTO");
                _errosValidacoes = true;
            }

            if (Convert.ToDouble(BlocoProjInvestimento.LanceMinimo) <= 0)
            {
                ModelState.AddModelError(string.Empty, "Necessário: VALOR LANCE MÍNIMO");
                _errosValidacoes = true;
            }

            if (_errosValidacoes)
            {
                BlocoProjInvestimento.UrlImgPrinc = @"/images/sem-imagem.png";
                return Page();
            }

            _context.BlocoProjInvestimentos.Add(BlocoProjInvestimento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}