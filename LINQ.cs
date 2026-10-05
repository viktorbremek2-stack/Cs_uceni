using System.Linq;
using System.Collections.Generic;
class Produkt
{
  string[] Devata_B = { "Filip", "Viktor", "Kuba", "Pepa", "Filip2", "Martin", "Anička", "Zuzka", "Terka", "Elen", "Šarlot", "Adél", "Noemi", "Agáta" };
}
class Program
{
  static void Main()
  {
    List<string> Trida = new List<string> { "Filip", "Viktor", "Kuba", "Pepa", "Filip2", "Martin", "Anička", "Zuzka", "Terka", "Elen", "Šarlot", "Adél", "Noemi", "Agáta" };


    var whereResult = Trida.Where(jmeno => jmeno.StartsWith("F"));
    foreach (var jmeno in whereResult)
    {
      Console.WriteLine(jmeno);
    }


    // x => x znamená "řaď podle samotného prvku", u stringů tedy abecedně
    var orderByResult = Trida.OrderBy(x => x).ToList();

    // Seznam projdeme prvek po prvku a každý jméno vypíšeme zvlášť
    foreach (string name in orderByResult)
    {
      Console.WriteLine(name);
    }


    // Seřadí podle id, sestupně (9-0)
    var orderByResultDecending = Trida.OrderByDescending(x => x).ToList();
    foreach (string name in orderByResult)
    {
      Console.WriteLine(name);
    }


    var anyResultTrue = Trida.Any(x => x == "Viktor");
    Console.WriteLine(anyResultTrue);



    var intLst = new List<int>() { 1, 2, 3, 4, 5 };

    var containsResult = intLst.Contains(8);  // false
    var containsResult2 = intLst.Contains(1); // true
    Console.WriteLine($"{containsResult}, {containsResult2}");

    var count = Trida.Count();    // počet prvků v seznamu
    Console.WriteLine(count);

    var lastResult = Trida.Where(x => x.StartsWith("E")).LastOrDefault();
    Console.WriteLine(lastResult);

    var firstResult = Trida.Where(x => x.EndsWith("l")).FirstOrDefault();
    Console.WriteLine(firstResult);

  }


}
