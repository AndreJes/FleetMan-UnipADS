using AppDesk.Serviço;
using Modelo.Classes.Clientes;
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

namespace AppDesk.Windows.Motoristas
{
    /// <summary>
    /// Lógica interna para FormRegistrarMotorista.xaml
    /// </summary>
    public partial class FormRegistrarMotorista : Window
    {
        private Cliente clienteSelecionado = null;
        public FormRegistrarMotorista()
        {
            InitializeComponent();
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
        }
        #region Eventos
        private void PopularDataGridClienteComPF(object sender, RoutedEventArgs e)
        {
            ClientePJDataGrid.Visibility = Visibility.Collapsed;
            ClientePFDataGrid.Visibility = Visibility.Visible;
            ClientePFDataGrid.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(c => c is ClientePF).Where(c => c.Ativo == true).ToList();
        }

        private void PopularDataGridClienteComPJ(object sender, RoutedEventArgs e)
        {
            ClientePFDataGrid.Visibility = Visibility.Collapsed;
            ClientePJDataGrid.Visibility = Visibility.Visible;
            ClientePJDataGrid.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(c => c is ClientePJ).Where(c => c.Ativo == true).ToList();
        }

        private void ClienteGroupBoxToggler(object sender, RoutedEventArgs e)
        {
            if (ClienteGroupBox.Visibility == Visibility.Visible)
            {
                ClienteGroupBox.Visibility = Visibility.Collapsed;
                clienteSelecionado = null;
            }
            else
            {
                ClienteGroupBox.Visibility = Visibility.Visible;
            }
        }

        private void SelectClientePJBtn_Click(object sender, RoutedEventArgs e)
        {
            clienteSelecionado = ClientePJDataGrid.SelectedItem as ClientePJ;
            ClienteGroupBox.DataContext = clienteSelecionado;
        }

        private void SelectClientePFBtn_Click(object sender, RoutedEventArgs e)
        {
            clienteSelecionado = ClientePFDataGrid.SelectedItem as ClientePF;
            ClienteGroupBox.DataContext = clienteSelecionado;
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirmar registro de motorista?", "Confirmar Registro", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosMotorista.GravarMotorista(GerarMotorista());
                MessageBox.Show("Motorista registrado com sucesso!");
                Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().PopulateDataGrid();
                this.Close();
            }
        }
        #endregion

        private Motorista GerarMotorista()
        {
            Motorista novoMotorista = new Motorista();
            novoMotorista.Nome = NomeTextBox.Text;
            novoMotorista.CPF = CPFTextBox.Text;
            novoMotorista.RG = RGTextBox.Text;
            novoMotorista.Email = EmailTextBox.Text;
            novoMotorista.Celular = CelularTextBox.Text;
            novoMotorista.NumeroCNH = NumeroCNHTextBox.Text;
            novoMotorista.PontosCNH = int.Parse(PontosCNHTextBox.Text);
            novoMotorista.VencimentoExame = VencimentoDatePicker.DisplayDate;
            novoMotorista.Endereco = new Modelo.Classes.Auxiliares.Endereco()
            {
                Bairro = BairroTextBox.Text,
                Rua = RuaTextBox.Text,
                CEP = CEPTextBox.Text,
                Cidade = CidadeTextBox.Text,
                Numero = NumeroTextBox.Text,
                UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString())
            };
            if(MotoristaProprioCheckBox.IsChecked == true)
            {
                clienteSelecionado = null;
                novoMotorista.MotoristaProprio = true;
                novoMotorista.ClienteId = null;
            }
            else
            {
                novoMotorista.ClienteId = clienteSelecionado.ClienteId;
            }

            return novoMotorista;
        }
    }
}
