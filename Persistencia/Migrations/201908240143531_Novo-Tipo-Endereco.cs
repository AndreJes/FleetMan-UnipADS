namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovoTipoEndereco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Peca", "FornecedorId", "dbo.Fornecedor");
            DropIndex("dbo.Peca", new[] { "FornecedorId" });
            AddColumn("dbo.Manutencao", "Local_Rua", c => c.String());
            AddColumn("dbo.Manutencao", "Local_Numero", c => c.String());
            AddColumn("dbo.Manutencao", "Local_Bairro", c => c.String());
            AddColumn("dbo.Manutencao", "Local_Cidade", c => c.String());
            AddColumn("dbo.Manutencao", "Local_UF", c => c.String());
            AddColumn("dbo.Motorista", "Endereco_Rua", c => c.String());
            AddColumn("dbo.Motorista", "Endereco_Numero", c => c.String());
            AddColumn("dbo.Motorista", "Endereco_Bairro", c => c.String());
            AddColumn("dbo.Motorista", "Endereco_Cidade", c => c.String());
            AddColumn("dbo.Motorista", "Endereco_UF", c => c.String());
            AddColumn("dbo.Cliente", "Endereco_Rua", c => c.String());
            AddColumn("dbo.Cliente", "Endereco_Numero", c => c.String());
            AddColumn("dbo.Cliente", "Endereco_Bairro", c => c.String());
            AddColumn("dbo.Cliente", "Endereco_Cidade", c => c.String());
            AddColumn("dbo.Cliente", "Endereco_UF", c => c.String());
            AddColumn("dbo.Garagem", "Endereco_Rua", c => c.String());
            AddColumn("dbo.Garagem", "Endereco_Numero", c => c.String());
            AddColumn("dbo.Garagem", "Endereco_Bairro", c => c.String());
            AddColumn("dbo.Garagem", "Endereco_Cidade", c => c.String());
            AddColumn("dbo.Garagem", "Endereco_UF", c => c.String());
            AddColumn("dbo.Fornecedor", "LojaVirtual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Fornecedor", "Endereco_Rua", c => c.String());
            AddColumn("dbo.Fornecedor", "Endereco_Numero", c => c.String());
            AddColumn("dbo.Fornecedor", "Endereco_Bairro", c => c.String());
            AddColumn("dbo.Fornecedor", "Endereco_Cidade", c => c.String());
            AddColumn("dbo.Fornecedor", "Endereco_UF", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoOrigem_Rua", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoOrigem_Numero", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoOrigem_Bairro", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoOrigem_Cidade", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoOrigem_UF", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoDestino_Rua", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoDestino_Numero", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoDestino_Bairro", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoDestino_Cidade", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoDestino_UF", c => c.String());
            AddColumn("dbo.Funcionario", "Endereco_Rua", c => c.String());
            AddColumn("dbo.Funcionario", "Endereco_Numero", c => c.String());
            AddColumn("dbo.Funcionario", "Endereco_Bairro", c => c.String());
            AddColumn("dbo.Funcionario", "Endereco_Cidade", c => c.String());
            AddColumn("dbo.Funcionario", "Endereco_UF", c => c.String());
            AlterColumn("dbo.Peca", "FornecedorId", c => c.Long());
            CreateIndex("dbo.Peca", "FornecedorId");
            AddForeignKey("dbo.Peca", "FornecedorId", "dbo.Fornecedor", "FornecedorId");
            DropColumn("dbo.Manutencao", "Local");
            DropColumn("dbo.Cliente", "Endereco");
            DropColumn("dbo.Garagem", "Endereco");
            DropColumn("dbo.Viagem", "EnderecoOrigem");
            DropColumn("dbo.Viagem", "EnderecoDestino");
            DropColumn("dbo.Funcionario", "Endereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Funcionario", "Endereco", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoDestino", c => c.String());
            AddColumn("dbo.Viagem", "EnderecoOrigem", c => c.String());
            AddColumn("dbo.Garagem", "Endereco", c => c.String());
            AddColumn("dbo.Cliente", "Endereco", c => c.String());
            AddColumn("dbo.Manutencao", "Local", c => c.String());
            DropForeignKey("dbo.Peca", "FornecedorId", "dbo.Fornecedor");
            DropIndex("dbo.Peca", new[] { "FornecedorId" });
            AlterColumn("dbo.Peca", "FornecedorId", c => c.Long(nullable: false));
            DropColumn("dbo.Funcionario", "Endereco_UF");
            DropColumn("dbo.Funcionario", "Endereco_Cidade");
            DropColumn("dbo.Funcionario", "Endereco_Bairro");
            DropColumn("dbo.Funcionario", "Endereco_Numero");
            DropColumn("dbo.Funcionario", "Endereco_Rua");
            DropColumn("dbo.Viagem", "EnderecoDestino_UF");
            DropColumn("dbo.Viagem", "EnderecoDestino_Cidade");
            DropColumn("dbo.Viagem", "EnderecoDestino_Bairro");
            DropColumn("dbo.Viagem", "EnderecoDestino_Numero");
            DropColumn("dbo.Viagem", "EnderecoDestino_Rua");
            DropColumn("dbo.Viagem", "EnderecoOrigem_UF");
            DropColumn("dbo.Viagem", "EnderecoOrigem_Cidade");
            DropColumn("dbo.Viagem", "EnderecoOrigem_Bairro");
            DropColumn("dbo.Viagem", "EnderecoOrigem_Numero");
            DropColumn("dbo.Viagem", "EnderecoOrigem_Rua");
            DropColumn("dbo.Fornecedor", "Endereco_UF");
            DropColumn("dbo.Fornecedor", "Endereco_Cidade");
            DropColumn("dbo.Fornecedor", "Endereco_Bairro");
            DropColumn("dbo.Fornecedor", "Endereco_Numero");
            DropColumn("dbo.Fornecedor", "Endereco_Rua");
            DropColumn("dbo.Fornecedor", "LojaVirtual");
            DropColumn("dbo.Garagem", "Endereco_UF");
            DropColumn("dbo.Garagem", "Endereco_Cidade");
            DropColumn("dbo.Garagem", "Endereco_Bairro");
            DropColumn("dbo.Garagem", "Endereco_Numero");
            DropColumn("dbo.Garagem", "Endereco_Rua");
            DropColumn("dbo.Cliente", "Endereco_UF");
            DropColumn("dbo.Cliente", "Endereco_Cidade");
            DropColumn("dbo.Cliente", "Endereco_Bairro");
            DropColumn("dbo.Cliente", "Endereco_Numero");
            DropColumn("dbo.Cliente", "Endereco_Rua");
            DropColumn("dbo.Motorista", "Endereco_UF");
            DropColumn("dbo.Motorista", "Endereco_Cidade");
            DropColumn("dbo.Motorista", "Endereco_Bairro");
            DropColumn("dbo.Motorista", "Endereco_Numero");
            DropColumn("dbo.Motorista", "Endereco_Rua");
            DropColumn("dbo.Manutencao", "Local_UF");
            DropColumn("dbo.Manutencao", "Local_Cidade");
            DropColumn("dbo.Manutencao", "Local_Bairro");
            DropColumn("dbo.Manutencao", "Local_Numero");
            DropColumn("dbo.Manutencao", "Local_Rua");
            CreateIndex("dbo.Peca", "FornecedorId");
            AddForeignKey("dbo.Peca", "FornecedorId", "dbo.Fornecedor", "FornecedorId", cascadeDelete: true);
        }
    }
}
