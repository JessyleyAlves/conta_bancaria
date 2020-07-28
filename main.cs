using System;
using System.Threading;
using System.Globalization;

class MainClass {
  public static void Main (string[] args) {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

   //instanciar a classe Conta
   Conta c1 = new Conta();

   string repete ="";

    //gerar numero aleatorio
    //Random aleatorio = new Random();
    //c1.numero = aleatorio.Next(1,10000);

  //pegar o nome do titular da Conta
  Console.Write("Informe seu nome completo: ");
  Console.ForegroundColor = ConsoleColor.Green;
  c1.nome = Console.ReadLine();

do{
  Console.Clear();
  Console.ForegroundColor = ConsoleColor.White;
  Console.WriteLine("Bem Vindo: " + c1.nome);
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.Write("=======================================");
  Console.WriteLine("\n");
  Console.WriteLine("Saldo atual: " + c1.saldo.ToString("c"));
  Console.WriteLine("\n");
  Console.Write("=======================================");
  Console.ForegroundColor = ConsoleColor.White;
  Console.WriteLine("\n");
  Console.WriteLine("Escolha uma das opções abaixo: ");
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine("\n");
  Console.WriteLine("1 - Deposito");
  Console.WriteLine("2 - Saque");
  Console.WriteLine("3 - Empréstimo");
  Console.WriteLine("4 - Sair");
  Console.Write("Opção desejada >> ");
  Console.ForegroundColor = ConsoleColor.Green;
  int opcao = int.Parse(Console.ReadLine());
  Console.WriteLine("\n");
  Console.ForegroundColor = ConsoleColor.White;

  

  double valor_dep = 0;
  double valor_saq = 0;
  

  switch(opcao)
  {
  case 1:
    Console.Write("Valor a depositar: R$");
    valor_dep = double.Parse(Console.ReadLine());
    c1.depositar(valor_dep);
    //Salvar o log
    break;

  case 2:
    Console.Write("Valor a sacar: R$");
    valor_saq = double.Parse(Console.ReadLine());
    c1.sacar(valor_saq);
    break;

  case 4:
    Console.Write("Pessione Enter para Sair");
    Console.ReadKey();
    Console.Clear();
    break;

  case 3:
  double valor_emprestimo = 0;
  int qtd_parcelas = 0;

  Console.Write("Digite o valor do empréstimo: R$");
  valor_emprestimo = double.Parse(Console.ReadLine());

  Console.Write("Digite a quantidade de parcelas -> 12, 24, 36 ou 48: ");
  qtd_parcelas = int.Parse(Console.ReadLine());

  //chamada do metodo
  c1.emprestar(valor_emprestimo,qtd_parcelas);
  break;

  default:
    Console.Write("Opção Inválida.");
    break;
  }

  Console.ForegroundColor = ConsoleColor.White;
  Console.Write("Deseja realizar outra operação(s/n): ");
  repete = Console.ReadLine();
  }while(repete == "s");

  Console.WriteLine("OPERAÇÃO ENCERRADA");  

  }
}