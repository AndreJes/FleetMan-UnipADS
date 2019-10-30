namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPKPecaManu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao");
            DropIndex("dbo.PecasManutencao", new[] { "ManutencaoId" });
            DropPrimaryKey("dbo.PecasManutencao");
            AlterColumn("dbo.PecasManutencao", "PecaManutencaoId", c => c.Long(nullable: false));
            AlterColumn("dbo.PecasManutencao", "ManutencaoId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.PecasManutencao", new[] { "PecaManutencaoId", "ManutencaoId" });
            CreateIndex("dbo.PecasManutencao", "ManutencaoId");
            AddForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao", "ManutencaoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao");
            DropIndex("dbo.PecasManutencao", new[] { "ManutencaoId" });
            DropPrimaryKey("dbo.PecasManutencao");
            AlterColumn("dbo.PecasManutencao", "ManutencaoId", c => c.Long());
            AlterColumn("dbo.PecasManutencao", "PecaManutencaoId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.PecasManutencao", "PecaManutencaoId");
            CreateIndex("dbo.PecasManutencao", "ManutencaoId");
            AddForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao", "ManutencaoId");
        }
    }
}
