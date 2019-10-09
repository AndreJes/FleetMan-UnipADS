namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPermissionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios_Remover", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes_Remover", c => c.Boolean(nullable: false));
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos", c => c.Boolean(nullable: false));
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Locacoes_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Relatorios_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Solicitacoes_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_MultasSinistros_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Manutencoes_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Financeiro_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Seguros_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Garagens_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Funcionarios_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Clientes_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Motoristas_Alterar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Veiculos_Alterar");
        }
    }
}
