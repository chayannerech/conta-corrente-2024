namespace ContaCorrente.ConsoleApp
{
    internal class ContaCorrente
    {
        public double saldo, limite, numeroConta;
        public bool status = false; //especial ou não
        Random conta = new Random();

        Usuario Cliente = new Usuario("nome", "sobrenome", "cpf");

        public ContaCorrente(double saldo, double limite, bool status, Usuario cliente)
        {
            this.numeroConta = conta.Next();
            this.saldo = saldo;
            this.limite = limite;
            this.status = status;
            Cliente = cliente;
        }

        void VisualizacaoSaldo(int aaa)
        {
            Console.WriteLine(aaa);
        }
        void VisualizaçãoExtrato()
        {
            Console.WriteLine();
        }
    }
}