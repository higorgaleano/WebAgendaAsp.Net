using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAgendaCodeFirst.Models;

namespace WebAgendaCodeFirst.DAL
{
    public interface IProcedimentosDAL
    {
        // Contratos
        List<Procedimento> ExibirGridProcedimento();
        
        void CadastrarProcedimento(Procedimento objCliente);
        
        Procedimento ConsultarProcedimento(int identificador);

        void AlterarProcedimento(Procedimento proced, int identificador);

        void ExcluirProcedimento(int identificador);
    }
}
