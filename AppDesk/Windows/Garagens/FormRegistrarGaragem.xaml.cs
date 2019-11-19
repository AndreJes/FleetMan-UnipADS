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
using Modelo.Classes.Desk;
using AppDesk.Tools;

namespace AppDesk.Windows.Garagens
{
    /// <summary>
    /// Lógica interna para FormRegistrarGaragem.xaml
    /// </summary>
    public partial class FormRegistrarGaragem : Window
    {
        public FormRegistrarGaragem()
        {
            InitializeComponent();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Garagem") == MessageBoxResult.Yes)
            {
                RegistrarGaragem();
                StandardMessageBoxes.MensagemSucesso("Garagem registrada com sucesso!", "Registro");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void RegistrarGaragem()
        {
            ServicoDados.ServicoDadosGaragem.GravarGaragem(GerarGaragem());
        }

        public Garagem GerarGaragem()
        {
            Garagem garagem = new Garagem()
            {
                CNPJ = CNPJTextBox.Text,
                Telefone = TelefoneTextBox.Text,
                Capacidade = int.Parse(CapacidadeSlider.Value.ToString()),
                Endereco = EnderecoUC.Endereco
            };
            return garagem;
        }
    }
}
