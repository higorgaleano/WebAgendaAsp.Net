using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAgendaCodeFirst.Models;

namespace WebAgendaCodeFirst.DAL
{
    public class AgendamentoDAL
    {
        public List<Cliente> ListarClientes()
        {
            Contexto dbContexto = new Contexto();

            var consulta = dbContexto.Clientes.Where(c => c.Ativo == true)
                .OrderBy(c => c.Nome)
                .ToList();

            return consulta.ToList();
        }

        public List<Procedimento> ListarProcedimentos()
        {
            Contexto dbContexto = new Contexto();

            var consulta = dbContexto.Procedimentos.Where(p => p.Id > 0)
                .OrderBy(p => p.Nome)
                .ToList();

            return consulta;
        }

        public Procedimento ConsultarIdProcedimento(int identificador)
        {
            Contexto dbContexto = new Contexto();

            var consulta = dbContexto.Procedimentos.FirstOrDefault(p => p.Id == identificador);

            return consulta;
        }

        public List<RetornoAgendamentos> ExibirGridAgendamento()
        {
            Contexto dbContexto = new Contexto();

            var data = (from a in dbContexto.Agendamentos
                        join c in dbContexto.Clientes
                        on a.ClienteId equals c.Id
                        join p in dbContexto.Procedimentos
                        on a.ProcedimentoId equals p.Id
                        where a.Id > 0 && a.Status != "Concluído"
                        select new RetornoAgendamentos
                        {
                            Id = a.Id,
                            Data = a.Data,
                            Horario = a.Horario,
                            Valor = a.Valor,
                            Status = a.Status,
                            Observacao = a.Observacao,
                            ClienteNome = c.Nome,
                            ProcedimentoNome = p.Nome
                        }).OrderBy(a => a.Data).ThenBy(a => a.Horario).ToList();

            return data;
        }

        public List<RetornoAgendamentos> ExibirGridAgendamentoConcluido()
        {
            var dbContexto = new Contexto();

            var data = (from a in dbContexto.Agendamentos
                        join c in dbContexto.Clientes
                        on a.ClienteId equals c.Id
                        join p in dbContexto.Procedimentos
                        on a.ProcedimentoId equals p.Id
                        where a.Id > 0 && a.Status == "Concluído"
                        select new RetornoAgendamentos
                        {
                            Id = a.Id,
                            Data = a.Data,
                            Horario = a.Horario,
                            Valor = a.Valor,
                            Status = a.Status,
                            Observacao = a.Observacao,
                            ClienteNome = c.Nome,
                            ProcedimentoNome = p.Nome
                        }).OrderBy(a => a.Data).ThenBy(a => a.Horario).ToList();

            return data;
        }

        public void CadastrarAgendamento(Agendamento objAgendamento)
        {
            Contexto dbContexto = new Contexto();

            dbContexto.Agendamentos.Add(objAgendamento);
            dbContexto.SaveChanges();
        }

        public List<RetornoAgendamentos> VerificarHorariosDisponiveis(DateTime identificadorData)
        {
            Contexto dbContexto = new Contexto();

            var consulta = (from a in dbContexto.Agendamentos
                            join p in dbContexto.Procedimentos
                            on a.ProcedimentoId equals p.Id
                            where a.Data == identificadorData
                            select new RetornoAgendamentos
                            {
                                Data = a.Data,
                                Horario = a.Horario,
                                ProcedimentoDuracao = p.Duracao
                            }).ToList();

            return consulta;
        }

        public Agendamento ConsultarAgendamentoNaGrid(int identificador)
        {
            Contexto dbContexto = new Contexto();

            var consulta = dbContexto.Agendamentos.First(a => a.Id == identificador);

            return consulta;
        }

        public void AlterarAgendamento(Agendamento Agend, int identificador)
        {
            Contexto dbContexto = new Contexto();

            Agendamento objAgendamento = dbContexto.Agendamentos.First(a => a.Id == identificador);
            objAgendamento.Data = Agend.Data;
            objAgendamento.Horario = Agend.Horario;
            objAgendamento.ProcedimentoId = Agend.ProcedimentoId;
            objAgendamento.Status = Agend.Status;
            objAgendamento.Observacao = Agend.Observacao;
            dbContexto.SaveChanges();
        }

        public void AlteraAgendamentoConfirmadosAposDataAtual(int identificador)
        {
            Contexto dbContexto = new Contexto();

            Agendamento objAgendamento = dbContexto.Agendamentos.First(a => a.Id == identificador);
            objAgendamento.Status = "Concluído";
            dbContexto.SaveChanges();
        }

        public void ExcluirAgendamento(int identificador)
        {
            Contexto dbContexto = new Contexto();

            Agendamento objAgendamento = dbContexto.Agendamentos.First(a => a.Id == identificador);
            dbContexto.Remove(objAgendamento);
            dbContexto.SaveChanges();
        }

        public List<Agendamento> ConsultarFaturamentoProcedimento1()
        {
            Contexto dbContexto = new Contexto();

            var consulta = dbContexto.Agendamentos
                .Where(a => a.ProcedimentoId == 8 && a.Status == "Concluído")
                .OrderByDescending(a => a.Data); ;
            return consulta.ToList();   
        }

        public List<Agendamento> ConsultarFaturamentoProcedimento2()
        {
            Contexto dbContexto = new Contexto();

            var consulta = dbContexto.Agendamentos
                .Where(a => a.ProcedimentoId == 9 && a.Status == "Concluído")
                .OrderByDescending(a => a.Data); ;
            return consulta.ToList();
        }

        public List<Agendamento> ConsultarFaturamentoProcedimento3()
        {
            Contexto dbContexto = new Contexto();

            var consulta = dbContexto.Agendamentos
                .Where(a => a.ProcedimentoId == 10 && a.Status == "Concluído")
                .OrderByDescending(a => a.Data);
            return consulta.ToList();
        }

        public List<Agendamento> ConsultarFaturamentoTotal()
        {
            Contexto dbContexto = new Contexto();

            var consulta = dbContexto.Agendamentos
                .Where(a => a.Status == "Concluído")
                .OrderByDescending(a => a.Data);
            return consulta.ToList();
        }

    }

}