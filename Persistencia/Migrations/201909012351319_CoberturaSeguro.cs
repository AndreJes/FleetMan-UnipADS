namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoberturaSeguro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seguro", "TipoCobertura", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seguro", "TipoCobertura");
        }
    }
}
