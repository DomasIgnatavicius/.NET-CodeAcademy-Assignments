namespace _07_Kartuves
{
    internal class Program
    {
        static string[] vardai = new string[] {"roberta", "tomas", "tukas", "mantas", "darius", "laurynas", "linas", "mantvydas", "gertruda", "mikalojus"};
        static string[] miestai = new string[] { "vilnius", "kaunas", "taurage", "klaipeda", "marijampole", "utena", "kupiskis", "alytus", "siauliai", "ariogala" };
        static string[] valstebes = new string[] { "lietuva", "latvija", "estija", "rusija", "sveicarija", "italija", "vokietija", "prancuzija", "baltarusija", "ukraina" };
        static string[] kita = new string[] { "suo", "ranka", "geoidas", "politeizmas", "aguona", "plastiskas", "lazas", "brakonierius", "bipolinis", "agurkas" };
        static int gyvybes = 7;
        static List<string> spetosRaides = new List<string>();
        static List<string> tusciasZodis = new List<string>();
        static List<string> atsakymas = new List<string>();
        static bool gameOn = true;
        static bool vykstaSpejimai = true;
        static string spejimas;
        public static string tema;
        static void Main(string[] args)
        {
            
            while (gameOn)
            {
                HangMan();
            }
            
        }

        public static void HangMan()
        {
            temosPasirinkimas();
            zodzioParinkimas();
            for (int i = 0; i < atsakymas.Count; i++)
            {
                tusciasZodis.Add("_");
            }
            
            while (vykstaSpejimai)
            {
                Console.Clear();
                Console.WriteLine($"Tema: {tema}");
                Piesimas();
                Console.WriteLine();
                Console.Write("Spetos raides: ");
                spetosRaides.ForEach(raide => Console.Write(raide + " "));
                Console.WriteLine();
                Console.Write("Zodis: ");
                tusciasZodis.ForEach(raide => Console.Write(raide + " "));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Iveskite raide arba zodi: ");
                if (gyvybes == 0 || !tusciasZodis.Contains("_"))
                {
                    break;
                }
                string unsafeSpejimas;
                bool onn = true;
                while (onn)
                {
                    unsafeSpejimas = Console.ReadLine();
                    if (!string.IsNullOrEmpty(unsafeSpejimas) && !int.TryParse(unsafeSpejimas, out _))
                    {
                        spejimas = unsafeSpejimas;
                        onn = false;
                    }
                    else
                        Console.WriteLine("Spejimsa turi buti zodis arba raide");
                }
                Console.WriteLine(atsakymas.Contains(spejimas));
                Console.WriteLine(atsakymas.Count);
                Console.WriteLine(tusciasZodis[1]);
                HangOrNotToHang(spejimas);

            }
            Console.WriteLine("Ar norite pradeti is naujo? T/N");
            string pasirinkimas;
            bool on = true;
            while (on)
            {
                pasirinkimas = Console.ReadLine();
                if (!string.IsNullOrEmpty(pasirinkimas) || pasirinkimas.ToUpper() != "Y" || pasirinkimas.ToUpper() != "Y")
                {
                    if (pasirinkimas.ToUpper() == "N")
                    {
                        gameOn = false;
                        on = false;
                    }
                    else
                    {
                        on = false;
                        Reset();
                        Console.Clear();
                    }

                }
                else
                    Console.WriteLine("Jus turite pasirinkti");
            }
        }

        public static void Piesimas()
        {
            if (gyvybes == 7)
            {
                Console.WriteLine("-------------------|");
                Console.WriteLine("|                  ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("------------");
            }
            else if (gyvybes == 6)
            {
                Console.WriteLine("-------------------|");
                Console.WriteLine("|                  O");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("------------");
            }
            else if (gyvybes == 5)
            {
                Console.WriteLine("-------------------|");
                Console.WriteLine("|                  O");
                Console.WriteLine("|                  |");
                Console.WriteLine("|                  ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("------------");
            }
            else if (gyvybes == 4)
            {
                Console.WriteLine("-------------------|");
                Console.WriteLine("|                  O");
                Console.WriteLine("|                 \\|");
                Console.WriteLine("|                  ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("------------");
            }
            else if (gyvybes == 3)
            {
                Console.WriteLine("-------------------|");
                Console.WriteLine("|                  O");
                Console.WriteLine("|                 \\|/");
                Console.WriteLine("|                  ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("------------");
            }
            else if (gyvybes == 2)
            {
                Console.WriteLine("-------------------|");
                Console.WriteLine("|                  O");
                Console.WriteLine("|                 \\|/");
                Console.WriteLine("|                  0");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("------------");
            }
            else if (gyvybes == 1)
            {
                Console.WriteLine("-------------------|");
                Console.WriteLine("|                  O");
                Console.WriteLine("|                 \\|/");
                Console.WriteLine("|                  0");
                Console.WriteLine("|                 / ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("------------");
            }
            else if(gyvybes == 0)
            {
                Console.WriteLine("-------------------|");
                Console.WriteLine("|                  O");
                Console.WriteLine("|                 \\|/");
                Console.WriteLine("|                  0");
                Console.WriteLine("|                 / \\");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("|                 ");
                Console.WriteLine("------------");
            }
            
        }

        public static void temosPasirinkimas()
        {
            Console.WriteLine("Pasirinkite tema:");
            Console.WriteLine("1. VARDAI");
            Console.WriteLine("2. LIETUVOS MIESTAI");
            Console.WriteLine("3. VALSTYBES");
            Console.WriteLine("4. KITA");
            bool on = true;
            string ivedimas;
            while (on)
            {
                ivedimas = Convert.ToString(Console.ReadLine());
                if (ivedimas == "1" || ivedimas == "2" || ivedimas == "3" || ivedimas == "4")
                {
                    if(ivedimas == "1" && vardai.Length == 0)
                    {
                        Console.WriteLine("Pasirinktoje kategorijoje nebeliko zodziu");
                    }
                    else if (ivedimas == "2" && miestai.Length == 0)
                    {
                        Console.WriteLine("Pasirinktoje kategorijoje nebeliko zodziu");
                    }
                    else if (ivedimas == "3" && valstebes.Length == 0)
                    {
                        Console.WriteLine("Pasirinktoje kategorijoje nebeliko zodziu");
                    }
                    else if (ivedimas == "4" && kita.Length == 0)
                    {
                        Console.WriteLine("Pasirinktoje kategorijoje nebeliko zodziu");
                    }
                    else
                    {
                        switch (ivedimas)
                        {
                            case "1": tema = "VARDAI"; break;
                            case "2": tema = "LIETUVOS MIESTAI"; break;
                            case "3": tema = "VALSTYBES"; break;
                            case "4": tema = "KITA"; break;
                            default:
                                break;
                        }
                        on = false;
                    }

                    
                }
                else
                    Console.WriteLine("Pasirinkimas turi buti 1 2 3 arba 4");
            }
            
        }

        public static void zodzioParinkimas()
        {
            Random rnd = new Random();
            if (tema == "VARDAI")
            {
                int randomNumber = rnd.Next(vardai.Length);
                atsakymas.AddRange(vardai[randomNumber].Select(c => c.ToString()));
                for (int i = randomNumber; i < vardai.Length-1; i++)
                {
                    vardai[i] = vardai[i + 1];
                }
                Array.Resize(ref vardai, vardai.Length - 1);
            }
            if (tema == "LIETUVOS MIESTAI")
            {
                int randomNumber = rnd.Next(miestai.Length+1);
                atsakymas.AddRange(miestai[randomNumber].Select(c => c.ToString()));
                for (int i = randomNumber; i < miestai.Length-1; i++)
                {
                    miestai[i] = miestai[i + 1];
                }
                Array.Resize(ref miestai, miestai.Length - 1);
            }
            if (tema == "VALSTYBES")
            {
                int randomNumber = rnd.Next(valstebes.Length);
                atsakymas.AddRange(valstebes[randomNumber].Select(c => c.ToString()));
                for (int i = randomNumber; i < valstebes.Length-1; i++)
                {
                    valstebes[i] = valstebes[i + 1];
                }
                Array.Resize(ref valstebes, valstebes.Length - 1);
            }
            if (tema == "KITA")
            {
                int randomNumber = rnd.Next(kita.Length);
                atsakymas.AddRange(kita[randomNumber].Select(c => c.ToString()));
                for (int i = randomNumber; i < kita.Length-1; i++)
                {
                    kita[i] = kita[i + 1];
                }
                Array.Resize(ref kita, kita.Length - 1);
            }
        }

        public static void Reset()
        {
            gyvybes = 7;
            spetosRaides = new List<string>();
            tusciasZodis = new List<string>();
            atsakymas = new List<string>();
            gameOn = true;
            vykstaSpejimai = true;
        }
        public static void HangOrNotToHang(string spejimas)
        {
            if(spejimas.Length == 1)
            {
                if (atsakymas.Contains(spejimas))
                {
                    
                    for (int i = 0; i < atsakymas.Count; i++)
                    {
                        Console.WriteLine(spejimas == atsakymas[i]);
                        Console.WriteLine(atsakymas[i]);
                        if(spejimas == atsakymas[i])
                        {
                            tusciasZodis[i] = spejimas;
                            Console.WriteLine(tusciasZodis[i]);
                            
                        }
                    }
                }
                else
                {
                    if (!spetosRaides.Contains(spejimas))
                    {
                        spetosRaides.Add(spejimas);
                        gyvybes--;
                        if (gyvybes == 0)
                        {
                            tusciasZodis = atsakymas;
                        }
                    }
                    
                }
            }
            else
            {
                if (spejimas == String.Join("", atsakymas))
                {
                    for (int i = 0; i < atsakymas.Count; i++)
                    {
                        tusciasZodis = atsakymas;
                    }
                }
                else
                {
                    gyvybes = 0;
                    tusciasZodis = atsakymas;
                }
                    
            }
        }
    }
}