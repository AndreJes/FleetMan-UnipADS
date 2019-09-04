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
    /// Lógica interna para FormAlterarGaragem.xaml
    /// </summary>
    public partial class FormAlterarGaragem : Window
    {
        private Modelo.Classes.Desk.Garagem _garagem = null;

        private FormAlterarGaragem()
        {
            InitializeComponent();
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
        }

        public FormAlterarGaragem(Modelo.Classes.Desk.Garagem garagem) : this()
        {
            _garagem = garagem;
            PreencherTextBoxes();
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Confirmar alterações?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                AlterarGaragem();
                MessageBox.Show("Garagem alterada com sucesso!");
                Application.Current.Windows.OfType<MainWindow>().First().PopulateDataGrid();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreencherTextBoxes()
        {
            CPFCNPJTextBox.Text = _garagem.CNPJ;
            TelefoneTextBox.Text = _garagem.Telefone;
            RuaTextBox.Text = _garagem.Endereco.Rua;
            CEPTextBox.Text = _garagem.Endereco.CEP;
            BairroTextBox.Text = _garagem.Endereco.Bairro;
            UfComboBox.SelectedItem = _garagem.UF;
            NumeroTextBox.Text = _garagem.Endereco.Numero;
            CidadeTextBox.Text = _garagem.Endereco.Cidade;

            CapacidadeSlider.Value = _garagem.Capacidade;
        }

        public void AlterarGaragem()
        {
            _garagem.CNPJ = CPFCNPJTextBox.Text;
            _garagem.Telefone = TelefoneTextBox.Text;
            _garagem.Capacidade = int.Parse(CapacidadeSlider.Value.ToString());
            _garagem.Endereco.Rua = RuaTextBox.Text;
            _garagem.Endereco.Numero = NumeroTextBox.Text;
            _garagem.Endereco.CEP = CEPTextBox.Text;
            _garagem.Endereco.Bairro = BairroTextBox.Text;
            _garagem.Endereco.Cidade = CidadeTextBox.Text;
            _garagem.Endereco.UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString());

            ServicoDados.ServicoDadosGaragem.GravarGaragem(_garagem);
        }
    }
}
