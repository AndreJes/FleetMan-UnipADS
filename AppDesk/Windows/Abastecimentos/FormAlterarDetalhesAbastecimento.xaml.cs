using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.UserControls;
using Modelo.Classes.Manutencao;
using Modelo.Enums;
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

namespace AppDesk.Windows.Abastecimentos
{
    /// <summary>
    /// Lógica interna para FormAlterarDetalhesAbastecimento.xaml
    /// </summary>
    public partial class FormAlterarDetalhesAbastecimento : Window
    {
        private Abastecimento _abastecimento = null;
        private FormAlterarDetalhesAbastecimento()
        {
            InitializeComponent();
        }

        public FormAlterarDetalhesAbastecimento(Abastecimento abastecimento) : this()
        {
            _abastecimento = abastecimento;

            this.DataContext = _abastecimento;

            if (_abastecimento.Estado == EstadoAbastecimento.AGENDADO)
            {
                DataAgendamentoDatePicker.SelectedDate = abastecimento.DataAgendada;
                DataConclusaoDatePicker.IsEnabled = false;
            }
            else if (_abastecimento.Estado == EstadoAbastecimento.REALIZADO)
            {
                DataAgendamentoDatePicker.SelectedDate = abastecimento.DataConclusao;
                DataConclusaoDatePicker.SelectedDate = abastecimento.DataConclusao;
                DataConclusaoDatePicker.IsEnabled = false;

                AbastecimentoConcluidoCheckBox.IsChecked = true;
                AbastecimentoConcluidoCheckBox.IsEnabled = false;
                SalvarAlteracoesBtn.IsEnabled = false;
            }

            EnderecoUC.Endereco = _abastecimento.Local;
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração de Abastecimento?", "Confirmar alteração", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AlterarInformacoes();
                ServicoDados.ServicoDadosAbastecimento.GravarAbastecimento(_abastecimento);
                MessageBox.Show("Abastecimento alterado com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar Remoção de Abastecimento?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosAbastecimento.RemoverAbastecimentoPorId(_abastecimento.AbastecimentoId);
                MessageBox.Show("Abastecimento removido com sucesso!");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void AbastecimentoConcluidoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (_abastecimento.Estado != EstadoAbastecimento.REALIZADO)
            {
                DataConclusaoDatePicker.IsEnabled = true;
            }
        }

        private void AbastecimentoConcluidoCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            DataConclusaoDatePicker.IsEnabled = false;
        }

        private void AlterarInformacoes()
        {
            _abastecimento.DataConclusao = DataConclusaoDatePicker.SelectedDate;
            _abastecimento.Valor = double.Parse(ValorTextBox.Text);
            _abastecimento.QuantidadeAbastecida = double.Parse(QuantidadeDeCombustivelTextBox.Text);
            _abastecimento.Estado = EstadoAbastecimento.REALIZADO;
        }
    }
}
