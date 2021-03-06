﻿using AppDesk.Serviço;
using AppDesk.Tools;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Linq;
using System.Windows;

namespace AppDesk.Windows.Seguros
{
    /// <summary>
    /// Lógica interna para FormDetalhesSeguro.xaml
    /// </summary>
    public partial class FormDetalhesSeguro : Window
    {
        private Seguro _seguro = null;
        private FormDetalhesSeguro()
        {
            InitializeComponent();
        }

        public FormDetalhesSeguro(Seguro seguro) : this()
        {
            _seguro = seguro;
            TipoCoberturaComboBox.ItemsSource = Enum.GetNames(typeof(CoberturasSeguro));
            PreencherDados();

            if (!DesktopLoginControlService._Usuario.Permissoes.Seguros.Alterar)
            {
                AlterarBtn.IsEnabled = false;
            }
            if (!DesktopLoginControlService._Usuario.Permissoes.Seguros.Remover)
            {
                RemoveBtn.IsEnabled = false;
            }
        }

        private void PreencherDados()
        {
            if (_seguro.Veiculos.Any() || _seguro.Veiculos != null)
            {
                VeiculosDataGrid.ItemsSource = _seguro.Veiculos.ToList();
            }
            CNPJUC.Text = _seguro.CNPJ;
            NomeUC.Text = _seguro.Nome;
            EmailUC.Text = _seguro.Email;
            TelefoneUC.Text = _seguro.Telefone;
            DataContratacaoUC.Date = _seguro.DataContratacao;
            DataVencimentoUC.Date = _seguro.Vencimento_Contrato;
            VencimentoProxParcelaUC.Date = _seguro.DataVencimentoParcela;
            ValorParcelaUC.Valor = _seguro.PrecoParcela;
            TipoCoberturaComboBox.Text = _seguro.TipoCobertura.ToString("G");

        }

        private void Alterar()
        {
            try
            {
                _seguro.Nome = NomeUC.Text;
                _seguro.Email = EmailUC.Text;
                _seguro.Telefone = TelefoneUC.Text;
                _seguro.Vencimento_Contrato = DataVencimentoUC.Date.GetValueOrDefault();
                _seguro.PrecoParcela = ValorParcelaUC.Valor;
                _seguro.DataVencimentoParcela = VencimentoProxParcelaUC.Date.GetValueOrDefault();
                _seguro.TipoCobertura = (CoberturasSeguro)Enum.Parse(typeof(CoberturasSeguro), TipoCoberturaComboBox.SelectedItem.ToString());
            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AlterarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarAlteracaoMessageBox("Seguradora") == MessageBoxResult.Yes)
                {
                    Alterar();
                    ServicoDados.ServicoDadosSeguro.GravarSeguro(_seguro);
                    StandardMessageBoxes.MensagemSucesso("Seguradora alterada com sucesso!", "Alteração");
                    Application.Current.Windows.OfType<SegurosList>().FirstOrDefault().UpdateDataGrid();
                }
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandardMessageBoxes.ConfirmarRemocaoMessageBox("Seguradora") == MessageBoxResult.Yes)
                {
                    ServicoDados.ServicoDadosSeguro.RemoverSeguroPorId(_seguro.SeguroId);
                    Application.Current.Windows.OfType<SegurosList>().FirstOrDefault().UpdateDataGrid();
                    StandardMessageBoxes.MensagemSucesso("Seguradora removida com sucesso!", "Remoção");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }
    }
}
