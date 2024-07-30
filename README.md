# TransacaoFinanceira
Case para refatoração

Passos a implementar:
1. Corrija o que for necessario para resolver os erros de compilação.
2. Execute o programa para avaliar a saida, identifique e corrija o motivo de algumas transacoes estarem sendo canceladas mesmo com saldo positivo e outras sem saldo sendo efetivadas.
3. Aplique o code review e refatore conforme as melhores praticas(SOLID,Patterns,etc).
4. Implemente os testes unitários que julgar efetivo.
5. Crie um git hub e compartilhe o link respondendo o ultimo e-mail.

Obs: Voce é livre para implementar na linguagem de sua preferência desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.


# ALTERAÇÕES NO PROJETO

 -> Para o projeto compilar corretamente foi alterada a Matriz de transações - havia um problema de Matriz implícita e o compilador não conseguia inferir o tipo da Matriz "TRANSAÇÕES";
 
 -> Foi alterado o parametro Conta Destino para {2} (antes {3}) para corrigir algumas transações erradas;
 
 -> Foram alterados o tipo dos parâmetros de Conta de INT para UINT devido o tamanho do campo conta ser maior do que o suportado pelo tipo INT;
 
 -> Foi aplicada refatoração e separação das classes para o modelo SOLID, deixando a resposabilidade definida para cada classe e tornando a arquitetura mais limpa;
 
 -> Foi aplicado o "///summary" para explicações das alterações nas classes sem excessos de comentários;
 
 -> Foram criados os seguintes testes unitários: 

		1. Transferir_TransacaoComSaldoSuficiente_DeveAtualizarSaldos: Verificação se as contas de origem e destino são atualizadas corretamente quando há saldo suficiente na conta de origem;

		2. Transferir_TransacaoSemSaldoSuficiente_DeveCancelarTransacao: Este teste Verificação se a transação é cancelada corretamente quando não há saldo suficiente na conta de origem;

		3. Transferir_TransacaoComSaldoSuficiente_DevePersistirSaldos: Verificação se os saldos atualizados são persistidos corretamente após uma transação bem-sucedida.