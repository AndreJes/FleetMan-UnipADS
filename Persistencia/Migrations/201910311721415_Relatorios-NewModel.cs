namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelatoriosNewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RelatoriosManutencao", "QntManEmAndamento", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosAcidentes", "QntSinistrosPagos", c => c.Int(nullable: false));
            DropColumn("dbo.RelatoriosManutencao", "QntManAgendadas");
            DropColumn("dbo.RelatoriosAcidentes", "QntSininistrosPagos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RelatoriosAcidentes", "QntSininistrosPagos", c => c.Int(nullable: false));
            AddColumn("dbo.RelatoriosManutencao", "QntManAgendadas", c => c.Int(nullable: false));
            DropColumn("dbo.RelatoriosAcidentes", "QntSinistrosPagos");
            DropColumn("dbo.RelatoriosManutencao", "QntManEmAndamento");
        }
    }
}
