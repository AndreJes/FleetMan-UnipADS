using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Web;
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

namespace AppDesk.Windows.Solicitacoes
{
    /// <summary>
    /// Lógica interna para FormSolicitacaoCliente.xaml
    /// </summary>
    public partial class FormSolicitacaoCliente : Window
    {
        private Solicitacao _solicitacao = null;

        private FormSolicitacaoCliente()
        {
            InitializeComponent();
        }

        public FormSolicitacaoCliente(Solicitacao solicitacao) : this()
        {
            _solicitacao = solicitacao;
            switch (solicitacao.Tipo)
            {
                case TiposDeSolicitacao.ALTERACAO:
                    TipoSolicitacaoTextBox.Text = "Alteração";
                    break;
                case TiposDeSolicitacao.RENOVACAO_ALUGUEL:
                    TipoSolicitacaoTextBox.Text = "Renovação de Aluguel";
                    break;
                case TiposDeSolicitacao.CANCELAMENTO_ALUGUEL:
                    TipoSolicitacaoTextBox.Text = "Cancelamento de Aluguel";
                    break;
            }

            switch (solicitacao.TipoDeItem)
            {
                case ItemSolicitacao.ALUGUEL:
                    ItemSolicitação.Text = "Aluguel";
                    break;
                case ItemSolicitacao.CLIENTE:
                    ItemSolicitação.Text = "Cliente";
                    SolicitacaoClienteUC.Visibility = Visibility.Visible;
                    SolicitacaoClienteUC.Solicitacao = solicitacao;
                    break;
            }

            if(solicitacao.Estado != EstadosDaSolicitacao.AGUARDANDO)
            {
                AprovarBtn.IsEnabled = false;
                ReprovarBtn.IsEnabled = false;
                if(solicitacao.Estado == EstadosDaSolicitacao.APROVADA)
                {
                    EstadoSolicitacaoTextBox.Text = "Aprovada";
                }
                else
                {
                    EstadoSolicitacaoTextBox.Text = "Reprovada";
                }
            }
            else
            {
                EstadoSolicitacaoTextBox.Text = "Aguardando";
            }
        }

        private void AprovarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Aprovar Solicitação?", "Aprovar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosSolicitacao.AprovarSolicitacao(_solicitacao);
                MessageBox.Show("Solicitação aprovada com sucesso!");
                EstadoSolicitacaoTextBox.Text = "Aprovada";
                MainWindowUpdater.UpdateDataGrids();
            }
        }

        private void ReprovarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Reprovar Solicitação?", "Reprovar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosSolicitacao.ReprovarSolicitacao(_solicitacao);
                MessageBox.Show("Solicitação reprovada com sucesso!");
                EstadoSolicitacaoTextBox.Text = "Reprovada";
                MainWindowUpdater.UpdateDataGrids();
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if(StandardMessageBoxes.ConfirmarRemocaoMessageBox("Solicitação") == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosSolicitacao.RemoverSolicitacaoPorId(_solicitacao.SolicitacaoId);
                MessageBox.Show("Solicitação removida com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }
    }
}
