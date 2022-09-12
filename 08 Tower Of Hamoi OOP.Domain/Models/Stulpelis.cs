using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Tower_Of_Hamoi_OOP.Domain.Models
{
    public class Stulpelis
    {
        public Stulpelis(int stulpelioNr)
        {
           /* eil1 = "     |     ";
            eil2 = "     |     ";
            eil3 = "     |     ";
            eil4 = "     |     ";
            eil5 = "     |     ";*/
            for(int i = 0; i< 5; i++)
            {
                eilutes[i] = "     |     ";
            }
            this.stulpelioNr = stulpelioNr;
        }
        public int stulpelioNr { get; set; }
        /*public string eil1 { get; set; }
        public string eil2 { get; set; }
        public string eil3 { get; set; }
        public string eil4 { get; set; }
        public string eil5 { get; set; }*/
        public string[] eilutes  = new string[5];
    }
}
