using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Web;
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

namespace AppDesk.Windows.Viagens
{
    /// <summary>
    /// Lógica interna para FormDetalhesAlterarViagem.xaml
    /// </summary>
    public partial class FormDetalhesAlterarViagem : Window
    {
        private Viagem _viagem = null;

        private FormDetalhesAlterarViagem()
        {
            InitializeComponent();
        }

        public FormDetalhesAlterarViagem(Viagem viagem) : this()
        {
            _viagem = viagem;
            this.DataContext = _viagem;
            TipoVeiculoTextBox.Text = _viagem.Veiculo.Tipo.ToString("G").Replace('_', ' ');
            EstadoViagemTextBox.Text = _viagem.EstadoDaViagem.ToString("G").Replace('_', ' ');
            GaragemRetornoCNPJ.Text = _viagem.GaragemRetorno.CNPJTxt;
            GaragemRetornoEndereco.Text = _viagem.GaragemRetorno.EnderecoCompleto;
        }

        private void CancelarViagemBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Cancelar essa viagem?", "Cancelar Viagem", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                _viagem.EstadoDaViagem = Modelo.Enums.EstadosDeViagem.CANCELADA;
                _viagem.DataChegada = DateTime.Now;
                EstadoViagemTextBox.Text = _viagem.EstadoDaViagem.ToString("G").Replace('_', ' ');
                ServicoDados.ServicoDadosViagem.GravarViagem(_viagem);
                MessageBox.Show("Viagem cancelada com sucesso!");
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Remover essa viagem?", "Remover Viagem", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosViagem.RemoverViagemPorId(_viagem.ViagemId);
                MessageBox.Show("Viagem removida com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }
    }
}
