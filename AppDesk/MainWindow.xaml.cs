﻿using System;
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
using Modelo.Classes.Clientes;

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
            PopulateDataGrid();
            StartGrids();
        }

        #region Botão de Voltar Ao Menu Principal
        private void BackToMainMenuGridBackBtn_Click(object sender, RoutedEventArgs e)
        {
            BackBtnFunction();
        }
        #endregion

        #region Botoes Menu Principal
        //Botão de acesso a lista de VEICULOS
        private void VehicleMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            VehicleGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de CLIENTES
        private void ClientesMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            ClientesGrid.Visibility = Visibility.Visible;
        }

        //Botão de acesso a lista de MULTAS/SINISTROS
        private void MultaSinisMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            MultaSinisGrid.Visibility = Visibility.Visible;
        }

        private void MotoristaMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Collapsed;
            MotoristasGrid.Visibility = Visibility.Visible;
        }
        #endregion

        #region Metodos Auxiliares
        //Método faz o retorno ao menu principal, escondendo os grids anteriores e exibindo apenas o grid do menu.
        private void BackBtnFunction()
        {
            VehicleGrid.Visibility = Visibility.Collapsed;
            ClientesGrid.Visibility = Visibility.Collapsed;
            MultaSinisGrid.Visibility = Visibility.Collapsed;
            MotoristasGrid.Visibility = Visibility.Collapsed;
            MainMenuBtnsGridBorder.Visibility = Visibility.Visible;
        }

        //Utilizado para iniciar o programa com os Grids corretos carregados e visiveis.
        private void StartGrids()
        {
            MainMenuBtnsGridBorder.Visibility = Visibility.Visible;
            VehicleGrid.Visibility = Visibility.Collapsed;
            ClientesGrid.Visibility = Visibility.Collapsed;
            MultaSinisGrid.Visibility = Visibility.Collapsed;
            MotoristasGrid.Visibility = Visibility.Collapsed;
        }

        //Define a fonte de dados de todos os DataGrids
        private void PopulateDataGrid()
        {
            VehicleDataGrid.ItemsSource = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().ToList();
            ClientePFDataGrid.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(cpf => cpf is ClientePF).ToList();
            ClientePJDataGrid.ItemsSource = ServicoDados.ServicoDadosClientes.ObterClientesOrdPorId().Where(cpj => cpj is ClientePJ).ToList();
            MultasDataGrid.ItemsSource = ServicoDados.ServicoDadosMulta.ObterMultasOrdPorId().ToList();
            SinistrosDataGrid.ItemsSource = ServicoDados.ServicoDadosSinistro.ObterSinistrosOrdPorId().ToList();
            MotoristasDataGrid.ItemsSource = ServicoDados.ServicoDadosMotorista.ObterMotoristasOrdPorId().ToList();
        }
        #endregion
    }
}
