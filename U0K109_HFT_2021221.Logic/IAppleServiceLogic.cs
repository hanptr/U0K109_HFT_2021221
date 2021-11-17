using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;


namespace U0K109_HFT_2021221.Logic
{
    public interface IAppleServiceLogic
    {
        void Create(AppleService appleService);
        void Delete(int id);
        IEnumerable<AppleService> GetAll();
        AppleService Read(int id);
        void Update(AppleService appleService);
    }
}
