using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAgendaCodeFirst.Models;

namespace WebAgendaCodeFirst.DAL
{
    public class ProcedimentoDAL : IProcedimentosDAL
    {
        // ctor com DI
        protected readonly Contexto dbContexto;

        public ProcedimentoDAL(Contexto dbContexto)
        {
            this.dbContexto = dbContexto;
        }


        // Contratos do IProcedimentoDAL
        public List<Procedimento> ExibirGridProcedimento()
        {
            var data = (from p in dbContexto.Procedimentos where p.Id > 0 select p);

            return data.ToList();
        }

        public void CadastrarProcedimento(Procedimento objProcedimento)
        {        
            dbContexto.Add(objProcedimento);
            dbContexto.SaveChanges();
        }

        public Procedimento ConsultarProcedimento(int identificador)
        {
            Contexto dbcontexto = new Contexto();
            
            var consulta = dbcontexto.Procedimentos.FirstOrDefault(p => p.Id == identificador);
            return consulta;
        }

        public void AlterarProcedimento(Procedimento proced, int identificador)
        {          
            Procedimento objProcedimento = dbContexto.Procedimentos.First(p => p.Id == identificador);
            objProcedimento.Nome = proced.Nome;
            objProcedimento.Duracao = proced.Duracao;
            objProcedimento.Valor = proced.Valor;
            dbContexto.SaveChanges();
        }

        public void ExcluirProcedimento(int identificador)
        {
            Procedimento objProcedimento = dbContexto.Procedimentos.First(p => p.Id == identificador);
            dbContexto.Remove(objProcedimento);
            dbContexto.SaveChanges();
        }
        
    }
}