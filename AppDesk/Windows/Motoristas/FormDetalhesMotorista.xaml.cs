using AppDesk.Interfaces;
using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Windows;

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

            if (!DesktopLoginControlService._Usuario.Permissoes.Motoristas.Alterar)
            {
                AlterarBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Motoristas.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Motorista") == MessageBoxResult.Yes)
                {
                    if (StandardMessageBoxes.MensagemAlerta("Ação também ira remover todos os dados relativos ao motorista (multas, sinistros, abastecimentos, etc.)", "Deseja continuar?") == MessageBoxResult.Yes)
                    {
                        ServicoDados.ServicoDadosMotorista.RemoverMotoristaPorId(_motorista.MotoristaId);
                        StandardMessageBoxes.MensagemSucesso("Motorista removido com sucesso!", "Remoção");
                        MainWindowUpdater.UpdateDataGrids();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
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
                _motorista.VencimentoExame = DataVencimentoUC.Date.GetValueOrDefault();
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
