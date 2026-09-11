using System;

class Program
{
  static void Main()
  {

    List<string> ukoly = new List<string>();
    string volba = "";


    do
    {
      Console.WriteLine("\n -- Úkolníček --\n Napiš číslo podle toho co chceš udělat\n 1 - Přidat úkol\n 2 - Zobrazit úkoly\n 3 - Odstranit úkol\n 4 - Počet úkolů\n 5 - Konec");
      volba = Console.ReadLine() ?? "";

      if (volba == "1")
      {
        Console.WriteLine("Jaký úkol chceš přidat?");
        string ukol = Console.ReadLine() ?? "";
        ukoly.Add(ukol);

      }
      if (volba == "2")
      {
        foreach (string ukol in ukoly)
        {
          Console.WriteLine(ukol);
        }
      }
      if (volba == "3")
      {

        Console.WriteLine("Jaký úkol chceš smazat?");

        string ukol = Console.ReadLine() ?? "";
      }
      if (volba == "4")
      {
        Console.WriteLine(ukoly.Count);
      }

      if (volba == "5")
      {
        return;
      }
    } while (volba != "5");
  }

}