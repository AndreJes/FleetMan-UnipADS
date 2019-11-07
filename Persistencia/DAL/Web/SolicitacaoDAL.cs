﻿using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class SolicitacaoDAL : DALContext
    {
        public IEnumerable<Solicitacao> ObterSolicitacoesOrdPorId()
        {
            return Context.Solicitacoes.OrderBy(s => s.SolicitacaoId).ToList();
        }

        public Solicitacao ObterSolicitacaoPorId(long? id)
        {
            return Context.Solicitacoes.Where(s => s.SolicitacaoId == id).FirstOrDefault();
        }

        public void GravarSolicitacao(Solicitacao solicitacao)
        {
            Context.Solicitacoes.Add(solicitacao);
            Context.SaveChanges();
        }
    }
}
