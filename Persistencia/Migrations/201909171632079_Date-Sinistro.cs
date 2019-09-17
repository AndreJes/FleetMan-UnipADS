namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateSinistro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sinistro", "DataSinistro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sinistro", "DataSinistro");
        }
    }
}
