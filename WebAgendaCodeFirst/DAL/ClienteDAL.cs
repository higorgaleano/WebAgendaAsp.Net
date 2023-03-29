using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAgendaCodeFirst.Models;

namespace WebAgendaCodeFirst.DAL
{
    public class ClienteDAL : IClienteDAL
    {
        private readonly Contexto dbContexto;
        
        public ClienteDAL(Contexto dbContexto) // ctor com DI
        {
            this.dbContexto = dbContexto;
            
        }

        // contratos do IClienteDAL
        public void CadastrarCliente(Cliente objCliente)
        {
            dbContexto.Clientes.Add(objCliente);
            dbContexto.SaveChanges();
        }

        public Cliente ConsultarCliente(int identificador)
        {
            var consulta = dbContexto.Clientes.First(c => c.Id == identificador);
            return consulta;
        }

        public void AlterarCliente(Cliente cli, int identificador)
        {
            Cliente objCliente = dbContexto.Clientes.First(c => c.Id == identificador);
            objCliente.Nome = cli.Nome;
            objCliente.Telefone = cli.Telefone;
            objCliente.Nascimento = cli.Nascimento;
            objCliente.Observacao = cli.Observacao;
            objCliente.Ativo = cli.Ativo;
            dbContexto.SaveChanges();
        }

        public void ExcluirCliente(int identificador)
        {
            Cliente objCliente = dbContexto.Clientes.First(c => c.Id == identificador);
            dbContexto.Remove(objCliente);
            dbContexto.SaveChanges();
        }
    }
}