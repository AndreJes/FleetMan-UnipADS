using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Manutencao;
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

namespace AppDesk.Windows.Abastecimentos
{
    /// <summary>
    /// Lógica interna para FormRegistrarAbastecimento.xaml
    /// </summary>
    public partial class FormRegistrarAbastecimento : Window
    {

        public FormRegistrarAbastecimento()
        {
            InitializeComponent();
            MotoristaUC.MotoristasDataGrid.ItemsSource = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId();
            SeletorVeiculo.VeiculosDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar registro de Abastecimento?", "Confirmar registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosAbastecimento.GravarAbastecimento(GerarAbastecimento());
                MessageBox.Show("Abastecimento registrado com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Abastecimento GerarAbastecimento()
        {
            Abastecimento abastecimento = new Abastecimento();
            abastecimento.NovoEstadoTanque = (EstadosTanqueCombustivel)int.Parse(QuantidadeSlider.Value.ToString("F0"));
            abastecimento.VeiculoId = SeletorVeiculo.Veiculo.VeiculoId;
            abastecimento.MotoristaId = MotoristaUC.Motorista.MotoristaId;

            if (AgendarRB.IsChecked == true)
            {
                abastecimento.Estado = EstadoAbastecimento.AGENDADO;
                abastecimento.DataAgendada = DataAgendamentoDatePicker.SelectedDate;
            }
            if (RegistrarRB.IsChecked == true)
            {
                abastecimento.Estado = EstadoAbastecimento.REALIZADO;
                abastecimento.DataConclusao = DataConclusaoDatePicker.SelectedDate;
                abastecimento.Valor = double.Parse(ValorTextBox.Text);
            }

            if (!string.IsNullOrEmpty(QuantidadeDeCombustivelTextBox.Text))
            {
                abastecimento.QuantidadeAbastecida = double.Parse(QuantidadeDeCombustivelTextBox.Text);
            }

            abastecimento.Local = EnderecoUC.Endereco;

            return abastecimento;
        }

    }
}
