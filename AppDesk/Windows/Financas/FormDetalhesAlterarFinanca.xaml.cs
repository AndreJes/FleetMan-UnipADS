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
            PreencherBoxes();

            if (!DesktopLoginControlService._Usuario.Permissoes.Financeiro.Alterar)
            {
                SalvarAlteracoesBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Financeiro.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Finança") == MessageBoxResult.Yes)
                {
                    AlterarFinanca();
                    StandardMessageBoxes.MensagemSucesso("Finança alterada com sucesso!", "Alteração");
                    MainWindowUpdater.UpdateDataGrids();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Remover finança?", "Remover Finança", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosFinancas.RemoverFinancaPorId(_financa.FinancaId);
                MessageBox.Show("Finança removida com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void PreencherBoxes()
        {
            string[] estados = Enum.GetNames(typeof(EstadosDePagamento));
            PagamentoFinancaComboBox.ItemsSource = estados;
            PagamentoFinancaComboBox.SelectedItem = _financa.EstadoPagamento.ToString("G").Replace('_', ' ');
            DataVencimentoUC.Date = _financa.DataVencimento.GetValueOrDefault();
            if (_financa.EstadoPagamento == EstadosDePagamento.PAGO)
            {
                DataPagamentoUC.Date = _financa.DataPagamento.GetValueOrDefault();
            }
            ValorTextBox.Valor = _financa.Valor;
        }

        private void AlterarFinanca()
        {
            try
            {
                _financa.Valor = ValorTextBox.Valor;
                _financa.DataVencimento = DataVencimentoUC.Date;
                _financa.EstadoPagamento = (EstadosDePagamento)Enum.Parse(typeof(EstadosDePagamento), PagamentoFinancaComboBox.SelectedItem.ToString().Replace(' ', '_'));

                if (_financa.EstadoPagamento == EstadosDePagamento.PAGO)
                {
                    _financa.DataPagamento = DataPagamentoUC.Date;
                }
                else
                {
                    _financa.DataPagamento = null;
                }

                ServicoDados.ServicoDadosFinancas.GravarFinanca(_financa);
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
    }
}
