using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Desk;
using Modelo.Classes.Usuarios;
using Modelo.Classes.Usuarios.Permissoes;
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

namespace AppDesk.Windows.Usuarios
{
    /// <summary>
    /// Lógica interna para FormAlterarDetalhesUsuario.xaml
    /// </summary>
    public partial class FormAlterarDetalhesUsuario : Window
    {
        private UsuarioFunc _usuario = null;
        private Funcionario _funcionario = null;

        private FormAlterarDetalhesUsuario()
        {
            InitializeComponent();
        }

        public FormAlterarDetalhesUsuario(Funcionario funcionario) : this()
        {
            _funcionario = funcionario;
            _usuario = ServicoDados.ServicoDadosUsuarioF.ObterUsuarioFuncPorId(_funcionario.FuncionarioId);

            this.DataContext = _funcionario;
            PopularPermissoes(_usuario.Permissoes);
            PreencherTextBoxes();

            if (!DesktopLoginControlService._Usuario.Permissoes.Funcionarios.Alterar)
            {
                SalvarAlteracoesBtn.IsEnabled = false;
                PermissoesTabItem.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Funcionarios.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("Usuário") == MessageBoxResult.Yes)
            {
                AlterarDadosFuncionario();
                AlterarPermissoesUsuario();
                ServicoDados.ServicoDadosUsuarioF.AlterarUsuarioFunc(_usuario);
                StandardMessageBoxes.MensagemSucesso("Dados alterados com sucesso!", "Alteração");
                MainWindowUpdater.UpdateDataGrids();
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            RemoverFuncionarioUsuario();
        }

        private void AlterarSenhaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("Senha") == MessageBoxResult.Yes)
            {
                AlterarSenhaUsuario();
            }
        }

        private void PopularPermissoes(Permissoes permissoes)
        {
            #region Veiculos
            ConsultarVeiculosCheck.IsChecked = permissoes.Veiculos.Cadastrar;
            CadastrarVeiculosCheck.IsChecked = permissoes.Veiculos.Cadastrar;
            AlterarVeiculosCheck.IsChecked = permissoes.Veiculos.Alterar;
            RemoverVeiculosCheck.IsChecked = permissoes.Veiculos.Remover;
            #endregion
            #region Motorista
            ConsultarMotoristasCheckBox.IsChecked = permissoes.Motoristas.Consultar;
            CadastrarMotoristasCheckBox.IsChecked = permissoes.Motoristas.Cadastrar;
            AlterarMotoristasCheckBox.IsChecked = permissoes.Motoristas.Alterar;
            RemoverMotoristasCheckBox.IsChecked = permissoes.Motoristas.Remover;
            #endregion
            #region Clientes
            ConsultarClientesCheckBox.IsChecked = permissoes.Clientes.Consultar;
            CadastrarClientesCheckBox.IsChecked = permissoes.Clientes.Cadastrar;
            AlterarClientesCheckBox.IsChecked = permissoes.Clientes.Alterar;
            RemoverClientesCheckBox.IsChecked = permissoes.Clientes.Remover;
            #endregion
            #region Garagens
            ConsultarGaragensCheckBox.IsChecked = permissoes.Garagens.Consultar;
            CadastrarGaragensCheckBox.IsChecked = permissoes.Garagens.Cadastrar;
            AlterarGaragensCheckBox.IsChecked = permissoes.Garagens.Alterar;
            RemoverGaragensCheckBox.IsChecked = permissoes.Garagens.Remover;
            #endregion
            #region MultasSinis
            ConsultarMultaSinisCheckBox.IsChecked = permissoes.MultasSinistros.Consultar;
            CadastrarMultaSinisCheckBox.IsChecked = permissoes.MultasSinistros.Cadastrar;
            AlterarMultaSinisCheckBox.IsChecked = permissoes.MultasSinistros.Alterar;
            RemoverMultaSinisCheckBox.IsChecked = permissoes.MultasSinistros.Remover;
            #endregion
            #region Manutencoes
            ConsultarManutencaoCheckBox.IsChecked = permissoes.Manutencoes.Consultar;
            CadastrarManutencaoCheckBox.IsChecked = permissoes.Manutencoes.Cadastrar;
            AlterarManutencaoCheckBox.IsChecked = permissoes.Manutencoes.Alterar;
            RemoverManutencaoCheckBox.IsChecked = permissoes.Manutencoes.Remover;
            #endregion
            #region Seguros
            ConsultarSeguroCheckBox.IsChecked = permissoes.Seguros.Consultar;
            CadastrarSeguroCheckBox.IsChecked = permissoes.Seguros.Cadastrar;
            AlterarSeguroCheckBox.IsChecked = permissoes.Seguros.Alterar;
            RemoverSeguroCheckBox.IsChecked = permissoes.Seguros.Remover;
            #endregion
            #region Financa
            ConsultarFinancaCheckBox.IsChecked = permissoes.Financeiro.Consultar;
            CadastrarFinancaCheckBox.IsChecked = permissoes.Financeiro.Cadastrar;
            AlterarFinancaCheckBox.IsChecked = permissoes.Financeiro.Alterar;
            RemoverFinancaCheckBox.IsChecked = permissoes.Financeiro.Remover;
            #endregion
            #region Solicitacoes
            ConsultarSolicitacaoCheckBox.IsChecked = permissoes.Solicitacoes.Consultar;
            CadastrarSolicitacaoCheckBox.IsChecked = permissoes.Solicitacoes.Cadastrar;
            AlterarSolicitacaoCheckBox.IsChecked = permissoes.Solicitacoes.Alterar;
            RemoverSolicitacaoCheckBox.IsChecked = permissoes.Solicitacoes.Remover;
            #endregion
            #region Relatorios
            ConsultarRelatorioCheckBox.IsChecked = permissoes.Relatorios.Consultar;
            CadastrarRelatorioCheckBox.IsChecked = permissoes.Relatorios.Cadastrar;
            AlterarRelatorioCheckBox.IsChecked = permissoes.Relatorios.Alterar;
            RemoverRelatorioCheckBox.IsChecked = permissoes.Relatorios.Remover;
            #endregion
            #region Locacoes
            ConsultarLocacaoCheckBox.IsChecked = permissoes.Locacoes.Consultar;
            CadastrarLocacaoCheckBox.IsChecked = permissoes.Locacoes.Cadastrar;
            AlterarLocacaoCheckBox.IsChecked = permissoes.Locacoes.Alterar;
            RemoverLocacaoCheckBox.IsChecked = permissoes.Locacoes.Remover;
            #endregion
            #region Viagens
            ConsultarViagemCheckBox.IsChecked = permissoes.Viagens.Consultar;
            CadastrarViagemCheckBox.IsChecked = permissoes.Viagens.Cadastrar;
            AlterarViagemCheckBox.IsChecked = permissoes.Viagens.Alterar;
            RemoverViagemCheckBox.IsChecked = permissoes.Viagens.Remover;
            #endregion
            #region Usuarios
            ConsultarUsuarioCheckBox.IsChecked = permissoes.Funcionarios.Consultar;
            CadastrarUsuarioCheckBox.IsChecked = permissoes.Funcionarios.Cadastrar;
            AlterarUsuarioCheckBox.IsChecked = permissoes.Funcionarios.Alterar;
            RemoverUsuarioCheckBox.IsChecked = permissoes.Funcionarios.Remover;
            #endregion
        }

