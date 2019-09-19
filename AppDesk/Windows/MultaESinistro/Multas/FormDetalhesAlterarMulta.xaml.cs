using AppDesk.Serviço;
using AppDesk.Tools;
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

namespace AppDesk.Windows.MultaESinistro.Multas
{
    /// <summary>
    /// Lógica interna para FormDetalhesAlterarMulta.xaml
    /// </summary>
    public partial class FormDetalhesAlterarMulta : Window
    {
        private Multa _multa = null;

        private FormDetalhesAlterarMulta()
        {
            InitializeComponent();
        }

        public FormDetalhesAlterarMulta(Multa multa) : this()
        {
            _multa = multa;
            PopularComboBox();
            EstadoPagamentoInfracaoComboBox.SelectedItem = _multa.EstadoDoPagamento.ToString("G").Replace('_', ' ');
            this.DataContext = _multa;
        }

        private void PopularComboBox()
        {
            var lista = Enum.GetNames(typeof(EstadosDePagamento));
            for(int i = 0; i < lista.Length; i++)
            {
                lista[i] = lista[i].Replace('_', ' ');
            }
            EstadoPagamentoInfracaoComboBox.ItemsSource = lista;
        }

        private void RemoverMultaBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirmar remoção de multa?", "Confirmar Remoção", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosMulta.RemoverMultaPorId(_multa.MultaId);
                MessageBox.Show("Multa removida com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void EstadoPagamentoInfracaoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EstadoPagamentoInfracaoComboBox.SelectedItem.ToString().Replace(' ', '_') != _multa.EstadoDoPagamento.ToString("G"))
            {
                SalvarAlteracaoPagamentoBtn.IsEnabled = true;
            }
        }

        private void SalvarAlteracaoPagamentoBtn_Click(object sender, RoutedEventArgs e)
        {
            _multa.EstadoDoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento),EstadoPagamentoInfracaoComboBox.SelectedItem.ToString().Replace(' ', '_'));
            ServicoDados.ServicoDadosMulta.GravarMulta(_multa);
            MainWindowUpdater.UpdateDataGrids();
        }
    }
}
