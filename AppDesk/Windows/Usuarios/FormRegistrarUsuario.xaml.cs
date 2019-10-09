using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Desk;
using Modelo.Classes.Usuarios;
using Modelo.Classes.Usuarios.Permissoes;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppDesk.Windows.Usuarios
{
    /// <summary>
    /// Lógica interna para FormRegistrarUsuario.xaml
    /// </summary>
    public partial class FormRegistrarUsuario : Window
    {
        public FormRegistrarUsuario()
        {
            InitializeComponent();
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            Funcionario funcionario = GerarFuncionario();
            Permissoes permissoes = GerarPermissoes();

            ServicoDados.ServicoDadosFuncionario.GravarFuncionario(funcionario);

            UsuarioFunc usuario = ServicoDados.ServicoDadosUsuarioF.GerarUsuarioFunc(funcionario, permissoes);

            ServicoDados.ServicoDadosUsuarioF.GravarUsuarioFunc(usuario);

            MessageBox.Show("Usuario registrado com sucesso!");
            MessageBox.Show("Login: " + usuario.Login + Environment.NewLine + "Senha: " + usuario.Senha);

            MainWindowUpdater.UpdateDataGrids();
            this.Close();
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Funcionario GerarFuncionario()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.CPF = CPFTextBox.Text;
            funcionario.Nome = NomeTextBox.Text;
            funcionario.RG = RGTextBox.Text;
            funcionario.Telefone = TelefoneTextBox.Text;
            funcionario.Email = EmailTextBox.Text;
            funcionario.Endereco = new Endereco()
            {
                Rua = RuaTextBox.Text,
                CEP = CEPTextBox.Text,
                Bairro = BairroTextBox.Text,
                Cidade = CidadeTextBox.Text,
                Numero = NumeroTextBox.Text,
                UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString())
            };
            return funcionario;
        }

        private Permissoes GerarPermissoes()
        {
            Permissoes permissoes = new Permissoes();

            permissoes.Clientes = GerarFuncao(ConsultarClientesCheckBox.IsChecked, CadastrarClientesCheckBox.IsChecked, AlterarClientesCheckBox.IsChecked, RemoverClientesCheckBox.IsChecked);
            permissoes.Financeiro = GerarFuncao(ConsultarFinancaCheckBox.IsChecked, CadastrarFinancaCheckBox.IsChecked, AlterarFinancaCheckBox.IsChecked, RemoverFinancaCheckBox.IsChecked);
            permissoes.Funcionarios = GerarFuncao(ConsultarUsuarioCheckBox.IsChecked, CadastrarUsuarioCheckBox.IsChecked, AlterarUsuarioCheckBox.IsChecked, RemoverUsuarioCheckBox.IsChecked);
            permissoes.Garagens = GerarFuncao(ConsultarGaragensCheckBox.IsChecked, CadastrarGaragensCheckBox.IsChecked, AlterarGaragensCheckBox.IsChecked, RemoverGaragensCheckBox.IsChecked);
            permissoes.Locacoes = GerarFuncao(ConsultarLocacaoCheckBox.IsChecked, CadastrarLocacaoCheckBox.IsChecked, AlterarLocacaoCheckBox.IsChecked, RemoverLocacaoCheckBox.IsChecked);
            permissoes.Manutencoes = GerarFuncao(ConsultarManutencaoCheckBox.IsChecked, CadastrarManutencaoCheckBox.IsChecked, AlterarManutencaoCheckBox.IsChecked, RemoverManutencaoCheckBox.IsChecked);
            permissoes.Motoristas = GerarFuncao(ConsultarMotoristasCheckBox.IsChecked, CadastrarMotoristasCheckBox.IsChecked, AlterarMotoristasCheckBox.IsChecked, RemoverMotoristasCheckBox.IsChecked);
            permissoes.MultasSinistros = GerarFuncao(ConsultarMultaSinisCheckBox.IsChecked, CadastrarMultaSinisCheckBox.IsChecked, AlterarMultaSinisCheckBox.IsChecked, RemoverMultaSinisCheckBox.IsChecked);
            permissoes.Relatorios = GerarFuncao(ConsultarRelatorioCheckBox.IsChecked, CadastrarRelatorioCheckBox.IsChecked, AlterarRelatorioCheckBox.IsChecked, RemoverRelatorioCheckBox.IsChecked);
            permissoes.Seguros = GerarFuncao(ConsultarSeguroCheckBox.IsChecked, CadastrarSeguroCheckBox.IsChecked, AlterarSeguroCheckBox.IsChecked, RemoverSeguroCheckBox.IsChecked);
            permissoes.Solicitacoes = GerarFuncao(ConsultarSolicitacaoCheckBox.IsChecked, CadastrarSolicitacaoCheckBox.IsChecked, AlterarSolicitacaoCheckBox.IsChecked, RemoverSolicitacaoCheckBox.IsChecked);
            permissoes.Veiculos = GerarFuncao(ConsultarVeiculosCheck.IsChecked, CadastrarVeiculosCheck.IsChecked, AlterarVeiculosCheck.IsChecked, RemoverVeiculosCheck.IsChecked);
            permissoes.Viagens = GerarFuncao(ConsultarViagemCheckBox.IsChecked, CadastrarViagemCheckBox.IsChecked, AlterarViagemCheckBox.IsChecked, RemoverViagemCheckBox.IsChecked);
            return permissoes;
        }

        private Funcoes GerarFuncao(bool? consultar, bool? cadastrar, bool? alterar, bool? remover)
        {
            return new Funcoes()
            {
                Consultar = ConversorBoolNullable.ConversorBooleano(consultar),
                Alterar = ConversorBoolNullable.ConversorBooleano(alterar),
                Cadastrar = ConversorBoolNullable.ConversorBooleano(cadastrar),
                Remover = ConversorBoolNullable.ConversorBooleano(remover)
            };
        }

    }
}
