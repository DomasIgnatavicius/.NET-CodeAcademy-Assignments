using System.Text.RegularExpressions;



namespace _05_DNR_inzinerija
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int meniuPasirinkimas;

            bool arNormalizuota = false;
            bool arValidi = false;
            bool pereitiPrieSubMeniu = false;

            Console.WriteLine("Iveskite DNR grandine");
            string txt = Console.ReadLine();
            
            

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
                meniuPasirinkimas = Convert.ToInt32(Console.ReadLine());
                SubMeniu(ref txt, meniuPasirinkimas, ref arNormalizuota, ref arValidi, ref pereitiPrieSubMeniu);
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
            switch (meniuPasirinkimas)
            {
                case 1:
                    txt = GCTtoAGG(txt);
                    Console.WriteLine(txt);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine(txt.Contains("CAT") == true ? "Tekste yra CAT" : "Tekste nera CAT" );
                    Console.WriteLine();
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

    }
}
