using _08_Tower_Of_Hamoi_OOP.Domain.Models;
using _08_Tower_Of_Hamoi_OOP.Domain.Services;
using System.Text;

namespace _08_Tower_Of_Hanoi_OOP
{
    internal class Program
    {
        public static Game Zaidimas = new Game();  
        static void Main(string[] args)
        {
            piesinukoReset();
            while (true)
            {
                piesimas();
                bool pasirinktaNeteisingai = true;
                
                while (pasirinktaNeteisingai)
                {
                    Console.WriteLine("Pasirinkite stulpeli is kurio paimti: ");
                    Zaidimas.pasirinkasStulpelis = Console.ReadKey();
                    //Console.WriteLine(pasirinkasStulpelis);
                    if(Zaidimas.pasirinkasStulpelis.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else if(!int.TryParse(Zaidimas.pasirinkasStulpelis.KeyChar.ToString(), out _))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ivesta ne skaitine reiksme, press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        piesimas();
                    }
                    else if(Zaidimas.pasirinkasStulpelis.KeyChar.ToString() == "1" || Zaidimas.pasirinkasStulpelis.KeyChar.ToString() == "2" || Zaidimas.pasirinkasStulpelis.KeyChar.ToString() == "3")
                    {
                        if (arStulpelisTuscias(int.Parse(Zaidimas.pasirinkasStulpelis.KeyChar.ToString())))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Stulpelis yra tuscias, pasirinkite stulpeli su diskais, press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            piesimas();
                        }
                        else
                            break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Pasirinktas neegzistuojantis stulpelis, press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        piesimas();
                    }
                        
                }
                diskoPerkelimas(int.Parse(Zaidimas.pasirinkasStulpelis.KeyChar.ToString()));
                Console.Clear();
            }
            
            
        }

        public static void piesimas()
        {
            Console.WriteLine($"Ejimas: {Zaidimas.ejimoNr}");
            Console.WriteLine($"Diskas rankoje: {Zaidimas.aktyvusDiskas.piesinukas}");
            Console.WriteLine();
            Console.WriteLine($"eil1. {Zaidimas.stulpelis1.eilutes[0]} {Zaidimas.stulpelis2.eilutes[0]} {Zaidimas.stulpelis3.eilutes[0]}");
            Console.WriteLine($"eil2. {Zaidimas.stulpelis1.eilutes[1]} {Zaidimas.stulpelis2.eilutes[1]} {Zaidimas.stulpelis3.eilutes[1]}");
            Console.WriteLine($"eil3. {Zaidimas.stulpelis1.eilutes[2]} {Zaidimas.stulpelis2.eilutes[2]} {Zaidimas.stulpelis3.eilutes[2]}");
            Console.WriteLine($"eil4. {Zaidimas.stulpelis1.eilutes[3]} {Zaidimas.stulpelis2.eilutes[3]} {Zaidimas.stulpelis3.eilutes[3]}");
            Console.WriteLine($"eil5. {Zaidimas.stulpelis1.eilutes[4]} {Zaidimas.stulpelis2.eilutes[4]} {Zaidimas.stulpelis3.eilutes[4]}");
            Console.WriteLine("          [1]         [2]         [3]");
        }

