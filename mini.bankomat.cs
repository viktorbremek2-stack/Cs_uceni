using System;

class Program
{
  static void Main()
  {
    int zustatek = 1000;
    string volba;
    Console.WriteLine("Ahoj! Vítej v Bankomatu! Začni tím že si vybereš - napiš číslo podle toho co chceš, počáteční zůstatek máš 1000kč \n1 - Zobrazit zůstatek\n2 - Vložit peníze\n3 - Vybrat peníze\n4 - Konec");

    do
    {

      volba = Console.ReadLine() ?? "";

      if (volba == "1")
      {
        Console.WriteLine($" Tvuj zůstatek je {zustatek}, Vyber si další číslo 1/2/3/4");
      }
      else if (volba == "2")
      {
        Console.WriteLine("Kolik chceš vložit?");

        int vklad = int.Parse(Console.ReadLine() ?? "0");

        zustatek = zustatek + vklad;

        Console.WriteLine($"Vložil jsi {vklad} Kč.");
        Console.WriteLine($"Nový zůstatek je {zustatek} Kč. Vyber si další číslo 1/2/3/4");
      }
      else if (volba == "3")
      {
        Console.WriteLine("Kolik si chceš vybrat?");
        int Vybrat = int.Parse(Console.ReadLine() ?? "0");
        zustatek = zustatek - Vybrat;
        Console.WriteLine($"Tvů zůstatek je: {zustatek}, vyber si další číslo 1/2/3/4");
      }
      else if (volba == "4")
      {
        Console.WriteLine("Konec.");
      }
      else
      {
        Console.WriteLine("Neplatná volba. Vyber si číslo 1/2/3/4");
      }
    }
    while (volba != "4");
  }
}