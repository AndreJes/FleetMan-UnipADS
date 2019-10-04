namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodigoFinanca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Financa", "Codigo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Financa", "Codigo");
        }
    }
}
