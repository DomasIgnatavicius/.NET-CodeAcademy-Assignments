using System.Text.RegularExpressions;



namespace _05_DNR_inzinerija
{
    public class Program
    {
        static void Main(string[] args)
        {
            int meniuPasirinkimas;

            bool arNormalizuota = false;
            bool arValidi = false;
            bool pereitiPrieSubMeniu = false;

            Console.WriteLine("Iveskite DNR grandine");
            string txt = Console.ReadLine();


            while (1 > 0)
            {
                while (!pereitiPrieSubMeniu)
                {
                    Console.WriteLine("1) Atlikti grandines normalizavima");
                    Console.WriteLine("2) Atlikti grandines validacija");
                    Console.WriteLine("3) Atlikti veiksmus su DNR grandine");
                    meniuPasirinkimas = Convert.ToInt32(Console.ReadLine());
                    Meniu(ref txt, meniuPasirinkimas, ref arNormalizuota, ref arValidi, ref pereitiPrieSubMeniu);
                }

                while (pereitiPrieSubMeniu)
                {
                    Console.WriteLine("1) GCT pakeis i AGG");
                    Console.WriteLine("2) Isvesti ar yra tekste CAT");
                    Console.WriteLine("3) Isvesti trecia ir penkta grandines segmentus");
                    Console.WriteLine("4) Isvesti raidziu kieki tekste");
                    Console.WriteLine("5) Kiek kartu pasikartoja ivestas segmentas");
                    Console.WriteLine("6) Prie grandines galo prideti ivesta segmenta");
                    Console.WriteLine("7) Is grandines pasalinti pasirinkta elementaS");
                    Console.WriteLine("8) Pakeisti pasirinkta elementa, pasirinktu is klaviaturos");
                    Console.WriteLine("9) BACK");
                    meniuPasirinkimas = Convert.ToInt32(Console.ReadLine());
                    SubMeniu(ref txt, meniuPasirinkimas, ref arNormalizuota, ref arValidi, ref pereitiPrieSubMeniu);
                }
            }

        }


