namespace House2Invest.Migrations
{
    using House2Invest.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Runtime.CompilerServices;

    [DbContext(typeof(ApplicationDbContext))]
    internal class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    DTHR = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x343, (DateTimeKind) DateTimeKind.Local).AddTicks(0x1d5L),
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
                    DTHR = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x343, (DateTimeKind) DateTimeKind.Local).AddTicks(0xd21L),
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
                    DTHR = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x343, (DateTimeKind) DateTimeKind.Local).AddTicks(0x1a49L),
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
                    DTHR = new DateTime(0x7e3, 6, 12, 0x11, 0x17, 0x27, 0x343, (DateTimeKind) DateTimeKind.Local).AddTicks(0x2092L)
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
    }
}

