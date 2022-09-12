using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Tower_Of_Hamoi_OOP.Domain.Models
{
    public class Diskas
    {
        public Diskas()
        {

        }
        public Diskas(int keliuDaliu, string piesinukas)
        {
            this.keliuDaliu = keliuDaliu;
            this.piesinukas = piesinukas;
        }
    
        public int keliuDaliu { get; set; }
        public string piesinukas { get; set; }
    }
}
