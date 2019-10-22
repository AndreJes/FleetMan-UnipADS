namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LotePeca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peca", "Lote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peca", "Lote");
        }
    }
}
