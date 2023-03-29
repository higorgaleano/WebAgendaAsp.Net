using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAgendaCodeFirst.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Horario { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; } 
        public string Observacao { get; set; }
       
        [ForeignKey("Id")]
        public int ClienteId { get; set; }

        [ForeignKey("Id")]
        public int ProcedimentoId { get; set; }

        public Cliente Cliente { get; set; }
        public Procedimento Procedimento { get; set; }

    }
}