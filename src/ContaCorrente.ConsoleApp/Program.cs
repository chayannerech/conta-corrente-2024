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
            ContaCorrente DuduMendigo = new ContaCorrente(30.00, 100.00, false, Dudu);

            //Informa que uma movimentação de valor X será realizada
            Movimentacao movimentacao = new Movimentacao(50, "débito");

            //Realiza a movimentação
            DuduMendigo.Saque(movimentacao);
            ChayDeusa.Deposito(movimentacao);

            Movimentacao movimentacao2 = new Movimentacao(10, "crédito");
            DuduMendigo.Transferência(ChayDeusa, movimentacao2);

            DuduMendigo.MostraSaldo();
            DuduMendigo.MostraExtrato();

            Console.Read();
        }
    }
}
