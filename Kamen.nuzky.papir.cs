using System;

class Program
{
  static void Main()
  {
    Random nahoda = new Random();
    int pocitac;

    Console.WriteLine("Vyber si jedno: kamen/nuzky/papir");


    string hrac = Console.ReadLine()!.ToLower().Trim();

    // Generování volby počítače (1 = kámen, 2 = nůžky, 3 = papír)
    pocitac = nahoda.Next(1, 4);

    if (pocitac == 1)
      Console.WriteLine("Počítač si vybral: kamen");
    else if (pocitac == 2)
      Console.WriteLine("Počítač si vybral: nuzky");
    else if (pocitac == 3)
      Console.WriteLine("Počítač si vybral: papir");


    if ((hrac == "kamen" && pocitac == 2) ||

        (hrac == "nuzky" && pocitac == 3) ||

        (hrac == "papir" && pocitac == 1))
    {
      Console.WriteLine("Vyhrál jsi!");
    }
    else if ((hrac == "kamen" && pocitac == 1) ||
             (hrac == "nuzky" && pocitac == 2) ||
            (hrac == "papir" && pocitac == 3))
    {
      Console.WriteLine("Remíza!");
    }
    else
    {

      Console.WriteLine("Prohrál jsi!");
    }
  }
}




















