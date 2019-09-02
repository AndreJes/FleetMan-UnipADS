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
            DataContratacaoDatePic.DisplayDate = _seguro.DataContratacao;
            VencimentoContratoDatePic.DisplayDate = _seguro.Vencimento_Contrato;
            VencimentoProxParcelaDatePic.DisplayDate = _seguro.DataVencimentoParcela;
            ValorParcelaTextBox.Text = _seguro.PrecoParcela.ToString("F2");
            QuantidadeVeiculosLabel.Content = _seguro.Veiculos.Count();
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            FormAlterarSeguro formAlterar = new FormAlterarSeguro(_seguro);
            formAlterar.Show();
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
