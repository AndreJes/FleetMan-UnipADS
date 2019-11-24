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
    /// Lógica interna para FormDetalhesRelatorioManutencao.xaml
    /// </summary>
    public partial class FormDetalhesRelatorioManutencao : Window
    {
        public RelatorioManutencao Relatorio { get; set; }

        private FormDetalhesRelatorioManutencao()
        {
            InitializeComponent();
        }

        public FormDetalhesRelatorioManutencao(RelatorioManutencao relatorio) : this()
        {
            Relatorio = relatorio;
            DataContext = this;
            DefinirGraficoRelacao();
            DefinirGraficoTipos();

            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Remover || !DesktopLoginControlService._Usuario.Permissoes.Relatorios.Alterar)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar remoção de relatório?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosRelatorio.RemoverRelatorioPorId(Relatorio.RelatorioId, TiposRelatorios.MANUTENCOES);
                MessageBox.Show("Relatorio removido com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void DefinirGraficoRelacao()
        {
            GraficoPizzaEstadosMan.Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Em Andamento",
                    Values = new ChartValues<double>(){Relatorio.QntManEmAndamento}
                },
                new PieSeries()
                {
                    Title = "Canceladas",
                    Values = new ChartValues<double>(){Relatorio.QntManCanceladas}
                },
                new PieSeries()
                {
                    Title = "Aguardando",
                    Values = new ChartValues<double>(){Relatorio.QntManAguardando}
                },
                new PieSeries()
                {
                    Title = "Concluidas",
                    Values = new ChartValues<double>(){Relatorio.QntManConcluidas}
                }
            };
        }

        private void DefinirGraficoTipos()
        {
            GraficoPizzaTipoMan.Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Preventivas",
                    Values = new ChartValues<double>(){Relatorio.QntManPreventivas}
                },
                new PieSeries()
                {
                    Title = "Corretivas",
                    Values = new ChartValues<double>(){Relatorio.QntManCorretivas}
                }
            };
        }
    }
}
