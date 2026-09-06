using System;

class Program
{
  static void Main()
  {
    int tajneCislo = 43;
    int tip;

    do
    {
      Console.WriteLine("Tipni si číslo");
      tip = Convert.ToInt32(Console.ReadLine());
      if (tip < tajneCislo)
      {
        Console.WriteLine("Tvoje číslo je menší než tajné číslo");
      }
      else if (tip > tajneCislo)
      {
        Console.WriteLine("Tvoje číslo je větší než tajné číslo");
      }
      if (tip == tajneCislo)
      {
        Console.WriteLine("Uhodl jsi tajné číslo!!! Gratuluji";

      }
    }
    while (tip != tajneCislo);

  }
}
