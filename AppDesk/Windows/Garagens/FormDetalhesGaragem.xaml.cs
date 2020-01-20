using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Veiculos;
using Modelo.Classes.Web;
using System;
using System.Windows;

namespace AppDesk.Windows.Garagens
{
    /// <summary>
    /// Lógica interna para FormDetalhesGaragem.xaml
    /// </summary>
    public partial class FormDetalhesGaragem : Window
    {
        private Modelo.Classes.Desk.Garagem _garagem = null;

        #region Construtores
        private FormDetalhesGaragem()
        {
            InitializeComponent();
        }

        public FormDetalhesGaragem(Modelo.Classes.Desk.Garagem garagem) : this()
        {
            _garagem = garagem;
            VeiculosDataGrid.ItemsSource = _garagem.Veiculos;

            if (!DesktopLoginControlService._Usuario.Permissoes.Garagens.Alterar)
            {
                AlterarBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Garagens.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
            PreencherTextBoxes();
        }
        #endregion

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Garagem") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosGaragem.RemoverGaragemPorId(_garagem.GaragemId);
                    StandardMessageBoxes.MensagemSucesso("Garagem removida com sucesso!", "Remoção");
                    MainWindowUpdater.UpdateDataGrids();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("Garagem") == MessageBoxResult.Yes)
                {
                    AlterarGaragem();
                    StandardMessageBoxes.MensagemSucesso("Garagem alterada com sucesso!", "Alteração");
                    MainWindowUpdater.UpdateDataGrids();
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

        private void PreencherTextBoxes()
        {
            CNPJTextBox.Text = _garagem.CNPJ;
            TeletoneTextBox.Text = _garagem.Telefone;
            EnderecoUC.Endereco = _garagem.Endereco;

            LotacaoTextBox.Text = _garagem.Veiculos.Count.ToString();
            CapacidadeTextBox.Text = _garagem.Capacidade.ToString();
            CapacidadeSlider.Value = _garagem.Capacidade;
            LotacaoProgressBar.Value = _garagem.Veiculos.Count;
            LotacaoProgressBar.Maximum = _garagem.Capacidade;
        }


        public void AlterarGaragem()
        {
            try
            {
                _garagem.CNPJ = CNPJTextBox.Text;
                _garagem.Telefone = TeletoneTextBox.Text;
                _garagem.Capacidade = int.Parse(CapacidadeSlider.Value.ToString());
                _garagem.Endereco = EnderecoUC.Endereco;

                ServicoDados.ServicoDadosGaragem.GravarGaragem(_garagem);
            }
            catch (FieldException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DetalhesVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId((VeiculosDataGrid.SelectedItem as Veiculo).VeiculoId);

            FormDetalhesVeiculo formDetalhesVeiculo = new FormDetalhesVeiculo(veiculo);
            formDetalhesVeiculo.Show();
        }
    }
}
