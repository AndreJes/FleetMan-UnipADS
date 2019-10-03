namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostDeleteViagem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Viagem", "GaragemOrigem_GaragemId", "dbo.Garagem");
            DropForeignKey("dbo.Viagem", "GaragemRetorno_GaragemId", "dbo.Garagem");
            DropIndex("dbo.Viagem", new[] { "GaragemOrigem_GaragemId" });
            DropIndex("dbo.Viagem", new[] { "GaragemRetorno_GaragemId" });
            AddColumn("dbo.Viagem", "GaragemOrigem_GaragemId1", c => c.Long());
            AddColumn("dbo.Viagem", "GaragemRetorno_GaragemId1", c => c.Long());
            CreateIndex("dbo.Viagem", "GaragemOrigem_GaragemId1");
            CreateIndex("dbo.Viagem", "GaragemRetorno_GaragemId1");
            AddForeignKey("dbo.Viagem", "GaragemOrigem_GaragemId1", "dbo.Garagem", "GaragemId");
            AddForeignKey("dbo.Viagem", "GaragemRetorno_GaragemId1", "dbo.Garagem", "GaragemId");
            DropColumn("dbo.Viagem", "GaragemOrigemId");
            DropColumn("dbo.Viagem", "GaragemRetornoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Viagem", "GaragemRetornoId", c => c.Long());
            AddColumn("dbo.Viagem", "GaragemOrigemId", c => c.Long());
            DropForeignKey("dbo.Viagem", "GaragemRetorno_GaragemId1", "dbo.Garagem");
            DropForeignKey("dbo.Viagem", "GaragemOrigem_GaragemId1", "dbo.Garagem");
            DropIndex("dbo.Viagem", new[] { "GaragemRetorno_GaragemId1" });
            DropIndex("dbo.Viagem", new[] { "GaragemOrigem_GaragemId1" });
            DropColumn("dbo.Viagem", "GaragemRetorno_GaragemId1");
            DropColumn("dbo.Viagem", "GaragemOrigem_GaragemId1");
            CreateIndex("dbo.Viagem", "GaragemRetorno_GaragemId");
            CreateIndex("dbo.Viagem", "GaragemOrigem_GaragemId");
            AddForeignKey("dbo.Viagem", "GaragemRetorno_GaragemId", "dbo.Garagem", "GaragemId");
            AddForeignKey("dbo.Viagem", "GaragemOrigem_GaragemId", "dbo.Garagem", "GaragemId");
        }
    }
}
