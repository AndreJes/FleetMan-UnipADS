namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoIntGaragem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Garagem", "Capacidade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Garagem", "Capacidade");
        }
    }
}
