using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HH2I.Areas.Data
{
    using global::House2Invest.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    namespace House2Invest.Data
    {
        public class ApplicationDbContext : IdentityDbContext<UsuarioApp>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            /* ENTIDADES */
            public DbSet<SEO_Visita> SEO_Visitas { get; set; }
            public DbSet<AppPerfil> AppPerfil { get; set; }
            public DbSet<AppConfiguracoes> AppConfiguracoes { get; set; }
            public DbSet<AppConfiguracoes_Aplicativo> AppConfiguracoes_Aplicativo { get; set; }
            public DbSet<AppConfiguracoes_Azure> AppConfiguracoes_Azure { get; set; }
            public DbSet<GaleriaPerfilAlbum> GaleriaPerfilAlbum { get; set; }
            public DbSet<GaleriaPerfilImagem> GaleriaPerfilImagem { get; set; }
            public DbSet<BlocoProjInvestimento> BlocoProjInvestimentos { get; set; }
            public DbSet<BlocoProjInvestimento_ItemDoc> BlocoProjInvestimento_ItemDocs { get; set; }
            public DbSet<BlocoProjInvestimentoValor> BlocoProjInvestimentoValores { get; set; }
            public DbSet<BlocoProjInvestimentoComentario> BlocoProjInvestimentoComentarios { get; set; }
            public DbSet<INVEST_ModeloDoc> INVEST_ModeloDocs { get; set; }
            public DbSet<INVEST_LancamentoDoc> INVEST_LancamentoDocs { get; set; }
            public DbSet<INVEST_LancamentoImagem> INVEST_LancamentoImagens { get; set; }
            public DbSet<INVEST_Lancamento> INVEST_Lancamentos { get; set; }
            public DbSet<LOGCENTRAL> LOGCENTRALs { get; set; }
            public DbSet<LOGACOESUSU> LOGACOESUSUs { get; set; }
            public DbSet<tblHubConversa> tblHubConversas { get; set; }
            public DbSet<tblHubCliente> tblHubClientes { get; set; }
            public DbSet<PreferSalaVIP> PreferSalaVIPs { get; set; }
            public DbSet<tblUsuSalaVIP> tblUsuSalaVIPs { get; set; }
            public DbSet<INVEST_ControleTransf> INVEST_ControleTransfs { get; set; }
            public DbSet<HgGeoIp> HgGeoIps { get; set; }
            public DbSet<ResultsGeoIp> ResultsGeoIps { get; set; }
            public DbSet<HgGeoIp_Pais> HgGeoIp_Paises { get; set; }
            public DbSet<HgGeoIp_Pais_Flag> HgGeoIp_Pais_Flags { get; set; }
            public DbSet<TaxaMercado> TaxaMercados { get; set; }
            public DbSet<Construtora> Construtoras { get; set; }
            public DbSet<TaxaGLOBAL> TaxasGLOBAIS { get; set; }
            public DbSet<InvestimentoDocUsuario> InvestimentoDocUsuarios { get; set; }
            public DbSet<InvestimentoConfirmacao> InvestimentoConfirmacoes { get; set; }
            public DbSet<DUMPSQL> DUMPSQL { get; set; }
            public DbSet<FAQ> FAQ { get; set; }
            public DbSet<FAQItem> FAQItens { get; set; }
            public DbSet<Transferencia> Tranferencias { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<AppConfiguracoes_Aplicativo>().HasIndex(x => new { x.CPFCNPJ }).IsUnique();
                modelBuilder.Entity<AppConfiguracoes_Aplicativo>().HasIndex(x => new { x.Empresa }).IsUnique();
                modelBuilder.Entity<AppConfiguracoes>().HasIndex(x => new { x.Descricao }).IsUnique();
                modelBuilder.Entity<AppConfiguracoes>().HasIndex(x => new { x.URLExibicao }).IsUnique();
                modelBuilder.Entity<AppConfiguracoes>().HasIndex(x => new { x.Descricao, x.URLExibicao, x.AppConfiguracoes_AplicativoId, x.AppConfiguracoes_AzureId }).IsUnique();
                modelBuilder.Entity<AppPerfil>().HasIndex(x => new { x.AppConfiguracoesId }).IsUnique();

                //--------------------------------------------------------------------------------
                // DESABILITA DELETE EM CASCATA
                //--------------------------------------------------------------------------------
                foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }
                //var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                //    .SelectMany(t => t.GetForeignKeys())
                //    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

                //foreach (var fk in cascadeFKs)
                //    fk.DeleteBehavior = DeleteBehavior.Restrict;
                //--------------------------------------------------------------------------------

                base.OnModelCreating(modelBuilder);

                //modelBuilder.Entity<FooBar>().Property(x => x.Secret).HasMaxLength(20);
            }
        }
    }
}
