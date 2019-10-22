namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PecaQuantidadeTipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peca", "Quantidade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peca", "Quantidade");
        }
    }
}
