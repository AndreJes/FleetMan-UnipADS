using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Auxiliares;
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

namespace AppDesk.Windows.Viagens
{
    /// <summary>
    /// Lógica interna para FormRegistrarViagem.xaml
    /// </summary>
    public partial class FormRegistrarViagem : Window
    {
        public FormRegistrarViagem()
        {
            InitializeComponent();

            SeletorVeiculoUC.ListaVeiculos = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId()
                .Where(v => v.EstadoDoVeiculo == EstadosDeVeiculo.NORMAL || v.EstadoDoVeiculo == EstadosDeVeiculo.ALUGADO)
                .ToList();

            SeletorMotoristaUC.ListaMotoristas = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId()
                .Where(m => m.Estado == EstadosDeMotorista.REGULAR)
                .ToList();
        }

        #region Cancelar/Registrar
        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Viagem") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosViagem.GravarViagem(GerarViagem());
                    StandardMessageBoxes.MensagemSucesso("Viagem registrada com sucesso!", "Registro");
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

        private Viagem GerarViagem()
        {
            try
            {
                Viagem viagem = new Viagem();
                viagem.MotoristaId = SeletorMotoristaUC.Motorista.MotoristaId;
                viagem.VeiculoId = SeletorVeiculoUC.Veiculo.VeiculoId;
                viagem.EnderecoOrigem = EnderecoOrigemUC.Endereco;
                viagem.EnderecoDestino = EnderecoDestinoUC.Endereco;
                viagem.GaragemOrigem_GaragemId = SeletorVeiculoUC.Veiculo.Garagem.GaragemId;
                viagem.GaragemRetorno_GaragemId = GaragemRetornoUC.Garagem.GaragemId;
                viagem.DataSaida = DataSaidaUC.Date;
                viagem.DataChegada = null;
                viagem.QuantidadePassageiros = PassageirosUC.Value;

                return viagem;
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

        private void AtualizarOrigem_Click(object sender, RoutedEventArgs e)
        {
            if (SeletorVeiculoUC.Veiculo != null)
            {
                EnderecoOrigemUC.Endereco = SeletorVeiculoUC.Veiculo.Garagem.Endereco;
            }
            else
            {
                StandardMessageBoxes.MensagemDeErro("Nenhum veiculo selecionado!");
            }
        }
    }
}
