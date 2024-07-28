using System;
using System.Collections.Generic;
using Xunit;

namespace TransacaoFinanceira.Tests
{
    public class ExecutarTransacaoFinanceiraTests
    {
        [Fact]
        public void Transferir_TransacaoComSaldoSuficiente_DeveAtualizarSaldos()
        {
            // Arrange
            var executor = new ExecutarTransacaoFinanceira();
            int correlationId = 1;
            int contaOrigem = 938485762;
            int contaDestino = 214748364;
            decimal valor = 50;

            // Act
            executor.Transferir(correlationId, contaOrigem, contaDestino, valor);

            // Assert
            var saldoOrigem = executor.GetSaldo<ContasSaldo>(contaOrigem).Saldo;
            var saldoDestino = executor.GetSaldo<ContasSaldo>(contaDestino).Saldo;
            Assert.Equal(130, saldoOrigem); // 180 - 50
            Assert.Equal(50, saldoDestino); // 0 + 50
        }

        [Fact]
        public void Transferir_TransacaoSemSaldoSuficiente_DeveCancelarTransacao()
        {
            // Arrange
            var executor = new ExecutarTransacaoFinanceira();
            int correlationId = 2;
            int contaOrigem = 214748364;
            int contaDestino = 210385733;
            decimal valor = 100;

            // Act
            executor.Transferir(correlationId, contaOrigem, contaDestino, valor);

            // Assert
            var saldoOrigem = executor.GetSaldo<ContasSaldo>(contaOrigem).Saldo;
            var saldoDestino = executor.GetSaldo<ContasSaldo>(contaDestino).Saldo;
            Assert.Equal(0, saldoOrigem); // Saldo não deve mudar
            Assert.Equal(10, saldoDestino); // Saldo não deve mudar
        }

        [Fact]
        public void Transferir_TransacaoComSaldoSuficiente_DevePersistirSaldos()
        {
            // Arrange
            var executor = new ExecutarTransacaoFinanceira();
            int correlationId = 3;
            int contaOrigem = 347586970;
            int contaDestino = 238596054;
            decimal valor = 100;

            // Act
            executor.Transferir(correlationId, contaOrigem, contaDestino, valor);

            // Assert
            var saldoOrigem = executor.GetSaldo<ContasSaldo>(contaOrigem).Saldo;
            var saldoDestino = executor.GetSaldo<ContasSaldo>(contaDestino).Saldo;
            Assert.Equal(1100, saldoOrigem); // 1200 - 100
            Assert.Equal(578, saldoDestino); // 478 + 100
        }
    }
}