        public static void Meniu(ref string txt, int meniuPasirinkimas, ref bool arNormalizuota, ref bool arValidi, ref bool pereitiPrieSubMeniu)
        {
            switch (meniuPasirinkimas)
            {
                case 1: 
                    txt = grandinesNormalizavimas(txt, ref arNormalizuota);
                    Console.WriteLine(txt);
                    Console.WriteLine();
                    break;
                case 2:
                    arValidi = arGrandineValidi(txt);
                    if (!arValidi)
                    {
                        Console.WriteLine("DNR grandine nera validi!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Grandine validi!");
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    if (arValidi && arNormalizuota)
                    {
                        pereitiPrieSubMeniu = true;
                    }
                    else if(arValidi && !arNormalizuota)
                    {
                        Console.WriteLine("Grandine yra validi, ja reikia normalizuoti!");
                        Console.WriteLine("1) Normalizuoti grandine");
                        Console.WriteLine("2) Iseiti is programos");
                        meniuPasirinkimas = Convert.ToInt32(Console.ReadLine());
                        switch (meniuPasirinkimas)
                        {
                            case 1:
                                txt = grandinesNormalizavimas(txt, ref arNormalizuota);
                                pereitiPrieSubMeniu = true;
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Grandine nera validi, su ja atlikti veiksmu negalima!");
                        Console.WriteLine();
                    }
                    break;
                default:
                    break;
            }
        }
        public static void SubMeniu(ref string txt, int meniuPasirinkimas, ref bool arNormalizuota, ref bool arValidi, ref bool pereitiPrieSubMeniu)
        {
            string segmentas;
            int segmentoNr;
            switch (meniuPasirinkimas)
            {
                case 1:
                    txt = GCTtoAGG(txt);
                    Console.WriteLine(txt);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine(arGrandinejeYraCAT(txt));
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine($"Trecias ir pentsa segmentai yra: {Gauti3ir5Segmentus(txt)}");
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Raidziu kiekis tekste yra: {0}", raidziuKiekisTexte(txt));
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Iveskite segmenta: ");
                    segmentas = Console.ReadLine();
                    if (txt.Contains(segmentas.ToUpper()))
                    {
                        Console.WriteLine("Sis segmentas pasikartoja {0} kartus(u)", kiekKartuPasikartojaIvestasSegmentas(txt,segmentas));
                    }else
                        Console.WriteLine("Tokio segmento grandineje nera");
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("Iveskite segmenta: ");
                    segmentas = Console.ReadLine();
                    if (arIvestasSegmentasValidus(segmentas))
                    {
                        txt = segmentasPridedamasPrieDNRGalo(txt, segmentas);
                        Console.WriteLine(txt);
                    }
                    else
                        Console.WriteLine("Ivestas segmentas nera validus");
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine(txt);
                    Console.WriteLine($"Grandine susidaro is {txt.Split("-").Count()} segmentu");
                    Console.WriteLine("Kuri segmenta noretumete pasalinti?");
                    segmentoNr = Convert.ToInt32(Console.ReadLine());
                    txt = pasalinamasSegmentas(txt, segmentoNr);
                    Console.WriteLine(txt);
                    Console.WriteLine();
                    break;
                case 8:
                    Console.WriteLine(txt);
                    Console.WriteLine($"Grandine susidaro is {txt.Split("-").Count()} segmentu");
                    Console.WriteLine("Kuri segmenta noretumete pakeisti?");
                    segmentoNr = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Iveskite kokiu segmentu noretumete pakeisti:");
                    segmentas = Console.ReadLine();
                    if (arIvestasSegmentasValidus(segmentas))
                    {
                        txt = keiciamasSegmentas(txt, segmentoNr, segmentas);
                        Console.WriteLine(txt);
                    }
                    else
                        Console.WriteLine("Ivestas segmentas nera validus");
                    Console.WriteLine();
                    break;
                case 9:
                    pereitiPrieSubMeniu = Back();
                    break;
                default:
                    break;
            }
        }

        public static string grandinesNormalizavimas(string txt, ref bool arNormalizuota)
        {
            arNormalizuota = true;
            return txt.Trim().Replace(" ", "").ToUpper();
        }
        public static bool arGrandineValidi(string txt)
        {
            string normalizuotasTxt = txt.Trim().Replace(" ", "").ToUpper();
            foreach(char raide in normalizuotasTxt)
            {
                if(raide != 'A' && raide != 'T' && raide != 'C' && raide != 'G' && raide != '-')
                {
                    return false;
                    Environment.Exit(0);
                }
            }
            return true;
        }

        public static string GCTtoAGG(string txt) => txt.Replace("GCT", "AGG");
        public static string arGrandinejeYraCAT(string txt) => txt.Contains("CAT") == true ? "Tekste yra CAT" : "Tekste nera CAT";
        public static string Gauti3ir5Segmentus(string txt)
        {
            if (txt.Split("-").Length < 5) 
            {
                return "Grandine yra trumpesne nei 5 segmentai.";
            }
            else
                return txt.Substring(8, 3) + "-" + txt.Substring(16, 3);
        }
        public static int raidziuKiekisTexte(string txt) => txt.Replace("-", "").Length;
        public static int kiekKartuPasikartojaIvestasSegmentas(string txt, string segmentas) => Regex.Matches(txt, segmentas.ToUpper()).Count();
        public static bool arIvestasSegmentasValidus(string segmentas)
        {
            foreach (char raide in segmentas.ToUpper())
            {
                if (raide != 'A' && raide != 'T' && raide != 'C' && raide != 'G')
                {
                    return false;
                    Environment.Exit(0);
                }
            }
            if (segmentas.Length == 3)
            {
                return true;
            }
            else
                return false;
        }
        public static string segmentasPridedamasPrieDNRGalo(string txt, string segmentas) => txt + "-" + segmentas.ToUpper();
        public static string pasalinamasSegmentas(string txt, int segmentoNr)
        {
            segmentoNr--;
            List<string> DNRlist= new List<string>(txt.Split('-'));
            txt = "";
            DNRlist.RemoveAt(segmentoNr);
            txt = string.Join("-", DNRlist);
            return txt;
        }
        public static string keiciamasSegmentas(string txt, int segmentoNr, string segmentas)
        {
            segmentoNr--;
            List<string> DNRlist = new List<string>(txt.Split('-'));
            txt = "";
            DNRlist[segmentoNr] = segmentas.ToUpper();
            txt = string.Join("-", DNRlist);
            return txt;
        }
        public static bool Back() => false;

    }
}
