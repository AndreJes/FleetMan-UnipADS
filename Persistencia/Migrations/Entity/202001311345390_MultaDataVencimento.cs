namespace Persistencia.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultaDataVencimento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Multa", "DataVencimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Multa", "DataVencimento");
        }
    }
}
