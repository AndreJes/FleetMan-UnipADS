namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUserPrimaryForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuariosClientes", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuariosFuncionarios", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuariosMotoristas", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.UsuariosClientes", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosClientes", new[] { "ClienteId" });
            DropIndex("dbo.UsuariosFuncionarios", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosFuncionarios", new[] { "FuncionarioId" });
            DropIndex("dbo.UsuariosMotoristas", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosMotoristas", new[] { "MotoristaId" });
            DropPrimaryKey("dbo.UsuariosClientes");
            DropPrimaryKey("dbo.UsuariosFuncionarios");
            DropPrimaryKey("dbo.UsuariosMotoristas");
            AddColumn("dbo.UsuariosClientes", "Login", c => c.String());
            AddColumn("dbo.UsuariosClientes", "Senha", c => c.String());
            AddColumn("dbo.UsuariosFuncionarios", "Login", c => c.String());
            AddColumn("dbo.UsuariosFuncionarios", "Senha", c => c.String());
            AddColumn("dbo.UsuariosMotoristas", "Login", c => c.String());
            AddColumn("dbo.UsuariosMotoristas", "Senha", c => c.String());
            AlterColumn("dbo.UsuariosClientes", "ClienteId", c => c.Long(nullable: false));
            AlterColumn("dbo.UsuariosFuncionarios", "FuncionarioId", c => c.Long(nullable: false));
            AlterColumn("dbo.UsuariosMotoristas", "MotoristaId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.UsuariosClientes", "ClienteId");
            AddPrimaryKey("dbo.UsuariosFuncionarios", "FuncionarioId");
            AddPrimaryKey("dbo.UsuariosMotoristas", "MotoristaId");
            CreateIndex("dbo.UsuariosClientes", "ClienteId");
            CreateIndex("dbo.UsuariosFuncionarios", "FuncionarioId");
            CreateIndex("dbo.UsuariosMotoristas", "MotoristaId");
            DropColumn("dbo.UsuariosClientes", "UsuarioId");
            DropColumn("dbo.UsuariosFuncionarios", "UsuarioId");
            DropColumn("dbo.UsuariosMotoristas", "UsuarioId");
            DropTable("dbo.Usuario");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            AddColumn("dbo.UsuariosMotoristas", "UsuarioId", c => c.Long(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "UsuarioId", c => c.Long(nullable: false));
            AddColumn("dbo.UsuariosClientes", "UsuarioId", c => c.Long(nullable: false));
            DropIndex("dbo.UsuariosMotoristas", new[] { "MotoristaId" });
            DropIndex("dbo.UsuariosFuncionarios", new[] { "FuncionarioId" });
            DropIndex("dbo.UsuariosClientes", new[] { "ClienteId" });
            DropPrimaryKey("dbo.UsuariosMotoristas");
            DropPrimaryKey("dbo.UsuariosFuncionarios");
            DropPrimaryKey("dbo.UsuariosClientes");
            AlterColumn("dbo.UsuariosMotoristas", "MotoristaId", c => c.Long());
            AlterColumn("dbo.UsuariosFuncionarios", "FuncionarioId", c => c.Long());
            AlterColumn("dbo.UsuariosClientes", "ClienteId", c => c.Long());
            DropColumn("dbo.UsuariosMotoristas", "Senha");
            DropColumn("dbo.UsuariosMotoristas", "Login");
            DropColumn("dbo.UsuariosFuncionarios", "Senha");
            DropColumn("dbo.UsuariosFuncionarios", "Login");
            DropColumn("dbo.UsuariosClientes", "Senha");
            DropColumn("dbo.UsuariosClientes", "Login");
            AddPrimaryKey("dbo.UsuariosMotoristas", "UsuarioId");
            AddPrimaryKey("dbo.UsuariosFuncionarios", "UsuarioId");
            AddPrimaryKey("dbo.UsuariosClientes", "UsuarioId");
            CreateIndex("dbo.UsuariosMotoristas", "MotoristaId");
            CreateIndex("dbo.UsuariosMotoristas", "UsuarioId");
            CreateIndex("dbo.UsuariosFuncionarios", "FuncionarioId");
            CreateIndex("dbo.UsuariosFuncionarios", "UsuarioId");
            CreateIndex("dbo.UsuariosClientes", "ClienteId");
            CreateIndex("dbo.UsuariosClientes", "UsuarioId");
            AddForeignKey("dbo.UsuariosMotoristas", "UsuarioId", "dbo.Usuario", "UsuarioId");
            AddForeignKey("dbo.UsuariosFuncionarios", "UsuarioId", "dbo.Usuario", "UsuarioId");
            AddForeignKey("dbo.UsuariosClientes", "UsuarioId", "dbo.Usuario", "UsuarioId");
        }
    }
}
