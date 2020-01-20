using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Linq;
using System.Windows;

namespace AppDesk.Windows.Locacoes
{
    /// <summary>
    /// Lógica interna para FormRegistrarAluguel.xaml
    /// </summary>
    public partial class FormRegistrarAluguel : Window
    {

        public FormRegistrarAluguel()
        {
            InitializeComponent();
            SeletorVeiculoUC.ListaVeiculos = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().Where(v => v.ParaLocacao == true).Where(v => v.ClienteId == null).ToList();
        }

        private Aluguel GerarAluguel()
        {
            try
            {
                Aluguel aluguel = new Aluguel();
                aluguel.DataContratacao = DataContratacaoDP.Date.GetValueOrDefault();
                aluguel.DataVencimento = DataVencimentoDP.Date.GetValueOrDefault();

                if (AguardandoPagamentoRadioBtn.IsChecked == true)
                {
                    aluguel.EstadoDoPagamento = EstadosDePagamento.AGUARDANDO;
                }
                else if (PagoRadioBtn.IsChecked == true)
                {
                    aluguel.EstadoDoPagamento = EstadosDePagamento.PAGO;
                }
                else
                {
                    throw new FieldException("Estado do pagamento!");
                }

                aluguel.EstadoDoAluguel = EstadosAluguel.REGULAR;

                aluguel.VeiculoId = SeletorVeiculoUC.Veiculo.VeiculoId;

                aluguel.ClienteId = SeletorClienteUC.Cliente.ClienteId;

                return aluguel;
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
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Aluguel") == MessageBoxResult.Yes)
                {
                    Aluguel aluguel = GerarAluguel();
                    ServicoDados.ServicoDadosAluguel.GravarAluguel(aluguel);
                    StandardMessageBoxes.MensagemSucesso("Aluguel registrado com sucesso!", "Registro");
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
