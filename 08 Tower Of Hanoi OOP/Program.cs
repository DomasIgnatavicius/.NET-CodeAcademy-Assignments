using _08_Tower_Of_Hamoi_OOP.Domain.Models;
using System.Text;

namespace _08_Tower_Of_Hanoi_OOP
{
    internal class Program
    {
        static public Diskas diskas1 = new Diskas(1, "#|#");
        static public Diskas diskas2 = new Diskas(2, "##|##");
        static public Diskas diskas3 = new Diskas(3, "###|###");
        static public Diskas diskas4 = new Diskas(4, "####|####");
        static public Diskas[] Diskai = new Diskas[] { diskas1, diskas2, diskas3, diskas4 };
        static public string diskuVietos = "1111";
        static void Main(string[] args)
        {
            /* Console.WriteLine($"Pries perkelimas: {diskuVietos}");
             diskoPerkelimas(1, "3");
             Console.WriteLine();
             Console.WriteLine($"Po perkelimo: {diskuVietos}");*/
            piesimas();
            
        }

        public static void piesimas()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1eil.");
            for(int i = 1; i < 4; i++)
            {
                if (diskuVietos[i-1] == i)
                {
                    sb.Append($"     {}     ");
                }




                /*for(int j = 0; j < 4; j++)
                {
                    if (diskuVietos[j] == i)
                    {
                        sb.Append($"     {Diskai[j].piesinukas}     ");
                    }
                    else
                        sb.Append($"     {"|"}     ");
                }*/
                
            }

            Console.WriteLine(sb);


            /*Console.Write("1eil.");
            Console.Write(String.Format("{0,8}", "|").Replace("|",diskas1.piesinukas));
            Console.Write(String.Format("{0,8}", "|"));
            Console.WriteLine();
            Console.Write("2eil.");
            Console.Write(String.Format("{0,8}", "|").Replace("|", diskas2.piesinukas));
            Console.Write(String.Format("{0,8}", "|"));
            Console.WriteLine();
            Console.Write("3eil.");
            Console.Write(String.Format("{0,6}", "|").Replace("|", diskas1.piesinukas));
            Console.Write(String.Format("{0,6}", "|"));
            Console.WriteLine();
            Console.Write("4eil.");
            Console.Write(String.Format("{0,6}", "|").Replace("|", diskas1.piesinukas));
            Console.Write(String.Format("{0,6}", "|"));
            Console.WriteLine();
            Console.Write("5eil.");
            Console.Write(String.Format("{0,6}", "|").Replace("|", diskas1.piesinukas));
            Console.Write(String.Format("{0,6}", "|"));
            Console.WriteLine();*/
        }

        public static void diskoPerkelimas(int diskoNr, string iKur)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 4; i++)
            {
                if(diskoNr-1 == i)
                    sb.Append(iKur);
                else
                    sb.Append(diskuVietos[i]);
            }
            diskuVietos = sb.ToString();
        }
    }
}