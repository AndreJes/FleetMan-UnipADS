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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using AppDesk.Windows.Clientes;
using AppDesk.Windows.Seguro;
using AppDesk.Windows.Garagem;
using Modelo.Classes.Desk;
using AppDesk.Windows.Veiculos;
using AppDesk.Windows.Motoristas;
using AppDesk.Windows.MultaESinistro;
using AppDesk.Windows.MultaESinistro.Multas;
using AppDesk.Windows.MultaESinistro.Sinistros;
using AppDesk.Windows.Viagens;
using AppDesk.Windows.Financas;
using AppDesk.Windows.Locacoes;

namespace AppDesk
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateDataGrid();
            GotoMainMenu();
        }

        #region Botão de Voltar Ao Menu Principal
        private void BackToMainMenuGridBackBtn_Click(object sender, RoutedEventArgs e)
        {
            BackBtnFunction();
        }
        #endregion

        #region Botoes Menu Principal
        //Botão de acesso a lista de VEICULOS
        private void VehicleMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            VehicleGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de CLIENTES
        private void ClientesMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            ClientesGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de MULTAS/SINISTROS
        private void MultaSinisMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            MultaSinisGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de MOTORISTAS
        private void MotoristaMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            MotoristasGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de GARAGENS
        private void GaragensMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            GaragensGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de LOCAÇÕES
        private void LocacaoMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            LocacoesGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de VIAGENS
        private void ViagensMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            ViagensGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de SOLICITAÇÕES
        private void SolicitacaoMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            SolicitacoesGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de MANUTENÇÕES

        //Botão de acesso a lista de FINANÇAS
        private void FinanceiroMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            FinancasGrid.Visibility = Visibility.Visible;
        }
        //Botão de acesso a lista de RELATÓRIOS
        private void RelatorioMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            RelatoriosGrid.Visibility = Visibility.Visible;
        }
        //Botão de acesso a lista de FUNCIONÁRIOS
        private void FuncionarioMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            FuncionariosGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de Seguros
        private void SegurosListBtn_Click(object sender, RoutedEventArgs e)
        {
            SegurosList SeguroWindow = Application.Current.Windows.OfType<SegurosList>().FirstOrDefault();
            if(SeguroWindow == null)
            {
                SeguroWindow = new SegurosList();
                SeguroWindow.Show();
            }
            else
            {
                SeguroWindow.Focus();
            }
        }
        #endregion

        #region Botões Registro
        private void RegistrarClienteBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistroCliente formRegistroCliente = new FormRegistroCliente();
            formRegistroCliente.Show();
        }

        private void RegistrarGaragemBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarGaragem formRegistrarGaragem = new FormRegistrarGaragem();
            formRegistrarGaragem.Show();
        }

        private void RegistrarVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarVeiculo formRegistrarVeiculo = new FormRegistrarVeiculo();
            formRegistrarVeiculo.Show();
        }

        private void RegistrarMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarMotorista formRegistrarMotorista = new FormRegistrarMotorista();
            formRegistrarMotorista.Show();
        }

        private void RegistrarMultaSinisBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarMultaSinistro formRegistrarMultaSinistro = new FormRegistrarMultaSinistro();
            formRegistrarMultaSinistro.Show();
        }


        private void RegistrarViagemBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarViagem formRegistrarViagem = new FormRegistrarViagem();
            formRegistrarViagem.Show();
        }

        private void RegistrarFinancaBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarFinanca formRegistrarFinanca = new FormRegistrarFinanca();
            formRegistrarFinanca.Show();
        }

        private void RegistrarAluguelBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarAluguel formRegistrarAluguel = new FormRegistrarAluguel();
            formRegistrarAluguel.Show();
        }
        #endregion

        #region Metodos Auxiliares
        //Método faz o retorno ao menu principal, escondendo os grids anteriores e exibindo apenas o grid do menu.
        private void BackBtnFunction()
        {
            GotoMainMenu();
        }

        //Utilizado para iniciar o programa com os Grids corretos carregados e visiveis.
        private void GotoMainMenu()
        {
            VehicleGrid.Visibility = Visibility.Collapsed;
            ClientesGrid.Visibility = Visibility.Collapsed;
            MultaSinisGrid.Visibility = Visibility.Collapsed;
            MotoristasGrid.Visibility = Visibility.Collapsed;
            GaragensGrid.Visibility = Visibility.Collapsed;
            LocacoesGrid.Visibility = Visibility.Collapsed;
            ViagensGrid.Visibility = Visibility.Collapsed;
            SolicitacoesGrid.Visibility = Visibility.Collapsed;
            FinancasGrid.Visibility = Visibility.Collapsed;
            FuncionariosGrid.Visibility = Visibility.Collapsed;
            RelatoriosGrid.Visibility = Visibility.Collapsed;
            MainMenuBtnsGridBorder.Visibility = Visibility.Visible;
        }

        //Define a fonte de dados de todos os DataGrids
        public void PopulateDataGrid()
        {
            VehicleDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().ToList();

            #region Clientes
            ClientePFDataGrid.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(cpf => cpf is ClientePF).ToList();
            ClientePJDataGrid.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(cpj => cpj is ClientePJ).ToList();
            #endregion

            #region Multas/Sinistros
            MultasDataGrid.ItemsSource = ServicoDados.ServicoDadosMulta.ObterMultasOrdPorId().ToList();
            SinistrosDataGrid.ItemsSource = ServicoDados.ServicoDadosSinistro.ObterSinistrosOrdPorId().ToList();
            #endregion

            MotoristasDataGrid.ItemsSource = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId().ToList();

            GaragensDataGrid.ItemsSource = ServicoDados.ServicoDadosGaragem.ObterGaragensOrdPorId().ToList();

            LocacoesDataGrid.ItemsSource = ServicoDados.ServicoDadosAluguel.ObterAlugueisOrdPorId().ToList();

            #region Viagens
            ViagensAguardandoDataGrid.ItemsSource = ServicoDados.ServicoDadosViagem.ObterViagensOrdPorId().Where(v => v.EstadoDaViagem == EstadosDeViagem.AGUARDANDO_INICIO).ToList();

            ViagensEmAndamentoDataGrid.ItemsSource = ServicoDados.ServicoDadosViagem.ObterViagensOrdPorId().Where(v => v.EstadoDaViagem == EstadosDeViagem.EM_ANDAMENTO).ToList();

            List<Viagem> ViagensConcluidasECanceladas = new List<Viagem>();
            ViagensConcluidasECanceladas.AddRange(ServicoDados.ServicoDadosViagem.ObterViagensOrdPorId().Where(v => v.EstadoDaViagem == EstadosDeViagem.CONCLUIDA));
            ViagensConcluidasECanceladas.AddRange(ServicoDados.ServicoDadosViagem.ObterViagensOrdPorId().Where(v => v.EstadoDaViagem == EstadosDeViagem.CANCELADA));
            ViagensConcluidasDataGrid.ItemsSource = ViagensConcluidasECanceladas;
            #endregion

            #region Solicitações
            SolicitacoesAguardandoDataGrid.ItemsSource = ServicoDados.ServicoDadosSolicitacao.ObterSolicitacoesOrdPorId().Where(s => s.Estado == EstadosDaSolicitacao.AGUARDANDO_APROVACAO);
            SolicitacoesAprovadasDataGrid.ItemsSource = ServicoDados.ServicoDadosSolicitacao.ObterSolicitacoesOrdPorId().Where(s => s.Estado == EstadosDaSolicitacao.APROVADA);
            SolicitacoesReprovadasDataGrid.ItemsSource = ServicoDados.ServicoDadosSolicitacao.ObterSolicitacoesOrdPorId().Where(s => s.Estado == EstadosDaSolicitacao.REPROVADA);
            #endregion

            #region Finanças
            FinancaEntradaDataGrid.ItemsSource = ServicoDados.ServicoDadosFinancas.ObterFinancasOrdPorId().Where(f => f.Tipo == TipoDeFinanca.ENTRADA).ToList();
            FinancaSaidaDataGrid.ItemsSource = ServicoDados.ServicoDadosFinancas.ObterFinancasOrdPorId().Where(f => f.Tipo == TipoDeFinanca.SAIDA).ToList();
            #endregion

            #region Funcionarios
            FuncionariosDataGrid.ItemsSource = ServicoDados.ServicoDadosFuncionario.ObterFuncionariosOrdPorId().ToList();
            //TODO: Separar funcionarios Ativos/Inativos.
            #endregion

            #region Relatórios
            RelatoriosAbastecimentoDataGrid.ItemsSource = ServicoDados.ServicoDadosRelatorio.ObterRelatoriosConsumoOrdPorId().ToList();
            RelatoriosFinanceiroDataGrid.ItemsSource = ServicoDados.ServicoDadosRelatorio.ObterRelatoriosFinanceiroOrdPorId().ToList();
            RelatoriosManutencaoDataGrid.ItemsSource = ServicoDados.ServicoDadosRelatorio.ObterRelatoriosManutencaoOrdPorId().ToList();
            RelatoriosMultaDataGrid.ItemsSource = ServicoDados.ServicoDadosRelatorio.ObterRelatoriosMultaOrdPorId().ToList();
            RelatoriosSinistroDataGrid.ItemsSource = ServicoDados.ServicoDadosRelatorio.ObterRelatoriosAcidenteOrdPorId().ToList();
            RelatoriosViagemDataGrid.ItemsSource = ServicoDados.ServicoDadosRelatorio.ObterRelatoriosViagemOrdPorId().ToList();
            #endregion
        }

        #endregion

        #region Botões de detalhes
        //Botões de detalhes de Clientes PJ e PF
        #region Clientes
        //Botão abre a janela de detalhes dos clientes PF's ao clicar no botão no data grid
        private void ClientePFDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientePF clientepf = ServicoDados.ServicoDadosClientes.ObterClientePFPorId((ClientePFDataGrid.SelectedItem as ClientePF).ClienteId);
            FormDetalhesCliente detalhesCliente = new FormDetalhesCliente(clientepf);
            detalhesCliente.Show();
        }

        //Botão abre a janela de detalhes dos clientes PJ's ao clicar no botão no data grid
        private void ClientePJDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientePJ clientepj = ServicoDados.ServicoDadosClientes.ObterClientePJPorId((ClientePJDataGrid.SelectedItem as ClientePJ).ClienteId);
            FormDetalhesCliente detalhesCliente = new FormDetalhesCliente(clientepj);
            detalhesCliente.Show();
        }
        #endregion

        // Botão Detalhes de garagem
        private void GaragemDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Garagem garagem = ServicoDados.ServicoDadosGaragem.ObterGaragemPorId((GaragensDataGrid.SelectedItem as Garagem).GaragemId);
            FormDetalhesGaragem formDetalhesGaragem = new FormDetalhesGaragem(garagem);
            formDetalhesGaragem.Show();
        }

        //Botão de Detalhes de Veiculos
        private void DetalhesVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId((VehicleDataGrid.SelectedItem as Veiculo).VeiculoId);
            FormDetalhesVeiculo formDetalhesVeiculo = new FormDetalhesVeiculo(veiculo);
            formDetalhesVeiculo.Show();
        }

        private void MotoristaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Motorista motorista = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId((MotoristasDataGrid.SelectedItem as Motorista).MotoristaId);
            FormDetalhesMotorista formDetalhesMotorista = new FormDetalhesMotorista(motorista);
            formDetalhesMotorista.Show();
        }


        private void MultaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Multa multa = ServicoDados.ServicoDadosMulta.ObterMultaPorId((MultasDataGrid.SelectedItem as Multa).MultaId);
            FormDetalhesAlterarMulta formDetalhesAlterarMulta = new FormDetalhesAlterarMulta(multa);
            formDetalhesAlterarMulta.Show();
        }


        private void DetalhesSinistroBtn_Click(object sender, RoutedEventArgs e)
        {
            Sinistro sinistro = ServicoDados.ServicoDadosSinistro.ObterSinistroPorId((SinistrosDataGrid.SelectedItem as Sinistro).SinistroId);
            FormDetalhesAlterarSinistro formDetalhesAlterarSinistro = new FormDetalhesAlterarSinistro(sinistro);
            formDetalhesAlterarSinistro.Show();
        }

        private void DetalhesViagemBtn_Click(object sender, RoutedEventArgs e)
        {
            Viagem viagem = null;

            if(ViagensAguardandoDataGrid.SelectedItem != null)
            {
                viagem = ServicoDados.ServicoDadosViagem.ObterViagemPorId((ViagensAguardandoDataGrid.SelectedItem as Viagem).ViagemId);
            }
            else if(ViagensEmAndamentoDataGrid.SelectedItem != null)
            {
                viagem = ServicoDados.ServicoDadosViagem.ObterViagemPorId((ViagensEmAndamentoDataGrid.SelectedItem as Viagem).ViagemId);
            }
            else if((ViagensConcluidasDataGrid.SelectedItem != null))
            {
                viagem = ServicoDados.ServicoDadosViagem.ObterViagemPorId((ViagensConcluidasDataGrid.SelectedItem as Viagem).ViagemId);
            }

            if(viagem != null)
            {
                FormDetalhesAlterarViagem formDetalhesAlterarViagem = new FormDetalhesAlterarViagem(viagem);
                formDetalhesAlterarViagem.Show();
            }
        }

        private void FinancasDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Financa financa = null;
            if(FinancaEntradaDataGrid.SelectedItem != null)
            {
                financa = ServicoDados.ServicoDadosFinancas.ObterFinancaPorId((FinancaEntradaDataGrid.SelectedItem as Financa).FinancaId);
            }
            else if(FinancaSaidaDataGrid.SelectedItem != null)
            {
                financa = ServicoDados.ServicoDadosFinancas.ObterFinancaPorId((FinancaSaidaDataGrid.SelectedItem as Financa).FinancaId);
            }

            if(financa != null)
            {
                FormDetalhesAlterarFinanca formDetalhesAlterarFinanca = new FormDetalhesAlterarFinanca(financa);
                formDetalhesAlterarFinanca.Show();
            }
        }

        private void AluguelDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Aluguel aluguel = ServicoDados.ServicoDadosAluguel.ObterAluguelPorId((LocacoesDataGrid.SelectedItem as Aluguel).AluguelId);
            FormDetalhesAlterarAluguel formDetalhesAlterarAluguel = new FormDetalhesAlterarAluguel(aluguel);
            formDetalhesAlterarAluguel.Show();
        }
        #endregion

    }
}
