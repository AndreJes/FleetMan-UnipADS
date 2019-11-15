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

namespace AppDesk.Windows.Seguros
{
    /// <summary>
    /// Lógica interna para FormAlterarSeguro.xaml
    /// </summary>
    public partial class FormAlterarSeguro : Window
    {
        private Modelo.Classes.Desk.Seguro _seguroEditavel = null;

        private FormAlterarSeguro()
        {
            InitializeComponent();
            TipoCoberturaComboBox.ItemsSource = Enum.GetValues(typeof(CoberturasSeguro));
        }

        public FormAlterarSeguro(Modelo.Classes.Desk.Seguro seguro) : this()
        {
            _seguroEditavel = seguro;
            PreencherDados();
        }


        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            EditarDados();
            ServicoDados.ServicoDadosSeguro.GravarSeguro(_seguroEditavel);
            MessageBox.Show("Seguradora alterada com sucesso!");
            this.Close();
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreencherDados()
        {
            CNPJTextBox.Text = _seguroEditavel.CNPJ;
            NomeTextBox.Text = _seguroEditavel.Nome;
            EmailTextBox.Text = _seguroEditavel.Email;
            TelefoneTextBox.Text = _seguroEditavel.Telefone;
            DataContratacaoDatePic.SelectedDate = _seguroEditavel.DataContratacao;
            VencimentoContratoDatePic.SelectedDate = _seguroEditavel.Vencimento_Contrato;
            VencimentoProxParcelaDatePic.SelectedDate = _seguroEditavel.DataVencimentoParcela;
            ValorParcelaTextBox.Text = _seguroEditavel.PrecoParcela.ToString("F2");
        }

        private void EditarDados()
        {
            _seguroEditavel.CNPJ = CNPJTextBox.Text;
            _seguroEditavel.Nome = NomeTextBox.Text;
            _seguroEditavel.Email = EmailTextBox.Text;
            _seguroEditavel.Telefone = TelefoneTextBox.Text;
            _seguroEditavel.Vencimento_Contrato = VencimentoContratoDatePic.DisplayDate;
            _seguroEditavel.DataVencimentoParcela = VencimentoProxParcelaDatePic.DisplayDate;
            _seguroEditavel.PrecoParcela = double.Parse(ValorParcelaTextBox.Text);
        }

    }
}
