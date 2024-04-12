using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Informar os titulares
            Usuario Chay = new Usuario("Chay", "Deusa", "904.540.122-36");
            Usuario Dudu = new Usuario("Dudu", "Mendigo", "000.000.000-00");

            //Criar conta corrente
            ContaCorrente ChayDeusa = new ContaCorrente(100000.00, 1000000.00, true, Chay);
            ContaCorrente DuduMendigo = new ContaCorrente(0.30, 100.00, false, Dudu);

            Movimentacao movimentacao = new Movimentacao(0, "débito");

            DuduMendigo.Saque(movimentacao);
            ChayDeusa.Deposito(movimentacao);
            Transferência(DuduMendigo, ChayDeusa, 0);

            Console.Read();
        }

        static void Transferência(ContaCorrente contaPaga, ContaCorrente contaRecebe, double valor)
        {
            if (contaPaga.saldo >= valor) FazTransferencia(contaPaga, contaRecebe, valor);
            else Console.WriteLine("Saldo insuficiente");
        }
        static void FazTransferencia(ContaCorrente contaPaga, ContaCorrente contaRecebe, double valor)
        {
            contaPaga.saldo -= valor;
            contaRecebe.saldo += valor;
        }
        void VisualizacaoSaldo(int aaa)
        {
            Console.WriteLine(aaa);
        }
        void VisualizacaoExtrato()
        {
            Console.WriteLine();
        }
    }
}
