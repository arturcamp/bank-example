using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "L":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Clear();
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Clear();
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);            
        }

        private static void Depositar()
        {
            Console.Clear();
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double ValorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(ValorDeposito);            
        }

        private static void ListarContas()
        {
            Console.Clear();
            if (listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("# {0} -> ", i);
                Console.WriteLine(conta);
            }
            Console.WriteLine("\nDigite alguma tecla para continuar...");
            Console.ReadKey();
        }

        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine("Inserir nova conta.");

            Console.WriteLine("Digite: \n 1 para criar uma conta do tipo Pessoa Física \n 2 para criar uma conta do tipo Pessoa Jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            
            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o crédito disponível: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome
                );

            listContas.Add(novaConta);

            Console.Clear();
            ListarContas();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("####### --- DIO BANK --- #######");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada!");
            Console.WriteLine();
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("L - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
