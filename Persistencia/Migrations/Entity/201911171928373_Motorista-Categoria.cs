namespace Persistencia.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotoristaCategoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Motorista", "Categoria", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Motorista", "Categoria");
        }
    }
}
