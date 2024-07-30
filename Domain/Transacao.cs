namespace TransacaoFinanceira
{
    class Transacao
    {
        /// <summary>
        /// todas as variáveis alteradas para uint;
        /// </summary>

        public uint CorrelationId { get; set; }
        public string DateTime { get; set; }
        public uint ContaOrigem { get; set; }
        public uint ContaDestino { get; set; }
        public decimal VALOR { get; set; }
    }
}
