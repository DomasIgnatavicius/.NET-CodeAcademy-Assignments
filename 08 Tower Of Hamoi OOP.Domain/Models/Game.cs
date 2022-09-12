using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Tower_Of_Hamoi_OOP.Domain.Models
{
    public class Game
    {
        public Game()
        {
            diskas1 = new Diskas(1, "    #|#    ");
            diskas2 = new Diskas(2, "   ##|##   ");
            diskas3 = new Diskas(3, "  ###|###  ");
            diskas4 = new Diskas(4, " ####|#### ");

            stulpelis1 = new Stulpelis(1);
            stulpelis2 = new Stulpelis(2);
            stulpelis3 = new Stulpelis(3);

            Diskai = new Diskas[] { diskas1, diskas2, diskas3, diskas4 };
            Tower = new Stulpelis[3] { stulpelis1, stulpelis2, stulpelis3 };

            diskuVietos = "1111";
            gameState = "disko paemimas";
            ejimoNr = 0;
            aktyvusDiskas = new Diskas();
        }
        /*static public Diskas diskas1 = new Diskas(1, "    #|#    ");
        static public Diskas diskas2 = new Diskas(2, "   ##|##   ");
        static public Diskas diskas3 = new Diskas(3, "  ###|###  ");
        static public Diskas diskas4 = new Diskas(4, " ####|#### ");
        static public Stulpelis stulpelis1 = new Stulpelis(1);
        static public Stulpelis stulpelis2 = new Stulpelis(2);
        static public Stulpelis stulpelis3 = new Stulpelis(3);
        static public Diskas[] Diskai = new Diskas[] { diskas1, diskas2, diskas3, diskas4 };
        static public Stulpelis[] Tower = new Stulpelis[3] { stulpelis1, stulpelis2, stulpelis3 };
        static public string diskuVietos = "1111";
        public static string gameState = "disko paemimas";
        static public int ejimoNr = 0;
        public static Diskas aktyvusDiskas = new Diskas();
        public static System.ConsoleKeyInfo pasirinkasStulpelis;*/

        public Diskas diskas1 { get; set; }
        public Diskas diskas2 { get; set; }
        public Diskas diskas3 { get; set; }
        public Diskas diskas4 { get; set; }
        public Stulpelis stulpelis1 { get; set; }
        public Stulpelis stulpelis2 { get; set; }
        public Stulpelis stulpelis3 { get; set; }
        public Diskas[] Diskai { get; set; }
        public Stulpelis[] Tower { get; set; }
        public string diskuVietos { get; set; }
        public string gameState { get; set; }
        public int ejimoNr { get; set; }
        public Diskas aktyvusDiskas { get; set; }
        public System.ConsoleKeyInfo pasirinkasStulpelis { get; set; }

    }
}
