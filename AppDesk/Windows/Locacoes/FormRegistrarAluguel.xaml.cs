using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Clientes;
using AppDesk.Windows.Veiculos;
using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
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

namespace AppDesk.Windows.Locacoes
{
    /// <summary>
    /// Lógica interna para FormRegistrarAluguel.xaml
    /// </summary>
    public partial class FormRegistrarAluguel : Window
    {
        private Veiculo _veiculoSelecionado = null;
        private Cliente _clienteSelecionado = null;

        public FormRegistrarAluguel()
        {
            InitializeComponent();
            VeiculosDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().Where(v => v.ParaLocacao == true).Where(v => v.ClienteId == null).ToList();
            ClientesDataGrid.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(c => c.Ativo == true).ToList();
            DataContratacaoDatePicker.SelectedDate = DateTime.Today;
        }

        private void SelecionarVeiculo(Veiculo veiculo)
        {
            _veiculoSelecionado = veiculo;
            VeiculoTabItem.DataContext = _veiculoSelecionado;
            MessageBox.Show("Veiculo Selecionado com sucesso!");
        }

        private void SelecionarCliente(Cliente cliente)
        {
            _clienteSelecionado = cliente;
            ClienteTabItem.DataContext = _clienteSelecionado;
            MessageBox.Show("Cliente Selecionado com sucesso!");
        }

        private Aluguel GerarAluguel()
        {
            Aluguel aluguel = new Aluguel();
            aluguel.DataContratacao = DataContratacaoDatePicker.DisplayDate;
            aluguel.DataVencimento = DataVencimentoDatePicker.DisplayDate;
            
            if (AguardandoPagamentoRadioBtn.IsChecked == true)
            {
                aluguel.EstadoDoPagamento = EstadosDePagamento.AGUARDANDO;
            }
            else if (PagoRadioBtn.IsChecked == true)
            {
                aluguel.EstadoDoPagamento = EstadosDePagamento.PAGO;
            }
            else
            {
                MessageBox.Show("Selecione o estado do pagamento!");
                return null;
            }
            
            aluguel.EstadoDoAluguel = EstadosAluguel.REGULAR;
            
            if(_veiculoSelecionado != null)
            {
                aluguel.VeiculoId = _veiculoSelecionado.VeiculoId;
            }
            else
            {
                MessageBox.Show("Selecione o veiculo!");
                return null;
            }
            
            if(_clienteSelecionado != null)
            {
                aluguel.ClienteId = _clienteSelecionado.ClienteId;
            }
            else
            {
                MessageBox.Show("Selecione o cliente!");
                return null;
            }

            return aluguel;
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Registrar aluguel?", "Confirmar Registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Aluguel aluguel = GerarAluguel();
                if(aluguel != null)
                {
                    ServicoDados.ServicoDadosAluguel.GravarAluguel(aluguel);
                    MessageBox.Show("Aluguel registrado com sucesso!");
                    MainWindowUpdater.UpdateDataGrids();
                    this.Close();
                }
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelecionarVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarVeiculo(VeiculosDataGrid.SelectedItem as Veiculo);
        }

        private void SelecionarClienteBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(ClientesDataGrid.SelectedItem as Cliente);
        }

        private void DetalhesVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            FormDetalhesVeiculo formDetalhesVeiculo = new FormDetalhesVeiculo(
                ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId((VeiculosDataGrid.SelectedItem as Veiculo).VeiculoId)
                );
            formDetalhesVeiculo.Show();
        }

        private void DetalhesClienteBtn_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = ClientesDataGrid.SelectedItem as Cliente;
            FormDetalhesCliente formDetalhesCliente = null;
            if (cliente is ClientePF)
            {
                formDetalhesCliente = new FormDetalhesCliente(
                    ServicoDados.ServicoDadosClientes.ObterClientePFPorId(cliente.ClienteId)
                    );
            }
            else if (cliente is ClientePJ)
            {
                formDetalhesCliente = new FormDetalhesCliente(
                    ServicoDados.ServicoDadosClientes.ObterClientePJPorId(cliente.ClienteId)
                    );
            }

            formDetalhesCliente.Show();
        }

        private void PesquisarVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorPlaca(PesquisarPlacaVeiculoTextBox.Text);
            if (veiculo != null)
            {
                MessageBoxResult result = MessageBox.Show("Veiculo encontrado! Deseja selecioná-lo agora?", "Veiculo Encontrado!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SelecionarVeiculo(veiculo);
                }
            }
            else
            {
                MessageBox.Show("Veiculo não encontrado!");
            }
        }

        private void PesquisarClienteBtn_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = null;

            if (PFRadioBtn.IsChecked == true)
            {
                cliente = ServicoDados.ServicoDadosClientes.ObterClientePorCPFCNPJ(PesquisarCPFClienteTextBox.Text, TipoCliente.PF);
            }
            else if (PJRadioBtn.IsChecked == true)
            {
                cliente = ServicoDados.ServicoDadosClientes.ObterClientePorCPFCNPJ(PesquisarCPFClienteTextBox.Text, TipoCliente.PJ);
            }
            else
            {
                MessageBox.Show("Selecione o tipo de cliente para pesquisar!");
            }

            if (cliente != null)
            {
                MessageBoxResult result = MessageBox.Show("Cliente encontrado! Deseja selecioná-lo agora?", "Cliente Selecionado!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SelecionarCliente(cliente);
                }
            }
            else
            {
                MessageBox.Show("Cliente não encontrado!");
            }
        }
    }
}
