using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Windows;

namespace AppDesk.Windows.Financas
{
    /// <summary>
    /// Lógica interna para FormRegistrarFinanca.xaml
    /// </summary>
    public partial class FormRegistrarFinanca : Window
    {
        public FormRegistrarFinanca()
        {
            InitializeComponent();
            PreencherComboBox();
        }

        private void PreencherComboBox()
        {
            string[] estados = Enum.GetNames(typeof(EstadosDePagamento));
            PagamentoFinancaComboBox.ItemsSource = estados;
        }

        private Financa GerarFinanca()
        {
            try
            {
                Financa financa = new Financa();
                financa.Codigo = CodigoFinancaTextBox.Text;
                financa.Descricao = "Referente a: " + ReferenciaFinancaTextBox.Text + " / " + "Comentário: " + ComentarioFinancaTextBox.Text;
                financa.Valor = ValorTextBox.Valor;
                financa.DataVencimento = DataVencimentoUC.Date;
                financa.DataPagamento = DataPagamentoUC.Date;
                financa.EstadoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), PagamentoFinancaComboBox.SelectedItem.ToString().Replace(' ', '_'));
                if (FinancaEntradaRadioBtn.IsChecked == true)
                {
                    financa.Tipo = TipoDeFinanca.ENTRADA;
                }
                if (FinancaSaidaRadioBtn.IsChecked == true)
                {
                    financa.Tipo = TipoDeFinanca.SAIDA;
                }

                return financa;
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

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Finança") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosFinancas.GravarFinanca(GerarFinanca());
                    StandardMessageBoxes.MensagemSucesso("Finança registrada com sucesso!", "Registro");
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
    }
}
