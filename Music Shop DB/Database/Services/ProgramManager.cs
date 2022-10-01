using Music_Shop_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Shop_DB.Database.Services
{
    public class ProgramManager
    {
        ManagerDb managerDB = new ManagerDb();
        Validator validator = new Validator();
        public Customer activeUser { get; private set; }
        public List<Track> dainuKrepselis { get; private set; } = null;
        public int savedId { get; set; }
        public int activeUserId { get; private set; }
        public string? savedName { get; private set; }
        public long savedAlbumId { get; private set; }
        public string? savedAlbumName { get; private set; }

        public void initialWindow()
        {
            Console.WriteLine("1. Prisijungi");
            Console.WriteLine("2. Registruotis");
            Console.WriteLine("3. Darbuotoju parinktys");
            var pasirinkimas = Console.ReadLine();
            validator.validateInitialWindow(pasirinkimas);
            switch (int.Parse(pasirinkimas))
            {
                case 1:
                    Console.Clear();
                    prisijungimas();
                    break;
                case 2:
                    Console.Clear();
                    registracija();
                    break;
                case 3:
                    Console.Clear();
                    validator.validateDarbuotojuParinktys();
                    darbuotojuMeniu();
                    break;
                default:
                    break;
            }
        }

        public void registracija()
        {
            Console.WriteLine("Iveskite varda: ");
            string vardas = Console.ReadLine();
            Console.WriteLine("Iveskite pavarde: ");
            string pavarde = Console.ReadLine();
            Console.WriteLine("Iveskite kompanija(optional): ");
            string? company = Console.ReadLine();
            Console.WriteLine("Iveskite adresa(optional): ");
            string? adresas = Console.ReadLine();
            Console.WriteLine("Iveskite miesta(optional): ");
            string? miestas = Console.ReadLine();
            Console.WriteLine("Iveskite valstija(optional): ");
            string? valstija = Console.ReadLine();
            Console.WriteLine("Iveskite sali(optional): ");
            string? salis = Console.ReadLine();
            Console.WriteLine("Iveskite pasto koda(optional): ");
            string? pastoKodas = Console.ReadLine();
            Console.WriteLine("Iveskite tel. numeri(optional): ");
            string? telNr = Console.ReadLine();
            Console.WriteLine("Iveskite fax(optional): ");
            string? fax = Console.ReadLine();
            Console.WriteLine("Iveskite email: ");
            string email = Console.ReadLine();
            managerDB.addCustomer(vardas, pavarde, company, adresas, miestas, valstija, salis, pastoKodas, telNr, fax, email);

            Console.WriteLine();
            Console.WriteLine("Registracija sekminga, press any key to continue...");
            Console.ReadLine();
            Console.Clear();
            initialWindow();
        }

        public void prisijungimas()
        {
            using var context = new chinookContext();
            Console.WriteLine("PRIE KURIO VARTOTOJO NORETUMETE PRISIJUNGI? ");
            managerDB.getAllCustomers();
            Console.WriteLine("PRIE KURIO VARTOTOJO NORETUMETE PRISIJUNGI? ");
            Console.WriteLine("Irasykite vartotojo ID: ");
            var activeUserId = Console.ReadLine();
            validator.validatePrisijungimas(activeUserId);
            activeUser = context.Customers.Find(long.Parse(activeUserId));
            Console.Clear();
            pirkimoLangas();
        }

        public void pirkimoLangas()
        {
            Console.WriteLine("1. Perziureti kataloga");
            Console.WriteLine("2. Ideti i krepseli");
            Console.WriteLine("3. Perziureti krepseli");
            Console.WriteLine("4. Perziureti pirkimu istorija");
            Console.WriteLine("q - Back");
            var pasirinkimas = Console.ReadLine();
            validator.validatePirkimoProcesas(pasirinkimas,"4");
            switch (pasirinkimas)
            {
                case "1":
                    Console.Clear();
                    perziuretiKataloga();
                    break;
                case "2":
                    Console.Clear();
                    idetiIKrepseliLangas();
                    break;
                case "3":
                    Console.Clear();
                    perziuretiKrepseli();
                    break;
                case "4":
                    Console.Clear();
                    managerDB.findCustomerInvoices(activeUser);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    pirkimoLangas();
                    break;
                case "q":
                    Console.Clear();
                    activeUser = new Customer();
                    initialWindow();
                    break ;
                default:
                    break;
            }

        }

        public void perziuretiKataloga()
        {
            managerDB.getAllTracks();
            perziuretiKatalogaNavigation();
        }
        public void perziuretiKatalogaNavigation()
        {
            Console.WriteLine("q - grizti atgal");
            Console.WriteLine("o - rikiuoti pagal");
            Console.WriteLine("s - paieska");
            var pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "q":
                    Console.Clear();
                    pirkimoLangas();
                    break;
                case "o":
                    Console.Clear();
                    perziuretiKatalogaRikiavimas();
                    break;
                case "s":
                    Console.Clear();
                    perziuretiKatalogaPaieska();
                    break;
                default:
                    break;
            }
        }

        public void perziuretiKatalogaRikiavimas()
        {
            Console.WriteLine("RIKIUOTI PAGAL");
            Console.WriteLine("1. Name abecėlės tvarka");
            Console.WriteLine("2. Name atvirkštine abecėlės tvarka");
            Console.WriteLine("3. Composer");
            Console.WriteLine("4. Genre");
            Console.WriteLine("5. Composer ir Album");
            var pasirinkimas = int.Parse(Console.ReadLine());
            switch (pasirinkimas)
            {
                case 1:
                    Console.Clear();
                    managerDB.getTracksNameABC();
                    perziuretiKatalogaNavigation();
                    break;
                case 2:
                    Console.Clear();
                    managerDB.getTracksNameCBA();
                    perziuretiKatalogaNavigation();
                    break;
                case 3:
                    Console.Clear();
                    managerDB.getTracksByComposer();
                    perziuretiKatalogaNavigation();
                    break;
                case 4:
                    Console.Clear();
                    managerDB.getTracksByGenre();
                    perziuretiKatalogaNavigation();
                    break;
                case 5:
                    Console.Clear();
                    managerDB.getTracksByGenre();
                    perziuretiKatalogaNavigation();
                    break;
                default:
                    break;
            }
        }

        public void perziuretiKatalogaPaieska()
        {
            Console.WriteLine("IESKOTI PAGAL");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Composer");
            Console.WriteLine("4. Genre");
            Console.WriteLine("5. Track lenght(miliseconds)");
            var pasirinkimas = int.Parse(Console.ReadLine());
            switch (pasirinkimas)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Irasykite Id: ");
                    int id = int.Parse(Console.ReadLine());
                    managerDB.searchTracksById(id);
                    perziuretiKatalogaNavigation();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Irasykite Pavadinima: ");
                    string name = Console.ReadLine();
                    managerDB.searchTracksByName(name);
                    perziuretiKatalogaNavigation();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Irasykite Composer: ");
                    string composer = Console.ReadLine();
                    managerDB.searchTracksByComposer(composer);
                    perziuretiKatalogaNavigation();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Irasykite Zanra: ");
                    string genre = Console.ReadLine();
                    managerDB.searchTracksByGenre(genre);
                    perziuretiKatalogaNavigation();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("1. Daugiau nei x");
                    Console.WriteLine("2. Maziau nei x");
                    int daugiauMaziau = int.Parse(Console.ReadLine());
                    switch (daugiauMaziau)
                    {
                        case 1:
                            Console.WriteLine("Iveskite milisekundes: ");
                            int miliMore = int.Parse(Console.ReadLine());
                            managerDB.searchTracksByMiliMore(miliMore);
                            break;
                        case 2:
                            Console.WriteLine("Iveskite milisekundes: ");
                            int miliLess = int.Parse(Console.ReadLine());
                            managerDB.searchTracksByMiliLess(miliLess);
                            break;
                        default:
                            break;
                    }
                    perziuretiKatalogaNavigation();
                    break;
                default:
                    break;
            }
        }

        public void idetiIKrepseliLangas()
        {
            Console.WriteLine("RINKTIS DAINA PAGAL: ");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Pavadinimą");
            Console.WriteLine("3. Albumo Id");
            Console.WriteLine("4. Albumo pavadinimą");
            Console.WriteLine("q - grizti atgal");
            var pasirinkimas = Console.ReadLine();
            validator.validatePirkimoProcesas(pasirinkimas,"4");
            switch (pasirinkimas)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Irasykite Id: ");
                    savedId = int.Parse(Console.ReadLine());
                    managerDB.searchTracksById(savedId);
                    idetiIkrepseliNavigacija(int.Parse(pasirinkimas));
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Irasykite Id: ");
                    savedName = Console.ReadLine();
                    managerDB.searchTracksByName(savedName);
                    idetiIkrepseliNavigacija(int.Parse(pasirinkimas));
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Irasykite Id: ");
                    savedAlbumId = long.Parse(Console.ReadLine());
                    managerDB.searchTracksByAlbumId(savedAlbumId);
                    idetiIkrepseliNavigacija(int.Parse(pasirinkimas));
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Irasykite Id: ");
                    savedAlbumName = Console.ReadLine();
                    managerDB.searchByAlbumName(savedAlbumName);
                    idetiIkrepseliNavigacija(int.Parse(pasirinkimas));
                    break;
                case "q":
                    Console.Clear();
                    pirkimoLangas();
                    break;
                default:
                    break;
            }
        }

        public void idetiIkrepseliNavigacija(int pasirinktasVeiksmas)
        {
            Console.WriteLine("q - grizti atgal");
            Console.WriteLine("y - ideti i krepseli visas rastas dainas");
            var pasirinkimas = Console.ReadLine();
            validator.validatePirkimoProcesas(pasirinkimas, "qy");
            switch (pasirinkimas)
            {
                case "q":
                    Console.Clear();
                    idetiIKrepseliLangas();
                    break;
                case "y":
                    Console.Clear();
                    switch (pasirinktasVeiksmas)
                    {
                        case 1:
                            dainuKrepselis = managerDB.searchTracksById(savedId);
                            break;
                        case 2:
                            dainuKrepselis = managerDB.searchTracksByName(savedName);
                            break;
                        case 3:
                            dainuKrepselis = managerDB.searchTracksByAlbumId(savedAlbumId);
                            break;
                        case 4:
                            dainuKrepselis = managerDB.searchByAlbumName(savedAlbumName);
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                    pirkimoLangas();
                    break;
                default:
                    break;
            }
        }

        public void perziuretiKrepseli()
        {
            if (dainuKrepselis == null)
            {
                Console.WriteLine("Pirkiniu krepselis yra tuscias, press any key to continue...");
                Console.ReadLine();
                pirkimoLangas();
                return;
            }
            foreach (var track in dainuKrepselis)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
            Console.WriteLine("q - grizti atgal || y - uzbaigti pirkima");
            var pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "q":
                    Console.Clear();
                    pirkimoLangas();
                    break;
                case "y":
                    double totalNoTax = 0;
                    Console.Clear();
                    Console.WriteLine($"Name: {activeUser.FirstName}");
                    Console.WriteLine($"Surname: {activeUser.LastName}");
                    Console.WriteLine($"Adress: {activeUser.Address}");
                    Console.WriteLine($"Phone: {activeUser.Phone}");
                    Console.WriteLine($"Postal Code: {activeUser.PostalCode}");
                    Console.WriteLine();
                    foreach (var track in dainuKrepselis)
                    {
                        Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
                        
                        totalNoTax += Convert.ToDouble(Encoding.Default.GetString(track.UnitPrice));
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Total Without Tax: {Math.Round(totalNoTax,2)} Eur");
                    Console.WriteLine("Tax: 21%");
                    Console.WriteLine($"Total: {Math.Round(totalNoTax + totalNoTax * 0.21, 2)} Eur");
                    managerDB.addInvoice(activeUser,totalNoTax);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    pirkimoLangas();
                    break;
                default:
                    break;
            }
        }

        public void darbuotojuMeniu()
        {
            Console.WriteLine("1. Keisti klientu duomenis");
            Console.WriteLine("2. Pakeisti dainos statusa");
            Console.WriteLine("3. Statistika(darbuotojams");
            var pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    Console.Clear();
                    darbuotojuMeniuKeistiDuomenis();
                    break;
                case "2":
                    Console.Clear();
                    darbuotojuMeniuKeistiDainosStatusa();
                    break;
                case "3":
                    Console.Clear();
                    darbuotojuMeniuStatistika();
                    break;
                case "q":
                    Console.Clear();
                    initialWindow();
                    break;
                default:
                    break;
            }
        }

        public void darbuotojuMeniuKeistiDuomenis()
        {
            Console.WriteLine("1. Gauti pirkeju sarasa");
            Console.WriteLine("2. Pasalinti pirkeja pagal Id");
            Console.WriteLine("3. Modifikuoti pirkejo duomenis");
            var pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    Console.Clear();
                    managerDB.getAllCustomers();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    darbuotojuMeniuKeistiDuomenis();
                    break;
                case "2":
                    Console.Clear();
                    salintiCustomerPagalId();
                    break;
                case "3":
                    Console.Clear();
                    modifikuotiPirkejoDuomenis();
                    break;
                case "q":
                    Console.Clear();
                    darbuotojuMeniu();
                    break;
                default:
                    break;
            }
        }
        public void salintiCustomerPagalId()
        {
            Console.WriteLine("Iveskite Id");
            var id = long.Parse(Console.ReadLine());
            Console.Clear();
            managerDB.getCustomerById(id);
            Console.WriteLine("Ar si vartotoja noretumete pasalinti?");
            Console.WriteLine("q - grizti atgal  ||  y - pasalinti");
            var pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "q":
                    Console.Clear();
                    darbuotojuMeniuKeistiDuomenis();
                    break;
                case "y":
                    Console.Clear();
                    managerDB.salintiCustomerPagalId(id);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    darbuotojuMeniuKeistiDuomenis();
                    break;
                default:
                    break;
            }

        }

        public void modifikuotiPirkejoDuomenis()
        {
            Console.WriteLine("Iveskite Id");
            var id = long.Parse(Console.ReadLine());
            Console.Clear();
            managerDB.getCustomerById(id);
            Console.WriteLine();

            Console.WriteLine("Iveskite nauja Varda: ");
            var vardas = Console.ReadLine();
            Console.WriteLine("Iveskite nauja Pavarde: ");
            var pavarde = Console.ReadLine();
            Console.WriteLine("Iveskite nauja Email: ");
            var email = Console.ReadLine();
            managerDB.updateCustomer(id,vardas,pavarde,email);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
            darbuotojuMeniuKeistiDuomenis();
        }

        public void darbuotojuMeniuKeistiDainosStatusa()
        {
            Console.WriteLine("1. Gauti dainu sarasa");
            Console.WriteLine("2. Keisti dainos statusa");
            var pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    Console.Clear();
                    managerDB.getAllTracks();
                    break;
                case "2":
                    Console.Clear();
                    keistiDainosStatusa();
                    break;
                case "q":
                    Console.Clear();
                    darbuotojuMeniu();
                    break;
                default:
                    break;
            }
        }
        public void keistiDainosStatusa()
        {
            Console.WriteLine("Iveskite Id");
            var id = long.Parse(Console.ReadLine());
            Console.Clear();
            managerDB.getTrackById(id);
            Console.WriteLine();

            Console.WriteLine("1. Keisti i Active");
            Console.WriteLine("2. Keisti i Inactive");
            var pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    managerDB.changeTrackStatus(id, "Inactive");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    darbuotojuMeniuKeistiDainosStatusa();
                    break;
                case "2":
                    managerDB.changeTrackStatus(id, "Active");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    darbuotojuMeniuKeistiDainosStatusa();
                    break;
                default:
                    break;
            }
        }

        public void darbuotojuMeniuStatistika()
        {
            Console.WriteLine("1. Isgauti visas kliento ataskaitas pagal kliento id");
            Console.WriteLine("2. Išgauti veiklos pelna (Neatskaičius mokesčių pilna suma)");
            Console.WriteLine("3. Išgauti veiklos pelną pagal paduotus metus");
            Console.WriteLine("4. Išgauti kiek kokio žanro kūrinių buvo nupirkta (Rikiuota pagal dydį)");
            var pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Iveskite Id");
                    var id = long.Parse(Console.ReadLine());
                    Console.Clear();
                    managerDB.getInvoiceByCustomerId(id);

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    darbuotojuMeniuStatistika();
                    break;
                case "2":
                    Console.Clear();
                    var totalIncome = managerDB.getTotalIncome() + managerDB.getTotalIncome()*0.21;
                    Console.WriteLine($"Total Income: {totalIncome}");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    darbuotojuMeniuStatistika();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Iveskite metus");
                    DateTime metai = DateTime.Parse(Console.ReadLine());
                    Console.Clear();
                    totalIncome = managerDB.getTotalIncomebyYear(metai) + managerDB.getTotalIncomebyYear(metai) * 0.21;

                    Console.WriteLine($"Total Income: {totalIncome}");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    darbuotojuMeniuStatistika();
                    break;
                case "4":
                    Console.Clear();
                    managerDB.countGenreSold();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    darbuotojuMeniuStatistika();
                    break;
                case "q":
                    Console.Clear();
                    darbuotojuMeniu();
                    break;
                default:
                    break;
            }
        }
    }
}
