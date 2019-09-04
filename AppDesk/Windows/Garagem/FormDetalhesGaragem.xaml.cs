using AppDesk.Serviço;
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

namespace AppDesk.Windows.Garagem
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
            PreencherTextBoxes();
        }
        #endregion

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Confirmar remoção de garagem?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(messageBox == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosGaragem.RemoverGaragemPorId(_garagem.GaragemId);
                this.Close();
                Application.Current.Windows.OfType<MainWindow>().First().PopulateDataGrid();
            }
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            FormAlterarGaragem formAlterar = new FormAlterarGaragem(_garagem);
            formAlterar.Show();
            this.Close();
        }

        private void PreencherTextBoxes()
        {
            CPFCNPJTextBox.Text = _garagem.CNPJTxt;
            TelefoneTextBox.Text = _garagem.TelefoneTxt;
            LotacaoTextBox.Text = _garagem.Veiculos.Count.ToString();
            RuaTextBox.Text = _garagem.Endereco.Rua;
            CEPTextBox.Text = _garagem.Endereco.CEP;
            BairroTextBox.Text = _garagem.Endereco.Bairro;
            UfTextBox.Text = _garagem.UF;
            NumeroTextBox.Text = _garagem.Endereco.Numero;
            CidadeTextBox.Text = _garagem.Endereco.Cidade;
            CapacidadeTextBox.Text = _garagem.Capacidade.ToString();

            LotacaoProgressBar.Value = _garagem.Veiculos.Count;
            LotacaoProgressBar.Maximum = _garagem.Capacidade;
        }
    }
}
