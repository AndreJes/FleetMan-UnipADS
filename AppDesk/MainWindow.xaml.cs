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
using AppDesk.Windows.Seguros;
using AppDesk.Windows.Garagens;
using Modelo.Classes.Desk;
using AppDesk.Windows.Veiculos;
using AppDesk.Windows.Motoristas;
using AppDesk.Windows.MultaESinistro;
using AppDesk.Windows.MultaESinistro.Multas;
using AppDesk.Windows.MultaESinistro.Sinistros;
using AppDesk.Windows.Viagens;
using AppDesk.Windows.Financas;
using AppDesk.Windows.Locacoes;
using AppDesk.Windows.Usuarios;
using AppDesk.Windows.Fornecedores;
using AppDesk.Windows.Estoque;
using Modelo.Classes.Manutencao;
using AppDesk.Windows.Abastecimentos;
using AppDesk.Windows.Manutencoes;
using AppDesk.Windows.Relatorios;
using Modelo.Classes.Relatorios;
using AppDesk.Windows.Solicitacoes;
using Modelo.Classes.Usuarios;
using Modelo.Classes.Usuarios.Permissoes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppDesk
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            LogonGridBorder.Visibility = Visibility.Visible;
            MainContentBorder.Visibility = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Botão de Voltar Ao Menu Principal
        private void BackToMainMenuGridBackBtn_Click(object sender, RoutedEventArgs e)
        {
            GotoMainMenu();
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

        //Botão de acesso ao CONTROLE de MANUTENÇÕES
        private void ManutencaoMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuPrimaryButtonsGrid.Visibility = Visibility.Collapsed;
            ManutencaoSubMenuButtonsGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de Seguros
        private void SegurosListBtn_Click(object sender, RoutedEventArgs e)
        {
            SegurosList SeguroWindow = Application.Current.Windows.OfType<SegurosList>().FirstOrDefault();
            if (SeguroWindow == null)
            {
                SeguroWindow = new SegurosList();
                SeguroWindow.Show();
            }
            else
            {
                SeguroWindow.Focus();
            }
        }

        //Botão de acesso a lista de Fornecedores
        private void FornecedoresListBtn_Click(object sender, RoutedEventArgs e)
        {
            FormFornecedoresList formFornecedoresList = Application.Current.Windows.OfType<FormFornecedoresList>().FirstOrDefault();
            if (formFornecedoresList == null)
            {
                formFornecedoresList = new FormFornecedoresList();
                formFornecedoresList.Show();
            }
            else
            {
                formFornecedoresList.Focus();
            }
        }

        #region Manutenções Sub Menu
        //Acesso a lista de manutenções
        private void ManutencaoSubMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            ManutencaoSubMenuButtonsGrid.Visibility = Visibility.Collapsed;
            ManutencoesGrid.Visibility = Visibility.Visible;
        }

        private void AbastecimentosSubMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            ManutencaoSubMenuButtonsGrid.Visibility = Visibility.Collapsed;
            AbastecimentoGrid.Visibility = Visibility.Visible;
        }

        private void EstoqueSubMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            ManutencaoSubMenuButtonsGrid.Visibility = Visibility.Collapsed;
            EstoqueGrid.Visibility = Visibility.Visible;
        }

        #endregion

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

        private void RegistrarFuncionarioBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarUsuario formRegistrarUsuario = new FormRegistrarUsuario();
            formRegistrarUsuario.Show();
        }

        private void RegistrarPecaBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarPeca formRegistrarPeca = new FormRegistrarPeca();
            formRegistrarPeca.Show();
        }

        private void RegistrarAbastecimentoBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarAbastecimento formRegistrarAbastecimento = new FormRegistrarAbastecimento();
            formRegistrarAbastecimento.Show();
        }

        private void RegistrarManutencaoBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarManutencao formRegistrarManutencao = new FormRegistrarManutencao();
            formRegistrarManutencao.Show();
        }

        private void GerarRelatorioBtn_Click(object sender, RoutedEventArgs e)
        {
            FormGerarRelatorio formGerarRelatorio = new FormGerarRelatorio();
            formGerarRelatorio.Show();
        }
        #endregion

        #region Metodos Auxiliares

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
            ManutencoesGrid.Visibility = Visibility.Collapsed;
            ManutencaoSubMenuButtonsGrid.Visibility = Visibility.Collapsed;
            EstoqueGrid.Visibility = Visibility.Collapsed;
            AbastecimentoGrid.Visibility = Visibility.Collapsed;

            MainMenuBtnsGridBorder.Visibility = Visibility.Visible;
            MainMenuPrimaryButtonsGrid.Visibility = Visibility.Visible;
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

            ViagensConcluidasDataGrid.ItemsSource = ServicoDados.ServicoDadosViagem.ObterViagensOrdPorId().Where(v => v.EstadoDaViagem == EstadosDeViagem.CONCLUIDA).ToList();

            ViagensCanceladasDataGrid.ItemsSource = ServicoDados.ServicoDadosViagem.ObterViagensOrdPorId().Where(v => v.EstadoDaViagem == EstadosDeViagem.CANCELADA).ToList();
            #endregion

            #region Solicitações
            SolicitacoesAguardandoDataGrid.ItemsSource = ServicoDados.ServicoDadosSolicitacao.ObterSolicitacoesOrdPorId().Where(s => s.Estado == EstadosDaSolicitacao.AGUARDANDO);
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

            ManutencaoDataGrid.ItemsSource = ServicoDados.ServicoDadosManutencao.ObterManutencoesOrdPorId();

            PecasDataGrid.ItemsSource = ServicoDados.ServicoDadosPeca.ObterPecasOrdPorId();

            AbastecimentosAgendadosDataGrid.ItemsSource = ServicoDados.ServicoDadosAbastecimento.ObterAbastecimentosOrdPorId().Where(a => a.Estado == EstadoAbastecimento.AGENDADO).ToList();
            AbastecimentosFinalizadosDataGrid.ItemsSource = ServicoDados.ServicoDadosAbastecimento.ObterAbastecimentosOrdPorId().Where(a => a.Estado == EstadoAbastecimento.REALIZADO).ToList();
        }

        public void StartSession()
        {
            Dispatcher.InvokeAsync(DefinirFuncoes);

            UserInfoPanel.DataContext = DesktopLoginControlService._Usuario;
            LogonGridBorder.Visibility = Visibility.Collapsed;
            MainContentBorder.Visibility = Visibility.Visible;
            PopulateDataGrid();
            GotoMainMenu();

        }

        public void DefinirFuncoes()
        {
            Permissoes permissoes = DesktopLoginControlService._Usuario.Permissoes;
            this.DataContext = this;

            #region Consultar
            if (!permissoes.Clientes.Consultar)
            {
                ClientesMainMenuBtn.IsEnabled = false;
            }
            else
            {
                ClientesMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Veiculos.Consultar)
            {
                VehicleMainMenuBtn.IsEnabled = false;
            }
            else
            {
                VehicleMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Motoristas.Consultar)
            {
                MotoristaMainMenuBtn.IsEnabled = false;
            }
            else
            {
                MotoristaMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.MultasSinistros.Consultar)
            {
                MultaSinisMainMenuBtn.IsEnabled = false;
            }
            else
            {
                MultaSinisMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Viagens.Consultar)
            {
                ViagensMainMenuBtn.IsEnabled = false;
            }
            else
            {
                ViagensMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Solicitacoes.Consultar)
            {
                SolicitacaoMainMenuBtn.IsEnabled = false;
            }
            else
            {
                SolicitacaoMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Garagens.Consultar)
            {
                GaragensMainMenuBtn.IsEnabled = false;
            }
            else
            {
                GaragensMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Locacoes.Consultar)
            {
                LocacaoMainMenuBtn.IsEnabled = false;
            }
            else
            {
                LocacaoMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Financeiro.Consultar)
            {
                FinanceiroMainMenuBtn.IsEnabled = false;
            }
            else
            {
                FinanceiroMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Relatorios.Consultar)
            {
                RelatorioMainMenuBtn.IsEnabled = false;
            }
            else
            {
                RelatorioMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Funcionarios.Consultar)
            {
                FuncionarioMainMenuBtn.IsEnabled = false;
            }
            else
            {
                FuncionarioMainMenuBtn.IsEnabled = true;
            }

            if (!permissoes.Manutencoes.Consultar)
            {
                ManutencaoMainMenuBtn.IsEnabled = false;
            }
            else
            {
                ManutencaoMainMenuBtn.IsEnabled = true;
            }
            #endregion

            #region Registrar 
            if (!permissoes.Clientes.Cadastrar)
            {
                RegistrarClienteBtn.IsEnabled = false;
            }
            else
            {
                RegistrarClienteBtn.IsEnabled = true;
            }

            if (!permissoes.Veiculos.Cadastrar)
            {
                RegistrarVeiculoBtn.IsEnabled = false;
            }
            else
            {
                RegistrarVeiculoBtn.IsEnabled = true;
            }

            if (!permissoes.Motoristas.Cadastrar)
            {
                RegistrarMotoristaBtn.IsEnabled = false;
            }
            else
            {
                RegistrarMotoristaBtn.IsEnabled = true;
            }

            if (!permissoes.MultasSinistros.Cadastrar)
            {
                RegistrarMultaSinisBtn.IsEnabled = false;
            }
            else
            {
                RegistrarMultaSinisBtn.IsEnabled = true;
            }

            if (!permissoes.Viagens.Cadastrar)
            {
                RegistrarViagemBtn.IsEnabled = false;
            }
            else
            {
                RegistrarViagemBtn.IsEnabled = true;
            }

            if (!permissoes.Garagens.Cadastrar)
            {
                RegistrarGaragemBtn.IsEnabled = false;
            }
            else
            {
                RegistrarGaragemBtn.IsEnabled = true;
            }

            if (!permissoes.Locacoes.Cadastrar)
            {
                RegistrarAluguelBtn.IsEnabled = false;
            }
            else
            {
                RegistrarAluguelBtn.IsEnabled = true;
            }

            if (!permissoes.Relatorios.Cadastrar)
            {
                GerarRelatorioBtn.IsEnabled = false;
            }
            else
            {
                GerarRelatorioBtn.IsEnabled = true;
            }

            if (!permissoes.Financeiro.Cadastrar)
            {
                RegistrarFinancaBtn.IsEnabled = false;
            }
            else
            {
                RegistrarFinancaBtn.IsEnabled = true;
            }

            if (!permissoes.Funcionarios.Cadastrar)
            {
                RegistrarFuncionarioBtn.IsEnabled = false;
            }
            else
            {
                RegistrarFuncionarioBtn.IsEnabled = true;
            }

            if (!permissoes.Manutencoes.Cadastrar)
            {
                RegistrarPecaBtn.IsEnabled = false;
            }
            else
            {
                RegistrarPecaBtn.IsEnabled = true;
            }

            if (!permissoes.Manutencoes.Cadastrar)
            {
                RegistrarAbastecimentoBtn.IsEnabled = false;
            }
            else
            {
                RegistrarAbastecimentoBtn.IsEnabled = true;
            }

            if (!permissoes.Manutencoes.Cadastrar)
            {
                RegistrarManutencaoBtn.IsEnabled = false;
            }
            else
            {
                RegistrarManutencaoBtn.IsEnabled = true;
            }
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
            FormAlterarClientes detalhesCliente = new FormAlterarClientes(clientepf);
            detalhesCliente.Show();
        }

        //Botão abre a janela de detalhes dos clientes PJ's ao clicar no botão no data grid
        private void ClientePJDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientePJ clientepj = ServicoDados.ServicoDadosClientes.ObterClientePJPorId((ClientePJDataGrid.SelectedItem as ClientePJ).ClienteId);
            FormAlterarClientes detalhesCliente = new FormAlterarClientes(clientepj);
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

            if (ViagensAguardandoDataGrid.SelectedItem != null)
            {
                viagem = ServicoDados.ServicoDadosViagem.ObterViagemPorId((ViagensAguardandoDataGrid.SelectedItem as Viagem).ViagemId);
            }
            else if (ViagensEmAndamentoDataGrid.SelectedItem != null)
            {
                viagem = ServicoDados.ServicoDadosViagem.ObterViagemPorId((ViagensEmAndamentoDataGrid.SelectedItem as Viagem).ViagemId);
            }
            else if ((ViagensConcluidasDataGrid.SelectedItem != null))
            {
                viagem = ServicoDados.ServicoDadosViagem.ObterViagemPorId((ViagensConcluidasDataGrid.SelectedItem as Viagem).ViagemId);
            }
            else if (ViagensCanceladasDataGrid.SelectedItem != null)
            {
                viagem = ServicoDados.ServicoDadosViagem.ObterViagemPorId((ViagensCanceladasDataGrid.SelectedItem as Viagem).ViagemId);
            }

            if (viagem != null)
            {
                FormDetalhesAlterarViagem formDetalhesAlterarViagem = new FormDetalhesAlterarViagem(viagem);
                formDetalhesAlterarViagem.Show();
            }
        }

        private void FinancasDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Financa financa = null;
            if (FinancaEntradaDataGrid.SelectedItem != null)
            {
                financa = ServicoDados.ServicoDadosFinancas.ObterFinancaPorId((FinancaEntradaDataGrid.SelectedItem as Financa).FinancaId);
            }
            else if (FinancaSaidaDataGrid.SelectedItem != null)
            {
                financa = ServicoDados.ServicoDadosFinancas.ObterFinancaPorId((FinancaSaidaDataGrid.SelectedItem as Financa).FinancaId);
            }

            if (financa != null)
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

        private void FuncionarioDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Funcionario funcionario = ServicoDados.ServicoDadosFuncionario.ObterFuncionarioPorId((FuncionariosDataGrid.SelectedItem as Funcionario).FuncionarioId);
            FormAlterarDetalhesUsuario formAlterarDetalhesUsuario = new FormAlterarDetalhesUsuario(funcionario);
            formAlterarDetalhesUsuario.Show();
        }

        private void PecaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Peca peca = ServicoDados.ServicoDadosPeca.ObterPecaPorId((PecasDataGrid.SelectedItem as Peca).PecaId);
            FormDetalhesAlterarPeca formDetalhesAlterarPeca = new FormDetalhesAlterarPeca(peca);
            formDetalhesAlterarPeca.Show();
        }

        private void DetalhesAbastecimentoBtn_Click(object sender, RoutedEventArgs e)
        {
            Abastecimento abastecimento = ServicoDados.ServicoDadosAbastecimento.ObterAbastecimentoPorId((AbastecimentosAgendadosDataGrid.SelectedItem as Abastecimento).AbastecimentoId);

            FormAlterarDetalhesAbastecimento formAlterarDetalhesAbastecimento = new FormAlterarDetalhesAbastecimento(abastecimento);
            formAlterarDetalhesAbastecimento.Show();
        }

        private void AbastecimentosFinDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Abastecimento abastecimento = ServicoDados.ServicoDadosAbastecimento.ObterAbastecimentoPorId((AbastecimentosFinalizadosDataGrid.SelectedItem as Abastecimento).AbastecimentoId);

            FormAlterarDetalhesAbastecimento formAlterarDetalhesAbastecimento = new FormAlterarDetalhesAbastecimento(abastecimento);
            formAlterarDetalhesAbastecimento.Show();
        }

        private void ManutencaoDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Manutencao manutencao = ServicoDados.ServicoDadosManutencao.ObterManutencaoPorId((ManutencaoDataGrid.SelectedItem as Manutencao).ManutencaoId);
            FormAlterarDetalhesManutencao formAlterarDetalhesManutencao = new FormAlterarDetalhesManutencao(manutencao);
            formAlterarDetalhesManutencao.Show();
        }


        private void RelatorioConsumoDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            RelatorioConsumo relatorioConsumo = ServicoDados.ServicoDadosRelatorio.ObterRelatorioPorId((RelatoriosAbastecimentoDataGrid.SelectedItem as RelatorioConsumo).RelatorioId, TiposRelatorios.CONSUMO) as RelatorioConsumo;
            FormDetalhesRelatorioConsumo formDetalhesRelatorioConsumo = new FormDetalhesRelatorioConsumo(relatorioConsumo);
            formDetalhesRelatorioConsumo.Show();
        }

        private void RelatorioFinanceiroDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            RelatorioFinanceiro relatorioFinanceiro = ServicoDados.ServicoDadosRelatorio.ObterRelatorioPorId((RelatoriosFinanceiroDataGrid.SelectedItem as RelatorioFinanceiro).RelatorioId, TiposRelatorios.FINANCEIRO) as RelatorioFinanceiro;
            FormDetalhesRelatorioFinanceiro formDetalhesRelatorioFinanceiro = new FormDetalhesRelatorioFinanceiro(relatorioFinanceiro);
            formDetalhesRelatorioFinanceiro.Show();
        }

        private void RelatorioManutencaoDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            RelatorioManutencao relatorioManutencao = (RelatorioManutencao)ServicoDados.ServicoDadosRelatorio.ObterRelatorioPorId((RelatoriosManutencaoDataGrid.SelectedItem as RelatorioManutencao).RelatorioId, TiposRelatorios.MANUTENCOES);
            FormDetalhesRelatorioManutencao formDetalhesRelatorioManutencao = new FormDetalhesRelatorioManutencao(relatorioManutencao);
            formDetalhesRelatorioManutencao.Show();
        }

        private void RelatorioViagensDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            RelatorioViagem relatorioViagem = (RelatorioViagem)ServicoDados.ServicoDadosRelatorio.ObterRelatorioPorId((RelatoriosViagemDataGrid.SelectedItem as RelatorioViagem).RelatorioId, TiposRelatorios.VIAGEM);
            FormDetalhesRelatorioViagens formDetalhesRelatorioViagens = new FormDetalhesRelatorioViagens(relatorioViagem);
            formDetalhesRelatorioViagens.Show();
        }

        private void RelatorioMultasDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            RelatorioMulta relatorioMulta = (RelatorioMulta)ServicoDados.ServicoDadosRelatorio.ObterRelatorioPorId((RelatoriosMultaDataGrid.SelectedItem as RelatorioMulta).RelatorioId, TiposRelatorios.MULTA);
            FormDetalhesRelatorioMultas formDetalhesRelatorioMultas = new FormDetalhesRelatorioMultas(relatorioMulta);
            formDetalhesRelatorioMultas.Show();
        }

        private void RelatorioSinistrosDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            RelatorioSinistros relatorioSinistros = (RelatorioSinistros)ServicoDados.ServicoDadosRelatorio.ObterRelatorioPorId((RelatoriosSinistroDataGrid.SelectedItem as RelatorioSinistros).RelatorioId, TiposRelatorios.ACIDENTE);
            FormDetalhesRelatorioAcidentes formDetalhesRelatorioAcidentes = new FormDetalhesRelatorioAcidentes(relatorioSinistros);
            formDetalhesRelatorioAcidentes.Show();
        }

        private void SolicitacaoAguardandoDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Solicitacao solicitacao = ServicoDados.ServicoDadosSolicitacao.ObterSolicitacaoPorId((SolicitacoesAguardandoDataGrid.SelectedItem as Solicitacao).SolicitacaoId);
            FormSolicitacaoCliente formSolicitacaoCliente = new FormSolicitacaoCliente(solicitacao);
            formSolicitacaoCliente.Show();
        }

        private void SolicitacaoReprovadaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Solicitacao solicitacao = ServicoDados.ServicoDadosSolicitacao.ObterSolicitacaoPorId((SolicitacoesReprovadasDataGrid.SelectedItem as Solicitacao).SolicitacaoId);
            FormSolicitacaoCliente formSolicitacaoCliente = new FormSolicitacaoCliente(solicitacao);
            formSolicitacaoCliente.Show();
        }

        private void SolicitacaoAprovadaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Solicitacao solicitacao = ServicoDados.ServicoDadosSolicitacao.ObterSolicitacaoPorId((SolicitacoesAprovadasDataGrid.SelectedItem as Solicitacao).SolicitacaoId);
            FormSolicitacaoCliente formSolicitacaoCliente = new FormSolicitacaoCliente(solicitacao);
            formSolicitacaoCliente.Show();
        }
        #endregion

        #region Botões Usuarios
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a sessão atual?", "Sair do sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DesktopLoginControlService.Deslogar();
                MainContentBorder.Visibility = Visibility.Collapsed;
                LogonGridBorder.Visibility = Visibility.Visible;
                MessageBox.Show("Sessão encerrada!");
            }
        }

        private void CurrentUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DesktopLoginControlService._Usuario.Funcionario != null)
            {
                FormAlterarDetalhesUsuario formAlterarDetalhes = new FormAlterarDetalhesUsuario(DesktopLoginControlService._Usuario.Funcionario);
                formAlterarDetalhes.SalvarAlteracoesBtn.IsEnabled = true;
                formAlterarDetalhes.Show();
            }
            else
            {
                StandardMessageBoxes.MensagemDeErro("Você não pode alterar as informações desse usuário");
            }
        }

        #endregion

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

    }
}
