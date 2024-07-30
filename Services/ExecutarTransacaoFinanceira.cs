using System;

namespace TransacaoFinanceira
{
    class ExecutarTransacaoFinanceira : AcessoDados
    {
        public void Transferir(uint CorrelationId, uint ContaOrigem, uint ContaDestino, decimal valor)
        {
            ContasSaldo conta_saldo_origem = GetSaldo<ContasSaldo>(ContaOrigem);
            if (conta_saldo_origem.Saldo < valor)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada por falta de saldo", CorrelationId);
            }
            else
            {
                ContasSaldo conta_saldo_destino = GetSaldo<ContasSaldo>(ContaDestino);
                conta_saldo_origem.Saldo -= valor;
                conta_saldo_destino.Saldo += valor;
                Atualizar(conta_saldo_origem);
                Atualizar(conta_saldo_destino);
                Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", CorrelationId, conta_saldo_origem.Saldo, conta_saldo_destino.Saldo);
            }
        }
    }
}