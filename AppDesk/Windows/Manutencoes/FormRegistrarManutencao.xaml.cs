using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Manutencao;
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

namespace AppDesk.Windows.Manutencoes
{
    /// <summary>
    /// Lógica interna para FormRegistrarManutencao.xaml
    /// </summary>
    public partial class FormRegistrarManutencao : Window
    {

        public FormRegistrarManutencao()
        {
            InitializeComponent();
            PecasDataGrid.ItemsSource = ServicoDados.ServicoDadosPeca.ObterPecasOrdPorId();
            VeiculosUC.VeiculosDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Confirmar registro de manutenção", "Confirmar registro?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosManutencao.AdicionarManutencao(GerarManutencao(), PecasSelecionadasDataGrid.Items.OfType<Peca>().ToList());
                MessageBox.Show("Manuteção adicionada com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelecionarPeca_Click(object sender, RoutedEventArgs e)
        {
            MoverItens(PecasDataGrid, PecasSelecionadasDataGrid);
        }

        private void RemoverPeca_Click(object sender, RoutedEventArgs e)
        {
            if (PecasSelecionadasDataGrid.SelectedItem != null)
            {
                if ((PecasSelecionadasDataGrid.SelectedItem as Peca).Quantidade > 1)
                {
                    (PecasSelecionadasDataGrid.SelectedItem as Peca).Quantidade--;
                    PecasSelecionadasDataGrid.Items.Refresh();
                }
                else
                {
                    PecasSelecionadasDataGrid.Items.Remove(PecasSelecionadasDataGrid.SelectedItem);
                }
            }

        }

        private void MoverItens(DataGrid origem, DataGrid destino)
        {
            Peca peca = null;
            if (origem.SelectedItem != null)
            {
                peca = (origem.SelectedItem as Peca);
            }
            if (destino.Items.Contains(peca))
            {
                peca = (destino.Items[destino.Items.IndexOf(peca)] as Peca);
                destino.Items.Remove(peca);
                peca.Quantidade++;
                destino.Items.Add(peca);
            }
            else if (peca != null)
            {
                peca.Quantidade = 1;
                destino.Items.Add(peca);
            }
        }

        private Manutencao GerarManutencao()
        {
            Manutencao manutencao = new Manutencao();
            manutencao.CPFCNPJResponsavel = CPFCNPJResponsavelTextBox.Text;
            manutencao.NomeResponsavel = NomeResponsavelTextBox.Text;
            manutencao.Local = EnderecoUC.Endereco;
            manutencao.VeiculoId = VeiculosUC.Veiculo.VeiculoId;

            if (PreventivaRadioButton.IsChecked == true)
            {
                manutencao.Tipo = TiposDeManutencao.PREVENTIVA;
            }
            else if (CorretivaRadioButton.IsChecked == true)
            {
                manutencao.Tipo = TiposDeManutencao.CORRETIVA;
            }

            manutencao.DataEntrada = (DateTime)DataAgendamentoDatePicker.SelectedDate;

            if (ConcluidoCheckBox.IsChecked == true)
            {
                manutencao.DataSaida = (DateTime)DataConclusaoDatePicker.SelectedDate;
                manutencao.EstadoAtual = EstadosDeManutencao.CONCLUIDA;
            }

            return manutencao;
        }
    }
}
