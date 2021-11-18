using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;

namespace U0K109_HFT_2021221.Logic
{
    class AppleServiceLogic : IAppleServiceLogic
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

        //non-crud metódusok

    }
}
