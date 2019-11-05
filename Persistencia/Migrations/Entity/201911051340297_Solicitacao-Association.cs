namespace Persistencia.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolicitacaoAssociation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Solicitacao", "DataProcessamento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Solicitacao", "DataProcessamento", c => c.DateTime(nullable: false));
        }
    }
}
