using AppDesk.Serviço;
using Modelo.Classes.Clientes;
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

namespace AppDesk.Windows.Veiculos
{
    /// <summary>
    /// Lógica interna para FormDetalhesVeiculo.xaml
    /// </summary>
    public partial class FormDetalhesVeiculo : Window
    {
        private Veiculo _veiculo = null;
        private FormDetalhesVeiculo()
        {
            InitializeComponent();
        }

        public FormDetalhesVeiculo(Veiculo veiculo) : this()
        {
            _veiculo = veiculo;
            DataContext = _veiculo;
            MultasDataGrid.ItemsSource = _veiculo.Multas.ToList();
            SinistrosDataGrid.ItemsSource = _veiculo.Sinistros.ToList();
            TanqueProgressBar.Value = (double)_veiculo.EstadoDoTanque;
            PreencherDadosCliente();
        }

        private void PreencherDadosCliente()
        {
            if(_veiculo.Cliente is ClientePF)
            {
                CPFCNPJClienteTextBox.Text = (_veiculo.Cliente as ClientePF).CPFTxt;
            }
            else if (_veiculo.Cliente is ClientePJ)
            {
                CPFCNPJClienteTextBox.Text = (_veiculo.Cliente as ClientePJ).CNPJTxt;
            }
            else if (_veiculo.Cliente == null)
            {
                ClienteGroupBox.Visibility = Visibility.Collapsed;
            }
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            FormAlterarVeiculo formAlterarVeiculo = new FormAlterarVeiculo(_veiculo);
            formAlterarVeiculo.Show();
            this.Close();
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirmar remoção de veículo?", "Confirmar Remoção", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosVeiculos.RemoverVeiculoPorId(_veiculo.VeiculoId);
                MessageBox.Show("Veiculo removido com sucesso!");
                Application.Current.Windows.OfType<MainWindow>().First().PopulateDataGrid();
                this.Close();
            }
        }
    }
}
