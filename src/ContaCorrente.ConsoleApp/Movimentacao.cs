
namespace ContaCorrente.ConsoleApp
{
    internal class Movimentacao
    {
        public double valor;
        public string naturezaTransacao; //crédito ou débito;

        public Movimentacao(double valor, string naturezaTransacao)
        {
            this.valor = valor;
            this.naturezaTransacao = naturezaTransacao;
        }

        public int Saque(int a, int b)
        {
            /* Requisitos
                Uma conta corrente só pode fazer saques desde que o valor não exceda o limite de operacao que é o limite + saldo.*/
            
            return a + b;
        }

        decimal depósitos(decimal saldo)
        {
            return saldo;
        }

        decimal Transferência(decimal saldo)
        {
            return saldo;
        }
    }
}
