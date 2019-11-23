namespace House2Invest.Migrations
{
    using House2Invest.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    [DbContext(typeof(ApplicationDbContext)), Migration("20190612202339_inicio")]
    public class Inicio : Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062").HasAnnotation("Relational:MaxIdentifierLength", (int)0x80).HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
            modelBuilder.Entity("House2Invest.Models.AppConfiguracoes", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("AppConfiguracoes_AplicativoId");
                b.Property<int>("AppConfiguracoes_AzureId");
                b.Property<string>("CaminhoAbsolutoTema");
                b.Property<DateTime>("DTHR");
                b.Property<string>("Descricao").IsRequired(true);
                b.Property<bool>("NovosUsuarios");
                b.Property<bool>("NovosUsuarios_NivelADM");
                b.Property<string>("Tema").IsRequired(true);
                b.Property<string>("URLExibicao").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "AppConfiguracoes_AplicativoId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "AppConfiguracoes_AzureId" };
                b.HasIndex(textArray3);
                string[] textArray4 = new string[] { "Descricao" };
                b.HasIndex(textArray4).IsUnique(true);
                string[] textArray5 = new string[] { "URLExibicao" };
                b.HasIndex(textArray5).IsUnique(true);
                string[] textArray6 = new string[] { "Descricao", "URLExibicao", "AppConfiguracoes_AplicativoId", "AppConfiguracoes_AzureId" };
                b.HasIndex(textArray6).IsUnique(true);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AppConfiguracoes");
                object[] objArray1 = new object[] { new {
                    Id = 1,
                    AppConfiguracoes_AplicativoId = 1,
                    AppConfiguracoes_AzureId = 1,
                    CaminhoAbsolutoTema = "",
                    DTHR = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x338, (DateTimeKind) DateTimeKind.Local).AddTicks(0x1103L),
                    Descricao = "Tema padr\x00e3o",
                    NovosUsuarios = false,
                    NovosUsuarios_NivelADM = true,
                    Tema = "_Layout",
                    URLExibicao = "padrao"
                } };
                b.HasData(objArray1);
            });
            modelBuilder.Entity("House2Invest.Models.AppConfiguracoes_Aplicativo", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<string>("Bairro").IsRequired(true);
                b.Property<string>("CEP").IsRequired(true);
                b.Property<string>("CPFCNPJ").IsRequired(true);
                b.Property<string>("Celular");
                b.Property<string>("Cidade").IsRequired(true);
                b.Property<string>("Complemento");
                b.Property<DateTime>("DTHR");
                b.Property<string>("EmailContato").IsRequired(true);
                b.Property<string>("EmailSuporte").IsRequired(true);
                b.Property<string>("EmailVendas").IsRequired(true);
                b.Property<string>("Empresa").IsRequired(true);
                b.Property<string>("Estado").IsRequired(true);
                b.Property<string>("Fone").IsRequired(true);
                b.Property<string>("FoneRecados");
                b.Property<string>("LogotipoEmpresa");
                b.Property<string>("Logradouro").IsRequired(true);
                b.Property<string>("dumpSQLHost");
                b.Property<string>("dumpSQLPass");
                b.Property<string>("dumpSQLUser");
                b.Property<string>("mailFrom");
                b.Property<string>("mailToAdd");
                b.Property<string>("smtpCredentialsEmail");
                b.Property<string>("smtpCredentialsSenha");
                b.Property<bool>("smtpEnableSsl");
                b.Property<string>("smtpHost");
                b.Property<int>("smtpPort");
                b.Property<bool>("smtpUseDefaultCredentials");
                b.Property<string>("temporizaLmiteMaximoCancelaInvestimento");
                b.Property<string>("temporizaLmiteMaximoOfertaSuspensa");
                b.Property<string>("temporizaLmiteMaximoRevogaInvestimento");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "CPFCNPJ" };
                b.HasIndex(textArray2).IsUnique(true);
                string[] textArray3 = new string[] { "Empresa" };
                b.HasIndex(textArray3).IsUnique(true);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AppConfiguracoes_Aplicativo");
                object[] objArray1 = new object[] { new {
                    Id = 1,
                    Bairro = "JD. NOSSA SENHORA DO CARMO",
                    CEP = "08275-010",
                    CPFCNPJ = "14.581.834/0001-42",
                    Celular = "(11) 99881-4900",
                    Cidade = "SAO PAULO",
                    Complemento = "",
                    DTHR = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x339, (DateTimeKind) DateTimeKind.Local).AddTicks(0x802L),
                    EmailContato = "leandrodiascarvalho@hotmail.com",
                    EmailSuporte = "leandrodiascarvalho@hotmail.com",
                    EmailVendas = "leandrodiascarvalho@hotmail.com",
                    Empresa = "DEPOIS DA LINHA",
                    Estado = "SP",
                    Fone = "(11) 99881-4900",
                    FoneRecados = "(11) 99881-4900",
                    LogotipoEmpresa = "/images/avatar-depois-da-linha.png",
                    Logradouro = "MATEUS MENDES PEREIRA, 312",
                    dumpSQLHost = "66EAF4C0C88A6F125E6743DF57CEF052",
                    dumpSQLPass = "B490B0B3AD983905BE51BE383C8F9D829B11776439CF9D86E260DB21BD141904",
                    dumpSQLUser = "711429BCCA6C1DACA75A01DF6DA3E941",
                    mailFrom = "F517408DFEF409845DE190A43EA194F50EE16B97A7EBFD67DEE0D257133CC958",
                    mailToAdd = "5CFDDB0D72BEAE3950A6066C5AD471C4CC821BA669C5A7634F1B709064F1E04666DF0B48BB967A6F52A81E2376C3723F839C239801C4B71C3FE178CB57964AEC98B15756417D5ACE06F1B12D3BE207B5",
                    smtpCredentialsEmail = "F517408DFEF409845DE190A43EA194F50EE16B97A7EBFD67DEE0D257133CC958",
                    smtpCredentialsSenha = "DE183F10391850758E21842DFEFA2B3B",
                    smtpEnableSsl = true,
                    smtpHost = "BE1D8EA6948053684AC62657FBAB58B3",
                    smtpPort = 0x24b,
                    smtpUseDefaultCredentials = false,
                    temporizaLmiteMaximoCancelaInvestimento = "D3F9EDBE6ABC40A63D5CF85B24F666A8",
                    temporizaLmiteMaximoOfertaSuspensa = "B181370B7EF0D09FA17561E1A8310E31",
                    temporizaLmiteMaximoRevogaInvestimento = "ED123C03D2D7FC5F378DD4DB227C16FB"
                } };
                b.HasData(objArray1);
            });
            modelBuilder.Entity("House2Invest.Models.AppConfiguracoes_Azure", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("EnderecoArmazLocal");
                b.Property<bool>("UsarSimuladorLocal");
                b.Property<string>("_azureblob_AccountKey").IsRequired(true);
                b.Property<string>("_azureblob_AccountName").IsRequired(true);
                b.Property<string>("_azureblob_ContainerRaiz").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AppConfiguracoes_Azure");
                object[] objArray1 = new object[] { new {
                    Id = 1,
                    DTHR = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x339, (DateTimeKind) DateTimeKind.Local).AddTicks(0x164eL),
                    EnderecoArmazLocal = "",
                    UsarSimuladorLocal = false,
                    _azureblob_AccountKey = "B7F9DD2BA3180A2AC1AE87482117BC9FC598FFC24B18402C434CEC6AC354FCBFC1DF2BBC848FB9D161B59F460A343838B3A66E1F7B0DCC9B0C25EF922D49FA47A438E3822FDC43DA436A583387945E82AEDCE81C4F2BB57BA94D4D46CC29A31C",
                    _azureblob_AccountName = "416B955DF5FCD4244EC8548581DC9BA3",
                    _azureblob_ContainerRaiz = "EAB44E95599081721154E4905C474E42"
                } };
                b.HasData(objArray1);
            });
            modelBuilder.Entity("House2Invest.Models.AppPerfil", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("AppConfiguracoesId");
                b.Property<DateTime>("DTHR");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "AppConfiguracoesId" };
                b.HasIndex(textArray2).IsUnique(true);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AppPerfil");
                object[] objArray1 = new object[] { new {
                    Id = 1,
                    AppConfiguracoesId = 1,
                    DTHR = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x339, (DateTimeKind) DateTimeKind.Local).AddTicks(0x1bbdL)
                } };
                b.HasData(objArray1);
            });
            modelBuilder.Entity("House2Invest.Models.BlocoProjInvestimento", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<string>("AndamentoObra");
                b.Property<string>("AndamentoObraAcabamento");
                b.Property<bool>("Ativo");
                b.Property<bool>("BlocoProjInvest_ExibTitulo");
                b.Property<int>("ConstrutoraId");
                b.Property<string>("Contador_DataFinal");
                b.Property<bool>("Contador_Exib");
                b.Property<string>("Contato_Bairro").IsRequired(true);
                b.Property<string>("Contato_CEP").IsRequired(true);
                b.Property<string>("Contato_Cidade").IsRequired(true);
                b.Property<string>("Contato_Complemento");
                b.Property<string>("Contato_Estado").IsRequired(true);
                b.Property<string>("Contato_Logradouro").IsRequired(true);
                b.Property<string>("Contato_LogradouroNum");
                b.Property<DateTime>("DTHR");
                b.Property<DateTime>("DataLimiteSuspensao");
                b.Property<string>("DescricaoDetalhadaProjeto").IsRequired(true);
                b.Property<int>("GaleriaPerfilAlbumId");
                b.Property<string>("LanceMinimo");
                b.Property<string>("LinkVideoProjeto");
                b.Property<string>("Rentabilidade_PRE_FIM");
                b.Property<string>("Rentabilidade_PRE_INI");
                b.Property<string>("Rentabilidade_PRE_TIT");
                b.Property<string>("Rentabilidade_ROI_FIM");
                b.Property<string>("Rentabilidade_ROI_INI");
                b.Property<string>("Rentabilidade_ROI_TIT");
                b.Property<string>("Rentabilidade_TIR_FIM");
                b.Property<string>("Rentabilidade_TIR_INI");
                b.Property<string>("Rentabilidade_TIR_TIT");
                b.Property<double>("SaldoReservado");
                b.Property<string>("Status");
                b.Property<string>("Titulo").IsRequired(true);
                b.Property<string>("UrlImgPrinc");
                b.Property<string>("Valor");
                b.Property<string>("ValorMinimoDocs");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "ConstrutoraId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "GaleriaPerfilAlbumId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "BlocoProjInvestimentos");
            });
            modelBuilder.Entity("House2Invest.Models.BlocoProjInvestimentoComentario", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("BlocoProjInvestimentoId");
                b.Property<string>("Comentario").IsRequired(true);
                b.Property<DateTime>("DTHR");
                b.Property<string>("UsuarioAppId").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "BlocoProjInvestimentoId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "BlocoProjInvestimentoComentarios");
            });
            modelBuilder.Entity("House2Invest.Models.BlocoProjInvestimentoValor", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("BlocoProjInvestimentoId");
                b.Property<DateTime>("DTHR");
                b.Property<string>("UsuarioAppId").IsRequired(true);
                b.Property<double>("Valor");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "BlocoProjInvestimentoId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "BlocoProjInvestimentoValores");
            });
            modelBuilder.Entity("House2Invest.Models.BlocoProjInvestimento_ItemDoc", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("BlocoProjInvestimentoId");
                b.Property<DateTime>("DTHR");
                b.Property<int>("INVEST_ModeloDocId");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "BlocoProjInvestimentoId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "INVEST_ModeloDocId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "BlocoProjInvestimento_ItemDocs");
            });
            modelBuilder.Entity("House2Invest.Models.Construtora", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<string>("AlertaSobreRiscos");
                b.Property<string>("Bairro");
                b.Property<string>("CEP");
                b.Property<string>("CNPJ");
                b.Property<string>("CaracOfertaTribuAplicavel");
                b.Property<string>("Cidade");
                b.Property<string>("Complemento");
                b.Property<string>("ComunPrestInfoContAposOferta");
                b.Property<DateTime>("DTHR");
                b.Property<string>("Email");
                b.Property<string>("Estado");
                b.Property<string>("EstudoViabEcoFinanc");
                b.Property<string>("Fone");
                b.Property<string>("IncorpConstrut");
                b.Property<string>("InfoPlanoNegocios");
                b.Property<string>("InfoRemunPlataforma");
                b.Property<string>("InfoValorMobOfertado");
                b.Property<string>("Logotipo");
                b.Property<string>("Logradouro");
                b.Property<string>("LogradouroNum");
                b.Property<string>("NomeFantasia").IsRequired(true);
                b.Property<string>("OutrasInfos");
                b.Property<string>("Pais");
                b.Property<string>("RazaoSocial").IsRequired(true);
                b.Property<string>("SetorAtuacaoHist");
                b.Property<string>("SociedadeAdms");
                b.Property<string>("Website");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "Construtoras");
            });
            modelBuilder.Entity("House2Invest.Models.DUMPSQL", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("URLBAK");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "DUMPSQL");
            });
            modelBuilder.Entity("House2Invest.Models.FAQ", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("Descricao");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "FAQ");
            });
            modelBuilder.Entity("House2Invest.Models.FAQItem", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<int>("FAQId");
                b.Property<int>("Ordem");
                b.Property<string>("Pergunta");
                b.Property<string>("Resposta");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "FAQId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "FAQItens");
            });
            modelBuilder.Entity("House2Invest.Models.GaleriaPerfilAlbum", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("AppPerfilId");
                b.Property<DateTime>("DTHR");
                b.Property<string>("Descricao");
                b.Property<string>("Nome").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "AppPerfilId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "GaleriaPerfilAlbum");
            });
            modelBuilder.Entity("House2Invest.Models.GaleriaPerfilImagem", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("Descricao");
                b.Property<int>("GaleriaPerfilAlbumId");
                b.Property<string>("Url");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "GaleriaPerfilAlbumId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "GaleriaPerfilImagem");
            });
            modelBuilder.Entity("House2Invest.Models.HgGeoIp", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<int>("ResultsGeoIpId");
                b.Property<string>("by");
                b.Property<float>("execution_time");
                b.Property<bool>("from_cache");
                b.Property<bool>("valid_key");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "ResultsGeoIpId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "HgGeoIps");
            });
            modelBuilder.Entity("House2Invest.Models.HgGeoIp_Pais", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<int>("HgGeoIp_Pais_FlagId");
                b.Property<string>("calling_code");
                b.Property<string>("capital");
                b.Property<string>("code");
                b.Property<string>("name");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "HgGeoIp_Pais_FlagId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "HgGeoIp_Paises");
            });
            modelBuilder.Entity("House2Invest.Models.HgGeoIp_Pais_Flag", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("png_16");
                b.Property<string>("svg");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "HgGeoIp_Pais_Flags");
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_ControleTransf", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("BlocoProjInvestimentosId");
                b.Property<DateTime>("DTHR");
                b.Property<int>("IdCompensacao");
                b.Property<string>("Status").IsRequired(true);
                b.Property<string>("UsuarioAppId").IsRequired(true);
                b.Property<double>("Valor");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "BlocoProjInvestimentosId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "INVEST_ControleTransfs");
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_Lancamento", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("BlocoProjInvestimentosId");
                b.Property<DateTime>("DTHR");
                b.Property<DateTime>("DataLimiteCancelamento");
                b.Property<string>("PerfilInvestidorInformado").IsRequired(true);
                b.Property<string>("Status").IsRequired(true);
                b.Property<string>("TP").IsRequired(true);
                b.Property<string>("UsuarioAppId").IsRequired(true);
                b.Property<double>("Valor");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "BlocoProjInvestimentosId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "INVEST_Lancamentos");
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_LancamentoDoc", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<int>("INVEST_LancamentoId");
                b.Property<int>("INVEST_ModeloDocId");
                b.Property<string>("TP").IsRequired(true);
                b.Property<string>("URLDoc").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "INVEST_LancamentoId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "INVEST_ModeloDocId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "INVEST_LancamentoDocs");
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_LancamentoImagem", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<int>("INVEST_LancamentoId");
                b.Property<string>("URLComprovTransf");
                b.Property<string>("URLPerfilInvest");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "INVEST_LancamentoId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "INVEST_LancamentoImagens");
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_ModeloDoc", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("Hyperlink");
                b.Property<string>("Texto").IsRequired(true);
                b.Property<string>("Titulo").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "INVEST_ModeloDocs");
            });
            modelBuilder.Entity("House2Invest.Models.InvestimentoConfirmacao", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("BlocoProjInvestimentoId");
                b.Property<bool>("Confirmado");
                b.Property<DateTime>("DTHR");
                b.Property<int>("INVEST_LancamentoId");
                b.Property<string>("Token");
                b.Property<string>("UsuarioAppId");
                b.Property<double>("Valor");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "BlocoProjInvestimentoId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "INVEST_LancamentoId" };
                b.HasIndex(textArray3);
                string[] textArray4 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray4);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "InvestimentoConfirmacoes");
            });
            modelBuilder.Entity("House2Invest.Models.InvestimentoDocUsuario", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("BlocoProjInvestimentoId");
                b.Property<DateTime>("DTHR");
                b.Property<string>("URL");
                b.Property<string>("UsuarioAppId");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "BlocoProjInvestimentoId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "InvestimentoDocUsuarios");
            });
            modelBuilder.Entity("House2Invest.Models.LOGACOESUSU", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("Url");
                b.Property<string>("UsuarioAppId");
                b.Property<string>("scrollLeft");
                b.Property<string>("scrollTop");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "LOGACOESUSUs");
            });
            modelBuilder.Entity("House2Invest.Models.LOGCENTRAL", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<string>("ACAO");
                b.Property<DateTime>("DTHR");
                b.Property<string>("ICOMENS");
                b.Property<string>("IP");
                b.Property<string>("MENSAGEM");
                b.Property<string>("STATUS");
                b.Property<string>("TIPO");
                b.Property<string>("UsuarioAppCriadorId");
                b.Property<string>("UsuarioAppId");
                b.Property<double>("VALOR");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "UsuarioAppCriadorId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray3);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "LOGCENTRALs");
            });
            modelBuilder.Entity("House2Invest.Models.PreferSalaVIP", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<bool>("BarrasFixas");
                b.Property<bool>("CabecalhoFixo");
                b.Property<DateTime>("DTHR");
                b.Property<bool>("FormatoCaixa");
                b.Property<bool>("MenuFixo");
                b.Property<bool>("RodapeFixo");
                b.Property<string>("Tema");
                b.Property<bool>("TopoFixo");
                b.Property<string>("UsuarioAppId").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "PreferSalaVIPs");
            });
            modelBuilder.Entity("House2Invest.Models.ResultsGeoIp", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<int>("HgGeoIp_PaisId");
                b.Property<string>("address");
                b.Property<string>("city");
                b.Property<string>("continent");
                b.Property<string>("continent_code");
                b.Property<string>("country_name");
                b.Property<string>("latitude");
                b.Property<string>("longitude");
                b.Property<string>("region");
                b.Property<string>("region_code");
                b.Property<string>("type");
                b.Property<string>("woeid");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "HgGeoIp_PaisId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "ResultsGeoIps");
            });
            modelBuilder.Entity("House2Invest.Models.SEO_Visita", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("IdUsu");
                b.Property<string>("URL");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "SEO_Visitas");
            });
            modelBuilder.Entity("House2Invest.Models.TaxaGLOBAL", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("descricao").IsRequired(true);
                b.Property<string>("informacoes");
                b.Property<bool>("pre_selec");
                b.Property<string>("valor").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "TaxasGLOBAIS");
            });
            modelBuilder.Entity("House2Invest.Models.TaxaMercado", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<float>("cdi");
                b.Property<string>("data");
                b.Property<float>("fator_diario");
                b.Property<float>("selic");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "TaxaMercados");
            });
            modelBuilder.Entity("House2Invest.Models.Transferencia", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<int>("BlocoProjInvestimentoId");
                b.Property<DateTime>("DTHR");
                b.Property<DateTime>("DataLimite");
                b.Property<int>("IdIncorporadora");
                b.Property<string>("IdUsu");
                b.Property<string>("URLComprovante");
                b.Property<double>("Valor");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "BlocoProjInvestimentoId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "Tranferencias");
            });
            modelBuilder.Entity("House2Invest.Models.UsuarioApp", delegate (EntityTypeBuilder b)
            {
                b.Property<string>("Id").ValueGeneratedOnAdd();
                b.Property<int>("AccessFailedCount");
                b.Property<int>("AppConfiguracoesId");
                b.Property<string>("AvatarUsuario");
                b.Property<string>("Bio");
                b.Property<string>("ConcurrencyStamp").IsConcurrencyToken(true);
                b.Property<string>("ContatoAutenticacao_Email");
                b.Property<string>("ContatoAutenticacao_EmailAlternativo");
                b.Property<string>("ContatoAutenticacao_Fone");
                b.Property<string>("ContatoAutenticacao_FoneAlternativo");
                b.Property<string>("Contato_Bairro");
                b.Property<string>("Contato_CEP");
                b.Property<string>("Contato_Cidade");
                b.Property<string>("Contato_Complemento");
                b.Property<string>("Contato_Escritorio");
                b.Property<string>("Contato_Estado");
                b.Property<string>("Contato_FoneCelular");
                b.Property<string>("Contato_FoneComercial");
                b.Property<string>("Contato_Logradouro");
                b.Property<string>("Contato_LogradouroNum");
                b.Property<string>("Contato_Pais");
                b.Property<string>("Contato_Website");
                b.Property<string>("Documentacao_CNPJ");
                b.Property<string>("Documentacao_CPF");
                b.Property<string>("Documentacao_RG");
                b.Property<string>("Documentacao_TPPessoa");
                b.Property<string>("Email").HasMaxLength(0x100);
                b.Property<bool>("EmailConfirmed");
                b.Property<string>("EstadoCivil");
                b.Property<string>("Financeiro_Banco_Ag");
                b.Property<string>("Financeiro_Banco_CC");
                b.Property<string>("Financeiro_Banco_Nome");
                b.Property<string>("Financeiro_Investidor_Perfil");
                b.Property<string>("Genero");
                b.Property<string>("ImagemFundoPerfil");
                b.Property<bool>("LockoutEnabled");
                b.Property<DateTimeOffset?>("LockoutEnd");
                b.Property<string>("MidiasSociais_Facebook");
                b.Property<string>("MidiasSociais_GooglePlus");
                b.Property<string>("MidiasSociais_Instagram");
                b.Property<string>("MidiasSociais_Linkedin");
                b.Property<string>("MidiasSociais_Pinterest");
                b.Property<string>("MidiasSociais_Twitter");
                b.Property<string>("MidiasSociais_Youtube");
                b.Property<DateTime?>("Nascimento");
                b.Property<string>("Nome");
                b.Property<string>("NormalizedEmail").HasMaxLength(0x100);
                b.Property<string>("NormalizedUserName").HasMaxLength(0x100);
                b.Property<string>("PasswordHash");
                b.Property<string>("PhoneNumber");
                b.Property<bool>("PhoneNumberConfirmed");
                b.Property<string>("SecurityStamp");
                b.Property<bool>("Sistema_AcessoBloqueado");
                b.Property<DateTime>("Sistema_DataDeclaracaoCienciaTermos");
                b.Property<bool>("Sistema_DeclaracaoCienciaTermos");
                b.Property<bool>("Sistema_DeclaracaoPessoaExposta");
                b.Property<string>("Sistema_FuncaoUsuario");
                b.Property<bool>("Sistema_NaoAparecerListaProjetos");
                b.Property<string>("Sistema_URLComprovanteResidencia");
                b.Property<string>("Sistema_URLFotoDoc");
                b.Property<string>("Sistema_URLSelfieDocFRENTE");
                b.Property<string>("Sistema_URLSelfieDocVERSO");
                b.Property<string>("Sobrenome");
                b.Property<string>("Trabalho_Cargo");
                b.Property<string>("Trabalho_Empresa");
                b.Property<string>("Trabalho_Profissao");
                b.Property<bool>("TwoFactorEnabled");
                b.Property<string>("UserName").HasMaxLength(0x100);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "AppConfiguracoesId" };
                b.HasIndex(textArray2);
                string[] textArray3 = new string[] { "NormalizedEmail" };
                RelationalIndexBuilderExtensions.HasName(b.HasIndex(textArray3), "EmailIndex");
                string[] textArray4 = new string[] { "NormalizedUserName" };
                RelationalIndexBuilderExtensions.HasFilter(RelationalIndexBuilderExtensions.HasName(b.HasIndex(textArray4).IsUnique(true), "UserNameIndex"), "[NormalizedUserName] IS NOT NULL");
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUsers");
                object[] objArray1 = new object[] { new {
                    Id = "b30b4d21-0f99-435e-acec-a2c672697b0f",
                    AccessFailedCount = 0,
                    AppConfiguracoesId = 1,
                    AvatarUsuario = "19C6B9DC189309182D3EDE85CDFCD3C0FA7E12357D852FAE54445547238E4BF0",
                    Bio = "7223201CBA30A22927EEE5E8009F3CFC",
                    ConcurrencyStamp = "101e6c5f-59c0-4544-a728-782ba76d0611",
                    ContatoAutenticacao_Email = "8CF74E568EA5B35D3835599521141757058C23F92DAB03337B452304016F5415",
                    ContatoAutenticacao_EmailAlternativo = "43436B5D54865325C2142528313460857B6E3DEA0C5784669EC1AF8033F298DB",
                    ContatoAutenticacao_Fone = "05CC644D54505E45C7BA1BC537C904B4",
                    ContatoAutenticacao_FoneAlternativo = "5CDD8271A37B090B4D2D766080427281",
                    Contato_Bairro = "AC4D2703DDB4ECDFFBE6CDCF85D57EFAA6DC9CDCD6D8F2DE2C9F98411462F1FB",
                    Contato_CEP = "ED5BDAF6729F3DEE43BD3262730DFB85",
                    Contato_Cidade = "09D8B4E96F6C50D48CEA2E7FDB168AB5",
                    Contato_Complemento = "3DF0D12434457D7194C831CCDED68217",
                    Contato_Escritorio = "4F6178F614B10C9CF9C51AF56EFF0D8B16D8C61A58106F51DEBE9BA60FADFBC390ABF51139EA79902B67454A5B3984DC91ABFB404EB1431709B20F3350EE86E755703FE72631D6455F11EF52ED98330D",
                    Contato_Estado = "67BF623EC26BFB0E31E9E3755F64F92D",
                    Contato_FoneCelular = "05CC644D54505E45C7BA1BC537C904B4",
                    Contato_FoneComercial = "5CDD8271A37B090B4D2D766080427281",
                    Contato_Logradouro = "4F6178F614B10C9CF9C51AF56EFF0D8B2472CDC571C1D897D12BCE462CBF792C",
                    Contato_LogradouroNum = "",
                    Contato_Pais = "188C94448021F72179E959C8C22A5235",
                    Contato_Website = "9EAAE2300C845D63A347F5961BB5ED651AE7D10BF66C6031C7BF28A44D80DE2E838190E549BB846CB1A5306A6B9E7F79",
                    Documentacao_CNPJ = "6CBF90ACBB00F5ECDB83BA969F950C2312232E024018AF97C28726C74FFC6FE9",
                    Documentacao_CPF = "C64ACB4FE9C58557494501F438D8E46B",
                    Documentacao_RG = "AA20A747877F89351277E23E1FF03D3F",
                    Documentacao_TPPessoa = "AC00C0AA39C7FF13CE7FEEC9969DCE5E",
                    Email = "adm@depoisdalinha.com.br",
                    EmailConfirmed = true,
                    EstadoCivil = "8086554AF4C49F7899D7E2DD3C073C0D",
                    Financeiro_Banco_Ag = "",
                    Financeiro_Banco_CC = "",
                    Financeiro_Banco_Nome = "",
                    Financeiro_Investidor_Perfil = "93274427AD8E0A8F4854F0BA1439F141",
                    Genero = "44E1E3882B52FCC8234B7863CAF32AC1",
                    ImagemFundoPerfil = "/images/fundo_padrao_perfil.png",
                    LockoutEnabled = false,
                    MidiasSociais_Facebook = "",
                    MidiasSociais_GooglePlus = "",
                    MidiasSociais_Instagram = "",
                    MidiasSociais_Linkedin = "",
                    MidiasSociais_Pinterest = "",
                    MidiasSociais_Twitter = "",
                    MidiasSociais_Youtube = "",
                    Nascimento = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind) DateTimeKind.Unspecified),
                    Nome = "B7A21D4C503F34760FC6C17A1C48F84B",
                    NormalizedEmail = "adm@depoisdalinha.com.br",
                    NormalizedUserName = "adm@depoisdalinha.com.br",
                    PasswordHash = "AQAAAAEAACcQAAAAEEUROHSF0nA9tt/w4PslWzvfLrLHn7bBqGaBeq9ud5I5yIjpHtfQ/l0PFaeYjikyGw==",
                    PhoneNumber = "+5511998814900",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = "",
                    Sistema_AcessoBloqueado = false,
                    Sistema_DataDeclaracaoCienciaTermos = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x166, (DateTimeKind) DateTimeKind.Local).AddTicks(0x1ae8L),
                    Sistema_DeclaracaoCienciaTermos = true,
                    Sistema_DeclaracaoPessoaExposta = false,
                    Sistema_FuncaoUsuario = "93274427AD8E0A8F4854F0BA1439F141",
                    Sistema_NaoAparecerListaProjetos = false,
                    Sistema_URLComprovanteResidencia = "",
                    Sistema_URLFotoDoc = "",
                    Sistema_URLSelfieDocFRENTE = "",
                    Sistema_URLSelfieDocVERSO = "",
                    Sobrenome = "511E099EB38F8E594610520A4F613080",
                    Trabalho_Cargo = "AA2C637A3C3863080A3046539A39635B75E92CB57C0986FACA019AE5A17B9A46",
                    Trabalho_Empresa = "FDB312CEDCA7BC781E69030EED215204",
                    Trabalho_Profissao = "C46D2C2793536285D2CAFA18BEC9A17C",
                    TwoFactorEnabled = false,
                    UserName = "adm@depoisdalinha.com.br"
                }, new {
                    Id = "b1aadecb-4357-457d-bfea-27e153505497",
                    AccessFailedCount = 0,
                    AppConfiguracoesId = 1,
                    AvatarUsuario = "432B4DD679BC8E3DE04F89CBBA514F9E6D8C125FA0C00CDF67B44091F95211FE4668E0CF7D27FBFCBECB27E474B12A73",
                    Bio = "E7767D052069A50DE93D25E4E9CB31DD",
                    ConcurrencyStamp = "2962ebb0-f360-47f1-81e4-736fa6b1d50d",
                    ContatoAutenticacao_Email = "9AD978F878C0C880A7E62BB29D985273E5F4E65EF8E5C9C3DFBA81BE27D38E42",
                    ContatoAutenticacao_EmailAlternativo = "9AD978F878C0C880A7E62BB29D985273E5F4E65EF8E5C9C3DFBA81BE27D38E42",
                    ContatoAutenticacao_Fone = "F6D4B3A852D8E2C9FC3AA7DF76D137E3",
                    ContatoAutenticacao_FoneAlternativo = "F6D4B3A852D8E2C9FC3AA7DF76D137E3",
                    Contato_Bairro = "645333AEE2F40EEAFCF6C9D2396769D8",
                    Contato_CEP = "F8190D87D5515C6F61703D0983B80C2E",
                    Contato_Cidade = "09D8B4E96F6C50D48CEA2E7FDB168AB5",
                    Contato_Complemento = "3DF0D12434457D7194C831CCDED68217",
                    Contato_Escritorio = "F8A40F09EDD34409B7E6E4A34456F4157F57D6BA6DA0B6E51F16A7CD84422F2AA50F74D9043088A046424266C72BA761",
                    Contato_Estado = "67BF623EC26BFB0E31E9E3755F64F92D",
                    Contato_FoneCelular = "F6D4B3A852D8E2C9FC3AA7DF76D137E3",
                    Contato_FoneComercial = "F6D4B3A852D8E2C9FC3AA7DF76D137E3",
                    Contato_Logradouro = "F8A40F09EDD34409B7E6E4A34456F415EE82760C3A1FAE3D852EEE9D8405C6EF",
                    Contato_LogradouroNum = "",
                    Contato_Pais = "188C94448021F72179E959C8C22A5235",
                    Contato_Website = "D3CF7F5DE9E702974C41C0281D4E21089AFE0D0702DE29C60B41C3006556D661",
                    Documentacao_CNPJ = "9C399CD489452A9A9EE44FDF1C63063334BDE696E1C706BB4A2446800CB60A82",
                    Documentacao_CPF = "FECB68EF441B6FF7FF4BD584F863A2DB",
                    Documentacao_RG = "2EC128A57C16437C98AAB7BD3C236F4B",
                    Documentacao_TPPessoa = "AC00C0AA39C7FF13CE7FEEC9969DCE5E",
                    Email = "adm@house2invest.com.br",
                    EmailConfirmed = true,
                    EstadoCivil = "8086554AF4C49F7899D7E2DD3C073C0D",
                    Financeiro_Banco_Ag = "",
                    Financeiro_Banco_CC = "",
                    Financeiro_Banco_Nome = "",
                    Financeiro_Investidor_Perfil = "93274427AD8E0A8F4854F0BA1439F141",
                    Genero = "44E1E3882B52FCC8234B7863CAF32AC1",
                    ImagemFundoPerfil = "/images/fundo_padrao_perfil.png",
                    LockoutEnabled = false,
                    MidiasSociais_Facebook = "",
                    MidiasSociais_GooglePlus = "",
                    MidiasSociais_Instagram = "",
                    MidiasSociais_Linkedin = "",
                    MidiasSociais_Pinterest = "",
                    MidiasSociais_Twitter = "",
                    MidiasSociais_Youtube = "",
                    Nascimento = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind) DateTimeKind.Unspecified),
                    Nome = "51E3E8C6C9CC0AC46984D32821700A57",
                    NormalizedEmail = "adm@house2invest.com.br",
                    NormalizedUserName = "adm@house2invest.com.br",
                    PasswordHash = "AQAAAAEAACcQAAAAEMdICSP3Fvf5QijkOsSjuQn8tzL6kdfQF78BcnLP9JblbRxYurQP1BX+du1MFd2HRg==",
                    PhoneNumber = "+5511995951925",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = "",
                    Sistema_AcessoBloqueado = false,
                    Sistema_DataDeclaracaoCienciaTermos = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x170, (DateTimeKind) DateTimeKind.Local).AddTicks(0x409L),
                    Sistema_DeclaracaoCienciaTermos = true,
                    Sistema_DeclaracaoPessoaExposta = false,
                    Sistema_FuncaoUsuario = "93274427AD8E0A8F4854F0BA1439F141",
                    Sistema_NaoAparecerListaProjetos = false,
                    Sistema_URLComprovanteResidencia = "",
                    Sistema_URLFotoDoc = "",
                    Sistema_URLSelfieDocFRENTE = "",
                    Sistema_URLSelfieDocVERSO = "",
                    Sobrenome = "97356CF65E5FD78B39BAA8249A8064A9",
                    Trabalho_Cargo = "AA14A749432228239F7A949F3BE8AE4F",
                    Trabalho_Empresa = "5051B8ABFA8206DAA52CFFE3CB57B9FE",
                    Trabalho_Profissao = "AA14A749432228239F7A949F3BE8AE4F",
                    TwoFactorEnabled = false,
                    UserName = "adm@house2invest.com.br"
                }, new {
                    Id = "4cb6d3d8-493a-415c-a5d7-cc6860aa8691",
                    AccessFailedCount = 0,
                    AppConfiguracoesId = 1,
                    AvatarUsuario = "690F796D0CD780FCE2710E7DC08AA01C4AD8ABAA3767BABD54CAB426BBFFDFDA",
                    Bio = "E7767D052069A50DE93D25E4E9CB31DD",
                    ConcurrencyStamp = "9ca8fc12-4ebb-4e21-a82c-3467135bf442",
                    ContatoAutenticacao_Email = "9AD978F878C0C880A7E62BB29D985273E5F4E65EF8E5C9C3DFBA81BE27D38E42",
                    ContatoAutenticacao_EmailAlternativo = "9AD978F878C0C880A7E62BB29D985273E5F4E65EF8E5C9C3DFBA81BE27D38E42",
                    ContatoAutenticacao_Fone = "F6D4B3A852D8E2C9FC3AA7DF76D137E3",
                    ContatoAutenticacao_FoneAlternativo = "F6D4B3A852D8E2C9FC3AA7DF76D137E3",
                    Contato_Bairro = "645333AEE2F40EEAFCF6C9D2396769D8",
                    Contato_CEP = "F8190D87D5515C6F61703D0983B80C2E",
                    Contato_Cidade = "09D8B4E96F6C50D48CEA2E7FDB168AB5",
                    Contato_Complemento = "3DF0D12434457D7194C831CCDED68217",
                    Contato_Escritorio = "F8A40F09EDD34409B7E6E4A34456F4157F57D6BA6DA0B6E51F16A7CD84422F2AA50F74D9043088A046424266C72BA761",
                    Contato_Estado = "67BF623EC26BFB0E31E9E3755F64F92D",
                    Contato_FoneCelular = "F6D4B3A852D8E2C9FC3AA7DF76D137E3",
                    Contato_FoneComercial = "F6D4B3A852D8E2C9FC3AA7DF76D137E3",
                    Contato_Logradouro = "F8A40F09EDD34409B7E6E4A34456F415EE82760C3A1FAE3D852EEE9D8405C6EF",
                    Contato_LogradouroNum = "",
                    Contato_Pais = "188C94448021F72179E959C8C22A5235",
                    Contato_Website = "D3CF7F5DE9E702974C41C0281D4E21089AFE0D0702DE29C60B41C3006556D661",
                    Documentacao_CNPJ = "9C399CD489452A9A9EE44FDF1C63063334BDE696E1C706BB4A2446800CB60A82",
                    Documentacao_CPF = "FECB68EF441B6FF7FF4BD584F863A2DB",
                    Documentacao_RG = "2EC128A57C16437C98AAB7BD3C236F4B",
                    Documentacao_TPPessoa = "AC00C0AA39C7FF13CE7FEEC9969DCE5E",
                    Email = "vitor@house2invest.com.br",
                    EmailConfirmed = true,
                    EstadoCivil = "8086554AF4C49F7899D7E2DD3C073C0D",
                    Financeiro_Banco_Ag = "",
                    Financeiro_Banco_CC = "",
                    Financeiro_Banco_Nome = "",
                    Financeiro_Investidor_Perfil = "93274427AD8E0A8F4854F0BA1439F141",
                    Genero = "44E1E3882B52FCC8234B7863CAF32AC1",
                    ImagemFundoPerfil = "/images/fundo_padrao_perfil.png",
                    LockoutEnabled = false,
                    MidiasSociais_Facebook = "",
                    MidiasSociais_GooglePlus = "",
                    MidiasSociais_Instagram = "",
                    MidiasSociais_Linkedin = "",
                    MidiasSociais_Pinterest = "",
                    MidiasSociais_Twitter = "",
                    MidiasSociais_Youtube = "",
                    Nascimento = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind) DateTimeKind.Unspecified),
                    Nome = "17CFDFFAC6A77D6AD1F466BF154D0181",
                    NormalizedEmail = "vitor@house2invest.com.br",
                    NormalizedUserName = "vitor@house2invest.com.br",
                    PasswordHash = "AQAAAAEAACcQAAAAEBA+KyJXM8BQ6iEdP6Nf1iINOYN4NWIRpaoLp5uEERv/2aPwUnGS1/dUqgMIsZIVeA==",
                    PhoneNumber = "+5511995951925",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = "",
                    Sistema_AcessoBloqueado = false,
                    Sistema_DataDeclaracaoCienciaTermos = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x179, (DateTimeKind) DateTimeKind.Local).AddTicks((long) 80),
                    Sistema_DeclaracaoCienciaTermos = true,
                    Sistema_DeclaracaoPessoaExposta = false,
                    Sistema_FuncaoUsuario = "93274427AD8E0A8F4854F0BA1439F141",
                    Sistema_NaoAparecerListaProjetos = false,
                    Sistema_URLComprovanteResidencia = "",
                    Sistema_URLFotoDoc = "",
                    Sistema_URLSelfieDocFRENTE = "",
                    Sistema_URLSelfieDocVERSO = "",
                    Sobrenome = "F16E462AD0B446EA18E356162F148FCDEBCCBE73C24E8DA648ACC5FEC6031D8A",
                    Trabalho_Cargo = "AA14A749432228239F7A949F3BE8AE4F",
                    Trabalho_Empresa = "5051B8ABFA8206DAA52CFFE3CB57B9FE",
                    Trabalho_Profissao = "AA14A749432228239F7A949F3BE8AE4F",
                    TwoFactorEnabled = false,
                    UserName = "vitor@house2invest.com.br"
                }, new {
                    Id = "bbf7b44d-faa0-4276-b163-295b780a062c",
                    AccessFailedCount = 0,
                    AppConfiguracoesId = 1,
                    AvatarUsuario = "F7FF434D3FF2F359A2C90E3841BABAC44DD6D9B9091DB2202B223A0405376DB5",
                    Bio = "E7767D052069A50DE93D25E4E9CB31DD",
                    ConcurrencyStamp = "626cfd16-8380-4a13-a1e1-ab7fe2982018",
                    ContatoAutenticacao_Email = "91993838DBE9C22EDDE9C4B674F70C32541645EEED633D2A6BB93D34C3BB2BC212119CF96BDC222FB06E3070E59F6846",
                    ContatoAutenticacao_EmailAlternativo = "91993838DBE9C22EDDE9C4B674F70C32541645EEED633D2A6BB93D34C3BB2BC212119CF96BDC222FB06E3070E59F6846",
                    ContatoAutenticacao_Fone = "EAB3774976AE2FA089327CD4A8E47378",
                    ContatoAutenticacao_FoneAlternativo = "EAB3774976AE2FA089327CD4A8E47378",
                    Contato_Bairro = "42DA8A2C618928E0568B5CC2770E9218",
                    Contato_CEP = "13184286525F221852B660C8F8A85119",
                    Contato_Cidade = "5E30B54D033E0A3551C761A7A9FB4FA3",
                    Contato_Complemento = "3DF0D12434457D7194C831CCDED68217",
                    Contato_Escritorio = "FBD72192F9DF948974190443768CA8B145A5E5BA7B1E4CF024D6AD9E12711002",
                    Contato_Estado = "67BF623EC26BFB0E31E9E3755F64F92D",
                    Contato_FoneCelular = "EAB3774976AE2FA089327CD4A8E47378",
                    Contato_FoneComercial = "EAB3774976AE2FA089327CD4A8E47378",
                    Contato_Logradouro = "FBD72192F9DF948974190443768CA8B145A5E5BA7B1E4CF024D6AD9E12711002",
                    Contato_LogradouroNum = "",
                    Contato_Pais = "188C94448021F72179E959C8C22A5235",
                    Contato_Website = "D3CF7F5DE9E702974C41C0281D4E21089AFE0D0702DE29C60B41C3006556D661",
                    Documentacao_CNPJ = "9C399CD489452A9A9EE44FDF1C63063334BDE696E1C706BB4A2446800CB60A82",
                    Documentacao_CPF = "FECB68EF441B6FF7FF4BD584F863A2DB",
                    Documentacao_RG = "2EC128A57C16437C98AAB7BD3C236F4B",
                    Documentacao_TPPessoa = "AC00C0AA39C7FF13CE7FEEC9969DCE5E",
                    Email = "joao@house2invest.com.br",
                    EmailConfirmed = true,
                    EstadoCivil = "8086554AF4C49F7899D7E2DD3C073C0D",
                    Financeiro_Banco_Ag = "",
                    Financeiro_Banco_CC = "",
                    Financeiro_Banco_Nome = "",
                    Financeiro_Investidor_Perfil = "93274427AD8E0A8F4854F0BA1439F141",
                    Genero = "44E1E3882B52FCC8234B7863CAF32AC1",
                    ImagemFundoPerfil = "/images/fundo_padrao_perfil.png",
                    LockoutEnabled = false,
                    MidiasSociais_Facebook = "",
                    MidiasSociais_GooglePlus = "",
                    MidiasSociais_Instagram = "",
                    MidiasSociais_Linkedin = "",
                    MidiasSociais_Pinterest = "",
                    MidiasSociais_Twitter = "",
                    MidiasSociais_Youtube = "",
                    Nascimento = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind) DateTimeKind.Unspecified),
                    Nome = "51931671FFEDC07127F36CEFAD81A4BC",
                    NormalizedEmail = "joao@house2invest.com.br",
                    NormalizedUserName = "joao@house2invest.com.br",
                    PasswordHash = "AQAAAAEAACcQAAAAEBVhUAlsdNI+ZBfl1Dpk7lyD6BDlx/zfSFN61mnAzgVvFdIjdv+geI4QZPZfDdEJQA==",
                    PhoneNumber = "+5511979661000",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = "",
                    Sistema_AcessoBloqueado = false,
                    Sistema_DataDeclaracaoCienciaTermos = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x184, (DateTimeKind) DateTimeKind.Local).AddTicks(0xf43L),
                    Sistema_DeclaracaoCienciaTermos = true,
                    Sistema_DeclaracaoPessoaExposta = false,
                    Sistema_FuncaoUsuario = "93274427AD8E0A8F4854F0BA1439F141",
                    Sistema_NaoAparecerListaProjetos = false,
                    Sistema_URLComprovanteResidencia = "",
                    Sistema_URLFotoDoc = "",
                    Sistema_URLSelfieDocFRENTE = "",
                    Sistema_URLSelfieDocVERSO = "",
                    Sobrenome = "A544D424B1546920B1A2C014CACE433E",
                    Trabalho_Cargo = "58DA4709D5F2A895A1518D8AC4D7F6FD",
                    Trabalho_Empresa = "5051B8ABFA8206DAA52CFFE3CB57B9FE",
                    Trabalho_Profissao = "58DA4709D5F2A895A1518D8AC4D7F6FD",
                    TwoFactorEnabled = false,
                    UserName = "joao@house2invest.com.br"
                }, new {
                    Id = "2751483e-2c65-4629-84b5-abc20c940c1c",
                    AccessFailedCount = 0,
                    AppConfiguracoesId = 1,
                    AvatarUsuario = "274BFF5C0F505E135768CF02B0D485929CDBFAE485B7DEE51D97195F85352C85",
                    Bio = "E7767D052069A50DE93D25E4E9CB31DD",
                    ConcurrencyStamp = "f60ed224-2d74-45e4-addd-6892ec0f654f",
                    ContatoAutenticacao_Email = "AE06F29830EDCA78DBF93B2B9B2C9931E3D16791B5263FBCD8AF254C3D4D240D",
                    ContatoAutenticacao_EmailAlternativo = "AE06F29830EDCA78DBF93B2B9B2C9931E3D16791B5263FBCD8AF254C3D4D240D",
                    ContatoAutenticacao_Fone = "2559F7BB0BFE7BC212CCD8C15DF0A4DB",
                    ContatoAutenticacao_FoneAlternativo = "2559F7BB0BFE7BC212CCD8C15DF0A4DB",
                    Contato_Bairro = "D577DE715FA1885EA70543B47179E4D4",
                    Contato_CEP = "BE3FA8F28BCAB6F10E21A9B699B12708",
                    Contato_Cidade = "09D8B4E96F6C50D48CEA2E7FDB168AB5",
                    Contato_Complemento = "9E0B3AC2C75EA329AB11C4F7BAEC14C4",
                    Contato_Escritorio = "575530A309AF0D4B5569553611DE2D5D4AE53324A8FBEACA267CA51E5EBB1721",
                    Contato_Estado = "67BF623EC26BFB0E31E9E3755F64F92D",
                    Contato_FoneCelular = "2559F7BB0BFE7BC212CCD8C15DF0A4DB",
                    Contato_FoneComercial = "2559F7BB0BFE7BC212CCD8C15DF0A4DB",
                    Contato_Logradouro = "575530A309AF0D4B5569553611DE2D5D4AE53324A8FBEACA267CA51E5EBB1721",
                    Contato_LogradouroNum = "",
                    Contato_Pais = "188C94448021F72179E959C8C22A5235",
                    Contato_Website = "D3CF7F5DE9E702974C41C0281D4E21089AFE0D0702DE29C60B41C3006556D661",
                    Documentacao_CNPJ = "9C399CD489452A9A9EE44FDF1C63063334BDE696E1C706BB4A2446800CB60A82",
                    Documentacao_CPF = "FECB68EF441B6FF7FF4BD584F863A2DB",
                    Documentacao_RG = "2EC128A57C16437C98AAB7BD3C236F4B",
                    Documentacao_TPPessoa = "AC00C0AA39C7FF13CE7FEEC9969DCE5E",
                    Email = "cristina@house2invest.com.br",
                    EmailConfirmed = true,
                    EstadoCivil = "7786386A9A58AF0AE8542BA111EA2C0C",
                    Financeiro_Banco_Ag = "",
                    Financeiro_Banco_CC = "",
                    Financeiro_Banco_Nome = "",
                    Financeiro_Investidor_Perfil = "93274427AD8E0A8F4854F0BA1439F141",
                    Genero = "B18F045FE1BD7F106650C0A57275FD04",
                    ImagemFundoPerfil = "/images/fundo_padrao_perfil.png",
                    LockoutEnabled = false,
                    MidiasSociais_Facebook = "",
                    MidiasSociais_GooglePlus = "",
                    MidiasSociais_Instagram = "",
                    MidiasSociais_Linkedin = "",
                    MidiasSociais_Pinterest = "",
                    MidiasSociais_Twitter = "",
                    MidiasSociais_Youtube = "",
                    Nascimento = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind) DateTimeKind.Unspecified),
                    Nome = "0362234E13B08161A5BB3DC2A857DA40",
                    NormalizedEmail = "cristina@house2invest.com.br",
                    NormalizedUserName = "cristina@house2invest.com.br",
                    PasswordHash = "AQAAAAEAACcQAAAAEL+s5GOX4eOZcA4yoJRn3uVx5pm/O0WsALhsI2UrwEA1EZsoQrkS5n6jG3u1IwU4qA==",
                    PhoneNumber = "+5511997103699",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = "",
                    Sistema_AcessoBloqueado = false,
                    Sistema_DataDeclaracaoCienciaTermos = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x18b, (DateTimeKind) DateTimeKind.Local).AddTicks(0x1881L),
                    Sistema_DeclaracaoCienciaTermos = true,
                    Sistema_DeclaracaoPessoaExposta = false,
                    Sistema_FuncaoUsuario = "93274427AD8E0A8F4854F0BA1439F141",
                    Sistema_NaoAparecerListaProjetos = false,
                    Sistema_URLComprovanteResidencia = "",
                    Sistema_URLFotoDoc = "",
                    Sistema_URLSelfieDocFRENTE = "",
                    Sistema_URLSelfieDocVERSO = "",
                    Sobrenome = "E09531C52ED770F0C352D41CB826F4C65D3C20212AA6ECAD9E53AD38EDA20B53",
                    Trabalho_Cargo = "006802EFD129DBAD6D02C2621C01168B",
                    Trabalho_Empresa = "5051B8ABFA8206DAA52CFFE3CB57B9FE",
                    Trabalho_Profissao = "006802EFD129DBAD6D02C2621C01168B",
                    TwoFactorEnabled = false,
                    UserName = "cristina@house2invest.com.br"
                } };
                b.HasData(objArray1);
            });
            modelBuilder.Entity("House2Invest.Models.tblHubCliente", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<string>("CnxId");
                b.Property<DateTime>("DTHR");
                b.Property<string>("Email");
                b.Property<string>("Status");
                b.Property<string>("UsuarioAppId").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "tblHubClientes");
            });
            modelBuilder.Entity("House2Invest.Models.tblHubConversa", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<DateTime>("DTHR");
                b.Property<string>("De");
                b.Property<string>("DeCnxId");
                b.Property<bool>("Lida");
                b.Property<string>("Mensagem");
                b.Property<string>("Para");
                b.Property<string>("ParaCnxId");
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "tblHubConversas");
            });
            modelBuilder.Entity("House2Invest.Models.tblUsuSalaVIP", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<string>("CnxId");
                b.Property<DateTime>("DTHR");
                b.Property<string>("Status");
                b.Property<string>("UsuarioAppId").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "tblUsuSalaVIPs");
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", delegate (EntityTypeBuilder b)
            {
                b.Property<string>("Id").ValueGeneratedOnAdd();
                b.Property<string>("ConcurrencyStamp").IsConcurrencyToken(true);
                b.Property<string>("Name").HasMaxLength(0x100);
                b.Property<string>("NormalizedName").HasMaxLength(0x100);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "NormalizedName" };
                RelationalIndexBuilderExtensions.HasFilter(RelationalIndexBuilderExtensions.HasName(b.HasIndex(textArray2).IsUnique(true), "RoleNameIndex"), "[NormalizedName] IS NOT NULL");
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetRoles");
                object[] objArray1 = new object[14];
                objArray1[0] = new
                {
                    Id = "59c39ee9-024a-41c1-bae8-7859879aa9f2",
                    ConcurrencyStamp = "89a7227e-9d9d-4f24-9bbe-a08f6feffa50",
                    Name = "SIS",
                    NormalizedName = "SIS"
                };
                objArray1[1] = new
                {
                    Id = "d3f04340-133b-4fe5-964f-725cf3482cbb",
                    ConcurrencyStamp = "c2a01ba0-50e9-4372-9667-48e5260785e1",
                    Name = "ADM",
                    NormalizedName = "ADM"
                };
                objArray1[2] = new
                {
                    Id = "730f160e-5178-4f3c-a955-2c12abc4d1f9",
                    ConcurrencyStamp = "b9cdd298-3ac6-414b-9434-fdea77870067",
                    Name = "SUPERVISOR",
                    NormalizedName = "SUPERVISOR"
                };
                objArray1[3] = new
                {
                    Id = "a59726df-21c5-44c8-96ba-a4a2244dea3c",
                    ConcurrencyStamp = "ed9c0b8a-ae78-4846-9891-c15daed83ec8",
                    Name = "ADMCONTA",
                    NormalizedName = "ADMCONTA"
                };
                objArray1[4] = new
                {
                    Id = "ced87445-4121-45ff-b05e-6965f5014bc8",
                    ConcurrencyStamp = "4cb7a313-3d5b-4329-8523-17a91d08aa61",
                    Name = "API",
                    NormalizedName = "API"
                };
                objArray1[5] = new
                {
                    Id = "8f0a2fbc-ec7d-47e2-b307-0d5085e57275",
                    ConcurrencyStamp = "fb6082d9-cc70-486d-96b2-d3cc806857b9",
                    Name = "MANUTAPP",
                    NormalizedName = "MANUTAPP"
                };
                objArray1[6] = new
                {
                    Id = "e42f1601-ac85-4384-8fd4-f3c4345b56db",
                    ConcurrencyStamp = "bf81164a-8bc3-4f45-b03a-9cefc4b85f74",
                    Name = "SUPORTE",
                    NormalizedName = "SUPORTE"
                };
                objArray1[7] = new
                {
                    Id = "c91c9806-bd59-4a8e-ade6-13bc0427602c",
                    ConcurrencyStamp = "3a8e4da0-b5e7-4320-a564-08314f14a33e",
                    Name = "COMUNIDADE",
                    NormalizedName = "COMUNIDADE"
                };
                objArray1[8] = new
                {
                    Id = "257310a1-a0bf-4625-ae12-a31c2940e5af",
                    ConcurrencyStamp = "c8e63732-e740-4a80-8430-3eb95dc78080",
                    Name = "FINANCEIRO",
                    NormalizedName = "FINANCEIRO"
                };
                objArray1[9] = new
                {
                    Id = "acbfb305-1c76-4a54-8c40-36ff8ac5312e",
                    ConcurrencyStamp = "3356fea7-d7c9-4188-a7b5-6919f66f1c4b",
                    Name = "MARKETING",
                    NormalizedName = "MARKETING"
                };
                objArray1[10] = new
                {
                    Id = "eb7726bc-7c17-446c-a22a-72df87922494",
                    ConcurrencyStamp = "7695fcc1-999d-4eb2-acdc-5e9ca57bc821",
                    Name = "MIDIAS",
                    NormalizedName = "MIDIAS"
                };
                objArray1[11] = new
                {
                    Id = "99d47b3f-b8f7-435a-b6a0-7dd2e80f4d30",
                    ConcurrencyStamp = "418d8670-7f66-4e6e-8812-d1a4141a67ae",
                    Name = "VENDA",
                    NormalizedName = "VENDA"
                };
                objArray1[12] = new
                {
                    Id = "16b933cf-e693-47d5-9957-d217467d17a6",
                    ConcurrencyStamp = "b5e49d47-bd1c-421e-82e2-872b40b5937a",
                    Name = "DESENVOLVEDOR",
                    NormalizedName = "DESENVOLVEDOR"
                };
                objArray1[13] = new
                {
                    Id = "96c373b4-8cc5-4a63-9f9a-81884a5efe75",
                    ConcurrencyStamp = "c4e0ce90-1867-4a71-a7a7-1dbb3a8bd11c",
                    Name = "USU",
                    NormalizedName = "USU"
                };
                b.HasData(objArray1);
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<string>("ClaimType");
                b.Property<string>("ClaimValue");
                b.Property<string>("RoleId").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "RoleId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetRoleClaims");
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", delegate (EntityTypeBuilder b)
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1);
                b.Property<string>("ClaimType");
                b.Property<string>("ClaimValue");
                b.Property<string>("UserId").IsRequired(true);
                string[] textArray1 = new string[] { "Id" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "UserId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUserClaims");
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", delegate (EntityTypeBuilder b)
            {
                b.Property<string>("LoginProvider");
                b.Property<string>("ProviderKey");
                b.Property<string>("ProviderDisplayName");
                b.Property<string>("UserId").IsRequired(true);
                string[] textArray1 = new string[] { "LoginProvider", "ProviderKey" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "UserId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUserLogins");
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", delegate (EntityTypeBuilder b)
            {
                b.Property<string>("UserId");
                b.Property<string>("RoleId");
                string[] textArray1 = new string[] { "UserId", "RoleId" };
                b.HasKey(textArray1);
                string[] textArray2 = new string[] { "RoleId" };
                b.HasIndex(textArray2);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUserRoles");
                object[] objArray1 = new object[] { new {
                    UserId = "b30b4d21-0f99-435e-acec-a2c672697b0f",
                    RoleId = "59c39ee9-024a-41c1-bae8-7859879aa9f2"
                }, new {
                    UserId = "b1aadecb-4357-457d-bfea-27e153505497",
                    RoleId = "59c39ee9-024a-41c1-bae8-7859879aa9f2"
                }, new {
                    UserId = "4cb6d3d8-493a-415c-a5d7-cc6860aa8691",
                    RoleId = "59c39ee9-024a-41c1-bae8-7859879aa9f2"
                }, new {
                    UserId = "bbf7b44d-faa0-4276-b163-295b780a062c",
                    RoleId = "59c39ee9-024a-41c1-bae8-7859879aa9f2"
                }, new {
                    UserId = "2751483e-2c65-4629-84b5-abc20c940c1c",
                    RoleId = "59c39ee9-024a-41c1-bae8-7859879aa9f2"
                } };
                b.HasData(objArray1);
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", delegate (EntityTypeBuilder b)
            {
                b.Property<string>("UserId");
                b.Property<string>("LoginProvider");
                b.Property<string>("Name");
                b.Property<string>("Value");
                string[] textArray1 = new string[] { "UserId", "LoginProvider", "Name" };
                b.HasKey(textArray1);
                RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUserTokens");
            });
            modelBuilder.Entity("House2Invest.Models.AppConfiguracoes", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "AppConfiguracoes_AplicativoId" };
                b.HasOne("House2Invest.Models.AppConfiguracoes_Aplicativo", "AppConfiguracoes_Aplicativo").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "AppConfiguracoes_AzureId" };
                b.HasOne("House2Invest.Models.AppConfiguracoes_Azure", "AppConfiguracoes_Azure").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.AppPerfil", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "AppConfiguracoesId" };
                b.HasOne("House2Invest.Models.AppConfiguracoes", "AppConfiguracoes").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.BlocoProjInvestimento", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "ConstrutoraId" };
                b.HasOne("House2Invest.Models.Construtora", "Construtora").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "GaleriaPerfilAlbumId" };
                b.HasOne("House2Invest.Models.GaleriaPerfilAlbum", "GaleriaPerfilAlbum").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.BlocoProjInvestimentoComentario", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "BlocoProjInvestimentoId" };
                b.HasOne("House2Invest.Models.BlocoProjInvestimento", "BlocoProjInvestimentos").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApps").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.BlocoProjInvestimentoValor", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "BlocoProjInvestimentoId" };
                b.HasOne("House2Invest.Models.BlocoProjInvestimento", "BlocoProjInvestimentos").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApps").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.BlocoProjInvestimento_ItemDoc", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "BlocoProjInvestimentoId" };
                b.HasOne("House2Invest.Models.BlocoProjInvestimento", "BlocoProjInvestimento").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "INVEST_ModeloDocId" };
                b.HasOne("House2Invest.Models.INVEST_ModeloDoc", "INVEST_ModeloDoc").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.FAQItem", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "FAQId" };
                b.HasOne("House2Invest.Models.FAQ", "FAQ").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.GaleriaPerfilAlbum", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "AppPerfilId" };
                b.HasOne("House2Invest.Models.AppPerfil", "AppPerfil").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.GaleriaPerfilImagem", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "GaleriaPerfilAlbumId" };
                b.HasOne("House2Invest.Models.GaleriaPerfilAlbum", "GaleriaPerfilAlbum").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.HgGeoIp", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "ResultsGeoIpId" };
                b.HasOne("House2Invest.Models.ResultsGeoIp", "results").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.HgGeoIp_Pais", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "HgGeoIp_Pais_FlagId" };
                b.HasOne("House2Invest.Models.HgGeoIp_Pais_Flag", "flag").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_ControleTransf", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "BlocoProjInvestimentosId" };
                b.HasOne("House2Invest.Models.BlocoProjInvestimento", "BlocoProjInvestimentos").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApp").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_Lancamento", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "BlocoProjInvestimentosId" };
                b.HasOne("House2Invest.Models.BlocoProjInvestimento", "BlocoProjInvestimentos").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApp").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_LancamentoDoc", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "INVEST_LancamentoId" };
                b.HasOne("House2Invest.Models.INVEST_Lancamento", "INVEST_Lancamento").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "INVEST_ModeloDocId" };
                b.HasOne("House2Invest.Models.INVEST_ModeloDoc", "INVEST_ModeloDoc").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.INVEST_LancamentoImagem", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "INVEST_LancamentoId" };
                b.HasOne("House2Invest.Models.INVEST_Lancamento", "INVEST_Lancamento").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.InvestimentoConfirmacao", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "BlocoProjInvestimentoId" };
                b.HasOne("House2Invest.Models.BlocoProjInvestimento", "BlocoProjInvestimentos").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "INVEST_LancamentoId" };
                b.HasOne("House2Invest.Models.INVEST_Lancamento", "INVEST_Lancamento").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
                string[] textArray3 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApps").WithMany(null).HasForeignKey(textArray3).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.InvestimentoDocUsuario", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "BlocoProjInvestimentoId" };
                b.HasOne("House2Invest.Models.BlocoProjInvestimento", "BlocoProjInvestimentos").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApps").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.LOGCENTRAL", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "UsuarioAppCriadorId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioAppCriador").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
                string[] textArray2 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApp").WithMany(null).HasForeignKey(textArray2).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.PreferSalaVIP", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApp").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.ResultsGeoIp", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "HgGeoIp_PaisId" };
                b.HasOne("House2Invest.Models.HgGeoIp_Pais", "country").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.Transferencia", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "BlocoProjInvestimentoId" };
                b.HasOne("House2Invest.Models.BlocoProjInvestimento", "BlocoProjInvestimentos").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.UsuarioApp", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "AppConfiguracoesId" };
                b.HasOne("House2Invest.Models.AppConfiguracoes", "AppConfiguracoes").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.tblHubCliente", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApp").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("House2Invest.Models.tblUsuSalaVIP", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "UsuarioAppId" };
                b.HasOne("House2Invest.Models.UsuarioApp", "UsuarioApp").WithMany(null).HasForeignKey(textArray1).OnDelete(1);
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "RoleId" };
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null).WithMany(null).HasForeignKey(textArray1).OnDelete(3);
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "UserId" };
                b.HasOne("House2Invest.Models.UsuarioApp", null).WithMany(null).HasForeignKey(textArray1).OnDelete(3);
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "UserId" };
                b.HasOne("House2Invest.Models.UsuarioApp", null).WithMany(null).HasForeignKey(textArray1).OnDelete(3);
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "RoleId" };
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null).WithMany(null).HasForeignKey(textArray1).OnDelete(3);
                string[] textArray2 = new string[] { "UserId" };
                b.HasOne("House2Invest.Models.UsuarioApp", null).WithMany(null).HasForeignKey(textArray2).OnDelete(3);
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", delegate (EntityTypeBuilder b)
            {
                string[] textArray1 = new string[] { "UserId" };
                b.HasOne("House2Invest.Models.UsuarioApp", null).WithMany(null).HasForeignKey(textArray1).OnDelete(3);
            });
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable("AspNetRoleClaims", null);
        //    migrationBuilder.DropTable("AspNetUserClaims", null);
        //    migrationBuilder.DropTable("AspNetUserLogins", null);
        //    migrationBuilder.DropTable("AspNetUserRoles", null);
        //    migrationBuilder.DropTable("AspNetUserTokens", null);
        //    migrationBuilder.DropTable("BlocoProjInvestimento_ItemDocs", null);
        //    migrationBuilder.DropTable("BlocoProjInvestimentoComentarios", null);
        //    migrationBuilder.DropTable("BlocoProjInvestimentoValores", null);
        //    migrationBuilder.DropTable("DUMPSQL", null);
        //    migrationBuilder.DropTable("FAQItens", null);
        //    migrationBuilder.DropTable("GaleriaPerfilImagem", null);
        //    migrationBuilder.DropTable("HgGeoIps", null);
        //    migrationBuilder.DropTable("INVEST_ControleTransfs", null);
        //    migrationBuilder.DropTable("INVEST_LancamentoDocs", null);
        //    migrationBuilder.DropTable("INVEST_LancamentoImagens", null);
        //    migrationBuilder.DropTable("InvestimentoConfirmacoes", null);
        //    migrationBuilder.DropTable("InvestimentoDocUsuarios", null);
        //    migrationBuilder.DropTable("LOGACOESUSUs", null);
        //    migrationBuilder.DropTable("LOGCENTRALs", null);
        //    migrationBuilder.DropTable("PreferSalaVIPs", null);
        //    migrationBuilder.DropTable("SEO_Visitas", null);
        //    migrationBuilder.DropTable("TaxaMercados", null);
        //    migrationBuilder.DropTable("TaxasGLOBAIS", null);
        //    migrationBuilder.DropTable("tblHubClientes", null);
        //    migrationBuilder.DropTable("tblHubConversas", null);
        //    migrationBuilder.DropTable("tblUsuSalaVIPs", null);
        //    migrationBuilder.DropTable("Tranferencias", null);
        //    migrationBuilder.DropTable("AspNetRoles", null);
        //    migrationBuilder.DropTable("FAQ", null);
        //    migrationBuilder.DropTable("ResultsGeoIps", null);
        //    migrationBuilder.DropTable("INVEST_ModeloDocs", null);
        //    migrationBuilder.DropTable("INVEST_Lancamentos", null);
        //    migrationBuilder.DropTable("HgGeoIp_Paises", null);
        //    migrationBuilder.DropTable("BlocoProjInvestimentos", null);
        //    migrationBuilder.DropTable("AspNetUsers", null);
        //    migrationBuilder.DropTable("HgGeoIp_Pais_Flags", null);
        //    migrationBuilder.DropTable("Construtoras", null);
        //    migrationBuilder.DropTable("GaleriaPerfilAlbum", null);
        //    migrationBuilder.DropTable("AppPerfil", null);
        //    migrationBuilder.DropTable("AppConfiguracoes", null);
        //    migrationBuilder.DropTable("AppConfiguracoes_Aplicativo", null);
        //    migrationBuilder.DropTable("AppConfiguracoes_Azure", null);
        //}

        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.CreateTable("AppConfiguracoes_Aplicativo", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            LogotipoEmpresa = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Empresa = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            CPFCNPJ = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Logradouro = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Complemento = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Bairro = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Cidade = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Estado = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            CEP = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Fone = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            FoneRecados = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Celular = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            EmailContato = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            EmailSuporte = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            EmailVendas = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            smtpUseDefaultCredentials = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            smtpEnableSsl = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            smtpPort = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            mailFrom = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            mailToAdd = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            smtpHost = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            smtpCredentialsEmail = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            smtpCredentialsSenha = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            dumpSQLHost = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            dumpSQLUser = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            dumpSQLPass = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            temporizaLmiteMaximoOfertaSuspensa = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            temporizaLmiteMaximoRevogaInvestimento = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            temporizaLmiteMaximoCancelaInvestimento = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType10<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType10<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AppConfiguracoes_Aplicativo", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType10<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType10<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("AppConfiguracoes_Azure", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsarSimuladorLocal = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            _azureblob_AccountName = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            _azureblob_AccountKey = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            _azureblob_ContainerRaiz = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            EnderecoArmazLocal = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType11<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType11<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AppConfiguracoes_Azure", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType11<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType11<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("AspNetRoles", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Name = table.Column<string>(null, nullable, 0x100, false, null, true, null, null, null, nullable),
        //            NormalizedName = table.Column<string>(null, nullable, 0x100, false, null, true, null, null, null, nullable),
        //            ConcurrencyStamp = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType12<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType12<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AspNetRoles", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType12<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType12<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("Construtoras", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            RazaoSocial = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            NomeFantasia = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Logradouro = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            LogradouroNum = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Complemento = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Bairro = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Cidade = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            CEP = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Estado = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Pais = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Website = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Email = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Fone = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            CNPJ = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Logotipo = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            SetorAtuacaoHist = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            SociedadeAdms = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            InfoPlanoNegocios = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            InfoValorMobOfertado = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ComunPrestInfoContAposOferta = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            AlertaSobreRiscos = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            InfoRemunPlataforma = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            CaracOfertaTribuAplicavel = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            IncorpConstrut = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            EstudoViabEcoFinanc = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            OutrasInfos = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType13<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType13<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_Construtoras", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType13<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType13<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("DUMPSQL", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            URLBAK = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType14<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType14<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_DUMPSQL", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType14<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType14<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("FAQ", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Descricao = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType15<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType15<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_FAQ", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType15<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType15<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("HgGeoIp_Pais_Flags", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            svg = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            png_16 = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType16<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType16<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_HgGeoIp_Pais_Flags", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType16<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType16<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("INVEST_ModeloDocs", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Titulo = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Texto = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Hyperlink = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType17<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType17<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_INVEST_ModeloDocs", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType17<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType17<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("LOGACOESUSUs", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            scrollLeft = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            scrollTop = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Url = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType18<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType18<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_LOGACOESUSUs", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType18<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType18<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("SEO_Visitas", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            URL = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            IdUsu = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType19<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType19<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_SEO_Visitas", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType19<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType19<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("TaxaMercados", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            data = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            cdi = table.Column<float>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            selic = table.Column<float>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            fator_diario = table.Column<float>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType20<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType20<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_TaxaMercados", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType20<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType20<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("TaxasGLOBAIS", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            descricao = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            valor = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            pre_selec = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            informacoes = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType21<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType21<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_TaxasGLOBAIS", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType21<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType21<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("tblHubConversas", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            De = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            DeCnxId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Para = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ParaCnxId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Mensagem = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Lida = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType22<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType22<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_tblHubConversas", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType22<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType22<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //    });
        //    migrationBuilder.CreateTable("AppConfiguracoes", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            NovosUsuarios = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            NovosUsuarios_NivelADM = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Descricao = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            URLExibicao = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Tema = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            CaminhoAbsolutoTema = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            AppConfiguracoes_AplicativoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            AppConfiguracoes_AzureId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AppConfiguracoes", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AppConfiguracoes_AppConfiguracoes_Aplicativo_AppConfiguracoes_AplicativoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_AppConfiguracoes_AplicativoId, <> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AppConfiguracoes_Aplicativo", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AppConfiguracoes_AppConfiguracoes_Azure_AppConfiguracoes_AzureId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_AppConfiguracoes_AzureId, <> f__AnonymousType23<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AppConfiguracoes_Azure", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("AspNetRoleClaims", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            RoleId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            ClaimType = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ClaimValue = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType24<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType24<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AspNetRoleClaims", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType24<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType24<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType24<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AspNetRoleClaims_AspNetRoles_RoleId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType24<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_RoleId, <> f__AnonymousType24<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AspNetRoles", "Id", null, 0, 2);
        //    });
        //    migrationBuilder.CreateTable("FAQItens", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Pergunta = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Resposta = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Ordem = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            FAQId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType25<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType25<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_FAQItens", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType25<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType25<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType25<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_FAQItens_FAQ_FAQId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType25<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_FAQId, <> f__AnonymousType25<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "FAQ", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("HgGeoIp_Paises", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            name = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            code = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            capital = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            HgGeoIp_Pais_FlagId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            calling_code = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType26<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType26<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_HgGeoIp_Paises", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType26<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType26<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType26<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_HgGeoIp_Paises_HgGeoIp_Pais_Flags_HgGeoIp_Pais_FlagId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType26<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_HgGeoIp_Pais_FlagId, <> f__AnonymousType26<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "HgGeoIp_Pais_Flags", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("AppPerfil", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            AppConfiguracoesId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType27<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType27<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AppPerfil", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType27<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType27<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType27<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AppPerfil_AppConfiguracoes_AppConfiguracoesId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType27<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_AppConfiguracoesId, <> f__AnonymousType27<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AppConfiguracoes", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("AspNetUsers", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UserName = table.Column<string>(null, nullable, 0x100, false, null, true, null, null, null, nullable),
        //            NormalizedUserName = table.Column<string>(null, nullable, 0x100, false, null, true, null, null, null, nullable),
        //            Email = table.Column<string>(null, nullable, 0x100, false, null, true, null, null, null, nullable),
        //            NormalizedEmail = table.Column<string>(null, nullable, 0x100, false, null, true, null, null, null, nullable),
        //            EmailConfirmed = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            PasswordHash = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            SecurityStamp = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ConcurrencyStamp = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            PhoneNumber = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            PhoneNumberConfirmed = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            TwoFactorEnabled = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            LockoutEnd = table.Column<DateTimeOffset>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            LockoutEnabled = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            AccessFailedCount = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Nome = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Sobrenome = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Nascimento = table.Column<DateTime>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Genero = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            EstadoCivil = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            AvatarUsuario = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ImagemFundoPerfil = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Bio = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Documentacao_TPPessoa = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Documentacao_CPF = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Documentacao_CNPJ = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Documentacao_RG = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Trabalho_Empresa = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Trabalho_Cargo = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Trabalho_Profissao = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Logradouro = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_LogradouroNum = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Complemento = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Bairro = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Cidade = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_CEP = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Estado = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Pais = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Escritorio = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Website = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_FoneComercial = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_FoneCelular = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Financeiro_Banco_Nome = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Financeiro_Banco_Ag = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Financeiro_Banco_CC = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Financeiro_Investidor_Perfil = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ContatoAutenticacao_Fone = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ContatoAutenticacao_Email = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ContatoAutenticacao_FoneAlternativo = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ContatoAutenticacao_EmailAlternativo = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            MidiasSociais_Facebook = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            MidiasSociais_Twitter = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            MidiasSociais_Instagram = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            MidiasSociais_GooglePlus = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            MidiasSociais_Linkedin = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            MidiasSociais_Youtube = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            MidiasSociais_Pinterest = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Sistema_FuncaoUsuario = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Sistema_URLComprovanteResidencia = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Sistema_URLSelfieDocFRENTE = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Sistema_URLSelfieDocVERSO = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Sistema_URLFotoDoc = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Sistema_AcessoBloqueado = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Sistema_DeclaracaoCienciaTermos = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Sistema_DeclaracaoPessoaExposta = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Sistema_NaoAparecerListaProjetos = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Sistema_DataDeclaracaoCienciaTermos = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            AppConfiguracoesId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType28<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType28<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AspNetUsers", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType28<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType28<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType28<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AspNetUsers_AppConfiguracoes_AppConfiguracoesId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType28<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_AppConfiguracoesId, <> f__AnonymousType28<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AppConfiguracoes", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("ResultsGeoIps", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            address = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            type = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            city = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            region = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            country_name = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            continent = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            continent_code = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            region_code = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            HgGeoIp_PaisId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            latitude = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            longitude = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            woeid = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType29<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType29<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_ResultsGeoIps", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType29<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType29<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType29<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_ResultsGeoIps_HgGeoIp_Paises_HgGeoIp_PaisId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType29<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_HgGeoIp_PaisId, <> f__AnonymousType29<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "HgGeoIp_Paises", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("GaleriaPerfilAlbum", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            AppPerfilId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Nome = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Descricao = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType30<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType30<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_GaleriaPerfilAlbum", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType30<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType30<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType30<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_GaleriaPerfilAlbum_AppPerfil_AppPerfilId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType30<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_AppPerfilId, <> f__AnonymousType30<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AppPerfil", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("AspNetUserClaims", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            UserId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            ClaimType = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ClaimValue = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType31<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType31<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AspNetUserClaims", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType31<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType31<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType31<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AspNetUserClaims_AspNetUsers_UserId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType31<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UserId, <> f__AnonymousType31<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AspNetUsers", "Id", null, 0, 2);
        //    });
        //    migrationBuilder.CreateTable("AspNetUserLogins", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            LoginProvider = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            ProviderKey = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            ProviderDisplayName = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            UserId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        Expression[] expressionArray1 = new Expression[] { (Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_LoginProvider, <> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), (Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_ProviderKey, <> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)) };
        //        MemberInfo[] infoArray1 = new MemberInfo[] { methodof(<> f__AnonymousType33<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_LoginProvider, <> f__AnonymousType33<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), methodof(<> f__AnonymousType33<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_ProviderKey, <> f__AnonymousType33<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>) };
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AspNetUserLogins", Expression.Lambda((Expression)Expression.New((ConstructorInfo)methodof(<> f__AnonymousType33<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>..ctor, <> f__AnonymousType33<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), expressionArray1, infoArray1), expressionArray2));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AspNetUserLogins_AspNetUsers_UserId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UserId, <> f__AnonymousType32<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetUsers", "Id", null, 0, 2);
        //    });
        //    migrationBuilder.CreateTable("AspNetUserRoles", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            UserId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            RoleId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        Expression[] expressionArray1 = new Expression[] { (Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UserId, <> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), (Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_RoleId, <> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)) };
        //        MemberInfo[] infoArray1 = new MemberInfo[] { methodof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UserId, <> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), methodof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_RoleId, <> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>) };
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AspNetUserRoles", Expression.Lambda((Expression)Expression.New((ConstructorInfo)methodof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>..ctor, <> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), expressionArray1, infoArray1), expressionArray2));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AspNetUserRoles_AspNetRoles_RoleId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_RoleId, <> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetRoles", "Id", null, 0, 2);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray4 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AspNetUserRoles_AspNetUsers_UserId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UserId, <> f__AnonymousType34<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray4), "AspNetUsers", "Id", null, 0, 2);
        //    });
        //    migrationBuilder.CreateTable("AspNetUserTokens", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            UserId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            LoginProvider = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Name = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Value = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        Expression[] expressionArray1 = new Expression[] { (Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UserId, <> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), (Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_LoginProvider, <> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), (Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Name, <> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)) };
        //        MemberInfo[] infoArray1 = new MemberInfo[] { methodof(<> f__AnonymousType36<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UserId, <> f__AnonymousType36<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), methodof(<> f__AnonymousType36<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_LoginProvider, <> f__AnonymousType36<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), methodof(<> f__AnonymousType36<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Name, <> f__AnonymousType36<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>) };
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_AspNetUserTokens", Expression.Lambda((Expression)Expression.New((ConstructorInfo)methodof(<> f__AnonymousType36<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>..ctor, <> f__AnonymousType36<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), expressionArray1, infoArray1), expressionArray2));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_AspNetUserTokens_AspNetUsers_UserId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UserId, <> f__AnonymousType35<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetUsers", "Id", null, 0, 2);
        //    });
        //    migrationBuilder.CreateTable("LOGCENTRALs", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppCriadorId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            TIPO = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            IP = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            VALOR = table.Column<double>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            ACAO = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            STATUS = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            MENSAGEM = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            ICOMENS = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_LOGCENTRALs", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_LOGCENTRALs_AspNetUsers_UsuarioAppCriadorId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppCriadorId, <> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AspNetUsers", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_LOGCENTRALs_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType37<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("PreferSalaVIPs", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            CabecalhoFixo = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BarrasFixas = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            TopoFixo = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            RodapeFixo = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            FormatoCaixa = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            MenuFixo = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Tema = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType38<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType38<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_PreferSalaVIPs", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType38<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType38<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType38<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_PreferSalaVIPs_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType38<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType38<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("tblHubClientes", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Email = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            CnxId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Status = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType39<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType39<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_tblHubClientes", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType39<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType39<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType39<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_tblHubClientes_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType39<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType39<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("tblUsuSalaVIPs", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            CnxId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Status = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType40<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType40<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_tblUsuSalaVIPs", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType40<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType40<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType40<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_tblUsuSalaVIPs_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType40<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType40<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("HgGeoIps", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            by = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            valid_key = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            ResultsGeoIpId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            execution_time = table.Column<float>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            from_cache = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType41<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType41<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_HgGeoIps", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType41<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType41<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType41<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_HgGeoIps_ResultsGeoIps_ResultsGeoIpId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType41<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_ResultsGeoIpId, <> f__AnonymousType41<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "ResultsGeoIps", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("BlocoProjInvestimentos", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Ativo = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UrlImgPrinc = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Valor = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            LanceMinimo = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Titulo = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Contador_Exib = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Contador_DataFinal = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            BlocoProjInvest_ExibTitulo = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            SaldoReservado = table.Column<double>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            ValorMinimoDocs = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Status = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            GaleriaPerfilAlbumId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            ConstrutoraId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            DescricaoDetalhadaProjeto = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            LinkVideoProjeto = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Logradouro = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Contato_LogradouroNum = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Complemento = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Contato_Bairro = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Contato_Cidade = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Contato_CEP = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Contato_Estado = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Rentabilidade_TIR_TIT = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Rentabilidade_PRE_TIT = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Rentabilidade_ROI_TIT = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Rentabilidade_TIR_INI = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Rentabilidade_TIR_FIM = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Rentabilidade_PRE_INI = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Rentabilidade_PRE_FIM = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Rentabilidade_ROI_INI = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Rentabilidade_ROI_FIM = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            DataLimiteSuspensao = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            AndamentoObra = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            AndamentoObraAcabamento = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_BlocoProjInvestimentos", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_BlocoProjInvestimentos_Construtoras_ConstrutoraId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_ConstrutoraId, <> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "Construtoras", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_BlocoProjInvestimentos_GaleriaPerfilAlbum_GaleriaPerfilAlbumId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_GaleriaPerfilAlbumId, <> f__AnonymousType42<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "GaleriaPerfilAlbum", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("GaleriaPerfilImagem", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            GaleriaPerfilAlbumId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Descricao = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Url = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType43<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType43<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_GaleriaPerfilImagem", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType43<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType43<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType43<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_GaleriaPerfilImagem_GaleriaPerfilAlbum_GaleriaPerfilAlbumId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType43<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_GaleriaPerfilAlbumId, <> f__AnonymousType43<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "GaleriaPerfilAlbum", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("BlocoProjInvestimento_ItemDocs", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BlocoProjInvestimentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            INVEST_ModeloDocId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_BlocoProjInvestimento_ItemDocs", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_BlocoProjInvestimento_ItemDocs_BlocoProjInvestimentos_BlocoProjInvestimentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_BlocoProjInvestimentoId, <> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "BlocoProjInvestimentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_BlocoProjInvestimento_ItemDocs_INVEST_ModeloDocs_INVEST_ModeloDocId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_INVEST_ModeloDocId, <> f__AnonymousType44<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "INVEST_ModeloDocs", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("BlocoProjInvestimentoComentarios", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BlocoProjInvestimentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Comentario = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_BlocoProjInvestimentoComentarios", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_BlocoProjInvestimentoComentarios_BlocoProjInvestimentos_BlocoProjInvestimentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_BlocoProjInvestimentoId, <> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "BlocoProjInvestimentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_BlocoProjInvestimentoComentarios_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType45<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("BlocoProjInvestimentoValores", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Valor = table.Column<double>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BlocoProjInvestimentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_BlocoProjInvestimentoValores", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_BlocoProjInvestimentoValores_BlocoProjInvestimentos_BlocoProjInvestimentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_BlocoProjInvestimentoId, <> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "BlocoProjInvestimentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_BlocoProjInvestimentoValores_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType46<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("INVEST_ControleTransfs", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BlocoProjInvestimentosId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Valor = table.Column<double>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Status = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            IdCompensacao = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_INVEST_ControleTransfs", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_INVEST_ControleTransfs_BlocoProjInvestimentos_BlocoProjInvestimentosId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_BlocoProjInvestimentosId, <> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "BlocoProjInvestimentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_INVEST_ControleTransfs_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType47<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("INVEST_Lancamentos", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BlocoProjInvestimentosId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            TP = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Valor = table.Column<double>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Status = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            PerfilInvestidorInformado = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            DataLimiteCancelamento = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_INVEST_Lancamentos", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_INVEST_Lancamentos_BlocoProjInvestimentos_BlocoProjInvestimentosId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_BlocoProjInvestimentosId, <> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "BlocoProjInvestimentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_INVEST_Lancamentos_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType48<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("InvestimentoDocUsuarios", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BlocoProjInvestimentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            URL = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_InvestimentoDocUsuarios", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_InvestimentoDocUsuarios_BlocoProjInvestimentos_BlocoProjInvestimentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_BlocoProjInvestimentoId, <> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "BlocoProjInvestimentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_InvestimentoDocUsuarios_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType49<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("Tranferencias", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Valor = table.Column<double>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            URLComprovante = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            IdUsu = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            IdIncorporadora = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BlocoProjInvestimentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            DataLimite = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType50<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType50<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_Tranferencias", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType50<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType50<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType50<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_Tranferencias_BlocoProjInvestimentos_BlocoProjInvestimentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType50<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_BlocoProjInvestimentoId, <> f__AnonymousType50<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "BlocoProjInvestimentos", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("INVEST_LancamentoDocs", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            INVEST_LancamentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            INVEST_ModeloDocId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            URLDoc = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            TP = table.Column<string>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_INVEST_LancamentoDocs", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_INVEST_LancamentoDocs_INVEST_Lancamentos_INVEST_LancamentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_INVEST_LancamentoId, <> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "INVEST_Lancamentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_INVEST_LancamentoDocs_INVEST_ModeloDocs_INVEST_ModeloDocId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_INVEST_ModeloDocId, <> f__AnonymousType51<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "INVEST_ModeloDocs", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("INVEST_LancamentoImagens", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            INVEST_LancamentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            URLComprovTransf = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            URLPerfilInvest = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType52<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType52<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_INVEST_LancamentoImagens", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType52<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType52<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType52<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_INVEST_LancamentoImagens_INVEST_Lancamentos_INVEST_LancamentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType52<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_INVEST_LancamentoId, <> f__AnonymousType52<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "INVEST_Lancamentos", "Id", null, 0, 1);
        //    });
        //    migrationBuilder.CreateTable("InvestimentoConfirmacoes", delegate (ColumnsBuilder table)
        //    {
        //        bool? nullable = null;
        //        int? nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        nullable = null;
        //        nullable2 = null;
        //        nullable = null;
        //        return new
        //        {
        //            Id = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable).Annotation("SqlServer:ValueGenerationStrategy", (SqlServerValueGenerationStrategy)1),
        //            DTHR = table.Column<DateTime>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            BlocoProjInvestimentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            UsuarioAppId = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Valor = table.Column<double>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            Token = table.Column<string>(null, nullable, nullable2, false, null, true, null, null, null, nullable),
        //            Confirmado = table.Column<bool>(null, nullable, nullable2, false, null, false, null, null, null, nullable),
        //            INVEST_LancamentoId = table.Column<int>(null, nullable, nullable2, false, null, false, null, null, null, nullable)
        //        };
        //    }, null, delegate (CreateTableBuilder<<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>> > table) {
        //        ParameterExpression expression = Expression.Parameter((Type)typeof(<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
        //        table.PrimaryKey("PK_InvestimentoConfirmacoes", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_Id, <> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray1));
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_InvestimentoConfirmacoes_BlocoProjInvestimentos_BlocoProjInvestimentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_BlocoProjInvestimentoId, <> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray2), "BlocoProjInvestimentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_InvestimentoConfirmacoes_INVEST_Lancamentos_INVEST_LancamentoId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_INVEST_LancamentoId, <> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray3), "INVEST_Lancamentos", "Id", null, 0, 1);
        //        expression = Expression.Parameter((Type)typeof(<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>), "x");
        //        ParameterExpression[] expressionArray4 = new ParameterExpression[] { expression };
        //        table.ForeignKey("FK_InvestimentoConfirmacoes_AspNetUsers_UsuarioAppId", Expression.Lambda((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(<> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>.get_UsuarioAppId, <> f__AnonymousType53<OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>, OperationBuilder<AddColumnOperation>>)), expressionArray4), "AspNetUsers", "Id", null, 0, 1);
        //    });
        //    string[] textArray1 = new string[0x1f];
        //    textArray1[0] = "Id";
        //    textArray1[1] = "Bairro";
        //    textArray1[2] = "CEP";
        //    textArray1[3] = "CPFCNPJ";
        //    textArray1[4] = "Celular";
        //    textArray1[5] = "Cidade";
        //    textArray1[6] = "Complemento";
        //    textArray1[7] = "DTHR";
        //    textArray1[8] = "EmailContato";
        //    textArray1[9] = "EmailSuporte";
        //    textArray1[10] = "EmailVendas";
        //    textArray1[11] = "Empresa";
        //    textArray1[12] = "Estado";
        //    textArray1[13] = "Fone";
        //    textArray1[14] = "FoneRecados";
        //    textArray1[15] = "LogotipoEmpresa";
        //    textArray1[0x10] = "Logradouro";
        //    textArray1[0x11] = "dumpSQLHost";
        //    textArray1[0x12] = "dumpSQLPass";
        //    textArray1[0x13] = "dumpSQLUser";
        //    textArray1[20] = "mailFrom";
        //    textArray1[0x15] = "mailToAdd";
        //    textArray1[0x16] = "smtpCredentialsEmail";
        //    textArray1[0x17] = "smtpCredentialsSenha";
        //    textArray1[0x18] = "smtpEnableSsl";
        //    textArray1[0x19] = "smtpHost";
        //    textArray1[0x1a] = "smtpPort";
        //    textArray1[0x1b] = "smtpUseDefaultCredentials";
        //    textArray1[0x1c] = "temporizaLmiteMaximoCancelaInvestimento";
        //    textArray1[0x1d] = "temporizaLmiteMaximoOfertaSuspensa";
        //    textArray1[30] = "temporizaLmiteMaximoRevogaInvestimento";
        //    object[] objArray1 = new object[0x1f];
        //    objArray1[0] = 1;
        //    objArray1[1] = "JD. NOSSA SENHORA DO CARMO";
        //    objArray1[2] = "08275-010";
        //    objArray1[3] = "14.581.834/0001-42";
        //    objArray1[4] = "(11) 99881-4900";
        //    objArray1[5] = "SAO PAULO";
        //    objArray1[6] = "";
        //    objArray1[7] = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x25f, (DateTimeKind)DateTimeKind.Local).AddTicks(0x8efL);
        //    objArray1[8] = "leandrodiascarvalho@hotmail.com";
        //    objArray1[9] = "leandrodiascarvalho@hotmail.com";
        //    objArray1[10] = "leandrodiascarvalho@hotmail.com";
        //    objArray1[11] = "DEPOIS DA LINHA";
        //    objArray1[12] = "SP";
        //    objArray1[13] = "(11) 99881-4900";
        //    objArray1[14] = "(11) 99881-4900";
        //    objArray1[15] = "/images/avatar-depois-da-linha.png";
        //    objArray1[0x10] = "MATEUS MENDES PEREIRA, 312";
        //    objArray1[0x11] = "66EAF4C0C88A6F125E6743DF57CEF052";
        //    objArray1[0x12] = "B490B0B3AD983905BE51BE383C8F9D829B11776439CF9D86E260DB21BD141904";
        //    objArray1[0x13] = "711429BCCA6C1DACA75A01DF6DA3E941";
        //    objArray1[20] = "F517408DFEF409845DE190A43EA194F50EE16B97A7EBFD67DEE0D257133CC958";
        //    objArray1[0x15] = "5CFDDB0D72BEAE3950A6066C5AD471C4CC821BA669C5A7634F1B709064F1E04666DF0B48BB967A6F52A81E2376C3723F839C239801C4B71C3FE178CB57964AEC98B15756417D5ACE06F1B12D3BE207B5";
        //    objArray1[0x16] = "F517408DFEF409845DE190A43EA194F50EE16B97A7EBFD67DEE0D257133CC958";
        //    objArray1[0x17] = "DE183F10391850758E21842DFEFA2B3B";
        //    objArray1[0x18] = true;
        //    objArray1[0x19] = "BE1D8EA6948053684AC62657FBAB58B3";
        //    objArray1[0x1a] = 0x24b;
        //    objArray1[0x1b] = false;
        //    objArray1[0x1c] = "D3F9EDBE6ABC40A63D5CF85B24F666A8";
        //    objArray1[0x1d] = "B181370B7EF0D09FA17561E1A8310E31";
        //    objArray1[30] = "ED123C03D2D7FC5F378DD4DB227C16FB";
        //    migrationBuilder.InsertData("AppConfiguracoes_Aplicativo", textArray1, objArray1, null);
        //    string[] textArray2 = new string[] { "Id", "DTHR", "EnderecoArmazLocal", "UsarSimuladorLocal", "_azureblob_AccountKey", "_azureblob_AccountName", "_azureblob_ContainerRaiz" };
        //    object[] objArray2 = new object[] { 1, new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x277, (DateTimeKind)DateTimeKind.Local).AddTicks(0xaf8L), "", false, "B7F9DD2BA3180A2AC1AE87482117BC9FC598FFC24B18402C434CEC6AC354FCBFC1DF2BBC848FB9D161B59F460A343838B3A66E1F7B0DCC9B0C25EF922D49FA47A438E3822FDC43DA436A583387945E82AEDCE81C4F2BB57BA94D4D46CC29A31C", "416B955DF5FCD4244EC8548581DC9BA3", "EAB44E95599081721154E4905C474E42" };
        //    migrationBuilder.InsertData("AppConfiguracoes_Azure", textArray2, objArray2, null);
        //    string[] textArray3 = new string[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" };
        //    object[] objArray3 = new object[14, 4];
        //    objArray3[0, 0] = "59c39ee9-024a-41c1-bae8-7859879aa9f2";
        //    objArray3[0, 1] = "89a7227e-9d9d-4f24-9bbe-a08f6feffa50";
        //    objArray3[0, 2] = "SIS";
        //    objArray3[0, 3] = "SIS";
        //    objArray3[1, 0] = "d3f04340-133b-4fe5-964f-725cf3482cbb";
        //    objArray3[1, 1] = "c2a01ba0-50e9-4372-9667-48e5260785e1";
        //    objArray3[1, 2] = "ADM";
        //    objArray3[1, 3] = "ADM";
        //    objArray3[2, 0] = "730f160e-5178-4f3c-a955-2c12abc4d1f9";
        //    objArray3[2, 1] = "b9cdd298-3ac6-414b-9434-fdea77870067";
        //    objArray3[2, 2] = "SUPERVISOR";
        //    objArray3[2, 3] = "SUPERVISOR";
        //    objArray3[3, 0] = "a59726df-21c5-44c8-96ba-a4a2244dea3c";
        //    objArray3[3, 1] = "ed9c0b8a-ae78-4846-9891-c15daed83ec8";
        //    objArray3[3, 2] = "ADMCONTA";
        //    objArray3[3, 3] = "ADMCONTA";
        //    objArray3[4, 0] = "ced87445-4121-45ff-b05e-6965f5014bc8";
        //    objArray3[4, 1] = "4cb7a313-3d5b-4329-8523-17a91d08aa61";
        //    objArray3[4, 2] = "API";
        //    objArray3[4, 3] = "API";
        //    objArray3[5, 0] = "8f0a2fbc-ec7d-47e2-b307-0d5085e57275";
        //    objArray3[5, 1] = "fb6082d9-cc70-486d-96b2-d3cc806857b9";
        //    objArray3[5, 2] = "MANUTAPP";
        //    objArray3[5, 3] = "MANUTAPP";
        //    objArray3[6, 0] = "e42f1601-ac85-4384-8fd4-f3c4345b56db";
        //    objArray3[6, 1] = "bf81164a-8bc3-4f45-b03a-9cefc4b85f74";
        //    objArray3[6, 2] = "SUPORTE";
        //    objArray3[6, 3] = "SUPORTE";
        //    objArray3[7, 0] = "c91c9806-bd59-4a8e-ade6-13bc0427602c";
        //    objArray3[7, 1] = "3a8e4da0-b5e7-4320-a564-08314f14a33e";
        //    objArray3[7, 2] = "COMUNIDADE";
        //    objArray3[7, 3] = "COMUNIDADE";
        //    objArray3[8, 0] = "257310a1-a0bf-4625-ae12-a31c2940e5af";
        //    objArray3[8, 1] = "c8e63732-e740-4a80-8430-3eb95dc78080";
        //    objArray3[8, 2] = "FINANCEIRO";
        //    objArray3[8, 3] = "FINANCEIRO";
        //    objArray3[9, 0] = "acbfb305-1c76-4a54-8c40-36ff8ac5312e";
        //    objArray3[9, 1] = "3356fea7-d7c9-4188-a7b5-6919f66f1c4b";
        //    objArray3[9, 2] = "MARKETING";
        //    objArray3[9, 3] = "MARKETING";
        //    objArray3[10, 0] = "eb7726bc-7c17-446c-a22a-72df87922494";
        //    objArray3[10, 1] = "7695fcc1-999d-4eb2-acdc-5e9ca57bc821";
        //    objArray3[10, 2] = "MIDIAS";
        //    objArray3[10, 3] = "MIDIAS";
        //    objArray3[11, 0] = "99d47b3f-b8f7-435a-b6a0-7dd2e80f4d30";
        //    objArray3[11, 1] = "418d8670-7f66-4e6e-8812-d1a4141a67ae";
        //    objArray3[11, 2] = "VENDA";
        //    objArray3[11, 3] = "VENDA";
        //    objArray3[12, 0] = "16b933cf-e693-47d5-9957-d217467d17a6";
        //    objArray3[12, 1] = "b5e49d47-bd1c-421e-82e2-872b40b5937a";
        //    objArray3[12, 2] = "DESENVOLVEDOR";
        //    objArray3[12, 3] = "DESENVOLVEDOR";
        //    objArray3[13, 0] = "96c373b4-8cc5-4a63-9f9a-81884a5efe75";
        //    objArray3[13, 1] = "c4e0ce90-1867-4a71-a7a7-1dbb3a8bd11c";
        //    objArray3[13, 2] = "USU";
        //    objArray3[13, 3] = "USU";
        //    migrationBuilder.InsertData("AspNetRoles", textArray3, objArray3, null);
        //    string[] textArray4 = new string[10];
        //    textArray4[0] = "Id";
        //    textArray4[1] = "AppConfiguracoes_AplicativoId";
        //    textArray4[2] = "AppConfiguracoes_AzureId";
        //    textArray4[3] = "CaminhoAbsolutoTema";
        //    textArray4[4] = "DTHR";
        //    textArray4[5] = "Descricao";
        //    textArray4[6] = "NovosUsuarios";
        //    textArray4[7] = "NovosUsuarios_NivelADM";
        //    textArray4[8] = "Tema";
        //    textArray4[9] = "URLExibicao";
        //    object[] objArray4 = new object[10];
        //    objArray4[0] = 1;
        //    objArray4[1] = 1;
        //    objArray4[2] = 1;
        //    objArray4[3] = "";
        //    objArray4[4] = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x240, (DateTimeKind)DateTimeKind.Local).AddTicks((long)100);
        //    objArray4[5] = "Tema padr\x00e3o";
        //    objArray4[6] = false;
        //    objArray4[7] = true;
        //    objArray4[8] = "_Layout";
        //    objArray4[9] = "padrao";
        //    migrationBuilder.InsertData("AppConfiguracoes", textArray4, objArray4, null);
        //    string[] textArray5 = new string[] { "Id", "AppConfiguracoesId", "DTHR" };
        //    object[] objArray5 = new object[] { 1, 1, new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x27b, (DateTimeKind)DateTimeKind.Local).AddTicks(0x6e9L) };
        //    migrationBuilder.InsertData("AppPerfil", textArray5, objArray5, null);
        //    string[] textArray6 = new string[0x44];
        //    textArray6[0] = "Id";
        //    textArray6[1] = "AccessFailedCount";
        //    textArray6[2] = "AppConfiguracoesId";
        //    textArray6[3] = "AvatarUsuario";
        //    textArray6[4] = "Bio";
        //    textArray6[5] = "ConcurrencyStamp";
        //    textArray6[6] = "ContatoAutenticacao_Email";
        //    textArray6[7] = "ContatoAutenticacao_EmailAlternativo";
        //    textArray6[8] = "ContatoAutenticacao_Fone";
        //    textArray6[9] = "ContatoAutenticacao_FoneAlternativo";
        //    textArray6[10] = "Contato_Bairro";
        //    textArray6[11] = "Contato_CEP";
        //    textArray6[12] = "Contato_Cidade";
        //    textArray6[13] = "Contato_Complemento";
        //    textArray6[14] = "Contato_Escritorio";
        //    textArray6[15] = "Contato_Estado";
        //    textArray6[0x10] = "Contato_FoneCelular";
        //    textArray6[0x11] = "Contato_FoneComercial";
        //    textArray6[0x12] = "Contato_Logradouro";
        //    textArray6[0x13] = "Contato_LogradouroNum";
        //    textArray6[20] = "Contato_Pais";
        //    textArray6[0x15] = "Contato_Website";
        //    textArray6[0x16] = "Documentacao_CNPJ";
        //    textArray6[0x17] = "Documentacao_CPF";
        //    textArray6[0x18] = "Documentacao_RG";
        //    textArray6[0x19] = "Documentacao_TPPessoa";
        //    textArray6[0x1a] = "Email";
        //    textArray6[0x1b] = "EmailConfirmed";
        //    textArray6[0x1c] = "EstadoCivil";
        //    textArray6[0x1d] = "Financeiro_Banco_Ag";
        //    textArray6[30] = "Financeiro_Banco_CC";
        //    textArray6[0x1f] = "Financeiro_Banco_Nome";
        //    textArray6[0x20] = "Financeiro_Investidor_Perfil";
        //    textArray6[0x21] = "Genero";
        //    textArray6[0x22] = "ImagemFundoPerfil";
        //    textArray6[0x23] = "LockoutEnabled";
        //    textArray6[0x24] = "LockoutEnd";
        //    textArray6[0x25] = "MidiasSociais_Facebook";
        //    textArray6[0x26] = "MidiasSociais_GooglePlus";
        //    textArray6[0x27] = "MidiasSociais_Instagram";
        //    textArray6[40] = "MidiasSociais_Linkedin";
        //    textArray6[0x29] = "MidiasSociais_Pinterest";
        //    textArray6[0x2a] = "MidiasSociais_Twitter";
        //    textArray6[0x2b] = "MidiasSociais_Youtube";
        //    textArray6[0x2c] = "Nascimento";
        //    textArray6[0x2d] = "Nome";
        //    textArray6[0x2e] = "NormalizedEmail";
        //    textArray6[0x2f] = "NormalizedUserName";
        //    textArray6[0x30] = "PasswordHash";
        //    textArray6[0x31] = "PhoneNumber";
        //    textArray6[50] = "PhoneNumberConfirmed";
        //    textArray6[0x33] = "SecurityStamp";
        //    textArray6[0x34] = "Sistema_AcessoBloqueado";
        //    textArray6[0x35] = "Sistema_DataDeclaracaoCienciaTermos";
        //    textArray6[0x36] = "Sistema_DeclaracaoCienciaTermos";
        //    textArray6[0x37] = "Sistema_DeclaracaoPessoaExposta";
        //    textArray6[0x38] = "Sistema_FuncaoUsuario";
        //    textArray6[0x39] = "Sistema_NaoAparecerListaProjetos";
        //    textArray6[0x3a] = "Sistema_URLComprovanteResidencia";
        //    textArray6[0x3b] = "Sistema_URLFotoDoc";
        //    textArray6[60] = "Sistema_URLSelfieDocFRENTE";
        //    textArray6[0x3d] = "Sistema_URLSelfieDocVERSO";
        //    textArray6[0x3e] = "Sobrenome";
        //    textArray6[0x3f] = "Trabalho_Cargo";
        //    textArray6[0x40] = "Trabalho_Empresa";
        //    textArray6[0x41] = "Trabalho_Profissao";
        //    textArray6[0x42] = "TwoFactorEnabled";
        //    textArray6[0x43] = "UserName";
        //    object[] objArray6 = new object[5, 0x44];
        //    objArray6[0, 0] = "b30b4d21-0f99-435e-acec-a2c672697b0f";
        //    objArray6[0, 1] = 0;
        //    objArray6[0, 2] = 1;
        //    objArray6[0, 3] = "19C6B9DC189309182D3EDE85CDFCD3C0FA7E12357D852FAE54445547238E4BF0";
        //    objArray6[0, 4] = "7223201CBA30A22927EEE5E8009F3CFC";
        //    objArray6[0, 5] = "101e6c5f-59c0-4544-a728-782ba76d0611";
        //    objArray6[0, 6] = "8CF74E568EA5B35D3835599521141757058C23F92DAB03337B452304016F5415";
        //    objArray6[0, 7] = "43436B5D54865325C2142528313460857B6E3DEA0C5784669EC1AF8033F298DB";
        //    objArray6[0, 8] = "05CC644D54505E45C7BA1BC537C904B4";
        //    objArray6[0, 9] = "5CDD8271A37B090B4D2D766080427281";
        //    objArray6[0, 10] = "AC4D2703DDB4ECDFFBE6CDCF85D57EFAA6DC9CDCD6D8F2DE2C9F98411462F1FB";
        //    objArray6[0, 11] = "ED5BDAF6729F3DEE43BD3262730DFB85";
        //    objArray6[0, 12] = "09D8B4E96F6C50D48CEA2E7FDB168AB5";
        //    objArray6[0, 13] = "3DF0D12434457D7194C831CCDED68217";
        //    objArray6[0, 14] = "4F6178F614B10C9CF9C51AF56EFF0D8B16D8C61A58106F51DEBE9BA60FADFBC390ABF51139EA79902B67454A5B3984DC91ABFB404EB1431709B20F3350EE86E755703FE72631D6455F11EF52ED98330D";
        //    objArray6[0, 15] = "67BF623EC26BFB0E31E9E3755F64F92D";
        //    objArray6[0, 0x10] = "05CC644D54505E45C7BA1BC537C904B4";
        //    objArray6[0, 0x11] = "5CDD8271A37B090B4D2D766080427281";
        //    objArray6[0, 0x12] = "4F6178F614B10C9CF9C51AF56EFF0D8B2472CDC571C1D897D12BCE462CBF792C";
        //    objArray6[0, 0x13] = "";
        //    objArray6[0, 20] = "188C94448021F72179E959C8C22A5235";
        //    objArray6[0, 0x15] = "9EAAE2300C845D63A347F5961BB5ED651AE7D10BF66C6031C7BF28A44D80DE2E838190E549BB846CB1A5306A6B9E7F79";
        //    objArray6[0, 0x16] = "6CBF90ACBB00F5ECDB83BA969F950C2312232E024018AF97C28726C74FFC6FE9";
        //    objArray6[0, 0x17] = "C64ACB4FE9C58557494501F438D8E46B";
        //    objArray6[0, 0x18] = "AA20A747877F89351277E23E1FF03D3F";
        //    objArray6[0, 0x19] = "AC00C0AA39C7FF13CE7FEEC9969DCE5E";
        //    objArray6[0, 0x1a] = "adm@depoisdalinha.com.br";
        //    objArray6[0, 0x1b] = true;
        //    objArray6[0, 0x1c] = "8086554AF4C49F7899D7E2DD3C073C0D";
        //    objArray6[0, 0x1d] = "";
        //    objArray6[0, 30] = "";
        //    objArray6[0, 0x1f] = "";
        //    objArray6[0, 0x20] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[0, 0x21] = "44E1E3882B52FCC8234B7863CAF32AC1";
        //    objArray6[0, 0x22] = "/images/fundo_padrao_perfil.png";
        //    objArray6[0, 0x23] = false;
        //    objArray6[0, 0x25] = "";
        //    objArray6[0, 0x26] = "";
        //    objArray6[0, 0x27] = "";
        //    objArray6[0, 40] = "";
        //    objArray6[0, 0x29] = "";
        //    objArray6[0, 0x2a] = "";
        //    objArray6[0, 0x2b] = "";
        //    objArray6[0, 0x2c] = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind)DateTimeKind.Unspecified);
        //    objArray6[0, 0x2d] = "B7A21D4C503F34760FC6C17A1C48F84B";
        //    objArray6[0, 0x2e] = "adm@depoisdalinha.com.br";
        //    objArray6[0, 0x2f] = "adm@depoisdalinha.com.br";
        //    objArray6[0, 0x30] = "AQAAAAEAACcQAAAAEEUROHSF0nA9tt/w4PslWzvfLrLHn7bBqGaBeq9ud5I5yIjpHtfQ/l0PFaeYjikyGw==";
        //    objArray6[0, 0x31] = "+5511998814900";
        //    objArray6[0, 50] = true;
        //    objArray6[0, 0x33] = "";
        //    objArray6[0, 0x34] = false;
        //    objArray6[0, 0x35] = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x166, (DateTimeKind)DateTimeKind.Local).AddTicks(0x1ae8L);
        //    objArray6[0, 0x36] = true;
        //    objArray6[0, 0x37] = false;
        //    objArray6[0, 0x38] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[0, 0x39] = false;
        //    objArray6[0, 0x3a] = "";
        //    objArray6[0, 0x3b] = "";
        //    objArray6[0, 60] = "";
        //    objArray6[0, 0x3d] = "";
        //    objArray6[0, 0x3e] = "511E099EB38F8E594610520A4F613080";
        //    objArray6[0, 0x3f] = "AA2C637A3C3863080A3046539A39635B75E92CB57C0986FACA019AE5A17B9A46";
        //    objArray6[0, 0x40] = "FDB312CEDCA7BC781E69030EED215204";
        //    objArray6[0, 0x41] = "C46D2C2793536285D2CAFA18BEC9A17C";
        //    objArray6[0, 0x42] = false;
        //    objArray6[0, 0x43] = "adm@depoisdalinha.com.br";
        //    objArray6[1, 0] = "b1aadecb-4357-457d-bfea-27e153505497";
        //    objArray6[1, 1] = 0;
        //    objArray6[1, 2] = 1;
        //    objArray6[1, 3] = "432B4DD679BC8E3DE04F89CBBA514F9E6D8C125FA0C00CDF67B44091F95211FE4668E0CF7D27FBFCBECB27E474B12A73";
        //    objArray6[1, 4] = "E7767D052069A50DE93D25E4E9CB31DD";
        //    objArray6[1, 5] = "2962ebb0-f360-47f1-81e4-736fa6b1d50d";
        //    objArray6[1, 6] = "9AD978F878C0C880A7E62BB29D985273E5F4E65EF8E5C9C3DFBA81BE27D38E42";
        //    objArray6[1, 7] = "9AD978F878C0C880A7E62BB29D985273E5F4E65EF8E5C9C3DFBA81BE27D38E42";
        //    objArray6[1, 8] = "F6D4B3A852D8E2C9FC3AA7DF76D137E3";
        //    objArray6[1, 9] = "F6D4B3A852D8E2C9FC3AA7DF76D137E3";
        //    objArray6[1, 10] = "645333AEE2F40EEAFCF6C9D2396769D8";
        //    objArray6[1, 11] = "F8190D87D5515C6F61703D0983B80C2E";
        //    objArray6[1, 12] = "09D8B4E96F6C50D48CEA2E7FDB168AB5";
        //    objArray6[1, 13] = "3DF0D12434457D7194C831CCDED68217";
        //    objArray6[1, 14] = "F8A40F09EDD34409B7E6E4A34456F4157F57D6BA6DA0B6E51F16A7CD84422F2AA50F74D9043088A046424266C72BA761";
        //    objArray6[1, 15] = "67BF623EC26BFB0E31E9E3755F64F92D";
        //    objArray6[1, 0x10] = "F6D4B3A852D8E2C9FC3AA7DF76D137E3";
        //    objArray6[1, 0x11] = "F6D4B3A852D8E2C9FC3AA7DF76D137E3";
        //    objArray6[1, 0x12] = "F8A40F09EDD34409B7E6E4A34456F415EE82760C3A1FAE3D852EEE9D8405C6EF";
        //    objArray6[1, 0x13] = "";
        //    objArray6[1, 20] = "188C94448021F72179E959C8C22A5235";
        //    objArray6[1, 0x15] = "D3CF7F5DE9E702974C41C0281D4E21089AFE0D0702DE29C60B41C3006556D661";
        //    objArray6[1, 0x16] = "9C399CD489452A9A9EE44FDF1C63063334BDE696E1C706BB4A2446800CB60A82";
        //    objArray6[1, 0x17] = "FECB68EF441B6FF7FF4BD584F863A2DB";
        //    objArray6[1, 0x18] = "2EC128A57C16437C98AAB7BD3C236F4B";
        //    objArray6[1, 0x19] = "AC00C0AA39C7FF13CE7FEEC9969DCE5E";
        //    objArray6[1, 0x1a] = "adm@house2invest.com.br";
        //    objArray6[1, 0x1b] = true;
        //    objArray6[1, 0x1c] = "8086554AF4C49F7899D7E2DD3C073C0D";
        //    objArray6[1, 0x1d] = "";
        //    objArray6[1, 30] = "";
        //    objArray6[1, 0x1f] = "";
        //    objArray6[1, 0x20] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[1, 0x21] = "44E1E3882B52FCC8234B7863CAF32AC1";
        //    objArray6[1, 0x22] = "/images/fundo_padrao_perfil.png";
        //    objArray6[1, 0x23] = false;
        //    objArray6[1, 0x25] = "";
        //    objArray6[1, 0x26] = "";
        //    objArray6[1, 0x27] = "";
        //    objArray6[1, 40] = "";
        //    objArray6[1, 0x29] = "";
        //    objArray6[1, 0x2a] = "";
        //    objArray6[1, 0x2b] = "";
        //    objArray6[1, 0x2c] = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind)DateTimeKind.Unspecified);
        //    objArray6[1, 0x2d] = "51E3E8C6C9CC0AC46984D32821700A57";
        //    objArray6[1, 0x2e] = "adm@house2invest.com.br";
        //    objArray6[1, 0x2f] = "adm@house2invest.com.br";
        //    objArray6[1, 0x30] = "AQAAAAEAACcQAAAAEMdICSP3Fvf5QijkOsSjuQn8tzL6kdfQF78BcnLP9JblbRxYurQP1BX+du1MFd2HRg==";
        //    objArray6[1, 0x31] = "+5511995951925";
        //    objArray6[1, 50] = true;
        //    objArray6[1, 0x33] = "";
        //    objArray6[1, 0x34] = false;
        //    objArray6[1, 0x35] = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x170, (DateTimeKind)DateTimeKind.Local).AddTicks(0x409L);
        //    objArray6[1, 0x36] = true;
        //    objArray6[1, 0x37] = false;
        //    objArray6[1, 0x38] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[1, 0x39] = false;
        //    objArray6[1, 0x3a] = "";
        //    objArray6[1, 0x3b] = "";
        //    objArray6[1, 60] = "";
        //    objArray6[1, 0x3d] = "";
        //    objArray6[1, 0x3e] = "97356CF65E5FD78B39BAA8249A8064A9";
        //    objArray6[1, 0x3f] = "AA14A749432228239F7A949F3BE8AE4F";
        //    objArray6[1, 0x40] = "5051B8ABFA8206DAA52CFFE3CB57B9FE";
        //    objArray6[1, 0x41] = "AA14A749432228239F7A949F3BE8AE4F";
        //    objArray6[1, 0x42] = false;
        //    objArray6[1, 0x43] = "adm@house2invest.com.br";
        //    objArray6[2, 0] = "4cb6d3d8-493a-415c-a5d7-cc6860aa8691";
        //    objArray6[2, 1] = 0;
        //    objArray6[2, 2] = 1;
        //    objArray6[2, 3] = "690F796D0CD780FCE2710E7DC08AA01C4AD8ABAA3767BABD54CAB426BBFFDFDA";
        //    objArray6[2, 4] = "E7767D052069A50DE93D25E4E9CB31DD";
        //    objArray6[2, 5] = "9ca8fc12-4ebb-4e21-a82c-3467135bf442";
        //    objArray6[2, 6] = "9AD978F878C0C880A7E62BB29D985273E5F4E65EF8E5C9C3DFBA81BE27D38E42";
        //    objArray6[2, 7] = "9AD978F878C0C880A7E62BB29D985273E5F4E65EF8E5C9C3DFBA81BE27D38E42";
        //    objArray6[2, 8] = "F6D4B3A852D8E2C9FC3AA7DF76D137E3";
        //    objArray6[2, 9] = "F6D4B3A852D8E2C9FC3AA7DF76D137E3";
        //    objArray6[2, 10] = "645333AEE2F40EEAFCF6C9D2396769D8";
        //    objArray6[2, 11] = "F8190D87D5515C6F61703D0983B80C2E";
        //    objArray6[2, 12] = "09D8B4E96F6C50D48CEA2E7FDB168AB5";
        //    objArray6[2, 13] = "3DF0D12434457D7194C831CCDED68217";
        //    objArray6[2, 14] = "F8A40F09EDD34409B7E6E4A34456F4157F57D6BA6DA0B6E51F16A7CD84422F2AA50F74D9043088A046424266C72BA761";
        //    objArray6[2, 15] = "67BF623EC26BFB0E31E9E3755F64F92D";
        //    objArray6[2, 0x10] = "F6D4B3A852D8E2C9FC3AA7DF76D137E3";
        //    objArray6[2, 0x11] = "F6D4B3A852D8E2C9FC3AA7DF76D137E3";
        //    objArray6[2, 0x12] = "F8A40F09EDD34409B7E6E4A34456F415EE82760C3A1FAE3D852EEE9D8405C6EF";
        //    objArray6[2, 0x13] = "";
        //    objArray6[2, 20] = "188C94448021F72179E959C8C22A5235";
        //    objArray6[2, 0x15] = "D3CF7F5DE9E702974C41C0281D4E21089AFE0D0702DE29C60B41C3006556D661";
        //    objArray6[2, 0x16] = "9C399CD489452A9A9EE44FDF1C63063334BDE696E1C706BB4A2446800CB60A82";
        //    objArray6[2, 0x17] = "FECB68EF441B6FF7FF4BD584F863A2DB";
        //    objArray6[2, 0x18] = "2EC128A57C16437C98AAB7BD3C236F4B";
        //    objArray6[2, 0x19] = "AC00C0AA39C7FF13CE7FEEC9969DCE5E";
        //    objArray6[2, 0x1a] = "vitor@house2invest.com.br";
        //    objArray6[2, 0x1b] = true;
        //    objArray6[2, 0x1c] = "8086554AF4C49F7899D7E2DD3C073C0D";
        //    objArray6[2, 0x1d] = "";
        //    objArray6[2, 30] = "";
        //    objArray6[2, 0x1f] = "";
        //    objArray6[2, 0x20] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[2, 0x21] = "44E1E3882B52FCC8234B7863CAF32AC1";
        //    objArray6[2, 0x22] = "/images/fundo_padrao_perfil.png";
        //    objArray6[2, 0x23] = false;
        //    objArray6[2, 0x25] = "";
        //    objArray6[2, 0x26] = "";
        //    objArray6[2, 0x27] = "";
        //    objArray6[2, 40] = "";
        //    objArray6[2, 0x29] = "";
        //    objArray6[2, 0x2a] = "";
        //    objArray6[2, 0x2b] = "";
        //    objArray6[2, 0x2c] = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind)DateTimeKind.Unspecified);
        //    objArray6[2, 0x2d] = "17CFDFFAC6A77D6AD1F466BF154D0181";
        //    objArray6[2, 0x2e] = "vitor@house2invest.com.br";
        //    objArray6[2, 0x2f] = "vitor@house2invest.com.br";
        //    objArray6[2, 0x30] = "AQAAAAEAACcQAAAAEBA+KyJXM8BQ6iEdP6Nf1iINOYN4NWIRpaoLp5uEERv/2aPwUnGS1/dUqgMIsZIVeA==";
        //    objArray6[2, 0x31] = "+5511995951925";
        //    objArray6[2, 50] = true;
        //    objArray6[2, 0x33] = "";
        //    objArray6[2, 0x34] = false;
        //    objArray6[2, 0x35] = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x179, (DateTimeKind)DateTimeKind.Local).AddTicks((long)80);
        //    objArray6[2, 0x36] = true;
        //    objArray6[2, 0x37] = false;
        //    objArray6[2, 0x38] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[2, 0x39] = false;
        //    objArray6[2, 0x3a] = "";
        //    objArray6[2, 0x3b] = "";
        //    objArray6[2, 60] = "";
        //    objArray6[2, 0x3d] = "";
        //    objArray6[2, 0x3e] = "F16E462AD0B446EA18E356162F148FCDEBCCBE73C24E8DA648ACC5FEC6031D8A";
        //    objArray6[2, 0x3f] = "AA14A749432228239F7A949F3BE8AE4F";
        //    objArray6[2, 0x40] = "5051B8ABFA8206DAA52CFFE3CB57B9FE";
        //    objArray6[2, 0x41] = "AA14A749432228239F7A949F3BE8AE4F";
        //    objArray6[2, 0x42] = false;
        //    objArray6[2, 0x43] = "vitor@house2invest.com.br";
        //    objArray6[3, 0] = "bbf7b44d-faa0-4276-b163-295b780a062c";
        //    objArray6[3, 1] = 0;
        //    objArray6[3, 2] = 1;
        //    objArray6[3, 3] = "F7FF434D3FF2F359A2C90E3841BABAC44DD6D9B9091DB2202B223A0405376DB5";
        //    objArray6[3, 4] = "E7767D052069A50DE93D25E4E9CB31DD";
        //    objArray6[3, 5] = "626cfd16-8380-4a13-a1e1-ab7fe2982018";
        //    objArray6[3, 6] = "91993838DBE9C22EDDE9C4B674F70C32541645EEED633D2A6BB93D34C3BB2BC212119CF96BDC222FB06E3070E59F6846";
        //    objArray6[3, 7] = "91993838DBE9C22EDDE9C4B674F70C32541645EEED633D2A6BB93D34C3BB2BC212119CF96BDC222FB06E3070E59F6846";
        //    objArray6[3, 8] = "EAB3774976AE2FA089327CD4A8E47378";
        //    objArray6[3, 9] = "EAB3774976AE2FA089327CD4A8E47378";
        //    objArray6[3, 10] = "42DA8A2C618928E0568B5CC2770E9218";
        //    objArray6[3, 11] = "13184286525F221852B660C8F8A85119";
        //    objArray6[3, 12] = "5E30B54D033E0A3551C761A7A9FB4FA3";
        //    objArray6[3, 13] = "3DF0D12434457D7194C831CCDED68217";
        //    objArray6[3, 14] = "FBD72192F9DF948974190443768CA8B145A5E5BA7B1E4CF024D6AD9E12711002";
        //    objArray6[3, 15] = "67BF623EC26BFB0E31E9E3755F64F92D";
        //    objArray6[3, 0x10] = "EAB3774976AE2FA089327CD4A8E47378";
        //    objArray6[3, 0x11] = "EAB3774976AE2FA089327CD4A8E47378";
        //    objArray6[3, 0x12] = "FBD72192F9DF948974190443768CA8B145A5E5BA7B1E4CF024D6AD9E12711002";
        //    objArray6[3, 0x13] = "";
        //    objArray6[3, 20] = "188C94448021F72179E959C8C22A5235";
        //    objArray6[3, 0x15] = "D3CF7F5DE9E702974C41C0281D4E21089AFE0D0702DE29C60B41C3006556D661";
        //    objArray6[3, 0x16] = "9C399CD489452A9A9EE44FDF1C63063334BDE696E1C706BB4A2446800CB60A82";
        //    objArray6[3, 0x17] = "FECB68EF441B6FF7FF4BD584F863A2DB";
        //    objArray6[3, 0x18] = "2EC128A57C16437C98AAB7BD3C236F4B";
        //    objArray6[3, 0x19] = "AC00C0AA39C7FF13CE7FEEC9969DCE5E";
        //    objArray6[3, 0x1a] = "joao@house2invest.com.br";
        //    objArray6[3, 0x1b] = true;
        //    objArray6[3, 0x1c] = "8086554AF4C49F7899D7E2DD3C073C0D";
        //    objArray6[3, 0x1d] = "";
        //    objArray6[3, 30] = "";
        //    objArray6[3, 0x1f] = "";
        //    objArray6[3, 0x20] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[3, 0x21] = "44E1E3882B52FCC8234B7863CAF32AC1";
        //    objArray6[3, 0x22] = "/images/fundo_padrao_perfil.png";
        //    objArray6[3, 0x23] = false;
        //    objArray6[3, 0x25] = "";
        //    objArray6[3, 0x26] = "";
        //    objArray6[3, 0x27] = "";
        //    objArray6[3, 40] = "";
        //    objArray6[3, 0x29] = "";
        //    objArray6[3, 0x2a] = "";
        //    objArray6[3, 0x2b] = "";
        //    objArray6[3, 0x2c] = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind)DateTimeKind.Unspecified);
        //    objArray6[3, 0x2d] = "51931671FFEDC07127F36CEFAD81A4BC";
        //    objArray6[3, 0x2e] = "joao@house2invest.com.br";
        //    objArray6[3, 0x2f] = "joao@house2invest.com.br";
        //    objArray6[3, 0x30] = "AQAAAAEAACcQAAAAEBVhUAlsdNI+ZBfl1Dpk7lyD6BDlx/zfSFN61mnAzgVvFdIjdv+geI4QZPZfDdEJQA==";
        //    objArray6[3, 0x31] = "+5511979661000";
        //    objArray6[3, 50] = true;
        //    objArray6[3, 0x33] = "";
        //    objArray6[3, 0x34] = false;
        //    objArray6[3, 0x35] = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x184, (DateTimeKind)DateTimeKind.Local).AddTicks(0xf43L);
        //    objArray6[3, 0x36] = true;
        //    objArray6[3, 0x37] = false;
        //    objArray6[3, 0x38] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[3, 0x39] = false;
        //    objArray6[3, 0x3a] = "";
        //    objArray6[3, 0x3b] = "";
        //    objArray6[3, 60] = "";
        //    objArray6[3, 0x3d] = "";
        //    objArray6[3, 0x3e] = "A544D424B1546920B1A2C014CACE433E";
        //    objArray6[3, 0x3f] = "58DA4709D5F2A895A1518D8AC4D7F6FD";
        //    objArray6[3, 0x40] = "5051B8ABFA8206DAA52CFFE3CB57B9FE";
        //    objArray6[3, 0x41] = "58DA4709D5F2A895A1518D8AC4D7F6FD";
        //    objArray6[3, 0x42] = false;
        //    objArray6[3, 0x43] = "joao@house2invest.com.br";
        //    objArray6[4, 0] = "2751483e-2c65-4629-84b5-abc20c940c1c";
        //    objArray6[4, 1] = 0;
        //    objArray6[4, 2] = 1;
        //    objArray6[4, 3] = "274BFF5C0F505E135768CF02B0D485929CDBFAE485B7DEE51D97195F85352C85";
        //    objArray6[4, 4] = "E7767D052069A50DE93D25E4E9CB31DD";
        //    objArray6[4, 5] = "f60ed224-2d74-45e4-addd-6892ec0f654f";
        //    objArray6[4, 6] = "AE06F29830EDCA78DBF93B2B9B2C9931E3D16791B5263FBCD8AF254C3D4D240D";
        //    objArray6[4, 7] = "AE06F29830EDCA78DBF93B2B9B2C9931E3D16791B5263FBCD8AF254C3D4D240D";
        //    objArray6[4, 8] = "2559F7BB0BFE7BC212CCD8C15DF0A4DB";
        //    objArray6[4, 9] = "2559F7BB0BFE7BC212CCD8C15DF0A4DB";
        //    objArray6[4, 10] = "D577DE715FA1885EA70543B47179E4D4";
        //    objArray6[4, 11] = "BE3FA8F28BCAB6F10E21A9B699B12708";
        //    objArray6[4, 12] = "09D8B4E96F6C50D48CEA2E7FDB168AB5";
        //    objArray6[4, 13] = "9E0B3AC2C75EA329AB11C4F7BAEC14C4";
        //    objArray6[4, 14] = "575530A309AF0D4B5569553611DE2D5D4AE53324A8FBEACA267CA51E5EBB1721";
        //    objArray6[4, 15] = "67BF623EC26BFB0E31E9E3755F64F92D";
        //    objArray6[4, 0x10] = "2559F7BB0BFE7BC212CCD8C15DF0A4DB";
        //    objArray6[4, 0x11] = "2559F7BB0BFE7BC212CCD8C15DF0A4DB";
        //    objArray6[4, 0x12] = "575530A309AF0D4B5569553611DE2D5D4AE53324A8FBEACA267CA51E5EBB1721";
        //    objArray6[4, 0x13] = "";
        //    objArray6[4, 20] = "188C94448021F72179E959C8C22A5235";
        //    objArray6[4, 0x15] = "D3CF7F5DE9E702974C41C0281D4E21089AFE0D0702DE29C60B41C3006556D661";
        //    objArray6[4, 0x16] = "9C399CD489452A9A9EE44FDF1C63063334BDE696E1C706BB4A2446800CB60A82";
        //    objArray6[4, 0x17] = "FECB68EF441B6FF7FF4BD584F863A2DB";
        //    objArray6[4, 0x18] = "2EC128A57C16437C98AAB7BD3C236F4B";
        //    objArray6[4, 0x19] = "AC00C0AA39C7FF13CE7FEEC9969DCE5E";
        //    objArray6[4, 0x1a] = "cristina@house2invest.com.br";
        //    objArray6[4, 0x1b] = true;
        //    objArray6[4, 0x1c] = "7786386A9A58AF0AE8542BA111EA2C0C";
        //    objArray6[4, 0x1d] = "";
        //    objArray6[4, 30] = "";
        //    objArray6[4, 0x1f] = "";
        //    objArray6[4, 0x20] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[4, 0x21] = "B18F045FE1BD7F106650C0A57275FD04";
        //    objArray6[4, 0x22] = "/images/fundo_padrao_perfil.png";
        //    objArray6[4, 0x23] = false;
        //    objArray6[4, 0x25] = "";
        //    objArray6[4, 0x26] = "";
        //    objArray6[4, 0x27] = "";
        //    objArray6[4, 40] = "";
        //    objArray6[4, 0x29] = "";
        //    objArray6[4, 0x2a] = "";
        //    objArray6[4, 0x2b] = "";
        //    objArray6[4, 0x2c] = new DateTime(0x7ba, 2, 14, 0, 0, 0, 0, (DateTimeKind)DateTimeKind.Unspecified);
        //    objArray6[4, 0x2d] = "0362234E13B08161A5BB3DC2A857DA40";
        //    objArray6[4, 0x2e] = "cristina@house2invest.com.br";
        //    objArray6[4, 0x2f] = "cristina@house2invest.com.br";
        //    objArray6[4, 0x30] = "AQAAAAEAACcQAAAAEL+s5GOX4eOZcA4yoJRn3uVx5pm/O0WsALhsI2UrwEA1EZsoQrkS5n6jG3u1IwU4qA==";
        //    objArray6[4, 0x31] = "+5511997103699";
        //    objArray6[4, 50] = true;
        //    objArray6[4, 0x33] = "";
        //    objArray6[4, 0x34] = false;
        //    objArray6[4, 0x35] = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x18b, (DateTimeKind)DateTimeKind.Local).AddTicks(0x1881L);
        //    objArray6[4, 0x36] = true;
        //    objArray6[4, 0x37] = false;
        //    objArray6[4, 0x38] = "93274427AD8E0A8F4854F0BA1439F141";
        //    objArray6[4, 0x39] = false;
        //    objArray6[4, 0x3a] = "";
        //    objArray6[4, 0x3b] = "";
        //    objArray6[4, 60] = "";
        //    objArray6[4, 0x3d] = "";
        //    objArray6[4, 0x3e] = "E09531C52ED770F0C352D41CB826F4C65D3C20212AA6ECAD9E53AD38EDA20B53";
        //    objArray6[4, 0x3f] = "006802EFD129DBAD6D02C2621C01168B";
        //    objArray6[4, 0x40] = "5051B8ABFA8206DAA52CFFE3CB57B9FE";
        //    objArray6[4, 0x41] = "006802EFD129DBAD6D02C2621C01168B";
        //    objArray6[4, 0x42] = false;
        //    objArray6[4, 0x43] = "cristina@house2invest.com.br";
        //    migrationBuilder.InsertData("AspNetUsers", textArray6, objArray6, null);
        //    string[] textArray7 = new string[] { "UserId", "RoleId" };
        //    object[] objArray7 = new object[,] { { "b30b4d21-0f99-435e-acec-a2c672697b0f", "59c39ee9-024a-41c1-bae8-7859879aa9f2" }, { "b1aadecb-4357-457d-bfea-27e153505497", "59c39ee9-024a-41c1-bae8-7859879aa9f2" }, { "4cb6d3d8-493a-415c-a5d7-cc6860aa8691", "59c39ee9-024a-41c1-bae8-7859879aa9f2" }, { "bbf7b44d-faa0-4276-b163-295b780a062c", "59c39ee9-024a-41c1-bae8-7859879aa9f2" }, { "2751483e-2c65-4629-84b5-abc20c940c1c", "59c39ee9-024a-41c1-bae8-7859879aa9f2" } };
        //    migrationBuilder.InsertData("AspNetUserRoles", textArray7, objArray7, null);
        //    migrationBuilder.CreateIndex("IX_AppConfiguracoes_AppConfiguracoes_AplicativoId", "AppConfiguracoes", "AppConfiguracoes_AplicativoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_AppConfiguracoes_AppConfiguracoes_AzureId", "AppConfiguracoes", "AppConfiguracoes_AzureId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_AppConfiguracoes_Descricao", "AppConfiguracoes", "Descricao", null, true, null);
        //    migrationBuilder.CreateIndex("IX_AppConfiguracoes_URLExibicao", "AppConfiguracoes", "URLExibicao", null, true, null);
        //    string[] textArray8 = new string[] { "Descricao", "URLExibicao", "AppConfiguracoes_AplicativoId", "AppConfiguracoes_AzureId" };
        //    migrationBuilder.CreateIndex("IX_AppConfiguracoes_Descricao_URLExibicao_AppConfiguracoes_AplicativoId_AppConfiguracoes_AzureId", "AppConfiguracoes", textArray8, null, true, null);
        //    migrationBuilder.CreateIndex("IX_AppConfiguracoes_Aplicativo_CPFCNPJ", "AppConfiguracoes_Aplicativo", "CPFCNPJ", null, true, null);
        //    migrationBuilder.CreateIndex("IX_AppConfiguracoes_Aplicativo_Empresa", "AppConfiguracoes_Aplicativo", "Empresa", null, true, null);
        //    migrationBuilder.CreateIndex("IX_AppPerfil_AppConfiguracoesId", "AppPerfil", "AppConfiguracoesId", null, true, null);
        //    migrationBuilder.CreateIndex("IX_AspNetRoleClaims_RoleId", "AspNetRoleClaims", "RoleId", null, false, null);
        //    migrationBuilder.CreateIndex("RoleNameIndex", "AspNetRoles", "NormalizedName", null, true, "[NormalizedName] IS NOT NULL");
        //    migrationBuilder.CreateIndex("IX_AspNetUserClaims_UserId", "AspNetUserClaims", "UserId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_AspNetUserLogins_UserId", "AspNetUserLogins", "UserId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_AspNetUserRoles_RoleId", "AspNetUserRoles", "RoleId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_AspNetUsers_AppConfiguracoesId", "AspNetUsers", "AppConfiguracoesId", null, false, null);
        //    migrationBuilder.CreateIndex("EmailIndex", "AspNetUsers", "NormalizedEmail", null, false, null);
        //    migrationBuilder.CreateIndex("UserNameIndex", "AspNetUsers", "NormalizedUserName", null, true, "[NormalizedUserName] IS NOT NULL");
        //    migrationBuilder.CreateIndex("IX_BlocoProjInvestimento_ItemDocs_BlocoProjInvestimentoId", "BlocoProjInvestimento_ItemDocs", "BlocoProjInvestimentoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_BlocoProjInvestimento_ItemDocs_INVEST_ModeloDocId", "BlocoProjInvestimento_ItemDocs", "INVEST_ModeloDocId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_BlocoProjInvestimentoComentarios_BlocoProjInvestimentoId", "BlocoProjInvestimentoComentarios", "BlocoProjInvestimentoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_BlocoProjInvestimentoComentarios_UsuarioAppId", "BlocoProjInvestimentoComentarios", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_BlocoProjInvestimentos_ConstrutoraId", "BlocoProjInvestimentos", "ConstrutoraId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_BlocoProjInvestimentos_GaleriaPerfilAlbumId", "BlocoProjInvestimentos", "GaleriaPerfilAlbumId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_BlocoProjInvestimentoValores_BlocoProjInvestimentoId", "BlocoProjInvestimentoValores", "BlocoProjInvestimentoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_BlocoProjInvestimentoValores_UsuarioAppId", "BlocoProjInvestimentoValores", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_FAQItens_FAQId", "FAQItens", "FAQId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_GaleriaPerfilAlbum_AppPerfilId", "GaleriaPerfilAlbum", "AppPerfilId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_GaleriaPerfilImagem_GaleriaPerfilAlbumId", "GaleriaPerfilImagem", "GaleriaPerfilAlbumId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_HgGeoIp_Paises_HgGeoIp_Pais_FlagId", "HgGeoIp_Paises", "HgGeoIp_Pais_FlagId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_HgGeoIps_ResultsGeoIpId", "HgGeoIps", "ResultsGeoIpId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_INVEST_ControleTransfs_BlocoProjInvestimentosId", "INVEST_ControleTransfs", "BlocoProjInvestimentosId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_INVEST_ControleTransfs_UsuarioAppId", "INVEST_ControleTransfs", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_INVEST_LancamentoDocs_INVEST_LancamentoId", "INVEST_LancamentoDocs", "INVEST_LancamentoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_INVEST_LancamentoDocs_INVEST_ModeloDocId", "INVEST_LancamentoDocs", "INVEST_ModeloDocId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_INVEST_LancamentoImagens_INVEST_LancamentoId", "INVEST_LancamentoImagens", "INVEST_LancamentoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_INVEST_Lancamentos_BlocoProjInvestimentosId", "INVEST_Lancamentos", "BlocoProjInvestimentosId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_INVEST_Lancamentos_UsuarioAppId", "INVEST_Lancamentos", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_InvestimentoConfirmacoes_BlocoProjInvestimentoId", "InvestimentoConfirmacoes", "BlocoProjInvestimentoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_InvestimentoConfirmacoes_INVEST_LancamentoId", "InvestimentoConfirmacoes", "INVEST_LancamentoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_InvestimentoConfirmacoes_UsuarioAppId", "InvestimentoConfirmacoes", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_InvestimentoDocUsuarios_BlocoProjInvestimentoId", "InvestimentoDocUsuarios", "BlocoProjInvestimentoId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_InvestimentoDocUsuarios_UsuarioAppId", "InvestimentoDocUsuarios", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_LOGCENTRALs_UsuarioAppCriadorId", "LOGCENTRALs", "UsuarioAppCriadorId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_LOGCENTRALs_UsuarioAppId", "LOGCENTRALs", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_PreferSalaVIPs_UsuarioAppId", "PreferSalaVIPs", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_ResultsGeoIps_HgGeoIp_PaisId", "ResultsGeoIps", "HgGeoIp_PaisId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_tblHubClientes_UsuarioAppId", "tblHubClientes", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_tblUsuSalaVIPs_UsuarioAppId", "tblUsuSalaVIPs", "UsuarioAppId", null, false, null);
        //    migrationBuilder.CreateIndex("IX_Tranferencias_BlocoProjInvestimentoId", "Tranferencias", "BlocoProjInvestimentoId", null, false, null);
        //}

    }
}

