namespace Persistencia.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvisosRemove : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Aviso");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Aviso",
                c => new
                    {
                        AvisoId = c.Long(nullable: false, identity: true),
                        Mensagem = c.String(),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvisoId);
            
        }
    }
}
