using System;
using System.Linq;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Repository
{
    public interface IAppleProduct
    {
        void Create(AppleProduct appleProduct);
        void Delete(int id);
        IQueryable<AppleProduct> GetAll();
        AppleProduct Read(int id);
        void Update(AppleProduct appleProduct);
    }
}
