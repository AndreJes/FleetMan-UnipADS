using AppDesk.Serviço;
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

        private void PopularComboBoxes()
        {

            string[] estadosDePagamento = Enum.GetNames(typeof(EstadosDePagamento));
            for(int i = 0; i < estadosDePagamento.Length; i++)
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

        private void SelecionarMotoristaMultaBtn_Click(object sender, RoutedEventArgs e)
        {
            _motoristaPMulta = MotoristaParaMultaDataGrid.SelectedItem as Motorista;
            MotoristaSelecionadoMultaTextBox.DataContext = _motoristaPMulta;
        }

        private void SelecionarVeiculoMultaBtn_Click(object sender, RoutedEventArgs e)
        {
            _veiculoPMulta = VeiculosParaMultasDataGrid.SelectedItem as Veiculo;
            VeiculoSelecionadoMultaTextBox.DataContext = _veiculoPMulta;
        }


    }
}
