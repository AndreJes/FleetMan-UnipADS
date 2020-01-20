using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace AppDesk.UserControls.Solicitacoes
{
    /// <summary>
    /// Interação lógica para SolicitacaoAlteracaoCliente.xam
    /// </summary>
    public partial class SolicitacaoAlteracaoCliente : UserControl, INotifyPropertyChanged
    {
        public Solicitacao Solicitacao
        {
            get
            {
                return Solicitacao;
            }
            set
            {
                if (value != null)
                {
                    if (value.ItemSerializado.Contains("CPF"))
                    {
                        ClientePF cliente = JsonConvert.DeserializeObject<ClientePF>(value.ItemSerializado);
                        ClienteNovo = cliente;
                    }
                    else if (value.ItemSerializado.Contains("CNPJ"))
                    {
                        ClientePJ cliente = JsonConvert.DeserializeObject<ClientePJ>(value.ItemSerializado);
                        ClienteNovo = cliente;
                    }
                    NotifyPropertyChanged();
                }
            }
        }

        private Cliente _clienteNovo;
        private Cliente ClienteNovo
        {
            get
            {
                return _clienteNovo;
            }
            set
            {
                if (value != null)
                {
                    _clienteNovo = value;
                    switch (ClienteNovo.Tipo)
                    {
                        case TipoCliente.PF:
                            CPFTextBox.Text = (value as ClientePF).CPF;
                            CPFTextBox.Visibility = Visibility.Visible;
                            break;
                        case TipoCliente.PJ:
                            CNPJTextBox.Text = (value as ClientePJ).CNPJ;
                            CNPJTextBox.Visibility = Visibility.Visible;
                            break;
                    }
                    NomeTextBox.Text = value.Nome;
                    TelefoneTextBox.Text = value.Telefone;
                    EnderecoNovoUC.Endereco = value.Endereco;
                    NotifyPropertyChanged();
                }
            }
        }

        public SolicitacaoAlteracaoCliente()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
