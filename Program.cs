using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransacaoFinanceira
{
    namespace TransacaoFinanceira
    {
        class Program
        {
           static void Main(string[] args)
            {
                var TRANSACOES = new List<Transacao>
            {
                new Transacao { CorrelationId = 1, DateTime = "09/09/2023 14:15:00", ContaOrigem = 938485762, ContaDestino = 214748364, VALOR = 150 },
                new Transacao { CorrelationId = 2, DateTime = "09/09/2023 14:15:05", ContaOrigem = 214748364, ContaDestino = 210385733, VALOR = 149 },
                new Transacao { CorrelationId = 3, DateTime = "09/09/2023 14:15:29", ContaOrigem = 347586970, ContaDestino = 238596054, VALOR = 1100 },
                new Transacao { CorrelationId = 4, DateTime = "09/09/2023 14:17:00", ContaOrigem = 675869708, ContaDestino = 210385733, VALOR = 5300 },
                new Transacao { CorrelationId = 5, DateTime = "09/09/2023 14:18:00", ContaOrigem = 238596054, ContaDestino = 674038564, VALOR = 1489 },
                new Transacao { CorrelationId = 6, DateTime = "09/09/2023 14:18:20", ContaOrigem = 573659065, ContaDestino = 563856300, VALOR = 49 },
                new Transacao { CorrelationId = 7, DateTime = "09/09/2023 14:19:00", ContaOrigem = 938485762, ContaDestino = 214748364, VALOR = 44 },
                new Transacao { CorrelationId = 8, DateTime = "09/09/2023 14:19:01", ContaOrigem = 573659065, ContaDestino = 675869708, VALOR = 150 }
            };
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                ExecutarTransacaoFinanceira executor = new ExecutarTransacaoFinanceira();
                TRANSACOES.ForEach(item =>
                {
                    executor.Transferir(item.CorrelationId, item.ContaOrigem, item.ContaDestino, item.VALOR);
                });
                // Parallel.ForEach(TRANSACOES, item =>
                // {
                //     executor.Transferir(item.CorrelationId, item.ContaOrigem, item.ContaDestino, item.VALOR);
                // });
                watch.Stop();
                Console.WriteLine(watch.Elapsed.ToString());
            }
        }
    }
}