        private void AlterarDadosFuncionario()
        {
            try
            {
                _funcionario.Nome = NomeTextBox.Text;
                _funcionario.RG = RGTextBox.Text;
                _funcionario.Telefone = TelefoneTextBox.Text;
                _funcionario.Email = EmailTextBox.Text;

                Endereco endereco = EnderecoUC.Endereco;

                _funcionario.Endereco = endereco;
            }
            catch(FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
            }
            catch(Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void AlterarPermissoesUsuario()
        {
            _usuario.Permissoes = GerarPermissoes();
        }

        private Permissoes GerarPermissoes()
        {
            Permissoes permissoes = new Permissoes();

            permissoes.Clientes = GerarFuncao(ConsultarClientesCheckBox.IsChecked, CadastrarClientesCheckBox.IsChecked, AlterarClientesCheckBox.IsChecked, RemoverClientesCheckBox.IsChecked);
            permissoes.Financeiro = GerarFuncao(ConsultarFinancaCheckBox.IsChecked, CadastrarFinancaCheckBox.IsChecked, AlterarFinancaCheckBox.IsChecked, RemoverFinancaCheckBox.IsChecked);
            permissoes.Funcionarios = GerarFuncao(ConsultarUsuarioCheckBox.IsChecked, CadastrarUsuarioCheckBox.IsChecked, AlterarUsuarioCheckBox.IsChecked, RemoverUsuarioCheckBox.IsChecked);
            permissoes.Garagens = GerarFuncao(ConsultarGaragensCheckBox.IsChecked, CadastrarGaragensCheckBox.IsChecked, AlterarGaragensCheckBox.IsChecked, RemoverGaragensCheckBox.IsChecked);
            permissoes.Locacoes = GerarFuncao(ConsultarLocacaoCheckBox.IsChecked, CadastrarLocacaoCheckBox.IsChecked, AlterarLocacaoCheckBox.IsChecked, RemoverLocacaoCheckBox.IsChecked);
            permissoes.Manutencoes = GerarFuncao(ConsultarManutencaoCheckBox.IsChecked, CadastrarManutencaoCheckBox.IsChecked, AlterarManutencaoCheckBox.IsChecked, RemoverManutencaoCheckBox.IsChecked);
            permissoes.Motoristas = GerarFuncao(ConsultarMotoristasCheckBox.IsChecked, CadastrarMotoristasCheckBox.IsChecked, AlterarMotoristasCheckBox.IsChecked, RemoverMotoristasCheckBox.IsChecked);
            permissoes.MultasSinistros = GerarFuncao(ConsultarMultaSinisCheckBox.IsChecked, CadastrarMultaSinisCheckBox.IsChecked, AlterarMultaSinisCheckBox.IsChecked, RemoverMultaSinisCheckBox.IsChecked);
            permissoes.Relatorios = GerarFuncao(ConsultarRelatorioCheckBox.IsChecked, CadastrarRelatorioCheckBox.IsChecked, AlterarRelatorioCheckBox.IsChecked, RemoverRelatorioCheckBox.IsChecked);
            permissoes.Seguros = GerarFuncao(ConsultarSeguroCheckBox.IsChecked, CadastrarSeguroCheckBox.IsChecked, AlterarSeguroCheckBox.IsChecked, RemoverSeguroCheckBox.IsChecked);
            permissoes.Solicitacoes = GerarFuncao(ConsultarSolicitacaoCheckBox.IsChecked, CadastrarSolicitacaoCheckBox.IsChecked, AlterarSolicitacaoCheckBox.IsChecked, RemoverSolicitacaoCheckBox.IsChecked);
            permissoes.Veiculos = GerarFuncao(ConsultarVeiculosCheck.IsChecked, CadastrarVeiculosCheck.IsChecked, AlterarVeiculosCheck.IsChecked, RemoverVeiculosCheck.IsChecked);
            permissoes.Viagens = GerarFuncao(ConsultarViagemCheckBox.IsChecked, CadastrarViagemCheckBox.IsChecked, AlterarViagemCheckBox.IsChecked, RemoverViagemCheckBox.IsChecked);
            return permissoes;
        }

        private Funcoes GerarFuncao(bool? consultar, bool? cadastrar, bool? alterar, bool? remover)
        {
            Funcoes funcoes = new Funcoes();

            if (ConversorBoolNullable.ConversorBooleano(consultar) != false)
            {
                funcoes.Consultar = ConversorBoolNullable.ConversorBooleano(consultar);
                funcoes.Cadastrar = ConversorBoolNullable.ConversorBooleano(cadastrar);
                funcoes.Alterar = ConversorBoolNullable.ConversorBooleano(alterar);
                funcoes.Remover = ConversorBoolNullable.ConversorBooleano(remover);
            }

            return funcoes;
        }

        private void AlterarSenhaUsuario()
        {
            if (_usuario.Senha == SenhaAtualPassBox.Password)
            {
                if (NovaSenhaPassBox.Password == NovaSenhaConfirmPassBox.Password)
                {
                    _usuario.Senha = NovaSenhaPassBox.Password;
                    ServicoDados.ServicoDadosUsuarioF.AlterarUsuarioFunc(_usuario);
                    StandardMessageBoxes.MensagemSucesso("Senha alterada com sucesso!", "Alteração");
                }
                else
                {
                    StandardMessageBoxes.MensagemDeErro("Não foi possível alterar a senha! A senha de confirmação deve ser igual a nova senha!");
                }
            }
            else
            {
                StandardMessageBoxes.MensagemDeErro("Senha atual invalida! Verifique se digitou os dados corretamente e tente novamente!");
            }
        }

        private void RemoverFuncionarioUsuario()
        {
            if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Usuário") == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosUsuarioF.RemoverUsuarioFuncPorId(_usuario.FuncionarioId);
                ServicoDados.ServicoDadosFuncionario.RemoverFuncionarioPorId(_funcionario.FuncionarioId);
                MainWindowUpdater.UpdateDataGrids();
                StandardMessageBoxes.MensagemSucesso("Usuário removido com sucesso!", "Remoção");
                this.Close();
            }
        }

        private void PreencherTextBoxes()
        {
            NomeTextBox.Text = _funcionario.Nome;
            CPFTextBox.Text = _funcionario.CPF;
            RGTextBox.Text = _funcionario.RG;
            EmailTextBox.Text = _funcionario.Email;
            TelefoneTextBox.Text = _funcionario.Telefone;
            EnderecoUC.Endereco = _funcionario.Endereco;
        }
    }
}
