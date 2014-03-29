using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dona.DateTimeUtc.model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtAniversario { get; set; }
        public DateTime DtCriacao { get; set; }
        public bool IsActive { get; set; }
    }
}
