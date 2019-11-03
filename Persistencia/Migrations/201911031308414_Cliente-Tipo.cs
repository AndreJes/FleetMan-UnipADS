namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteTipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Tipo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "Tipo");
        }
    }
}
