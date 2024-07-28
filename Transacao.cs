using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira
{
    class Transacao
    {
        public int CorrelationId { get; set; }
        public string DateTime { get; set; }
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public decimal VALOR { get; set; }
    }
}
