using AppDesk.Serviço;
using AppDesk.Tools;
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
            if (MessageBox.Show("Confirmar registro de relatório?", "Confirmar registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                TiposRelatorios tipo = TiposRelatorios.ACIDENTE;
                if(ConsumoRB.IsChecked == true)
                {
                    tipo = TiposRelatorios.CONSUMO;
                }
                else if(FinanceiroRB.IsChecked == true)
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

                ServicoDados.ServicoDadosRelatorio.GravarRelatorio(
                    ServicoDados.ServicoDadosRelatorio.GerarRelatorio(
                        InicioDatePicker.SelectedDate.GetValueOrDefault(),
                        FinalDatePicker.SelectedDate.GetValueOrDefault(),
                        tipo, DescricaoTextBox.Text),
                    tipo);

                MessageBox.Show("Relatorio Gerado com sucesso!");

                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
