using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;

namespace U0K109_HFT_2021221.Logic
{
    public class AppleServiceLogic : IAppleServiceLogic
    {
        IAppleServiceRepository appleServiceRepo;
        public AppleServiceLogic(IAppleServiceRepository appleServiceRepo)
        {
            this.appleServiceRepo = appleServiceRepo;
        }

        public void Create(AppleService appleService)
        {
            if (appleService.Location.Contains('%'))
            {
                throw new Exception("Not supported symbol.");
            }
            else
            {
                appleServiceRepo.Create(appleService);
            }
        }

        public void Delete(int id)
        {
            appleServiceRepo.Delete(id);
        }

        public IEnumerable<AppleService> GetAll()
        {
            return appleServiceRepo.GetAll();
        }

        public AppleService Read(int id)
        {
            return appleServiceRepo.Read(id);
        }

        public void Update(AppleService appleService)
        {
            appleServiceRepo.Update(appleService);
        }

        //non-crud methods
        public IEnumerable<AppleService> IdStartsWithTwo()
        {
            return appleServiceRepo.GetAll().Where(t => t.ServiceID.ToString().StartsWith("2"));
        }
        public IEnumerable<KeyValuePair<int, double>> AvgProdPerCustomerPerService()
        {
            var q1 = from x in appleServiceRepo.GetAll().AsEnumerable()
                     group x by x.ServiceID into g
                     select new KeyValuePair<int, double>(g.Key, g.Average(t => t.Customers.Average(z => z.Products.Count())));
            return q1;
        }
        public IEnumerable<KeyValuePair<int, int>> CustomerCountWithGmailPerService()
        {
            var q2 = from x in appleServiceRepo.GetAll().AsEnumerable()
                     group x by x.ServiceID into g
                     select new KeyValuePair<int, int>(g.Key, g.SelectMany(t => t.Customers).Where(z => z.Email.Contains("gmail.com")).Count());
            return q2;
        }
        public IEnumerable<KeyValuePair<int, int>> CountOfProdSerialStartingWith2PerService()
        {
            var q3 = from x in appleServiceRepo.GetAll().AsEnumerable()
                     group x by x.ServiceID into g
                     select new KeyValuePair<int, int>(g.Key, g.SelectMany(t => t.Products).Where(z => z.Serial.ToString().StartsWith("2")).Count());
            return q3;
        }
        public IEnumerable<KeyValuePair<int, int>> CountOfCustomerNameStartingWithBPerService()
        {
            var q4 = from x in appleServiceRepo.GetAll().AsEnumerable()
                     group x by x.ServiceID into g
                     select new KeyValuePair<int, int>(g.Key, g.SelectMany(t => t.Customers).Where(z => z.Name.Contains("B")).Count());
            return q4;
        }
        public IEnumerable<KeyValuePair<int, int>> CountOfProdcutsWithBlackColorPerService()
        {
            var q5 = from x in appleServiceRepo.GetAll().AsEnumerable()
                     group x by x.ServiceID into g
                     select new KeyValuePair<int, int>(g.Key, g.SelectMany(t => t.Products).Where(z => z.Color == "Black").Count());
            return q5;
        }

    }
}
