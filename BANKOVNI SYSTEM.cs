using System.Globalization;
using System.Text.Json;

// Do tohoto souboru se ukládají všechna data (účty, zůstatky, historie)
string fileName = "accounts.json";

// Seznam všech účtů v bance
List<Account> accounts = new List<Account>();

// Pokud už soubor existuje, načteme z něj účty.
// Pokud ne (první spuštění), přidáme dva účty na zkoušku.
if (File.Exists(fileName))
{
  string json = File.ReadAllText(fileName);
  accounts = JsonSerializer.Deserialize<List<Account>>(json) ?? new List<Account>();
}
else
{
  accounts.Add(new Account { Name = "Alice", Balance = 100 });
  accounts.Add(new Account { Name = "Bob", Balance = 700 });
}

Console.WriteLine("Vítej v C# bance!");

// Přihlášení - ptáme se tak dlouho, dokud uživatel něco nenapíše
string loginName = "";
while (loginName == "")
{
  Console.Write("Zadej své jméno pro přihlášení: ");
  loginName = (Console.ReadLine() ?? "").Trim();
}

// Hledáme účet se stejným jménem (velikost písmen nás nezajímá)
// Account? znamená, že tam může být i nic (null), když účet nenajdeme
Account? current = accounts.Find(a => a.Name.ToLower() == loginName.ToLower());

if (current == null)
{
  // Takový účet ještě není, tak ho vytvoříme s nulovým zůstatkem
  current = new Account { Name = loginName, Balance = 0 };
  accounts.Add(current);
  Console.WriteLine("Byl vytvořen nový účet pro " + loginName);
}

// Hlavní menu
bool running = true;

while (running)
{
  Console.WriteLine();
  Console.WriteLine("Přihlášen: " + current.Name);
  Console.WriteLine("1 - Zobrazit zůstatek");
  Console.WriteLine("2 - Vložit peníze");
  Console.WriteLine("3 - Vybrat peníze");
  Console.WriteLine("4 - Poslat peníze jinému účtu");
  Console.WriteLine("5 - Historie transakcí");
  Console.WriteLine("6 - Konec");
  Console.Write("Vyber možnost: ");

  string choice = Console.ReadLine() ?? "";

  switch (choice)
  {
    case "1":
      // F2 znamená, že se číslo vypíše na 2 desetinná místa
      Console.WriteLine($"Zůstatek: {current.Balance:F2}");
      break;

    case "2":
      Console.Write("Kolik chceš vložit: ");
      try
      {
        // Čárku změníme na tečku, aby šlo napsat 10,5 i 10.5
        string text = (Console.ReadLine() ?? "").Replace(',', '.');
        decimal deposit = decimal.Parse(text, CultureInfo.InvariantCulture);

        if (deposit > 0)
        {
          current.Balance += deposit;
          current.History.Add($"Vloženo {deposit:F2}");
          Console.WriteLine($"Vloženo. Nový zůstatek: {current.Balance:F2}");
        }
        else
        {
          Console.WriteLine("Částka musí být větší než 0.");
        }
      }
      catch
      {
        Console.WriteLine("Zadej prosím platné číslo.");
      }
      break;

    case "3":
      Console.Write("Kolik chceš vybrat: ");
      try
      {
        string text = (Console.ReadLine() ?? "").Replace(',', '.');
        decimal withdraw = decimal.Parse(text, CultureInfo.InvariantCulture);

        if (withdraw <= 0)
        {
          Console.WriteLine("Částka musí být větší než 0.");
        }
        else if (withdraw > current.Balance)
        {
          Console.WriteLine("Nemáš dost peněz na účtu.");
        }
        else
        {
          current.Balance -= withdraw;
          current.History.Add($"Vybráno {withdraw:F2}");
          Console.WriteLine($"Vybráno. Nový zůstatek: {current.Balance:F2}");
        }
      }
      catch
      {
        Console.WriteLine("Zadej prosím platné číslo.");
      }
      break;

    case "4":
      Console.Write("Komu chceš poslat peníze (jméno): ");
      string targetName = (Console.ReadLine() ?? "").Trim();
      Account? target = accounts.Find(a => a.Name.ToLower() == targetName.ToLower());

      if (target == null)
      {
        Console.WriteLine("Takový příjemce neexistuje.");
      }
      else if (target == current)
      {
        Console.WriteLine("Nemůžeš poslat peníze sám sobě.");
      }
      else
      {
        Console.Write("Kolik chceš poslat: ");
        try
        {
          string text = (Console.ReadLine() ?? "").Replace(',', '.');
          decimal transfer = decimal.Parse(text, CultureInfo.InvariantCulture);

          if (transfer > 0 && transfer <= current.Balance)
          {
            // Odesílateli peníze ubydou, příjemci přibydou
            current.Balance -= transfer;
            target.Balance += transfer;

            // Zapíšeme to do historie obou účtů
            current.History.Add($"Odesláno {transfer:F2} uživateli {target.Name}");
            target.History.Add($"Přijato {transfer:F2} od uživatele {current.Name}");

            Console.WriteLine($"Odesláno. Nový zůstatek: {current.Balance:F2}");
          }
          else
          {
            Console.WriteLine("Neplatná částka (musí být větší než 0 a nesmí být víc, než máš na účtu).");
          }
        }
        catch
        {
          Console.WriteLine("Zadej prosím platné číslo.");
        }
      }
      break;

    case "5":
      Console.WriteLine($"--- Historie účtu {current.Name} ---");
      if (current.History.Count == 0)
      {
        Console.WriteLine("Zatím žádné transakce.");
      }
      foreach (string line in current.History)
      {
        Console.WriteLine(line);
      }
      break;

    case "6":
      Console.WriteLine("Ukončuji program...");
      running = false;
      break;

    default:
      Console.WriteLine("Neplatná volba!");
      break;
  }

  // Po každé akci uložíme všechny účty do JSON souboru,
  // takže o nic nepřijdeme, ani když program vypneme křížkem nebo stop tlačítkem.
  // WriteIndented = true jen udělá, že je soubor pěkně čitelný.
  string jsonToSave = JsonSerializer.Serialize(accounts, new JsonSerializerOptions { WriteIndented = true });
  File.WriteAllText(fileName, jsonToSave);
}

// Třída Account je takový návod, jak vypadá jeden účet.
// Každý účet má jméno, zůstatek a seznam textů s historií.
// decimal je číslo s desetinnou čárkou, které se hodí na peníze, protože počítá přesně.
// { get; set; } je potřeba, aby to šlo uložit do JSON.
class Account
{
  public string Name { get; set; } = "";
  public decimal Balance { get; set; }
  public List<string> History { get; set; } = new List<string>();
}