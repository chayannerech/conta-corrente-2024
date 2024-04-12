
using System.Reflection.Metadata;

namespace ContaCorrente.ConsoleApp
{
    internal class Movimentacao
    {
        public double valor;
        public string naturezaTransacao; //crédito ou débito;

        //Construtor
        public Movimentacao(double valor, string naturezaTransacao)
        {
            this.valor = valor;
            this.naturezaTransacao = naturezaTransacao;
        }
    }
}
