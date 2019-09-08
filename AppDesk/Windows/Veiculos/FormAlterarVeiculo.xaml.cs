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

namespace AppDesk.Windows.Veiculos
{
    /// <summary>
    /// Lógica interna para FormAlterarVeiculo.xaml
    /// </summary>
    public partial class FormAlterarVeiculo : Window
    {
        private Veiculo _veiculo = null;

        private FormAlterarVeiculo()
        {
            InitializeComponent();
        }

        public FormAlterarVeiculo(Veiculo veiculo) : this()
        {
            _veiculo = veiculo;
            PopularComboBoxes();
            DataContext = _veiculo;
        }

        #region Eventos
        //Evento ativado ao mudar item da ComboBox de seleção de UF
        private void UFGaragemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopularGaragemComboBox();
        }

        //Evento ativado ao mudar item da ComboBox de seleção de Garagem
        private void GaragemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GaragemComboBox.SelectedItem as Modelo.Classes.Desk.Garagem) != null)
            {
                GaragemEnderecoTextBox.Text = (GaragemComboBox.SelectedItem as Modelo.Classes.Desk.Garagem).EnderecoParcial;
            }
        }

        //Evento ativa a groupbox de clientes
        private void ClienteGroupBoxToggleEnable(object sender, RoutedEventArgs e)
        {
            ClienteGroupBox.IsEnabled = true;
        }

        //Evento desativa a groupbox de clientes
        private void ClienteGroupBoxToggleDisable(object sender, RoutedEventArgs e)
        {
            ClienteGroupBox.IsEnabled = false;
        }

        //Evento altera o texto do textbox que mostra a cobertura do seguro
        private void AlterarTextBoxCoberturaSeguro(object sender, SelectionChangedEventArgs e)
        {
            CoberturaTextBox.Text = (SeguradorasComboBox.SelectedItem as Modelo.Classes.Desk.Seguro).TipoCobertura.ToString("G");
        }
        #endregion

        private void PopularComboBoxes()
        {
            UFGaragemComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
            UFGaragemComboBox.SelectedItem = _veiculo.Garagem.UF.ToString();
            GaragemComboBox.SelectedItem = ServicoDados.ServicoDadosGaragem.ObterGaragemPorId(_veiculo.GaragemId);
            SeguradorasComboBox.ItemsSource = ServicoDados.ServicoDadosSeguro.ObterSegurosOrdPorId().ToList();
            SeguradorasComboBox.SelectedItem = ServicoDados.ServicoDadosSeguro.ObterSeguroPorId(_veiculo.SeguroId);
            TipoDeVeiculoTextBox.Text = _veiculo.Tipo.ToString("G");

            if (_veiculo.ClienteId == null)
            {
                ClienteGroupBox.Visibility = Visibility.Collapsed;
            }
            else if (_veiculo.Cliente is ClientePF)
            {
                CPFCNPJClienteTextBox.Text = (_veiculo.Cliente as ClientePF).CPFTxt;
            }
            else
            {
                CPFCNPJClienteTextBox.Text = (_veiculo.Cliente as ClientePJ).CNPJTxt;
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AlterarDados()
        {

            bool adaptado = _veiculo.Adaptado;
            if (AdaptadoCheckBox.IsChecked == true)
            {
                adaptado = true;
            }
            _veiculo.GaragemId = (GaragemComboBox.SelectedItem as Modelo.Classes.Desk.Garagem).GaragemId;
            _veiculo.SeguroId = (SeguradorasComboBox.SelectedItem as Modelo.Classes.Desk.Seguro).SeguroId;
        }

        private void SalvarBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Confirmar alteração de veiculo?", "Confirmar Alteração", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                AlterarDados();
                ServicoDados.ServicoDadosVeiculos.GravarVeiculo(_veiculo);
                Application.Current.Windows.OfType<MainWindow>().First().PopulateDataGrid();
                FormDetalhesVeiculo formDetalhes = new FormDetalhesVeiculo(ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId(_veiculo.VeiculoId));
                formDetalhes.Show();
                this.Close();
            }
        }

        private void PopularGaragemComboBox()
        {
            GaragemComboBox.ItemsSource = ServicoDados.ServicoDadosGaragem.ObterGaragensOrdPorId()
                .Where(g => g.Endereco.UF == (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UFGaragemComboBox.SelectedItem.ToString()))
                .ToList();
        }
    }
}
