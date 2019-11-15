using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Garagem;
using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            FormAlterarGaragem formAlterarGaragem = new FormAlterarGaragem((GaragensDataGrid.SelectedItem as Garagem));
            formAlterarGaragem.Show();
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
