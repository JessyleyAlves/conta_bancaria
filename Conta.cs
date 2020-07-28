using System;
using System.IO;
 
class Conta{
 public int numero;
 public string nome;
 public double saldo;
 public DateTime hoje = DateTime.Today;

 //Cria o arquivo de texto
  StreamWriter io = new StreamWriter("conta.txt", true);

public void SalvarTxt(string opcao, double valor)
{
  io.WriteLine(hoje.ToString("dd/MM/yyyy") + ";" +
    opcao + ";" +
    this.nome + ";" +
    valor.ToString("c") + ";" +
    this.saldo.ToString("c"));
    io.Flush();

  Console.ForegroundColor = ConsoleColor.Red;
 Console.WriteLine("{0} realizado com sucesso.\n", opcao);
 Console.ResetColor();
}
 
 
 public void depositar(double valor){
 this.saldo += valor;
 Console.WriteLine("Saldo atual: " + saldo.ToString("c"));
 
 SalvarTxt("Depósito",valor);
 }

 //Método para realizar Empréstimo
 public void emprestar(double valor, int qtd_parcelas)
 {
   double total_juros = 0;
   double valor_parcela = 0;
   double juros = 0.0255;
   double final = 0;

   total_juros = (qtd_parcelas * juros * valor);
   valor_parcela = (total_juros + valor) / qtd_parcelas;
   final = total_juros + valor;

  //acrescenta o emprestimo ao SALDO da Conta
  this.saldo += valor;
  Console.ResetColor();

  Console.WriteLine($"Valor do Emprestimo       -> {valor.ToString("c")}");
  Console.WriteLine($"Valor da Parcela          -> {qtd_parcelas}X de {valor_parcela.ToString("c")}");
  Console.WriteLine($"Valor Total do Empréstimo -> {final.ToString("c")}");

  Console.ForegroundColor = ConsoleColor.Magenta;
  Console.WriteLine($"Juros do Empréstimo       -> {total_juros.ToString("c")}");

  Console.WriteLine("\n"); 
  //salva no arquivo de texto
  SalvarTxt("Emprestimo", valor);

 }
 
 //Método para realizar Saque
 public void sacar(double valor){
 //se houver saldo disponivel, realize o saque
  if(this.saldo >= valor)
  {
  this.saldo -= valor;
  Console.WriteLine("Saldo Atual " + this.saldo.ToString("c") + "\n");
  SalvarTxt("Saque", valor);
  }
  else
  if(this.saldo < valor)
  {
    this.saldo += 600;
    this.saldo -= valor;
    Console.WriteLine("Saldo Atual " + this.saldo.ToString("c") + "\n");
  SalvarTxt("Saque", valor);
  }
  else
  {
  Console.WriteLine("Saldo Insuficiente" + this.saldo.ToString("c") + "\n");
  }
 }
}