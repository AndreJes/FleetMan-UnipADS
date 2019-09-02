using AppDesk.Serviço;
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

namespace AppDesk.Windows.Garagem
{
    /// <summary>
    /// Lógica interna para FormRegistrarGaragem.xaml
    /// </summary>
    public partial class FormRegistrarGaragem : Window
    {
        public FormRegistrarGaragem()
        {
            InitializeComponent();
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrarGaragem();
            MessageBox.Show("Garagem registrada com sucesso!");
            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().PopulateDataGrid();
            this.Close();
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void RegistrarGaragem()
        {
            ServicoDados.ServicoDadosGaragem.GravarGaragem(GerarGaragem());
        }

        public Modelo.Classes.Desk.Garagem GerarGaragem()
        {
            Modelo.Classes.Desk.Garagem garagem = new Modelo.Classes.Desk.Garagem()
            {
                CNPJ = CPFCNPJTextBox.Text,
                Telefone = TelefoneTextBox.Text,
                Capacidade = int.Parse(CapacidadeSlider.Value.ToString()),
                Endereco = new Modelo.Classes.Auxiliares.Endereco()
                {
                    Rua = RuaTextBox.Text,
                    Numero = NumeroTextBox.Text,
                    CEP = CEPTextBox.Text,
                    Bairro = BairroTextBox.Text,
                    Cidade = CidadeTextBox.Text,
                    UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString())
                }
            };
            return garagem;
        }
    }
}
