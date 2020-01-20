using AppDesk.Serviço;
using Modelo.Classes.Manutencao;
using System.Windows;

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

            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Cadastrar)
            {
                RegistrarFornecedorBtn.IsEnabled = false;
            }

            FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
        }

        private void DetalhesFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            FormDetalhesAlterarFornecedor formDetalhesAlterarFornecedor = new FormDetalhesAlterarFornecedor(
                ServicoDados.ServicoDadosFornecedor.ObterFornecedorPorId((FornecedoresDataGrid.SelectedItem as Fornecedor).FornecedorId)
                );
            formDetalhesAlterarFornecedor.Show();
        }

        private void RegistrarFornecedorBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarFornecedor formRegistrarFornecedor = new FormRegistrarFornecedor();
            formRegistrarFornecedor.ShowDialog();
        }
    }
}
