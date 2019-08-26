namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataNaSolicitacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solicitacao", "DataDaSolicitacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Solicitacao", "DataProcessamento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Solicitacao", "DataProcessamento");
            DropColumn("dbo.Solicitacao", "DataDaSolicitacao");
        }
    }
}
