using AppDesk.Serviço;
using AppDesk.Tools;
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
            try
            {

                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Fornecedor") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosFornecedor.GravarFornecedor(GerarFornecedor());
                    Application.Current.Windows.OfType<FormFornecedoresList>().FirstOrDefault().FornecedoresDataGrid.ItemsSource = ServicoDados.ServicoDadosFornecedor.ObterFornecedoresOrdPorId();
                    StandardMessageBoxes.MensagemSucesso("Fornecedor registrado com sucesso!", "Registro");
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

        private void LojaVirtualCheckBox_Toggle(object sender, RoutedEventArgs e)
        {
            EnderecoUC.IsEnabled = !ConversorBoolNullable.ConversorBooleano(LojaVirtualCheckBox.IsChecked);
        }

        private Fornecedor GerarFornecedor()
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.CNPJ = CNPJTextBox.Text;
                fornecedor.Razao_Social = NomeTextBox.Text;
                fornecedor.Email = EmailTextBox.Text;
                fornecedor.Telefone = TelefoneTextBox.Text;
                fornecedor.LojaVirtual = ConversorBoolNullable.ConversorBooleano(LojaVirtualCheckBox.IsChecked);

                if (fornecedor.LojaVirtual == false)
                {
                    fornecedor.Endereco = EnderecoUC.Endereco;
                }
                else
                {
                    fornecedor.Endereco = new Endereco();
                }

                return fornecedor;
            }
            catch (FieldException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
