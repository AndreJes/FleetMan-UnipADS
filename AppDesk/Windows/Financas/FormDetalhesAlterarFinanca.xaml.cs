using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace AppDesk.Windows.Financas
{
    /// <summary>
    /// Lógica interna para FormDetalhesAlterarFinanca.xaml
    /// </summary>
    public partial class FormDetalhesAlterarFinanca : Window
    {
        private Financa _financa = null;

        private FormDetalhesAlterarFinanca()
        {
            InitializeComponent();
        }

        public FormDetalhesAlterarFinanca(Financa financa) : this()
        {
            _financa = financa;
            this.DataContext = _financa;
            PreencherComboBox();
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            AlterarFinanca();
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Remover finança?", "Remover Finança", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosFinancas.RemoverFinancaPorId(_financa.FinancaId);
                MessageBox.Show("Finança removida com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreencherComboBox()
        {
            string[] estados = Enum.GetNames(typeof(EstadosDePagamento));

            for (int i = 0; i < estados.Length; i++)
            {
                estados[i] = estados[i].Replace('_', ' ');
            }

            PagamentoFinancaComboBox.ItemsSource = estados;
            PagamentoFinancaComboBox.SelectedItem = _financa.EstadoPagamento.ToString("G").Replace('_', ' ');
        }

        private void AlterarFinanca()
        {
            _financa.Valor = double.Parse(ValorFinancaTextBox.Text, CultureInfo.InvariantCulture);
            _financa.DataVencimento = DataVencimentoDatePicker.DisplayDate;
            _financa.EstadoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), PagamentoFinancaComboBox.SelectedItem.ToString().Replace(' ', '_'));

            if (_financa.EstadoPagamento == EstadosDePagamento.PAGO)
            {
                _financa.DataPagamento = DataPagamentoDatePicker.DisplayDate;
            }
            else
            {
                _financa.DataPagamento = null;
            }
            ServicoDados.ServicoDadosFinancas.GravarFinanca(_financa);
        }
    }
}
