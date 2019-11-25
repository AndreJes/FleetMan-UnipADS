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
            VeiculoUC.Veiculo = _manutencao.Veiculo;
            EnderecoUC.Editavel = true;
            EnderecoUC.Endereco = _manutencao.Local;
            NomeResponsavelTextBox.Text = _manutencao.NomeResponsavel;
            if (_manutencao.CPFCNPJResponsavel.Length > 11)
            {
                PjRB.IsChecked = true;
                CNPJUC.Text = _manutencao.CPFCNPJResponsavel;
            }
            else
            {
                PfRB.IsChecked = true;
                CPFUC.Text = _manutencao.CPFCNPJResponsavel;
            }

            DataAgendamento.Date = manutencao.DataEntrada;
            if (manutencao.DataSaida != null)
            {
                ConcluidoCheckBox.IsChecked = true;
                ConcluidoCheckBox.IsEnabled = false;
                DataConclusaoUC.Date = _manutencao.DataSaida.GetValueOrDefault();
                DataConclusaoUC.IsEnabled = false;
                DataAgendamento.IsEnabled = false;
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
            foreach (PecasManutencao p in manutencao.PecasUtilizadas)
            {
                PecasSelecionadasDataGrid.Items.Add(p);
            }

            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Alterar)
            {
                SalvarAlteracoesBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("Manutenção") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosManutencao.AlterarManutencao(AlterarInformacoes(), PecasSelecionadasDataGrid.Items.OfType<PecasManutencao>().ToList());
                    StandardMessageBoxes.MensagemSucesso("Manutenção alterada com sucesso!", "Alteração");
                    MainWindowUpdater.UpdateDataGrids();
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

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Manutenção") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosManutencao.RemoverManutencaoPorId(_manutencao.ManutencaoId);
                    StandardMessageBoxes.MensagemSucesso("Manutenção removida com sucesso!", "Remoção");
                    MainWindowUpdater.UpdateDataGrids();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
            try
            {
                _manutencao.NomeResponsavel = NomeResponsavelTextBox.Text;
                if (PjRB.IsChecked == true)
                {
                    _manutencao.CPFCNPJResponsavel = CNPJUC.Text;
                }
                else
                {
                    _manutencao.CPFCNPJResponsavel = CPFUC.Text;
                }
                _manutencao.Local = EnderecoUC.Endereco;
                if (ConcluidoCheckBox.IsChecked == true)
                {
                    _manutencao.DataSaida = DataConclusaoUC.Date;
                    _manutencao.EstadoAtual = EstadosDeManutencao.CONCLUIDA;
                }

                return _manutencao;
            }
            catch (FieldException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PfRB_Checked(object sender, RoutedEventArgs e)
        {
            if (PfRB.IsChecked == true)
            {
                if (CNPJUC != null)
                {
                    CNPJUC.Visibility = Visibility.Collapsed;
                }
                if (CPFUC != null)
                {
                    CPFUC.Visibility = Visibility.Visible;
                }
            }
        }

        private void PjRB_Checked(object sender, RoutedEventArgs e)
        {
            if (PjRB.IsChecked == true)
            {
                if (CNPJUC != null)
                {
                    CPFUC.Visibility = Visibility.Collapsed;
                }
                if (CPFUC != null)
                {
                    CNPJUC.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
