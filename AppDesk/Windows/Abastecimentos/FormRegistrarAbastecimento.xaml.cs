using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Manutencao;
using Modelo.Enums;
using System.Linq;
using System.Windows;

namespace AppDesk.Windows.Abastecimentos
{
    /// <summary>
    /// Lógica interna para FormRegistrarAbastecimento.xaml
    /// </summary>
    public partial class FormRegistrarAbastecimento : Window
    {

        public FormRegistrarAbastecimento()
        {
            InitializeComponent();
            MotoristaUC.ListaMotoristas = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId().Where(m => m.Estado == EstadosDeMotorista.REGULAR).ToList();
            SeletorVeiculo.ListaVeiculos = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().ToList();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Abastecimento") == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosAbastecimento.GravarAbastecimento(GerarAbastecimento());
                StandardMessageBoxes.MensagemSucesso("Abastecimento registrado com sucesso!", "Registro");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private Abastecimento GerarAbastecimento()
        {
            Abastecimento abastecimento = new Abastecimento();
            abastecimento.NovoEstadoTanque = (EstadosTanqueCombustivel)int.Parse(QuantidadeSlider.Value.ToString("F0"));
            abastecimento.VeiculoId = SeletorVeiculo.Veiculo.VeiculoId;
            abastecimento.MotoristaId = MotoristaUC.Motorista.MotoristaId;

            if (AgendarRB.IsChecked == true)
            {
                abastecimento.Estado = EstadoAbastecimento.AGENDADO;
                abastecimento.DataAgendada = DataAgendamentoUC.Date;
            }
            if (RegistrarRB.IsChecked == true)
            {
                abastecimento.Estado = EstadoAbastecimento.REALIZADO;
                abastecimento.DataConclusao = DataConclusaoUC.Date;
                abastecimento.Valor = ValorUC.Valor;
            }

            abastecimento.QuantidadeAbastecida = QuantidadeLitrosUC.Value;


            abastecimento.Local = EnderecoUC.Endereco;

            return abastecimento;
        }

    }
}
