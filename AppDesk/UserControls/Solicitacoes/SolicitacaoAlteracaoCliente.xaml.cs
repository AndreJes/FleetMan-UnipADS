using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Modelo.Enums;
using AppDesk.Serviço;

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
                        ClienteAntigo = ServicoDados.ServicoDadosClientes.ObterClientePFPorId(cliente.ClienteId);
                    }
                    else if (value.ItemSerializado.Contains("CNPJ"))
                    {
                        ClientePJ cliente = JsonConvert.DeserializeObject<ClientePJ>(value.ItemSerializado);
                        ClienteNovo = cliente;
                        ClienteAntigo = ServicoDados.ServicoDadosClientes.ObterClientePJPorId(cliente.ClienteId);
                    }
                    NotifyPropertyChanged();
                }
            }
        }

        private Cliente _clienteAntigo;
        private Cliente ClienteAntigo
        {
            get
            {
                return _clienteAntigo;
            }
            set
            {
                if (value != null)
                {
                    _clienteAntigo = value;
                    switch (ClienteAntigo.Tipo)
                    {
                        case TipoCliente.PF:
                            CpfCnpjAntigoTextBox.Text = (value as ClientePF).CPFTxt;
                            break;
                        case TipoCliente.PJ:
                            CpfCnpjAntigoTextBox.Text = (value as ClientePJ).CNPJTxt;
                            break;
                    }
                    NomeAntigoTextBox.Text = value.Nome;
                    TelefoneAntigoTextBox.Text = value.Telefone;
                    EnderecoAntigoUC.Endereco = value.Endereco;
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
                            CpfCnpjNovoTextBox.Text = (value as ClientePF).CPFTxt;
                            
                            break;
                        case TipoCliente.PJ:
                            CpfCnpjNovoTextBox.Text = (value as ClientePJ).CNPJTxt;
                            break;
                    }
                    NomeNovoTextBox.Text = value.Nome;
                    TelefoneNovoTextBox.Text = value.Telefone;
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
