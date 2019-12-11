namespace Persistencia.Migrations.Entity
{
    using Modelo.Classes.Usuarios;
    using Modelo.Classes.Usuarios.Permissoes;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexts.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Entity";
        }

        protected override void Seed(Persistencia.Contexts.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            UsuarioFunc admin = new UsuarioFunc()
            {
                Login = "Admin",
                Senha = "Admin",
                Permissoes = new Permissoes()
                {
                    Clientes = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Financeiro = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Funcionarios = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Garagens = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Locacoes = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Manutencoes = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Motoristas = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    MultasSinistros = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Relatorios = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Seguros = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Solicitacoes = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Veiculos = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true },
                    Viagens = new Funcoes() { Alterar = true, Cadastrar = true, Consultar = true, Remover = true }
                },
                Funcionario = null,
                FuncionarioId = null
            };

            context.UsuariosFuncionarios.AddOrUpdate(uf => uf.Login, admin);

        }
    }
}
