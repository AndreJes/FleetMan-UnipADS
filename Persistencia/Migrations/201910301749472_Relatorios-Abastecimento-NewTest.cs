namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelatoriosAbastecimentoNewTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abastecimento", "RelatorioConsumo_RelatorioId", "dbo.RelatoriosConsumos");
            DropIndex("dbo.Abastecimento", new[] { "RelatorioConsumo_RelatorioId" });
            AddColumn("dbo.Relatorio", "DataInicial", c => c.DateTime(nullable: false));
            AddColumn("dbo.Relatorio", "DataFinal", c => c.DateTime(nullable: false));
            AddColumn("dbo.RelatoriosConsumos", "QntVeiculosAbastecidos", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosConsumos", "TotalCombustivel", c => c.Double(nullable: false));
            AddColumn("dbo.RelatoriosConsumos", "MediaDeCombustivel", c => c.Double(nullable: false));
            AddColumn("dbo.RelatoriosConsumos", "ValorGastoTotal", c => c.Double(nullable: false));
            AddColumn("dbo.RelatoriosConsumos", "ValorGastoMedio", c => c.Double(nullable: false));
            DropColumn("dbo.Abastecimento", "RelatorioConsumo_RelatorioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abastecimento", "RelatorioConsumo_RelatorioId", c => c.Long());
            DropColumn("dbo.RelatoriosConsumos", "ValorGastoMedio");
            DropColumn("dbo.RelatoriosConsumos", "ValorGastoTotal");
            DropColumn("dbo.RelatoriosConsumos", "MediaDeCombustivel");
            DropColumn("dbo.RelatoriosConsumos", "TotalCombustivel");
            DropColumn("dbo.RelatoriosConsumos", "QntVeiculosAbastecidos");
            DropColumn("dbo.Relatorio", "DataFinal");
            DropColumn("dbo.Relatorio", "DataInicial");
            CreateIndex("dbo.Abastecimento", "RelatorioConsumo_RelatorioId");
            AddForeignKey("dbo.Abastecimento", "RelatorioConsumo_RelatorioId", "dbo.RelatoriosConsumos", "RelatorioId");
        }
    }
}
