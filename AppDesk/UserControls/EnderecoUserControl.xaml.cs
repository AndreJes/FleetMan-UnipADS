using AppDesk.Serviço.APIs;
using AppDesk.Tools;
using Modelo.Classes.Auxiliares;
using Modelo.Enums;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para EnderecoUserControl.xam
    /// </summary>
    public partial class EnderecoUserControl : UserControl
    {
        public bool Editavel { get; set; } = true;

        public Endereco Endereco
        {
            get
            {
                Endereco endereco = new Endereco();
                endereco.Rua = RuaUC.Text;
                endereco.Numero = NumeroUC.Text;
                endereco.Bairro = BairroUC.Text;
                endereco.CEP = CEPUC.Text;
                endereco.Cidade = CidadeUC.Text;
                endereco.UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString());
                return endereco;
            }
            set
            {
                DefinirEndereco(value);
            }
        }

        public EnderecoUserControl()
        {
            InitializeComponent();
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
        }

        private void DefinirEndereco(Endereco endereco)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    this.DataContext = endereco;
                    RuaUC.Text = endereco.Rua;
                    NumeroUC.Text = endereco.Numero;
                    CidadeUC.Text = endereco.Cidade;
                    CEPUC.Text = endereco.CEP;
                    BairroUC.Text = endereco.Bairro;
                    UfComboBox.SelectedItem = endereco.UF.ToString("G");
                    if (Editavel == false)
                    {
                        BairroUC.IsEnabled = false;
                        CEPUC.IsEnabled = false;
                        CidadeUC.IsEnabled = false;
                        NumeroUC.IsEnabled = false;
                        RuaUC.IsEnabled = false;
                        UfComboBox.IsEnabled = false;
                        BuscarCepBtn.IsEnabled = false;
                    }
                });
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void BuscarCepBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Buscar();
        }

        private async void Buscar()
        {
            try
            {
                BuscarCepBtn.IsEnabled = false;
                AddressSearcher searcher = new AddressSearcher();
                Endereco endereco = await searcher.GetEnderecoByCEPAsync(CEPUC.Text);
                DefinirEndereco(endereco);
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
            finally
            {
                BuscarCepBtn.IsEnabled = true;
            }
        }
    }
}
