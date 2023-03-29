using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAgendaCodeFirst.Models
{
    public abstract class ICliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Nascimento { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }

    }
}
