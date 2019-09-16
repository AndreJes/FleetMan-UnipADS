using AppDesk.Serviço;
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

namespace AppDesk.Windows.Seguro
{
    /// <summary>
    /// Lógica interna para FormDetalhesSeguro.xaml
    /// </summary>
    public partial class FormDetalhesSeguro : Window
    {
        private Modelo.Classes.Desk.Seguro _seguro = null;
        private FormDetalhesSeguro()
        {
            InitializeComponent();
        }

        public FormDetalhesSeguro(Modelo.Classes.Desk.Seguro seguro) : this()
        {
            _seguro = seguro;
            PreencherDados();
        }

        private void PreencherDados()
        {
            CNPJTextBox.Text = _seguro.CNPJ;
            NomeTextBox.Text = _seguro.Nome;
            EmailTextBox.Text = _seguro.Email;
            TelefoneTextBox.Text = _seguro.Telefone;
            DataContratacaoDatePic.SelectedDate = _seguro.DataContratacao;
            VencimentoContratoDatePic.SelectedDate = _seguro.Vencimento_Contrato;
            VencimentoProxParcelaDatePic.SelectedDate = _seguro.DataVencimentoParcela;
            ValorParcelaTextBox.Text = _seguro.PrecoParcela.ToString("F2");
            QuantidadeVeiculosLabel.Content = _seguro.Veiculos.Count();
            TipoCoberturaComboBox.Text = _seguro.TipoCobertura.ToString("G");
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            FormAlterarSeguro formAlterar = new FormAlterarSeguro(_seguro);
            formAlterar.Show();
            Application.Current.Windows.OfType<SegurosList>().FirstOrDefault().UpdateDataGrid();
            this.Close();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmRemove = MessageBox.Show("Remover seguradora?", "Confirmar remoção", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmRemove == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosSeguro.RemoverSeguroPorId(_seguro.SeguroId);
                Application.Current.Windows.OfType<SegurosList>().FirstOrDefault().UpdateDataGrid();
                MessageBox.Show("Seguradora removida com sucesso!");
                this.Close();
            }
        }
    }
}
