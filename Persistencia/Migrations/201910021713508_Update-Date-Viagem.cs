namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateViagem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Viagem", "DataChegada", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Viagem", "DataChegada", c => c.DateTime(nullable: false));
        }
    }
}
