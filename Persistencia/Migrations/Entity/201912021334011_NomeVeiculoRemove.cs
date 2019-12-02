namespace Persistencia.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeVeiculoRemove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Veiculo", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Veiculo", "Nome", c => c.String());
        }
    }
}
