using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para SelecaoMotoristaUserControl.xam
    /// </summary>
    public partial class SelecaoMotoristaUserControl : UserControl
    {
        public Motorista Motorista { get; private set; }

        public List<Motorista> ListaMotoristas
        {
            set
            {
                MotoristasDataGrid.ItemsSource = value;
            }
        }

        public SelecaoMotoristaUserControl()
        {
            InitializeComponent();
        }

        private void SelecionarMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            SelecionarMotorista(MotoristasDataGrid.SelectedItem as Motorista);
        }

        private void PesquisarMotoristaBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Motorista motorista = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorCPF(CPFTextBox.Text);
                if (motorista != null)
                {
                    MessageBoxResult result = MessageBox.Show("Motorista encontrado. Deseja selecioná-lo(a) agora?", "Motorista encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelecionarMotorista(motorista);
                    }
                }
                else
                {
                    MessageBox.Show("Motorista não encontrado!");
                }
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void SelecionarMotorista(Motorista motorista)
        {
            Motorista = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId(motorista.MotoristaId);
            MotoristaSelecionadoTextBox.DataContext = Motorista;
        }

    }
}
