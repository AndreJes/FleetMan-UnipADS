namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermissoesViagens : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Viagens_Alterar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Viagens_Consultar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Viagens_Cadastrar", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsuariosFuncionarios", "Permissoes_Viagens_Remover", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Viagens_Remover");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Viagens_Cadastrar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Viagens_Consultar");
            DropColumn("dbo.UsuariosFuncionarios", "Permissoes_Viagens_Alterar");
        }
    }
}
