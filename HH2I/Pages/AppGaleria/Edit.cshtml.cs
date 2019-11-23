using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
namespace House2Invest.Pages.AppGaleria
{
    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public EditModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public Models.GaleriaPerfilAlbum GaleriaPerfilAlbum { get; set; }
        [BindProperty]
        public int AppPerfilId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GaleriaPerfilAlbum = await _context.GaleriaPerfilAlbum.FirstOrDefaultAsync(m => m.Id == id);

            if (GaleriaPerfilAlbum == null)
            {
                return NotFound();
            }

            AppPerfilId = _context.AppPerfil.FirstOrDefault().Id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var _totaldeelementos = Request.Form.Count - 1;
            var _listaimagens = new List<ImagensEnvio>();
            var _idperfil = AppPerfilId;

            // PEGO A LISTA DE IMAGENS QUE EXISTE NO BANCO PARA COMPARAR COM O MODELO ENVIADO
            var _Listaimagensalbum =
                _context.GaleriaPerfilImagem
                .Where(x => x.GaleriaPerfilAlbumId == GaleriaPerfilAlbum.Id)
                .ToList();

            // OBTENDO O REGISTRO EXISTENTE NO BANCO PARA ALTERACAO COM O MODELO ENVIADO
            var registro =
                _context
                .GaleriaPerfilAlbum
                .Where(x => x.Id == GaleriaPerfilAlbum.Id)
                .FirstOrDefault();

            registro.Nome = GaleriaPerfilAlbum.Nome;
            registro.Descricao = GaleriaPerfilAlbum.Descricao;

            _context.Attach(registro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // CARREGO UMA LISTA COM AS IMAGENS ENVIADAS PELO MODELO
            var _listaModel = new List<GaleriaPerfilImagem>();
            for (int i = 0; i < _totaldeelementos; i++)
            {
                var _nomeimg = Request.Form["inputarq_" + i];
                var _des = Request.Form["descricao_" + i].ToString();
                var _idimg = Request.Form["idgaleriaimagem_" + i].ToString();
                var _urlimg = Request.Form["urlgaleriaimagem_" + i].ToString();
                _des = string.IsNullOrEmpty(_des) ? "" : _des;

                if (!string.IsNullOrEmpty(_idimg))
                {
                    var _imagem = new GaleriaPerfilImagem()
                    {
                        Id = Convert.ToInt32(_idimg),
                        Descricao = _des,
                        GaleriaPerfilAlbumId = GaleriaPerfilAlbum.Id,
                        Url = _urlimg
                    };

                    _listaModel.Add(_imagem);
                }
            }

            // RODO A LISTA CARREGADA E COMPARO COM A LISTA ENVIADA DO MODELO
            // VERIFICO SE FORAM EXCLUÍDAS IMAGENS DO ÁLBUM
            foreach (var _imagem in _Listaimagensalbum.OrderBy(x => x.Id))
            {
                var _imagemExiste = _listaModel.Where(x => x.Id == _imagem.Id).FirstOrDefault();

                // NÃO ACHEI NA LISTA ENVIADA
                if (_imagemExiste == null)
                {
                    // APAGO DO BANCO E REMOVO O BLOB DA NUVEM
                    var _exc_appgaleria_imagem =
                        _context.GaleriaPerfilImagem
                        .Where(x => x.Id == _imagem.Id).FirstOrDefault();

                    _context.GaleriaPerfilImagem.Remove(_exc_appgaleria_imagem);
                    await _context.SaveChangesAsync();

                    // PEGA NOME DO ARQUIVO
                    string _nomedoarq = "";
                    Uri uri = new Uri(_imagem.Url);
                    _nomedoarq = System.IO.Path.GetFileName(uri.LocalPath);

                    var _config = _context.AppPerfil
                        .Include(x => x.AppConfiguracoes)
                        .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                        .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                        .FirstOrDefault();

                    await VerificadoresRetornos
                        .ApagarBlob(
                        _nomedoarq,
                        _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName,
                        _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey,
                        _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz,
                        _config.AppConfiguracoes.AppConfiguracoes_Azure.UsarSimuladorLocal,
                        _config.AppConfiguracoes.AppConfiguracoes_Azure.EnderecoArmazLocal);
                }
                // ALTERO A DESCRICAO DA IMAGEM
                else
                {
                    var _ImagemEditada =
                        _context.GaleriaPerfilImagem
                        .Where(x => x.Id == _imagemExiste.Id).FirstOrDefault();

                    _ImagemEditada.Descricao = _imagemExiste.Descricao;

                    _context.Attach(_ImagemEditada).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }

            // NOVAS IMAGENS ADICIONADAS AO ALBUM
            if (Request.Form.Files.Count > 0)
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
                            GaleriaPerfilAlbumId = GaleriaPerfilAlbum.Id,
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
                foreach (var imagem in _listaimagens)
                {
                    if (!string.IsNullOrEmpty(imagem.Url))
                    {
                        _listarange.Add(new Models.GaleriaPerfilImagem()
                        {
                            GaleriaPerfilAlbumId = imagem.GaleriaPerfilAlbumId,
                            Descricao = imagem.Descricao,
                            Url = imagem.Url
                        });
                    }
                }

                if (_listarange.Count > 0)
                {
                    await _context.GaleriaPerfilImagem.AddRangeAsync(_listarange);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}