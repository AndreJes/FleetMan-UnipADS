namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelatoriosNewProps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Financa", "RelatorioFinanceiro_RelatorioId", "dbo.RelatoriosFinanceiros");
            DropForeignKey("dbo.Manutencao", "RelatorioManutencao_RelatorioId", "dbo.RelatoriosManutencao");
            DropForeignKey("dbo.Multa", "RelatorioMulta_RelatorioId", "dbo.RelatoriosMultas");
            DropForeignKey("dbo.Sinistro", "RelatorioSinistros_RelatorioId", "dbo.RelatoriosAcidentes");
            DropForeignKey("dbo.Viagem", "RelatorioViagem_RelatorioId", "dbo.RelatoriosViagens");
            DropIndex("dbo.Manutencao", new[] { "RelatorioManutencao_RelatorioId" });
            DropIndex("dbo.Multa", new[] { "RelatorioMulta_RelatorioId" });
            DropIndex("dbo.Sinistro", new[] { "RelatorioSinistros_RelatorioId" });
            DropIndex("dbo.Viagem", new[] { "RelatorioViagem_RelatorioId" });
            DropIndex("dbo.Financa", new[] { "RelatorioFinanceiro_RelatorioId" });
            AddColumn("dbo.RelatoriosFinanceiros", "QntTotalFinancas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosFinanceiros", "QntFinancasVencidas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosFinanceiros", "QntFinancasPagas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosFinanceiros", "QntFinancasAguardando", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosFinanceiros", "TotalValorEntradas", c => c.Double(nullable: false));
            AddColumn("dbo.RelatoriosFinanceiros", "TotalValorSaidas", c => c.Double(nullable: false));
            AddColumn("dbo.RelatoriosManutencao", "QntTotalMan", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosManutencao", "QntManAguardando", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosManutencao", "QntManConcluidas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosManutencao", "QntManCanceladas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosManutencao", "QntManAgendadas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosManutencao", "QntManPreventivas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosManutencao", "QntManCorretivas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "QntTotalMultas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "QntMultasVencidas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "QntMultasPagas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "QntMultasAguardando", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "ValorTotal", c => c.Double(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "ValorMedio", c => c.Double(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "QntMultasLeves", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "QntMultasMedias", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "QntMultasGraves", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "QntMultasGravissimas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosMultas", "GravidadeMaisComum", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntTotalSinistros", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "MediaDeEnvolvidos", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntSinistrosVencidos", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntSininistrosPagos", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntSinistrosAguardando", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntBatidas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntAcidentesLevesCVitima", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntAcidentesLevesSVitima", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntAcidentesGraves", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntAcidentesFatais", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntPerdasTotais", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "GravidadeMaisComum", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosViagens", "QntTotalViagens", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosViagens", "QntViagensAguardando", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosViagens", "QntViagensEmAndamento", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosViagens", "QntViagensConcluidas", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosViagens", "QntViagensCanceladas", c => c.Int(nullable: false));
            DropColumn("dbo.Manutencao", "RelatorioManutencao_RelatorioId");
            DropColumn("dbo.Multa", "RelatorioMulta_RelatorioId");
            DropColumn("dbo.Sinistro", "RelatorioSinistros_RelatorioId");
            DropColumn("dbo.Viagem", "RelatorioViagem_RelatorioId");
            DropColumn("dbo.Financa", "RelatorioFinanceiro_RelatorioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Financa", "RelatorioFinanceiro_RelatorioId", c => c.Long());
            AddColumn("dbo.Viagem", "RelatorioViagem_RelatorioId", c => c.Long());
            AddColumn("dbo.Sinistro", "RelatorioSinistros_RelatorioId", c => c.Long());
            AddColumn("dbo.Multa", "RelatorioMulta_RelatorioId", c => c.Long());
            AddColumn("dbo.Manutencao", "RelatorioManutencao_RelatorioId", c => c.Long());
            DropColumn("dbo.RelatoriosViagens", "QntViagensCanceladas");
            DropColumn("dbo.RelatoriosViagens", "QntViagensConcluidas");
            DropColumn("dbo.RelatoriosViagens", "QntViagensEmAndamento");
            DropColumn("dbo.RelatoriosViagens", "QntViagensAguardando");
            DropColumn("dbo.RelatoriosViagens", "QntTotalViagens");
            DropColumn("dbo.RelatoriosAcidentes", "GravidadeMaisComum");
            DropColumn("dbo.RelatoriosAcidentes", "QntPerdasTotais");
            DropColumn("dbo.RelatoriosAcidentes", "QntAcidentesFatais");
            DropColumn("dbo.RelatoriosAcidentes", "QntAcidentesGraves");
            DropColumn("dbo.RelatoriosAcidentes", "QntAcidentesLevesSVitima");
            DropColumn("dbo.RelatoriosAcidentes", "QntAcidentesLevesCVitima");
            DropColumn("dbo.RelatoriosAcidentes", "QntBatidas");
            DropColumn("dbo.RelatoriosAcidentes", "QntSinistrosAguardando");
            DropColumn("dbo.RelatoriosAcidentes", "QntSininistrosPagos");
            DropColumn("dbo.RelatoriosAcidentes", "QntSinistrosVencidos");
            DropColumn("dbo.RelatoriosAcidentes", "MediaDeEnvolvidos");
            DropColumn("dbo.RelatoriosAcidentes", "QntTotalSinistros");
            DropColumn("dbo.RelatoriosMultas", "GravidadeMaisComum");
            DropColumn("dbo.RelatoriosMultas", "QntMultasGravissimas");
            DropColumn("dbo.RelatoriosMultas", "QntMultasGraves");
            DropColumn("dbo.RelatoriosMultas", "QntMultasMedias");
            DropColumn("dbo.RelatoriosMultas", "QntMultasLeves");
            DropColumn("dbo.RelatoriosMultas", "ValorMedio");
            DropColumn("dbo.RelatoriosMultas", "ValorTotal");
            DropColumn("dbo.RelatoriosMultas", "QntMultasAguardando");
            DropColumn("dbo.RelatoriosMultas", "QntMultasPagas");
            DropColumn("dbo.RelatoriosMultas", "QntMultasVencidas");
            DropColumn("dbo.RelatoriosMultas", "QntTotalMultas");
            DropColumn("dbo.RelatoriosManutencao", "QntManCorretivas");
            DropColumn("dbo.RelatoriosManutencao", "QntManPreventivas");
            DropColumn("dbo.RelatoriosManutencao", "QntManAgendadas");
            DropColumn("dbo.RelatoriosManutencao", "QntManCanceladas");
            DropColumn("dbo.RelatoriosManutencao", "QntManConcluidas");
            DropColumn("dbo.RelatoriosManutencao", "QntManAguardando");
            DropColumn("dbo.RelatoriosManutencao", "QntTotalMan");
            DropColumn("dbo.RelatoriosFinanceiros", "TotalValorSaidas");
            DropColumn("dbo.RelatoriosFinanceiros", "TotalValorEntradas");
            DropColumn("dbo.RelatoriosFinanceiros", "QntFinancasAguardando");
            DropColumn("dbo.RelatoriosFinanceiros", "QntFinancasPagas");
            DropColumn("dbo.RelatoriosFinanceiros", "QntFinancasVencidas");
            DropColumn("dbo.RelatoriosFinanceiros", "QntTotalFinancas");
            CreateIndex("dbo.Financa", "RelatorioFinanceiro_RelatorioId");
            CreateIndex("dbo.Viagem", "RelatorioViagem_RelatorioId");
            CreateIndex("dbo.Sinistro", "RelatorioSinistros_RelatorioId");
            CreateIndex("dbo.Multa", "RelatorioMulta_RelatorioId");
            CreateIndex("dbo.Manutencao", "RelatorioManutencao_RelatorioId");
            AddForeignKey("dbo.Viagem", "RelatorioViagem_RelatorioId", "dbo.RelatoriosViagens", "RelatorioId");
            AddForeignKey("dbo.Sinistro", "RelatorioSinistros_RelatorioId", "dbo.RelatoriosAcidentes", "RelatorioId");
            AddForeignKey("dbo.Multa", "RelatorioMulta_RelatorioId", "dbo.RelatoriosMultas", "RelatorioId");
            AddForeignKey("dbo.Manutencao", "RelatorioManutencao_RelatorioId", "dbo.RelatoriosManutencao", "RelatorioId");
            AddForeignKey("dbo.Financa", "RelatorioFinanceiro_RelatorioId", "dbo.RelatoriosFinanceiros", "RelatorioId");
        }
    }
}
