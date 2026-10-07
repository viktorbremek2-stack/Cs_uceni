// Stopwatch (stopky) je v System.Diagnostics
using System.Diagnostics;

class Program
{
  // ===== DATA =====
  // Seznam vět. static = vidí ho všechny static metody ve třídě.
  static List<string> seznam = new List<string>
  {
    "Včera jsem na procházce potkal psa, který nosil v tlamě botu.",
    "Káva vystydla dřív, než jsem stihl otevřít poštu.",
    "Na střeše starého domu hnízdili čápi už několik let.",
    "Zítra pojedeme vlakem k babičce na venkov.",
    "Ten film měl nečekaně dobrý konec.",
    "V lednici zbyl jen kousek sýra a půlka okurky.",
    "Děti stavěly na pláži obrovský hrad z písku.",
    "Kdybych měl víc času, naučil bych se hrát na klavír.",
    "Z okna je vidět celé údolí zahalené v mlze.",
    "Opravář přišel o hodinu dřív, než slíbil.",
    "Moje oblíbená knihovna voní po starém papíře a dřevě.",
    "Večer se ochladilo, takže jsme zapálili oheň.",
    "Nikdo nevěděl, kam se ztratil klíč od sklepa.",
    "Na trhu měli první letošní jahody.",
    "Kocour celé odpoledne spal na parapetu ve slunci.",
    "Učitel nám zadal úkol, který nešlo vyřešit za jeden večer.",
    "Autobus dnes ráno jel s patnáctiminutovým zpožděním.",
    "V dálce zahřmělo a vzduch se zvláštně zatřpytil.",
    "Nejlepší polévku jsem jedl v malé hospodě u řeky.",
    "Říká se, že ráno je moudřejší večera.",
    "Hodinky na zdi se zastavily přesně o půlnoci.",
    "Na zahradě rozkvetly první narcisy.",
    "Sousedka každé ráno krmí holuby na náměstí.",
    "Dlouho jsme hledali místo, kde by se dalo zaparkovat.",
    "Vítr odnesl klobouk až na druhý břeh řeky.",
    "Do batohu jsem zapomněl sbalit svačinu.",
    "Starý most vrzal pod každým krokem.",
    "Moje sestra umí upéct nejlepší jablečný koláč široko daleko.",
    "Na obloze se objevila duha po dlouhém dešti.",
    "Pošťák zazvonil, ale nikdo nebyl doma.",
    "V parku si děti hrály na schovávanou.",
    "Koupil jsem si nové boty, které mě hned první den tlačily.",
    "Celý večer jsme si povídali o dávných cestách.",
    "Na stole ležel dopis bez adresy odesílatele.",
    "Tramvaj zastavila uprostřed křižovatky kvůli poruše.",
    "Dědeček rád vyprávěl příběhy o svém dětství na horách.",
    "Hudba z vedlejšího bytu nás nenechala usnout.",
    "V létě jezdíme každý rok ke stejnému rybníku.",
    "Ta kniha mě pohltila natolik, že jsem zapomněl na čas.",
    "Z komína stoupal kouř a voněl po dřevě.",
    "Na horách napadlo přes noc půl metru sněhu.",
    "Zapomněl jsem heslo, takže jsem musel zavolat na podporu.",
    "Malíř celé dopoledne míchal barvy na paletě.",
    "U cesty stála osamělá lípa, stará snad tři sta let.",
    "Telefon zazvonil přesně ve chvíli, kdy jsem vcházel do sprchy.",
    "Měsíc svítil tak jasně, že nebylo potřeba baterky.",
    "Bratr si koupil kolo, ale ještě na něm nikam nejel.",
    "V kavárně na rohu mají nejlepší domácí limonádu.",
    "Před bouřkou se na dvorku rozeštěkali všichni psi.",
    "Cestou ze školy jsme se zastavili u pekařství pro rohlíky.",
    "Zima letos přišla dřív, než jsme čekali.",
    "Na půdě jsme našli starou krabici plnou fotografií.",
    "Vlak do Ostravy odjíždí z třetího nástupiště.",
    "Obloha byla celý den šedá a bez jediného slunečního paprsku.",
    "Kuchař do polévky přidal špetku čerstvého kopru.",
    "Za domem roste divoká malina, kterou nikdo nesází.",
    "Zítra bychom mohli vyrazit na výlet do hor.",
    "Moje kamarádka se právě vrátila z půlroční cesty po Asii.",
    "Na zdi visel obraz, který nikdo neuměl přesně popsat.",
    "Včera v noci se mi zdál zvláštní sen o létajících rybách.",
    "Mraky se honily nad kopci a stíny přebíhaly po polích.",
    "Chleba z místní pekárny voněl po celé ulici.",
    "Pes se vyhříval u kamen a ani se nehnul.",
    "V knihovně jsem narazil na knihu, kterou jsem hledal roky.",
    "Zahradník ořezal všechny růže ještě před zimou.",
    "Na nádraží panoval ruch jako každé pondělí ráno.",
    "Řeka po deštích zvedla hladinu o celý metr.",
    "Staré hodiny v předsíni tikaly tak hlasitě, že byly slyšet v celém domě.",
    "Dnes si dám k obědu něco lehkého, třeba salát.",
    "Světla města se odrážela v mokrém chodníku.",
  };

