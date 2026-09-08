using System;
using System.Data.Common;

class Program
{
  static void Main()
  {

    Random nahoda = new Random();


    Console.WriteLine("Napiš 1 aby jsi hodil kostkou");
    if (Console.ReadLine() != "1")
      return;
    int nahodaHrace = nahoda.Next(1, 7);
    int nahodaPocitace = nahoda.Next(1, 7);
    if (nahodaHrace > nahodaPocitace)
    {
      Console.WriteLine($"Vyhral jsi, pocitac hodil {nahodaPocitace}");
    }
    if (nahodaPocitace > nahodaHrace)
      Console.WriteLine($"Počítač vyhrál, hodil {nahodaPocitace}");




















  }
}