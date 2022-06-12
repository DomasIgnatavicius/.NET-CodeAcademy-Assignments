using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            towerOfHanoi();
        }
        static void teorineDalis()
        {
            string hello = "Hello";
            string world = " World!";

            string tuscias = "";
            string nulas = null;
            string laisvaerdve = "";

            string raideA = "AAAAAAAAAAAA";
            string raideB = raideA.Replace("A", "B"); // replace kabutese rasom pirma is ko keiciam(is A) ir tada i ka keiciam(i B)

            //Galima naudoti tuos pacius tris su visais string kintamaisiai

            string konkatinacija = hello + world;
            Console.WriteLine(konkatinacija);

            string kompozicija = String.Format("{0}{1}", hello, world);
            Console.WriteLine(kompozicija);

            string interpoliacija = $"{hello}{world}";
            Console.WriteLine(interpoliacija);

            Console.WriteLine(raideB);
        }

        static void towerOfHanoi()
        {
            string stulpelis = "|";
            string vienas = "#|#";
            string du = "##|##";
            string trys = "###|###";
            string keturi = "####|####";

            //1.
            // Nupieškite Tower of Hanoi. Piešiniui naudokite kintamuosius.
            Console.WriteLine("NUPIESIAME TOWER OF HANOI");
            Console.WriteLine();

            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"     {vienas}           {stulpelis}            {stulpelis}");
            Console.WriteLine($"    {du}          {stulpelis}            {stulpelis}");
            Console.WriteLine($"   {trys}         {stulpelis}            {stulpelis}");
            Console.WriteLine($"  {keturi}        {stulpelis}            {stulpelis}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            Console.ReadKey();
            Console.WriteLine();

            //2.
            // Apverskite pirmą sulpelį ir išveskite visą Tower of Hanoi
            Console.WriteLine("APVERCIAME PIRMA PIRAMIDE");
            Console.WriteLine();

            Console.WriteLine($"  {keturi}        {stulpelis}            {stulpelis}");
            Console.WriteLine($"   {trys}         {stulpelis}            {stulpelis}");
            Console.WriteLine($"    {du}          {stulpelis}            {stulpelis}");
            Console.WriteLine($"     {vienas}           {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            Console.ReadKey();
            Console.WriteLine();

            //3.
            // Išvalykite pirmą stulpelį ir išveskite tuščią Tower of Hanoi
            Console.WriteLine("TUSCIAS TOWERIS");
            Console.WriteLine();

            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            Console.ReadKey();
            Console.WriteLine();

            //4.
            // Į kiekvieno stulpelio 5eil įdėkite po 4 dalių elementą ir išveskite Tower of Hanoi
            Console.WriteLine("Į kiekvieno stulpelio 5eil įdėkite po 4 dalių elementą ir išveskite Tower of Hanoi");
            Console.WriteLine();

            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"  {keturi}    {keturi}    {keturi}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            Console.ReadKey();
            Console.WriteLine();

            //5.
            // Į 1stulp 5eil įdėkite 4 dalių elementą, 2sutup 5eil - 3 dalių, 3sutup 4eil - 1 dalies, 3sutup 5eil - 2 dalių, ir išveskite Tower of Hanoi
            Console.WriteLine("Į 1stulp 5eil įdėkite 4 dalių elementą, 2sutup 5eil - 3 dalių, 3sutup 4eil - 1 dalies, 3sutup 5eil - 2 dalių, ir išveskite Tower of Hanoi");
            Console.WriteLine();

            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}           {vienas}");
            Console.WriteLine($"  {keturi}     {trys}       {du}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            Console.ReadKey();
            Console.WriteLine();

            //6.
            // Į 1stulp 4eil įdėkite tokį pat elementą kaip yra 3stup 4eil, ir išveskite Tower of Hanoi
            Console.WriteLine("Į 1stulp 4eil įdėkite tokį pat elementą kaip yra 3stup 4eil, ir išveskite Tower of Hanoi");
            Console.WriteLine();

            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"     {vienas}           {stulpelis}           {vienas}");
            Console.WriteLine($"  {keturi}     {trys}       {du}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            //7.
            // Į visas 2stulp eilutes įdėkite tokį pat elementą kaip yra 3stup 5eil, ir išveskite Tower of Hanoi
            Console.WriteLine("Į visas 2stulp eilutes įdėkite tokį pat elementą kaip yra 3stup 5eil, ir išveskite Tower of Hanoi");
            Console.WriteLine();

            Console.WriteLine($"      {stulpelis}          {du}          {stulpelis}");
            Console.WriteLine($"      {stulpelis}          {du}          {stulpelis}");
            Console.WriteLine($"      {stulpelis}          {du}          {stulpelis}");
            Console.WriteLine($"     {vienas}         {du}         {vienas}");
            Console.WriteLine($"  {keturi}      {du}        {du}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            //8.
            // į 3stulp sudėkite teisingą piramidę. 1stulp ir 2 stulp turi likti tušti, išveskite Tower of Hanoi
            Console.WriteLine("į 3stulp sudėkite teisingą piramidę. 1stulp ir 2 stulp turi likti tušti, išveskite Tower of Hanoi");
            Console.WriteLine();

            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}           {vienas}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}          {du}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}         {trys}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}        {keturi}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            //9.
            // pakeiskite visų elementų dizainą iš # į " , išveskite Tower of Hanoi
            Console.WriteLine("pakeiskite visų elementų dizainą iš # į \", išveskite Tower of Hanoi");
            Console.WriteLine();

            Console.WriteLine($"      {stulpelis}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}           {vienas.Replace("#", "\"")}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}          {du.Replace("#", "\"")}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}         {trys.Replace("#", "\"")}");
            Console.WriteLine($"      {stulpelis}            {stulpelis}        {keturi.Replace("#", "\"")}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");

            //10.
            // paprašykite naudotojo nupiešti 1 sulpelio 1 eilutę. Išveskite visą Tower of Hanoi su perpiešta pirma eilute
            Console.WriteLine("paprašykite naudotojo nupiešti 1 sulpelio 1 eilutę. Išveskite visą Tower of Hanoi su perpiešta pirma eilute");
            Console.WriteLine();

            string zmogausEilute;

            Console.WriteLine("NUPIESKITE 1STULP 1EIL: ");
            zmogausEilute = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine($"      {zmogausEilute}            {stulpelis}            {stulpelis}");
            Console.WriteLine($"     {vienas}           {stulpelis}           {vienas.Replace("#", "\"")}");
            Console.WriteLine($"    {du}          {stulpelis}          {du.Replace("#", "\"")}");
            Console.WriteLine($"   {trys}         {stulpelis}         {trys.Replace("#", "\"")}");
            Console.WriteLine($"  {keturi}        {stulpelis}        {keturi.Replace("#", "\"")}");
            Console.WriteLine("----1stulp-------2stulp-------3stulp----");
        }

    }
}

