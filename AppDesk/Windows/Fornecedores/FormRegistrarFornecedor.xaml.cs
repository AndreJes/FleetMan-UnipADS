using AppDesk.Serviço;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Manutencao;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AppDesk.Windows.Fornecedores
{
    /// <summary>
    /// Lógica interna para FormRegistrarFornecedor.xaml
    /// </summary>
    public partial class FormRegistrarFornecedor : Window
    {
        public FormRegistrarFornecedor()
        {
            InitializeComponent();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Confirmar registro de Fornecedor?", "Confirmar registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosFornecedor.GravarFornecedor(GerarFornecedor());
                Application.Current.Windows.OfType<FormFornecedoresList>().FirstOrDefault().FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
                MessageBox.Show("Fornecedor registrado com sucesso!");
                this.Close();
            }
        }

        private void CancelarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LojaVirtualCheckBox_Toggle(object sender,RoutedEventArgs e)
        {
            EnderecoUC.IsEnabled = !ConversorBoolNullable.ConversorBooleano(LojaVirtualCheckBox.IsChecked);
        }

        private Fornecedor GerarFornecedor()
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.CNPJ = CNPJTextBox.Text;
            fornecedor.Razao_Social = RazaoSocialTextBox.Text;
            fornecedor.Email = EmailTextBox.Text;
            fornecedor.Telefone = TelefoneTextBox.Text;
            fornecedor.LojaVirtual = ConversorBoolNullable.ConversorBooleano(LojaVirtualCheckBox.IsChecked);
            Endereco endereco = new Endereco();

            if (fornecedor.LojaVirtual == false)
            {
                endereco.Rua = EnderecoUC.RuaUC.Text;
                endereco.Numero = EnderecoUC.NumeroUC.Text;
                endereco.Cidade = EnderecoUC.CidadeUC.Text;
                endereco.CEP = EnderecoUC.CEPUC.Text;
                endereco.Bairro = EnderecoUC.BairroUC.Text;
                endereco.UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), EnderecoUC.UfComboBox.SelectedItem.ToString());
            }

            fornecedor.Endereco = endereco;

            return fornecedor;
        }
    }
}
