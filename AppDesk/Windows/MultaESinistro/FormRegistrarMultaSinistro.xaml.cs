using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace AppDesk.Windows.MultaESinistro
{
    /// <summary>
    /// Lógica interna para FormRegistrarMultaSinistro.xaml
    /// </summary>
    public partial class FormRegistrarMultaSinistro : Window
    {
        public FormRegistrarMultaSinistro()
        {
            InitializeComponent();
            PopularComboBoxes();
            SeletorVeiculoMultaUC.ListaVeiculos = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().Where(v => v.EstadoDoVeiculo != EstadosDeVeiculo.INATIVO).ToList();
            SeletorMotoristaMultaUC.ListaMotoristas = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId().Where(m => m.Estado != EstadosDeMotorista.INATIVO).ToList();
            SeletorVeiculoSinistro.ListaVeiculos = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().Where(v => v.EstadoDoVeiculo != EstadosDeVeiculo.INATIVO).ToList();
            SeletorMotoristaSinistro.ListaMotoristas = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId().Where(m => m.Estado != EstadosDeMotorista.INATIVO).ToList();

        }

        #region Eventos
        private void RegistrarMultaBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Multa") == MessageBoxResult.Yes)
                {
                    Multa multa = GerarMulta();
                    ServicoDados.ServicoDadosMulta.GravarMulta(multa);
                    MainWindowUpdater.UpdateDataGrids();
                    MessageBox.Show("Multa registrada com sucesso!");
                    this.Close();
                }
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.ConfirmarRegistroMessageBox(ex.Message);
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void RegistrarSinistroBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Sinistro") == MessageBoxResult.Yes)
                {
                    Sinistro sinistro = GerarSinistro();
                    ServicoDados.ServicoDadosSinistro.GravarSinistro(sinistro);
                    MainWindowUpdater.UpdateDataGrids();
                    StandardMessageBoxes.MensagemSucesso("Sinistro registrado com sucesso!", "Registro");
                    this.Close();
                }
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.ConfirmarRegistroMessageBox(ex.Message);
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }
        #endregion

        #region Métodos
        private void PopularComboBoxes()
        {

            string[] estadosDePagamento = Enum.GetNames(typeof(EstadosDePagamento));
            for (int i = 0; i < estadosDePagamento.Length; i++)
            {
                estadosDePagamento[i] = estadosDePagamento[i].Replace('_', ' ');
            }
            EstadoPagamentoInfracaoComboBox.ItemsSource = estadosDePagamento;
            EstadoPagamentoSinistroComboBox.ItemsSource = estadosDePagamento;

            GravidadeInfracaoComboBox.ItemsSource = Enum.GetNames(typeof(GravidadesDeInfracao));
            GravidadeSinistroComboBox.ItemsSource = Enum.GetNames(typeof(GravidadesDeSinistro));
        }

        private Multa GerarMulta()
        {
            try
            {
                Multa multa = new Multa();
                multa.CodigoMulta = CodigoMultaTextBox.Text;
                multa.Valor = ValorMultaUC.Valor;
                multa.DataDaMulta = DataInfraçãoUC.Date.GetValueOrDefault();
                multa.DataVencimento = DataDeVencimentoUC.Date.GetValueOrDefault();
                multa.EstadoDoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), EstadoPagamentoInfracaoComboBox.SelectedItem.ToString().Replace(' ', '_'));
                multa.GravidadeDaInfracao = (GravidadesDeInfracao)Enum.Parse(typeof(GravidadesDeInfracao), GravidadeInfracaoComboBox.SelectedItem.ToString());
                multa.MotoristaId = SeletorMotoristaMultaUC.Motorista.MotoristaId;
                multa.VeiculoId = SeletorVeiculoMultaUC.Veiculo.VeiculoId;
                return multa;
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

        private Sinistro GerarSinistro()
        {
            try
            {
                string descricao = new TextRange(DescricaoSinistroRichTextBox.Document.ContentStart, DescricaoSinistroRichTextBox.Document.ContentEnd).Text;

                Sinistro sinistro = new Sinistro();
                sinistro.CodSinistro = CodigoSinistroTextBox.Text;
                sinistro.DataSinistro = DataSinistroUC.Date.GetValueOrDefault();
                sinistro.QntEnvolvidos = QntEnvolvidosUC.Value;
                sinistro.Gravidade = (GravidadesDeSinistro)Enum.Parse(typeof(GravidadesDeSinistro), GravidadeSinistroComboBox.SelectedItem.ToString().Replace(' ', '_'));
                sinistro.EstadoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), EstadoPagamentoSinistroComboBox.SelectedItem.ToString().Replace(' ', '_'));
                sinistro.VeiculoId = SeletorVeiculoSinistro.Veiculo.VeiculoId;
                sinistro.MotoristaId = SeletorMotoristaSinistro.Motorista.MotoristaId;
                sinistro.Descricao = descricao;

                return sinistro;
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
        #endregion

    }
}
