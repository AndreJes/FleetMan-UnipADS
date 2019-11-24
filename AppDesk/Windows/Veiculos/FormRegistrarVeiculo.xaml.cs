using AppDesk.Serviço;
using AppDesk.Tools;
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

        //Evento ativa a groupbox de clientes
        private void ClienteGroupBoxToggleEnable(object sender, RoutedEventArgs e)
        {
            ClienteTabItem.IsEnabled = true;
        }

        //Evento desativa a groupbox de clientes
        private void ClienteGroupBoxToggleDisable(object sender, RoutedEventArgs e)
        {
            ClienteTabItem.IsEnabled = false;
        }

        //Evento altera o texto do textbox que mostra a cobertura do seguro
        private void AlterarTextBoxCoberturaSeguro(object sender, SelectionChangedEventArgs e)
        {
            CoberturaTextBox.Text = (SeguradorasComboBox.SelectedItem as Modelo.Classes.Desk.Seguro).TipoCobertura.ToString("G");
        }
        #endregion

        private void PopularComboBoxes()
        {
            SeguradorasComboBox.ItemsSource = ServicoDados.ServicoDadosSeguro.ObterSegurosOrdPorId().ToList();
            List<string> tiposVeiculo = new List<string>(Enum.GetNames(typeof(TiposDeVeiculo)));
            for (int i = 0; i < tiposVeiculo.Count; i++)
            {
                string novo = tiposVeiculo[i].Replace('_', ' ');
                tiposVeiculo[i] = novo;
            }
            TipoDeVeiculoComboBox.ItemsSource = tiposVeiculo;
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Veiculo veiculo = GerarVeiculo();
                if (veiculo != null)
                {
                    ServicoDados.ServicoDadosVeiculos.GravarVeiculo(veiculo);
                    StandardMessageBoxes.MensagemSucesso("Veiculo registrado com sucesso!", "Registro");
                    Application.Current.Windows.OfType<MainWindow>().First().PopulateDataGrid();
                    this.Close();
                }
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }
        private Veiculo GerarVeiculo()
        {
            try
            {
                Veiculo veiculo = new Veiculo();
                veiculo.Placa = PlacaUC.Text;
                veiculo.CodRenavam = RenavamUC.Text;
                veiculo.Marca = MarcaUC.Text;
                veiculo.Modelo = ModeloUC.Text;
                veiculo.Ano = AnoUC.Value;
                veiculo.Cor = CorUC.Text;
                if (GaragemUC.Garagem != null)
                {
                    veiculo.GaragemId = GaragemUC.Garagem.GaragemId;
                }
                else
                {
                    throw new FieldException("Garagem");
                }
                if (SeguradorasComboBox.SelectedItem != null)
                {
                    veiculo.SeguroId = (SeguradorasComboBox.SelectedItem as Modelo.Classes.Desk.Seguro).SeguroId;
                }
                else
                {
                    throw new FieldException("Seguradora");
                }

                veiculo.ClienteId = SeletorClienteUC.Cliente.ClienteId;


                if (ParaLocacaoCheckBox.IsChecked == true)
                {
                    veiculo.ParaLocacao = true;
                }
                else
                {
                    veiculo.ParaLocacao = false;
                    veiculo.ClienteId = SeletorClienteUC.Cliente.ClienteId;
                }
                if (AdaptadoCheckBox.IsChecked == true)
                {
                    veiculo.Adaptado = true;
                }

                veiculo.Tipo = (TiposDeVeiculo)Enum.Parse(typeof(TiposDeVeiculo), TipoDeVeiculoComboBox.SelectedItem.ToString().Replace(' ', '_'));

                CategoriasCNH categoria;

                switch (veiculo.Tipo)
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

                veiculo.CategoriaExigida = categoria;

                veiculo.EstadoDoTanque = EstadosTanqueCombustivel.CHEIO;

                return veiculo;
            }
            catch (FieldException ex)
            {
                throw ex;
            }
            catch
            {
                throw new Exception("Verifique se todos os campos foram preenchidos corretamente");
            }
        }
    }
}