  // ===== METODA 1: úvod (void = nic nevrací) =====
  static void ShowIntro()
  {
    Console.WriteLine("Psací hra\n");                              // \n = prázdný řádek navíc
    Console.WriteLine("Napiš následující větu co nejrychleji\n");
  }

  // ===== METODA 2: náhodná věta (string = vrací text) =====
  static string GetRandomSentence()
  {
    Random random = new Random();               // generátor náhodných čísel
    int index = random.Next(seznam.Count);      // číslo od 0 do Count - 1
    return seznam[index];                       // vrať větu na pozici index
  }

  // ===== METODA 3: přesnost v procentech (double = vrací číslo) =====
  static double CalculateAccuracy(string original, string typed)
  {
    int spravne = 0;                                        // počítadlo shod
    int kratsi = Math.Min(original.Length, typed.Length);   // kratší délka, ať nečteme mimo text

    for (int i = 0; i < kratsi; i++)                        // projdi znak po znaku
    {
      if (original[i] == typed[i])                          // stejný znak na stejné pozici?
      {
        spravne++;                                          // ano: přičti 1
      }
    }

    // (double) před dělením, jinak by se desetinná část zahodila
    // Math.Max = dělíme delším textem, takže přebytečné znaky snižují přesnost
    return (double)spravne / Math.Max(original.Length, typed.Length) * 100;
  }

  // ===== METODA 4: obarvený výpis toho, co hráč napsal =====
  static void ShowMistakes(string original, string typed)
  {
    for (int i = 0; i < typed.Length; i++)
    {
      // i < original.Length chrání před čtením znaku, který v originálu není
      if (i < original.Length && original[i] == typed[i])
      {
        Console.ForegroundColor = ConsoleColor.Green;       // správně
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;         // špatně
      }

      Console.Write(typed[i]);                              // Write = bez nového řádku
    }

    Console.ResetColor();                                   // vrať původní barvu terminálu
    Console.WriteLine();                                    // ukonči řádek
  }

  // ===== HLAVNÍ PROGRAM =====
  static void Main()
  {
    string odpoved = "";                                    // vytvořena PŘED cyklem, ať ji vidí while

    do
    {
      Console.Clear();                                      // čistá obrazovka pro každé kolo
      ShowIntro();

      string veta = GetRandomSentence();                    // ulož, co metoda vrátí
      Console.WriteLine(veta);
      Console.Write("Napiš větu: ");

      Stopwatch stopwatch = Stopwatch.StartNew();           // start těsně před psaním
      string napsano = Console.ReadLine() ?? "";            // ?? "" = prázdný text místo null
      stopwatch.Stop();                                     // stop hned po Enteru

      double presnost = CalculateAccuracy(veta, napsano);

      Console.WriteLine($"\nČas: {stopwatch.Elapsed.TotalSeconds:F1} s");   // :F1 = 1 desetinné místo
      Console.WriteLine($"Přesnost: {presnost:F1} %");

      Console.WriteLine("\nTvůj text:");
      ShowMistakes(veta, napsano);

      Console.WriteLine("\nChceš další větu? ano/ne");
      odpoved = Console.ReadLine() ?? "";                   // jen přiřazení, bez "string"
    }
    while (odpoved.Trim().ToLower() == "ano");              // Trim/ToLower: pozná i "Ano" nebo "ano "
  }
}