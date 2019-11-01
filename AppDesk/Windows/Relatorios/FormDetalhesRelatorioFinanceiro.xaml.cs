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
    /// Lógica interna para FormDetalhesRelatorioFinanceiro.xaml
    /// </summary>
    public partial class FormDetalhesRelatorioFinanceiro : Window
    {
        public RelatorioFinanceiro Relatorio { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }
        public string[] Legendas { get; set; }
        public Func<double, string> Formatador { get; set; }

        private FormDetalhesRelatorioFinanceiro()
        {
            InitializeComponent();
            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
        }

        public FormDetalhesRelatorioFinanceiro(RelatorioFinanceiro relatorio) : this()
        {
            Relatorio = relatorio;
            DataContext = this;
            DefinirGraficoPizza();
            DefinirGraficoBarras();
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Confirmar remoção de relatório?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosRelatorio.RemoverRelatorioPorId(Relatorio.RelatorioId, TiposRelatorios.FINANCEIRO);
                MessageBox.Show("Relatorio removido com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DefinirGraficoPizza()
        {
            GraficoPizzaPagamentos.Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Pago",
                    Values = new ChartValues<double>() {Relatorio.QntFinancasPagas},
                    DataLabels = true
                },
                new PieSeries()
                {
                    Title = "Vencidos",
                    Values = new ChartValues<double>() {Relatorio.QntFinancasVencidas},
                    DataLabels = true
                },
                new PieSeries()
                {
                    Title = "Aguardando",
                    Values = new ChartValues<double>() {Relatorio.QntFinancasAguardando},
                    DataLabels = true
                }
            };
        }

        private void DefinirGraficoBarras()
        {
            Legendas = new string[] { "Entradas / Saidas" };
            Formatador = valor => valor.ToString("C");

            GraficoBarraEntradasSaidas.Series = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Entradas",
                    Values = new ChartValues<double>() {Relatorio.TotalValorEntradas}
                },
                new ColumnSeries()
                {
                    Title = "Saidas",
                    Values = new ChartValues<double>() {Relatorio.TotalValorSaidas}
                }
            };
        }
    }
}
