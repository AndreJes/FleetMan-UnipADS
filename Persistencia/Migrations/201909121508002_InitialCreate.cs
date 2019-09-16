namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manutencao",
                c => new
                    {
                        ManutencaoId = c.Long(nullable: false, identity: true),
                        Local_Rua = c.String(),
                        Local_Numero = c.String(),
                        Local_Bairro = c.String(),
                        Local_Cidade = c.String(),
                        Local_CEP = c.String(),
                        Local_UF = c.Int(nullable: false),
                        DataEntrada = c.DateTime(nullable: false),
                        DataSaida = c.DateTime(nullable: false),
                        Tipo = c.Int(nullable: false),
                        EstadoAtual = c.Int(nullable: false),
                        VeiculoId = c.Long(),
                        QuantidadeAbastecida = c.Double(),
                        Valor = c.Double(),
                        MotoristaId = c.Long(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        RelatorioConsumo_RelatorioId = c.Long(),
                        RelatorioManutencao_RelatorioId = c.Long(),
                    })
                .PrimaryKey(t => t.ManutencaoId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .ForeignKey("dbo.Motorista", t => t.MotoristaId)
                .ForeignKey("dbo.RelatoriosConsumos", t => t.RelatorioConsumo_RelatorioId)
                .ForeignKey("dbo.RelatoriosManutencao", t => t.RelatorioManutencao_RelatorioId)
                .Index(t => t.VeiculoId)
                .Index(t => t.MotoristaId)
                .Index(t => t.RelatorioConsumo_RelatorioId)
                .Index(t => t.RelatorioManutencao_RelatorioId);
            
            CreateTable(
                "dbo.Motorista",
                c => new
                    {
                        MotoristaId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        RG = c.String(),
                        Celular = c.String(),
                        Email = c.String(),
                        NumeroCNH = c.String(),
                        PontosCNH = c.Int(nullable: false),
                        Endereco_Rua = c.String(),
                        Endereco_Numero = c.String(),
                        Endereco_Bairro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_CEP = c.String(),
                        Endereco_UF = c.Int(nullable: false),
                        MotoristaProprio = c.Boolean(nullable: false),
                        VencimentoExame = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        ClienteId = c.Long(),
                    })
                .PrimaryKey(t => t.MotoristaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Long(nullable: false, identity: true),
                        Telefone = c.String(),
                        Endereco_Rua = c.String(),
                        Endereco_Numero = c.String(),
                        Endereco_Bairro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_CEP = c.String(),
                        Endereco_UF = c.Int(nullable: false),
                        Nome = c.String(),
                        Email = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Aluguel",
                c => new
                    {
                        AluguelId = c.Long(nullable: false, identity: true),
                        DataContratacao = c.DateTime(nullable: false),
                        DataVencimento = c.DateTime(nullable: false),
                        EstadoDoPagamento = c.Int(nullable: false),
                        EstadoDoAluguel = c.Int(nullable: false),
                        VeiculoId = c.Long(),
                        ClienteId = c.Long(),
                    })
                .PrimaryKey(t => t.AluguelId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .Index(t => t.VeiculoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        VeiculoId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Placa = c.String(),
                        Ano = c.Int(nullable: false),
                        Marca = c.String(),
                        Modelo = c.String(),
                        CodRenavam = c.String(),
                        Cor = c.String(),
                        Adaptado = c.Boolean(nullable: false),
                        ParaLocacao = c.Boolean(nullable: false),
                        EstadoDoTanque = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        EstadoDoVeiculo = c.Int(nullable: false),
                        CategoriaExigida = c.Int(nullable: false),
                        GaragemId = c.Long(),
                        ClienteId = c.Long(),
                        SeguroId = c.Long(),
                    })
                .PrimaryKey(t => t.VeiculoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Garagem", t => t.GaragemId)
                .ForeignKey("dbo.Seguro", t => t.SeguroId)
                .Index(t => t.GaragemId)
                .Index(t => t.ClienteId)
                .Index(t => t.SeguroId);
            
            CreateTable(
                "dbo.Garagem",
                c => new
                    {
                        GaragemId = c.Long(nullable: false, identity: true),
                        Telefone = c.String(),
                        Endereco_Rua = c.String(),
                        Endereco_Numero = c.String(),
                        Endereco_Bairro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_CEP = c.String(),
                        Endereco_UF = c.Int(nullable: false),
                        CNPJ = c.String(),
                        Capacidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GaragemId);
            
            CreateTable(
                "dbo.Peca",
                c => new
                    {
                        PecaId = c.Long(nullable: false, identity: true),
                        Descricao = c.String(),
                        FornecedorId = c.Long(),
                        Manutencao_ManutencaoId = c.Long(),
                    })
                .PrimaryKey(t => t.PecaId)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId)
                .ForeignKey("dbo.Manutencao", t => t.Manutencao_ManutencaoId)
                .Index(t => t.FornecedorId)
                .Index(t => t.Manutencao_ManutencaoId);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        FornecedorId = c.Long(nullable: false, identity: true),
                        CNPJ = c.String(),
                        Razao_Social = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        LojaVirtual = c.Boolean(nullable: false),
                        Endereco_Rua = c.String(),
                        Endereco_Numero = c.String(),
                        Endereco_Bairro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_CEP = c.String(),
                        Endereco_UF = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Multa",
                c => new
                    {
                        MultaId = c.Long(nullable: false, identity: true),
                        CodigoMulta = c.String(),
                        Valor = c.Double(nullable: false),
                        DataDaMulta = c.DateTime(nullable: false),
                        EstadoDoPagamento = c.Int(nullable: false),
                        GravidadeDaInfracao = c.Int(nullable: false),
                        VeiculoId = c.Long(),
                        MotoristaId = c.Long(),
                        RelatorioMulta_RelatorioId = c.Long(),
                    })
                .PrimaryKey(t => t.MultaId)
                .ForeignKey("dbo.Motorista", t => t.MotoristaId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .ForeignKey("dbo.RelatoriosMultas", t => t.RelatorioMulta_RelatorioId)
                .Index(t => t.VeiculoId)
                .Index(t => t.MotoristaId)
                .Index(t => t.RelatorioMulta_RelatorioId);
            
            CreateTable(
                "dbo.Seguro",
                c => new
                    {
                        SeguroId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        CNPJ = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        PrecoParcela = c.Double(nullable: false),
                        DataVencimentoParcela = c.DateTime(nullable: false),
                        DataContratacao = c.DateTime(nullable: false),
                        Vencimento_Contrato = c.DateTime(nullable: false),
                        EstadoPagamento = c.Int(nullable: false),
                        TipoCobertura = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeguroId);
            
            CreateTable(
                "dbo.Sinistro",
                c => new
                    {
                        SinistroId = c.Long(nullable: false, identity: true),
                        CodSinistro = c.String(),
                        Descricao = c.String(),
                        QntEnvolvidos = c.Int(nullable: false),
                        EstadoPagamento = c.Int(nullable: false),
                        Gravidade = c.Int(nullable: false),
                        VeiculoId = c.Long(),
                        MotoristaId = c.Long(),
                        RelatorioSinistros_RelatorioId = c.Long(),
                    })
                .PrimaryKey(t => t.SinistroId)
                .ForeignKey("dbo.Motorista", t => t.MotoristaId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .ForeignKey("dbo.RelatoriosAcidentes", t => t.RelatorioSinistros_RelatorioId)
                .Index(t => t.VeiculoId)
                .Index(t => t.MotoristaId)
                .Index(t => t.RelatorioSinistros_RelatorioId);
            
            CreateTable(
                "dbo.Viagem",
                c => new
                    {
                        ViagemId = c.Long(nullable: false, identity: true),
                        EnderecoOrigem_Rua = c.String(),
                        EnderecoOrigem_Numero = c.String(),
                        EnderecoOrigem_Bairro = c.String(),
                        EnderecoOrigem_Cidade = c.String(),
                        EnderecoOrigem_CEP = c.String(),
                        EnderecoOrigem_UF = c.Int(nullable: false),
                        EnderecoDestino_Rua = c.String(),
                        EnderecoDestino_Numero = c.String(),
                        EnderecoDestino_Bairro = c.String(),
                        EnderecoDestino_Cidade = c.String(),
                        EnderecoDestino_CEP = c.String(),
                        EnderecoDestino_UF = c.Int(nullable: false),
                        DataSaida = c.DateTime(nullable: false),
                        DataChegada = c.DateTime(nullable: false),
                        QuantidadePassageiros = c.Int(nullable: false),
                        EstadoDaViagem = c.Int(nullable: false),
                        VeiculoId = c.Long(),
                        MotoristaId = c.Long(),
                        GaragemOrigem_GaragemId = c.Long(),
                        GaragemRetorno_GaragemId = c.Long(),
                        RelatorioViagem_RelatorioId = c.Long(),
                    })
                .PrimaryKey(t => t.ViagemId)
                .ForeignKey("dbo.Garagem", t => t.GaragemOrigem_GaragemId)
                .ForeignKey("dbo.Garagem", t => t.GaragemRetorno_GaragemId)
                .ForeignKey("dbo.Motorista", t => t.MotoristaId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .ForeignKey("dbo.RelatoriosViagens", t => t.RelatorioViagem_RelatorioId)
                .Index(t => t.VeiculoId)
                .Index(t => t.MotoristaId)
                .Index(t => t.GaragemOrigem_GaragemId)
                .Index(t => t.GaragemRetorno_GaragemId)
                .Index(t => t.RelatorioViagem_RelatorioId);
            
            CreateTable(
                "dbo.Aviso",
                c => new
                    {
                        AvisoId = c.Long(nullable: false, identity: true),
                        Mensagem = c.String(),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvisoId);
            
            CreateTable(
                "dbo.Financa",
                c => new
                    {
                        FinancaId = c.Long(nullable: false, identity: true),
                        Descricao = c.String(),
                        Valor = c.Double(nullable: false),
                        DataVencimento = c.DateTime(),
                        DataPagamento = c.DateTime(),
                        EstadoPagamento = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        RelatorioFinanceiro_RelatorioId = c.Long(),
                    })
                .PrimaryKey(t => t.FinancaId)
                .ForeignKey("dbo.RelatoriosFinanceiros", t => t.RelatorioFinanceiro_RelatorioId)
                .Index(t => t.RelatorioFinanceiro_RelatorioId);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        FuncionarioId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        Endereco_Rua = c.String(),
                        Endereco_Numero = c.String(),
                        Endereco_Bairro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_CEP = c.String(),
                        Endereco_UF = c.Int(nullable: false),
                        Email = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Relatorio",
                c => new
                    {
                        RelatorioId = c.Long(nullable: false, identity: true),
                        DataEmissao = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioId);
            
            CreateTable(
                "dbo.Solicitacao",
                c => new
                    {
                        SolicitacaoId = c.Long(nullable: false, identity: true),
                        ItemSerializado = c.String(),
                        DataDaSolicitacao = c.DateTime(nullable: false),
                        DataProcessamento = c.DateTime(nullable: false),
                        TipoDeItem = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        ClienteId = c.Long(),
                    })
                .PrimaryKey(t => t.SolicitacaoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ClientesPF",
                c => new
                    {
                        ClienteId = c.Long(nullable: false),
                        CPF = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.ClientesPJ",
                c => new
                    {
                        ClienteId = c.Long(nullable: false),
                        CNPJ = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.RelatoriosAcidentes",
                c => new
                    {
                        RelatorioId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioId)
                .ForeignKey("dbo.Relatorio", t => t.RelatorioId)
                .Index(t => t.RelatorioId);
            
            CreateTable(
                "dbo.RelatoriosConsumos",
                c => new
                    {
                        RelatorioId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioId)
                .ForeignKey("dbo.Relatorio", t => t.RelatorioId)
                .Index(t => t.RelatorioId);
            
            CreateTable(
                "dbo.RelatoriosFinanceiros",
                c => new
                    {
                        RelatorioId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioId)
                .ForeignKey("dbo.Relatorio", t => t.RelatorioId)
                .Index(t => t.RelatorioId);
            
            CreateTable(
                "dbo.RelatoriosManutencao",
                c => new
                    {
                        RelatorioId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioId)
                .ForeignKey("dbo.Relatorio", t => t.RelatorioId)
                .Index(t => t.RelatorioId);
            
            CreateTable(
                "dbo.RelatoriosMultas",
                c => new
                    {
                        RelatorioId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioId)
                .ForeignKey("dbo.Relatorio", t => t.RelatorioId)
                .Index(t => t.RelatorioId);
            
            CreateTable(
                "dbo.RelatoriosViagens",
                c => new
                    {
                        RelatorioId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioId)
                .ForeignKey("dbo.Relatorio", t => t.RelatorioId)
                .Index(t => t.RelatorioId);
            
            CreateTable(
                "dbo.UsuariosClientes",
                c => new
                    {
                        UsuarioId = c.Long(nullable: false),
                        ClienteId = c.Long(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.UsuariosFuncionarios",
                c => new
                    {
                        UsuarioId = c.Long(nullable: false),
                        FuncionarioId = c.Long(),
                        Permissoes_Veiculos = c.Boolean(nullable: false),
                        Permissoes_Motoristas = c.Boolean(nullable: false),
                        Permissoes_Clientes = c.Boolean(nullable: false),
                        Permissoes_Funcionarios = c.Boolean(nullable: false),
                        Permissoes_Garagens = c.Boolean(nullable: false),
                        Permissoes_Seguros = c.Boolean(nullable: false),
                        Permissoes_Financeiro = c.Boolean(nullable: false),
                        Permissoes_Manutencoes = c.Boolean(nullable: false),
                        Permissoes_MultasSinistros = c.Boolean(nullable: false),
                        Permissoes_Solicitacoes = c.Boolean(nullable: false),
                        Permissoes_Relatorios = c.Boolean(nullable: false),
                        Permissoes_Locacoes = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.UsuariosMotoristas",
                c => new
                    {
                        UsuarioId = c.Long(nullable: false),
                        MotoristaId = c.Long(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .ForeignKey("dbo.Motorista", t => t.MotoristaId)
                .Index(t => t.UsuarioId)
                .Index(t => t.MotoristaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuariosMotoristas", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.UsuariosMotoristas", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuariosFuncionarios", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.UsuariosFuncionarios", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuariosClientes", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.UsuariosClientes", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.RelatoriosViagens", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosMultas", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosManutencao", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosFinanceiros", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosConsumos", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosAcidentes", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.ClientesPJ", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.ClientesPF", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Solicitacao", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Viagem", "RelatorioViagem_RelatorioId", "dbo.RelatoriosViagens");
            DropForeignKey("dbo.Sinistro", "RelatorioSinistros_RelatorioId", "dbo.RelatoriosAcidentes");
            DropForeignKey("dbo.Multa", "RelatorioMulta_RelatorioId", "dbo.RelatoriosMultas");
            DropForeignKey("dbo.Manutencao", "RelatorioManutencao_RelatorioId", "dbo.RelatoriosManutencao");
            DropForeignKey("dbo.Financa", "RelatorioFinanceiro_RelatorioId", "dbo.RelatoriosFinanceiros");
            DropForeignKey("dbo.Manutencao", "RelatorioConsumo_RelatorioId", "dbo.RelatoriosConsumos");
            DropForeignKey("dbo.Manutencao", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Viagem", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Viagem", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Viagem", "GaragemRetorno_GaragemId", "dbo.Garagem");
            DropForeignKey("dbo.Viagem", "GaragemOrigem_GaragemId", "dbo.Garagem");
            DropForeignKey("dbo.Motorista", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Aluguel", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Sinistro", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Sinistro", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Veiculo", "SeguroId", "dbo.Seguro");
            DropForeignKey("dbo.Multa", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Multa", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Manutencao", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Peca", "Manutencao_ManutencaoId", "dbo.Manutencao");
            DropForeignKey("dbo.Peca", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Veiculo", "GaragemId", "dbo.Garagem");
            DropForeignKey("dbo.Veiculo", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Aluguel", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.UsuariosMotoristas", new[] { "MotoristaId" });
            DropIndex("dbo.UsuariosMotoristas", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosFuncionarios", new[] { "FuncionarioId" });
            DropIndex("dbo.UsuariosFuncionarios", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosClientes", new[] { "ClienteId" });
            DropIndex("dbo.UsuariosClientes", new[] { "UsuarioId" });
            DropIndex("dbo.RelatoriosViagens", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosMultas", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosManutencao", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosFinanceiros", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosConsumos", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosAcidentes", new[] { "RelatorioId" });
            DropIndex("dbo.ClientesPJ", new[] { "ClienteId" });
            DropIndex("dbo.ClientesPF", new[] { "ClienteId" });
            DropIndex("dbo.Solicitacao", new[] { "ClienteId" });
            DropIndex("dbo.Financa", new[] { "RelatorioFinanceiro_RelatorioId" });
            DropIndex("dbo.Viagem", new[] { "RelatorioViagem_RelatorioId" });
            DropIndex("dbo.Viagem", new[] { "GaragemRetorno_GaragemId" });
            DropIndex("dbo.Viagem", new[] { "GaragemOrigem_GaragemId" });
            DropIndex("dbo.Viagem", new[] { "MotoristaId" });
            DropIndex("dbo.Viagem", new[] { "VeiculoId" });
            DropIndex("dbo.Sinistro", new[] { "RelatorioSinistros_RelatorioId" });
            DropIndex("dbo.Sinistro", new[] { "MotoristaId" });
            DropIndex("dbo.Sinistro", new[] { "VeiculoId" });
            DropIndex("dbo.Multa", new[] { "RelatorioMulta_RelatorioId" });
            DropIndex("dbo.Multa", new[] { "MotoristaId" });
            DropIndex("dbo.Multa", new[] { "VeiculoId" });
            DropIndex("dbo.Peca", new[] { "Manutencao_ManutencaoId" });
            DropIndex("dbo.Peca", new[] { "FornecedorId" });
            DropIndex("dbo.Veiculo", new[] { "SeguroId" });
            DropIndex("dbo.Veiculo", new[] { "ClienteId" });
            DropIndex("dbo.Veiculo", new[] { "GaragemId" });
            DropIndex("dbo.Aluguel", new[] { "ClienteId" });
            DropIndex("dbo.Aluguel", new[] { "VeiculoId" });
            DropIndex("dbo.Motorista", new[] { "ClienteId" });
            DropIndex("dbo.Manutencao", new[] { "RelatorioManutencao_RelatorioId" });
            DropIndex("dbo.Manutencao", new[] { "RelatorioConsumo_RelatorioId" });
            DropIndex("dbo.Manutencao", new[] { "MotoristaId" });
            DropIndex("dbo.Manutencao", new[] { "VeiculoId" });
            DropTable("dbo.UsuariosMotoristas");
            DropTable("dbo.UsuariosFuncionarios");
            DropTable("dbo.UsuariosClientes");
            DropTable("dbo.RelatoriosViagens");
            DropTable("dbo.RelatoriosMultas");
            DropTable("dbo.RelatoriosManutencao");
            DropTable("dbo.RelatoriosFinanceiros");
            DropTable("dbo.RelatoriosConsumos");
            DropTable("dbo.RelatoriosAcidentes");
            DropTable("dbo.ClientesPJ");
            DropTable("dbo.ClientesPF");
            DropTable("dbo.Usuario");
            DropTable("dbo.Solicitacao");
            DropTable("dbo.Relatorio");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Financa");
            DropTable("dbo.Aviso");
            DropTable("dbo.Viagem");
            DropTable("dbo.Sinistro");
            DropTable("dbo.Seguro");
            DropTable("dbo.Multa");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Peca");
            DropTable("dbo.Garagem");
            DropTable("dbo.Veiculo");
            DropTable("dbo.Aluguel");
            DropTable("dbo.Cliente");
            DropTable("dbo.Motorista");
            DropTable("dbo.Manutencao");
        }
    }
}
