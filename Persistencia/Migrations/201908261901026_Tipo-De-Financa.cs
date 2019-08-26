namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoDeFinanca : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Financa", "DataPagamento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Financa", "DataPagamento", c => c.DateTime(nullable: false));
        }
    }
}
