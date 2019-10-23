namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbastecimentoNewProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abastecimento", "DataAgendada", c => c.DateTime());
            AddColumn("dbo.Abastecimento", "DataConclusao", c => c.DateTime());
            AddColumn("dbo.Abastecimento", "Estado", c => c.Int(nullable: false));
            AlterColumn("dbo.Abastecimento", "QuantidadeAbastecida", c => c.Double());
            AlterColumn("dbo.Abastecimento", "Valor", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abastecimento", "Valor", c => c.Double(nullable: false));
            AlterColumn("dbo.Abastecimento", "QuantidadeAbastecida", c => c.Double(nullable: false));
            DropColumn("dbo.Abastecimento", "Estado");
            DropColumn("dbo.Abastecimento", "DataConclusao");
            DropColumn("dbo.Abastecimento", "DataAgendada");
        }
    }
}
