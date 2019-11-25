namespace Persistencia.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abastecimento", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Abastecimento", "VeiculoId", "dbo.Veiculo");
            DropIndex("dbo.Abastecimento", new[] { "MotoristaId" });
            DropIndex("dbo.Abastecimento", new[] { "VeiculoId" });
            AlterColumn("dbo.Abastecimento", "MotoristaId", c => c.Long(nullable: false));
            AlterColumn("dbo.Abastecimento", "VeiculoId", c => c.Long(nullable: false));
            CreateIndex("dbo.Abastecimento", "MotoristaId");
            CreateIndex("dbo.Abastecimento", "VeiculoId");
            AddForeignKey("dbo.Abastecimento", "MotoristaId", "dbo.Motorista", "MotoristaId", cascadeDelete: true);
            AddForeignKey("dbo.Abastecimento", "VeiculoId", "dbo.Veiculo", "VeiculoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abastecimento", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Abastecimento", "MotoristaId", "dbo.Motorista");
            DropIndex("dbo.Abastecimento", new[] { "VeiculoId" });
            DropIndex("dbo.Abastecimento", new[] { "MotoristaId" });
            AlterColumn("dbo.Abastecimento", "VeiculoId", c => c.Long());
            AlterColumn("dbo.Abastecimento", "MotoristaId", c => c.Long());
            CreateIndex("dbo.Abastecimento", "VeiculoId");
            CreateIndex("dbo.Abastecimento", "MotoristaId");
            AddForeignKey("dbo.Abastecimento", "VeiculoId", "dbo.Veiculo", "VeiculoId");
            AddForeignKey("dbo.Abastecimento", "MotoristaId", "dbo.Motorista", "MotoristaId");
        }
    }
}
