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
    /// Lógica interna para FormRegistrarVeiculo.xaml
    /// </summary>
    public partial class FormRegistrarVeiculo : Window
    {
        public FormRegistrarVeiculo()
        {
            InitializeComponent();
            PopularComboBoxes();
        }

        #region Eventos
        //Evento ativado ao mudar item da ComboBox de seleção de UF
        private void UFGaragemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GaragemComboBox.ItemsSource = ServicoDados.ServicoDadosGaragem.ObterGaragensOrdPorId()
                .Where(g => g.Endereco.UF == (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UFGaragemComboBox.SelectedItem.ToString()))
                .ToList();
        }

        //Evento ativado ao mudar item da ComboBox de seleção de Garagem
        private void GaragemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GaragemEnderecoTextBox.Text = (GaragemComboBox.SelectedItem as Modelo.Classes.Desk.Garagem).EnderecoParcial;
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

        //Evento popula a ComboBox de seleção de clientes apenas com Pessoas Fisicas
        private void PopularComboBoxComPF(object sender, RoutedEventArgs e)
        {
            ClienteComboBox.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(c => c is ClientePF).ToList();
        }

        //Evento popula a ComboBox de seleção de clientes apenas com Pessoas Juridicas
        private void PopularComboBoxComPJ(object sender, RoutedEventArgs e)
        {
            ClienteComboBox.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(c => c is ClientePJ).ToList();
        }
        #endregion

        private void PopularComboBoxes()
        {
            UFGaragemComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
            SeguradorasComboBox.ItemsSource = ServicoDados.ServicoDadosSeguro.ObterSegurosOrdPorId().ToList();
            List<string> tiposVeiculo = new List<string>(Enum.GetNames(typeof(TiposDeVeiculo)));
            for(int i = 0; i < tiposVeiculo.Count; i++)
            {
                string novo = tiposVeiculo[i].Replace('_', ' ');
                tiposVeiculo[i] = novo;
            }
            TipoDeVeiculoComboBox.ItemsSource = tiposVeiculo;
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = GerarVeiculo();
            ServicoDados.ServicoDadosVeiculos.GravarVeiculo(veiculo);
            MessageBox.Show("Veiculo registrado com sucesso!");
            Application.Current.Windows.OfType<MainWindow>().First().PopulateDataGrid();
            this.Close();
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Veiculo GerarVeiculo()
        {
            long? clienteId = null;
            if (PfRadioBtn.IsChecked == true)
            {
                clienteId = (ClienteComboBox.SelectedItem as ClientePF).ClienteId;
            }
            if (PjRadioBtn.IsChecked == true)
            {
                clienteId = (ClienteComboBox.SelectedItem as ClientePJ).ClienteId;
            }

            bool locacao = false;
            if(ParaLocacaoCheckBox.IsChecked == true)
            {
                locacao = true;
                clienteId = null;
            }

            bool adaptado = false;
            if(AdaptadoCheckBox.IsChecked == true)
            {
                adaptado = true;
            }

            TiposDeVeiculo tipo = (TiposDeVeiculo)Enum.Parse(typeof(TiposDeVeiculo), TipoDeVeiculoComboBox.SelectedItem.ToString().Replace(' ', '_'));
            CategoriasCNH categoria;
            switch (tipo)
            {
                case TiposDeVeiculo.MOTO:
                    categoria = CategoriasCNH.A;
                    break;
                case TiposDeVeiculo.CARRO:
                case TiposDeVeiculo.CAMINHONETE:
                case TiposDeVeiculo.UTILITARIO:
                    categoria = CategoriasCNH.B;
                    break;
                
                case TiposDeVeiculo.CAMINHAO_LEVE:
                case TiposDeVeiculo.CAMINHAO_PESADO:
                    categoria = CategoriasCNH.C;
                    break;
                case TiposDeVeiculo.VAN:
                case TiposDeVeiculo.ONIBUS:
                    categoria = CategoriasCNH.D;
                    break;
                case TiposDeVeiculo.OUTROS:
                    categoria = CategoriasCNH.B;
                    break;
                default:
                    categoria = CategoriasCNH.B;
                    break;
            }

            Veiculo veiculo = new Veiculo()
            {
                Placa = PlacaTextBox.Text,
                CodRenavam = RenavamTextBox.Text,
                Marca = MarcaTextBox.Text,
                Modelo = ModeloTextbox.Text,
                Ano = ushort.Parse(AnoTextBox.Text),
                Nome = MarcaTextBox.Text + " " + ModeloTextbox.Text + " " + AnoTextBox.Text,
                Cor = CorTextBox.Text,
                Tipo = tipo,
                ParaLocacao = locacao,
                Adaptado = adaptado,
                CategoriaExigida = categoria,
                EstadoDoTanque = EstadosTanqueCombustivel.CHEIO,
                EstadoDoVeiculo = EstadosDeVeiculo.NORMAL,
                ClienteId = clienteId,
                GaragemId = (GaragemComboBox.SelectedItem as Modelo.Classes.Desk.Garagem).GaragemId,
                SeguroId = (SeguradorasComboBox.SelectedItem as Modelo.Classes.Desk.Seguro).SeguroId
            };

            return veiculo;
        }
    }
}
