using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Financas;
using AppDesk.Windows.Locacoes;
using AppDesk.Windows.Motoristas;
using AppDesk.Windows.Veiculos;
using AppDesk.Windows.Viagens;
using Modelo.Classes.Desk;
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

namespace AppDesk.Windows.Avisos
{
    /// <summary>
    /// Lógica interna para FormAvisosList.xaml
    /// </summary>
    public partial class FormAvisosList : Window
    {
        private FormAvisosList()
        {
            InitializeComponent();
        }

        public FormAvisosList(List<Aviso> avisos) : this()
        {
            ListItemAvisos.ItemsSource = avisos;
        }

        private void VisualizarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Aviso aviso = ListItemAvisos.SelectedItem as Aviso;
                switch (aviso.Tipo)
                {
                    case Modelo.Enums.TiposDeAviso.VEICULO_IRREGULAR:
                        FormDetalhesVeiculo formDetalhesVeiculo = new FormDetalhesVeiculo(ServicoDados.ServicoDadosVeiculos.ObterVeiculoPorId(aviso.idObjeto));
                        formDetalhesVeiculo.Show();
                        break;
                    case Modelo.Enums.TiposDeAviso.MOTORISTA_IRREGULAR:
                        FormDetalhesMotorista formDetalhesMotorista = new FormDetalhesMotorista(ServicoDados.ServicoDadosMotorista.ObterMotoristaPorId(aviso.idObjeto));
                        formDetalhesMotorista.Show();
                        break;
                    case Modelo.Enums.TiposDeAviso.PAGAMENTO_VENCIDO:
                        FormDetalhesAlterarFinanca formDetalhesAlterarFinanca = new FormDetalhesAlterarFinanca(ServicoDados.ServicoDadosFinancas.ObterFinancaPorId(aviso.idObjeto));
                        formDetalhesAlterarFinanca.Show();
                        break;
                    case Modelo.Enums.TiposDeAviso.VIAGEM_IRREGULAR:
                        FormDetalhesAlterarViagem formDetalhesAlterarViagem = new FormDetalhesAlterarViagem(ServicoDados.ServicoDadosViagem.ObterViagemPorId(aviso.idObjeto));
                        formDetalhesAlterarViagem.Show();
                        break;
                    case Modelo.Enums.TiposDeAviso.ALUGUEL_IRREGULAR:
                        FormDetalhesAlterarAluguel formDetalhesAlterarAluguel = new FormDetalhesAlterarAluguel(ServicoDados.ServicoDadosAluguel.ObterAluguelPorId(aviso.idObjeto));
                        formDetalhesAlterarAluguel.Show();
                        break;
                }
            }
            catch(NullReferenceException)
            {
                StandardMessageBoxes.MensagemDeErro("Selecione um item para poder visualizar!");
            }
            catch(Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }
    }
}
