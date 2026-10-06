using System;
using System.Collections.Generic;
using System.Linq;

class Produkt
{
  public Produkt(string nazev, double cena, string kategorie)
  {
    Nazev = nazev;
    Cena = cena;
    Kategorie = kategorie;
  }

  public string Nazev;
  public double Cena;
  public string Kategorie;
}

class Program
{
  static List<Produkt> produkty = new()
    {
        new Produkt("Rohlik", 3, "Potraviny"),
        new Produkt("Kofola", 35, "Napoje"),
        new Produkt("Houska", 4, "Potraviny"),
        new Produkt("Voda", 15, "Napoje"),
        new Produkt("Tricko", 250, "Obleceni"),
        new Produkt("Mikina", 600, "Obleceni")
    };

  static void Main()

  {
    // tohle vypíše vsechny "nazvy"
    var selectLst = produkty.Select(x => x.Nazev);
    {
      foreach (var nazev in selectLst)
      {
        Console.WriteLine(nazev);
      }


    }

    var vybratList = produkty
        .Where(x => x.Kategorie == "Napoje")
        .Select(x => x.Nazev);

    foreach (var nazev in vybratList)
    {
      Console.WriteLine(nazev);
    }


    var avg = produkty.Average(x => x.Cena);
    var min = produkty.Min(x => x.Cena);
    var max = produkty.Max(x => x.Cena);
    Console.WriteLine($"Max: {max}, Avg: {avg}, Min: {min}");


    var trinejlevnejsi = produkty
        .OrderBy(x => x.Cena)
        .Take(3)
        .ToList();

    foreach (var x in trinejlevnejsi)
    {
      Console.WriteLine($"{x.Nazev} - {x.Cena}");
    }
  }
}
