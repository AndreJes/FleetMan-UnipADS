using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Manutencao;
using Modelo.Classes.Manutencao.Associacao;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica interna para FormAlterarDetalhesManutencao.xaml
    /// </summary>
    public partial class FormAlterarDetalhesManutencao : Window
    {
        private Manutencao _manutencao = null;
        public ObservableCollection<PecasManutencao> PecasSelecionadas { get; set; }

        private FormAlterarDetalhesManutencao()
        {
            InitializeComponent();
        }

        public FormAlterarDetalhesManutencao(Manutencao manutencao) : this()
        {
            _manutencao = manutencao;
            this.DataContext = _manutencao;
            VeiculoUC.Veiculo = manutencao.Veiculo;
            EnderecoUC.Editavel = true;
            EnderecoUC.Endereco = manutencao.Local;
            NomeResponsavelTextBox.Text = manutencao.NomeResponsavel;
            CPFCNPJResponsavelTextBox.Text = manutencao.CPFCNPJResponsavel;
            DataAgendamentoDatePicker.SelectedDate = manutencao.DataEntrada;
            if (manutencao.DataSaida != null)
            {
                ConcluidoCheckBox.IsChecked = true;
                DataConclusaoDatePicker.SelectedDate = manutencao.DataSaida;
                DataConclusaoDatePicker.IsEnabled = false;
            }
            switch (manutencao.Tipo)
            {
                case Modelo.Enums.TiposDeManutencao.PREVENTIVA:
                    PreventivaRadioButton.IsChecked = true;
                    break;
                case Modelo.Enums.TiposDeManutencao.CORRETIVA:
                    CorretivaRadioButton.IsChecked = true;
                    break;
                default:
                    break;
            }
            PecasDataGrid.ItemsSource = ServicoDados.ServicoDadosPeca.ObterPecasOrdPorId();
            foreach(PecasManutencao p in manutencao.PecasUtilizadas)
            {
                PecasSelecionadasDataGrid.Items.Add(p);
            }
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração de manutenção?", "Confirmar Alteração", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosManutencao.AlterarManutencao(AlterarInformacoes(), PecasSelecionadasDataGrid.Items.OfType<PecasManutencao>().ToList());
                MessageBox.Show("Manutenção alterada com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar remoção de manutenção?", "Confirmar Remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosManutencao.RemoverManutencaoPorId(_manutencao.ManutencaoId);
                MessageBox.Show("Manutenção removida com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void SelecionarPeca_Click(object sender, RoutedEventArgs e)
        {
            MoverItens(PecasDataGrid, PecasSelecionadasDataGrid);
        }

        private void RemoverPeca_Click(object sender, RoutedEventArgs e)
        {
            if (PecasSelecionadasDataGrid.SelectedItem != null)
            {
                PecasManutencao pecasManutencao = PecasSelecionadasDataGrid.SelectedItem as PecasManutencao;
                PecasSelecionadasDataGrid.Items.Remove(pecasManutencao);
            }

        }

        private void MoverItens(DataGrid origem, DataGrid destino)
        {
            Peca peca = null;
            if (origem.SelectedItem != null)
            {
                peca = (origem.SelectedItem as Peca);
            }

            PecasManutencao PecaParaAdicionar = new PecasManutencao();
            PecaParaAdicionar.PecaId = peca.PecaId;
            PecaParaAdicionar.Peca = peca;

            PecasManutencao PecaSelecionada = PecasSelecionadasDataGrid.Items.OfType<PecasManutencao>().Where(pm => pm.PecaId == PecaParaAdicionar.PecaId).FirstOrDefault();

            if (PecaSelecionada != null)
            {
                PecaSelecionada.QuantidadePecasUtilizadas++;
                PecasSelecionadasDataGrid.Items.Refresh();
            }
            else
            {
                PecaParaAdicionar.QuantidadePecasUtilizadas++;
                PecasSelecionadasDataGrid.Items.Add(PecaParaAdicionar);
            }
        }

        private Manutencao AlterarInformacoes()
        {
            _manutencao.NomeResponsavel = NomeResponsavelTextBox.Text;
            _manutencao.CPFCNPJResponsavel = CPFCNPJResponsavelTextBox.Text;
            _manutencao.Local = EnderecoUC.Endereco;
            if (ConcluidoCheckBox.IsChecked == true)
            {
                _manutencao.DataSaida = DataConclusaoDatePicker.SelectedDate;
                _manutencao.EstadoAtual = EstadosDeManutencao.CONCLUIDA;
            }

            return _manutencao;
        }
    }
}
