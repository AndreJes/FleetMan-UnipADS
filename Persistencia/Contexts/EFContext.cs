using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Modelo.Classes.Clientes;
using Modelo.Classes.Desk;
using Modelo.Classes.Manutencao;
using Modelo.Classes.Relatorios;
using Modelo.Classes.Web;
using Modelo.Classes.Usuarios;
using Persistencia.Migrations;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        #region Dbsets
        #region Clientes
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClientePF> ClientesPF { get; set; }
        public DbSet<ClientePJ> ClientesPJ { get; set; }
        #endregion
        #region Desk
        public DbSet<Aviso> Avisos { get; set; }
        public DbSet<Financa> Financas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Garagem> Garagens { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<Seguro> Seguro { get; set; }
        public DbSet<Sinistro> Sinistros { get; set; }
        #endregion
        #region Manutenção
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<Abastecimento> Abastecimentos { get; set; }
        #endregion
        #region Relatorios
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<RelatorioSinistros> RelatoriosAcidentes { get; set; }
        public DbSet<RelatorioConsumo> RelatoriosConsumos { get; set; }
        public DbSet<RelatorioFinanceiro> RelatoriosFinanceiros { get; set; }
        public DbSet<RelatorioManutencao> RelatoriosManutencao { get; set; }
        public DbSet<RelatorioMulta> RelatoriosMultas { get; set; }
        public DbSet<RelatorioViagem> RelatoriosViagens { get; set; }
        #endregion
        #region Usuarios
        public DbSet<UsuarioFunc> UsuariosFuncionarios { get; set; }
        public DbSet<UsuarioCliente> UsuariosClientes { get; set; }
        public DbSet<UsuarioMotorista> UsuariosMotoristas { get; set; }
        #endregion
        #region Web
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        #endregion
        #endregion

        public EFContext() : base("Banco_Pim_IV")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<RelatorioSinistros>().ToTable("RelatoriosAcidentes");
            modelBuilder.Entity<RelatorioConsumo>().ToTable("RelatoriosConsumos");
            modelBuilder.Entity<RelatorioFinanceiro>().ToTable("RelatoriosFinanceiros");
            modelBuilder.Entity<RelatorioManutencao>().ToTable("RelatoriosManutencao");
            modelBuilder.Entity<RelatorioMulta>().ToTable("RelatoriosMultas");
            modelBuilder.Entity<RelatorioViagem>().ToTable("RelatoriosViagens");
            modelBuilder.Entity<UsuarioCliente>().ToTable("UsuariosClientes");
            modelBuilder.Entity<UsuarioFunc>().ToTable("UsuariosFuncionarios");
            modelBuilder.Entity<UsuarioMotorista>().ToTable("UsuariosMotoristas");
            modelBuilder.Entity<ClientePF>().ToTable("ClientesPF");
            modelBuilder.Entity<ClientePJ>().ToTable("ClientesPJ");

            base.OnModelCreating(modelBuilder);
        }

    }
}
