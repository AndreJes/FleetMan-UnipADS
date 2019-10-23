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
    /// Lógica interna para FormDetalhesAlterarPeca.xaml
    /// </summary>
    public partial class FormDetalhesAlterarPeca : Window
    {
        private Peca _peca = null;
        private Fornecedor _fornecedor = null;

        private FormDetalhesAlterarPeca()
        {
            InitializeComponent();
        }

        public FormDetalhesAlterarPeca(Peca peca) : this()
        {
            _peca = peca;
            this.DataContext = _peca;
            FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
        }

        private void AlterarFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            DadosFornecedorAtualGrid.Visibility = Visibility.Collapsed;
            SelecionarNovoFornecedorGrid.Visibility = Visibility.Visible;
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração de Peça?", "Confirmar alteração", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _peca.Quantidade = int.Parse(QuantidadeTextBox.Text);
                if (_fornecedor != null)
                {
                    _peca.FornecedorId = _fornecedor.FornecedorId;
                }
                ServicoDados.ServicoDadosPeca.GravarPeca(_peca);
                MessageBox.Show("Peça alterada com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar remoção de peça?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosPeca.RemoverPecaPorId(_peca.PecaId);
                MessageBox.Show("Peca removida com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void SelecionarFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarFornecedor(FornecedoresDataGrid.SelectedItem as Fornecedor);
        }

        private void PesquisarFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            Fornecedor fornecedor = ServicoDados.ServicoDadosFornecedor.ObterFornecedorPorCNPJ(PesquisarFornecedorTextBox.Text);
            if (fornecedor != null)
            {
                MessageBox.Show("Fornecedor encontrado!");
                SelecionarFornecedor(fornecedor);
            }
            else
            {
                MessageBox.Show("Fornecedor não encontrado!");
            }
        }

        private void SelecionarFornecedor(Fornecedor fornecedor)
        {
            if (MessageBox.Show("Selecionar fornecedor?", "Confirmar seleção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _fornecedor = fornecedor;
                FornecedorSelecionadoTextBox.Text = _fornecedor.Razao_Social;
                MessageBox.Show("Fornecedor selecionado com sucesso!");
            }
        }

        private void CancelarAlteracaoBtn_Click(object sender, RoutedEventArgs e)
        {
            _fornecedor = null;
            FornecedorSelecionadoTextBox.Text = "";
            SelecionarNovoFornecedorGrid.Visibility = Visibility.Collapsed;
            DadosFornecedorAtualGrid.Visibility = Visibility.Visible;
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
