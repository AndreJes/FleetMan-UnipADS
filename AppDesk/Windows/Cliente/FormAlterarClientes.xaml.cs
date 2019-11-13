using AppDesk.Interfaces;
using AppDesk.Serviço;
using AppDesk.Tools;
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
    public partial class FormAlterarClientes : Window, IFillTextBoxes
    {
        private ClientePF _clientePF = null;
        private ClientePJ _clientePJ = null;

        public FormAlterarClientes()
        {
            InitializeComponent();
        }

        public FormAlterarClientes(Cliente cliente) : this()
        {
            VehicleDataGrid.ItemsSource = cliente.Veiculos;
            MotoristasDataGrid.ItemsSource = cliente.Motoristas;
            LocacoesDataGrid.ItemsSource = cliente.Alugueis;
            EnderecoUC.Editavel = true;
            if (cliente is ClientePF)
            {
                _clientePF = cliente as ClientePF;
                CPFUC.Text = _clientePF.CPF;
                CPFUC.Visibility = Visibility.Visible;
            }
            if (cliente is ClientePJ)
            {
                _clientePJ = cliente as ClientePJ;
                CNPJUC.Text = _clientePJ.CNPJ;
                CNPJUC.Visibility = Visibility.Visible;
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
                ServicoDados.ServicoDadosClientes.GravarCliente(clienteAlterado);
                StandardMessageBoxes.MensagemSucesso("Cliente", "Alterado");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
            else
            {
                StandardMessageBoxes.MensagemDeErro("Falha ao alterar cliente");
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreencherTextBoxes(Cliente cliente)
        {
            NomeUC.Text = cliente.Nome;
            EmailUC.Text = cliente.Email;
            TelefoneUC.Text = cliente.Telefone;
            EnderecoUC.Endereco = cliente.Endereco;
            if (cliente is ClientePF)
            {
                CNPJUC.Text = (cliente as ClientePF).CPF;
            }
            else if (cliente is ClientePJ)
            {
                CNPJUC.Text = (cliente as ClientePJ).CNPJ;
            }
        }

        private Cliente AlterarCliente()
        {
            try
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
                    _clientePF.Nome = NomeUC.Text;
                    _clientePF.CPF = CPFUC.Text;
                    _clientePF.Email = EmailUC.Text;
                    _clientePF.Telefone = TelefoneUC.Text;
                    _clientePF.Endereco = EnderecoUC.Endereco;
                    return _clientePF;
                }
                else if (_clientePJ != null)
                {
                    _clientePJ.Ativo = ativoInativo;
                    _clientePJ.Nome = NomeUC.Text;
                    _clientePJ.CNPJ = CNPJUC.Text;
                    _clientePJ.Email = EmailUC.Text;
                    _clientePJ.Telefone = TelefoneUC.Text;
                    _clientePJ.Endereco = EnderecoUC.Endereco;
                    return _clientePJ;
                }
                return null;
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
                return null;
            }
        }

        private void DetalhesVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AluguelDetailsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MotoristaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
