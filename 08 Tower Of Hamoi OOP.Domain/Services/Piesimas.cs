using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_Tower_Of_Hamoi_OOP.Domain.Models;

namespace _08_Tower_Of_Hamoi_OOP.Domain.Services
{
    public class Piesimas
    {
        public Piesimas(Stulpelis stulpelis1, Stulpelis stulpelis2, Stulpelis stulpelis3, int ejimoNr, Diskas aktyvusDiskas)
        {
            this.stulpelis1 = stulpelis1;
            this.stulpelis2 = stulpelis2;
            this.stulpelis3 = stulpelis3;
            this.ejimoNr = ejimoNr;
            this.aktyvusDiskas = aktyvusDiskas;
        }

        public Stulpelis stulpelis1 { get; set; }
        public Stulpelis stulpelis2 { get; set; }
        public Stulpelis stulpelis3 { get; set; }
        public int ejimoNr { get; set; }
        public Diskas aktyvusDiskas { get; set; }
        public void piesti()
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
    }
}
