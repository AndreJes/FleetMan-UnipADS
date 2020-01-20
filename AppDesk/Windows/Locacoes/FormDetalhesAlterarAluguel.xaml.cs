using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Clientes;
using AppDesk.Windows.Veiculos;
using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Windows;

namespace AppDesk.Windows.Locacoes
{
    /// <summary>
    /// Lógica interna para FormDetalhesAlterarAluguel.xaml
    /// </summary>
    public partial class FormDetalhesAlterarAluguel : Window
    {
        private Aluguel _aluguel = null;

        private FormDetalhesAlterarAluguel()
        {
            InitializeComponent();
        }

        public FormDetalhesAlterarAluguel(Aluguel aluguel) : this()
        {
            _aluguel = aluguel;
            PreencherCampos();

            if (!DesktopLoginControlService._Usuario.Permissoes.Locacoes.Alterar)
            {
                CancelarLocacaoBtn.IsEnabled = false;
                SalvarPagamentoBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Locacoes.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void PreencherCampos()
        {
            switch (_aluguel.EstadoDoPagamento)
            {
                case EstadosDePagamento.PAGO:
                    PagoRadioBtn.IsChecked = true;
                    break;
                case EstadosDePagamento.VENCIDO:
                    VencidoRadioBtn.IsChecked = true;
                    break;
                case EstadosDePagamento.AGUARDANDO:
                    AguardandoPagamentoRadioBtn.IsChecked = true;
                    break;
                default:
                    break;
            }

            NomeClienteTextBox.Text = _aluguel.Cliente.Nome;
            NomeVeiculoTextBox.Text = _aluguel.Veiculo.Marca + " " + _aluguel.Veiculo.Modelo + " " + _aluguel.Veiculo.Ano.ToString();

            if (_aluguel.Cliente is ClientePF)
            {
                CPFTextBox.Text = (_aluguel.Cliente as ClientePF).CPFTxt;
                CPFTextBox.Visibility = Visibility.Visible;
            }
            else if (_aluguel.Cliente is ClientePJ)
            {
                CNPJTextBox.Text = (_aluguel.Cliente as ClientePJ).CNPJTxt;
                CNPJTextBox.Visibility = Visibility.Visible;
            }

            DataContratacaoUC.Date = _aluguel.DataContratacao;
            DataVencimentoUC.Date = _aluguel.DataVencimento;

            PlacaVeiculoTextBox.Text = _aluguel.Veiculo.Placa;

            this.DataContext = _aluguel;
        }

        private void DetalhesVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            FormDetalhesVeiculo formDetalhesVeiculo = new FormDetalhesVeiculo(ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId(_aluguel.VeiculoId));
            formDetalhesVeiculo.Show();
        }

        private void DetalhesClienteBtn_Click(object sender, RoutedEventArgs e)
        {
            FormAlterarClientes formDetalhesCliente = null;
            if (_aluguel.Cliente is ClientePF)
            {
                formDetalhesCliente = new FormAlterarClientes(ServicoDados.ServicoDadosClientes.ObterClientePFPorId(_aluguel.ClienteId));
            }
            else if (_aluguel.Cliente is ClientePJ)
            {
                formDetalhesCliente = new FormAlterarClientes(ServicoDados.ServicoDadosClientes.ObterClientePJPorId(_aluguel.ClienteId));
            }
            formDetalhesCliente.Show();
        }

        private void CancelarLocacaoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.MensagemAlerta("Cancelar locação?", "Atenção está ação não podera ser desfeita") == MessageBoxResult.Yes)
                {
                    _aluguel.EstadoDoAluguel = EstadosAluguel.CANCELADO;
                    ServicoDados.ServicoDadosAluguel.GravarAluguel(_aluguel);
                    MessageBox.Show("Locação cancelada com sucesso!");
                    MainWindowUpdater.UpdateDataGrids();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Locação") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosAluguel.RemoverAluguelPorId(_aluguel.AluguelId);
                    StandardMessageBoxes.MensagemSucesso("Locação removida com sucesso", "Remoção");
                    MainWindowUpdater.UpdateDataGrids();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void SalvarPagamentoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AguardandoPagamentoRadioBtn.IsChecked == true)
                {
                    _aluguel.EstadoDoPagamento = EstadosDePagamento.AGUARDANDO;
                }
                else if (PagoRadioBtn.IsChecked == true)
                {
                    _aluguel.EstadoDoPagamento = EstadosDePagamento.PAGO;
                }
                else if (VencidoRadioBtn.IsChecked == true)
                {
                    _aluguel.EstadoDoPagamento = EstadosDePagamento.VENCIDO;
                }
                ServicoDados.ServicoDadosAluguel.GravarAluguel(_aluguel);
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void PagamentoCheckChanged_Event(object sender, RoutedEventArgs e)
        {
            if (DesktopLoginControlService._Usuario.Permissoes.Locacoes.Alterar)
            {
                if (AguardandoPagamentoRadioBtn.IsChecked == true && _aluguel.EstadoDoPagamento != EstadosDePagamento.AGUARDANDO)
                {
                    SalvarPagamentoBtn.IsEnabled = true;
                }
                else if (PagoRadioBtn.IsChecked == true && _aluguel.EstadoDoPagamento != EstadosDePagamento.PAGO)
                {
                    SalvarPagamentoBtn.IsEnabled = true;
                }
                else if (VencidoRadioBtn.IsChecked == true && _aluguel.EstadoDoPagamento != EstadosDePagamento.VENCIDO)
                {
                    SalvarPagamentoBtn.IsEnabled = true;
                }
                else
                {
                    SalvarPagamentoBtn.IsEnabled = false;
                }
            }
        }
    }
}
