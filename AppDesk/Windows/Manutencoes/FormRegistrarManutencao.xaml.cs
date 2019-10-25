using AppDesk.Serviço;
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

namespace AppDesk.Windows.Manutencoes
{
    /// <summary>
    /// Lógica interna para FormRegistrarManutencao.xaml
    /// </summary>
    public partial class FormRegistrarManutencao : Window
    {

        public FormRegistrarManutencao()
        {
            InitializeComponent();
            PecasDataGrid.ItemsSource = ServicoDados.ServicoDadosPeca.ObterPecasOrdPorId();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelecionarPeca_Click(object sender, RoutedEventArgs e)
        {
            MoverItens(PecasDataGrid, PecasSelecionadasDataGrid);
        }

        private void RemoverPeca_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MoverItens(DataGrid origem, DataGrid destino)
        {
            Peca peca = (origem.SelectedItem as Peca);
            if (destino.Items.Contains(peca))
            {
                peca = (destino.Items[destino.Items.IndexOf(peca)] as Peca);
                destino.Items.Remove(peca);
                peca.Quantidade++;
                destino.Items.Add(peca);
            }
            else
            {
                peca.Quantidade = 1;
                destino.Items.Add(peca);
            }
        }
    }
}
