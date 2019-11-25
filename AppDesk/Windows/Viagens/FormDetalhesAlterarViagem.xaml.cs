using AppDesk.Interfaces;
using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Motoristas;
using AppDesk.Windows.Veiculos;
using Modelo.Classes.Web;
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

namespace AppDesk.Windows.Viagens
{
    /// <summary>
    /// Lógica interna para FormDetalhesAlterarViagem.xaml
    /// </summary>
    public partial class FormDetalhesAlterarViagem : Window, IFillTextBoxes
    {
        private Viagem _viagem = null;

        private FormDetalhesAlterarViagem()
        {
            InitializeComponent();
        }

        public FormDetalhesAlterarViagem(Viagem viagem) : this()
        {
            _viagem = viagem;
            this.DataContext = _viagem;
            PreencherTextBoxes();

            if (!DesktopLoginControlService._Usuario.Permissoes.Viagens.Alterar)
            {
                CancelarViagemBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Viagens.Remover)
            {
                RemoverViagemBtn.IsEnabled = false;
            }
        }

        private void CancelarViagemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.MensagemCancelamento("Viagem") == MessageBoxResult.Yes)
                {
                    _viagem.EstadoDaViagem = Modelo.Enums.EstadosDeViagem.CANCELADA;
                    _viagem.DataChegada = DateTime.Now;
                    EstadoViagemTextBox.Text = _viagem.EstadoDaViagem.ToString("G").Replace('_', ' ');
                    ServicoDados.ServicoDadosViagem.GravarViagem(_viagem);
                    StandardMessageBoxes.MensagemSucesso("Viagem cancelada com sucesso!", "Cancelamento");
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
                if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Viagem") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosViagem.RemoverViagemPorId(_viagem.ViagemId);
                    StandardMessageBoxes.MensagemSucesso("Viagem removida com sucesso!", "Remoção");
                    MainWindowUpdater.UpdateDataGrids();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PreencherTextBoxes()
        {
            TipoVeiculoTextBox.Text = _viagem.Veiculo.Tipo.ToString("G").Replace('_', ' ');
            EstadoViagemTextBox.Text = _viagem.EstadoDaViagem.ToString("G").Replace('_', ' ');
            CNPJGaragemUC.Text = _viagem.GaragemRetorno.CNPJ;
            GaragemRetornoEndereco.Text = _viagem.GaragemRetorno.EnderecoCompleto;
            NomeUC.Text = _viagem.Motorista.Nome;
            TelefoneUC.Text = _viagem.Motorista.Celular;
            PlacaUC.Text = _viagem.Veiculo.Placa;
            ModeloUC.Text = _viagem.Veiculo.Modelo;
            MarcaUC.Text = _viagem.Veiculo.Marca;
            QntPassageirosUC.Value = _viagem.QuantidadePassageiros;
            EnderecoOrigemUC.Endereco = _viagem.EnderecoOrigem;
            EnderecoDestinoUC.Endereco = _viagem.EnderecoDestino;

            DataSaidaUC.Date = _viagem.DataSaida;

            switch (_viagem.EstadoDaViagem)
            {
                case Modelo.Enums.EstadosDeViagem.CONCLUIDA:
                    DataChegadaUC.Date = _viagem.DataChegada.GetValueOrDefault();
                    DataChegadaUC.Visibility = Visibility.Visible;
                    break;
                case Modelo.Enums.EstadosDeViagem.CANCELADA:
                    DataCancelamentoUC.Date = _viagem.DataChegada.GetValueOrDefault();
                    DataCancelamentoUC.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void DetalhesMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            Motorista motorista = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId(_viagem.MotoristaId);
            FormDetalhesMotorista formDetalhesMotorista = new FormDetalhesMotorista(motorista);
            formDetalhesMotorista.ShowDialog();
        }

        private void DetalhesVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId(_viagem.VeiculoId);
            FormDetalhesVeiculo FormDetalhesVeiculo = new FormDetalhesVeiculo(veiculo);
            FormDetalhesVeiculo.ShowDialog();
        }
    }
}
