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
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Clientes;
using Modelo.Enums;

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
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
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
            Cliente cliente = GerarCliente();
            if (cliente == null)
            {
                MessageBox.Show("Falha ao registrar cliente!");
            }
            else
            {
                Serviço.ServicoDados.ServicoDadosClientes.RegistrarCliente(cliente);
                MessageBox.Show("Cliente registrado com sucesso!");
                MainWindow window = Application.Current.Windows.OfType<MainWindow>().First();
                window.PopulateDataGrid();
                this.Close();
            }
        }

        //Função que valida o formulário e gera o cliente a ser registrado no banco.
        private Cliente GerarCliente()
        {
            ClientePF clientePF = null;
            ClientePJ clientePJ = null;
            if (PFRBtn.IsChecked == true)
            {
                clientePF = new ClientePF()
                {
                    Ativo = true,
                    Nome = NomeTextBox.Text,
                    CPF = CPFCNPJTextBox.Text,
                    Email = EmailTextBox.Text,
                    Telefone = TelefoneTextBox.Text,
                    Endereco = new Endereco()
                    {
                        Rua = RuaTextBox.Text,
                        Bairro = BairroTextBox.Text,
                        CEP = CEPTextBox.Text,
                        Cidade = CidadeTextBox.Text,
                        Numero = NumeroTextBox.Text,
                        UF = (UnidadesFederativas) Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString())
                    }
                };
                return clientePF;
            }
            else if (PJRBtn.IsChecked == true)
            {
                clientePJ = new ClientePJ()
                {
                    Ativo = true,
                    Nome = NomeTextBox.Text,
                    CNPJ = CPFCNPJTextBox.Text,
                    Email = EmailTextBox.Text,
                    Telefone = TelefoneTextBox.Text,
                    Endereco = new Endereco()
                    {
                        Rua = RuaTextBox.Text,
                        Bairro = BairroTextBox.Text,
                        CEP = CEPTextBox.Text,
                        Cidade = CidadeTextBox.Text,
                        Numero = NumeroTextBox.Text,
                        UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString())
                    }
                };
                return clientePJ;
            }
            else
            {
                MessageBox.Show("Falha ao registrar cliente: Informe se é pessoa física ou jurídica");
                return null;
            }
        }

        private void ChangeLabelToCPF(object sender, RoutedEventArgs e)
        {
            CPF_CNPJ_Label.Content = "CPF";
        }

        private void ChangeLabelToCNPJ(object sender, RoutedEventArgs e)
        {
            CPF_CNPJ_Label.Content = "CNPJ";
        }
        #endregion
    }
}
