namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewForeignKeyAssociationViagem : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Viagem", "GaragemOrigem_GaragemId");
            DropColumn("dbo.Viagem", "GaragemRetorno_GaragemId");
            RenameColumn(table: "dbo.Viagem", name: "GaragemOrigem_GaragemId1", newName: "GaragemOrigem_GaragemId");
            RenameColumn(table: "dbo.Viagem", name: "GaragemRetorno_GaragemId1", newName: "GaragemRetorno_GaragemId");
            RenameIndex(table: "dbo.Viagem", name: "IX_GaragemOrigem_GaragemId1", newName: "IX_GaragemOrigem_GaragemId");
            RenameIndex(table: "dbo.Viagem", name: "IX_GaragemRetorno_GaragemId1", newName: "IX_GaragemRetorno_GaragemId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Viagem", name: "IX_GaragemRetorno_GaragemId", newName: "IX_GaragemRetorno_GaragemId1");
            RenameIndex(table: "dbo.Viagem", name: "IX_GaragemOrigem_GaragemId", newName: "IX_GaragemOrigem_GaragemId1");
            RenameColumn(table: "dbo.Viagem", name: "GaragemRetorno_GaragemId", newName: "GaragemRetorno_GaragemId1");
            RenameColumn(table: "dbo.Viagem", name: "GaragemOrigem_GaragemId", newName: "GaragemOrigem_GaragemId1");
            AddColumn("dbo.Viagem", "GaragemRetorno_GaragemId", c => c.Long());
            AddColumn("dbo.Viagem", "GaragemOrigem_GaragemId", c => c.Long());
        }
    }
}
