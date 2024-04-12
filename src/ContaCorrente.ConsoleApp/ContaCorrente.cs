namespace ContaCorrente.ConsoleApp
{
    internal class ContaCorrente
    {
        public double saldo, limite, numeroConta;
        public bool status = false; //especial ou não
        //Cria o titular
        public Usuario titular;

        //Construtor
        public ContaCorrente(double saldo, double limite, bool status, Usuario titular)
        {
            Random numero = new Random();
            this.numeroConta = numero.Next();
            this.saldo = saldo;
            this.limite = limite;
            this.status = status;
            this.titular = titular;
        }

        //Criar o extrato
        public Movimentacao[] extrato = new Movimentacao[100];
        int contador = 0;

        //Movimentações
        public void Saque(Movimentacao movimentacao)
        {
            if (Édebito(movimentacao.naturezaTransacao)) FazSaque(movimentacao.valor, movimentacao);
            else Console.WriteLine("Operação inválida");
        }
        public void Deposito(Movimentacao movimentacao)
        {
            if (Édebito(movimentacao.naturezaTransacao)) FazDeposito(movimentacao.valor, movimentacao);
            else Console.WriteLine("Operação inválida");
        }





        //Funções auxiliares
        public bool Édebito(string naturezaTransacao)
        {
            return naturezaTransacao == "débito";
        }
        public void FazSaque(double valor, Movimentacao movimentacao)
        {
            if (valor <= limite + saldo) SaldoSuficiente(valor, movimentacao);
            else Console.WriteLine("Saldo insuficiente");
        }
        public void SaldoSuficiente(double valor, Movimentacao movimentacao)
        {
            saldo -= valor;

            if (saldo < 0)
            {
                limite += saldo;
                saldo = 0;
            }

            Console.WriteLine("Saque realizado");

            SalvaExtrato(movimentacao);
        }
        public void SalvaExtrato(Movimentacao movimentacao)
        {
            extrato[contador] = movimentacao;
            contador++;
        }
        public void FazDeposito(double valor, Movimentacao movimentacao)
        {
            saldo += valor;
            Console.WriteLine("Depósito realizado");

            SalvaExtrato(movimentacao);
        }
    }
}