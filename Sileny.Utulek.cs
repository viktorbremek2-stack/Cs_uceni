using System;
using System.Collections.Generic;


interface IKrmitelny
{
  void Nakrmit();
}

interface IVencitelny
{
  void Vencit();
}

abstract class Zvire
{
  public string Name;
  public double Vek;
  public static int PocetZvirat = 0;

  public Zvire(string name, double vek)
  {
    Name = name;
    Vek = vek;
    PocetZvirat++;
  }

  public abstract void VydejZvuk();
}

class Pes : Zvire, IKrmitelny, IVencitelny
{
  public Pes(string name, double vek) : base(name, vek)
  {
  }

  public override void VydejZvuk()
  {
    Console.WriteLine($"{Name}: Haf haf!");
  }

  public void Nakrmit()
  {
    Console.WriteLine($"{Name} si pochutnává na žrádle");
  }

  public void Vencit()
  {
    Console.WriteLine($"{Name} se vrátil z procházky celej unavenej");
  }
}

class BlazniviPes : Zvire, IKrmitelny, IVencitelny
{
  public BlazniviPes(string name, double vek) : base(name, vek)
  {
  }

  public override void VydejZvuk()
  {
    Console.WriteLine($"{Name} křičí: grrr huuuuu grrr huuu!");
  }

  public void Nakrmit()
  {
    Console.WriteLine($"{Name} sežral všechno za 5 vteřin");
  }

  public void Vencit()
  {
    Console.WriteLine($"{Name} pořád běhá jak blázen i po venčení");
  }
}

class SuperRychlyPapousek : Zvire, IKrmitelny
{
  public SuperRychlyPapousek(string name, double vek) : base(name, vek)
  {
  }

  public override void VydejZvuk()
  {
    Console.WriteLine($"{Name} křičí letim rychle letim rychle, šššššššš!");
  }

  public void Nakrmit()
  {
    Console.WriteLine("Pro papouška nezbylo jídlo :(");
  }
}

class Program
{
  static void Main()
  {
    Pes Kuba = new Pes("Kuba", 3);
    BlazniviPes Filip = new BlazniviPes("Filip", 2);
    SuperRychlyPapousek Pepa = new SuperRychlyPapousek("Pepa", 1);

    List<Zvire> vsechnaZvirata = new List<Zvire>();
    vsechnaZvirata.Add(Kuba);
    vsechnaZvirata.Add(Filip);
    vsechnaZvirata.Add(Pepa);


    Console.WriteLine($"V útulku máme {Zvire.PocetZvirat} zvířat/a");


    foreach (Zvire zvire in vsechnaZvirata)
    {
      Console.WriteLine($"{zvire.Name} má {zvire.Vek} roků");
    }
  }
}