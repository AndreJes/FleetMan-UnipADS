using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Motoristas;
using AppDesk.Windows.Veiculos;
using Modelo.Classes.Desk;
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

namespace AppDesk.Windows.MultaESinistro.Sinistros
{
    /// <summary>
    /// Lógica interna para FormDetalhesAlterarSinistro.xaml
    /// </summary>
    public partial class FormDetalhesAlterarSinistro : Window
    {
        private Sinistro _sinistro = null;

        private FormDetalhesAlterarSinistro()
        {
            InitializeComponent();
        }

        public FormDetalhesAlterarSinistro(Sinistro sinistro) : this()
        {
            _sinistro = sinistro;
            DataContext = _sinistro;
            PopularComboBox();
            EstadoPagamentoSinistro.SelectedItem = _sinistro.EstadoPagamento.ToString("G");
            PreencherRichTextBox();
            CPFUC.Text = _sinistro.Motorista.CPF;
            PlacaVeiculoUC.Text = _sinistro.Veiculo.Placa;
            DataSinistroUC.Date = _sinistro.DataSinistro;
        }

        private void PopularComboBox()
        {
            var lista = Enum.GetNames(typeof(EstadosDePagamento));
            for (int i = 0; i < lista.Length; i++)
            {
                lista[i] = lista[i].Replace('_', ' ');
            }
            EstadoPagamentoSinistro.ItemsSource = lista;
        }

        private void PreencherRichTextBox()
        {
            FlowDocument fd = new FlowDocument(new Paragraph(new Run(_sinistro.Descricao)));
            DescricaoSinistroTextBox.Document = fd;
        }

        private void EstadoPagamentoSinistro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EstadoPagamentoSinistro.SelectedItem.ToString() != _sinistro.EstadoPagamento.ToString("G"))
            {
                SalvarAlteracaoPagamentoBtn.IsEnabled = true;
            }
        }

        private void SalvarAlteracaoPagamentoBtn_Click(object sender, RoutedEventArgs e)
        {
            _sinistro.EstadoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), EstadoPagamentoSinistro.SelectedItem.ToString());
            ServicoDados.ServicoDadosSinistro.GravarSinistro(_sinistro);
            MainWindowUpdater.UpdateDataGrids();
        }

        private void RemoverSinistroBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirmar remoção de sinistro?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosSinistro.RemoverSinistroPorId(_sinistro.SinistroId);
                MainWindowUpdater.UpdateDataGrids();
                MessageBox.Show("Sinistro removido com sucesso!");
                this.Close();
            }
        }

        private void DetalhesDoVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            FormDetalhesVeiculo formDetalhesVeiculo = new FormDetalhesVeiculo(ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId(_sinistro.VeiculoId));
            formDetalhesVeiculo.Show();
        }

        private void DetalhesDoMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            FormDetalhesMotorista formDetalhesMotorista = new FormDetalhesMotorista(ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId(_sinistro.MotoristaId));
            formDetalhesMotorista.Show();
        }
    }
}
