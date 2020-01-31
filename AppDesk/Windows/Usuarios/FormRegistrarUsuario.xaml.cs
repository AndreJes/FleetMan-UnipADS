using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Desk;
using Modelo.Classes.Usuarios;
using Modelo.Classes.Usuarios.Permissoes;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppDesk.Windows.Usuarios
{
    /// <summary>
    /// Lógica interna para FormRegistrarUsuario.xaml
    /// </summary>
    public partial class FormRegistrarUsuario : Window
    {
        #region Funções/Eventos
        public FormRegistrarUsuario()
        {
            InitializeComponent();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funcionario funcionario = GerarFuncionario();

                Permissoes permissoes = GerarPermissoes();

                ServicoDados.ServicoDadosFuncionario.GravarFuncionario(funcionario);

                UsuarioFunc usuario = GerarUsuario(funcionario, permissoes);

                ServicoDados.ServicoDadosUsuarioF.GravarUsuarioFunc(usuario);

                StandardMessageBoxes.MensagemSucesso("Usuario registrado com sucesso!", "Registro");

                MainWindowUpdater.UpdateDataGrids();
                this.Close();
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

        private Funcionario GerarFuncionario()
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.CPF = CPFTextBox.Text;
                funcionario.Nome = NomeTextBox.Text;
                funcionario.RG = RGTextBox.Text;
                funcionario.Telefone = TelefoneTextBox.Text;
                funcionario.Email = EmailTextBox.Text;
                funcionario.Endereco = EnderecoUC.Endereco;
                return funcionario;
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

        private Permissoes GerarPermissoes()
        {
            Permissoes permissoes = new Permissoes();

            if (ConversorBoolNullable.ConversorBooleano(ConsultarClientesCheckBox.IsChecked))
            {
                permissoes.Clientes = GerarFuncao(ConsultarClientesCheckBox.IsChecked, CadastrarClientesCheckBox.IsChecked, AlterarClientesCheckBox.IsChecked, RemoverClientesCheckBox.IsChecked);
            }
            else
            {
                permissoes.Clientes = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false }; ;
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarFinancaCheckBox.IsChecked))
            {
                permissoes.Financeiro = GerarFuncao(ConsultarFinancaCheckBox.IsChecked, CadastrarFinancaCheckBox.IsChecked, AlterarFinancaCheckBox.IsChecked, RemoverFinancaCheckBox.IsChecked);
            }
            else
            {
                permissoes.Financeiro = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false }; ;
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarUsuarioCheckBox.IsChecked))
            {
                permissoes.Funcionarios = GerarFuncao(ConsultarUsuarioCheckBox.IsChecked, CadastrarUsuarioCheckBox.IsChecked, AlterarUsuarioCheckBox.IsChecked, RemoverUsuarioCheckBox.IsChecked);
            }
            else
            {
                permissoes.Funcionarios = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false }; ;
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarGaragensCheckBox.IsChecked))
            {
                permissoes.Garagens = GerarFuncao(ConsultarGaragensCheckBox.IsChecked, CadastrarGaragensCheckBox.IsChecked, AlterarGaragensCheckBox.IsChecked, RemoverGaragensCheckBox.IsChecked);
            }
            else
            {
                permissoes.Garagens = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false }; ;
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarLocacaoCheckBox.IsChecked))
            {
                permissoes.Locacoes = GerarFuncao(ConsultarLocacaoCheckBox.IsChecked, CadastrarLocacaoCheckBox.IsChecked, AlterarLocacaoCheckBox.IsChecked, RemoverLocacaoCheckBox.IsChecked);
            }
            else
            {
                permissoes.Locacoes = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false }; ;
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarManutencaoCheckBox.IsChecked))
            {
                permissoes.Manutencoes = GerarFuncao(ConsultarManutencaoCheckBox.IsChecked, CadastrarManutencaoCheckBox.IsChecked, AlterarManutencaoCheckBox.IsChecked, RemoverManutencaoCheckBox.IsChecked);
            }
            else
            {
                permissoes.Manutencoes = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false }; ;
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarMotoristasCheckBox.IsChecked))
            {
                permissoes.Motoristas = GerarFuncao(ConsultarMotoristasCheckBox.IsChecked, CadastrarMotoristasCheckBox.IsChecked, AlterarMotoristasCheckBox.IsChecked, RemoverMotoristasCheckBox.IsChecked);
            }
            else
            {
                permissoes.Motoristas = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false };
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarMultaSinisCheckBox.IsChecked))
            {
                permissoes.MultasSinistros = GerarFuncao(ConsultarMultaSinisCheckBox.IsChecked, CadastrarMultaSinisCheckBox.IsChecked, AlterarMultaSinisCheckBox.IsChecked, RemoverMultaSinisCheckBox.IsChecked);
            }
            else
            {
                permissoes.MultasSinistros = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false };
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarRelatorioCheckBox.IsChecked))
            {
                permissoes.Relatorios = GerarFuncao(ConsultarRelatorioCheckBox.IsChecked, CadastrarRelatorioCheckBox.IsChecked, AlterarRelatorioCheckBox.IsChecked, RemoverRelatorioCheckBox.IsChecked);
            }
            else
            {
                permissoes.Relatorios = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false };
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarSeguroCheckBox.IsChecked))
            {
                permissoes.Seguros = GerarFuncao(ConsultarSeguroCheckBox.IsChecked, CadastrarSeguroCheckBox.IsChecked, AlterarSeguroCheckBox.IsChecked, RemoverSeguroCheckBox.IsChecked);
            }
            else
            {
                permissoes.Seguros = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false };
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarSolicitacaoCheckBox.IsChecked))
            {
                permissoes.Solicitacoes = GerarFuncao(ConsultarSolicitacaoCheckBox.IsChecked, CadastrarSolicitacaoCheckBox.IsChecked, AlterarSolicitacaoCheckBox.IsChecked, RemoverSolicitacaoCheckBox.IsChecked);
            }
            else
            {
                permissoes.Solicitacoes = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false };
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarVeiculosCheck.IsChecked))
            {
                permissoes.Veiculos = GerarFuncao(ConsultarVeiculosCheck.IsChecked, CadastrarVeiculosCheck.IsChecked, AlterarVeiculosCheck.IsChecked, RemoverVeiculosCheck.IsChecked);
            }
            else
            {
                permissoes.Veiculos = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false };
            }

            if (ConversorBoolNullable.ConversorBooleano(ConsultarViagemCheckBox.IsChecked))
            {
                permissoes.Viagens = GerarFuncao(ConsultarViagemCheckBox.IsChecked, CadastrarViagemCheckBox.IsChecked, AlterarViagemCheckBox.IsChecked, RemoverViagemCheckBox.IsChecked);
            }
            else
            {
                permissoes.Viagens = new Funcoes() { Alterar = false, Cadastrar = false, Consultar = false, Remover = false };
            }

            return permissoes;

        }

        private Funcoes GerarFuncao(bool? consultar, bool? cadastrar, bool? alterar, bool? remover)
        {
            return new Funcoes()
            {
                Consultar = ConversorBoolNullable.ConversorBooleano(consultar),
                Alterar = ConversorBoolNullable.ConversorBooleano(alterar),
                Cadastrar = ConversorBoolNullable.ConversorBooleano(cadastrar),
                Remover = ConversorBoolNullable.ConversorBooleano(remover)
            };
        }

        private UsuarioFunc GerarUsuario(Funcionario funcionario, Permissoes permissoes)
        {
            UsuarioFunc usuario = new UsuarioFunc();

            usuario.FuncionarioId = ServicoDados.ServicoDadosFuncionario.ObterFuncionarioPorCPF(funcionario.CPF).FuncionarioId;
            usuario.Login = funcionario.Email;
            usuario.Senha = funcionario.RG.Substring(0, 4);
            usuario.Permissoes = permissoes;

            return usuario;
        }
        #endregion

        #region Eventos p/ Labels de permissões
        #region Filas
        private void ToggleCheckBoxRow(CheckBox cbConsultar, CheckBox cbCadastrar, CheckBox cbAlterar, CheckBox cbRemover)
        {
            bool consultar = ConversorBoolNullable.ConversorBooleano(cbConsultar.IsChecked);
            bool cadastrar = ConversorBoolNullable.ConversorBooleano(cbCadastrar.IsChecked);
            bool alterar = ConversorBoolNullable.ConversorBooleano(cbAlterar.IsChecked);
            bool remover = ConversorBoolNullable.ConversorBooleano(cbRemover.IsChecked);

            if (consultar || cadastrar || alterar || remover)
            {
                cbConsultar.IsChecked = false;
                cbCadastrar.IsChecked = false;
                cbAlterar.IsChecked = false;
                cbRemover.IsChecked = false;
            }
            else
            {
                cbConsultar.IsChecked = true;
                cbCadastrar.IsChecked = true;
                cbAlterar.IsChecked = true;
                cbRemover.IsChecked = true;
            }
        }

        private void VeiculosLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarVeiculosCheck, CadastrarVeiculosCheck, AlterarVeiculosCheck, RemoverVeiculosCheck);
        }

        private void MotoristasLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarMotoristasCheckBox, CadastrarMotoristasCheckBox, AlterarMotoristasCheckBox, RemoverMotoristasCheckBox);
        }

        private void ClienteLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarClientesCheckBox, CadastrarClientesCheckBox, AlterarClientesCheckBox, RemoverClientesCheckBox);
        }

        private void GaragensLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarGaragensCheckBox, CadastrarGaragensCheckBox, AlterarGaragensCheckBox, RemoverGaragensCheckBox);

        }

        private void MultaSinisLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarMultaSinisCheckBox, CadastrarMultaSinisCheckBox, AlterarMultaSinisCheckBox, RemoverMultaSinisCheckBox);

        }

        private void ManutenLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarManutencaoCheckBox, CadastrarManutencaoCheckBox, AlterarManutencaoCheckBox, RemoverManutencaoCheckBox);

        }

        private void SegurosLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarSeguroCheckBox, CadastrarSeguroCheckBox, AlterarSeguroCheckBox, RemoverSeguroCheckBox);
        }

        private void FinanceiroLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarFinancaCheckBox, CadastrarFinancaCheckBox, AlterarFinancaCheckBox, RemoverFinancaCheckBox);
        }

        private void SolicitacoesLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarSolicitacaoCheckBox, CadastrarSolicitacaoCheckBox, AlterarSolicitacaoCheckBox, RemoverSolicitacaoCheckBox);
        }

        private void RelatoriosLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarRelatorioCheckBox, CadastrarRelatorioCheckBox, AlterarRelatorioCheckBox, RemoverRelatorioCheckBox);

        }

        private void LocacoesLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarLocacaoCheckBox, CadastrarLocacaoCheckBox, AlterarLocacaoCheckBox, RemoverLocacaoCheckBox);

        }

        private void ViagensLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarViagemCheckBox, CadastrarViagemCheckBox, AlterarViagemCheckBox, RemoverViagemCheckBox);

        }

        private void UsuariosLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxRow(ConsultarUsuarioCheckBox, CadastrarUsuarioCheckBox, AlterarUsuarioCheckBox, RemoverUsuarioCheckBox);
        }
        #endregion
        #region Colunas
        private void ToggleCheckBoxColumn(CheckBox[] column)
        {
            foreach (CheckBox cb in column)
            {
                if (ConversorBoolNullable.ConversorBooleano(cb.IsChecked))
                {
                    foreach (CheckBox checkBox in column)
                    {
                        checkBox.IsChecked = false;
                    }

                    break;
                }
                else
                {
                    foreach (CheckBox checkBox in column)
                    {
                        checkBox.IsChecked = true;
                    }

                    break;
                }
            }
        }


        #endregion

        #endregion

        private void ConsultarLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxColumn(
                new CheckBox[]{
                    ConsultarClientesCheckBox,
                    ConsultarFinancaCheckBox,
                    ConsultarGaragensCheckBox,
                    ConsultarLocacaoCheckBox,
                    ConsultarManutencaoCheckBox,
                    ConsultarMotoristasCheckBox,
                    ConsultarMultaSinisCheckBox,
                    ConsultarRelatorioCheckBox,
                    ConsultarSeguroCheckBox,
                    ConsultarSolicitacaoCheckBox,
                    ConsultarUsuarioCheckBox,
                    ConsultarVeiculosCheck,
                    ConsultarViagemCheckBox,
                });
        }

        private void CadastrarLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxColumn(
                new CheckBox[]{
                    CadastrarClientesCheckBox,
                    CadastrarFinancaCheckBox,
                    CadastrarGaragensCheckBox,
                    CadastrarLocacaoCheckBox,
                    CadastrarManutencaoCheckBox,
                    CadastrarMotoristasCheckBox,
                    CadastrarMultaSinisCheckBox,
                    CadastrarRelatorioCheckBox,
                    CadastrarSeguroCheckBox,
                    CadastrarSolicitacaoCheckBox,
                    CadastrarUsuarioCheckBox,
                    CadastrarVeiculosCheck,
                    CadastrarViagemCheckBox,
                });
        }

        private void AlterarLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxColumn(
                new CheckBox[]{
                    AlterarClientesCheckBox,
                    AlterarFinancaCheckBox,
                    AlterarGaragensCheckBox,
                    AlterarLocacaoCheckBox,
                    AlterarManutencaoCheckBox,
                    AlterarMotoristasCheckBox,
                    AlterarMultaSinisCheckBox,
                    AlterarRelatorioCheckBox,
                    AlterarSeguroCheckBox,
                    AlterarSolicitacaoCheckBox,
                    AlterarUsuarioCheckBox,
                    AlterarVeiculosCheck,
                    AlterarViagemCheckBox,
                });
        }

        private void RemoverLabel_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ToggleCheckBoxColumn(
                new CheckBox[]{
                    RemoverClientesCheckBox,
                    RemoverFinancaCheckBox,
                    RemoverGaragensCheckBox,
                    RemoverLocacaoCheckBox,
                    RemoverManutencaoCheckBox,
                    RemoverMotoristasCheckBox,
                    RemoverMultaSinisCheckBox,
                    RemoverRelatorioCheckBox,
                    RemoverSeguroCheckBox,
                    RemoverSolicitacaoCheckBox,
                    RemoverUsuarioCheckBox,
                    RemoverVeiculosCheck,
                    RemoverViagemCheckBox,
                });
        }
    }
}
