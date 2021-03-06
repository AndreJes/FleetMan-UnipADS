﻿using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Clientes;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Clientes
{
    public class ClienteService
    {
        private ClienteDAL Context = new ClienteDAL();
        private VeiculoService VeiculoService = new VeiculoService();

        public IEnumerable<Cliente> ObterClientesOrdPorId()
        {
            try
            {
                return Context.ObterTodosOsClientesOrdPorId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarCliente(Cliente cliente)
        {
            try
            {
                Context.GravarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClientePF ObterClientePFPorId(long? id)
        {
            try
            {
                return Context.ObterClientePFPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClientePJ ObterClientePJPorId(long? id)
        {
            try
            {
                return Context.ObterClientePJPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente ObterClientePorCPFCNPJ(string cpfcnpj, TipoCliente tipo)
        {
            try
            {
                return Context.ObterClientePorCPFCNPJ(cpfcnpj, tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente ObterClientePorEmailTipo(string email, TipoCliente tipo)
        {
            try
            {
                switch (tipo)
                {
                    case TipoCliente.PF:
                        return ObterClientesOrdPorId().Where(c => c.Tipo == TipoCliente.PF).Where(c => c.Email == email).FirstOrDefault();
                    case TipoCliente.PJ:
                        return ObterClientesOrdPorId().Where(c => c.Tipo == TipoCliente.PJ).Where(c => c.Email == email).FirstOrDefault();
                    default:
                        throw new Exception("Tipo cliente inválido!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClientePF ObterClientePFPorEmail(string email)
        {
            try
            {
                return ObterClientePFPorId(ObterClientePorEmailTipo(email, TipoCliente.PF).ClienteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClientePJ ObterClientePJPorEmail(string email)
        {
            try
            {
                return ObterClientePJPorId(ObterClientePorEmailTipo(email, TipoCliente.PJ).ClienteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverClientePorId(long? id)
        {
            try
            {
                Cliente cliente = ObterClientePFPorId(id);
                if(cliente == null)
                {
                    cliente = ObterClientePJPorId(id);
                }

                foreach(Veiculo v in cliente.Veiculos.Where(v => v.ParaLocacao == true))
                {
                    v.ClienteId = null;
                    v.EstadoDoVeiculo = EstadosDeVeiculo.NORMAL;
                    VeiculoService.GravarVeiculo(v);
                }

                Context.RemoverClientePorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
