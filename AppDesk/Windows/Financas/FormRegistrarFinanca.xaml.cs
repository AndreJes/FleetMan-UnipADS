using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Modelo.Enums;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Modelo.Classes.Desk;
using AppDesk.Serviço;
using AppDesk.Tools;

namespace AppDesk.Windows.Financas
{
    /// <summary>
    /// Lógica interna para FormRegistrarFinanca.xaml
    /// </summary>
    public partial class FormRegistrarFinanca : Window
    {
        public FormRegistrarFinanca()
        {
            InitializeComponent();
            PreencherComboBox();
        }

        private void PreencherComboBox()
        {
            string[] estados = Enum.GetNames(typeof(EstadosDePagamento));

            for (int i = 0; i < estados.Length; i++)
            {
                estados[i] = estados[i].Replace('_', ' ');
            }

            PagamentoFinancaComboBox.ItemsSource = estados;
        }

        private Financa GerarFinanca()
        {
            Financa financa = new Financa();
            financa.Codigo = CodigoFinancaTextBox.Text;
            financa.Descricao = "Referente a: " + ReferenciaFinancaTextBox.Text + " / " + ComentarioFinancaTextBox.Text;
            financa.Valor = double.Parse(ValorFinancaTextBox.Text);
            financa.DataVencimento = DataVencimentoDatePicker.DisplayDate;
            financa.DataPagamento = DataPagamentoDatePicker.DisplayDate;
            financa.EstadoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), PagamentoFinancaComboBox.SelectedItem.ToString().Replace('_', ' '));
            if (FinancaEntradaRadioBtn.IsChecked == true)
            {
                financa.Tipo = TipoDeFinanca.ENTRADA;
            }
            if(FinancaSaidaRadioBtn.IsChecked == true)
            {
                financa.Tipo = TipoDeFinanca.SAIDA;
            }

            return financa;
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Registrar Finança?", "Registrar Finança", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosFinancas.GravarFinanca(GerarFinanca());
                MessageBox.Show("Finança registrada com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
