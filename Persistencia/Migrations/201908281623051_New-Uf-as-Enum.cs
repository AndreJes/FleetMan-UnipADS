namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUfasEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manutencao", "Local_UF", c => c.Int(nullable: false));
            AddColumn("dbo.Motorista", "Endereco_UF", c => c.Int(nullable: false));
            AddColumn("dbo.Cliente", "Endereco_UF", c => c.Int(nullable: false));
            AddColumn("dbo.Garagem", "Endereco_UF", c => c.Int(nullable: false));
            AddColumn("dbo.Fornecedor", "Endereco_UF", c => c.Int(nullable: false));
            AddColumn("dbo.Viagem", "EnderecoOrigem_UF", c => c.Int(nullable: false));
            AddColumn("dbo.Viagem", "EnderecoDestino_UF", c => c.Int(nullable: false));
            AddColumn("dbo.Funcionario", "Endereco_UF", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcionario", "Endereco_UF");
            DropColumn("dbo.Viagem", "EnderecoDestino_UF");
            DropColumn("dbo.Viagem", "EnderecoOrigem_UF");
            DropColumn("dbo.Fornecedor", "Endereco_UF");
            DropColumn("dbo.Garagem", "Endereco_UF");
            DropColumn("dbo.Cliente", "Endereco_UF");
            DropColumn("dbo.Motorista", "Endereco_UF");
            DropColumn("dbo.Manutencao", "Local_UF");
        }
    }
}
