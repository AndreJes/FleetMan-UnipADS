using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Estoque;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Manutencao;
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

namespace AppDesk.Windows.Fornecedores
{
    /// <summary>
    /// Lógica interna para FormDetalhesAlterarFornecedor.xaml
    /// </summary>
    public partial class FormDetalhesAlterarFornecedor : Window
    {
        private Fornecedor _fornecedor = null;

        private FormDetalhesAlterarFornecedor()
        {
            InitializeComponent();
        }

        public FormDetalhesAlterarFornecedor(Fornecedor fornecedor) : this()
        {
            _fornecedor = fornecedor;
            this.DataContext = _fornecedor;
            EnderecoUC.Editavel = true;
            EnderecoUC.Endereco = _fornecedor.Endereco;
            PecasDataGrid.ItemsSource = _fornecedor.Pecas;
            CNPJTextbox.Text = _fornecedor.CNPJ;
            EmailTextBox.Text = _fornecedor.Email;
            NomeTextBox.Text = _fornecedor.Razao_Social;
            TelefoneTextBox.Text = _fornecedor.Telefone;

            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Alterar)
            {
                SalvarAlteracoesBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
        }



        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LojaVirtualCheckBox_Toggle(object sender, RoutedEventArgs e)
        {
            EnderecoUC.IsEnabled = !ConversorBoolNullable.ConversorBooleano(LojaVirtualCheckBox.IsChecked);
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Fornecedor") == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosFornecedor.RemoverFornecedorPorId(_fornecedor.FornecedorId);
                StandardMessageBoxes.MensagemSucesso("Fornecedor removido com sucesso!", "Remoção");
                Application.Current.Windows.OfType<FormFornecedoresList>().FirstOrDefault().FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
                this.Close();
            }
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("Fornecedor") == MessageBoxResult.Yes)
                {
                    AlterarFornecedor();
                    ServicoDados.ServicoDadosFornecedor.GravarFornecedor(_fornecedor);
                    StandardMessageBoxes.MensagemSucesso("Fornecedor alterado com sucesso!", "Alteração");
                    Application.Current.Windows.OfType<FormFornecedoresList>().FirstOrDefault().FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
                }
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

        private void PecaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Peca peca = ServicoDados.ServicoDadosPeca.ObterPecaPorId((PecasDataGrid.SelectedItem as Peca).PecaId);
            FormDetalhesAlterarPeca formDetalhesAlterarPeca = new FormDetalhesAlterarPeca(peca);
            formDetalhesAlterarPeca.Show();
        }

        private void AlterarFornecedor()
        {
            try
            {
                _fornecedor.Razao_Social = NomeTextBox.Text;
                _fornecedor.Email = EmailTextBox.Text;
                _fornecedor.Telefone = TelefoneTextBox.Text;
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
