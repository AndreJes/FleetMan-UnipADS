using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Locacoes;
using AppDesk.Windows.Motoristas;
using AppDesk.Windows.Veiculos;
using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Windows;

namespace AppDesk.Windows.Clientes
{
    /// <summary>
    /// Lógica interna para FormAlterarClientes.xaml
    /// </summary>
    public partial class FormAlterarClientes : Window
    {
        private TipoCliente tipo;
        private ClientePF _clientePF = null;
        private ClientePJ _clientePJ = null;

        public FormAlterarClientes()
        {
            InitializeComponent();
        }

        public FormAlterarClientes(Cliente cliente) : this()
        {
            tipo = cliente.Tipo;
            VehicleDataGrid.ItemsSource = cliente.Veiculos;
            MotoristasDataGrid.ItemsSource = cliente.Motoristas;
            LocacoesDataGrid.ItemsSource = cliente.Alugueis;
            EnderecoUC.Editavel = true;
            if (cliente is ClientePF)
            {
                _clientePF = cliente as ClientePF;
                CPFUC.Text = _clientePF.CPF;
                CPFUC.Visibility = Visibility.Visible;
            }
            if (cliente is ClientePJ)
            {
                _clientePJ = cliente as ClientePJ;
                CNPJUC.Text = _clientePJ.CNPJ;
                CNPJUC.Visibility = Visibility.Visible;
            }

            if (cliente.Ativo)
            {
                AtivoRadioBtn.IsChecked = true;
            }
            else
            {
                InativoRadioBtn.IsChecked = true;
            }


            if (!DesktopLoginControlService._Usuario.Permissoes.Clientes.Alterar)
            {
                AlterarBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Clientes.Remover)
            {
                CancelarBtn.IsEnabled = false;
            }

            PreencherTextBoxes(cliente);
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente clienteAlterado = AlterarCliente();
                if (clienteAlterado != null)
                {
                    ServicoDados.ServicoDadosClientes.GravarCliente(clienteAlterado);
                    StandardMessageBoxes.MensagemSucesso("Cliente alterado com sucesso!", "Alteração");
                    MainWindowUpdater.UpdateDataGrids();
                    this.Close();
                }
                else
                {
                    StandardMessageBoxes.MensagemDeErro("Falha ao alterar cliente");
                }
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Cliente") == MessageBoxResult.Yes)
                {
                    if (StandardMessageBoxes.MensagemAlerta("Remover cliente irá remover todos os dados relacionados (Veiculos, Motoristas, Alugueis, etc.)", "Deseja continuar?") == MessageBoxResult.Yes)
                    {
                        switch (tipo)
                        {
                            case TipoCliente.PF:
                                ServicoDados.ServicoDadosClientes.RemoverClientePorId(_clientePF.ClienteId);
                                break;
                            case TipoCliente.PJ:
                                ServicoDados.ServicoDadosClientes.RemoverClientePorId(_clientePJ.ClienteId);
                                break;
                        }
                    }
                }
                StandardMessageBoxes.MensagemSucesso("Cliente removido com sucesso!", "Remoção");
                MainWindowUpdater.UpdateDataGrids();
                this.Close();
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void PreencherTextBoxes(Cliente cliente)
        {
            NomeUC.Text = cliente.Nome;
            EmailUC.Text = cliente.Email;
            TelefoneUC.Text = cliente.Telefone;
            EnderecoUC.Endereco = cliente.Endereco;
            if (cliente is ClientePF)
            {
                CNPJUC.Text = (cliente as ClientePF).CPF;
            }
            else if (cliente is ClientePJ)
            {
                CNPJUC.Text = (cliente as ClientePJ).CNPJ;
            }
        }

        private Cliente AlterarCliente()
        {
            try
            {
                bool ativoInativo = true;
                if (AtivoRadioBtn.IsChecked == true)
                {
                    ativoInativo = true;
                }
                else if (InativoRadioBtn.IsChecked == true)
                {
                    ativoInativo = false;
                }

                if (_clientePF != null)
                {
                    _clientePF.Ativo = ativoInativo;
                    _clientePF.Nome = NomeUC.Text;
                    _clientePF.CPF = CPFUC.Text;
                    _clientePF.Email = EmailUC.Text;
                    _clientePF.Telefone = TelefoneUC.Text;
                    _clientePF.Endereco = EnderecoUC.Endereco;
                    return _clientePF;
                }
                else if (_clientePJ != null)
                {
                    _clientePJ.Ativo = ativoInativo;
                    _clientePJ.Nome = NomeUC.Text;
                    _clientePJ.CNPJ = CNPJUC.Text;
                    _clientePJ.Email = EmailUC.Text;
                    _clientePJ.Telefone = TelefoneUC.Text;
                    _clientePJ.Endereco = EnderecoUC.Endereco;
                    return _clientePJ;
                }
                return null;
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
                return null;
            }
        }

        private void DetalhesVeiculoBtn_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId((VehicleDataGrid.SelectedItem as Veiculo).VeiculoId);

            FormDetalhesVeiculo formDetalhesVeiculo = new FormDetalhesVeiculo(veiculo);
            formDetalhesVeiculo.Show();
        }

        private void AluguelDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Aluguel aluguel = ServicoDados.ServicoDadosAluguel.ObterAluguelPorId((LocacoesDataGrid.SelectedItem as Aluguel).AluguelId);

            FormDetalhesAlterarAluguel formDetalhesAluguel = new FormDetalhesAlterarAluguel(aluguel);
            formDetalhesAluguel.Show();
        }

        private void MotoristaDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            Motorista motorista = ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId((MotoristasDataGrid.SelectedItem as Motorista).MotoristaId);

            FormDetalhesMotorista formDetalhesMotorista = new FormDetalhesMotorista(motorista);
            formDetalhesMotorista.Show();
        }
    }
}
