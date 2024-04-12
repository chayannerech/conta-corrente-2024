using System.ComponentModel.Design;

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

        //Criar o historico de movimentações
        public Movimentacao[] historicoMovimentacoes = new Movimentacao[100];
        int contador = 0; //Para preencher o histórico

        //Criar o extrato da conta
        string[] extrato = new string[100];

        //Movimentações
        public void Saque(Movimentacao movimentacao)
        {
            if (Édebito(movimentacao.naturezaTransacao)) FazSaque(ref saldo, ref limite, movimentacao);
            else FazSaque(ref limite, ref saldo, movimentacao);
        }
        public void Deposito(Movimentacao movimentacao)
        {
            if (Édebito(movimentacao.naturezaTransacao)) FazDeposito(movimentacao.valor, movimentacao);
            else Console.WriteLine("Operação inválida");
        }
        public void Transferência(ContaCorrente contaRecebe, Movimentacao movimentacao)
        {
            if (Édebito(movimentacao.naturezaTransacao)) FazTransferencia(contaRecebe, ref saldo, movimentacao);
            else FazTransferencia(contaRecebe, ref limite, movimentacao);
        }
        public void MostraHistórico()
        {
            Console.WriteLine("\nHistórico de movimentações:");
            for (int i = 0; i < contador; i++) EscreveHistórico(i);
        }
        public void MostraExtrato()
        {
            Console.WriteLine("\nExtrato da Conta Corrente:");
            for (int i = 0; i < contador; i++) Console.WriteLine(extrato[i]);
        }

        //Funções auxiliares
        bool Édebito(string naturezaTransacao)
        {
            return naturezaTransacao == "débito";
        }
        bool Ésuficiente(double valorPossuido, double valorMovimentado)
        {
            return valorPossuido >= valorMovimentado;
        }
        void FazSaque(ref double saldoOUlimite, ref double excedente, Movimentacao movimentacao)
        {
            if (Ésuficiente(saldo, movimentacao.valor - limite))
            {
                saldoOUlimite -= movimentacao.valor;
                //Se o valor do saque for superior ao valor em conta, tira-se o excedente do limite e vice-versa
                if (saldoOUlimite < 0)
                {
                    excedente += saldoOUlimite;
                    saldoOUlimite = 0;
                }
                Console.WriteLine("Saque realizado");
                SalvaHistorico(movimentacao);
                SalvaExtrato(movimentacao, "Saque");
                contador++;
            }
            else Console.WriteLine("Saldo insuficiente");
        }
        void FazDeposito(double valor, Movimentacao movimentacao)
        {
            saldo += valor;
            Console.WriteLine("Depósito realizado");

            SalvaHistorico(movimentacao);
            SalvaExtrato(movimentacao, "Depósito");
            contador++;
        }
        void FazTransferencia(ContaCorrente contaRecebe, ref double saldoOUlimite, Movimentacao movimentacao)
        {
            if (Ésuficiente(saldoOUlimite, movimentacao.valor))
            {
                saldoOUlimite -= movimentacao.valor;
                contaRecebe.saldo += movimentacao.valor;
                Console.WriteLine("Transferência realizada");
                SalvaHistorico(movimentacao);
                SalvaExtrato(movimentacao, $"Transferência de {movimentacao.valor} para {contaRecebe.titular.nome}");
                contador++;
            }
            else Console.WriteLine("Saldo insuficiente");
        }
        void SalvaHistorico(Movimentacao movimentacao)
        {
            historicoMovimentacoes[contador] = movimentacao;
        }
        void SalvaExtrato(Movimentacao movimentacao, string operacao)
        {
            extrato[contador] = $"{operacao} ({DateTime.Now.ToString("t")}) -> saldo = {saldo}; limite = {limite}";
        }
        void EscreveHistórico(int i)
        {
            Console.WriteLine(historicoMovimentacoes[i].valor + " " + historicoMovimentacoes[i].naturezaTransacao);
        }
    }
}