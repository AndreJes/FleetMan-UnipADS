using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Persistencia.DAL.Cliente;
using Servicos.Clientes;

namespace Servicos.Web
{
    public class SolicitacaoService
    {
        private SolicitacaoDAL Context = new SolicitacaoDAL();
        private ClienteService ClienteService = new ClienteService();

        public IEnumerable<Solicitacao> ObterSolicitacoesOrdPorId()
        {
            return Context.ObterSolicitacoesOrdPorId();
        }

        public Solicitacao ObterSolicitacaoPorId(long? id)
        {
            return Context.ObterSolicitacaoPorId(id);
        }

        public void GravarSolicitacao(Solicitacao solicitacao)
        {
            Context.GravarSolicitacao(solicitacao);
        }

        public void AprovarSolicitacao(Solicitacao solicitacao)
        {
            solicitacao.Estado = EstadosDaSolicitacao.APROVADA;
            solicitacao.DataProcessamento = DateTime.Now;

            switch (solicitacao.TipoDeItem)
            {
                case ItemSolicitacao.ALUGUEL:
                    break;
                case ItemSolicitacao.CLIENTE:
                    Cliente clienteModelo = JsonConvert.DeserializeObject<Cliente>(solicitacao.ItemSerializado);
                    if (clienteModelo.Tipo == TipoCliente.PF)
                    {
                        ClientePF clienteSolicitacao = JsonConvert.DeserializeObject<ClientePF>(solicitacao.ItemSerializado);
                        ClientePF cliente = ClienteService.ObterClientePFPorId(clienteSolicitacao.ClienteId);
                        cliente.Nome = clienteSolicitacao.Nome;
                        cliente.Telefone = clienteSolicitacao.Telefone;
                        cliente.Endereco = clienteSolicitacao.Endereco;
                        cliente.CPF = clienteSolicitacao.CPF;
                        ClienteService.GravarCliente(cliente);
                        GravarSolicitacao(solicitacao);
                    }
                    else if (clienteModelo.Tipo == TipoCliente.PJ)
                    {
                        ClientePJ clienteSolicitacao = JsonConvert.DeserializeObject<ClientePJ>(solicitacao.ItemSerializado);
                        ClientePJ cliente = ClienteService.ObterClientePJPorId(clienteSolicitacao.ClienteId);
                        cliente.Nome = clienteSolicitacao.Nome;
                        cliente.Telefone = clienteSolicitacao.Telefone;
                        cliente.Endereco = clienteSolicitacao.Endereco;
                        cliente.CNPJ = clienteSolicitacao.CNPJ;
                        ClienteService.GravarCliente(cliente);
                        GravarSolicitacao(solicitacao);
                    }
                    break;
            }
        }

        public void ReprovarSolicitacao(Solicitacao solicitacao)
        {
            solicitacao.Estado = EstadosDaSolicitacao.REPROVADA;
            solicitacao.DataProcessamento = DateTime.Now;

            GravarSolicitacao(solicitacao);
        }

        public void RemoverSolicitacaoPorId(long? id)
        {
            Context.RemoverSolicitacaoPorId(id);
        }

        public Solicitacao GerarSolicitacao(ItemSolicitacao tipoItem, TiposDeSolicitacao tipo, long? clienteId)
        {
            Solicitacao solicitacao = new Solicitacao();
            solicitacao.DataDaSolicitacao = DateTime.Now;
            solicitacao.TipoDeItem = tipoItem;
            solicitacao.Tipo = tipo;
            solicitacao.Estado = EstadosDaSolicitacao.AGUARDANDO;
            solicitacao.ClienteId = clienteId;
            return solicitacao;
        }
    }
}
