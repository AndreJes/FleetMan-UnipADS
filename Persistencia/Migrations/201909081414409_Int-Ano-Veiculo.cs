namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntAnoVeiculo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Veiculo", "Ano", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Veiculo", "Ano");
        }
    }
}
