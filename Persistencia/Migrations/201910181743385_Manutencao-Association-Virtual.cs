namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManutencaoAssociationVirtual : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Manutencao", "DataSaida", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manutencao", "DataSaida", c => c.DateTime(nullable: false));
        }
    }
}
