using Modelo.Classes.Clientes;
using Modelo.Classes.Desk;
using Modelo.Classes.Manutencao;
using Modelo.Classes.Usuarios;
using Modelo.Classes.Usuarios.Permissoes;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;

namespace Persistencia.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Persistencia.Contexts.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Persistencia.Contexts.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ClientePF ClientesPF = new ClientePF(1, "1126784567", "Rua Santos Batista, 155, Ermelino Matarazzo, São Paulo, SP", "Carlos", "Narutinho123@gmail.com", "44433322255");
            ClientePJ ClientesPJ =  new ClientePJ(2, "1134562345", "Rua um, 1, Bras, São Paulo, SP", "XingLing LTDA.", "XinglingRoupas@hotmail.com", "12341234123432");
            Financa Financas = new Financa() { FinancaId = 1, Valor = 50.30, Descricao = "Conta de Luz", DataVencimento = DateTime.ParseExact("07/27/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture), EstadoPagamento = EstadosDePagamento.PAGO } ;
            Funcionario Funcionarios = new Funcionario() { FuncionarioId = 1, CPF = "12332112345", Email = "Jose@gmail.com", Nome = "José", Endereco = "Rua dois, 56, Bras, São Paulo, SP", Telefone = "11956783214" } ;
            Garagem Garagens = new Garagem() { GaragemId = 1, Capacidade = 30, Endereco = "Rua das Garagens, 23, Alemão, Rio de Janeiro, RJ", Telefone = "2143534223", CNPJ = "12343235433323" } ;
            Seguro Seguros = new Seguro() { SeguroId = 1, CNPJ = "12354312354323", PrecoParcela = 250.00, Email = "AutoSeguros@auto.com.br", Telefone = "1253432343", DataContratacao = DateTime.ParseExact("07/30/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture), DataVencimentoParcela = DateTime.Now, EstadoPagamento = EstadosDePagamento.PAGO, Nome = "AutoSeguros LTDA.", Vencimento_Contrato = DateTime.ParseExact("2019", "yyyy", CultureInfo.InvariantCulture) } ;
            Fornecedor Fornecedores = new Fornecedor() { FornecedorId = 1, CNPJ = "78912345632134", Email = "Pecas123@gmail.com", Telefone = "3167893456" } ;
            Peca Pecas = new Peca() { FornecedorId = 1, PecaId = 1, Descricao = "Carburador de Celta", Quantidade = 5 };
            UsuarioFunc UsuariosFuncs = new UsuarioFunc() { UsuarioId = 1, FuncionarioId = 1, Login = Funcionarios.Email, Senha = Funcionarios.CPF.Substring(0, 4), Permissoes = new Permissoes() { Clientes = true, Financeiro = true, Funcionarios = true, Garagens = true, Locacoes = true, Manutencoes = true, Motoristas = true, MultasSinistros = true, Relatorios = true, Seguros = true, Solicitacoes = true, Veiculos = true } };
            UsuarioCliente UsuarioClientes = new UsuarioCliente() { UsuarioId = 2, ClienteId = 1, Login = ClientesPF.Email, Senha = ClientesPF.CPF.Substring(0, 4) } ;

            Motorista Motorista1 = new Motorista() { MotoristaId = 1, CPF = "12345678911", Nome = "Antonio", NumeroCNH = "98712345684", MotoristaProprio = true, PontosCNH = 0, Estado = EstadosDeMotorista.REGULAR, VencimentoExame = DateTime.ParseExact("11/22/2019","MM/dd/yyyy", CultureInfo.InvariantCulture) };
            Motorista Motorista2 = new Motorista() { MotoristaId = 2, CPF = "12345558911", Nome = "Maria", NumeroCNH = "54376512343", MotoristaProprio = false, PontosCNH = 13, Estado = EstadosDeMotorista.REGULAR, VencimentoExame = DateTime.ParseExact("11/25/2019","MM/dd/yyyy", CultureInfo.InvariantCulture), ClienteId = 2 };
            Veiculo Veiculo1 = new Veiculo() { Adaptado = false, Ano = 2018, CategoriaExigida = CategoriasCNH.B, Tipo = TiposDeVeiculo.CARRO, Cor = "Vermelho", CodRenavam = "12398745682", Placa = "JDO2842", Modelo = "Gol", Marca = "Volksvagen", VeiculoId = 1, Nome = "Gol", EstadoDoTanque = EstadosTanqueCombustivel.TRES_QUARTOS, EstadoDoVeiculo = EstadosDeVeiculo.NORMAL, ParaLocacao = true, GaragemId = 1 };
            Veiculo Veiculo2 = new Veiculo() { Adaptado = true, Ano = 2019, CategoriaExigida = CategoriasCNH.C, Tipo = TiposDeVeiculo.VAN, Cor = "Branco", CodRenavam = "12378974582", Placa = "JKO2842", Modelo = "Transit", Marca = "Ford", VeiculoId = 2, Nome = "Ford Transit", EstadoDoTanque = EstadosTanqueCombustivel.CHEIO, EstadoDoVeiculo = EstadosDeVeiculo.NORMAL, ParaLocacao = false, GaragemId = 1, ClienteId = 2 };

            context.ClientesPF.AddOrUpdate<ClientePF>(ClientesPF);
            context.ClientesPJ.AddOrUpdate<ClientePJ>(ClientesPJ);
            context.Financas.AddOrUpdate<Financa>(Financas);
            context.Funcionarios.AddOrUpdate<Funcionario>(Funcionarios);
            context.Garagens.AddOrUpdate<Garagem>(Garagens);
            context.Seguro.AddOrUpdate<Seguro>(Seguros);
            context.Fornecedores.AddOrUpdate<Fornecedor>(Fornecedores);
            context.Pecas.AddOrUpdate<Peca>(Pecas);
            context.UsuariosFuncionarios.AddOrUpdate<UsuarioFunc>(UsuariosFuncs);
            context.UsuariosClientes.AddOrUpdate<UsuarioCliente>(UsuarioClientes);

            context.Motoristas.AddOrUpdate<Motorista>(Motorista1);
            context.Motoristas.AddOrUpdate<Motorista>(Motorista2);

            context.Veiculos.AddOrUpdate<Veiculo>(Veiculo1);
            context.Veiculos.AddOrUpdate<Veiculo>(Veiculo2);
        }
    }
}
