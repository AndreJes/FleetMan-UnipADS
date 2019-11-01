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
    /// Lógica interna para FormDetalhesRelatorioViagens.xaml
    /// </summary>
    public partial class FormDetalhesRelatorioViagens : Window
    {

        public RelatorioViagem Relatorio { get; set; }

        private FormDetalhesRelatorioViagens()
        {
            InitializeComponent();
        }

        public FormDetalhesRelatorioViagens(RelatorioViagem relatorio) : this()
        {
            Relatorio = relatorio;
            DataContext = this;
            DefinirGraficoRelacao();
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar remoção de relatório?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosRelatorio.RemoverRelatorioPorId(Relatorio.RelatorioId, TiposRelatorios.VIAGEM);
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
            GraficoPizzaEstadosViagem.Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Em Andamento",
                    Values = new ChartValues<double>(){Relatorio.QntViagensEmAndamento}
                },
                new PieSeries()
                {
                    Title = "Canceladas",
                    Values = new ChartValues<double>(){Relatorio.QntViagensCanceladas}
                },
                new PieSeries()
                {
                    Title = "Aguardando",
                    Values = new ChartValues<double>(){Relatorio.QntViagensAguardando}
                },
                new PieSeries()
                {
                    Title = "Concluidas",
                    Values = new ChartValues<double>(){Relatorio.QntViagensConcluidas}
                }
            };
        }
    }
}
