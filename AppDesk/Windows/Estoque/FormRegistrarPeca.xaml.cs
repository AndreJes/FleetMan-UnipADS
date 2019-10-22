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
            if(MessageBox.Show("Confirmar registro de Peça?", "Confirmar registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _peca.Quantidade = int.Parse(QuantidadeTextBox.Text);
                ServicoDados.ServicoDadosPeca.GravarPeca(_peca);
                MessageBox.Show("Peça registrada com sucesso!");
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
            Fornecedor fornecedor = ServicoDados.ServicoDadosFornecedor.ObterFornecedorPorCNPJ(PesquisarFornecedorTextBox.Text);
            if(fornecedor != null)
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
            if(MessageBox.Show("Selecionar fornecedor?", "Confirmar seleção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _fornecedor = fornecedor;
                FornecedorSelecionadoTextBox.Text = _fornecedor.Razao_Social;
                _peca.FornecedorId = _fornecedor.FornecedorId;
                MessageBox.Show("Fornecedor selecionado com sucesso!");
            }
        }
    }
}
