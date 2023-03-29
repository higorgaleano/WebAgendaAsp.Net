using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAgendaCodeFirst.Models;

namespace WebAgendaCodeFirst.DAL
{
    public interface IClienteDAL
    {

        // contratos
        void CadastrarCliente(Cliente objCliente);

        Cliente ConsultarCliente(int identificador);

        void AlterarCliente(Cliente cli, int identificador);

        void ExcluirCliente(int identificador);

    }
}
