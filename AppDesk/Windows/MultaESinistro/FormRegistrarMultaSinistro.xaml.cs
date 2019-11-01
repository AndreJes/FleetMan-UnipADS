using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Desk;
using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace AppDesk.Windows.MultaESinistro
{
    /// <summary>
    /// Lógica interna para FormRegistrarMultaSinistro.xaml
    /// </summary>
    public partial class FormRegistrarMultaSinistro : Window
    {
        private Veiculo _veiculoPMulta = null;
        private Veiculo _veiculoPSinistro = null;
        private Motorista _motoristaPMulta = null;
        private Motorista _motoristaPSinistro = null;

        public FormRegistrarMultaSinistro()
        {
            InitializeComponent();
            PopularComboBoxes();
            PopularDataGrids();
        }

        #region Eventos
        private void SelecionarMotoristaMultaBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarMotorista(MotoristaParaMultaDataGrid.SelectedItem as Motorista, pMulta: true);
        }

        private void SelecionarVeiculoMultaBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarVeiculo(VeiculosParaMultasDataGrid.SelectedItem as Veiculo, pMulta: true);
        }

        private void PesquisarPlacaVeiculoPMulta_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = PesquisarVeiculo(PesquisarVeiculoPMultaTextBox.Text);

            if(veiculo == null)
            {
                MessageBox.Show("Veiculo não encontrado!");
            }
            else if(veiculo != null)
            {
                MessageBoxResult result = MessageBox.Show("Veiculo encontrado! Deseja selecionar esse veiculo?", "Veiculo encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    SelecionarVeiculo(veiculo, pMulta: true);
                }
            }
        }

        private void PesquisarMotoristaPMultaBtn_Click(object sender, RoutedEventArgs e)
        {
            Motorista motorista = PesquisarMotorista(PesquisarMotoristaPMultaTextBox.Text);

            if(motorista == null)
            {
                MessageBox.Show("Motorista não encontrado!");
            }
            else if (motorista != null)
            {
                MessageBoxResult result = MessageBox.Show("Motorista encontrado! Deseja selecionar esse motorista?", "Motorista encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    SelecionarMotorista(motorista, pMulta: true);
                }
            }
        }

        private void RegistrarMultaBtn_Click(object sender, RoutedEventArgs e)
        {
            Multa multa = GerarMulta();

            MessageBoxResult result = MessageBox.Show("Confirmar registro de nova multa?", "Confirmar registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosMulta.GravarMulta(multa);
                MainWindowUpdater.UpdateDataGrids();
                MessageBox.Show("Multa registrada com sucesso!");
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrarSinistroBtn_Click(object sender, RoutedEventArgs e)
        {
            Sinistro sinistro = GerarSinistro();

            MessageBoxResult result = MessageBox.Show("Confirmar registro de novo sinistro?", "Confirmar registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosSinistro.GravarSinistro(sinistro);
                MainWindowUpdater.UpdateDataGrids();
                MessageBox.Show("Sinistro registrado com sucesso!");
                this.Close();
            }
        }

        private void SelecionarVeiculoPSinistroBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarVeiculo(VeiculosParaSinistrosDataGrid.SelectedItem as Veiculo, pSinistro: true);
        }

        private void PesquisarVeiculoPSinistroBtn_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = PesquisarVeiculo(PesquisarVeiculoPSinistroTextBox.Text);

            if (veiculo == null)
            {
                MessageBox.Show("Veiculo não encontrado!");
            }
            else if (veiculo != null)
            {
                MessageBoxResult result = MessageBox.Show("Veiculo encontrado! Deseja selecionar esse veiculo?", "Veiculo encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SelecionarVeiculo(veiculo, pSinistro: true);
                }
            }
        }

        private void PesquisarMotoristaPSinistroBtn_Click(object sender, RoutedEventArgs e)
        {
            Motorista motorista = PesquisarMotorista(PesquisarMotoristaPSinistroTextBox.Text);

            if (motorista == null)
            {
                MessageBox.Show("Motorista não encontrado!");
            }
            else if (motorista != null)
            {
                MessageBoxResult result = MessageBox.Show("Motorista encontrado! Deseja selecionar esse motorista?", "Motorista encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SelecionarMotorista(motorista, pSinistro: true);
                }
            }
        }

        private void SelecionarMotoristaPSinistroBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarMotorista(MotoristaParaSinistroDataGrid.SelectedItem as Motorista, pSinistro: true);
        }
        #endregion

        #region Métodos

        private Veiculo PesquisarVeiculo(string placa)
        {
            return ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorPlaca(placa);
        }

        private Motorista PesquisarMotorista(string cpf)
        {
            return ServicoDados.ServicoDadosMotorista.ObterMotoristaPorCPF(cpf);
        }

        private void SelecionarVeiculo(Veiculo veiculoSelecionado, bool pMulta = false, bool pSinistro = false)
        {
            if(pMulta == true)
            {
                _veiculoPMulta = veiculoSelecionado;
                VeiculoSelecionadoMultaTextBox.DataContext = _veiculoPMulta;
            }
            if(pSinistro == true)
            {
                _veiculoPSinistro = veiculoSelecionado;
                VeiculoSelecionadoPSinistroTextBox.DataContext = _veiculoPSinistro;
            }
        }

        private void SelecionarMotorista(Motorista motoristaSelecionado, bool pMulta = false, bool pSinistro = false)
        {
            if (pMulta == true)
            {
                _motoristaPMulta = motoristaSelecionado;
                MotoristaSelecionadoMultaTextBox.DataContext = _motoristaPMulta;
            }
            if (pSinistro == true)
            {
                _motoristaPSinistro = motoristaSelecionado;
                MotoristaSelecionadoPSinistroTextBox.DataContext = _motoristaPSinistro;
            }
        }

        private void PopularComboBoxes()
        {

            string[] estadosDePagamento = Enum.GetNames(typeof(EstadosDePagamento));
            for (int i = 0; i < estadosDePagamento.Length; i++)
            {
                estadosDePagamento[i] = estadosDePagamento[i].Replace('_', ' ');
            }
            EstadoPagamentoInfracaoComboBox.ItemsSource = estadosDePagamento;
            EstadoPagamentoSinistroComboBox.ItemsSource = estadosDePagamento;

            GravidadeInfracaoComboBox.ItemsSource = Enum.GetNames(typeof(GravidadesDeInfracao));
            GravidadeSinistroComboBox.ItemsSource = Enum.GetNames(typeof(GravidadesDeSinistro));
        }

        private void PopularDataGrids()
        {
            VeiculosParaMultasDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().ToList();
            VeiculosParaSinistrosDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().ToList();

            MotoristaParaMultaDataGrid.ItemsSource = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId().ToList();
            MotoristaParaSinistroDataGrid.ItemsSource = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId().ToList();
        }

        private Multa GerarMulta()
        {
            Multa multa = new Multa();
            multa.CodigoMulta = CodigoMultaTextBox.Text;
            multa.Valor = double.Parse(ValorMultaTextBox.Text);
            multa.DataDaMulta = DataDaMultaDatePicker.DisplayDate;
            multa.EstadoDoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), EstadoPagamentoInfracaoComboBox.SelectedItem.ToString().Replace(' ', '_'));
            multa.GravidadeDaInfracao = (GravidadesDeInfracao)Enum.Parse(typeof(GravidadesDeInfracao), GravidadeInfracaoComboBox.SelectedItem.ToString());
            multa.MotoristaId = _motoristaPMulta.MotoristaId;
            multa.VeiculoId = _veiculoPMulta.VeiculoId;

            return multa;
        }

        private Sinistro GerarSinistro()
        {
            string descricao = new TextRange(DescricaoSinistroRichTextBox.Document.ContentStart, DescricaoSinistroRichTextBox.Document.ContentEnd).Text;

            Sinistro sinistro = new Sinistro();
            sinistro.CodSinistro = CodigoSinistroTextBox.Text;
            sinistro.DataSinistro = DataDoSinistroDatePicker.DisplayDate;
            sinistro.QntEnvolvidos = int.Parse(QtnEnvolvidosSinistroTextBox.Text);
            sinistro.Gravidade = (GravidadesDeSinistro)Enum.Parse(typeof(GravidadesDeSinistro), GravidadeSinistroComboBox.SelectedItem.ToString().Replace(' ', '_'));
            sinistro.EstadoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), EstadoPagamentoSinistroComboBox.SelectedItem.ToString().Replace(' ', '_'));
            sinistro.VeiculoId = _veiculoPSinistro.VeiculoId;
            sinistro.MotoristaId = _motoristaPSinistro.MotoristaId;
            sinistro.Descricao = descricao;

            return sinistro;
        }

        #endregion

    }
}
