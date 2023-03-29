using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAgendaCodeFirst.Models
{
    public abstract class AProcedimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Duracao { get; set; }
        public Decimal Valor { get; set; }
    }
}