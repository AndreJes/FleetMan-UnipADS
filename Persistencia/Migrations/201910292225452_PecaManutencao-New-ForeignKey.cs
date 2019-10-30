namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PecaManutencaoNewForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao");
            DropForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca");
            DropIndex("dbo.PecasManutencao", new[] { "PecaId" });
            DropIndex("dbo.PecasManutencao", new[] { "ManutencaoId" });
            DropPrimaryKey("dbo.PecasManutencao");
            AlterColumn("dbo.PecasManutencao", "PecaId", c => c.Long(nullable: false));
            AlterColumn("dbo.PecasManutencao", "ManutencaoId", c => c.Long(nullable: false));
            AlterColumn("dbo.PecasManutencao", "PecaManutencaoId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.PecasManutencao", new[] { "PecaManutencaoId", "PecaId", "ManutencaoId" });
            CreateIndex("dbo.PecasManutencao", "PecaId");
            CreateIndex("dbo.PecasManutencao", "ManutencaoId");
            AddForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao", "ManutencaoId", cascadeDelete: true);
            AddForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca", "PecaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca");
            DropForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao");
            DropIndex("dbo.PecasManutencao", new[] { "ManutencaoId" });
            DropIndex("dbo.PecasManutencao", new[] { "PecaId" });
            DropPrimaryKey("dbo.PecasManutencao");
            AlterColumn("dbo.PecasManutencao", "PecaManutencaoId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PecasManutencao", "ManutencaoId", c => c.Long());
            AlterColumn("dbo.PecasManutencao", "PecaId", c => c.Long());
            AddPrimaryKey("dbo.PecasManutencao", "PecaManutencaoId");
            CreateIndex("dbo.PecasManutencao", "ManutencaoId");
            CreateIndex("dbo.PecasManutencao", "PecaId");
            AddForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca", "PecaId");
            AddForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao", "ManutencaoId");
        }
    }
}
