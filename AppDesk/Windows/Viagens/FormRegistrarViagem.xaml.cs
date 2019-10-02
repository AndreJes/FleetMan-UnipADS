using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Auxiliares;
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

namespace AppDesk.Windows.Viagens
{
    /// <summary>
    /// Lógica interna para FormRegistrarViagem.xaml
    /// </summary>
    public partial class FormRegistrarViagem : Window
    {
        private Motorista _motoristaSelecionado = null;
        private Veiculo _veiculoSelecionado = null;

        public FormRegistrarViagem()
        {
            InitializeComponent();

            UFGaragemRetornoComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
            UfDestinoComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));

            VeiculoSelecionadoTextBox.DataContext = _veiculoSelecionado;
            MotoristaSelecionadoTextBox.DataContext = _motoristaSelecionado;

            VeiculosDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId()
                .Where(v => v.EstadoDoVeiculo == EstadosDeVeiculo.NORMAL || v.EstadoDoVeiculo == EstadosDeVeiculo.ALUGADO)
                .ToList();

            MotoristasDataGrid.ItemsSource = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId()
                .Where(m => m.Estado == EstadosDeMotorista.REGULAR)
                .ToList();
        }

        #region Cancelar/Registrar
        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirmar registro de viagem?", "Confirmar registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosViagem.GravarViagem(GerarViagem());
                MessageBox.Show("Viagem registrada com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        #endregion
        #region Seleçao/Pesquisa
        private void SelecionarMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarMotorista(MotoristasDataGrid.SelectedItem as Motorista);
        }

        private void PesquisarMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            Motorista motorista = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorCPF(PesquisarMotoristaTextBox.Text);
            if (motorista != null)
            {
                MessageBoxResult result = MessageBox.Show("Motorista encontrado. Deseja selecioná-lo(a) agora?", "Motorista encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SelecionarMotorista(motorista);
                    MessageBox.Show("Motorista selecionado!");
                }
            }
            else
            {
                MessageBox.Show("Motorista não encontrado!");
            }
        }

        private void SelecionarVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarVeiculo(VeiculosDataGrid.SelectedItem as Veiculo);
        }

        private void PesquisarPlacaVeiculo_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorPlaca(PesquisarVeiculoTextBox.Text);
            if (veiculo != null)
            {
                MessageBoxResult result = MessageBox.Show("Veiculo encontrado. Deseja selecioná-lo agora?", "Veiculo encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SelecionarVeiculo(veiculo);
                    MessageBox.Show("Veiculo selecionado!");
                }
            }
            else
            {
                MessageBox.Show("Veiculo não encontrado!");
            }
        }
        #endregion
        #region SelecionarGaragem
        private void UFGaragemRetornoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GaragemRetornoComboBox.ItemsSource = ServicoDados.ServicoDadosGaragem.ObterGaragensOrdPorId()
                .Where(g => g.Endereco.UF == (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UFGaragemRetornoComboBox.SelectedItem.ToString()))
                .ToList();
        }

        private void GaragemRetornoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GaragemEnderecoTextBox.Text = (GaragemRetornoComboBox.SelectedItem as Modelo.Classes.Desk.Garagem).EnderecoCompleto;
        }
        #endregion

        private void SelecionarVeiculo(Veiculo veiculo)
        {
            _veiculoSelecionado = ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId(veiculo.VeiculoId);
            VeiculoSelecionadoTextBox.DataContext = _veiculoSelecionado;
            EnderecoOrigemGroupBox.DataContext = _veiculoSelecionado.Garagem.Endereco;
        }

        private void SelecionarMotorista(Motorista motorista)
        {
            _motoristaSelecionado = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId(motorista.MotoristaId);
            MotoristaSelecionadoTextBox.DataContext = _motoristaSelecionado;
        }

        private Viagem GerarViagem()
        {
            Viagem viagem = new Viagem();

            viagem.MotoristaId = _motoristaSelecionado.MotoristaId;
            viagem.VeiculoId = _veiculoSelecionado.VeiculoId;
            viagem.EnderecoOrigem = _veiculoSelecionado.Garagem.Endereco;
            viagem.EnderecoDestino = new Endereco()
            {
                Rua = RuaDestinoTextBox.Text,
                CEP = CEPDestinoTextBox.Text,
                Numero = NumeroDestinoTextBox.Text,
                Cidade = CidadeDestinoTextBox.Text,
                Bairro = BairroDestinoTextBox.Text,
                UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfDestinoComboBox.SelectedItem.ToString())
            };
            viagem.GaragemOrigemId = _veiculoSelecionado.Garagem.GaragemId;
            viagem.GaragemRetornoId = (GaragemRetornoComboBox.SelectedItem as Modelo.Classes.Desk.Garagem).GaragemId;
            viagem.DataSaida = DataSaidaDatePicker.DisplayDate;
            viagem.DataChegada = null;
            viagem.QuantidadePassageiros = int.Parse(QuantidadeDePassageirosTextBox.Text);

            return viagem;
    }
}
}
