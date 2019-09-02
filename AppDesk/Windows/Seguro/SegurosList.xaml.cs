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

namespace AppDesk.Windows.Seguro
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
            FormDetalhesSeguro formDetalhes = new FormDetalhesSeguro(SegurosDataGrid.SelectedItem as Modelo.Classes.Desk.Seguro);
            formDetalhes.Show();
        }
    }
}
