using AppDesk.Serviço;
using Modelo.Classes.Web;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para SelecaoMotoristaUserControl.xam
    /// </summary>
    public partial class SelecaoMotoristaUserControl : UserControl
    {
        public Motorista Motorista { get; private set; }

        public List<Motorista> ListaMotoristas 
        {
            set
            {
                MotoristasDataGrid.ItemsSource = value;
            }
        }

        public SelecaoMotoristaUserControl()
        {
            InitializeComponent();
        }

        private void SelecionarMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarMotorista(MotoristasDataGrid.SelectedItem as Motorista);
        }

        private void PesquisarMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            Motorista motorista = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorCPF(PesquisarMotoristaTextBox.Text);
            if (motorista != null)
            {
                MessageBoxResult result = MessageBox.Show("Motorista encontrado. Deseja selecioná-lo(a) agora?", "Motorista encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SelecionarMotorista(motorista);
                }
            }
            else
            {
                MessageBox.Show("Motorista não encontrado!");
            }
        }

        private void SelecionarMotorista(Motorista motorista)
        {
            Motorista = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId(motorista.MotoristaId);
            MotoristaSelecionadoTextBox.DataContext = Motorista;
            MessageBox.Show("Motorista selecionado!");
        }

    }
}
