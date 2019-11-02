namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUserCliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuariosClientes", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.UsuariosClientes", new[] { "ClienteId" });
            DropTable("dbo.UsuariosClientes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuariosClientes",
                c => new
                    {
                        ClienteId = c.Long(nullable: false),
                        Login = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateIndex("dbo.UsuariosClientes", "ClienteId");
            AddForeignKey("dbo.UsuariosClientes", "ClienteId", "dbo.Cliente", "ClienteId");
        }
    }
}
