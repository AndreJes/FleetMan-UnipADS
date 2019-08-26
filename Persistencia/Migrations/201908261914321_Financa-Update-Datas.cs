namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinancaUpdateDatas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Financa", "DataVencimento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Financa", "DataVencimento", c => c.DateTime(nullable: false));
        }
    }
}
