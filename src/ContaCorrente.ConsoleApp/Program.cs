using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario Chay = new Usuario("Chay", "Deusa", "904.540.122-36");
            Usuario Dudu = new Usuario("Dudu", "Mendigo", "000.000.000-00");

            ContaCorrente DuduMendigo = new ContaCorrente(0.30, 100.00, false, Chay);
            ContaCorrente ChayDeusa = new ContaCorrente(100000.00, 1000000.00, false, Dudu);

            Movimentacao extrato = new Movimentacao(10, "débito");
)
            DuduMendigo.operacao.Saque(1, 2);
            
            
            Console.Read();
        }
    }
}
