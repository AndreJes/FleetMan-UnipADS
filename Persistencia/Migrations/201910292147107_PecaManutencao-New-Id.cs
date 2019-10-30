namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PecaManutencaoNewId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao");
            DropForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca");
            DropIndex("dbo.PecasManutencao", new[] { "PecaId" });
            DropIndex("dbo.PecasManutencao", new[] { "ManutencaoId" });
            DropPrimaryKey("dbo.PecasManutencao");
            AddColumn("dbo.PecasManutencao", "PecaManutencaoId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PecasManutencao", "PecaId", c => c.Long());
            AlterColumn("dbo.PecasManutencao", "ManutencaoId", c => c.Long());
            AddPrimaryKey("dbo.PecasManutencao", "PecaManutencaoId");
            CreateIndex("dbo.PecasManutencao", "PecaId");
            CreateIndex("dbo.PecasManutencao", "ManutencaoId");
            AddForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao", "ManutencaoId");
            AddForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca", "PecaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca");
            DropForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao");
            DropIndex("dbo.PecasManutencao", new[] { "ManutencaoId" });
            DropIndex("dbo.PecasManutencao", new[] { "PecaId" });
            DropPrimaryKey("dbo.PecasManutencao");
            AlterColumn("dbo.PecasManutencao", "ManutencaoId", c => c.Long(nullable: false));
            AlterColumn("dbo.PecasManutencao", "PecaId", c => c.Long(nullable: false));
            DropColumn("dbo.PecasManutencao", "PecaManutencaoId");
            AddPrimaryKey("dbo.PecasManutencao", new[] { "PecaId", "ManutencaoId" });
            CreateIndex("dbo.PecasManutencao", "ManutencaoId");
            CreateIndex("dbo.PecasManutencao", "PecaId");
            AddForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca", "PecaId", cascadeDelete: true);
            AddForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao", "ManutencaoId", cascadeDelete: true);
        }
    }
}
