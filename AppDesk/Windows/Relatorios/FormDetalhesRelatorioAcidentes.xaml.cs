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
    /// Lógica interna para FormDetalhesRelatorioAcidentes.xaml
    /// </summary>
    public partial class FormDetalhesRelatorioAcidentes : Window
    {
        public RelatorioSinistros Relatorio { get; set; }

        private FormDetalhesRelatorioAcidentes()
        {
            InitializeComponent();
        }

        public FormDetalhesRelatorioAcidentes(RelatorioSinistros relatorio) : this()
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
                ServicoDados.ServicoDadosRelatorio.RemoverRelatorioPorId(Relatorio.RelatorioId, TiposRelatorios.ACIDENTE);
                MessageBox.Show("Relatorio removido com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }
        private void DefinirGraficoRelacao()
        {
            GraficoPizzaPagamento.Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Pago",
                    Values = new ChartValues<double>(){Relatorio.QntSinistrosPagos}
                },
                new PieSeries()
                {
                    Title = "Vencido",
                    Values = new ChartValues<double>(){Relatorio.QntSinistrosVencidos}
                },
                new PieSeries()
                {
                    Title = "Aguardando",
                    Values = new ChartValues<double>(){Relatorio.QntSinistrosAguardando}
                }
            };
        }

        private void DefinirGraficoTipos()
        {
            GraficoPizzaTipoSinis.Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Batida",
                    Values = new ChartValues<double>(){Relatorio.QntBatidas}
                },
                new PieSeries()
                {
                    Title = "Acidente Leve S/ Vitimas",
                    Values = new ChartValues<double>(){Relatorio.QntAcidentesLevesSVitima}
                },
                new PieSeries()
                {
                    Title = "Acidente Leve C/ Vitimas",
                    Values = new ChartValues<double>(){Relatorio.QntAcidentesLevesCVitima}
                },
                new PieSeries()
                {
                    Title = "Acidente Grave",
                    Values = new ChartValues<double>(){Relatorio.QntAcidentesGraves}
                },
                new PieSeries()
                {
                    Title = "Acidente Fatal",
                    Values = new ChartValues<double>(){Relatorio.QntAcidentesFatais}
                },
                new PieSeries()
                {
                    Title = "Perda Total",
                    Values = new ChartValues<double>(){Relatorio.QntPerdasTotais}
                }
            };
        }
    }
}
