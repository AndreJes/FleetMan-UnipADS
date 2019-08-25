namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUshortToInt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viagem", "QuantidadePassageiros", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viagem", "QuantidadePassageiros");
        }
    }
}
