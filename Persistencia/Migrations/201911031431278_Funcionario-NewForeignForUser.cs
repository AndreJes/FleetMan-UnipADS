namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FuncionarioNewForeignForUser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UsuariosFuncionarios", new[] { "FuncionarioId" });
            DropPrimaryKey("dbo.UsuariosFuncionarios");
            AddColumn("dbo.UsuariosFuncionarios", "UsuarioId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.UsuariosFuncionarios", "FuncionarioId", c => c.Long());
            AddPrimaryKey("dbo.UsuariosFuncionarios", "UsuarioId");
            CreateIndex("dbo.UsuariosFuncionarios", "FuncionarioId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UsuariosFuncionarios", new[] { "FuncionarioId" });
            DropPrimaryKey("dbo.UsuariosFuncionarios");
            AlterColumn("dbo.UsuariosFuncionarios", "FuncionarioId", c => c.Long(nullable: false));
            DropColumn("dbo.UsuariosFuncionarios", "UsuarioId");
            AddPrimaryKey("dbo.UsuariosFuncionarios", "FuncionarioId");
            CreateIndex("dbo.UsuariosFuncionarios", "FuncionarioId");
        }
    }
}
