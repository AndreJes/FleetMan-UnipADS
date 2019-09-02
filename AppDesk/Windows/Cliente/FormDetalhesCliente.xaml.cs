using AppDesk.Serviço;
using Modelo.Classes.Clientes;
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
    /// Lógica interna para FormDetalhesCliente.xaml
    /// </summary>
    public partial class FormDetalhesCliente : Window
    {
        private ClientePF _clientePF = null;
        private ClientePJ _clientePJ = null;

        #region Construtores
        private FormDetalhesCliente()
        {
            InitializeComponent();
            
        }

        //Construtor para cliente PF
        public FormDetalhesCliente(ClientePF clientePF) : this()
        {
            CPF_CNPJ_Label.Content = "CPF";
            CPFCNPJTextBox.Text = clientePF.CPFTxt;
            _clientePF = clientePF;
            PreencherTextBoxes(_clientePF);
        }

        //Construtor para cliente PJ
        public FormDetalhesCliente(ClientePJ clientePJ) : this()
        {
            CPF_CNPJ_Label.Content = "CNPJ";
            CPFCNPJTextBox.Text = clientePJ.CNPJTxt;
            _clientePJ = clientePJ;
            PreencherTextBoxes(_clientePJ);
        }
        #endregion

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
            UfTextBox.Text = cliente.Endereco.UF.ToString("G");

            QuantidadeDeVeiculos.Content = cliente.Veiculos.ToList().Count.ToString();
            QuantidadeDeMotoristas.Content = cliente.Motoristas.ToList().Count.ToString();
            QuantidadeDeLocacoes.Content = cliente.Alugueis.ToList().Count.ToString();
        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            FormAlterarClientes formAlteracao = null;

            if (_clientePF != null)
            {
                formAlteracao = new FormAlterarClientes(_clientePF);
                formAlteracao.Show();
                this.Close();
            }
            else if(_clientePJ != null)
            {
                formAlteracao = new FormAlterarClientes(_clientePJ);
                formAlteracao.Show();
                this.Close();
            }
            
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_clientePF != null)
            {
                ServicoDados.ServicoDadosClientes.RemoverClientePorId(_clientePF.ClienteId);
            }
            else if( _clientePJ != null)
            {
                ServicoDados.ServicoDadosClientes.RemoverClientePorId(_clientePJ.ClienteId);
            }
            else
            {
                MessageBox.Show("Não foi possivel fazer a remoção");
                return;
            }

            MessageBox.Show("Cliente removido com sucesso");
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().First();
            main.PopulateDataGrid();
            this.Close();
        }
    }
}
