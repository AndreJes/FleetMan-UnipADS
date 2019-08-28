namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CEPEndereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manutencao", "Local_CEP", c => c.String());
            AddColumn("dbo.Motorista", "Endereco_CEP", c => c.String());
            AddColumn("dbo.Cliente", "Endereco_CEP", c => c.String());
            AddColumn("dbo.Garagem", "Endereco_CEP", c => c.String());
            AddColumn("dbo.Fornecedor", "Endereco_CEP", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoOrigem_CEP", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoDestino_CEP", c => c.String());
            AddColumn("dbo.Funcionario", "Endereco_CEP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcionario", "Endereco_CEP");
            DropColumn("dbo.Viagem", "EnderecoDestino_CEP");
            DropColumn("dbo.Viagem", "EnderecoOrigem_CEP");
            DropColumn("dbo.Fornecedor", "Endereco_CEP");
            DropColumn("dbo.Garagem", "Endereco_CEP");
            DropColumn("dbo.Cliente", "Endereco_CEP");
            DropColumn("dbo.Motorista", "Endereco_CEP");
            DropColumn("dbo.Manutencao", "Local_CEP");
        }
    }
}
