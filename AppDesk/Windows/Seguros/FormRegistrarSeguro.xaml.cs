using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Linq;
using System.Windows;

namespace AppDesk.Windows.Seguros
{
    /// <summary>
    /// Lógica interna para FormRegistrarSeguro.xaml
    /// </summary>
    public partial class FormRegistrarSeguro : Window
    {
        public FormRegistrarSeguro()
        {
            InitializeComponent();
            TipoCoberturaComboBox.ItemsSource = Enum.GetValues(typeof(CoberturasSeguro));
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrarSeguro();
        }

        private void RegistrarSeguro()
        {
            try
            {
                Seguro seguro = GerarSeguro();
                if (seguro != null)
                {
                    ServicoDados.ServicoDadosSeguro.GravarSeguro(seguro);
                    StandardMessageBoxes.MensagemSucesso("Seguro registrado com sucesso!", "Registro");
                    Application.Current.Windows.OfType<SegurosList>().FirstOrDefault().UpdateDataGrid();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro("Ocorreu um erro: " + Environment.NewLine + ex.Message);
            }
        }

        private Seguro GerarSeguro()
        {
            try
            {
                Seguro seguro = new Seguro();
                seguro.CNPJ = CNPJUC.Text;
                seguro.Telefone = TelefoneUC.Text;
                seguro.Email = EmailUC.Text;
                seguro.Nome = NomeUC.Text;
                seguro.DataContratacao = DataContratacaoUC.Date.GetValueOrDefault();
                seguro.Vencimento_Contrato = DataVencimentoUC.Date.GetValueOrDefault();
                seguro.DataVencimentoParcela = DataVencimentoUC.Date.GetValueOrDefault();
                seguro.PrecoParcela = ValorParcelaUC.Valor;
                seguro.TipoCobertura = (CoberturasSeguro)Enum.Parse(typeof(CoberturasSeguro), TipoCoberturaComboBox.SelectedItem.ToString());
                return seguro;
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
                throw ex;
            }
        }

    }
}
