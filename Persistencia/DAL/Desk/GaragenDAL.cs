﻿using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Persistencia.Contexts;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Persistencia.DAL.Desk
{
    public class GaragenDAL
    {
        public IEnumerable<Garagem> ObterGaragensOrdPorId()
        {
            try
            {
                using EFContext Context = new EFContext();
                return Context.Garagens.Include(g => g.Veiculos).OrderBy(g => g.GaragemId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarGaragem(Garagem garagem)
        {
            try
            {
                using EFContext Context = new EFContext();
                if (garagem.GaragemId == null)
                {
                    Context.Garagens.Add(garagem);
                }
                else
                {
                    AttachItem(garagem, Context);
                    Context.Entry(garagem).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (DbUpdateException ex) when ((ex.InnerException.InnerException is SqlException && (ex.InnerException.InnerException as SqlException).Number == 2601))
            {
                throw new Exception("Já existe garagem com CNPJ idêntico registrada", ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Garagem ObterGaragemPorId(long? id)
        {
            try
            {
                using EFContext Context = new EFContext();
                Garagem garagem = Context.Garagens.Where(g => g.GaragemId == id).Include(g => g.Veiculos).First();
                return garagem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverGaragemPorId(long? id)
        {
            try
            {
                using EFContext Context = new EFContext();
                Garagem garagem = ObterGaragemPorId(id);
                AttachItem(garagem, Context);
                Context.Garagens.Remove(garagem);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AttachItem(Garagem garagem, EFContext context)
        {
            if (!context.Garagens.Local.Contains(garagem))
            {
                context.Garagens.Attach(garagem);
            }
        }
    }
}
