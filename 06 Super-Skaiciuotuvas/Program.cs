namespace _06_Super_Skaiciuotuvas
{
    public class Program
    {
        static double? rezultatas = null;
        static string[] moves = new string[] {};
        static int movesCount = 0;
        static int machineState = 1; // 1 - esame meniu, 2 - esame submeniu, 3 - vykdoma operacija
        static double? pirmas = null;
        static double? antras = null;
        static string? operation = null; // + - * /
        static int operationState = 0; // 1 - ivedamas pirmsa skaicius, 2 - ivedamas antras skaicius 0 - operacija nevyksta
        static bool testiSuRezultatu = false;
        static void Main(string[] args)
        {
            var fake_moves = new string[] { "1", "1", "15", "45", "2", "2", "10", "3" };
            //var fake_moves = new string[] { "1", "1", "15", "45", "3" };
            //var fake_moves = new string[] { "1", "1", "15", "45", "2", "2", "10", "1", "3", "2", "3", "3" };
            foreach (var move in fake_moves)
            {
                Console.WriteLine("--------PRIES----------");
                Console.WriteLine("Machine sstate:" + machineState);
                Console.WriteLine("Operation state:" + operationState);
                Console.WriteLine("Testi su rezultatu:" + testiSuRezultatu);
                Console.WriteLine("Operation:" + operation);
                Console.WriteLine("Pirmas: " + pirmas);
                Console.WriteLine("Antras: " + antras);
                Console.WriteLine("Rezultatas" + Rezultatas());
                SuperSkaiciuotuvas(move);
                Console.WriteLine("--------PO----------");
                Console.WriteLine(move);
                Console.WriteLine();
                Console.WriteLine("Machine sstate:" + machineState);
                Console.WriteLine("Operation state:" + operationState);
                Console.WriteLine("Testi su rezultatu:" + testiSuRezultatu);
                Console.WriteLine("Operation:" + operation);
                Console.WriteLine("Pirmas: " + pirmas);
                Console.WriteLine("Antras: " + antras);
                Console.WriteLine("Rezultatas" + Rezultatas());
            }
            /*while (true)
            {

                if (machineState == 1)
                {
                    PradinisMeniu();

                    SuperSkaiciuotuvas(moves[movesCount - 1]);
                    Console.WriteLine("Machine sstate:" + machineState);
                    Console.WriteLine("Operation state:" + operationState);
                    Console.WriteLine("Testi su rezultatu:" + testiSuRezultatu);
                    Console.WriteLine("Operation:" + operation);
                    Console.WriteLine("Pirmas: " + pirmas);
                    Console.WriteLine("Antras: " + antras);
                }
                if (machineState == 2)
                {
                    SubMeniu();
                    SuperSkaiciuotuvas(moves[movesCount - 1]);
                    Console.WriteLine("Machine sstate:" + machineState);
                    Console.WriteLine("Operation state:" + operationState);
                    Console.WriteLine("Testi su rezultatu:" + testiSuRezultatu);
                    Console.WriteLine("Operation:" + operation);
                    Console.WriteLine("Pirmas: " + pirmas);
                    Console.WriteLine("Antras: " + antras);
                }
                if (machineState == 3)
                {
                    Console.WriteLine("YEE");
                    if (testiSuRezultatu)
                    {
                        Console.WriteLine("Iveskite viena skaicius");
                        Array.Resize(ref moves, moves.Length + 1);
                        moves[movesCount] = Convert.ToString(Console.ReadLine());
                        movesCount++;
                        SuperSkaiciuotuvas(moves[movesCount - 1]);
                        Console.WriteLine("Machine sstate:" + machineState);
                        Console.WriteLine("Operation state:" + operationState);
                        Console.WriteLine("Testi su rezultatu:" + testiSuRezultatu);
                        Console.WriteLine("Operation:" + operation);
                        Console.WriteLine("Pirmas: " + pirmas);
                        Console.WriteLine("Antras: " + antras);
                    }
                    else
                    {
                        Console.WriteLine("Iveskite du skaicius");
                        for (int i = 0; i < 2; i++)
                        {
                            Array.Resize(ref moves, moves.Length + 1);
                            moves[movesCount] = Convert.ToString(Console.ReadLine());
                            movesCount++;
                            SuperSkaiciuotuvas(moves[movesCount - 1]);
                            Console.WriteLine("Machine sstate:" + machineState);
                            Console.WriteLine("Operation state:" + operationState);
                            Console.WriteLine("Testi su rezultatu:" + testiSuRezultatu);
                            Console.WriteLine("Operation:" + operation);
                            Console.WriteLine("Pirmas: " + pirmas);
                            Console.WriteLine("Antras: " + antras);
                        }
                    }

                }
                Console.WriteLine("---------");
                for (int i = 0; i < moves.Length; i++)
                {
                    Console.WriteLine(moves[i]);
                }
                Console.WriteLine("---------");
                Console.WriteLine();
                Console.WriteLine(Rezultatas());
            }*/

        }

        public static void SuperSkaiciuotuvas(string move)
        {
            if(machineState == 2)
            {
                switch (move)
                {
                    case "1":
                        operation = "+";
                        break;
                    case "2":
                        operation = "-";
                        break;
                    case "3":
                        operation = "*";
                        break;
                    case "4":
                        operation = "/";
                        break;
                    case "5":
                        operation = "sqrt";
                        break;
                    case "6":
                        operation = "^";
                        break;
                    default:
                        break;
                }
                machineState = 3;
                operationState++;
            }
            else if (move == "1" && machineState == 1)
            {
                machineState = 2;
            }
            else if(move == "2" && rezultatas == null && machineState == 1)
            {
                Environment.Exit(0);
            }
            else if (move == "3" && rezultatas != null && machineState == 1)
            {
                Environment.Exit(0);
            }
            else if (rezultatas != null && machineState == 1 && move == "2")
            {
                testiSuRezultatu = true;
                machineState = 2;
            }
            else if (machineState == 3 && operationState == 1)
            {
                if (testiSuRezultatu)
                {
                    pirmas = rezultatas;
                    antras = Convert.ToDouble(move);
                    skaiciavimas();
                    testiSuRezultatu = false;
                }
                else
                {
                    pirmas = Convert.ToDouble(move);
                    operationState++;
                }

            }
            else if (machineState == 3 && operationState == 2)
            {
                antras = Convert.ToDouble(move);
                skaiciavimas();
            }

            

        }
        public static double Rezultatas()
        {
            return rezultatas ?? 0;
        }

        public static void Reset()
        {
             rezultatas = null;
             moves = new string[] { };
             movesCount = 0;
             machineState = 1; // 1 - esame meniu, 2 - esame submeniu, 3 - vykdoma operacija
             pirmas = null;
             antras = null;
             operation = null; // + - * /
             operationState = 0; // 1 - ivedamas pirmsa skaicius, 2 - ivedamas antras skaicius 0 - operacija nevyksta
             testiSuRezultatu = false;
        }

        public static void PradinisMeniu()
        {
            if (rezultatas != null)
            {
                Console.WriteLine("1) Nauja Operacija");
                Console.WriteLine("2) Testi su rezultatu");
                Console.WriteLine("3) Iseiti");
                Array.Resize(ref moves, moves.Length + 1);
                moves[movesCount] = Convert.ToString(Console.ReadLine());
                if (moves[movesCount] == "2")
                {
                    testiSuRezultatu = true;
                }
            }
            else
            {
                Console.WriteLine("1) Nauja Operacija");
                Console.WriteLine("2) Iseiti");
                Array.Resize(ref moves, moves.Length + 1);
                moves[movesCount] = Convert.ToString(Console.ReadLine());
            }
            movesCount++;
            Console.WriteLine();
        }

        public static void SubMeniu()
        {
            
            Console.WriteLine("1) Sudetis");
            Console.WriteLine("2) Atimtis");
            Console.WriteLine("3) Daugyba"); 
            Console.WriteLine("4) Dalyba");
            Console.WriteLine("5) Traukti sakni");
            Console.WriteLine("6) Kelimas laipsniu");
            Array.Resize(ref moves, moves.Length + 1);
            moves[movesCount] = Convert.ToString(Console.ReadLine());
            movesCount++;
            Console.WriteLine();
        }

        public static void skaiciavimas()
        {
            if (machineState == 3 && operation == "+")
            {
                rezultatas = pirmas + antras;
                machineState = 1;
                operationState = 0;
                operation = null;
                pirmas = null;
                antras = null;
            }
            if (machineState == 3 && operation == "-")
            {
                rezultatas = pirmas - antras;
                machineState = 1;
                operationState = 0;
                operation = null;
                pirmas = null;
                antras = null;
            }
            if (machineState == 3 && operation == "*")
            {
                rezultatas = pirmas * antras;
                machineState = 1;
                operationState = 0;
                operation = null;
                pirmas = null;
                antras = null;
            }
            if (machineState == 3 && operation == "/")
            {
                rezultatas = pirmas / antras;
                machineState = 1;
                operationState = 0;
                operation = null;
                pirmas = null;
                antras = null;
            }
            if (machineState == 3 && operation == "sqrt")
            {
                rezultatas = Convert.ToDouble(Math.Pow(Convert.ToDouble(pirmas), (1 / Convert.ToDouble(antras))));
                machineState = 1;
                operationState = 0;
                operation = null;
                pirmas = null;
                antras = null;
            }
            if (machineState == 3 && operation == "^")
            {
                rezultatas = Convert.ToDouble(Math.Pow(Convert.ToDouble(pirmas), Convert.ToDouble(antras)));
                machineState = 1;
                operationState = 0;
                operation = null;
                pirmas = null;
                antras = null;
            }
        }
        public static int MoveCountReturn()
        {
            return operationState;
        }

    }
}

