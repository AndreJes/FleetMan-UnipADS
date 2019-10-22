using AppDesk.Serviço;
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
    /// Lógica interna para FormFornecedoresList.xaml
    /// </summary>
    public partial class FormFornecedoresList : Window
    {
        public FormFornecedoresList()
        {
            InitializeComponent();
            FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
        }

        private void DetalhesFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            FormDetalhesAlterarFornecedor formDetalhesAlterarFornecedor = new FormDetalhesAlterarFornecedor();
            formDetalhesAlterarFornecedor.Show();
        }

        private void RegistrarFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarFornecedor formRegistrarFornecedor = new FormRegistrarFornecedor();
            formRegistrarFornecedor.ShowDialog();
        }
    }
}
