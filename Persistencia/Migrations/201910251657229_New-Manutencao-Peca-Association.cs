namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewManutencaoPecaAssociation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Peca", "Manutencao_ManutencaoId", "dbo.Manutencao");
            DropIndex("dbo.Peca", new[] { "Manutencao_ManutencaoId" });
            CreateTable(
                "dbo.PecasManutencao",
                c => new
                    {
                        PecaId = c.Long(nullable: false),
                        ManutencaoId = c.Long(nullable: false),
                        QuantidadePecasUtilizadas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PecaId, t.ManutencaoId })
                .ForeignKey("dbo.Peca", t => t.PecaId, cascadeDelete: true)
                .ForeignKey("dbo.Manutencao", t => t.ManutencaoId, cascadeDelete: true)
                .Index(t => t.PecaId)
                .Index(t => t.ManutencaoId);
            DropColumn("dbo.Peca", "Manutencao_ManutencaoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peca", "Manutencao_ManutencaoId", c => c.Long());
            DropForeignKey("dbo.PecasManutencao", "ManutencaoId", "dbo.Manutencao");
            DropForeignKey("dbo.PecasManutencao", "PecaId", "dbo.Peca");
            DropIndex("dbo.PecasManutencao", new[] { "ManutencaoId" });
            DropIndex("dbo.PecasManutencao", new[] { "PecaId" });
            DropTable("dbo.PecasManutencao");
            RenameColumn(table: "dbo.PecasManutencao", name: "ManutencaoId", newName: "Manutencao_ManutencaoId");
            CreateIndex("dbo.Peca", "Manutencao_ManutencaoId");
            AddForeignKey("dbo.Peca", "Manutencao_ManutencaoId", "dbo.Manutencao", "ManutencaoId");
        }
    }
}
