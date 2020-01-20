using AppDesk.Serviço;
using Modelo.Classes.Desk;
using System.Linq;
using System.Windows;

namespace AppDesk.Windows.Seguros
{
    /// <summary>
    /// Lógica interna para SegurosList.xaml
    /// </summary>
    public partial class SegurosList : Window
    {
        public SegurosList()
        {
            InitializeComponent();
            UpdateDataGrid();
            RegistrarSeguradoraBtn.IsEnabled = DesktopLoginControlService._Usuario.Permissoes.Seguros.Cadastrar;
        }

        private void RegistrarSeguradoraBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarSeguro formRegistrarSeguro = new FormRegistrarSeguro();
            formRegistrarSeguro.Show();
        }

        public void UpdateDataGrid()
        {
            SegurosDataGrid.ItemsSource = ServicoDados.ServicoDadosSeguro.ObterSegurosOrdPorId().ToList();
        }

        private void DetalhesSeguroBtn_Click(object sender, RoutedEventArgs e)
        {
            Seguro seguro = ServicoDados.ServicoDadosSeguro.ObterSeguroPorId((SegurosDataGrid.SelectedItem as Seguro).SeguroId);
            FormDetalhesSeguro formDetalhes = new FormDetalhesSeguro(seguro);
            formDetalhes.Show();
        }
    }
}
