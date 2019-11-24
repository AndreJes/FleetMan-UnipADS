using AppDesk.Interfaces;
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
    public partial class FormAlterarDetalhesAbastecimento : Window, IFillTextBoxes
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

            PreencherTextBoxes();

            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Alterar)
            {
                SalvarAlteracoesBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void SalvarAlteracoesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("Abastecimento") == MessageBoxResult.Yes)
            {
                AlterarInformacoes();
                ServicoDados.ServicoDadosAbastecimento.GravarAbastecimento(_abastecimento);
                StandardMessageBoxes.MensagemSucesso("Abastecimento alterado com sucesso!","Alteração");
                MainWindowUpdater.UpdateDataGrids();
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Abastecimento") == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosAbastecimento.RemoverAbastecimentoPorId(_abastecimento.AbastecimentoId);
                StandardMessageBoxes.MensagemSucesso("Abastecimento removido com sucesso!", "Remoção");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }


        private void AlterarInformacoes()
        {
            _abastecimento.DataConclusao = DataConclusaoUC.Date;
            _abastecimento.Valor = ValorUC.Valor;
            _abastecimento.QuantidadeAbastecida = QntCombustivelUC.Value;
            _abastecimento.Estado = EstadoAbastecimento.REALIZADO;
        }

        public void PreencherTextBoxes()
        {
            PlacaVeiculoUC.Text = _abastecimento.Veiculo.Placa;
            CPFMotoristaUC.Text = _abastecimento.Motorista.CPF;
            NomeMotoristaUC.Text = _abastecimento.Motorista.Nome;
            EnderecoUC.Endereco = _abastecimento.Local;

            if (_abastecimento.Estado == EstadoAbastecimento.AGENDADO)
            {
                DataAgendamentoUC.Date = _abastecimento.DataAgendada.GetValueOrDefault();
            }
            else if (_abastecimento.Estado == EstadoAbastecimento.REALIZADO)
            {
                DataAgendamentoUC.Date = _abastecimento.DataConclusao.GetValueOrDefault();
                DataConclusaoUC.Date = _abastecimento.DataConclusao.GetValueOrDefault();
                DataConclusaoUC.IsEnabled = false;
                QntCombustivelUC.Value = Convert.ToInt32(_abastecimento.QuantidadeAbastecida.GetValueOrDefault());
                ValorUC.Valor = _abastecimento.Valor.GetValueOrDefault();

                AbastecimentoConcluidoCheckBox.IsChecked = true;
                AbastecimentoConcluidoCheckBox.IsEnabled = false;
                SalvarAlteracoesBtn.IsEnabled = false;
            }
        }
    }
}
