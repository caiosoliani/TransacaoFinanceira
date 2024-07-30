namespace TransacaoFinanceira
{
    /// <summary>
    /// todas as variáveis alteradas para uint;
    /// </summary>
    class ContasSaldo
    {
        public ContasSaldo(uint Conta, decimal Valor)
        {
            this.Conta = Conta;
            this.Saldo = Valor;
        }

        public uint Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}