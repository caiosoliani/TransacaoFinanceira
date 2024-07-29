namespace TransacaoFinanceira
{
    class ContasSaldo
    {
        public ContasSaldo(int Conta, decimal Valor)
        {
            this.Conta = Conta;
            this.Saldo = Valor;
        }

        public int Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}