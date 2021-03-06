﻿using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Manutencao;
using Modelo.Classes.Manutencao.Associacao;
using Modelo.Enums;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AppDesk.Windows.Manutencoes
{
    /// <summary>
    /// Lógica interna para FormRegistrarManutencao.xaml
    /// </summary>
    public partial class FormRegistrarManutencao : Window
    {

        public FormRegistrarManutencao()
        {
            InitializeComponent();
            PecasDataGrid.ItemsSource = ServicoDados.ServicoDadosPeca.ObterPecasOrdPorId();
            VeiculosUC.ListaVeiculos = ServicoDados.ServicoDadosVeiculos.ObterVeiculosOrdPorId().ToList();
        }

        private void RegistrarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRegistroMessageBox("Manutenção") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosManutencao.AdicionarManutencao(GerarManutencao(), PecasSelecionadasDataGrid.Items.OfType<PecasManutencao>().ToList());
                    StandardMessageBoxes.MensagemSucesso("Manuteção adicionada com sucesso!", "Registro");
                    MainWindowUpdater.UpdateDataGrids();
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

        private void SelecionarPeca_Click(object sender, RoutedEventArgs e)
        {
            MoverItens(PecasDataGrid, PecasSelecionadasDataGrid);
        }

        private void RemoverPeca_Click(object sender, RoutedEventArgs e)
        {
            if (PecasSelecionadasDataGrid.SelectedItem != null)
            {
                PecasManutencao pecasManutencao = PecasSelecionadasDataGrid.SelectedItem as PecasManutencao;
                PecasSelecionadasDataGrid.Items.Remove(pecasManutencao);
            }

        }

        private void MoverItens(DataGrid origem, DataGrid destino)
        {
            Peca peca = null;
            if (origem.SelectedItem != null)
            {
                peca = (origem.SelectedItem as Peca);
            }

            PecasManutencao PecaParaAdicionar = new PecasManutencao();
            PecaParaAdicionar.PecaId = peca.PecaId;
            PecaParaAdicionar.Peca = peca;

            PecasManutencao PecaSelecionada = PecasSelecionadasDataGrid.Items.OfType<PecasManutencao>().Where(pm => pm.PecaId == PecaParaAdicionar.PecaId).FirstOrDefault();

            if (PecaSelecionada != null)
            {
                PecaSelecionada.QuantidadePecasUtilizadas++;
                PecasSelecionadasDataGrid.Items.Refresh();
            }
            else
            {
                PecaParaAdicionar.QuantidadePecasUtilizadas++;
                PecasSelecionadasDataGrid.Items.Add(PecaParaAdicionar);
            }
        }

        private Manutencao GerarManutencao()
        {
            try
            {
                Manutencao manutencao = new Manutencao();

                if (PfRB.IsChecked == true)
                {
                    manutencao.CPFCNPJResponsavel = CPFUC.Text;
                }
                else
                {
                    manutencao.CPFCNPJResponsavel = CNPJUC.Text;
                }

                manutencao.NomeResponsavel = NomeResponsavelField.Text;

                manutencao.Local = EnderecoUC.Endereco;
                manutencao.VeiculoId = VeiculosUC.Veiculo.VeiculoId;

                if (PreventivaRadioButton.IsChecked == true)
                {
                    manutencao.Tipo = TiposDeManutencao.PREVENTIVA;
                }
                else if (CorretivaRadioButton.IsChecked == true)
                {
                    manutencao.Tipo = TiposDeManutencao.CORRETIVA;
                }

                manutencao.DataEntrada = DataAgendamento.Date;

                if (ConcluidoCheckBox.IsChecked == true)
                {
                    manutencao.DataSaida = DataConclusaoUC.Date;
                    manutencao.EstadoAtual = EstadosDeManutencao.CONCLUIDA;
                }
                else if(manutencao.DataEntrada <= DateTime.Now)
                {
                    manutencao.EstadoAtual = EstadosDeManutencao.EM_ANDAMENTO;
                }
                else
                {
                    manutencao.EstadoAtual = EstadosDeManutencao.AGUARDANDO;
                }

                return manutencao;
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

        private void PfRB_Checked(object sender, RoutedEventArgs e)
        {
            if (PfRB.IsChecked == true)
            {
                if (CNPJUC != null)
                {
                    CNPJUC.Visibility = Visibility.Collapsed;
                }
                if (CPFUC != null)
                {
                    CPFUC.Visibility = Visibility.Visible;
                }
            }
        }

        private void PjRB_Checked(object sender, RoutedEventArgs e)
        {
            if (PjRB.IsChecked == true)
            {
                if (CNPJUC != null)
                {
                    CPFUC.Visibility = Visibility.Collapsed;
                }
                if (CPFUC != null)
                {
                    CNPJUC.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
