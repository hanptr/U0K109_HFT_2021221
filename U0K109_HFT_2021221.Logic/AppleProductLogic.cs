using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;

namespace U0K109_HFT_2021221.Logic
{
    class AppleProductLogic : IAppleProductLogic
    {
        IAppleProductLogic appleProdcutRepo;
        public AppleProductLogic(IAppleProductLogic appleProdcutRepo)
        {
            this.appleProdcutRepo = appleProdcutRepo;
        }
        public void Create(AppleProduct appleProduct)
        {
            appleProdcutRepo.Create(appleProduct);
        }

        public void Delete(int id)
        {
            appleProdcutRepo.Delete(id);
        }

        public IEnumerable<AppleProduct> GetAll()
        {
            return appleProdcutRepo.GetAll();
        }

        public AppleProduct Read(int id)
        {
            return appleProdcutRepo.Read(id);
        }

        public void Update(AppleProduct appleProduct)
        {
            appleProdcutRepo.Update(appleProduct);
        }

        //non-crud methods
        
        public int HowManyiPhones() {
            return appleProdcutRepo.GetAll().Where(t => t.Type == U0K109_HFT_2021221.Models.Type.iPhone).Count();
        }


    }
}
