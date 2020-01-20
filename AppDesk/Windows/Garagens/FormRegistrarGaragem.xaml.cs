using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Desk;
using System.Windows;

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
