namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOlderUf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Manutencao", "Local_UF");
            DropColumn("dbo.Motorista", "Endereco_UF");
            DropColumn("dbo.Cliente", "Endereco_UF");
            DropColumn("dbo.Garagem", "Endereco_UF");
            DropColumn("dbo.Fornecedor", "Endereco_UF");
            DropColumn("dbo.Viagem", "EnderecoOrigem_UF");
            DropColumn("dbo.Viagem", "EnderecoDestino_UF");
            DropColumn("dbo.Funcionario", "Endereco_UF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Funcionario", "Endereco_UF", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoDestino_UF", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoOrigem_UF", c => c.String());
            AddColumn("dbo.Fornecedor", "Endereco_UF", c => c.String());
            AddColumn("dbo.Garagem", "Endereco_UF", c => c.String());
            AddColumn("dbo.Cliente", "Endereco_UF", c => c.String());
            AddColumn("dbo.Motorista", "Endereco_UF", c => c.String());
            AddColumn("dbo.Manutencao", "Local_UF", c => c.String());
        }
    }
}
