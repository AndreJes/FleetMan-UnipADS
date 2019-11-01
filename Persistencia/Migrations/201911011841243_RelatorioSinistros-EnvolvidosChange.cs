namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelatorioSinistrosEnvolvidosChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RelatoriosAcidentes", "TotalDeEnvolvidos", c => c.Int(nullable: false));
            DropColumn("dbo.RelatoriosAcidentes", "MediaDeEnvolvidos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RelatoriosAcidentes", "MediaDeEnvolvidos", c => c.Int(nullable: false));
            DropColumn("dbo.RelatoriosAcidentes", "TotalDeEnvolvidos");
        }
    }
}