        public static void diskoPerkelimas(int pasirinktasStulpelis)
        {
            System.ConsoleKeyInfo pasirinkimas;
            diskoPaemimas(pasirinktasStulpelis);
            Console.Clear();
            piesimas();
            while (Zaidimas.gameState == "disko padejimas")
            {
                while (true)
                {
                    Console.WriteLine("Pasirinkite i koki stulpeli noretumete padeti: ");
                    pasirinkimas = Console.ReadKey();
                    if (Zaidimas.pasirinkasStulpelis.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else if (Zaidimas.pasirinkasStulpelis.KeyChar.ToString() == "1" || Zaidimas.pasirinkasStulpelis.KeyChar.ToString() == "2" || Zaidimas.pasirinkasStulpelis.KeyChar.ToString() == "3")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Pasirinktas neegzistuojantis stulpelis, press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        piesimas();
                    }
                }
                
                diskoPadejimas(int.Parse(pasirinkimas.KeyChar.ToString()));
                if (Zaidimas.gameState == "disko padejimas")
                {
                    Console.WriteLine();
                    Console.WriteLine("Negalima dedi didenio ant mazesnio, press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    piesimas();
                }
                
            }
            
            
        }

        public static void diskoPadejimas(int pasirinktasStulpelis)
        {
            for(int i = 4; i >= 0; i--)
            {
                if (Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i] == "     |     ")
                {
                    Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i] = Zaidimas.aktyvusDiskas.piesinukas;
                    Zaidimas.ejimoNr++;
                    moveLog(pasirinktasStulpelis);

                    Zaidimas.aktyvusDiskas = new Diskas();
                    Zaidimas.gameState = "disko paemimas";
                    break;
                }
                else if(Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i-1] == "     |     ")
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i] == Zaidimas.Diskai[j].piesinukas)
                        {
                            if(Zaidimas.aktyvusDiskas.keliuDaliu < Zaidimas.Diskai[j].keliuDaliu)
                            {
                                Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i - 1] = Zaidimas.aktyvusDiskas.piesinukas;
                                Zaidimas.ejimoNr++;
                                moveLog(pasirinktasStulpelis);
                                Zaidimas.aktyvusDiskas = new Diskas();
                                Zaidimas.gameState = "disko paemimas";
                                break;
                            }
                            else
                            {
                                break;
                            }
                            
                        }
                    }
                    break;
                }
            }
        }

        public static bool arStulpelisTuscias(int pasirinktasStulpelis)
        {
            for(int i = 0; i < 5; i++)
            {
                if (Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i] != "     |     ")
                {
                    return false;
                }
            }
            return true;
        }

        public static void piesinukoReset()
        {
            Zaidimas.stulpelis1.eilutes[1] = Zaidimas.diskas1.piesinukas;
            Zaidimas.stulpelis1.eilutes[2] = Zaidimas.diskas2.piesinukas;
            Zaidimas.stulpelis1.eilutes[3] = Zaidimas.diskas3.piesinukas;
            Zaidimas.stulpelis1.eilutes[4] = Zaidimas.diskas4.piesinukas;
        }

        public static void diskoPaemimas(int pasirinktasStulpelis)
        {
            
            for(int i = 0; i < 5; i++)
            {
                if (Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i] != "     |     ")
                {
                    for(int j = 0; j < 4; j++)
                    {
                        if(Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i] == Zaidimas.Diskai[j].piesinukas)
                        {
                            Zaidimas.aktyvusDiskas = Zaidimas.Diskai[j];
                            break;
                        }
                    }
                    Zaidimas.Tower[pasirinktasStulpelis - 1].eilutes[i] = "     |     ";
                    break;
                }
            }
            Zaidimas.gameState = "disko padejimas";
        }

        public static void moveLog(int pasirinktasStulpelis)
        {
            string stulpelisIsKurioPaeme = "";
            string stulpelisIKuriPadejo = "";
            var logBuilder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                if (i + 1 == Zaidimas.aktyvusDiskas.keliuDaliu)
                {
                    stulpelisIsKurioPaeme = Zaidimas.diskuVietos[i].ToString();
                    stulpelisIsKurioPaeme = stulpelioNrToString(pasirinktasStulpelis.ToString(), stulpelisIsKurioPaeme, ref stulpelisIKuriPadejo);
                    logBuilder.Append(pasirinktasStulpelis.ToString());
                }
                else
                    logBuilder.Append(Zaidimas.diskuVietos[i]);
            }
            Zaidimas.diskuVietos = logBuilder.ToString();

            //CSV
            string pathCsv = @"C:\Users\ignat\Documents\.NET CodeAcademy\Assignments\NET CodeAcademy Assignments\08 Tower Of Hamoi OOP.Domain\Logs\log.csv";
            TextWriter csv = new StreamWriter(pathCsv, true);
            var date = new DateTime();
            date = DateTime.Now;
            var newLineCSV = $"{date.ToString("yyyy-MM-dd hh:mm")},{Zaidimas.ejimoNr},{Zaidimas.diskuVietos[0]},{Zaidimas.diskuVietos[1]},{Zaidimas.diskuVietos[2]},{Zaidimas.diskuVietos[3]}";
            csv.WriteLine(newLineCSV);
            csv.Close();

            //TXT
            string pathTxt = @"C:\Users\ignat\Documents\.NET CodeAcademy\Assignments\NET CodeAcademy Assignments\08 Tower Of Hamoi OOP.Domain\Logs\log.txt";
            TextWriter txt = new StreamWriter(pathTxt, true);
            var newLineTXT = $"zaidime, kuris pradetas {date.ToString("yyyy-MM-dd hh:mm")}, ejimu nr {Zaidimas.ejimoNr} {Zaidimas.aktyvusDiskas.keliuDaliu} daliu diskas buvo paimtas is {stulpelisIsKurioPaeme} stulpelio ir padetas i {stulpelisIKuriPadejo} stulpeli";
            txt.WriteLine(newLineTXT);
            txt.Close();
        }

        public static string stulpelioNrToString(string pasirinktasStulpelis, string stulpelisIsKurioPaeme, ref string stulpelisIKuriPadejo)
        {
            switch (stulpelisIsKurioPaeme)
            {
                case "1":
                    stulpelisIsKurioPaeme = "pirmo";
                    break;
                case "2":
                    stulpelisIsKurioPaeme = "antro";
                    break;
                case "3":
                    stulpelisIsKurioPaeme = "trecio";
                    break;
                case "4":
                    stulpelisIsKurioPaeme = "ketvirto";
                    break;
                default:
                    break;
            }
            switch (pasirinktasStulpelis)
            {
                case "1":
                    stulpelisIKuriPadejo = "pirma";
                    break;
                case "2":
                    stulpelisIKuriPadejo = "antra";
                    break;
                case "3":
                    stulpelisIKuriPadejo = "trecia";
                    break;
                case "4":
                    stulpelisIKuriPadejo = "ketvirta";
                    break;
                default:
                    break;
            }
            return stulpelisIsKurioPaeme;
        }
    }
}