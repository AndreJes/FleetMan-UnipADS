using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Garagens;
using Modelo.Classes.Desk;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para SelecaoGaragemUC.xam
    /// </summary>
    public partial class SelecaoGaragemUC : UserControl, INotifyPropertyChanged
    {
        private Garagem _garagem;

        public Garagem Garagem
        {
            get
            {
                if (_garagem != null)
                {
                    return _garagem;
                }
                else
                {
                    return null;
                }
            }
            private set
            {
                _garagem = value;
                NotifyPropertyChanged();
            }
        }


        public SelecaoGaragemUC()
        {
            InitializeComponent();
            DataContext = this;
            GaragensDataGrid.ItemsSource = ServicoDados.ServicoDadosGaragem.ObterGaragensOrdPorId().Where(g => int.Parse(g.Lotacao) < g.Capacidade).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GaragemSelecionarBtn_Click(object sender, RoutedEventArgs e)
        {
            Garagem = (GaragensDataGrid.SelectedItem as Garagem);
        }

        private void GaragemDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            FormDetalhesGaragem detalhesGaragem = new FormDetalhesGaragem((GaragensDataGrid.SelectedItem as Garagem));
            detalhesGaragem.Show();
        }

        private void PesquisarGaragemBtn_Click(object sender, RoutedEventArgs e)
        {
            Garagem garagem = ServicoDados.ServicoDadosGaragem.ObterGaragensOrdPorId().Where(g => g.CNPJ == CNPJPesquisaUC.Text).FirstOrDefault();
            if (garagem != null)
            {
                Garagem = garagem;
                StandardMessageBoxes.MensagemSelecao("Garagem");
            }
            else
            {
                StandardMessageBoxes.MensagemDeErro("Garagem não encontrada!");
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
