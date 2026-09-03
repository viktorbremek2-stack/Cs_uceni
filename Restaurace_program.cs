using System;

class Program
{
  static void Main()
  {
    Console.WriteLine("Napiš cenu jídla:");
    double cenaJidla = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Napiš cenu nápoje:");
    double cenaNapoje = Convert.ToDouble(Console.ReadLine());
    double celkovaCena = cenaJidla + cenaNapoje;
    Console.WriteLine("Celková cena je: " + celkovaCena);
    Console.WriteLine("Chcete rozdělit cenu mezi více lidí? (ano/ne)");
    string odpoved = Console.ReadLine();
    if (odpoved.ToLower() == "ano")
    {
      Console.WriteLine("Kolik lidí se bude podílet na platbě?");
      int pocetLidi = Convert.ToInt32(Console.ReadLine());
      double cenaNaOsobu = celkovaCena / pocetLidi;
      Console.WriteLine("Cena na osobu je: " + cenaNaOsobu);
    }

  }
}