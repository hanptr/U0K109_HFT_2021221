using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;

namespace U0K109_HFT_2021221.Logic
{
    public interface IAppleProductLogic
    {
        void Create(AppleProduct appleProduct);
        void Delete(int id);
        IEnumerable<AppleProduct> GetAll();
        AppleProduct Read(int id);
        void Update(AppleProduct appleProduct);
    }
}
