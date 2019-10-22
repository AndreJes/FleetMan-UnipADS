using AppDesk.Serviço;
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
            EnderecoUC.DataContext = _fornecedor.Endereco;
            if (!_fornecedor.LojaVirtual)
            {
                EnderecoUC.UfComboBox.SelectedItem = _fornecedor.Endereco.UF.ToString("G");
            }
            PecasDataGrid.ItemsSource = _fornecedor.Pecas;
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
            if (MessageBox.Show("Confirmar Remoção de Fornecedor?", "Confirmar Remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosFornecedor.RemoverFornecedorPorId(_fornecedor.FornecedorId);
                MessageBox.Show("Fornecedor removido com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Application.Current.Windows.OfType<FormFornecedoresList>().FirstOrDefault().FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
                this.Close();
            }
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar Alteração de Fornecedor?", "Confirmar Alteração", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (!_fornecedor.LojaVirtual)
                {
                    _fornecedor.Endereco.UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), EnderecoUC.UfComboBox.SelectedItem.ToString());
                }
                ServicoDados.ServicoDadosFornecedor.GravarFornecedor(_fornecedor);
                MessageBox.Show("Fornecedor alterado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Application.Current.Windows.OfType<FormFornecedoresList>().FirstOrDefault().FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
            }
        }

        private void PecaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Peca peca = ServicoDados.ServicoDadosPeca.ObterPecaPorId((PecasDataGrid.SelectedItem as Peca).PecaId);
            FormDetalhesAlterarPeca formDetalhesAlterarPeca = new FormDetalhesAlterarPeca(peca);
            formDetalhesAlterarPeca.Show();
        }
    }
}
