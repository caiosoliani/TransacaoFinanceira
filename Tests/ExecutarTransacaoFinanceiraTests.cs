using Xunit;

namespace TransacaoFinanceira.Tests
{
    /// <summary>
    /// implementação de testes unitários.
    /// </summary>
    public class ExecutarTransacaoFinanceiraTests
    {
        [Fact]
        public void Transferir_TransacaoComSaldoSuficiente_DeveAtualizarSaldos()
        {
            var executor = new ExecutarTransacaoFinanceira();
            uint correlationId = 1;
            uint contaOrigem = 938485762;
            uint contaDestino = 2147483649;
            decimal valor = 50;

            executor.Transferir(correlationId, contaOrigem, contaDestino, valor);

            var saldoOrigem = executor.GetSaldo<ContasSaldo>(contaOrigem).Saldo;
            var saldoDestino = executor.GetSaldo<ContasSaldo>(contaDestino).Saldo;
            Assert.Equal(130, saldoOrigem);
            Assert.Equal(50, saldoDestino);
        }

        [Fact]
        public void Transferir_TransacaoSemSaldoSuficiente_DeveCancelarTransacao()
        {
            var executor = new ExecutarTransacaoFinanceira();
            uint correlationId = 2;
            uint contaOrigem = 2147483649;
            uint contaDestino = 210385733;
            decimal valor = 100;

            executor.Transferir(correlationId, contaOrigem, contaDestino, valor);

            var saldoOrigem = executor.GetSaldo<ContasSaldo>(contaOrigem).Saldo;
            var saldoDestino = executor.GetSaldo<ContasSaldo>(contaDestino).Saldo;
            Assert.Equal(0, saldoOrigem);
            Assert.Equal(10, saldoDestino);
        }

        [Fact]
        public void Transferir_TransacaoComSaldoSuficiente_DevePersistirSaldos()
        {
            var executor = new ExecutarTransacaoFinanceira();
            uint correlationId = 3;
            uint contaOrigem = 347586970;
            uint contaDestino = 238596054;
            decimal valor = 100;

            executor.Transferir(correlationId, contaOrigem, contaDestino, valor);

            var saldoOrigem = executor.GetSaldo<ContasSaldo>(contaOrigem).Saldo;
            var saldoDestino = executor.GetSaldo<ContasSaldo>(contaDestino).Saldo;
            Assert.Equal(1100, saldoOrigem);
            Assert.Equal(578, saldoDestino);
        }
    }
}