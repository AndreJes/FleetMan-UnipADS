﻿using AppDesk.Serviço;
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

            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Remover || !DesktopLoginControlService._Usuario.Permissoes.Relatorios.Alterar)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar remoção de relatório?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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
