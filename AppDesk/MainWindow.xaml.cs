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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppDesk.Serviço;
using AppDesk.Tools;

namespace AppDesk
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            VehicleDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().ToList();
            MainMenuBtnsGridBorder.Visibility = Visibility.Visible;
            VehicleGrid.Visibility = Visibility.Collapsed;
            
        }

        #region Botoes de Voltar Ao Menu Principal
        // Botão de Voltar da lista de Veiculos
        private void VehicleGridBackBtn_Click(object sender, RoutedEventArgs e)
        {
            BackBtnFunction();
        }
        #endregion

        #region Botoes Menu Principal
        //Botão de acesso as funcões de veiculos
        private void VehicleMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            VehicleGrid.Visibility = Visibility.Visible;
        }
        #endregion

        #region Metodos Auxiliares
        //Método faz o retorno ao menu principal, escondendo os grids anteriores e exibindo apenas o grid do menu.
        private void BackBtnFunction()
        {
            VehicleGrid.Visibility = Visibility.Collapsed;
            MainMenuBtnsGridBorder.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
