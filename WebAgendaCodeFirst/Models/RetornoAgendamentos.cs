using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAgendaCodeFirst.Models
{
    public class RetornoAgendamentos
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }   
        public string Horario { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
        public string ClienteNome { get; set; }
        public string ProcedimentoNome { get; set; }
        public DateTime ProcedimentoDuracao { get; set; }

    }
}