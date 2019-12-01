using AppDesk.Interfaces;
using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Abastecimentos;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Clientes;
using Modelo.Classes.Desk;
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

namespace AppDesk.Windows.Veiculos
{
    /// <summary>
    /// Lógica interna para FormDetalhesVeiculo.xaml
    /// </summary>
    public partial class FormDetalhesVeiculo : Window, IFillTextBoxes
    {
        private Veiculo _veiculo = new Veiculo();

        private FormDetalhesVeiculo()
        {
            InitializeComponent();
        }

        public FormDetalhesVeiculo(Veiculo veiculo) : this()
        {
            _veiculo = veiculo;
            DataContext = _veiculo;
            MultasDataGrid.ItemsSource = _veiculo.Multas.ToList();
            SinistrosDataGrid.ItemsSource = _veiculo.Sinistros.ToList();
            ManutencaoDataGrid.ItemsSource = _veiculo.Manutencoes.ToList();
            TanqueProgressBar.Value = (double)_veiculo.EstadoDoTanque;
            SeguradorasComboBox.ItemsSource = ServicoDados.ServicoDadosSeguro.ObterSegurosOrdPorId().ToList();

            SituacaoTextBox.Text = _veiculo.EstadoTxt;

            TipoDeVeiculoTextBox.Text = _veiculo.Tipo.ToString("G");
            PreencherDadosCliente();
            PreencherTextBoxes();


            if (!DesktopLoginControlService._Usuario.Permissoes.Veiculos.Alterar)
            {
                AlterarBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Veiculos.Remover)
            {
                RemoverBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Manutencoes.Cadastrar)
            {
                RegistrarAbastecimentoBtn.IsEnabled = false;
            }
        }

        private void PreencherDadosCliente()
        {
            if (_veiculo.Cliente is ClientePF)
            {
                CPFCNPJClienteTextBox.Text = (_veiculo.Cliente as ClientePF).CPFTxt;
            }
            else if (_veiculo.Cliente is ClientePJ)
            {
                CPFCNPJClienteTextBox.Text = (_veiculo.Cliente as ClientePJ).CNPJTxt;
            }
        }

        private void AlterarDados()
        {
            try
            {
                _veiculo.Placa = PlacaUC.Text;
                _veiculo.CodRenavam = RenavamUC.Text;
                _veiculo.Marca = MarcaUC.Text;
                _veiculo.Modelo = ModeloUC.Text;
                _veiculo.Ano = AnoUC.Value;
                _veiculo.Cor = CorUC.Text;
                _veiculo.Adaptado = ConversorBoolNullable.ConversorBooleano(AdaptadoCheckBox.IsChecked);
                if (GaragemUC.Garagem != null)
                {
                    _veiculo.GaragemId = GaragemUC.Garagem.GaragemId;
                }
                if (SeguradorasComboBox.SelectedItem != null)
                {
                    _veiculo.SeguroId = (SeguradorasComboBox.SelectedItem as Seguro).SeguroId;
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

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("veículo") == MessageBoxResult.Yes)
            {
                AlterarDados();
                StandardMessageBoxes.MensagemSucesso("Veículo alterado com sucesso!", "Alteração");
                MainWindowUpdater.UpdateDataGrids();
            }
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("veiculo") == MessageBoxResult.Yes)
                {
                    if (StandardMessageBoxes.MensagemAlerta("Ação também ira remover todos os dados relativos ao veiculo (multas, sinistros, abastecimentos, etc.)", "Deseja continuar?") == MessageBoxResult.Yes)
                    {
                        ServicoDados.ServicoDadosVeiculos.RemoverVeiculoPorId(_veiculo.VeiculoId);
                        StandardMessageBoxes.MensagemSucesso("Veiculo removido com sucesso!", "Remoção");
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

        private void SeguradorasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CoberturaTextBox.Text = (SeguradorasComboBox.SelectedItem as Modelo.Classes.Desk.Seguro).TipoCobertura.ToString("G");
        }

        public void PreencherTextBoxes()
        {
            PlacaUC.Text = _veiculo.Placa;
            RenavamUC.Text = _veiculo.CodRenavam;
            MarcaUC.Text = _veiculo.Marca;
            ModeloUC.Text = _veiculo.Modelo;
            AnoUC.Value = _veiculo.Ano;
            CorUC.Text = _veiculo.Cor;
            
        }

        private void RegistrarAbastecimentoBtn_Click(object sender, RoutedEventArgs e)
        {
            FormRegistrarAbastecimento formRegistrarAbastecimento = new FormRegistrarAbastecimento();
            formRegistrarAbastecimento.SeletorVeiculo.Veiculo = _veiculo;
            formRegistrarAbastecimento.Show();
        }
    }
}
