using AppDesk.Serviço;
using AppDesk.Tools;
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
    }
}
