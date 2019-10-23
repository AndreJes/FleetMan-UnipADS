namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbastecimentoChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abastecimento", "NovoEstadoTanque", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abastecimento", "NovoEstadoTanque");
        }
    }
}
