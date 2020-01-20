using AppDesk.Serviço;
using AppDesk.Tools;
using LiveCharts;
using LiveCharts.Wpf;
using Modelo.Classes.Relatorios;
using Modelo.Enums;
using System;
using System.Windows;

namespace AppDesk.Windows.Relatorios
{
    /// <summary>
    /// Lógica interna para FormDetalhesRelatorioMultas.xaml
    /// </summary>
    public partial class FormDetalhesRelatorioMultas : Window
    {
        public RelatorioMulta Relatorio { get; set; }
        public string[] Legendas { get; set; }
        public Func<double, string> Formatador { get; set; }

        private FormDetalhesRelatorioMultas()
        {
            InitializeComponent();
        }

        public FormDetalhesRelatorioMultas(RelatorioMulta relatorio) : this()
        {
            Relatorio = relatorio;
            DataContext = this;
            Legendas = new string[] { "Total / Média" };
            DefinirGraficoRelacao();
            DefinirGraficoValores();

            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Remover || !DesktopLoginControlService._Usuario.Permissoes.Relatorios.Alterar)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar remoção de relatório?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosRelatorio.RemoverRelatorioPorId(Relatorio.RelatorioId, TiposRelatorios.MULTA);
                MessageBox.Show("Relatorio removido com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DefinirGraficoRelacao()
        {
            GraficoPizzaGravidades.Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Leves",
                    Values = new ChartValues<double>(){Relatorio.QntMultasLeves}
                },
                new PieSeries()
                {
                    Title = "Gravissimas",
                    Values = new ChartValues<double>(){Relatorio.QntMultasGravissimas}
                },
                new PieSeries()
                {
                    Title = "Graves",
                    Values = new ChartValues<double>(){Relatorio.QntMultasGraves}
                },
                new PieSeries()
                {
                    Title = "Médias",
                    Values = new ChartValues<double>(){Relatorio.QntMultasMedias}
                }
            };
            GraficoPizzaPagamentos.Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Pago",
                    Values = new ChartValues<double>(){Relatorio.QntMultasPagas}
                },
                new PieSeries()
                {
                    Title = "Vencido",
                    Values = new ChartValues<double>(){Relatorio.QntMultasVencidas}
                },
                new PieSeries()
                {
                    Title = "Aguardando",
                    Values = new ChartValues<double>(){Relatorio.QntMultasAguardando}
                }
            };
        }

        private void DefinirGraficoValores()
        {
            Formatador = values => values.ToString("C");
            GraficoValores.Series = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Total",
                    Values = new ChartValues<double>(){Relatorio.ValorTotal}
                },
                new ColumnSeries()
                {
                    Title = "Média",
                    Values = new ChartValues<double>(){Relatorio.ValorMedio}
                }
            };
        }
    }
}
