using AppDesk.Serviço;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Clientes;
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

namespace AppDesk.Windows.Clientes
{
    /// <summary>
    /// Lógica interna para FormAlterarClientes.xaml
    /// </summary>
    public partial class FormAlterarClientes : Window
    {
        private ClientePF _clientePF = null;
        private ClientePJ _clientePJ = null;

        public FormAlterarClientes()
        {
            InitializeComponent();
        }

        public FormAlterarClientes(Cliente cliente) : this()
        {
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));

            if (cliente is ClientePF)
            {
                _clientePF = cliente as ClientePF;
                CPF_CNPJ_Label.Content = "CPF";
            }
            if (cliente is ClientePJ)
            {
                _clientePJ = cliente as ClientePJ;
                CPF_CNPJ_Label.Content = "CNPJ";
            }

            if (cliente.Ativo)
            {
                AtivoRadioBtn.IsChecked = true;
            }
            else
            {
                InativoRadioBtn.IsChecked = true;
            }

            PreencherTextBoxes(cliente);
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            Cliente clienteAlterado = AlterarCliente();
            if (clienteAlterado != null)
            {
                ServicoDados.ServicoDadosClientes.RegistrarCliente(clienteAlterado);
                MessageBox.Show("Cliente alterado com sucesso!");
                MainWindow window = Application.Current.Windows.OfType<MainWindow>().First();
                window.PopulateDataGrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha ao alterar cliente");
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreencherTextBoxes(Cliente cliente)
        {
            NomeTextBox.Text = cliente.Nome;
            EmailTextBox.Text = cliente.Email;
            TelefoneTextBox.Text = cliente.Telefone;
            RuaTextBox.Text = cliente.Endereco.Rua;
            NumeroTextBox.Text = cliente.Endereco.Numero;
            CidadeTextBox.Text = cliente.Endereco.Cidade;
            CEPTextBox.Text = cliente.Endereco.CEP;
            BairroTextBox.Text = cliente.Endereco.Bairro;
            UfComboBox.SelectedItem = cliente.Endereco.UF.ToString();

            if (cliente is ClientePF)
            {
                CPFCNPJTextBox.Text = (cliente as ClientePF).CPF;
            }
            else if (cliente is ClientePJ)
            {
                CPFCNPJTextBox.Text = (cliente as ClientePJ).CNPJ;
            }
        }

        private Cliente AlterarCliente()
        {
            bool ativoInativo = true;
            if (AtivoRadioBtn.IsChecked == true)
            {
                ativoInativo = true;
            }
            else if (InativoRadioBtn.IsChecked == true)
            {
                ativoInativo = false;
            }

            if (_clientePF != null)
            {
                _clientePF.Ativo = ativoInativo;
                _clientePF.Nome = NomeTextBox.Text;
                _clientePF.CPF = CPFCNPJTextBox.Text;
                _clientePF.Email = EmailTextBox.Text;
                _clientePF.Telefone = TelefoneTextBox.Text;
                _clientePF.Endereco.Rua = RuaTextBox.Text;
                _clientePF.Endereco.Bairro = BairroTextBox.Text;
                _clientePF.Endereco.CEP = CEPTextBox.Text;
                _clientePF.Endereco.Cidade = CidadeTextBox.Text;
                _clientePF.Endereco.Numero = NumeroTextBox.Text;
                _clientePF.Endereco.UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString());

                return _clientePF;
            }
            else if (_clientePJ != null)
            {
                _clientePJ.Ativo = ativoInativo;
                _clientePJ.Nome = NomeTextBox.Text;
                _clientePJ.CNPJ = CPFCNPJTextBox.Text;
                _clientePJ.Email = EmailTextBox.Text;
                _clientePJ.Telefone = TelefoneTextBox.Text;
                _clientePJ.Endereco.Rua = RuaTextBox.Text;
                _clientePJ.Endereco.Bairro = BairroTextBox.Text;
                _clientePJ.Endereco.CEP = CEPTextBox.Text;
                _clientePJ.Endereco.Cidade = CidadeTextBox.Text;
                _clientePJ.Endereco.Numero = NumeroTextBox.Text;
                _clientePJ.Endereco.UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString());

                return _clientePJ;
            }
            else
            {
                MessageBox.Show("Erro ao alterar cliente!");
                return null;
            }
}
    }
}
