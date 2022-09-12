﻿using _08_Tower_Of_Hamoi_OOP.Domain.Models;
using System.Text;

namespace _08_Tower_Of_Hanoi_OOP
{
    internal class Program
    {
        static public Diskas diskas1 = new Diskas(1, "    #|#    ");
        static public Diskas diskas2 = new Diskas(2, "   ##|##   ");
        static public Diskas diskas3 = new Diskas(3, "  ###|###  ");
        static public Diskas diskas4 = new Diskas(4, " ####|#### ");
        static public Stulpelis stulpelis1 = new Stulpelis(1);
        static public Stulpelis stulpelis2 = new Stulpelis(2);
        static public Stulpelis stulpelis3 = new Stulpelis(3);
        static public Diskas[] Diskai = new Diskas[] { diskas1, diskas2, diskas3, diskas4 };
        static public Stulpelis[] Tower = new Stulpelis[3] { stulpelis1, stulpelis2, stulpelis3};
        static public string diskuVietos = "1111";
        public static string gameState = "disko paemimas";
        static public int ejimoNr = 0;
        public static Diskas aktyvusDiskas = new Diskas();
        public static System.ConsoleKeyInfo pasirinkasStulpelis;
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
                    pasirinkasStulpelis = Console.ReadKey();
                    //Console.WriteLine(pasirinkasStulpelis);
                    if(pasirinkasStulpelis.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else if(!int.TryParse(pasirinkasStulpelis.KeyChar.ToString(), out _))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ivesta ne skaitine reiksme, press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        piesimas();
                    }
                    else if(pasirinkasStulpelis.KeyChar.ToString() == "1" || pasirinkasStulpelis.KeyChar.ToString() == "2" || pasirinkasStulpelis.KeyChar.ToString() == "3")
                    {
                        if (arStulpelisTuscias(int.Parse(pasirinkasStulpelis.KeyChar.ToString())))
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
                diskoPerkelimas(int.Parse(pasirinkasStulpelis.KeyChar.ToString()));
                Console.Clear();
            }
            
            
        }

        public static void piesimas()
        {
            Console.WriteLine($"Ejimas: {ejimoNr}");
            Console.WriteLine($"Diskas rankoje: {aktyvusDiskas.piesinukas}");
            Console.WriteLine();
            Console.WriteLine($"eil1. {stulpelis1.eilutes[0]} {stulpelis2.eilutes[0]} {stulpelis3.eilutes[0]}");
            Console.WriteLine($"eil2. {stulpelis1.eilutes[1]} {stulpelis2.eilutes[1]} {stulpelis3.eilutes[1]}");
            Console.WriteLine($"eil3. {stulpelis1.eilutes[2]} {stulpelis2.eilutes[2]} {stulpelis3.eilutes[2]}");
            Console.WriteLine($"eil4. {stulpelis1.eilutes[3]} {stulpelis2.eilutes[3]} {stulpelis3.eilutes[3]}");
            Console.WriteLine($"eil5. {stulpelis1.eilutes[4]} {stulpelis2.eilutes[4]} {stulpelis3.eilutes[4]}");
            Console.WriteLine("          [1]         [2]         [3]");
        }

        public static void diskoPerkelimas(int pasirinktasStulpelis)
        {
            System.ConsoleKeyInfo pasirinkimas;
            diskoPaemimas(pasirinktasStulpelis);
            Console.Clear();
            piesimas();
            while (gameState == "disko padejimas")
            {
                while (true)
                {
                    Console.WriteLine("Pasirinkite i koki stulpeli noretumete padeti: ");
                    pasirinkimas = Console.ReadKey();
                    if (pasirinkasStulpelis.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else if (pasirinkasStulpelis.KeyChar.ToString() == "1" || pasirinkasStulpelis.KeyChar.ToString() == "2" || pasirinkasStulpelis.KeyChar.ToString() == "3")
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
                if (gameState == "disko padejimas")
                {
                    Console.WriteLine();
                    Console.WriteLine("Negalima dedi didenio ant mazesnio, press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    piesimas();
                }
                
            }
            ejimoNr++;
            
        }

        public static void diskoPadejimas(int pasirinktasStulpelis)
        {
            for(int i = 4; i >= 0; i--)
            {
                if (Tower[pasirinktasStulpelis - 1].eilutes[i] == "     |     ")
                {
                    Tower[pasirinktasStulpelis - 1].eilutes[i] = aktyvusDiskas.piesinukas;
                    aktyvusDiskas = new Diskas();
                    gameState = "disko paemimas";
                    break;
                }
                else if(Tower[pasirinktasStulpelis - 1].eilutes[i-1] == "     |     ")
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Tower[pasirinktasStulpelis - 1].eilutes[i] == Diskai[j].piesinukas)
                        {
                            if(aktyvusDiskas.keliuDaliu < Diskai[j].keliuDaliu)
                            {
                                Tower[pasirinktasStulpelis - 1].eilutes[i - 1] = aktyvusDiskas.piesinukas;
                                aktyvusDiskas = new Diskas();
                                gameState = "disko paemimas";
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
                if (Tower[pasirinktasStulpelis - 1].eilutes[i] != "     |     ")
                {
                    return false;
                }
            }
            return true;
        }

        public static void piesinukoReset()
        {
            stulpelis1.eilutes[1] = diskas1.piesinukas;
            stulpelis1.eilutes[2] = diskas2.piesinukas;
            stulpelis1.eilutes[3] = diskas3.piesinukas;
            stulpelis1.eilutes[4] = diskas4.piesinukas;
        }

        public static void diskoPaemimas(int pasirinktasStulpelis)
        {
            
            for(int i = 0; i < 5; i++)
            {
                if (Tower[pasirinktasStulpelis - 1].eilutes[i] != "     |     ")
                {
                    for(int j = 0; j < 4; j++)
                    {
                        if(Tower[pasirinktasStulpelis - 1].eilutes[i] == Diskai[j].piesinukas)
                        {
                            aktyvusDiskas = Diskai[j];
                            break;
                        }
                    }
                    Tower[pasirinktasStulpelis - 1].eilutes[i] = "     |     ";
                    break;
                }
            }
            gameState = "disko padejimas";
        }
    }
}