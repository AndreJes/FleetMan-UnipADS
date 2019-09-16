using AppDesk.Serviço;
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
    /// Lógica interna para FormAlterarMotorista.xaml
    /// </summary>
    public partial class FormAlterarMotorista : Window
    {
        private Motorista _motorista = null;

        private FormAlterarMotorista()
        {
            InitializeComponent();
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
        }

        public FormAlterarMotorista(Motorista motorista) : this()
        {
            _motorista = motorista;
            this.DataContext = _motorista;
            UfComboBox.SelectedItem = _motorista.Endereco.UF.ToString("G");
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirmar alteração de motorista?", "Confirmar Alteração", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                AlterarMotorista();
                ServicoDados.ServicoDadosMotorista.GravarMotorista(_motorista);
                MessageBox.Show("Motorista alterado com sucesso!");
                Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().PopulateDataGrid();
                FormDetalhesMotorista formDetalhesMotorista = new FormDetalhesMotorista(ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId(_motorista.MotoristaId));
                formDetalhesMotorista.Show();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AlterarMotorista()
        {
            _motorista.Nome = NomeTextBox.Text;
            _motorista.RG = RGTextBox.Text;
            _motorista.Email = EmailTextBox.Text;
            _motorista.Celular = CelularTextBox.Text;
            _motorista.NumeroCNH = NumeroCNHTextBox.Text;
            _motorista.PontosCNH = int.Parse(PontosCNHTextBox.Text);
            _motorista.VencimentoExame = VencimentoDatePicker.DisplayDate;
            _motorista.Endereco = new Modelo.Classes.Auxiliares.Endereco()
            {
                Bairro = BairroTextBox.Text,
                Rua = RuaTextBox.Text,
                CEP = CEPTextBox.Text,
                Cidade = CidadeTextBox.Text,
                Numero = NumeroTextBox.Text,
                UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString())
            };
        }
    }
}
