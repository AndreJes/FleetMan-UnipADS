using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Clientes;
using Modelo.Classes.Clientes;
using Modelo.Enums;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para SelecionarClienteUC.xam
    /// </summary>
    public partial class SelecionarClienteUC : UserControl, INotifyPropertyChanged
    {
        private Cliente _cliente;

        public event PropertyChangedEventHandler PropertyChanged;

        public Cliente Cliente
        {
            get
            {
                if (_cliente != null)
                {
                    return _cliente;
                }
                else
                {
                    throw new FieldException("Cliente");
                }
            }
            private set
            {
                _cliente = value;
                NotifyPropertyChanged();
            }
        }
        public TipoCliente Tipo
        {
            get
            {
                if (PFRadioBtn.IsChecked == true)
                {
                    return TipoCliente.PF;
                }
                else if (PJRadioBtn.IsChecked == true)
                {
                    return TipoCliente.PJ;
                }
                else
                {
                    throw new FieldException("Tipo de cliente");
                }
            }
        }

        public SelecionarClienteUC()
        {
            InitializeComponent();
            DataContext = this;
            ClientesDataGrid.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(c => c.Ativo == true).ToList();
        }

        private void PesquisarClienteBtn_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = null;

            if (PFRadioBtn.IsChecked == true)
            {
                cliente = ServicoDados.ServicoDadosClientes.ObterClientePorCPFCNPJ(PesquisarCPFClienteTextBox.Text.Replace(".", "").Replace("-", ""), TipoCliente.PF);
            }
            else if (PJRadioBtn.IsChecked == true)
            {
                cliente = ServicoDados.ServicoDadosClientes.ObterClientePorCPFCNPJ(PesquisarCNPJClienteTextBox.Text.Replace(".", "").Replace("/", "").Replace("-", ""), TipoCliente.PJ);
            }
            else
            {
                StandardMessageBoxes.MensagemDeErro("Selecione o tipo de cliente para pesquisar!");
            }

            if (cliente != null)
            {
                MessageBox.Show("Cliente Encontrado!");
                if (StandardMessageBoxes.MensagemSelecao("cliente") == MessageBoxResult.Yes)
                {
                    Cliente = cliente;
                }
            }
            else
            {
                MessageBox.Show("Cliente não encontrado!");
            }
        }

        private void DetalhesClienteBtn_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = ClientesDataGrid.SelectedItem as Cliente;
            FormAlterarClientes formDetalhesCliente = null;
            if (cliente is ClientePF)
            {
                formDetalhesCliente = new FormAlterarClientes(
                    ServicoDados.ServicoDadosClientes.ObterClientePFPorId(cliente.ClienteId)
                    );
            }
            else if (cliente is ClientePJ)
            {
                formDetalhesCliente = new FormAlterarClientes(
                    ServicoDados.ServicoDadosClientes.ObterClientePJPorId(cliente.ClienteId)
                    );
            }

            formDetalhesCliente.Show();
        }

        private void SelecionarClienteBtn_Click(object sender, RoutedEventArgs e)
        {
            Cliente = ClientesDataGrid.SelectedItem as Cliente;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PFRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            PesquisarCPFClienteTextBox.Visibility = Visibility.Visible;
            PesquisarCNPJClienteTextBox.Visibility = Visibility.Collapsed;

        }

        private void PJRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            PesquisarCNPJClienteTextBox.Visibility = Visibility.Visible;
            PesquisarCPFClienteTextBox.Visibility = Visibility.Collapsed;
        }
    }
}
