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
using AppDesk.Serviço;
using Modelo.Classes.Desk;
using Modelo.Enums;

namespace AppDesk.Windows.Seguro
{
    /// <summary>
    /// Lógica interna para FormRegistrarSeguro.xaml
    /// </summary>
    public partial class FormRegistrarSeguro : Window
    {
        public FormRegistrarSeguro()
        {
            InitializeComponent();
            TipoCoberturaComboBox.ItemsSource = Enum.GetValues(typeof(CoberturasSeguro));
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrarSeguro();
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrarSeguro()
        {
            Modelo.Classes.Desk.Seguro seguro = GerarSeguro();
            if (seguro != null)
            {
                ServicoDados.ServicoDadosSeguro.GravarSeguro(seguro);
                MessageBox.Show("Seguro registrado com sucesso!");
                Application.Current.Windows.OfType<SegurosList>().First().UpdateDataGrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha ao registrar seguradora!");
            }
        }

        private Modelo.Classes.Desk.Seguro GerarSeguro()
        {
            Modelo.Classes.Desk.Seguro seguro = new Modelo.Classes.Desk.Seguro()
            {
                CNPJ = CNPJTextBox.Text,
                Nome = NomeTextBox.Text,
                Email = EmailTextBox.Text,
                Telefone = TelefoneTextBox.Text,
                DataContratacao = DataContratacaoDatePic.DisplayDate,
                Vencimento_Contrato = VencimentoContratoDatePic.DisplayDate,
                DataVencimentoParcela = VencimentoProxParcelaDatePic.DisplayDate,
                PrecoParcela = double.Parse(ValorParcelaTextBox.Text),
                TipoCobertura = (CoberturasSeguro)Enum.Parse(typeof(CoberturasSeguro), TipoCoberturaComboBox.SelectedItem.ToString())
            };

            return seguro;
        }

    }
}
