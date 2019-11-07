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
        private FormSolicitacaoCliente()
        {
            InitializeComponent();
        }

        public FormSolicitacaoCliente(Solicitacao solicitacao) : this()
        {
            switch (solicitacao.Tipo)
            {
                case Modelo.Enums.TiposDeSolicitacao.INCLUSAO:
                    break;
                case Modelo.Enums.TiposDeSolicitacao.EXCLUSAO:
                    break;
                case Modelo.Enums.TiposDeSolicitacao.ALTERACAO:
                    TipoSolicitacaoTextBox.Text = "Alteração";
                    break;
                case Modelo.Enums.TiposDeSolicitacao.RENOVACAO_ALUGUEL:
                    break;
                case Modelo.Enums.TiposDeSolicitacao.CANCELAMENTO_ALUGUEL:
                    break;
            }

            switch (solicitacao.TipoDeItem)
            {
                case Modelo.Enums.ItemSolicitacao.VEICULO:
                    break;
                case Modelo.Enums.ItemSolicitacao.MOTORISTA:
                    break;
                case Modelo.Enums.ItemSolicitacao.ALUGUEL:
                    break;
                case Modelo.Enums.ItemSolicitacao.CLIENTE:
                    ItemSolicitação.Text = "Cliente";
                    SolicitacaoClienteUC.Visibility = Visibility.Visible;
                    SolicitacaoClienteUC.Solicitacao = solicitacao;
                    break;
            }

            if(solicitacao.Estado != EstadosDaSolicitacao.AGUARDANDO)
            {
                AprovarBtn.IsEnabled = false;
                ReprovarBtn.IsEnabled = false;
            }
        }

        private void AprovarBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReprovarBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
