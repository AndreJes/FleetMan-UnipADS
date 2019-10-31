using AppDesk.Serviço;
using AppDesk.Tools;
using LiveCharts;
using LiveCharts.Wpf;
using Modelo.Classes.Relatorios;
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

namespace AppDesk.Windows.Relatorios
{
    /// <summary>
    /// Lógica interna para FormDetalhesRelatorioConsumo.xaml
    /// </summary>
    public partial class FormDetalhesRelatorioConsumo : Window
    {
        public RelatorioConsumo Relatorio { get; set; }
        public string[] Legendas { get; set; }

        private FormDetalhesRelatorioConsumo()
        {
            InitializeComponent();
        }

        public FormDetalhesRelatorioConsumo(RelatorioConsumo relatorioConsumo) : this()
        {
            Relatorio = relatorioConsumo;
            DataContext = this;
            Legendas = new string[] { "Total/Média" };
            DefinirGraficoTotalCombustivel(Relatorio);
            DefinirGraficoValores(Relatorio);
        }

        public void DefinirGraficoTotalCombustivel(RelatorioConsumo relatorioConsumo)
        {
            GraficoTotalDeCombustivel.Series = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Total",
                    Values = new ChartValues<double> {relatorioConsumo.TotalCombustivel}
                },
                new ColumnSeries()
                {
                    Title = "Média",
                    Values = new ChartValues<double> {relatorioConsumo.MediaDeCombustivel}
                }
            };
        }

        public void DefinirGraficoValores(RelatorioConsumo relatorioConsumo)
        {
            GraficoCustos.Series = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Total",
                    Values = new ChartValues<double> {relatorioConsumo.ValorGastoTotal}
                },
                new ColumnSeries()
                {
                    Title = "Média",
                    Values = new ChartValues<double> {relatorioConsumo.ValorGastoMedio}
                }
            };
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Confirmar remoção de relatório", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosRelatorio.RemoverRelatorioPorId(Relatorio.RelatorioId, TiposRelatorios.CONSUMO);
                MessageBox.Show("Relatório removido com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }
    }
}
