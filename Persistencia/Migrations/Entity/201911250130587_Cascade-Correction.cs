namespace Persistencia.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeCorrection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abastecimento", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo");
            DropForeignKey("dbo.Aluguel", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo");
            DropForeignKey("dbo.Manutencao", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo");
            DropForeignKey("dbo.Multa", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo");
            DropForeignKey("dbo.Sinistro", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo");
            DropForeignKey("dbo.Viagem", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo");
            DropIndex("dbo.Abastecimento", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            DropIndex("dbo.Aluguel", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            DropIndex("dbo.Manutencao", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            DropIndex("dbo.Multa", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            DropIndex("dbo.Sinistro", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            DropIndex("dbo.Viagem", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            DropIndex("dbo.UsuariosMotoristas", new[] { "MotoristaId" });
            DropColumn("dbo.Abastecimento", "VeiculoId");
            DropColumn("dbo.Aluguel", "VeiculoId");
            DropColumn("dbo.Manutencao", "VeiculoId");
            DropColumn("dbo.Multa", "VeiculoId");
            DropColumn("dbo.Sinistro", "VeiculoId");
            DropColumn("dbo.Viagem", "VeiculoId");
            RenameColumn(table: "dbo.Abastecimento", name: "Veiculo_VeiculoId", newName: "VeiculoId");
            RenameColumn(table: "dbo.Aluguel", name: "Veiculo_VeiculoId", newName: "VeiculoId");
            RenameColumn(table: "dbo.Manutencao", name: "Veiculo_VeiculoId", newName: "VeiculoId");
            RenameColumn(table: "dbo.Multa", name: "Veiculo_VeiculoId", newName: "VeiculoId");
            RenameColumn(table: "dbo.Sinistro", name: "Veiculo_VeiculoId", newName: "VeiculoId");
            RenameColumn(table: "dbo.Viagem", name: "Veiculo_VeiculoId", newName: "VeiculoId");
            DropPrimaryKey("dbo.Veiculo");
            DropPrimaryKey("dbo.UsuariosMotoristas");
            AddColumn("dbo.UsuariosMotoristas", "UsuarioId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Abastecimento", "VeiculoId", c => c.Long(nullable: false));
            AlterColumn("dbo.Aluguel", "VeiculoId", c => c.Long(nullable: false));
            AlterColumn("dbo.Veiculo", "VeiculoId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Veiculo", "Placa", c => c.String());
            AlterColumn("dbo.Veiculo", "CodRenavam", c => c.String());
            AlterColumn("dbo.Manutencao", "VeiculoId", c => c.Long(nullable: false));
            AlterColumn("dbo.Multa", "VeiculoId", c => c.Long(nullable: false));
            AlterColumn("dbo.Sinistro", "VeiculoId", c => c.Long(nullable: false));
            AlterColumn("dbo.Viagem", "VeiculoId", c => c.Long(nullable: false));
            AlterColumn("dbo.UsuariosMotoristas", "MotoristaId", c => c.Long());
            AddPrimaryKey("dbo.Veiculo", "VeiculoId");
            AddPrimaryKey("dbo.UsuariosMotoristas", "UsuarioId");
            CreateIndex("dbo.Abastecimento", "VeiculoId");
            CreateIndex("dbo.Aluguel", "VeiculoId");
            CreateIndex("dbo.Manutencao", "VeiculoId");
            CreateIndex("dbo.Multa", "VeiculoId");
            CreateIndex("dbo.Sinistro", "VeiculoId");
            CreateIndex("dbo.Viagem", "VeiculoId");
            CreateIndex("dbo.UsuariosMotoristas", "MotoristaId");
            AddForeignKey("dbo.Abastecimento", "VeiculoId", "dbo.Veiculo", "VeiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Aluguel", "VeiculoId", "dbo.Veiculo", "VeiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Manutencao", "VeiculoId", "dbo.Veiculo", "VeiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Multa", "VeiculoId", "dbo.Veiculo", "VeiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Sinistro", "VeiculoId", "dbo.Veiculo", "VeiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Viagem", "VeiculoId", "dbo.Veiculo", "VeiculoId", cascadeDelete: true);
            DropColumn("dbo.Abastecimento", "Veiculo_Placa");
            DropColumn("dbo.Abastecimento", "Veiculo_CodRenavam");
            DropColumn("dbo.Aluguel", "Veiculo_Placa");
            DropColumn("dbo.Aluguel", "Veiculo_CodRenavam");
            DropColumn("dbo.Manutencao", "Veiculo_Placa");
            DropColumn("dbo.Manutencao", "Veiculo_CodRenavam");
            DropColumn("dbo.Multa", "Veiculo_Placa");
            DropColumn("dbo.Multa", "Veiculo_CodRenavam");
            DropColumn("dbo.Sinistro", "Veiculo_Placa");
            DropColumn("dbo.Sinistro", "Veiculo_CodRenavam");
            DropColumn("dbo.Viagem", "Veiculo_Placa");
            DropColumn("dbo.Viagem", "Veiculo_CodRenavam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Viagem", "Veiculo_CodRenavam", c => c.String(maxLength: 128));
            AddColumn("dbo.Viagem", "Veiculo_Placa", c => c.String(maxLength: 128));
            AddColumn("dbo.Sinistro", "Veiculo_CodRenavam", c => c.String(maxLength: 128));
            AddColumn("dbo.Sinistro", "Veiculo_Placa", c => c.String(maxLength: 128));
            AddColumn("dbo.Multa", "Veiculo_CodRenavam", c => c.String(maxLength: 128));
            AddColumn("dbo.Multa", "Veiculo_Placa", c => c.String(maxLength: 128));
            AddColumn("dbo.Manutencao", "Veiculo_CodRenavam", c => c.String(maxLength: 128));
            AddColumn("dbo.Manutencao", "Veiculo_Placa", c => c.String(maxLength: 128));
            AddColumn("dbo.Aluguel", "Veiculo_CodRenavam", c => c.String(maxLength: 128));
            AddColumn("dbo.Aluguel", "Veiculo_Placa", c => c.String(maxLength: 128));
            AddColumn("dbo.Abastecimento", "Veiculo_CodRenavam", c => c.String(maxLength: 128));
            AddColumn("dbo.Abastecimento", "Veiculo_Placa", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Viagem", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Sinistro", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Multa", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Manutencao", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Aluguel", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Abastecimento", "VeiculoId", "dbo.Veiculo");
            DropIndex("dbo.UsuariosMotoristas", new[] { "MotoristaId" });
            DropIndex("dbo.Viagem", new[] { "VeiculoId" });
            DropIndex("dbo.Sinistro", new[] { "VeiculoId" });
            DropIndex("dbo.Multa", new[] { "VeiculoId" });
            DropIndex("dbo.Manutencao", new[] { "VeiculoId" });
            DropIndex("dbo.Aluguel", new[] { "VeiculoId" });
            DropIndex("dbo.Abastecimento", new[] { "VeiculoId" });
            DropPrimaryKey("dbo.UsuariosMotoristas");
            DropPrimaryKey("dbo.Veiculo");
            AlterColumn("dbo.UsuariosMotoristas", "MotoristaId", c => c.Long(nullable: false));
            AlterColumn("dbo.Viagem", "VeiculoId", c => c.Long());
            AlterColumn("dbo.Sinistro", "VeiculoId", c => c.Long());
            AlterColumn("dbo.Multa", "VeiculoId", c => c.Long());
            AlterColumn("dbo.Manutencao", "VeiculoId", c => c.Long());
            AlterColumn("dbo.Veiculo", "CodRenavam", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Veiculo", "Placa", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Veiculo", "VeiculoId", c => c.Long(nullable: false));
            AlterColumn("dbo.Aluguel", "VeiculoId", c => c.Long());
            AlterColumn("dbo.Abastecimento", "VeiculoId", c => c.Long());
            DropColumn("dbo.UsuariosMotoristas", "UsuarioId");
            AddPrimaryKey("dbo.UsuariosMotoristas", "MotoristaId");
            AddPrimaryKey("dbo.Veiculo", new[] { "VeiculoId", "Placa", "CodRenavam" });
            RenameColumn(table: "dbo.Viagem", name: "VeiculoId", newName: "Veiculo_VeiculoId");
            RenameColumn(table: "dbo.Sinistro", name: "VeiculoId", newName: "Veiculo_VeiculoId");
            RenameColumn(table: "dbo.Multa", name: "VeiculoId", newName: "Veiculo_VeiculoId");
            RenameColumn(table: "dbo.Manutencao", name: "VeiculoId", newName: "Veiculo_VeiculoId");
            RenameColumn(table: "dbo.Aluguel", name: "VeiculoId", newName: "Veiculo_VeiculoId");
            RenameColumn(table: "dbo.Abastecimento", name: "VeiculoId", newName: "Veiculo_VeiculoId");
            AddColumn("dbo.Viagem", "VeiculoId", c => c.Long(nullable: false));
            AddColumn("dbo.Sinistro", "VeiculoId", c => c.Long(nullable: false));
            AddColumn("dbo.Multa", "VeiculoId", c => c.Long(nullable: false));
            AddColumn("dbo.Manutencao", "VeiculoId", c => c.Long(nullable: false));
            AddColumn("dbo.Aluguel", "VeiculoId", c => c.Long(nullable: false));
            AddColumn("dbo.Abastecimento", "VeiculoId", c => c.Long(nullable: false));
            CreateIndex("dbo.UsuariosMotoristas", "MotoristaId");
            CreateIndex("dbo.Viagem", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            CreateIndex("dbo.Sinistro", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            CreateIndex("dbo.Multa", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            CreateIndex("dbo.Manutencao", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            CreateIndex("dbo.Aluguel", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            CreateIndex("dbo.Abastecimento", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" });
            AddForeignKey("dbo.Viagem", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo", new[] { "VeiculoId", "Placa", "CodRenavam" });
            AddForeignKey("dbo.Sinistro", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo", new[] { "VeiculoId", "Placa", "CodRenavam" });
            AddForeignKey("dbo.Multa", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo", new[] { "VeiculoId", "Placa", "CodRenavam" });
            AddForeignKey("dbo.Manutencao", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo", new[] { "VeiculoId", "Placa", "CodRenavam" });
            AddForeignKey("dbo.Aluguel", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo", new[] { "VeiculoId", "Placa", "CodRenavam" });
            AddForeignKey("dbo.Abastecimento", new[] { "Veiculo_VeiculoId", "Veiculo_Placa", "Veiculo_CodRenavam" }, "dbo.Veiculo", new[] { "VeiculoId", "Placa", "CodRenavam" });
        }
    }
}
