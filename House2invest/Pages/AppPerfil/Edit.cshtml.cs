using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models.ViewModels;
namespace House2Invest.Pages.AppPerfil
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public EditModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public Models.AppPerfil AppPerfil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppPerfil = await _context.AppPerfil.Include(a => a.AppConfiguracoes).FirstOrDefaultAsync(m => m.Id == id);

            if (AppPerfil == null)
            {
                return NotFound();
            }
            ViewData["AppConfiguracoesId"] = new SelectList(_context.AppConfiguracoes, "Id", "Descricao");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AppPerfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppPerfilExists(AppPerfil.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }






        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        // UPLOAD DE IMAGENS COM DESCRICAO
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //public async Task<IActionResult> OnPostEnviarImagensAsync(List<IFormFile> file)
        //public async Task<IActionResult> OnPostEnviarImagensAsync()
        //{
        //    var _totaldeelementos = Request.Form.Count - 1;
        //    var _listaimagens = new List<ImagensEnvio>();
        //    var _idperfil = Request.Form["AppPerfil.Id"];
        //    for (int i = 0; i < _totaldeelementos; i++)
        //    {
        //        var _nomeimg = Request.Form["inputarq_" + i];
        //        var _img = Request.Form["inputimg_" + i];
        //        var _des = Request.Form["descricao_" + i];
        //        if (!string.IsNullOrEmpty(_img) && !string.IsNullOrEmpty(_des))
        //        {
        //            var _buscafilearray = Request.Form.Files.Where(x => x.FileName == _nomeimg).FirstOrDefault();
        //            _listaimagens.Add(new ImagensEnvio()
        //            {
        //                AppPerfilId = Convert.ToInt32(_idperfil),
        //                Url = _buscafilearray.FileName.ToString(),
        //                //    .Replace("data:image/png;base64,", "")
        //                //    .Replace("data:image/jpeg;base64,", "")
        //                //    .Replace("data:image/jpg;base64,", ""),
        //                Descricao = _des,
        //                Arquivo = _buscafilearray
        //                //    Extensao = _extensao
        //            });

        //            //var _extensao = "";
        //            //if (_img.ToString().Contains("image/png"))
        //            //    _extensao = "png";
        //            //if (_img.ToString().Contains("image/jpg") || _img.ToString().Contains("image/jpeg"))
        //            //    _extensao = "jpg";
        //            //_listaimagens.Add(new ImagensEnvio()
        //            //{
        //            //    AppPerfilId = Convert.ToInt32(_idperfil),
        //            //    Url = _img.ToString()
        //            //    .Replace("data:image/png;base64,", "")
        //            //    .Replace("data:image/jpeg;base64,", "")
        //            //    .Replace("data:image/jpg;base64,", ""),
        //            //    Descricao = _des,
        //            //    Extensao = _extensao
        //            //});
        //        }
        //    }

        //    var _config = _context.AppPerfil
        //        .Include(x => x.AppConfiguracoes)
        //        .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
        //        .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
        //        .FirstOrDefault();

        //    foreach (var item in _listaimagens)
        //    {
        //        //var _imagem = Base64ToImage(item.Url);
        //        //var _imagemLogotipo =
        //        //    await VerificadoresRetornos
        //        //    .EnviarImagemAzure(_imagem, 307200, item.Extensao, 0, 0,
        //        //    _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName,
        //        //    _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey,
        //        //    _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

        //        var _imagemLogotipo =
        //            await VerificadoresRetornos
        //            .EnviarImagemAzure(item.Arquivo, 307200, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

        //        if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
        //            item.Url = _imagemLogotipo;
        //    }

        //    var _listarange = new List<Models.GaleriaPerfilImagem>();
        //    foreach (var registro in _listaimagens)
        //    {
        //        _listarange.Add(new Models.GaleriaPerfilImagem()
        //        {
        //            AppPerfilId = registro.AppPerfilId,
        //            Descricao = registro.Descricao,
        //            Url = registro.Url
        //        });
        //    }

        //    await _context.GaleriaPerfil.AddRangeAsync(_listaimagens);
        //    await _context.SaveChangesAsync();

        //    return Page();
        //}
        //public System.Drawing.Image Base64ToImage(string base64String)
        //{
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
        //    //System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
        //    return image;
        //}
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        // UPLOAD DE IMAGENS COM DESCRICAO
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------



        private bool AppPerfilExists(int id)
        {
            return _context.AppPerfil.Any(e => e.Id == id);
        }
    }
}
