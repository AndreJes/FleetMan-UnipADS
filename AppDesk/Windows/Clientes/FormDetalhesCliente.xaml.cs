using Modelo.Classes.Clientes;
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

namespace AppDesk.Windows.Clientes
{
    /// <summary>
    /// Lógica interna para FormDetalhesCliente.xaml
    /// </summary>
    public partial class FormDetalhesCliente : Window
    {
        #region Construtores
        private FormDetalhesCliente()
        {
            InitializeComponent();
            
        }

        public FormDetalhesCliente(ClientePF clientePF) : this()
        {
            CPF_CNPJ_Label.Content = "CPF";
            CPFCNPJTextBox.Text = clientePF.CPFTxt;
            PreencherTextBoxes(clientePF);
        }

        public FormDetalhesCliente(ClientePJ clientePJ) : this()
        {
            CPF_CNPJ_Label.Content = "CNPJ";
            CPFCNPJTextBox.Text = clientePJ.CNPJTxt;
            PreencherTextBoxes(clientePJ);
        }
        #endregion

        private void PreencherTextBoxes(Cliente cliente)
        {
            NomeTextBox.Text = cliente.Nome;
            EmailTextBox.Text = cliente.Email;
            TelefoneTextBox.Text = cliente.Telefone;
            RuaTextBox.Text = cliente.Endereco.Rua;
            NumeroTextBox.Text = cliente.Endereco.Numero;
            CidadeTextBox.Text = cliente.Endereco.Cidade;
            CEPTextBox.Text = cliente.Endereco.CEP;
            BairroTextBox.Text = cliente.Endereco.Bairro;
            UfTextBox.Text = cliente.Endereco.UF.ToString("G");

            QuantidadeDeVeiculos.Content = cliente.Veiculos.ToList().Count.ToString();
            QuantidadeDeMotoristas.Content = cliente.Motoristas.ToList().Count.ToString();
            QuantidadeDeLocacoes.Content = cliente.Alugueis.ToList().Count.ToString();
        }
    }
}
