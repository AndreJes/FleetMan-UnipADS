using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Manutencao;
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

namespace AppDesk.Windows.Estoque
{
    /// <summary>
    /// Lógica interna para FormRegistrarPeca.xaml
    /// </summary>
    public partial class FormRegistrarPeca : Window
    {
        private Peca _peca = new Peca();
        private Fornecedor _fornecedor = null;

        public FormRegistrarPeca()
        {
            InitializeComponent();
            FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
            this.DataContext = _peca;
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Peça") == MessageBoxResult.Yes)
            {
                _peca.Quantidade = QuantidadeUC.Value;
                ServicoDados.ServicoDadosPeca.GravarPeca(_peca);
                StandardMessageBoxes.MensagemSucesso("Peça registrada com sucesso!", "Registro");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelecionarFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarFornecedor(FornecedoresDataGrid.SelectedItem as Fornecedor);
        }

        private void PesquisarFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fornecedor fornecedor = ServicoDados.ServicoDadosFornecedor.ObterFornecedorPorCNPJ(CNPJTextBox.Text);
                if (fornecedor != null)
                {
                    MessageBox.Show("Fornecedor encontrado!");
                    SelecionarFornecedor(fornecedor);
                }
                else
                {
                    StandardMessageBoxes.MensagemDeErro("Fornecedor não encontrado!");
                }
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
            }
            catch(Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void SelecionarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                if (MessageBox.Show("Selecionar fornecedor?", "Confirmar seleção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _fornecedor = fornecedor;
                    FornecedorSelecionadoTextBox.Text = _fornecedor.Razao_Social;
                    _peca.FornecedorId = _fornecedor.FornecedorId;
                }
            }
            catch(Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }
    }
}
