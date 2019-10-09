namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FuncionarioRG : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionario", "RG", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcionario", "RG");
        }
    }
}
