﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Clientes;
using Modelo.Classes.Usuarios;
using Modelo.Enums;
using Persistencia.DAL.Usuarios;

namespace Persistencia.DAL.Clientes
{
    public class ClienteDAL : DALContext
    {
        private UsuarioClienteDAL UsuarioClienteDAL
        {
            get
            {
                return new UsuarioClienteDAL();
            }
        }

        public IEnumerable<Modelo.Classes.Clientes.Cliente> ObterTodosOsClientesOrdPorId()
        {
            try
            {
                IList<Modelo.Classes.Clientes.Cliente> Clientes = new List<Modelo.Classes.Clientes.Cliente>();

                foreach (ClientePF pf in Context.ClientesPF.ToList())
                {
                    Clientes.Add(pf);
                }
                foreach (ClientePJ pj in Context.ClientesPJ.ToList())
                {
                    Clientes.Add(pj);
                }

                return Clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarCliente(Modelo.Classes.Clientes.Cliente cliente)
        {
            try
            {
                bool add = false;
                if (cliente is ClientePF)
                {
                    if (cliente.ClienteId == null)
                    {
                        Context.ClientesPF.Add(cliente as ClientePF);
                        add = true;
                    }
                    else
                    {
                        Context.Entry(cliente).State = EntityState.Modified;
                    }
                }
                else
                {
                    if (cliente.ClienteId == null)
                    {
                        Context.ClientesPJ.Add(cliente as ClientePJ);
                        add = true;
                    }
                    else
                    {
                        Context.Entry(cliente).State = EntityState.Modified;
                    }
                }

                Context.SaveChanges();

                if (add)
                {
                    GerarUsuarioCliente(Context.Entry(cliente).Entity);
                }
                else
                {
                    UsuarioClienteDAL.AlterarUsuarioCliente(cliente.ClienteId.ToString(), novoEmail: cliente.Email);
                }
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
                ClientePF clientePF = Context.ClientesPF.Where(c => c.ClienteId == id).Include(c => c.Veiculos).Include(c => c.Motoristas).Include(c => c.Alugueis).Include(c => c.Solicitacoes).FirstOrDefault();
                return clientePF;
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
                return Context.ClientesPJ.Where(c => c.ClienteId == id).Include(c => c.Veiculos).Include(c => c.Alugueis).Include(c => c.Motoristas).Include(c => c.Solicitacoes).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Modelo.Classes.Clientes.Cliente ObterClientePorCPFCNPJ(string cpfcnpj, TipoCliente tipo)
        {
            try
            {
                switch (tipo)
                {
                    case TipoCliente.PF:
                        return Context.ClientesPF.Where(c => c.CPF == cpfcnpj).FirstOrDefault();
                    case TipoCliente.PJ:
                        return Context.ClientesPJ.Where(c => c.CNPJ == cpfcnpj).FirstOrDefault();
                    default:
                        return null;
                }
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
                UsuarioClienteDAL.RemoverUsuarioClientePorId(id.ToString());
                Modelo.Classes.Clientes.Cliente cliente = Context.Clientes.Where(c => c.ClienteId == id).FirstOrDefault();
                Context.Clientes.Remove(cliente);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GerarUsuarioCliente(Modelo.Classes.Clientes.Cliente cliente)
        {
            try
            {
                UsuarioClienteView clienteView = new UsuarioClienteView();
                clienteView.ClienteId = cliente.ClienteId;
                clienteView.Email = cliente.Email;
                clienteView.Login = cliente.Email;
                if (cliente is ClientePF)
                {
                    clienteView.Senha = (cliente as ClientePF).CPF.Substring(0, 8);
                }
                else
                {
                    clienteView.Senha = (cliente as ClientePJ).CNPJ.Substring(0, 8);
                }
                UsuarioClienteDAL.AdicionarUsuarioCliente(clienteView);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
