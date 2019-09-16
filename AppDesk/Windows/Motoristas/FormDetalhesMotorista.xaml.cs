using AppDesk.Serviço;
using Modelo.Classes.Clientes;
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

namespace AppDesk.Windows.Motoristas
{
    /// <summary>
    /// Lógica interna para FormDetalhesMotorista.xaml
    /// </summary>
    public partial class FormDetalhesMotorista : Window
    {
        private Motorista _motorista = null;

        private FormDetalhesMotorista()
        {
            InitializeComponent();
        }

        public FormDetalhesMotorista(Motorista motorista) : this()
        {
            _motorista = motorista;
            this.DataContext = _motorista;
            if (_motorista.Cliente is ClientePF)
            {
                CPFCNPJClienteTextBox.Text = (_motorista.Cliente as ClientePF).CPFTxt;
            }
            else if (_motorista.Cliente is ClientePJ)
            {
                CPFCNPJClienteTextBox.Text = (_motorista.Cliente as ClientePJ).CNPJTxt;
            }
        }

        private void ClienteGroupBoxToggler(object sender, RoutedEventArgs e)
        {
            if (ClienteGroupBox.Visibility == Visibility.Visible)
            {
                ClienteGroupBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                ClienteGroupBox.Visibility = Visibility.Visible;
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Remover motorista?", "Confirmar Remoção", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosMotorista.RemoverMotoristaPorId(_motorista.MotoristaId);
                MessageBox.Show("Motorista removido com sucesso!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().PopulateDataGrid();
                this.Close();
            }
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            FormAlterarMotorista formAlterarMotorista = new FormAlterarMotorista(ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId(_motorista.MotoristaId));
            formAlterarMotorista.Show();
            this.Close();
        }
    }
}
