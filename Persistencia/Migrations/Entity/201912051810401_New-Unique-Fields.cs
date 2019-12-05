namespace Persistencia.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUniqueFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Motorista", "CPF", c => c.String(maxLength: 11));
            AlterColumn("dbo.Motorista", "Celular", c => c.String(maxLength: 11));
            AlterColumn("dbo.Motorista", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Cliente", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.ClientesPF", "CPF", c => c.String(maxLength: 11));
            AlterColumn("dbo.ClientesPJ", "CNPJ", c => c.String(maxLength: 14));
            AlterColumn("dbo.Veiculo", "Placa", c => c.String(maxLength: 8));
            AlterColumn("dbo.Veiculo", "CodRenavam", c => c.String(maxLength: 11));
            AlterColumn("dbo.Garagem", "CNPJ", c => c.String(maxLength: 14));
            AlterColumn("dbo.Peca", "Lote", c => c.String(maxLength: 50));
            AlterColumn("dbo.Fornecedor", "CNPJ", c => c.String(maxLength: 14));
            AlterColumn("dbo.Fornecedor", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Multa", "CodigoMulta", c => c.String(maxLength: 40));
            AlterColumn("dbo.Seguro", "CNPJ", c => c.String(maxLength: 14));
            AlterColumn("dbo.Seguro", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Sinistro", "CodSinistro", c => c.String(maxLength: 40));
            AlterColumn("dbo.Financa", "Codigo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Funcionario", "CPF", c => c.String(maxLength: 11));
            AlterColumn("dbo.Funcionario", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.UsuariosFuncionarios", "Login", c => c.String(maxLength: 100));
            AlterColumn("dbo.UsuariosMotoristas", "Login", c => c.String(maxLength: 100));
            CreateIndex("dbo.Motorista", "CPF", unique: true);
            CreateIndex("dbo.Motorista", "Celular", unique: true);
            CreateIndex("dbo.Motorista", "Email", unique: true);
            CreateIndex("dbo.Cliente", "Email", unique: true);
            CreateIndex("dbo.Veiculo", "Placa", unique: true);
            CreateIndex("dbo.Veiculo", "CodRenavam", unique: true);
            CreateIndex("dbo.Garagem", "CNPJ", unique: true);
            CreateIndex("dbo.Peca", "Lote", unique: true);
            CreateIndex("dbo.Fornecedor", "CNPJ", unique: true);
            CreateIndex("dbo.Fornecedor", "Email", unique: true);
            CreateIndex("dbo.Multa", "CodigoMulta", unique: true);
            CreateIndex("dbo.Seguro", "CNPJ", unique: true);
            CreateIndex("dbo.Seguro", "Email", unique: true);
            CreateIndex("dbo.Sinistro", "CodSinistro", unique: true);
            CreateIndex("dbo.Financa", "Codigo", unique: true);
            CreateIndex("dbo.Funcionario", "CPF", unique: true);
            CreateIndex("dbo.Funcionario", "Email", unique: true);
            CreateIndex("dbo.UsuariosFuncionarios", "Login", unique: true);
            CreateIndex("dbo.UsuariosMotoristas", "Login", unique: true);
            CreateIndex("dbo.ClientesPF", "CPF", unique: true);
            CreateIndex("dbo.ClientesPJ", "CNPJ", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClientesPJ", new[] { "CNPJ" });
            DropIndex("dbo.ClientesPF", new[] { "CPF" });
            DropIndex("dbo.UsuariosMotoristas", new[] { "Login" });
            DropIndex("dbo.UsuariosFuncionarios", new[] { "Login" });
            DropIndex("dbo.Funcionario", new[] { "Email" });
            DropIndex("dbo.Funcionario", new[] { "CPF" });
            DropIndex("dbo.Financa", new[] { "Codigo" });
            DropIndex("dbo.Sinistro", new[] { "CodSinistro" });
            DropIndex("dbo.Seguro", new[] { "Email" });
            DropIndex("dbo.Seguro", new[] { "CNPJ" });
            DropIndex("dbo.Multa", new[] { "CodigoMulta" });
            DropIndex("dbo.Fornecedor", new[] { "Email" });
            DropIndex("dbo.Fornecedor", new[] { "CNPJ" });
            DropIndex("dbo.Peca", new[] { "Lote" });
            DropIndex("dbo.Garagem", new[] { "CNPJ" });
            DropIndex("dbo.Veiculo", new[] { "CodRenavam" });
            DropIndex("dbo.Veiculo", new[] { "Placa" });
            DropIndex("dbo.Cliente", new[] { "Email" });
            DropIndex("dbo.Motorista", new[] { "Email" });
            DropIndex("dbo.Motorista", new[] { "Celular" });
            DropIndex("dbo.Motorista", new[] { "CPF" });
            AlterColumn("dbo.UsuariosMotoristas", "Login", c => c.String());
            AlterColumn("dbo.UsuariosFuncionarios", "Login", c => c.String());
            AlterColumn("dbo.Funcionario", "Email", c => c.String());
            AlterColumn("dbo.Funcionario", "CPF", c => c.String());
            AlterColumn("dbo.Financa", "Codigo", c => c.String());
            AlterColumn("dbo.Sinistro", "CodSinistro", c => c.String());
            AlterColumn("dbo.Seguro", "Email", c => c.String());
            AlterColumn("dbo.Seguro", "CNPJ", c => c.String());
            AlterColumn("dbo.Multa", "CodigoMulta", c => c.String());
            AlterColumn("dbo.Fornecedor", "Email", c => c.String());
            AlterColumn("dbo.Fornecedor", "CNPJ", c => c.String());
            AlterColumn("dbo.Peca", "Lote", c => c.String());
            AlterColumn("dbo.Garagem", "CNPJ", c => c.String());
            AlterColumn("dbo.Veiculo", "CodRenavam", c => c.String());
            AlterColumn("dbo.Veiculo", "Placa", c => c.String());
            AlterColumn("dbo.ClientesPJ", "CNPJ", c => c.String());
            AlterColumn("dbo.ClientesPF", "CPF", c => c.String());
            AlterColumn("dbo.Cliente", "Email", c => c.String());
            AlterColumn("dbo.Motorista", "Email", c => c.String());
            AlterColumn("dbo.Motorista", "Celular", c => c.String());
            AlterColumn("dbo.Motorista", "CPF", c => c.String());
        }
    }
}
