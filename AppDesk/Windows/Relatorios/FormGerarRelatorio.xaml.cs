using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Enums;
using System;
using System.Windows;

namespace AppDesk.Windows.Relatorios
{
    /// <summary>
    /// Lógica interna para FormGerarRelatorio.xaml
    /// </summary>
    public partial class FormGerarRelatorio : Window
    {
        public FormGerarRelatorio()
        {
            InitializeComponent();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Relatório") == MessageBoxResult.Yes)
                {
                    TiposRelatorios tipo = 0;

                    if (ConsumoRB.IsChecked == true)
                    {
                        tipo = TiposRelatorios.CONSUMO;
                    }
                    else if (FinanceiroRB.IsChecked == true)
                    {
                        tipo = TiposRelatorios.FINANCEIRO;
                    }
                    else if (ManutencaoRB.IsChecked == true)
                    {
                        tipo = TiposRelatorios.MANUTENCOES;
                    }
                    else if (ViagemRB.IsChecked == true)
                    {
                        tipo = TiposRelatorios.VIAGEM;
                    }
                    else if (SinistroRB.IsChecked == true)
                    {
                        tipo = TiposRelatorios.ACIDENTE;
                    }
                    else if (MultaRB.IsChecked == true)
                    {
                        tipo = TiposRelatorios.MULTA;
                    }
                    else if (SinistroRB.IsChecked == true)
                    {
                        tipo = TiposRelatorios.ACIDENTE;
                    }
                    else
                    {
                        throw new FieldException("Tipo de Relatório");
                    }

                    ServicoDados.ServicoDadosRelatorio.GravarRelatorio(
                        relatorio: ServicoDados.ServicoDadosRelatorio.GerarRelatorio(
                            dataInicio: DataInicialUC.Date.GetValueOrDefault(),
                            dataFinal: DataFinalUC.Date.GetValueOrDefault(),
                            tipo: tipo,
                            descricao: DescricaoTextBox.Text),
                        tipo: tipo);

                    MessageBox.Show("Relatorio Gerado com sucesso!");

                    MainWindowUpdater.UpdateDataGrids();
                    this.Close();
                }
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

    }
}
