using Music_Shop_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Shop_DB.Database.Services
{
    public class Validator
    {
        public int Kodas => 1234;
        ManagerDb manageDb = new ManagerDb(); 
        public void validateInitialWindow(string pasirinkimas)
        {
            ProgramManager programManager = new ProgramManager();
            if (!int.TryParse(pasirinkimas, out _))
            {
                Console.WriteLine("Ivestas ne skaicius, press any key to continue...");
                Console.ReadLine();
                Console.Clear();
                programManager.initialWindow();
            }
            else if (pasirinkimas == "1" || pasirinkimas == "2" || pasirinkimas == "3")
            {
                return;
            }
            else
            {
                Console.WriteLine("Ivestas netinkamas pasirinkimas(galimi pasirinkimai 1 2 3), press any key to continue...");
                Console.ReadLine();
                Console.Clear();
                programManager.initialWindow();
            }
                
        }

        public void validatePrisijungimas(string activeUserId)
        {
            bool arYraToksCustomer = false;
            ProgramManager programManager = new ProgramManager();
            if (!long.TryParse(activeUserId, out _))
            {
                Console.WriteLine("Ivestas ne skaicius, press any key to continue...");
                Console.ReadLine();
                Console.Clear();
                programManager.initialWindow();
            }
            long activeUserIdLong = long.Parse(activeUserId);
            List < Customer > customers = manageDb.getAllCustomers();
            foreach (var customer in customers)
            {
                if(customer.CustomerId == activeUserIdLong)
                {
                    arYraToksCustomer = true;
                    break;
                }

            }
            if (!arYraToksCustomer)
            {
                Console.WriteLine("Tokio customer nera, press any key to continue...");
                Console.ReadLine();
                Console.Clear();
                programManager.initialWindow();
            }
            else
                return;
        }

        public void validateDarbuotojuParinktys()
        {
            ProgramManager programManager = new ProgramManager();
            Console.Clear();
            Console.WriteLine("Iveskite koda");
            var kodas = Console.ReadLine();
            if (!int.TryParse(kodas, out _))
            {
                Console.WriteLine("Ivestas ne skaicius, press any key to continue...");
                Console.ReadLine();
                Console.Clear();
                programManager.initialWindow();
            }
            else if (int.Parse(kodas) != Kodas)
            {
                Console.WriteLine("Ivestas neteisingas kodas, press any key to continue...");
                Console.ReadLine();
                Console.Clear();
                programManager.initialWindow();
            }
            else
            {
                Console.Clear();
                return;
            }
                
        }

        public void validatePirkimoProcesas(string pasirinkimas, string option)
        {
            ProgramManager programManager = new ProgramManager();
            switch (option)
            {
                case "4":
                    if (pasirinkimas == "1" || pasirinkimas == "2" || pasirinkimas == "3" || pasirinkimas == "4" || pasirinkimas == "q")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Ivestas neteisingas pasirinkimas, press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        programManager.pirkimoLangas();
                    }
                    break;
                case "qy":
                    if (pasirinkimas == "y" || pasirinkimas == "q")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Ivestas neteisingas pasirinkimas, press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        programManager.idetiIKrepseliLangas();
                    }
                    break;
                default:
                    break;
            }
            
        }
    }
}
