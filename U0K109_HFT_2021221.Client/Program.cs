using System;
using U0K109_HFT_2021221.Data;
using U0K109_HFT_2021221.Logic;
using U0K109_HFT_2021221.Repository;

namespace U0K109_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            AppleDbContext db = new AppleDbContext();
            db.SaveChanges();
            //AppleServiceRepository repo = new AppleServiceRepository(db);
            //AppleServiceLogic l = new AppleServiceLogic(repo);
            //l.AvgProdPerCustomerPerService();
            ;
        }
    }
}
