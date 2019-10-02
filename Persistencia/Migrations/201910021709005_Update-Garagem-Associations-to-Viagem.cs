namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGaragemAssociationstoViagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viagem", "GaragemOrigemId", c => c.Long());
            AddColumn("dbo.Viagem", "GaragemRetornoId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viagem", "GaragemRetornoId");
            DropColumn("dbo.Viagem", "GaragemOrigemId");
        }
    }
}
