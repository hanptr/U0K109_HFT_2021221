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
            var q1 = from x in appleServiceRepo.GetAll()
                     group x by x.ServiceID into g
                     select new KeyValuePair<int, double>(g.Key, g.Average(t => t.Customers.Average(z => z.Products.Count())));
            
            return q1;
        }
    }
}
