using AppDesk.Interfaces;
using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
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

namespace AppDesk.Windows.Motoristas
{
    /// <summary>
    /// Lógica interna para FormDetalhesMotorista.xaml
    /// </summary>
    public partial class FormDetalhesMotorista : Window, IFillTextBoxes
    {
        private Motorista _motorista = null;

        private FormDetalhesMotorista()
        {
            InitializeComponent();
        }

        public FormDetalhesMotorista(Motorista motorista) : this()
        {
            _motorista = motorista;
            CategoriaComboBox.ItemsSource = Enum.GetNames(typeof(CategoriasCNH));
            MultasDataGrid.ItemsSource = _motorista.Multas;
            SinistrosDataGrid.ItemsSource = _motorista.Sinistros;
            PreencherTextBoxes();
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Motorista") == MessageBoxResult.Yes)
            {
                ServicoDados.ServicoDadosMotorista.RemoverMotoristaPorId(_motorista.MotoristaId);
                StandardMessageBoxes.MensagemSucesso("Motorista removido com sucesso!", "Remoção");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("Motorista") == MessageBoxResult.Yes)
                {
                    Alterar();
                    ServicoDados.ServicoDadosMotorista.GravarMotorista(_motorista);
                    StandardMessageBoxes.MensagemSucesso("Motorista alterado com sucesso!", "Alteração");
                    MainWindowUpdater.UpdateDataGrids();
                }
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        public void PreencherTextBoxes()
        {
            if (_motorista.Cliente != null)
            {
                if (_motorista.Cliente is ClientePF)
                {
                    CPFClienteUC.Visibility = Visibility.Visible;
                    CPFClienteUC.Text = (_motorista.Cliente as ClientePF).CPF;
                }
                else if (_motorista.Cliente is ClientePJ)
                {
                    CNPJClienteUC.Visibility = Visibility.Visible;
                    CNPJClienteUC.Text = (_motorista.Cliente as ClientePJ).CNPJ;
                }

                EmailClienteUC.Text = _motorista.Cliente.Email;
                NomeClienteUC.Text = _motorista.Cliente.Nome;
                TelefoneClienteUC.Text = _motorista.Cliente.Telefone;
            }
            else
            {
                ClienteGroupBox.Visibility = Visibility.Collapsed;
            }

            CategoriaComboBox.SelectedItem = _motorista.Categoria.ToString("G");

            CPFUC.Text = _motorista.CPF;
            DataVencimentoUC.Date = _motorista.VencimentoExame;
            EmailUC.Text = _motorista.Email;
            EnderecoUC.Endereco = _motorista.Endereco;
            NomeUC.Text = _motorista.Nome;
            NumeroCNHUC.Text = _motorista.NumeroCNH;
            PontosCNHUC.Value = _motorista.PontosCNH;
            RGUC.Text = _motorista.RG;
            TelefoneUC.Text = _motorista.Celular;
            MotoristaProprioCB.IsChecked = _motorista.MotoristaProprio;
        }

        public void Alterar()
        {
            try
            {
                _motorista.Nome = NomeUC.Text;
                _motorista.RG = RGUC.Text;
                _motorista.Email = EmailUC.Text;
                _motorista.Celular = TelefoneUC.Text;
                _motorista.PontosCNH = PontosCNHUC.Value;
                _motorista.VencimentoExame = DataVencimentoUC.Date;
                _motorista.Endereco = EnderecoUC.Endereco;
                _motorista.Categoria = (CategoriasCNH)Enum.Parse(typeof(CategoriasCNH), CategoriaComboBox.SelectedItem.ToString());

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
    }
}
