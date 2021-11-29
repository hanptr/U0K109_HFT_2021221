using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;

namespace U0K109_HFT_2021221.Logic
{
    public class AppleProductLogic : IAppleProductLogic
    {
        IAppleProductRepository appleProdcutRepo;
        public AppleProductLogic(IAppleProductRepository appleProdcutRepo)
        {
            this.appleProdcutRepo = appleProdcutRepo;
        }
        public void Create(AppleProduct appleProduct)
        {
            if (appleProduct.Serial<0)
            {
                throw new Exception("Invalid Serial number.");
            }
            else if (appleProduct.Serial.ToString().Length>7)
            {
                throw new Exception("Too long Serial number.");
            }
            else
            {
                appleProdcutRepo.Create(appleProduct);
            }
            
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

    }
}
