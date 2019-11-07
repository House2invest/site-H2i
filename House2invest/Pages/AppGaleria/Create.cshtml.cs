using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models.ViewModels;
namespace House2Invest.Pages.AppGaleria
{
    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public Models.GaleriaPerfilAlbum GaleriaPerfilAlbum { get; set; }
        [BindProperty]
        public int AppPerfilId { get; set; }

        public IActionResult OnGet()
        {
            AppPerfilId = _context.AppPerfil.FirstOrDefault().Id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var _totaldeelementos = Request.Form.Count - 1;
            var _listaimagens = new List<ImagensEnvio>();
            var _idperfil = AppPerfilId;

            if (Request.Form.Files.Count > 0)
            {
                // CRIA ALBUM
                var _novoalbum = new Models.GaleriaPerfilAlbum()
                {
                    AppPerfilId = _idperfil,
                    Nome = Request.Form["GaleriaPerfilAlbum.Nome"].ToString(),
                    Descricao = string.IsNullOrEmpty(Request.Form["GaleriaPerfilAlbum.Descricao"].ToString()) ? "" : Request.Form["GaleriaPerfilAlbum.Descricao"].ToString()
                };

                // SALVA ALBUM
                await _context.GaleriaPerfilAlbum.AddAsync(_novoalbum);
                await _context.SaveChangesAsync();

                if (_novoalbum.Id > 0)
                {
                    for (int i = 0; i < _totaldeelementos; i++)
                    {
                        var _nomeimg = Request.Form["inputarq_" + i];
                        var _des = Request.Form["descricao_" + i].ToString();
                        _des = string.IsNullOrEmpty(_des) ? "" : _des;

                        var _buscafilearray =
                            Request.Form.Files
                            .Where(x => x.FileName == _nomeimg).FirstOrDefault();

                        if (_buscafilearray != null)
                        {
                            _listaimagens.Add(new ImagensEnvio()
                            {
                                GaleriaPerfilAlbumId = _novoalbum.Id,
                                Url = _buscafilearray.FileName.ToString(),
                                Descricao = _des,
                                Arquivo = _buscafilearray
                            });
                        }
                    }

                    var _config = _context.AppPerfil
                        .Include(x => x.AppConfiguracoes)
                        .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                        .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                        .FirstOrDefault();

                    foreach (var item in _listaimagens)
                    {
                        var _imagemLogotipo =
                            await VerificadoresRetornos
                            .EnviarImagemAzure(item.Arquivo, 512000, 0, 0,
                            _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName,
                            _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey,
                            _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz,
                            _config.AppConfiguracoes.AppConfiguracoes_Azure.UsarSimuladorLocal,
                            _config.AppConfiguracoes.AppConfiguracoes_Azure.EnderecoArmazLocal);

                        Uri uriResult;
                        bool result = Uri.TryCreate(_imagemLogotipo, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                        if (result)
                            item.Url = _imagemLogotipo;
                        else
                            item.Url = "";
                    }

                    var _listarange = new List<Models.GaleriaPerfilImagem>();
                    foreach (var registro in _listaimagens)
                    {
                        if (!string.IsNullOrEmpty(registro.Url))
                        {
                            _listarange.Add(new Models.GaleriaPerfilImagem()
                            {
                                GaleriaPerfilAlbumId = registro.GaleriaPerfilAlbumId,
                                Descricao = registro.Descricao,
                                Url = registro.Url
                            });
                        }
                    }

                    if (_listarange.Count > 0)
                    {
                        await _context.GaleriaPerfilImagem.AddRangeAsync(_listarange);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Você precisa selecionar ao menos uma imagem para criar um álbum. Clique no botão CARREGAR IMAGENS para selecionar à partir do seu dispositivo.");
            }

            return RedirectToPage("./Index");
        }
    }
}