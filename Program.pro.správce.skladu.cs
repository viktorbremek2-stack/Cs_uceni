using System;
using System.Net;

class Program
{
  static void Main(string[] args)
  {
    List<string> sklad = new List<string>();

    sklad.Add("MacBook Air M4");
    sklad.Add("iPad Air");
    sklad.Add("AirPods Pro");
    sklad.Add("Apple Watch");
    ZobrazitMenu();



    do
    {


      string volba = Console.ReadLine() ?? "";

      if (volba == "1")
      {
        Console.WriteLine("Jaký produkt chceš přidat?");
        string produkt = Console.ReadLine() ?? "";

        sklad.Add(produkt);

        Console.WriteLine("Produkt byl přidán! Zadej další číslo");
      }

      if (volba == "2")
      {
        foreach (string produkt in sklad)
        {
          Console.WriteLine(produkt);
        }
        Console.WriteLine("Napiš další číslo 1-6");

      }
      if (volba == "3")
      {
        Console.WriteLine("Jaký produkt chceš hledat?");
        string hledanyProdukt = Console.ReadLine() ?? "";

        if (sklad.Contains(hledanyProdukt))
        {
          Console.WriteLine("Produkt byl nalezen! Napiš další číslo 1-6");
        }
        else
        {
          Console.WriteLine("Produkt nebyl nalezen. Napiš další číslo 1-6");
        }
      }
      {

      }
      if (volba == "4")
      {

        Console.WriteLine("Jaký produkt chceš odstranit?");
        string produkt = Console.ReadLine() ?? "";

        if (sklad.Remove(produkt))
        {
          Console.WriteLine("Produkt byl odstraněn! Napiš další číslo 1-6");
        }
        else
        {
          Console.WriteLine("Produkt nebyl nalezen.");
        }
      }




      if (volba == "5")
      {
        Console.WriteLine($"Počet produktů ve skladu: {sklad.Count}. Napiš další číslo 1-6");
      }

      if (volba == "6")
        return;
    } while (true);
  }




  static void ZobrazitMenu()
  {
    Console.WriteLine("");
    Console.WriteLine("   -- APPLE SKLAD --");
    Console.WriteLine("");
    Console.WriteLine("Vždy si vyber číslo - podle toho, co chceš udělat");
    Console.WriteLine("1 - Přidat produkt");
    Console.WriteLine("2 - Zobrazit produkty");
    Console.WriteLine("3 - Vyhledat produkt");
    Console.WriteLine("4 - Odstranit produkt");
    Console.WriteLine("5 - Zobrazit počet produktů");
    Console.WriteLine("6 - Konec");

  }
}