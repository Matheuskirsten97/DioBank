using System;
using System.Collections.Generic;

namespace DIO.Bank
{
	class Program
	{
		static List<Conta> ListaContas = new List<Conta>();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						OpcaoTransferir();
						break;
					case "4":
						OpcaoSacar();
						break;
					case "5":
						OpcaoDepositar();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
				opcaoUsuario = ObterOpcaoUsuario();
			}
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

        private static void OpcaoDepositar()
        {
			Console.WriteLine("Digite o numero da Conta: ");
			int indeceConta = int.Parse(Console.ReadLine());
			Console.WriteLine("Digito o valor do depósito: ");
			double valorDeposito = double.Parse(Console.ReadLine());
			ListaContas[indeceConta].Depositar(valorDeposito);
        }

        private static void OpcaoSacar()
        {
			Console.WriteLine("Digite o numero da Conta: ");
			int indiceConta = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());
			ListaContas[indiceConta].Sacar(valorSaque);
		}

        private static void OpcaoTransferir()
        {
			Console.WriteLine("Qual o numero da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());
			Console.WriteLine("Qual o numero da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite o valor a ser depositado: ");
			double valorTransferencia = double.Parse(Console.ReadLine());
			ListaContas[indiceContaOrigem].Transferir(valorTransferencia, ListaContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
			Console.WriteLine("Inserir nova Conta");

			Console.WriteLine("Digite 1 para pessoa fisica e 2 para pessoa juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite o nome do cliente: ");
			string entradaNome = Console.ReadLine();
			Console.WriteLine("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());
			Console.WriteLine("Digite o saldo de crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										nome: entradaNome,
										credito: entradaCredito);
			ListaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
			Console.WriteLine("Listar Contas");
				if (ListaContas.Count == 0)
				{
				Console.WriteLine("Nenhuma conta cadastrada");
				return;
				}
				for (int i = 0; i < ListaContas.Count; i++)
				{
				Conta conta = ListaContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
				}
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}

