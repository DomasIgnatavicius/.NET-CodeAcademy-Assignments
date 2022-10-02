using Microsoft.EntityFrameworkCore;
using Music_Shop_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Shop_DB.Database.Services
{
    public class ManagerDb
    {
        public List<Track> getAllTracks()
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} { track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
            return tracks;
        }
        public void getTrackById(long id)
        {
            using var context = new chinookContext();
            var track = context.Tracks.Find(id);
            Console.WriteLine($"{track.TrackId} {track.Name} {track.Status} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
        }
        public void changeTrackStatus(long id, string status)
        {
            if(status == "Active")
            {
                using var context = new chinookContext();
                var track = context.Tracks.Find(id);
                track.Status = "Inactive";
                context.SaveChanges();
            }
            else if (status == "Inactive")
            {
                using var context = new chinookContext();
                var track = context.Tracks.Find(id);
                track.Status = "Active";
                context.SaveChanges();
            }
            
        }
        public List<Customer> getAllCustomers()
        {
            using var context = new chinookContext();
            var customers = context.Customers.ToList();
            foreach (var customer in context.Customers)
            {
                Console.WriteLine($"{customer.CustomerId} {customer.FirstName} {customer.LastName}");
            }
            return customers;
        }
        public void getTracksNameABC()
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .OrderBy(x => x.Name)
                .Include(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }
        public void getTracksNameCBA()
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .OrderByDescending(x => x.Name)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }
        public void getTracksByComposer()
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .OrderBy(x => x.Composer)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }
        public void getTracksByGenre()
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .OrderBy(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }
        public void getTracksByComposerAndGenre()
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .OrderBy(x => x.Composer).ThenBy(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }
        public List<Models.Track> searchTracksById(int id)
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.TrackId == id)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
            return tracks;
        }
        public List<Models.Track> searchTracksByName(string name)
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.Name == name)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
            return tracks;
        }
        public void searchTracksByComposer(string composer)
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.Composer == composer)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }
        public void searchTracksByGenre(string genre)
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.Genre.Name == genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }
        public List<Models.Track> searchTracksByAlbumId(long albumId)
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.AlbumId == albumId)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
            return tracks;
        }
        public List<Models.Track> searchByAlbumName(string albumName)
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Include(x => x.Album)
                .Where(x => x.Album.Title == albumName)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
            return tracks;
        }
        public void searchTracksByMiliMore(int mili)
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.Milliseconds > mili)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }
        public void searchTracksByMiliLess(int mili)
        {
            using var context = new chinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.Milliseconds < mili)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }

        public void addInvoice(Customer customer, double totalNoTax)
        {
            using var context = new chinookContext();
            context.Invoices.Add(new Invoice
            {
                CustomerId = customer.CustomerId,
                InvoiceDate = DateTime.Now,
                BillingAddress = customer.Address,
                BillingPostalCode = customer.PostalCode,
                Total = Math.Round(totalNoTax + totalNoTax * 0.21, 2),
                Customer = customer
            });
            context.Customers.Attach(customer);
            context.SaveChanges();
        }

        public List<Invoice> findCustomerInvoices(Customer customer)
        {
            using var context = new chinookContext();
            var invoices = context.Invoices
                .Where(x => x.Customer == customer)
                .ToList();

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"{invoice.InvoiceId} {invoice.CustomerId} {invoice.InvoiceDate} {invoice.BillingAddress} {invoice.BillingPostalCode} {invoice.Total} Eur");
            }
            return invoices;
        }

        public void salintiCustomerPagalId(long id)
        {
            using var context = new chinookContext();
            var customer = context.Customers.Find(id);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
        public void getCustomerById(long id)
        {
            using var context = new chinookContext();
            var customer = context.Customers.Find(id);
            Console.WriteLine($"{customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Email}");
        }

        public void updateCustomer(long id, string vardas, string pavarde, string email)
        {
            using var context = new chinookContext();
            var customer = context.Customers.Find(id);
            customer.FirstName = vardas;
            customer.LastName = pavarde;
            customer.Email = email;
            context.SaveChanges();
        }

        public void getInvoiceByCustomerId(long customerId)
        {
            using var context = new chinookContext();
            var invoices = context.Invoices
                .Where(x => x.CustomerId == customerId);

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"{invoice.InvoiceId} {invoice.CustomerId} {invoice.InvoiceDate} {invoice.BillingAddress} {invoice.BillingPostalCode} {invoice.Total} Eur");
            }
        }
        public double getTotalIncome()
        {
            double totalIncome = 0;
            using var context = new chinookContext();
            var invoices = context.Invoices.ToList();
            foreach (var invoice in invoices)
            {
                totalIncome += invoice.Total;
            }
            return totalIncome;
        }
        public double getTotalIncomebyYear(DateTime year)
        {
            double totalIncome = 0;
            using var context = new chinookContext();
            var invoices = context.Invoices
                .Where(x => x.InvoiceDate.Year == year.Year)
                .ToList();
            
            foreach (var invoice in invoices)
            {
                totalIncome += invoice.Total;
            }
            return totalIncome;
        }

        public void addCustomer(string vardas, string pavarde, string? company, string? adresas, string? miestas, string? valstija, string? salis, string? pastoKodas, string? telNr, string? fax, string email)
        {
            using var context = new chinookContext();
            context.Customers.Add(new Customer
                {
                    FirstName = vardas,
                    LastName = pavarde,
                    Company = company,
                    Address = adresas,
                    City = miestas,
                    State = valstija,
                    Country = salis,
                    PostalCode = pastoKodas,
                    Phone = telNr,
                    Fax = fax,
                    Email = email
                });
            context.SaveChanges();
        }

        public void countGenreSold()
        {
            using var context = new chinookContext();
            var invoicesItem = context.Invoices
                .Include(x => x.InvoiceItems).ThenInclude(x => x.Track).ThenInclude(x => x.Genre)
                .GroupBy(x => x.InvoiceItems)
                .ToList();

            foreach (var item in invoicesItem)
            {
                Console.WriteLine($"{item.Key}");
            }
        }
    }
}
