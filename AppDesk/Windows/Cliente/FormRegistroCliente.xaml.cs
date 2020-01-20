using AppDesk.Tools;
using Modelo.Classes.Clientes;
using Modelo.Enums;
using System;
using System.Linq;
using System.Windows;

namespace AppDesk.Windows.Clientes
{
    /// <summary>
    /// Lógica interna para FormRegistroVeiculo.xaml
    /// </summary>
    public partial class FormRegistroCliente : Window
    {
        public FormRegistroCliente()
        {
            InitializeComponent();
        }

        //Botão registro
        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrarCliente();
        }

        //Botão Cancelar
        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #region Métodos Auxiliares
        //Função que registra o cliente no banco
        private void RegistrarCliente()
        {
            try
            {
                Cliente cliente = GerarCliente();
                if (cliente != null)
                {
                    Serviço.ServicoDados.ServicoDadosClientes.GravarCliente(cliente);
                    StandardMessageBoxes.MensagemSucesso("Cliente registrado com sucesso!", "Registro");
                    MainWindow window = Application.Current.Windows.OfType<MainWindow>().First();
                    window.PopulateDataGrid();
                    this.Close();
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

        //Função que valida o formulário e gera o cliente a ser registrado no banco.
        private Cliente GerarCliente()
        {
            if (PFRBtn.IsChecked == true)
            {
                ClientePF clientePF = new ClientePF()
                {
                    Ativo = true,
                    Nome = NomeUC.Text,
                    CPF = CPFUC.Text,
                    Email = EmailUC.Text,
                    Telefone = TelefoneUC.Text,
                    Endereco = EnderecoUC.Endereco,
                    Tipo = TipoCliente.PF
                };
                return clientePF;
            }
            else if (PJRBtn.IsChecked == true)
            {
                ClientePJ clientePJ = new ClientePJ()
                {
                    Ativo = true,
                    Nome = NomeUC.Text,
                    CNPJ = CNPJUC.Text,
                    Email = EmailUC.Text,
                    Telefone = TelefoneUC.Text,
                    Endereco = EnderecoUC.Endereco,
                    Tipo = TipoCliente.PJ
                };
                return clientePJ;
            }
            else
            {
                throw new FieldException("Tipo de Cliente");
            }
        }

        private void ChangeLabelToCPF(object sender, RoutedEventArgs e)
        {
            CNPJUC.Visibility = Visibility.Collapsed;
            CPFUC.Visibility = Visibility.Visible;
        }

        private void ChangeLabelToCNPJ(object sender, RoutedEventArgs e)
        {
            CPFUC.Visibility = Visibility.Collapsed;
            CNPJUC.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
