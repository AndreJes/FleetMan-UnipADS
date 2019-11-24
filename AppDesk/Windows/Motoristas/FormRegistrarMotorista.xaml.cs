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

namespace AppDesk.Windows.Motoristas
{
    /// <summary>
    /// Lógica interna para FormRegistrarMotorista.xaml
    /// </summary>
    public partial class FormRegistrarMotorista : Window
    {
        public FormRegistrarMotorista()
        {
            InitializeComponent();
            CategoriaComboBox.ItemsSource = Enum.GetNames(typeof(CategoriasCNH));
        }
        #region Eventos
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

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Motorista") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosMotorista.GravarMotorista(GerarMotorista());
                    StandardMessageBoxes.MensagemSucesso("Motorista registrado com sucesso!", "Registro");
                    MainWindowUpdater.UpdateDataGrids();
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
        #endregion

        private Motorista GerarMotorista()
        {
            try
            {
                Motorista novoMotorista = new Motorista();
                novoMotorista.Nome = NomeUC.Text;
                novoMotorista.CPF = CPFUC.Text;
                novoMotorista.RG = RGUC.Text;
                novoMotorista.Email = EmailUC.Text;
                novoMotorista.Celular = TelefoneUC.Text;
                novoMotorista.NumeroCNH = NumeroCNHUC.Text;
                novoMotorista.PontosCNH = PontosCNHUC.Value;
                novoMotorista.VencimentoExame = DataVencimentoUC.Date.GetValueOrDefault();
                novoMotorista.Endereco = EnderecoUC.Endereco;
                if (MotoristaProprioCheckBox.IsChecked == true)
                {
                    novoMotorista.MotoristaProprio = true;
                    novoMotorista.ClienteId = null;
                }
                else
                {
                    novoMotorista.ClienteId = ClienteUC.Cliente.ClienteId;
                }

                novoMotorista.Categoria = (CategoriasCNH)Enum.Parse(typeof(CategoriasCNH), CategoriaComboBox.SelectedItem.ToString());

                return novoMotorista;
            }
            catch (FieldException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
