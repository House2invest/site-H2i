using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.CMSConstrutoras
{
    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public EditModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public ConstrutoraViewModel Construtora { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context
                .Construtoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            Construtora = new ConstrutoraViewModel()
            {
                Bairro = registro.Bairro,
                CEP = registro.CEP,
                Cidade = registro.Cidade,
                CNPJ = registro.CNPJ,
                Complemento = registro.Complemento,
                Email = registro.Email,
                Estado = registro.Estado,
                Fone = registro.Fone,
                DTHR = registro.DTHR,
                Id = registro.Id,
                Logotipo = registro.Logotipo,
                Logradouro = registro.Logradouro,
                LogradouroNum = registro.LogradouroNum,
                NomeFantasia = registro.NomeFantasia,
                Pais = registro.Pais,
                RazaoSocial = registro.RazaoSocial,
                Website = registro.Website,
                AlertaSobreRiscos = registro.AlertaSobreRiscos,
                CaracOfertaTribuAplicavel = registro.CaracOfertaTribuAplicavel,
                ComunPrestInfoContAposOferta = registro.ComunPrestInfoContAposOferta,
                EstudoViabEcoFinanc = registro.EstudoViabEcoFinanc,
                IncorpConstrut = registro.IncorpConstrut,
                InfoPlanoNegocios = registro.InfoPlanoNegocios,
                InfoRemunPlataforma = registro.InfoRemunPlataforma,
                InfoValorMobOfertado = registro.InfoValorMobOfertado,
                OutrasInfos = registro.OutrasInfos,
                SetorAtuacaoHist = registro.SetorAtuacaoHist,
                SociedadeAdms = registro.SociedadeAdms
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var _errosValidacoes = false;
            if (!ModelState.IsValid)
                _errosValidacoes = true;

            var _config = _context.AppPerfil
                .Include(x => x.AppConfiguracoes)
                .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                .FirstOrDefault();

            var registro =
                _context
                .Construtoras
                .Where(x => x.Id == Construtora.Id)
                .FirstOrDefault();

            registro.Bairro = Construtora.Bairro;
            registro.CEP = Construtora.CEP;
            registro.Cidade = Construtora.Cidade;
            registro.CNPJ = Construtora.CNPJ;
            registro.Complemento = Construtora.Complemento;
            registro.DTHR = Construtora.DTHR;
            registro.Email = Construtora.Email;
            registro.Estado = Construtora.Estado;
            registro.Fone = Construtora.Fone;
            registro.Logradouro = Construtora.Logradouro;
            registro.LogradouroNum = Construtora.LogradouroNum;
            registro.NomeFantasia = Construtora.NomeFantasia;
            registro.Pais = Construtora.Pais;
            registro.RazaoSocial = Construtora.RazaoSocial;
            registro.Website = Construtora.Website;
            registro.AlertaSobreRiscos = Construtora.AlertaSobreRiscos;
            registro.CaracOfertaTribuAplicavel = Construtora.CaracOfertaTribuAplicavel;
            registro.ComunPrestInfoContAposOferta = Construtora.ComunPrestInfoContAposOferta;
            registro.EstudoViabEcoFinanc = Construtora.EstudoViabEcoFinanc;
            registro.IncorpConstrut = Construtora.IncorpConstrut;
            registro.InfoPlanoNegocios = Construtora.InfoPlanoNegocios;
            registro.InfoRemunPlataforma = Construtora.InfoRemunPlataforma;
            registro.InfoValorMobOfertado = Construtora.InfoValorMobOfertado;
            registro.OutrasInfos = Construtora.OutrasInfos;
            registro.SetorAtuacaoHist = Construtora.SetorAtuacaoHist;
            registro.SociedadeAdms = Construtora.SociedadeAdms;
            if (Construtora.Imagem != null)
            {
                var _imagemLogotipo =
                    await VerificadoresRetornos
                    .EnviarImagemAzure(Construtora.Imagem, 550000, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                    registro.Logotipo = _imagemLogotipo;
                else
                {
                    ModelState.AddModelError(string.Empty, "A imagem é muito grande");
                    _errosValidacoes = true;
                }
            }

            if (_errosValidacoes)
            {
                return Page();
            }

            _context.Attach(registro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BlocoProjInvestimentoExists(BlocoProjInvestimento.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("./Index");
        }
    }
}