namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manutencao",
                c => new
                    {
                        ManutencaoId = c.Long(nullable: false, identity: true),
                        Local = c.String(),
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
                        NumeroCNH = c.String(),
                        PontosCNH = c.Int(nullable: false),
                        Nome = c.String(),
                        CPF = c.String(),
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
                        Endereco = c.String(),
                        Nome = c.String(),
                        Email = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        CPF = c.String(),
                        CNPJ = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                        Marca = c.String(),
                        Modelo = c.String(),
                        CodRenavam = c.String(),
                        Cor = c.String(),
                        Adaptado = c.Boolean(nullable: false),
                        Paralocacao = c.Boolean(nullable: false),
                        EstadoDoTanque = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        EstadoDoVeiculo = c.Int(nullable: false),
                        CategoriaExigida = c.Int(nullable: false),
                        GaragemId = c.Long(),
                        ClienteId = c.Long(),
                    })
                .PrimaryKey(t => t.VeiculoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Garagem", t => t.GaragemId)
                .Index(t => t.GaragemId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Garagem",
                c => new
                    {
                        GaragemId = c.Long(nullable: false, identity: true),
                        Telefone = c.String(),
                        Endereco = c.String(),
                        CNPJ = c.String(),
                    })
                .PrimaryKey(t => t.GaragemId);
            
            CreateTable(
                "dbo.Peca",
                c => new
                    {
                        PecaId = c.Long(nullable: false, identity: true),
                        Descricao = c.String(),
                        FornecedorId = c.Long(nullable: false),
                        Manutencao_ManutencaoId = c.Long(),
                    })
                .PrimaryKey(t => t.PecaId)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId, cascadeDelete: true)
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
                "dbo.Sinistro",
                c => new
                    {
                        SinistroId = c.Long(nullable: false, identity: true),
                        CodSinistro = c.String(),
                        Descricao = c.String(),
                        EstadoPagamento = c.Int(nullable: false),
                        Gravidade = c.Int(nullable: false),
                        VeiculoId = c.Long(),
                        MotoristaId = c.Long(),
                        RelatorioAcidentes_RelatorioId = c.Long(),
                    })
                .PrimaryKey(t => t.SinistroId)
                .ForeignKey("dbo.Motorista", t => t.MotoristaId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .ForeignKey("dbo.RelatoriosAcidentes", t => t.RelatorioAcidentes_RelatorioId)
                .Index(t => t.VeiculoId)
                .Index(t => t.MotoristaId)
                .Index(t => t.RelatorioAcidentes_RelatorioId);
            
            CreateTable(
                "dbo.Viagem",
                c => new
                    {
                        ViagemId = c.Long(nullable: false, identity: true),
                        EnderecoOrigem = c.String(),
                        EnderecoDestino = c.String(),
                        DataSaida = c.DateTime(nullable: false),
                        DataChegada = c.DateTime(nullable: false),
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
                        DataVencimento = c.DateTime(nullable: false),
                        EstadoPagamento = c.Int(nullable: false),
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
                        Endereco = c.String(),
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
                        VeiculoId = c.Long(),
                    })
                .PrimaryKey(t => t.SeguroId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .Index(t => t.VeiculoId);
            
            CreateTable(
                "dbo.Solicitacao",
                c => new
                    {
                        SolicitacaoId = c.Long(nullable: false, identity: true),
                        ItemSerializado = c.String(),
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
                        ClienteId = c.Long(),
                        FuncionarioId = c.Long(),
                        Permissoes_Veiculos = c.Boolean(),
                        Permissoes_Motoristas = c.Boolean(),
                        Permissoes_Clientes = c.Boolean(),
                        Permissoes_Funcionarios = c.Boolean(),
                        Permissoes_Garagens = c.Boolean(),
                        Permissoes_Seguros = c.Boolean(),
                        Permissoes_Financeiro = c.Boolean(),
                        Permissoes_Manutencoes = c.Boolean(),
                        Permissoes_MultasSinistros = c.Boolean(),
                        Permissoes_Solicitacoes = c.Boolean(),
                        Permissoes_Relatorios = c.Boolean(),
                        Permissoes_Locacoes = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .Index(t => t.ClienteId)
                .Index(t => t.FuncionarioId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelatoriosViagens", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosMultas", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosManutencao", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosFinanceiros", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosConsumos", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.RelatoriosAcidentes", "RelatorioId", "dbo.Relatorio");
            DropForeignKey("dbo.Usuario", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Usuario", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Solicitacao", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Seguro", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Viagem", "RelatorioViagem_RelatorioId", "dbo.RelatoriosViagens");
            DropForeignKey("dbo.Multa", "RelatorioMulta_RelatorioId", "dbo.RelatoriosMultas");
            DropForeignKey("dbo.Manutencao", "RelatorioManutencao_RelatorioId", "dbo.RelatoriosManutencao");
            DropForeignKey("dbo.Financa", "RelatorioFinanceiro_RelatorioId", "dbo.RelatoriosFinanceiros");
            DropForeignKey("dbo.Manutencao", "RelatorioConsumo_RelatorioId", "dbo.RelatoriosConsumos");
            DropForeignKey("dbo.Sinistro", "RelatorioAcidentes_RelatorioId", "dbo.RelatoriosAcidentes");
            DropForeignKey("dbo.Manutencao", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Viagem", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Viagem", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Viagem", "GaragemRetorno_GaragemId", "dbo.Garagem");
            DropForeignKey("dbo.Viagem", "GaragemOrigem_GaragemId", "dbo.Garagem");
            DropForeignKey("dbo.Motorista", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Aluguel", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Sinistro", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Sinistro", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Multa", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Multa", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Manutencao", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Peca", "Manutencao_ManutencaoId", "dbo.Manutencao");
            DropForeignKey("dbo.Peca", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Veiculo", "GaragemId", "dbo.Garagem");
            DropForeignKey("dbo.Veiculo", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Aluguel", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.RelatoriosViagens", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosMultas", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosManutencao", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosFinanceiros", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosConsumos", new[] { "RelatorioId" });
            DropIndex("dbo.RelatoriosAcidentes", new[] { "RelatorioId" });
            DropIndex("dbo.Usuario", new[] { "FuncionarioId" });
            DropIndex("dbo.Usuario", new[] { "ClienteId" });
            DropIndex("dbo.Solicitacao", new[] { "ClienteId" });
            DropIndex("dbo.Seguro", new[] { "VeiculoId" });
            DropIndex("dbo.Financa", new[] { "RelatorioFinanceiro_RelatorioId" });
            DropIndex("dbo.Viagem", new[] { "RelatorioViagem_RelatorioId" });
            DropIndex("dbo.Viagem", new[] { "GaragemRetorno_GaragemId" });
            DropIndex("dbo.Viagem", new[] { "GaragemOrigem_GaragemId" });
            DropIndex("dbo.Viagem", new[] { "MotoristaId" });
            DropIndex("dbo.Viagem", new[] { "VeiculoId" });
            DropIndex("dbo.Sinistro", new[] { "RelatorioAcidentes_RelatorioId" });
            DropIndex("dbo.Sinistro", new[] { "MotoristaId" });
            DropIndex("dbo.Sinistro", new[] { "VeiculoId" });
            DropIndex("dbo.Multa", new[] { "RelatorioMulta_RelatorioId" });
            DropIndex("dbo.Multa", new[] { "MotoristaId" });
            DropIndex("dbo.Multa", new[] { "VeiculoId" });
            DropIndex("dbo.Peca", new[] { "Manutencao_ManutencaoId" });
            DropIndex("dbo.Peca", new[] { "FornecedorId" });
            DropIndex("dbo.Veiculo", new[] { "ClienteId" });
            DropIndex("dbo.Veiculo", new[] { "GaragemId" });
            DropIndex("dbo.Aluguel", new[] { "ClienteId" });
            DropIndex("dbo.Aluguel", new[] { "VeiculoId" });
            DropIndex("dbo.Motorista", new[] { "ClienteId" });
            DropIndex("dbo.Manutencao", new[] { "RelatorioManutencao_RelatorioId" });
            DropIndex("dbo.Manutencao", new[] { "RelatorioConsumo_RelatorioId" });
            DropIndex("dbo.Manutencao", new[] { "MotoristaId" });
            DropIndex("dbo.Manutencao", new[] { "VeiculoId" });
            DropTable("dbo.RelatoriosViagens");
            DropTable("dbo.RelatoriosMultas");
            DropTable("dbo.RelatoriosManutencao");
            DropTable("dbo.RelatoriosFinanceiros");
            DropTable("dbo.RelatoriosConsumos");
            DropTable("dbo.RelatoriosAcidentes");
            DropTable("dbo.Usuario");
            DropTable("dbo.Solicitacao");
            DropTable("dbo.Seguro");
            DropTable("dbo.Relatorio");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Financa");
            DropTable("dbo.Aviso");
            DropTable("dbo.Viagem");
            DropTable("dbo.Sinistro");
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
