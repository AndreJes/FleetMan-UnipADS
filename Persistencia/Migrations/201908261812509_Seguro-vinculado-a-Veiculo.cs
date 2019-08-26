namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegurovinculadoaVeiculo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seguro", "VeiculoId", "dbo.Veiculo");
            DropIndex("dbo.Seguro", new[] { "VeiculoId" });
            AddColumn("dbo.Veiculo", "SeguroId", c => c.Long());
            AddColumn("dbo.Sinistro", "QntEnvolvidos", c => c.Int(nullable: false));
            CreateIndex("dbo.Veiculo", "SeguroId");
            AddForeignKey("dbo.Veiculo", "SeguroId", "dbo.Seguro", "SeguroId");
            DropColumn("dbo.Seguro", "VeiculoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seguro", "VeiculoId", c => c.Long());
            DropForeignKey("dbo.Veiculo", "SeguroId", "dbo.Seguro");
            DropIndex("dbo.Veiculo", new[] { "SeguroId" });
            DropColumn("dbo.Sinistro", "QntEnvolvidos");
            DropColumn("dbo.Veiculo", "SeguroId");
            CreateIndex("dbo.Seguro", "VeiculoId");
            AddForeignKey("dbo.Seguro", "VeiculoId", "dbo.Veiculo", "VeiculoId");
        }
    }
}
